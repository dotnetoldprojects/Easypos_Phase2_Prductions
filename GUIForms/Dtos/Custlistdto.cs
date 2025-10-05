using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUIForms.Dtos
{
    public class Custlistdto
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }

        public override string ToString()
        {
            return Name; // ده اللي هيتعرض في الليست
        }
    }
}
