namespace GUIForms.Forms.tailoring
{
    partial class Frmcustrecived
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frmcustrecived));
            this.dgvoprator = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThirdPartyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Clothesnumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Clothesrecived = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Clothesremining = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.picClose = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.Btnsave = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.textBox15 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvoprator)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvoprator
            // 
            this.dgvoprator.AllowUserToAddRows = false;
            this.dgvoprator.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvoprator.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvoprator.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvoprator.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvoprator.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvoprator.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.ThirdPartyName,
            this.Clothesnumber,
            this.Clothesrecived,
            this.Clothesremining});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvoprator.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvoprator.Location = new System.Drawing.Point(12, 114);
            this.dgvoprator.Name = "dgvoprator";
            this.dgvoprator.Size = new System.Drawing.Size(514, 427);
            this.dgvoprator.TabIndex = 84;
            this.dgvoprator.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvoprator_CellEndEdit);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "المسلسل";
            this.Id.Name = "Id";
            this.Id.Visible = false;
            // 
            // ThirdPartyName
            // 
            this.ThirdPartyName.DataPropertyName = "ThirdPartyName";
            this.ThirdPartyName.HeaderText = "اسم العميل";
            this.ThirdPartyName.Name = "ThirdPartyName";
            this.ThirdPartyName.ReadOnly = true;
            // 
            // Clothesnumber
            // 
            this.Clothesnumber.DataPropertyName = "Clothesnumber";
            this.Clothesnumber.HeaderText = "عدد الاثواب الكلي";
            this.Clothesnumber.Name = "Clothesnumber";
            this.Clothesnumber.ReadOnly = true;
            // 
            // Clothesrecived
            // 
            this.Clothesrecived.DataPropertyName = "Clothesrecived";
            this.Clothesrecived.HeaderText = "عدد الاثواب المستلمه";
            this.Clothesrecived.Name = "Clothesrecived";
            // 
            // Clothesremining
            // 
            this.Clothesremining.DataPropertyName = "Clothesremining";
            this.Clothesremining.HeaderText = "عدد الاثواب المتبقيه";
            this.Clothesremining.Name = "Clothesremining";
            this.Clothesremining.ReadOnly = true;
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
            this.panel2.Size = new System.Drawing.Size(539, 65);
            this.panel2.TabIndex = 85;
            // 
            // picClose
            // 
            this.picClose.BackColor = System.Drawing.Color.PowderBlue;
            this.picClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picClose.BackgroundImage")));
            this.picClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.picClose.Location = new System.Drawing.Point(1, 2);
            this.picClose.Name = "picClose";
            this.picClose.Size = new System.Drawing.Size(25, 21);
            this.picClose.TabIndex = 3;
            this.picClose.TabStop = false;
            this.picClose.Click += new System.EventHandler(this.picClose_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBox2.Location = new System.Drawing.Point(485, 10);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(45, 44);
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(219, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(251, 35);
            this.label1.TabIndex = 1;
            this.label1.Text = "استلام الاثواب من العميل";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // iconButton1
            // 
            this.iconButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            this.iconButton1.IconColor = System.Drawing.Color.Black;
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton1.IconSize = 19;
            this.iconButton1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.iconButton1.Location = new System.Drawing.Point(12, 81);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(31, 26);
            this.iconButton1.TabIndex = 89;
            this.iconButton1.UseVisualStyleBackColor = true;
            this.iconButton1.Click += new System.EventHandler(this.iconButton1_Click);
            // 
            // Btnsave
            // 
            this.Btnsave.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Btnsave.BackColor = System.Drawing.Color.PowderBlue;
            this.Btnsave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Btnsave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btnsave.FlatAppearance.BorderColor = System.Drawing.SystemColors.Highlight;
            this.Btnsave.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Highlight;
            this.Btnsave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btnsave.Font = new System.Drawing.Font("Verdana", 11.25F);
            this.Btnsave.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Btnsave.Location = new System.Drawing.Point(219, 547);
            this.Btnsave.Name = "Btnsave";
            this.Btnsave.Size = new System.Drawing.Size(75, 34);
            this.Btnsave.TabIndex = 88;
            this.Btnsave.Text = "حفظ";
            this.Btnsave.UseVisualStyleBackColor = false;
            this.Btnsave.Click += new System.EventHandler(this.Btnsave_Click);
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Sylfaen", 11.25F);
            this.label15.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label15.Location = new System.Drawing.Point(419, 83);
            this.label15.Name = "label15";
            this.label15.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label15.Size = new System.Drawing.Size(111, 19);
            this.label15.TabIndex = 87;
            this.label15.Text = "البحث برقم التفصيل:";
            // 
            // textBox15
            // 
            this.textBox15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox15.Location = new System.Drawing.Point(49, 83);
            this.textBox15.Name = "textBox15";
            this.textBox15.Size = new System.Drawing.Size(364, 20);
            this.textBox15.TabIndex = 86;
            this.textBox15.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox15.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox15_KeyPress);
            // 
            // Frmcustrecived
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 585);
            this.Controls.Add(this.dgvoprator);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.iconButton1);
            this.Controls.Add(this.Btnsave);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.textBox15);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frmcustrecived";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frmcustrecived";
            ((System.ComponentModel.ISupportInitialize)(this.dgvoprator)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvoprator;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox picClose;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private FontAwesome.Sharp.IconButton iconButton1;
        private System.Windows.Forms.Button Btnsave;
        private System.Windows.Forms.Label label15;
        public System.Windows.Forms.TextBox textBox15;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThirdPartyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Clothesnumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn Clothesrecived;
        private System.Windows.Forms.DataGridViewTextBoxColumn Clothesremining;
    }
}