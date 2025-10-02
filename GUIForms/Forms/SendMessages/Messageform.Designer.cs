namespace GUIForms.Forms.SendMessages
{
    partial class Messageform
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Messageform));
            this.panel2 = new System.Windows.Forms.Panel();
            this.picClose = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtfile = new System.Windows.Forms.RichTextBox();
            this.Btnup = new System.Windows.Forms.Button();
            this.Btnsend = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label15 = new System.Windows.Forms.Label();
            this.phone = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.clientID = new System.Windows.Forms.ComboBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtMsg = new System.Windows.Forms.RichTextBox();
            this.OFD = new System.Windows.Forms.OpenFileDialog();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.PowderBlue;
            this.panel2.Controls.Add(this.picClose);
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(396, 65);
            this.panel2.TabIndex = 34;
            // 
            // picClose
            // 
            this.picClose.BackColor = System.Drawing.Color.PowderBlue;
            this.picClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picClose.BackgroundImage")));
            this.picClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.picClose.Location = new System.Drawing.Point(359, 12);
            this.picClose.Name = "picClose";
            this.picClose.Size = new System.Drawing.Size(25, 21);
            this.picClose.TabIndex = 5;
            this.picClose.TabStop = false;
            this.picClose.Click += new System.EventHandler(this.picClose_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBox2.Location = new System.Drawing.Point(12, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(45, 44);
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 27.75F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(61, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 43);
            this.label1.TabIndex = 1;
            this.label1.Text = "Meaasge";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtfile);
            this.panel1.Controls.Add(this.Btnup);
            this.panel1.Controls.Add(this.Btnsend);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 390);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(396, 100);
            this.panel1.TabIndex = 35;
            // 
            // txtfile
            // 
            this.txtfile.Location = new System.Drawing.Point(8, 8);
            this.txtfile.Name = "txtfile";
            this.txtfile.Size = new System.Drawing.Size(181, 83);
            this.txtfile.TabIndex = 10;
            this.txtfile.Text = "";
            this.txtfile.Visible = false;
            // 
            // Btnup
            // 
            this.Btnup.BackColor = System.Drawing.Color.PowderBlue;
            this.Btnup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Btnup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btnup.FlatAppearance.BorderColor = System.Drawing.SystemColors.Highlight;
            this.Btnup.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Highlight;
            this.Btnup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btnup.Font = new System.Drawing.Font("Verdana", 11.25F);
            this.Btnup.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Btnup.Location = new System.Drawing.Point(195, 9);
            this.Btnup.Name = "Btnup";
            this.Btnup.Size = new System.Drawing.Size(100, 82);
            this.Btnup.TabIndex = 9;
            this.Btnup.Text = "Fileuploade";
            this.Btnup.UseVisualStyleBackColor = false;
            this.Btnup.Visible = false;
            this.Btnup.Click += new System.EventHandler(this.Btnup_Click);
            // 
            // Btnsend
            // 
            this.Btnsend.BackColor = System.Drawing.Color.PowderBlue;
            this.Btnsend.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Btnsend.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btnsend.FlatAppearance.BorderColor = System.Drawing.SystemColors.Highlight;
            this.Btnsend.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Highlight;
            this.Btnsend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btnsend.Font = new System.Drawing.Font("Verdana", 11.25F);
            this.Btnsend.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Btnsend.Location = new System.Drawing.Point(301, 9);
            this.Btnsend.Name = "Btnsend";
            this.Btnsend.Size = new System.Drawing.Size(83, 82);
            this.Btnsend.TabIndex = 8;
            this.Btnsend.Text = "Send";
            this.Btnsend.UseVisualStyleBackColor = false;
            this.Btnsend.Visible = false;
            this.Btnsend.Click += new System.EventHandler(this.Btnsend_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label15);
            this.panel3.Controls.Add(this.phone);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.clientID);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 65);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(396, 79);
            this.panel3.TabIndex = 36;
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Sylfaen", 11.25F);
            this.label15.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label15.Location = new System.Drawing.Point(284, 44);
            this.label15.Name = "label15";
            this.label15.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label15.Size = new System.Drawing.Size(94, 19);
            this.label15.TabIndex = 80;
            this.label15.Text = "رقم جوال العميل:";
            // 
            // phone
            // 
            this.phone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.phone.Enabled = false;
            this.phone.Location = new System.Drawing.Point(12, 42);
            this.phone.Name = "phone";
            this.phone.ReadOnly = true;
            this.phone.Size = new System.Drawing.Size(266, 20);
            this.phone.TabIndex = 79;
            this.phone.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Sylfaen", 11.25F);
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(284, 17);
            this.label10.Name = "label10";
            this.label10.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label10.Size = new System.Drawing.Size(71, 19);
            this.label10.TabIndex = 67;
            this.label10.Text = "إختر العميل:";
            // 
            // clientID
            // 
            this.clientID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.clientID.DisplayMember = "Name";
            this.clientID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.clientID.FormattingEnabled = true;
            this.clientID.Location = new System.Drawing.Point(12, 15);
            this.clientID.Name = "clientID";
            this.clientID.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.clientID.Size = new System.Drawing.Size(266, 21);
            this.clientID.TabIndex = 66;
            this.clientID.ValueMember = "ID";
            this.clientID.SelectionChangeCommitted += new System.EventHandler(this.clientID_SelectionChangeCommitted);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.txtMsg);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 144);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(396, 246);
            this.panel4.TabIndex = 37;
            // 
            // txtMsg
            // 
            this.txtMsg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMsg.Location = new System.Drawing.Point(0, 0);
            this.txtMsg.Name = "txtMsg";
            this.txtMsg.Size = new System.Drawing.Size(396, 246);
            this.txtMsg.TabIndex = 0;
            this.txtMsg.Text = "";
            this.txtMsg.TextChanged += new System.EventHandler(this.txtMsg_TextChanged);
            // 
            // OFD
            // 
            this.OFD.FileName = "openFileDialog1";
            // 
            // Messageform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 490);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Messageform";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox picClose;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button Btnsend;
        private System.Windows.Forms.RichTextBox txtMsg;
        private System.Windows.Forms.RichTextBox txtfile;
        private System.Windows.Forms.Button Btnup;
        private System.Windows.Forms.Label label10;
        public System.Windows.Forms.ComboBox clientID;
        private System.Windows.Forms.Label label15;
        public System.Windows.Forms.TextBox phone;
        private System.Windows.Forms.OpenFileDialog OFD;
    }
}

