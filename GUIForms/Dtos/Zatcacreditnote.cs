using Domain.Dtos;
using Domain.Models;
using GUI.Helpers;
using Helpers.Dtos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UOW;

namespace GUIForms.Dtos
{
    public class Zatcacreditnote
    {
        IUnitofwork _IUW;
        public int invid { get; set; }
        public int nextNumber { get; set; }
        public int TB { get; set; }
        public string Zatcainv { get; set; }
        public string Prevuuid { get; set; }
        public string Previnv { get; set; }
        public company DC { get; set; }
        Getcentralaizes GC;

        public Zatcacreditnote()
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
            var lastInvoice = _IUW.UBLS.GetAll().Where(x => x.invoicenumber == invid).FirstOrDefault();
            nextNumber = (int)(lastInvoice.Saleid);
            Zatcainv = $"R-{nextNumber:D4}";
            Previnv = $"inv-{nextNumber:D5}";
            Prevuuid = lastInvoice.Uuid;
            await Getreturnedata();
        }

        private async Task Getreturnedata()
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
                Custid = TB,
                Invtitle = Zatcainv,
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

            string InputPath = @"Data/Creditnote/Invoice.xml";
            var RBD = Convert.ToDecimal(sal.Discount);
            bool RB2 = RBD > 0;
            GXL.Prevuuid = Prevuuid;
            GXL.PrevInvtitle = Previnv;
            GXL.Status = "Creditnote";
            GXL.Createxmldata(productLines, DC, RB2, RBD);

            var xmlContent = File.ReadAllText(InputPath);
            GC = new Getcentralaizes();
            var Doc = GC.LoadInvoiceFromString(xmlContent);

            Signdtos Sdtos = new Signdtos
            {
                Saleid = nextNumber,
                invno = invid
            };
            Sdtos.flage = "مرتجع مبيعات";
            Sdtos.Status = "Creditnote";
            await Sdtos.Sign(Doc, Zatcainv);

            var GUL = _IUW.UBLS.GetAll().LastOrDefault(x => x.Saleid == Sdtos.Saleid);
            if (GUL != null)
            {
                Sdtos.Ublid = GUL.Id;
                await Sdtos.SendInvoiceAsync(GUL.Invoicehash, GUL.Uuid, GUL.Invoice, GUL.Path, GUL.QRCode, GUL.PIH);
            }
        }
    }
}
