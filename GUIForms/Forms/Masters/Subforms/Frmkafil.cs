using CountryCodes;
using Domain.Models;
using GUIForms.Dtos;
using PhoneNumbers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UOW;

namespace GUIForms.Forms.Masters.Subforms
{
    public partial class Frmkafil : Form
    {
        company DC;
        Getcentralaizes GC;
        Kafil Kaf;
        IUnitofwork _IUW;
        Usingnumber _NO;
        List<CountryInfo> CI;
        public int Kafid { get; set; }
        public Frmkafil()
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
        private void Clearfields()
        {
            textBox2.Clear();
            textBox4.Clear();
        }
        private void Loading()
        {
            GC = new Getcentralaizes();
            DC = (company)LanguageHelper.ApplyLanguage(this);
            _IUW = new Unitofwork(new EasyposEntities());
            Getingcountrycode();
            var kafilList = _IUW.Kafils.GetAll()
                .Select(k => new
                {
                    Id = k.Id,
                    Name = k.Name,
                    NID = k.NID,
                    Phone = k.Phone
                })
                .ToList();
            DGV.DataSource = kafilList;
            Clearfields();
        }
        private void Add_Click(object sender, EventArgs e)
        {
            var Kaf = new Kafil();
            Kaf.Name = textBox2.Text;
            Kaf.NID = textBox1.Text;
            if (!string.IsNullOrEmpty(textBox4.Text))
            {
                var Codes = (CountryInfo)Countrybox.SelectedItem;
                if (Codes != null)
                {
                    var phoneNumberUtil = PhoneNumberUtil.GetInstance();
                    //var Naional = phoneNumberUtil.GetRegionCodeForCountryCode(20);
                    var phoneNumber = phoneNumberUtil.Parse(Codes.DialCode + textBox4.Text, Codes.IsoCode);
                    var isValid = phoneNumberUtil.IsValidNumber(phoneNumber);
                    if (!isValid)
                    {
                        MessageBox.Show("من فضلك تحقق من رقم الهاتف الصحيح.", "خطا في التحقق", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        Kaf.Phone = Codes.DialCode + textBox4.Text;
                    }
                }
            }
            _IUW.Kafils.Insert(Kaf);
            _IUW.Complete();
            Loading();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Kaf.Id = Kafid;
            Kaf.Name = textBox2.Text;
            Kaf.NID = textBox1.Text;
            if (!string.IsNullOrEmpty(textBox4.Text) && !textBox4.Text.Contains("+966"))
            {
                var Codes = (CountryInfo)Countrybox.SelectedItem;
                if (Codes != null)
                {
                    var phoneNumberUtil = PhoneNumberUtil.GetInstance();
                    //var Naional = phoneNumberUtil.GetRegionCodeForCountryCode(20);
                    var phoneNumber = phoneNumberUtil.Parse(Codes.DialCode + textBox4.Text, Codes.IsoCode);
                    var isValid = phoneNumberUtil.IsValidNumber(phoneNumber);
                    if (!isValid)
                    {
                        MessageBox.Show("من فضلك تحقق من رقم الهاتف الصحيح.", "خطا في التحقق", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        Kaf.Phone = Codes.DialCode + textBox4.Text;
                    }
                }
            }
            else
            {
                Kaf.Phone = textBox4.Text;
            }
            _IUW.Kafils.Update(Kaf);
            _IUW.Complete();
            Loading();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            _IUW.Kafils.Delbyid(Kafid);
            _IUW.Complete();
            Loading();
        }
        private void DGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DGV.Rows.Count > 0)
            {
                Kaf = new Kafil();
                Kafid = int.Parse(DGV.CurrentRow.Cells[0].Value.ToString());
                textBox2.Text = DGV.CurrentRow.Cells[1].Value.ToString();
                textBox1.Text = DGV.CurrentRow.Cells[2].Value.ToString();
                textBox4.Text = DGV.CurrentRow.Cells[3].Value.ToString();
            }
            else
            {
                return;
            }
        }
        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            //_NO.Usenumber(sender, e);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
