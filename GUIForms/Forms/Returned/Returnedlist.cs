using Aspose.Pdf;
using Aspose.Pdf.Operators;
using Domain.Models;
using GUIForms.Dtos;
using GUIForms.Forms.salesforms.Normal;
using GUIForms.helpers;
using InternetConnection;
using iText.StyledXmlParser.Jsoup.Nodes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UOW;

namespace GUIForms.Forms.Returned
{
    public partial class Returnedlist : Form
    {
        company DC;
        Getcentralaizes GC;
        Zatcacreditnote ZRF;
        IUnitofwork _IUW;
        public Returnedlist()
        {
            InitializeComponent();
            Loading();
        }
        private void Loading()
        {
            GC = new Getcentralaizes();
            DC = (company)LanguageHelper.ApplyLanguage(this);
            _IUW = new Unitofwork(new EasyposEntities());
            ZRF = new Zatcacreditnote();
            Getdatalist();
        }
        private void Btnclose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void picMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void Btnall_Click(object sender, EventArgs e)
        {
            Loading();
        }
        private void Getdatalist()
        {
            var Res = _IUW.returneds.GetAll().ToList();
            DGV.DataSource = Res.Select(x => new
            {
                x.Invoiceno,
                x.TDate,
                x.NonVatTotal,
                x.Discount,
                x.VatAmount,
                x.TotalAmount,
                x.Returnedtype,
            }).ToList();
        }
        private void Btnsearch_Click(object sender, EventArgs e)
        {
            Getsalesbyfilters();
        }
        public void Getsalesbyfilters()
        {
            var Res = _IUW.returneds.GetAll();

            // شرط رقم الفاتورة
            if (!string.IsNullOrEmpty(IN.Text))
            {
                var invoiceNo = Convert.ToUInt32(IN.Text);
                Res = Res.Where(x => x.Invoiceno == invoiceNo);
            }
            // شرط التاريخ
            if (Searchbydate.Checked)
            {
                var fromDate = DTF.Value.Date;
                var toDate = DTT.Value.Date;
                Res = Res.AsEnumerable()
                             .Where(x =>
                             {
                                 DateTime tDate;
                                 return DateTime.TryParse(x.TDate, out tDate)
                                            && tDate.Date >= fromDate
                                            && tDate.Date <= toDate;
                             })
                             .AsQueryable();
            }
            // تحويل النتائج
            var result = Res.Select(x => new
            {
                x.Invoiceno,
                x.TDate,
                x.NonVatTotal,
                x.Discount,
                x.VatAmount,
                x.TotalAmount,
                x.Returnedtype,
            }).ToList();

            // عرض النتائج
            DGV.DataSource = result;
        }

        private async void DGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var Datareg = DGV.CurrentRow.Cells[8].Value.ToString();
            var Invnum = DGV.CurrentRow.Cells[1].Value.ToString();
            if (DGV.Columns[e.ColumnIndex].Name == "Btnreg")
            {
                if (DC.ISUsePhase2)
                {
                    if (Datareg == "سجلت")
                    {
                        MessageBox.Show("لا يمكن تسجيل الفاتوره لانها مسجله مسبقا", "تسجيل فاتوره", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        Connector checker = new Connector();
                        bool isConnected = checker.CheckIfInternetConnected();
                        var Gp = _IUW.payments.GetAll().Where(x => x.InvoiceNo == int.Parse(Invnum)).FirstOrDefault();
                        if (Gp.Bank > 0)
                        {
                            var trans = new transaction();
                            trans.Invoiceno = Gp.InvoiceNo;
                            trans.Paynum = Gp.paymentNo;
                            trans.TDate = Gp.Date;
                            trans.Type = "سند ايصال مرتجعات";
                            trans.Paytype = "بنكي";
                            trans.ThirdPartyID = Gp.ThirdPartyID;
                            trans.Paid = Gp.Bank;
                            trans.Note = "";
                            _IUW.transactions.Insert(trans);
                            _IUW.Complete();
                        }
                        if (Gp.Cash > 0)
                        {
                            var trans = new transaction();
                            trans.Invoiceno = Gp.InvoiceNo;
                            trans.Paynum = Gp.paymentNo;
                            trans.TDate = Gp.Date;
                            trans.Type = "سند ايصال مرتجعات";
                            trans.Paytype = "نقدي";
                            trans.ThirdPartyID = Gp.ThirdPartyID;
                            trans.Paid = Gp.Cash;
                            trans.Note = "";
                            _IUW.transactions.Insert(trans);
                            _IUW.Complete();
                        }
                        if (isConnected)
                        {
                            Cursor.Current = Cursors.WaitCursor;
                            var Bank = Gp.Bank;
                            var Cash = Gp.Cash;
                            ZRF.TB = Gp.ThirdPartyID ?? 0;
                            ZRF.invid = Gp.InvoiceNo ?? 0;
                            ZRF.DC = DC;
                            if (DC.Signtype == 0)
                            {
                                if (Cash > 0)
                                {
                                    await ZRF.Loading();
                                }
                            }
                            if (DC.Signtype == 1)
                            {
                                if (Bank > 0)
                                {
                                    await ZRF.Loading();
                                }
                            }
                            if (DC.Signtype == 2)
                            {
                                await ZRF.Loading();
                            }
                            Cursor.Current = Cursors.Default;
                        }
                        else
                        {
                            MessageBox.Show("لا يوجد اتصال بالانترنت", "تسجيل فاتوره", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("لا يمكن تسجيل الفاتوره لان النظام غير مفعل عليه المرحله الثانيه برجاء التواصل مع الدعم الفني", "تسجيل فاتوره", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }
    }
}
