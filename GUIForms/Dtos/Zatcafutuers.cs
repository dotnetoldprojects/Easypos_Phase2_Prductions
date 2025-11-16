using Aspose.Pdf;
using Domain.Dtos;
using Domain.Models;
using GUI.Helpers;
using GUIForms.helpers;
using GUIForms.models;
using Helpers.Dtos;
using java.time.format;
using QRCoder.Extensions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using UOW;

namespace GUIForms.Dtos
{
    public class Zatcafutuers
    {
        IUnitofwork _IUW;
        public int invid { get; set; }
        public int nextNumber { get; set; }
        public string Zatcainv { get; set; }
        public Paymentenum Payenum { get; set; }
        public company DC { get; set; }
        Getcentralaizes GC;
        public Zatcafutuers()
        {
            // Constructor فارغ، التحميل بيتم يدويًا
        }

        public async Task Loading()
        {
            _IUW = new Unitofwork(new EasyposEntities());
            await Getzatcaid();
        }

        private async Task Getzatcaid()
        {
            var lastInvoice = _IUW.UBLS.GetAll().OrderByDescending(i => i.Saleid).FirstOrDefault();
            nextNumber = (int)(lastInvoice != null ? (lastInvoice.Saleid + 1) : 1);
            Zatcainv = $"inv-{nextNumber:D5}";
            await Getsalesdata();
        }

        private async Task Getsalesdata()
        {
            var Salesinnvoice = _IUW.sales.Get(invid);
            var SDinvoice = _IUW.salesdetailes.GetAll().Where(x => x.InvoiceNo == invid).ToList();
            await Generatexml(Salesinnvoice, SDinvoice);
        }

        private async Task Generatexml(sale sal, List<salesdetaile> SD)
        {
            List<ProductLine> productLines = new List<ProductLine>();
            Geneatexml GXL = new Geneatexml
            {
                Custid = (int)sal.ThirdPartyID,
                Invtitle = Zatcainv
            };

            const string unitCode = "PCE";
            const decimal taxPercent = 15m;
            int IL = 1;
            foreach (var item in SD)
            {
                var UP = double.Parse(item.ItemPrice.ToString()) / 1.15;
                var GUP = Math.Round(UP, 2).ToString();
                productLines.Add(new ProductLine
                {
                    //Id = item.TDetailNo.ToString(),
                    Id = IL.ToString(),
                    Name = item.TDDesc,
                    Quantity = int.Parse(item.Quantity.ToString()),
                    UnitCode = unitCode,
                    UnitPrice = DC.PricesWithVAT == 1 ? decimal.Parse(GUP) : decimal.Parse(item.ItemPrice.ToString()),
                    Discount = decimal.Parse(item.Discount.ToString()),
                    TaxPercent = taxPercent
                });
                IL++;
            }

            string InputPath = @"Data/Invoice.xml";
            var RBD = Convert.ToDecimal(sal.Discount);
            bool RB2 = RBD > 0;

            GXL.Createxmldata(productLines, DC, RB2, RBD);

            var xmlContent = File.ReadAllText(InputPath);
            GC = new Getcentralaizes();
            var Doc = GC.LoadInvoiceFromString(xmlContent);

            Signdtos Sdtos = new Signdtos
            {
                invno = invid
            };
            Sdtos.DC = DC;
            Sdtos.Payenum = Payenum;
            await Sdtos.Sign(Doc, Zatcainv);

            var GUL = _IUW.UBLS.GetAll().FirstOrDefault(x => x.Saleid == Sdtos.Saleid);
            if (GUL != null)
            {
                Sdtos.Ublid = GUL.Id;
                Sdtos.flage = "فاتورة مبيعات";
                Sdtos.Saleid = null;
                if (DC.Signtype == (int)Payenum)
                {
                    Sdtos.Saleid = nextNumber;
                    // ✅ فقط لو نوع التوقيع يستدعي الإرسال
                    await Sdtos.SendInvoiceAsync(GUL.Invoicehash, GUL.Uuid, GUL.Invoice, GUL.Path, GUL.QRCode, GUL.PIH);
                }
            }
        }
    }
}
