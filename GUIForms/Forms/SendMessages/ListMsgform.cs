using Aspose.Pdf.Plugins;
using GUIForms.Dtos;
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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUIForms.Forms.SendMessages
{
    public partial class ListMsgform : Form
    {
        Getcentralaizes GC;
        MultipartFormDataContent MFDC;
        public ListMsgform()
        {
            InitializeComponent();
            Loading();
        }
        void Loading()
        {
            MFDC = new MultipartFormDataContent();
            GC = new Getcentralaizes();
            var data = GC.Getcustomerdatalist();
            Custlist.Items.Clear();

            foreach (var row in data)
            {
                Custlist.Items.Add(new Custlistdto
                {
                    ID = row.ID,
                    Name = row.Name
                });
            }
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            Messageform MF = new Messageform();
            this.Hide();
            MF.ShowDialog();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Close();
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
                Btnsend.Visible = true;
            }
        }

        private async void Btnsend_Click(object sender, EventArgs e)
        {
            //string cleanedNumber = phone.Text.Replace("+", "") + "@c.us";
            //if (txtMsg.Visible)
            //{
            //    var url = "https://7103.api.greenapi.com/waInstance7103934473/sendMessage/80e868a9de5e4eacba13535ec26db6678b0e2a695bd54e7b85";
            //    var payload = new
            //    {
            //        chatId = cleanedNumber,
            //        message = txtMsg.Text.Trim()
            //    };

            //    var jsonPayload = JsonConvert.SerializeObject(payload);

            //    var client = new HttpClient();
            //    var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

            //    var response = await client.PostAsync(url, content);
            //    var responseText = await response.Content.ReadAsStringAsync();

            //    if (response.StatusCode == HttpStatusCode.OK)
            //    {
            //        var responseData = JsonConvert.DeserializeObject<Authorize>(responseText);
            //        if (!string.IsNullOrEmpty(responseData.idMessage))
            //        {
            //            txtfile.Clear();
            //            txtMsg.Clear();
            //        }
            //        else
            //        {
            //            MessageBox.Show("❌ فشل في الإرسال");
            //        }
            //    }
            //}
            //else
            //{
            //    var url = "https://7103.media.greenapi.com/waInstance7103934473/sendFileByUpload/80e868a9de5e4eacba13535ec26db6678b0e2a695bd54e7b85";
            //    var client = new HttpClient();

            //    MFDC.Add(new StringContent(cleanedNumber), "chatId");
            //    MFDC.Add(new StringContent(txtfile.Text.Trim()), "caption");



            //    var response = await client.PostAsync(url, MFDC);
            //    var responseText = await response.Content.ReadAsStringAsync();

            //    if (response.StatusCode == HttpStatusCode.OK)
            //    {
            //        //var responseText = await response.Content.ReadAsStringAsync();
            //        var responseData = JsonConvert.DeserializeObject<Authorize>(responseText);
            //        if (!string.IsNullOrEmpty(responseData.idMessage))
            //        {
            //            txtfile.Clear();
            //            txtMsg.Clear();
            //            txtMsg.Visible = true;
            //            txtfile.Visible = false;
            //            Btnsend.Visible = false;
            //        }
            //        else
            //        {
            //            MessageBox.Show("❌ فشل في الإرسال");
            //        }
            //    }
            //}
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            FrmTemplet FRT = new FrmTemplet();
            FRT.ShowDialog();
        }
    }
}
