using Domain.Models;
using GUIForms.Dtos;
using GUIForms.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UOW;

namespace GUIForms.helpers
{
    public class UBLClass
    {
        IUnitofwork _IUW;
        public Paymentenum Payenum { get; set; }
        public company DC { get; set; }
        public void SaveUBL(string QRCode, string Invoicehash, string Uuid,string Invoice,int? Saleid,string Status, string path,int invid, string PIH)
        {
            _IUW = new Unitofwork(new EasyposEntities());
            UBL ubl = new UBL
            {
                QRCode = QRCode,
                Invoicehash = Invoicehash,
                Uuid = Uuid,
                Invoice = Invoice,
                Saleid = Saleid, 
                Status = Status,
                Path = path,
                invoicenumber = invid,
                PIH = PIH,
                Flage = "فاتورة مبيعات",
            };
            if (DC.Signtype == (int)Payenum)
            {
                _IUW.UBLS.Insert(ubl);
                _IUW.Complete();
            }
        }
    }
}
