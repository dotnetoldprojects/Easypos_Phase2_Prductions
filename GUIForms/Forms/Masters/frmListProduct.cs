using Domain.Models;
using Easypos.Masters.Subforms;
using GUIForms.Dtos;
using GUIForms.helpers;
using GUIForms.models;
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using UOW;

//using Org.BouncyCastle.Utilities.Collections;

namespace Easypos.Masters
{
    public partial class frmListProduct : Form
    {
        public int UId { get; set; }
        public int CId { get; set; }
        company DC;
        Getcentralaizes GC;
        product Pro;
        productitem Pi;
        IUnitofwork _IUW;
        Usingnumber _NO;
        private List<ProductViewModel> _EVM;
        BindingList<ItemRow> IR;
        public frmListProduct()
        {
            Pi = new productitem();
            InitializeComponent();
            Loading();
        }
        private void Loading()
        {
            _NO = new Usingnumber();
            GC = new Getcentralaizes();
            DC = (company)LanguageHelper.ApplyLanguage(this);
            _IUW = new Unitofwork(new EasyposEntities());
            Pro = new product();
            GLPC();
            GetProductData();
            CBItems.DataSource = GC.GetItemsdatalist();
            CBItems.DisplayMember = "Itemname";   // اللي المستخدم هيشوفه
            CBItems.ValueMember = "ID";           // القيمة اللي هتكون مخزنة
            IR = new BindingList<ItemRow>();
            DGVProitems.AutoGenerateColumns = true;
            DGVProitems.DataSource = IR;
        }
        private void GetProductData()
        {
            var products = _IUW.products.GetAll();
            var unitTypes = _IUW.unittypes.GetAll();
            var categories = _IUW.categories.GetAll();

            _EVM = (from p in products
                    join u in unitTypes on p.Unitid equals u.ID
                    join c in categories on p.CategoryNo equals c.CategoryNo
                    select new ProductViewModel
                    {
                        ProductNo = p.ProductNo,
                        ProductCode = p.ProductCode,
                        Description = p.Description,
                        Barcode = p.Barcode,
                        UnitPrice = p.UnitPrice,
                        StocksOnHand = p.StocksOnHand ?? 0,
                        CategoryNo = c.CategoryNo,
                        Unitid = p.Unitid ?? 0,
                        ShowInPOS = p.ShowInPOS ?? false,
                        AllowInventory = p.AllowInventory,
                        ReorderLevel = p.ReorderLevel ?? 0,
                        CategoryName = c.CategoryName,
                        UnitName = u.UName,
                    }).ToList();
            DGV.DataSource = _EVM
                .Select(p => new {
                    p.ProductNo,
                    p.ProductCode,
                    p.Description,
                    p.Barcode,
                    p.UnitPrice,
                    p.StocksOnHand,
                    p.CategoryName,
                    p.UnitName,
                    p.Unitid,
                    p.CategoryNo,
                    p.ShowInPOS,
                    p.AllowInventory,
                    p.ReorderLevel
                }).ToList();
        }
        private void GLPC()
        {
            var Lastid = GC.Getproductdatalist().Max(p => p.ProductNo);
            string nextCode = $"EP{(Lastid + 1).ToString("D4")}";
            lblProductNo.Text = (Lastid + 1).ToString();
            txtProductCode.Text = nextCode;
        }
        private void Cleardata()
        {
            lblProductNo.Text = "";
            txtBarcode.Clear();
            txtUnitPrice.Clear();
            txtStocksOnHand.Text = "0";
            txtCategory.Clear();
            txtDescription.Clear();
            txtProductCode.Clear();
            txtReorderLevel.Text = "0";
            ShowInPOS.Checked = false;
            allowInventory.Checked = false;
            textBox1.Clear();
            UId = 0;
            CId = 0;
            Loading();
        }
        private void picClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void Button3_Click(object sender, EventArgs e)
        {
            frmSelectCategory flc = new frmSelectCategory();
            flc.CategorySelected += (id, name) =>
            {
                // هنا استقبلنا البيانات من الفورم التاني
                CId = id;
                txtCategory.Text = name;
            };
            flc.ShowDialog();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            Frmlistunit flu = new Frmlistunit();
            flu.UnitSelected += (id, name) =>
            {
                // هنا استقبلنا البيانات من الفورم التاني
                UId = id;
                textBox1.Text = name;
            };
            flu.ShowDialog();
        }
        private void Btnaddedit_Click(object sender, EventArgs e)
        {
            Pro.ProductCode = txtProductCode.Text;
            Pro.Description = txtDescription.Text;
            Pro.Barcode = txtBarcode.Text;
            Pro.UnitPrice = decimal.Parse(txtUnitPrice.Text);
            Pro.StocksOnHand = int.Parse(txtStocksOnHand.Text);
            Pro.Unitid = UId;
            Pro.CategoryNo = CId;
            Pro.ShowInPOS = ShowInPOS.Checked;
            Pro.AllowInventory = allowInventory.Checked;
            Pro.ReorderLevel = int.Parse(txtReorderLevel.Text);
            if (Pro.Unitid == 0)
            {
                MessageBox.Show("برجاء ادخال الوحده", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (Pro.CategoryNo == 0)
            {
                MessageBox.Show("برجاء ادخال الفئه", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!string.IsNullOrEmpty(lblProductNo.Text.Trim()))
            {
                Pro.ProductNo = int.Parse(lblProductNo.Text);
                _IUW.products.Update(Pro);
            }
            else
            {
                _IUW.products.Insert(Pro);
            }
            if (DGVProitems.Rows.Count > 0)
            {
                for (int i = 0; i < DGVProitems.Rows.Count; i++)
                {
                    Pi.Proid = lblProductNo.Text;
                    var itemId = int.Parse(DGVProitems.Rows[i].Cells[0].Value.ToString());
                    var itemqty = DGVProitems.Rows[i].Cells[1].Value.ToString();
                    _IUW.productitems.Delbyid(itemId);
                    Pi.itemid = itemId.ToString();
                    Pi.Quantity = itemqty;
                    _IUW.productitems.Insert(Pi);
                    _IUW.Complete();
                }
            }
            var data = _IUW.stok_transactions.Get(int.Parse(lblProductNo.Text));
            if (data == null)
            {
                data.Quantity += int.Parse(txtStocksOnHand.Text);
                data.Proid = int.Parse(lblProductNo.Text);
                _IUW.stok_transactions.Update(data);
            }
            _IUW.Complete();
            Cleardata();
        }
        private void Btndel_Click(object sender, EventArgs e)
        {
            _IUW.products.Delbyid(int.Parse(lblProductNo.Text));
            _IUW.Complete();
            Cleardata();
        }
        private void DGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DGV.Rows.Count > 0)
            {
                lblProductNo.Text = DGV.CurrentRow.Cells[0].Value.ToString();
                txtProductCode.Text = DGV.CurrentRow.Cells[1].Value.ToString();
                txtDescription.Text = DGV.CurrentRow.Cells[2].Value.ToString();
                txtBarcode.Text = DGV.CurrentRow.Cells[3].Value.ToString();
                txtUnitPrice.Text = DGV.CurrentRow.Cells[4].Value.ToString();
                txtStocksOnHand.Text = DGV.CurrentRow.Cells[5].Value.ToString();
                txtCategory.Text = DGV.CurrentRow.Cells[6].Value.ToString();
                textBox1.Text = DGV.CurrentRow.Cells[7].Value.ToString();
                UId = int.Parse(DGV.CurrentRow.Cells[8].Value.ToString());
                CId = int.Parse(DGV.CurrentRow.Cells[9].Value.ToString());
                ShowInPOS.Checked = bool.Parse(DGV.CurrentRow.Cells[10].Value.ToString());
                allowInventory.Checked = bool.Parse(DGV.CurrentRow.Cells[11].Value.ToString());
                txtReorderLevel.Text = DGV.CurrentRow.Cells[12].Value.ToString();
                //var result = GC.GetProductItems(lblProductNo.Text);
                LoadProductItems(lblProductNo.Text);
            }
        }
        private void LoadProductItems(string productId)
        {
            // انهي أي تعديل شغال
            if (DGVProitems.IsCurrentCellInEditMode)
                DGVProitems.EndEdit();

            // امسح القديم
            IR.Clear();

            // هات الداتا (AnonymousType = object)
            var result = GC.GetProductItems(productId);

            // اعمل Map لـ ItemRow
            foreach (var obj in result)
            {
                dynamic item = obj; // حل سريع للتعامل مع AnonymousType
                IR.Add(new ItemRow
                {
                    ID = item.ID ?? 0,
                    Itemname = item.Itemname,
                    Quantity = int.Parse(item.Quantity) ?? 1
                });
            }
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            Cleardata();
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            var Serch = _EVM.Where(x => x.Description != null && x.Description.Contains(txtSearch.Text))
                .ToList();
            DGV.DataSource = Serch.Select(p => new {
                p.ProductNo,
                p.ProductCode,
                p.Description,
                p.Barcode,
                p.UnitPrice,
                p.StocksOnHand,
                p.CategoryName,
                p.UnitName,
                p.Unitid,
                p.CategoryNo,
                p.ShowInPOS,
                p.AllowInventory,
                p.ReorderLevel
            }).ToList();
        }
        private void Btnadd_Click(object sender, EventArgs e)
        {
            string selectedId = CBItems.SelectedValue?.ToString();
            var row = IR.FirstOrDefault(x => x.ID == int.Parse(selectedId));
            if (row != null)
            {
                row.Quantity += 1;
                DGVProitems.Refresh(); // للتحديث
            }
            else
            {
                IR.Add(new ItemRow
                {
                    ID = int.Parse(selectedId),
                    Itemname = CBItems.Text,
                    Quantity = 1
                });
            }
        }
        private void DGVProitems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DGVProitems.Columns[e.ColumnIndex].Name == "Delete")
            {
                var RI = DGVProitems.CurrentRow.Index;
                var Data = DGVProitems.Rows[RI].Cells["itemname"].Value;
                if (Data != null)
                {
                    DGVProitems.Rows.RemoveAt(DGVProitems.CurrentRow.Index);
                    DGVProitems.Refresh();
                }
            }
        }

        private void txtStocksOnHand_KeyPress(object sender, KeyPressEventArgs e)
        {
            _NO.Usenumber(sender, e);
        }

        private void txtReorderLevel_KeyPress(object sender, KeyPressEventArgs e)
        {
            _NO.Usenumber(sender, e);
        }
    }
}
