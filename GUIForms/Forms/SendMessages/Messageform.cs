using CountryCodes;
using GUIForms.Dtos;
using GUIForms.helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUIForms.Forms.SendMessages
{
    public partial class Messageform : Form
    {
        Getcentralaizes GC;
        List<CountryInfo> CI;
        MultipartFormDataContent MFDC;
        public Messageform()
        {
            InitializeComponent();
            GC = new Getcentralaizes();
            Commondatasales.FillCombo(clientID, GC.Getcustomerdatalist(), "Name", "ID");
            Getingcountrycode();
            MFDC = new MultipartFormDataContent();
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
        }
        private void picClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void clientID_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var GClient = GC.Getcustomerdatalist().Where(c => c.ID == Convert.ToInt32(clientID.SelectedValue)).FirstOrDefault();
            if (GClient != null)
            {
                string rawNumber = GClient.MobileNumber.Trim();

                // نحاول نلاقي أول دولة يبدأ بها الرقم
                var matchedCountry = CI.FirstOrDefault(c => rawNumber.StartsWith(c.DialCode));
                if (matchedCountry == null)
                {
                    MessageBox.Show("❌ الرقم لا يحتوي على كود دولة معروف.");
                    return;
                }
                else
                {
                    phone.Text = GClient.MobileNumber;
                    Btnup.Visible = true;
                }
            }
        }
        private void txtMsg_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMsg.Text.Trim()))
            {
                Btnsend.Visible = true;
            }
            else
            {
                Btnsend.Visible = false;
            }
        }
        private async void Btnsend_Click(object sender, EventArgs e)
        {
            string cleanedNumber = phone.Text.Replace("+", "") + "@c.us";
            if (txtMsg.Visible)
            {
                var url = "https://7103.api.greenapi.com/waInstance7103934473/sendMessage/80e868a9de5e4eacba13535ec26db6678b0e2a695bd54e7b85";
                var payload = new
                {
                    chatId = cleanedNumber,
                    message = txtMsg.Text.Trim()
                };

                var jsonPayload = JsonConvert.SerializeObject(payload);

                var client = new HttpClient();
                var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(url, content);
                var responseText = await response.Content.ReadAsStringAsync();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var responseData = JsonConvert.DeserializeObject<Authorize>(responseText);
                    if (!string.IsNullOrEmpty(responseData.idMessage))
                    {
                        txtfile.Clear();
                        txtMsg.Clear();
                    }
                    else
                    {
                        MessageBox.Show("❌ فشل في الإرسال");
                    }
                }
            }
            else
            {
                var url = "https://7103.media.greenapi.com/waInstance7103934473/sendFileByUpload/80e868a9de5e4eacba13535ec26db6678b0e2a695bd54e7b85";
                var client = new HttpClient();

                MFDC.Add(new StringContent(cleanedNumber), "chatId");
                MFDC.Add(new StringContent(txtfile.Text.Trim()), "caption");



                var response = await client.PostAsync(url, MFDC);
                var responseText = await response.Content.ReadAsStringAsync();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    //var responseText = await response.Content.ReadAsStringAsync();
                    var responseData = JsonConvert.DeserializeObject<Authorize>(responseText);
                    if (!string.IsNullOrEmpty(responseData.idMessage))
                    {
                        txtfile.Clear();
                        txtMsg.Clear();
                        txtMsg.Visible = true;
                        txtfile.Visible = false;
                        Btnsend.Visible = false;
                    }
                    else
                    {
                        MessageBox.Show("❌ فشل في الإرسال");
                    }
                }
            }
        }
        private void Btnup_Click(object sender, EventArgs e)
        {
            txtMsg.Clear();
            txtMsg.Visible = false;
            var FD = OFD.ShowDialog();
            if (FD == DialogResult.OK)
            {
                var filePath = OFD.FileName;
                var fileStream = File.OpenRead(filePath);
                var fileContent = new StreamContent(fileStream);
                fileContent.Headers.ContentType = new MediaTypeHeaderValue("application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
                MFDC.Add(fileContent, "file", OFD.SafeFileName);
                txtfile.Visible = true;
                Btnsend.Visible = true;
            }
            else
            {
                txtMsg.Visible = true;
                Btnsend.Visible = false;
            }
        }

        private void Btnlist_Click(object sender, EventArgs e)
        {
            ListMsgform LMF = new ListMsgform();
            this.Hide();
            LMF.ShowDialog();
        }
    }
}
