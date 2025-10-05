using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using Button = System.Windows.Forms.Button;

namespace GUIForms.Forms.SendMessages
{
    public partial class FrmTemplet : Form
    {
        int top = 0;
        string path = @"Data\MSG\";
        public FrmTemplet()
        {
            InitializeComponent();
            Loading();
        }
        void Loading()
        {
            FLP.Controls.Clear();
            top = 0;
            txtfn.Clear();
            txtMsg.Clear();
            string path = @"Data\MSG\";

            // يجيب كل الملفات اللي جوه الفولدر
            string[] files = Directory.GetFiles(path);

            foreach (string file in files)
            {
                string filename = Path.GetFileName(file);
                addTembletButton(filename, file);
            }
        }
        private void addTembletButton(string Filename, string FP)
        {
            Button button = new Button();
            button.Top = top;
            button.Left = 0;
            button.Height = 50;
            button.Width = 70;
            FLP.AutoScroll = true;
            button.Text = Filename;
            button.Margin = new Padding(15,15,15,0);
            button.FlatStyle = FlatStyle.Flat;
            button.Tag = FP;
            button.Click += new EventHandler(Btntemplet_Click);
            FLP.Controls.Add(button);
            top += button.Height + 15;
        }
        private void Btntemplet_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            string filePath = clickedButton.Tag.ToString();
            string text = File.ReadAllText(filePath);
            txtfn.Tag = filePath;
            txtfn.Text = clickedButton.Text.Split('.')[0];
            txtMsg.Text = text;
        }
        private void picClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void iconButton2_Click(object sender, EventArgs e)
        {
            ListMsgform LMF = new ListMsgform();
            this.Hide();
            LMF.ShowDialog();
        }
        private void button7_Click(object sender, EventArgs e)
        {
            path += txtfn.Text;
            string content = txtMsg.Text;

            // لو الفولدر مش موجود يعمل Create له
            Directory.CreateDirectory(Path.GetDirectoryName(path));

            // كتابة النص للملف (هيعمله لو مش موجود أو يبدله لو موجود)
            File.WriteAllText(path + ".txt", content);

            MessageBox.Show("تم إنشاء القالب بنجاح");
            Loading();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var Res = txtfn.Tag.ToString();
            if (File.Exists(Res))
            {
                File.Delete(Res);
            }
            path += txtfn.Text;
            string content = txtMsg.Text;

            // لو الفولدر مش موجود يعمل Create له
            Directory.CreateDirectory(Path.GetDirectoryName(path));

            // كتابة النص للملف (هيعمله لو مش موجود أو يبدله لو موجود)
            File.WriteAllText(path + ".txt", content);

            MessageBox.Show("تم تعديل القالب بنجاح");
            Loading();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            var Res = txtfn.Tag.ToString();
            if (File.Exists(Res))
            {
                File.Delete(Res);
                MessageBox.Show("تم حذف القالب");
            }
            Loading();
        }
    }
}
