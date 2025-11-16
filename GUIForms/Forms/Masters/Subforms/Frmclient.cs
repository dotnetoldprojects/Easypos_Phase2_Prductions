using Domain.Models;
using Easypos.Tailoring;
using GUIForms.Dtos;
using GUIForms.Forms.salesforms.Normal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using UOW;

namespace Easypos.Masters.Subforms
{
    public partial class Frmclient : Form
    {
        private Frmtailoring FSB = null;
        company DC;
        Getcentralaizes GC;
        public int Id { get; set; }
        public Frmclient()
        {
            InitializeComponent();
            Loading();
        }
        public void Loading()
        {
            GC = new Getcentralaizes();
            DC = (company)LanguageHelper.ApplyLanguage(this);
            DGV.Rows.Clear();
            foreach (var item in GC.Getcustomerdatalist())
            {
                DataGridViewRow newRow = new DataGridViewRow();
                newRow.CreateCells(DGV);
                newRow.Cells[0].Value = item.ID;
                newRow.Cells[1].Value = item.Name;
                newRow.Cells[2].Value = item.MobileNumber;
                DGV.Rows.Add(newRow);
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void dgw_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DGV.Rows.Count > 0)
            {
                Id = Convert.ToInt32(DGV.CurrentRow.Cells[0].Value.ToString());
                textBox2.Text = DGV.CurrentRow.Cells[1].Value.ToString();
                textBox4.Text = DGV.CurrentRow.Cells[2].Value.ToString();
                if (Application.OpenForms["Frmtailoring"] != null)
                {
                    Frmtailoring p = (Application.OpenForms["Frmtailoring"] as Frmtailoring);
                    p.clientID.SelectedValue = Id;
                    p.textBox15.Text = textBox4.Text;
                    p.Getcustdata();
                    this.Close();
                }
            }
            else
            {
                return;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            DGV.Rows.Clear();
            textBox2.Clear();
            textBox4.Clear();
            Loading();
        }
        private void Btnsearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox4.Text) && string.IsNullOrEmpty(textBox2.Text))
            {
                Loading();
            }
            else
            {
                DGV.Rows.Clear();
                foreach (var item in GC.Getcustomerdatalist().Where(x => x.Name.Contains(textBox2.Text) || x.MobileNumber.Contains(textBox4.Text)))
                {
                    DataGridViewRow newRow = new DataGridViewRow();
                    newRow.CreateCells(DGV);
                    newRow.Cells[0].Value = item.ID;
                    newRow.Cells[1].Value = item.Name;
                    newRow.Cells[2].Value = item.MobileNumber;
                    DGV.Rows.Add(newRow);
                }
            }
        }
        private void DGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DGV.Columns[e.ColumnIndex].Name == "Choose")
            {
                if (DGV.Rows.Count > 0)
                {
                    Id = Convert.ToInt32(DGV.CurrentRow.Cells[0].Value.ToString());
                    textBox2.Text = DGV.CurrentRow.Cells[1].Value.ToString();
                    textBox4.Text = DGV.CurrentRow.Cells[2].Value.ToString();
                    if (Application.OpenForms["Frmtailoring"] != null)
                    {
                        Frmtailoring p = (Application.OpenForms["Frmtailoring"] as Frmtailoring);
                        p.clientID.SelectedValue = Id;
                        p.textBox15.Text = textBox4.Text;
                        p.Getcustdata();
                        this.Close();
                    }
                }
                else
                {
                    return;
                }
            }
        }
    }
}
