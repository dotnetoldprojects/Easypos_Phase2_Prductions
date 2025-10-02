using InternetConnection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SendWhatsappMeassage
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static async Task Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Connector checker = new Connector();
            bool isConnected = checker.CheckIfInternetConnected();
            if (isConnected) {
                var Auth = "waInstance7103934473/getStateInstance/80e868a9de5e4eacba13535ec26db6678b0e2a695bd54e7b85";
                var url = "https://7103.api.greenapi.com/" + Auth;

                HttpClient client = new HttpClient();
                var response = await client.GetAsync(url);
                var responseText = await response.Content.ReadAsStringAsync();
                Authorize result = JsonConvert.DeserializeObject<Authorize>(responseText);
                if (result.stateInstance == "notAuthorized")
                {
                    Application.Run(new Qrform());
                }
                else
                {
                    Application.Run(new Messageform());
                }
            }
            else
            {
                MessageBox.Show("برجاء التحقق من اتصال الانترنت","خطأ",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
    }
}
