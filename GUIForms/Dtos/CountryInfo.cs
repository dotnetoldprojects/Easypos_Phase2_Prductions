using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUIForms.Dtos
{
    public class CountryInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string IsoCode { get; set; } 
        public string DialCode { get; set; }
    }
}
