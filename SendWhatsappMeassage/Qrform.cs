using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SendWhatsappMeassage
{
    public partial class Qrform : Form
    {
        public Qrform()
        {
            InitializeComponent();
            QRGenerate();
        }
        public Image ConvertBase64ToImage(string base64String)
        {
            byte[] imageBytes = Convert.FromBase64String(base64String);
            using (var ms = new MemoryStream(imageBytes))
            {
                return Image.FromStream(ms);
            }
        }
        public async Task QRGenerate()
        {
            var QR = "waInstance7103934473/qr/80e868a9de5e4eacba13535ec26db6678b0e2a695bd54e7b85";
            var url = "https://7103.api.greenapi.com/" + QR;
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(url);
            var responseText = await response.Content.ReadAsStringAsync();
            Authorize result = JsonConvert.DeserializeObject<Authorize>(responseText);
            pictureBox1.Image = ConvertBase64ToImage(result.message);
        }

        private async void Btndel_Click(object sender, EventArgs e)
        {
            var Auth = "waInstance7103934473/getStateInstance/80e868a9de5e4eacba13535ec26db6678b0e2a695bd54e7b85";
            var url = "https://7103.api.greenapi.com/" + Auth;

            HttpClient client = new HttpClient();
            var response = await client.GetAsync(url);
            var responseText = await response.Content.ReadAsStringAsync();
            Authorize result = JsonConvert.DeserializeObject<Authorize>(responseText);
            if (result.stateInstance == "notAuthorized")
            {
                MessageBox.Show("Not Authorized");
                return;
            }
            else
            {
                this.Hide();
                Messageform form1 = new Messageform();
                form1.Show();
            }
        }
    }
}
