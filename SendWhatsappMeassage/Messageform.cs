using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SendWhatsappMeassage
{
    public partial class Messageform : Form
    {
        //Getcentralaizes GC;
        public Messageform()
        {
            InitializeComponent();
            //GC = new Getcentralaizes();
            //Commondatasales.FillCombo(clientID, GC.Getcustomerdatalist(), "Name", "ID");
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
