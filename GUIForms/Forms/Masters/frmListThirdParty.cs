using CountryCodes;
using Domain.Models;
using Easypos.Tailoring;
using GUIForms.Dtos;
using GUIForms.Forms.Masters.Subforms;
using GUIForms.helpers;
using Microsoft.VisualBasic;
using PhoneNumbers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Xml.Linq;
using UOW;

namespace Easypos.Masters
{
    public partial class frmListThirdParty : Form
    {
        company DC;
        Getcentralaizes GC;
        thirdparty TP;
        IUnitofwork _IUW;
        Usingnumber _NO;
        List<CountryInfo> CI;
        public frmListThirdParty()
        {
            InitializeComponent();
            Loading();
        }
        private void Getingcountrycode()
        {
            var dialType = typeof(CountryCallingCodes);
            var isoType = typeof(TwoLetterISORegionCode);

            var dialFields = dialType.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy);
            var isoFields = isoType.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy);
            int i = 0;
            CI = new List<CountryInfo>();
            foreach (var dialField in dialFields)
            {
                if (dialField.IsLiteral && !dialField.IsInitOnly && dialField.FieldType == typeof(string))
                {
                    string countryName = dialField.Name;
                    string dialCode = dialField.GetRawConstantValue()?.ToString();

                    // دور على نفس الدولة في كلاس ISO
                    var isoField = isoFields.FirstOrDefault(f => f.Name == countryName);
                    string isoCode = isoField?.GetRawConstantValue()?.ToString() ?? "??";
                    CI.Add(new CountryInfo
                    {
                        Id = i,
                        Name = countryName,
                        IsoCode = isoCode,
                        DialCode = dialCode
                    });
                    i++;
                }
            }
            Countrybox.DataSource = CI;
            Countrybox.DisplayMember = "Name";
            Countrybox.ValueMember = "Id";
            var selectedCountry = CI.FirstOrDefault(c => c.IsoCode == "SA");
            if (selectedCountry != null)
            {
                Countrybox.SelectedItem = selectedCountry;
            }
        }
        private void Loading()
        {
            radioClient.Checked = true;
            _NO = new Usingnumber();
            TP = new thirdparty();
            GC = new Getcentralaizes();
            DC = (company)LanguageHelper.ApplyLanguage(this);
            _IUW = new Unitofwork(new EasyposEntities());
            DGV.DataSource = GC.Getthirdpartydatalist()
                                .Select(x => new {
                                    ID = x.ID, 
                                    Name = x.Name,
                                    Type = x.Type,
                                    MobileNumber = x.MobileNumber,
                                    Address = x.Address,
                                    Typedata = x.Type,
                                    City = x.City,
                                    Comments = x.Comments,
                                    Email = x.Email,
                                    OpeningBalance = x.OpeningBalance,
                                    Taxnumber = x.Taxnumber,
                                    Billnumber= x.Billnumber,
                                    Pagenumber = x.Pagenumber
                                }).ToList();
            Getingcountrycode();
            Commondatasales.FillCombo(comboBox1, GC.Getkafildatalist(), "Name", "Id");
        }
        private void Clearfieldes(){
            txtNumber.Text = string.Empty;
            txtName.Clear();
            txt_seller_citysubdiv.Clear();
            txt_seller_cityname.Clear();
            textBox4.Clear();
            textBox3.Clear();
            textBox2.Clear();
            textBox1.Clear();
            txtOpeningBalance.Clear();
            txtMobile.Clear();
            txtComments.Clear();
            radioSuppliers.Checked = false;
            radioClients.Checked = false;
            if (DC.Systemlang == "الانجليزية" || DC.Systemlang == "English")
            {
                Btnsave.Text = "Add";
            }
            else
            {
                Btnsave.Text = "أضافة";
            }
            cbzatca.Checked = false;
            comdata.Visible = false;
            txt_seller_street.Clear();
            txt_seller_buildingnumber.Clear();
            txt_seller_cityname.Clear();
            txt_seller_citysubdiv.Clear();
            txt_seller_postalzone.Clear();
            txt_location.Clear();
            txtRN.Clear();
            Loading();
        }
        private void picClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            Clearfieldes();
        }
        private void DGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DC.Systemlang == "الانجليزية" || DC.Systemlang == "English")
            {
                Btnsave.Text = "Edit";
            }
            else
            {
                Btnsave.Text = "تعديل";
            }
            if (DGV.Rows.Count > 0)
            {
                txtNumber.Text = DGV.CurrentRow.Cells[1].Value.ToString();
                TP.ID = int.Parse(txtNumber.Text);
                txtName.Text = DGV.CurrentRow.Cells[2].Value.ToString();
                string fullNumber = DGV.CurrentRow.Cells[4].Value != null
                                       ? DGV.CurrentRow.Cells[4].Value.ToString()
                                       : "";
                var matchedCountry = CI.FirstOrDefault(c => fullNumber.StartsWith(c.DialCode));
                string localNumber = fullNumber;
                if (matchedCountry != null)
                {
                    localNumber = fullNumber.Substring(matchedCountry.DialCode.Length);
                    Countrybox.SelectedItem = matchedCountry;
                    txtMobile.Text = localNumber;
                }
                else
                {
                    txtMobile.Text = fullNumber; // Display the full number as is
                }
                //txtMobile.Text = DGV.CurrentRow.Cells[3].Value.ToString();
                //txt_seller_citysubdiv.Text = DGV.CurrentRow.Cells[4].Value != null
                //                       ? DGV.CurrentRow.Cells[4].Value.ToString()
                //                       : "";
                //txt_seller_cityname.Text = DGV.CurrentRow.Cells[5].Value != null
                //                       ? DGV.CurrentRow.Cells[5].Value.ToString()
                //                       : "";
                txtComments.Text = DGV.CurrentRow.Cells[13].Value?.ToString();
                txtOpeningBalance.Text = DGV.CurrentRow.Cells[10].Value != null
                                       ? DGV.CurrentRow.Cells[10].Value.ToString()
                                       : "";
                textBox4.Text = DGV.CurrentRow.Cells[11].Value.ToString();
                textBox3.Text = DGV.CurrentRow.Cells[12].Value != null
                                       ? DGV.CurrentRow.Cells[12].Value.ToString()
                                       : "";
                // Type Member
                var TM = DGV.CurrentRow.Cells[6].Value.ToString();
                if (TM == "2")
                {
                    radioClient.Checked = true;
                }
                else
                {
                    radioSupplier.Checked = true;
                }
            }
            else
            {
                Clearfieldes();
            }
        }
        private void Btnsave_Click(object sender, EventArgs e)
        {
            if (!radioClient.Checked && !radioSupplier.Checked)
            {
                MessageBox.Show("برجاء ادخال نوع المستخدم.", "خطأ");
                return;
            }
            else
            {
                if (string.IsNullOrEmpty(txtName.Text))
                {
                    MessageBox.Show("من فضلك ادخل الاسم", "خطأ");
                    return;
                }
                else
                {
                    TP.ISUsePhase2 = cbzatca.Checked;
                    if (cbzatca.Checked)
                    {
                        if (string.IsNullOrEmpty(txt_seller_street.Text))
                        {
                            MessageBox.Show("من فضلك ادخل اسم الشارع.", "خطأ في التحقق", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        else
                        {
                            TP.StreetName = txt_seller_street.Text;
                        }
                        if (string.IsNullOrEmpty(txt_seller_buildingnumber.Text))
                        {
                            MessageBox.Show("من فضلك ادخل رقم المبنى.", "خطأ في التحقق", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        else
                        {
                            TP.BuildingNumber = txt_seller_buildingnumber.Text;
                        }
                        if (string.IsNullOrEmpty(txt_seller_citysubdiv.Text))
                        {
                            MessageBox.Show("من فضلك ادخل اسم الحي.", "خطأ في التحقق", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        else
                        {
                            TP.CitySubdivisionName = txt_seller_citysubdiv.Text;
                        }
                        if (string.IsNullOrEmpty(txt_seller_cityname.Text))
                        {
                            MessageBox.Show("من فضلك ادخل اسم البلده.", "خطأ في التحقق", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        else
                        {
                            TP.CityName = txt_seller_cityname.Text;
                        }
                        if (string.IsNullOrEmpty(txt_seller_postalzone.Text))
                        {
                            MessageBox.Show("من فضلك ادخل الرقم البريدي.", "خطا في التحقق", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        else
                        {
                            TP.PostalZone = txt_seller_postalzone.Text;
                        }
                    }
                    TP.Name = txtName.Text;
                    if (!string.IsNullOrEmpty(txtMobile.Text))
                    {
                        var Codes = (CountryInfo)Countrybox.SelectedItem;
                        if (Codes != null)
                        {
                            var phoneNumberUtil = PhoneNumberUtil.GetInstance();
                            //var Naional = phoneNumberUtil.GetRegionCodeForCountryCode(20);
                            var phoneNumber = phoneNumberUtil.Parse(Codes.DialCode + txtMobile.Text, Codes.IsoCode);
                            var isValid = phoneNumberUtil.IsValidNumber(phoneNumber);
                            if (!isValid)
                            {
                                MessageBox.Show("من فضلك تحقق من رقم الهاتف الصحيح.", "خطا في التحقق", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            else
                            {
                                TP.MobileNumber = Codes.DialCode + txtMobile.Text;
                            }
                        }
                    }
                    TP.Taxnumber = textBox4.Text;
                    TP.Comments = txtComments.Text;
                    if (radioClient.Checked)
                    {
                        TP.Type = 2; // Client
                    }
                    else
                    {
                        TP.Type = 1; // Supplier
                    }
                    if (string.IsNullOrEmpty(txtOpeningBalance.Text))
                    {
                        TP.OpeningBalance = 0;
                    }
                    else
                    {
                        TP.OpeningBalance = double.Parse(txtOpeningBalance.Text);
                    }
                    if (!string.IsNullOrEmpty(txtNumber.Text.Trim()))
                    {
                        TP.ID = int.Parse(txtNumber.Text);
                        if (comboBox1.SelectedIndex > 0)
                        {
                            TP.Kafid = int.Parse(comboBox1.SelectedValue.ToString());
                        }
                    }
                    else
                    {
                        if (comboBox1.SelectedIndex > 0)
                        {
                            TP.Kafid = int.Parse(comboBox1.SelectedValue.ToString());
                        }
                    }
                    TP.Billnumber = textBox3.Text;
                    TP.Pagenumber = txtComments.Text;
                    if (Btnsave.Text == "حفظ")
                    {
                         _IUW.thirdparties.Insert(TP);
                    }
                    else
                    {
                        _IUW.thirdparties.Update(TP);
                    }
                    _IUW.Complete();
                    Loading();
                    if (Application.OpenForms["Frmtailoring"] != null)
                    {
                        Frmtailoring p = (Application.OpenForms["Frmtailoring"] as Frmtailoring);
                        p.LoadAllCombos();
                        //p.Cleargc();
                        p.clientID.Text = txtName.Text;
                        p.textBox15.Text = txtMobile.Text;
                        p.Getcustdata();
                        Clearfieldes();
                        this.Close();
                        return;
                        //p.textBox15.Text = txtMobile.Text;
                    }
                    Clearfieldes();
                }
            }
        }
        private void radioAll_CheckedChanged(object sender, EventArgs e)
        {
            Loading();
        }
        private void radioSuppliers_CheckedChanged(object sender, EventArgs e)
        {
            DGV.DataSource = GC.Getsupplierdatalist();
        }
        private void radioClients_CheckedChanged(object sender, EventArgs e)
        {
            DGV.DataSource = GC.Getcustomerdatalist();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (TP.ID != null)
            {
                var TH = _IUW.tailorheaders.GetAll().Where(x => x.Id == TP.ID.ToString()).FirstOrDefault();
                if (TH != null)
                {
                    MessageBox.Show("You cannot delete this third party because it is linked to tailoring records.", "Error");
                    return;
                }
                else
                {
                    _IUW.thirdparties.Delbyid(TP.ID);
                    _IUW.Complete();
                    Clearfieldes();
                }
            }
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox2.Text))
            {
                var Data = this.GC.Getthirdpartydatalist();
                var Serch = Data
                    .Where(x => x.Name != null && x.Name.Contains(textBox2.Text))
                                                    .Select(x => new {
                                                        ID = x.ID,
                                                        Name = x.Name,
                                                        Type = x.Type,
                                                        MobileNumber = x.MobileNumber,
                                                        Address = x.Address,
                                                        Typedata = x.Type,
                                                        City = x.City,
                                                        Comments = x.Comments,
                                                        Email = x.Email,
                                                        OpeningBalance = x.OpeningBalance,
                                                        Taxnumber = x.Taxnumber,
                                                        Billnumber = x.Billnumber,
                                                        Pagenumber = x.Pagenumber
                                                    }).ToList();
                DGV.DataSource = Serch;
            }
            else
            {
                Loading();
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                var Data = this.GC.Getthirdpartydatalist();
                var Serch = Data
                    .Where(x => x.MobileNumber != null && x.MobileNumber.Contains(textBox1.Text))
                                                    .Select(x => new {
                                                        ID = x.ID,
                                                        Name = x.Name,
                                                        Type = x.Type,
                                                        MobileNumber = x.MobileNumber,
                                                        Address = x.Address,
                                                        Typedata = x.Type,
                                                        City = x.City,
                                                        Comments = x.Comments,
                                                        Email = x.Email,
                                                        OpeningBalance = x.OpeningBalance,
                                                        Taxnumber = x.Taxnumber,
                                                        Billnumber = x.Billnumber,
                                                        Pagenumber = x.Pagenumber
                                                    }).ToList();
                DGV.DataSource = Serch;
            }
            else
            {
                Loading();
            }
        }
        private void cbzatca_CheckedChanged(object sender, EventArgs e)
        {
            if (cbzatca.Checked)
            {
                comdata.Visible = true;
                txtRN.Visible = true;
            }
            else
            {
                comdata.Visible = false;
                txtRN.Visible = false;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            _NO.Usenumber(sender, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Frmkafil fk = new Frmkafil();
            fk.ShowDialog();
        }
    }
}
