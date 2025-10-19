using Domain.Dtos;
using Domain.Models;
using GUI.Helpers;
using GUIForms.Dtos;
using GUIForms.Forms.salesforms.Normal;
using GUIForms.helpers;
using GUIForms.models;
using Helpers.Dtos;
using InternetConnection;
using iText.Layout.Element;
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

namespace GUIForms.Forms.salesforms
{
    public partial class Frmzatcalist : Form
    {
        Printinginvoice _PI;
        company DC;
        Getcentralaizes GC;
        IUnitofwork _IUW;
        Getallsales GAS;
        List<SaleViewModel> Res;
        Zatcafutuers ZF;
        public bool Filter { get; set; }
        public Frmzatcalist()
        {
            InitializeComponent();
            Loading();
            DataTotals();
        }
        private void Loading()
        {
            Filter = false;
            GC = new Getcentralaizes();
            DC = (company)LanguageHelper.ApplyLanguage(this);
            ZF = new Zatcafutuers();
            _IUW = new Unitofwork(new EasyposEntities());
            _PI = new Printinginvoice();
            Getdatalist();
            LoadAllCombos();
        }
        private void LoadAllCombos()
        {
            Commondatasales.FillCombo(clientID, GC.Getcustomerdatalist(), "Name", "ID");
        }
        private void Btnclose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void picMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void Getdatalist()
        {
            GAS = new Getallsales();
            Res = GAS.GetSaleslist().Where(u => u.Status == "سجلت").ToList();
            DGV.DataSource = Res.Select(x => new
            {
                x.Invoiceno,
                x.TDate,
                x.TTime,
                x.NonVatTotal,
                x.Discount,
                x.VatAmount,
                x.TotalAmount,
                x.Cash,
                x.Bank,
                ThirdParty = x.ThirdPartyName ?? "عميل افتراضي",
                x.Type,
                x.Status,
                Invoicenumber = !string.IsNullOrEmpty(x.Invoicenumber) && int.TryParse(x.Invoicenumber, out int num)
                                ? $"inv-{num.ToString("D5")}"
                                : "",
                x.Note
            }).ToList();
        }
        private async void DGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var Dataid = DGV.CurrentRow.Cells[2].Value.ToString();
            var Datatye = DGV.CurrentRow.Cells[12].Value.ToString();
            if (DGV.Columns[e.ColumnIndex].Name == "Show")
            {
                frmMSalesBill FMS = new frmMSalesBill();
                frmMSalesBill open = Application.OpenForms["frmMSalesBill"] as frmMSalesBill;
                if (open == null)
                {
                    FMS.ClearAll();
                    FMS.Invid = int.Parse(Dataid);
                    FMS.Btnsave.Text = "تعديل";
                    FMS.Btnsaveandprint.Text = "تعديل وطباعه";
                    if (Datatye == "مسوده")
                    {
                        FMS.Invid = int.Parse(Dataid);
                        FMS.Btnsaveandprint.Visible = true;
                        FMS.Btnsave.Visible = true;
                        FMS.Btnsave.Visible = true;
                        FMS.Btnsave.Text = "تعديل";
                        FMS.Btnsaveandprint.Text = "تعديل وطباعه";
                    }
                    else
                    {
                        FMS.Ztkinv = DGV.CurrentRow.Cells[14].Value.ToString();
                        FMS.button1.Visible = true;
                        FMS.Invid = int.Parse(Dataid);
                        FMS.GroupBox1.Enabled = false;
                        FMS.DGV.Columns["Delete"].Visible = false;
                        FMS.DGV.Enabled = false;
                        FMS.groupBox3.Visible = false;
                        FMS.groupBox4.Visible = false;
                        FMS.RB1.Visible = false;
                        FMS.RB2.Visible = false;
                        FMS.Lblinvoice.Visible = true;
                        FMS.Lblinvoice.Text = "رقم الفاتوره : " + DGV.CurrentRow.Cells[14].Value.ToString();
                        FMS.Lblinvoice.Location = new Point(46, 33);
                        FMS.groupBox2.Location = new Point(550, 3);
                        FMS.Btnsaveandprint.Visible = false;
                        FMS.Btnsave.Visible = false;
                        FMS.Btnsave.Visible = false;
                        FMS.Billtype.Enabled = false;
                        FMS.Billtype.Text = Datatye;
                    }
                    FMS.Getsalesbill();
                    FMS.Show();
                    this.Close();
                }
                else
                {
                    open.ClearAll();
                    open.Activate();
                    if (open.WindowState == FormWindowState.Maximized)
                    {
                        open.Invid = int.Parse(Dataid);
                        if (Datatye == "مسوده")
                        {
                            open.Invid = int.Parse(Dataid);
                            open.Btnsaveandprint.Visible = true;
                            open.Btnsave.Visible = true;
                            open.Btnsave.Visible = true;
                            open.Btnsave.Text = "تعديل";
                            open.Btnsaveandprint.Text = "تعديل وطباعه";
                            open.Billtype.Text = Datatye;
                        }
                        else
                        {
                            open.Ztkinv = DGV.CurrentRow.Cells[14].Value.ToString();
                            open.button1.Visible = true;
                            open.Invid = int.Parse(Dataid);
                            open.GroupBox1.Enabled = false;
                            open.DGV.Columns["Delete"].Visible = false;
                            open.DGV.Enabled = false;
                            open.groupBox3.Visible = false;
                            open.groupBox4.Visible = false;
                            open.RB1.Visible = false;
                            open.RB2.Visible = false;
                            open.Lblinvoice.Visible = true;
                            open.Lblinvoice.Text = "رقم الفاتوره : " + DGV.CurrentRow.Cells[14].Value.ToString();
                            open.Lblinvoice.Location = new Point(46, 33);
                            //open.groupBox2.Location = new Point(550, 3);
                            open.Btnsaveandprint.Visible = false;
                            open.Btnsave.Visible = false;
                            open.Btnsave.Visible = false;
                            open.Billtype.Enabled = false;
                            open.Billtype.Text = Datatye;
                        }
                        open.Getsalesbill();
                        this.Close();
                    }
                }
            }
            else if (DGV.Columns[e.ColumnIndex].Name == "Print")
            {
                _PI.Invoice(int.Parse(Dataid), DGV.CurrentRow.Cells[14].Value.ToString());
            }
        }
        private void Btnsearch_Click(object sender, EventArgs e)
        {
            Filter = true;
            Getsalesbyfilters();
            DataTotals();
        }
        public void Getsalesbyfilters()
        {
            var query = Res.AsQueryable();

            // شرط رقم الفاتورة
            if (!string.IsNullOrEmpty(IN.Text))
            {
                int invoiceNo = int.Parse(IN.Text);
                query = query.Where(x => x.Invoiceno == invoiceNo);
            }

            // شرط العميل
            if (clientID.SelectedValue != null && (int)clientID.SelectedValue != 0)
            {
                int clientId = (int)clientID.SelectedValue;
                query = query.Where(x => x.ThirdPartyID == clientId);
            }

            // شرط التاريخ
            if (Searchbydate.Checked)
            {
                var fromDate = DTF.Value.Date;
                var toDate = DTT.Value.Date;
                query = query.AsEnumerable()
                             .Where(x =>
                             {
                                 DateTime tDate;
                                 return DateTime.TryParse(x.TDate, out tDate)
                                            && tDate.Date >= fromDate
                                            && tDate.Date <= toDate;
                             })
                             .AsQueryable();
            }

            // شرط الوقت
            if (Searchbytime.Checked)
            {
                if (TimeSpan.TryParse(TTF.Value.ToString("HH:mm:ss"), out var fromTime) &&
                    TimeSpan.TryParse(TTT.Value.ToString("HH:mm:ss"), out var toTime))
                {
                    query = query.AsEnumerable()
                                 .Where(x =>
                                 {
                                     if (TimeSpan.TryParse(x.TTime, out var tTime))
                                     {
                                         return tTime >= fromTime && tTime <= toTime;
                                     }
                                     return false;
                                 })
                                 .AsQueryable();
                }
            }



            // شرط رقم الهاتف
            if (!string.IsNullOrEmpty(txtPhone.Text))
            {
                query = query.Where(x => x.Phone.Contains(txtPhone.Text));
            }
            var result = query
    .AsEnumerable() // نحول لـ LINQ to Objects عشان نقدر نستخدم TryParse
    .Select(x =>
    {
        int numa;
        string formattedNumber = !string.IsNullOrEmpty(x.Invoicenumber) && int.TryParse(x.Invoicenumber, out numa)
            ? $"inv-{numa.ToString("D5")}"
            : "";

        return new
        {
            x.Invoiceno,
            x.TDate,
            x.TTime,
            x.NonVatTotal,
            x.Discount,
            x.VatAmount,
            x.TotalAmount,
            x.Cash,
            x.Bank,
            ThirdParty = x.ThirdPartyName ?? "عميل افتراضي",
            x.Type,
            x.Status,
            Invoicenumber = formattedNumber,
            x.Note,
        };
    })
    .ToList();


            // عرض النتائج
            DGV.DataSource = result;
        }
        private void Btnall_Click(object sender, EventArgs e)
        {
            Loading();
            DataTotals();
        }
        void DataTotals()
        {
            decimal Subtotal = 0;
            decimal Disctotal = 0;
            decimal totalTax = 0;
            decimal totalAmount = 0;

            foreach (DataGridViewRow row in DGV.Rows)
            {
                if (row.Cells["Subtotal"].Value != null)
                    Subtotal += Convert.ToDecimal(row.Cells["Subtotal"].Value);

                if (row.Cells["Discount"].Value != null)
                    Disctotal += Convert.ToDecimal(row.Cells["Discount"].Value);

                if (row.Cells["Tax"].Value != null)
                    totalTax += Convert.ToDecimal(row.Cells["Tax"].Value);

                if (row.Cells["Total"].Value != null)
                    totalAmount += Convert.ToDecimal(row.Cells["Total"].Value);
            }

            lblsubtotal.Text = Subtotal.ToString("N2");
            lbldisc.Text = Disctotal.ToString("N2");
            lbltax.Text = totalTax.ToString("N2");
            lbltot.Text = totalAmount.ToString("N2");

        }
    }
}
