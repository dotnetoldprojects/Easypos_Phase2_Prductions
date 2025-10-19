namespace GUIForms.Forms.salesforms
{
    partial class Frmzatcalist
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frmzatcalist));
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.IN = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.clientID = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.DGV = new System.Windows.Forms.DataGridView();
            this.DTF = new System.Windows.Forms.DateTimePicker();
            this.Btnsearch = new System.Windows.Forms.Button();
            this.Searchbytime = new System.Windows.Forms.CheckBox();
            this.lblsubtotal = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbldisc = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.picMinimize = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lbltot = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lbltax = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.Btnall = new System.Windows.Forms.Button();
            this.Btnclose = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.TTF = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.TTT = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.Searchbydate = new System.Windows.Forms.CheckBox();
            this.DTT = new System.Windows.Forms.DateTimePicker();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Show = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Print = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Invoiceno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Invoicenumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Subtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Discount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cash = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Customer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Billtype = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Note = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupBox1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMinimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(287, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "التاريخ الى :";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(580, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "التاريخ من :";
            // 
            // GroupBox1
            // 
            this.GroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupBox1.Controls.Add(this.txtPhone);
            this.GroupBox1.Controls.Add(this.IN);
            this.GroupBox1.Controls.Add(this.label10);
            this.GroupBox1.Controls.Add(this.clientID);
            this.GroupBox1.Controls.Add(this.label4);
            this.GroupBox1.Controls.Add(this.label1);
            this.GroupBox1.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.GroupBox1.Location = new System.Drawing.Point(663, 6);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(637, 106);
            this.GroupBox1.TabIndex = 53;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "بيانات البحث ";
            // 
            // txtPhone
            // 
            this.txtPhone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPhone.Location = new System.Drawing.Point(13, 37);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(130, 21);
            this.txtPhone.TabIndex = 16;
            // 
            // IN
            // 
            this.IN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.IN.Location = new System.Drawing.Point(460, 38);
            this.IN.Name = "IN";
            this.IN.Size = new System.Drawing.Size(100, 21);
            this.IN.TabIndex = 12;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(144, 40);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(58, 13);
            this.label10.TabIndex = 15;
            this.label10.Text = "رقم الجوال:";
            // 
            // clientID
            // 
            this.clientID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.clientID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.clientID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.clientID.DisplayMember = "Name";
            this.clientID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.clientID.FormattingEnabled = true;
            this.clientID.Location = new System.Drawing.Point(240, 38);
            this.clientID.Name = "clientID";
            this.clientID.Size = new System.Drawing.Size(135, 21);
            this.clientID.TabIndex = 5;
            this.clientID.ValueMember = "ID";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(377, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "إختر العميل:";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(561, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "رقم الفاتورة:";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.DGV);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 172);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1312, 548);
            this.panel3.TabIndex = 59;
            // 
            // DGV
            // 
            this.DGV.AllowUserToAddRows = false;
            this.DGV.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DGV.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Show,
            this.Print,
            this.Invoiceno,
            this.Invoicenumber,
            this.Date,
            this.Time,
            this.Subtotal,
            this.Discount,
            this.Tax,
            this.Total,
            this.Cash,
            this.Bank,
            this.Customer,
            this.Billtype,
            this.Status,
            this.Note});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV.DefaultCellStyle = dataGridViewCellStyle3;
            this.DGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGV.Location = new System.Drawing.Point(0, 0);
            this.DGV.Name = "DGV";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.DGV.Size = new System.Drawing.Size(1312, 548);
            this.DGV.TabIndex = 0;
            this.DGV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_CellContentClick);
            // 
            // DTF
            // 
            this.DTF.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DTF.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTF.Location = new System.Drawing.Point(449, 44);
            this.DTF.Name = "DTF";
            this.DTF.Size = new System.Drawing.Size(130, 21);
            this.DTF.TabIndex = 15;
            // 
            // Btnsearch
            // 
            this.Btnsearch.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Btnsearch.Location = new System.Drawing.Point(9, 24);
            this.Btnsearch.Name = "Btnsearch";
            this.Btnsearch.Size = new System.Drawing.Size(75, 60);
            this.Btnsearch.TabIndex = 18;
            this.Btnsearch.Text = "بحث";
            this.Btnsearch.UseVisualStyleBackColor = true;
            this.Btnsearch.Click += new System.EventHandler(this.Btnsearch_Click);
            // 
            // Searchbytime
            // 
            this.Searchbytime.AutoSize = true;
            this.Searchbytime.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Searchbytime.Location = new System.Drawing.Point(170, 19);
            this.Searchbytime.Name = "Searchbytime";
            this.Searchbytime.Size = new System.Drawing.Size(117, 17);
            this.Searchbytime.TabIndex = 13;
            this.Searchbytime.Text = "البحث بواسطة الوقت";
            this.Searchbytime.UseVisualStyleBackColor = true;
            // 
            // lblsubtotal
            // 
            this.lblsubtotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblsubtotal.AutoSize = true;
            this.lblsubtotal.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblsubtotal.Location = new System.Drawing.Point(1138, 28);
            this.lblsubtotal.Name = "lblsubtotal";
            this.lblsubtotal.Size = new System.Drawing.Size(13, 13);
            this.lblsubtotal.TabIndex = 38;
            this.lblsubtotal.Text = "0";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(1007, 28);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 13);
            this.label8.TabIndex = 37;
            this.label8.Text = "الضريبة :";
            // 
            // lbldisc
            // 
            this.lbldisc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbldisc.AutoSize = true;
            this.lbldisc.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbldisc.Location = new System.Drawing.Point(1138, 52);
            this.lbldisc.Name = "lbldisc";
            this.lbldisc.Size = new System.Drawing.Size(13, 13);
            this.lbldisc.TabIndex = 36;
            this.lbldisc.Text = "0";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label11.Location = new System.Drawing.Point(1251, 52);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(40, 13);
            this.label11.TabIndex = 35;
            this.label11.Text = "الخصم :";
            // 
            // picMinimize
            // 
            this.picMinimize.BackColor = System.Drawing.Color.PowderBlue;
            this.picMinimize.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picMinimize.BackgroundImage")));
            this.picMinimize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picMinimize.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.picMinimize.Location = new System.Drawing.Point(12, 16);
            this.picMinimize.Name = "picMinimize";
            this.picMinimize.Size = new System.Drawing.Size(25, 21);
            this.picMinimize.TabIndex = 15;
            this.picMinimize.TabStop = false;
            this.picMinimize.Click += new System.EventHandler(this.picMinimize_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBox2.Location = new System.Drawing.Point(1266, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(45, 44);
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.Black;
            this.lblTitle.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblTitle.Location = new System.Drawing.Point(1149, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(115, 25);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "قائمة الفواتير";
            // 
            // lbltot
            // 
            this.lbltot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbltot.AutoSize = true;
            this.lbltot.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbltot.Location = new System.Drawing.Point(944, 52);
            this.lbltot.Name = "lbltot";
            this.lbltot.Size = new System.Drawing.Size(13, 13);
            this.lbltot.TabIndex = 34;
            this.lbltot.Text = "0";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(1205, 28);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(86, 13);
            this.label9.TabIndex = 33;
            this.label9.Text = "الاجمالي الجزئي :";
            // 
            // lbltax
            // 
            this.lbltax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbltax.AutoSize = true;
            this.lbltax.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbltax.Location = new System.Drawing.Point(944, 28);
            this.lbltax.Name = "lbltax";
            this.lbltax.Size = new System.Drawing.Size(13, 13);
            this.lbltax.TabIndex = 32;
            this.lbltax.Text = "0";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(1007, 52);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 13);
            this.label7.TabIndex = 31;
            this.label7.Text = "الاجمالي الكلي :";
            // 
            // Btnall
            // 
            this.Btnall.BackColor = System.Drawing.Color.PowderBlue;
            this.Btnall.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Btnall.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btnall.FlatAppearance.BorderColor = System.Drawing.SystemColors.Highlight;
            this.Btnall.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Highlight;
            this.Btnall.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btnall.Font = new System.Drawing.Font("Verdana", 11.25F);
            this.Btnall.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Btnall.Location = new System.Drawing.Point(93, 15);
            this.Btnall.Name = "Btnall";
            this.Btnall.Size = new System.Drawing.Size(75, 60);
            this.Btnall.TabIndex = 15;
            this.Btnall.Text = "الكل";
            this.Btnall.UseVisualStyleBackColor = false;
            this.Btnall.Click += new System.EventHandler(this.Btnall_Click);
            // 
            // Btnclose
            // 
            this.Btnclose.BackColor = System.Drawing.Color.PowderBlue;
            this.Btnclose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Btnclose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btnclose.FlatAppearance.BorderColor = System.Drawing.SystemColors.Highlight;
            this.Btnclose.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Highlight;
            this.Btnclose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btnclose.Font = new System.Drawing.Font("Verdana", 11.25F);
            this.Btnclose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Btnclose.Location = new System.Drawing.Point(12, 15);
            this.Btnclose.Name = "Btnclose";
            this.Btnclose.Size = new System.Drawing.Size(75, 60);
            this.Btnclose.TabIndex = 14;
            this.Btnclose.Text = "الغاء";
            this.Btnclose.UseVisualStyleBackColor = false;
            this.Btnclose.Click += new System.EventHandler(this.Btnclose_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.GroupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 54);
            this.panel1.Name = "panel1";
            this.panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.panel1.Size = new System.Drawing.Size(1312, 118);
            this.panel1.TabIndex = 58;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.TTF);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.Btnsearch);
            this.groupBox3.Controls.Add(this.TTT);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.Searchbydate);
            this.groupBox3.Controls.Add(this.DTT);
            this.groupBox3.Controls.Add(this.Searchbytime);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.DTF);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.groupBox3.Location = new System.Drawing.Point(3, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(654, 106);
            this.groupBox3.TabIndex = 52;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = " بحث بواسطة التاريخ ";
            // 
            // TTF
            // 
            this.TTF.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TTF.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.TTF.Location = new System.Drawing.Point(449, 69);
            this.TTF.Name = "TTF";
            this.TTF.Size = new System.Drawing.Size(130, 21);
            this.TTF.TabIndex = 22;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(580, 73);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "التوقيت من :";
            // 
            // TTT
            // 
            this.TTT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TTT.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.TTT.Location = new System.Drawing.Point(156, 69);
            this.TTT.Name = "TTT";
            this.TTT.Size = new System.Drawing.Size(130, 21);
            this.TTT.TabIndex = 20;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(287, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "التوقيت الى :";
            // 
            // Searchbydate
            // 
            this.Searchbydate.AutoSize = true;
            this.Searchbydate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Searchbydate.Location = new System.Drawing.Point(457, 21);
            this.Searchbydate.Name = "Searchbydate";
            this.Searchbydate.Size = new System.Drawing.Size(122, 17);
            this.Searchbydate.TabIndex = 14;
            this.Searchbydate.Text = "البحث بواسطة التاريخ";
            this.Searchbydate.UseVisualStyleBackColor = true;
            // 
            // DTT
            // 
            this.DTT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DTT.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTT.Location = new System.Drawing.Point(156, 42);
            this.DTT.Name = "DTT";
            this.DTT.Size = new System.Drawing.Size(130, 21);
            this.DTT.TabIndex = 17;
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.lblsubtotal);
            this.GroupBox2.Controls.Add(this.label8);
            this.GroupBox2.Controls.Add(this.lbldisc);
            this.GroupBox2.Controls.Add(this.label11);
            this.GroupBox2.Controls.Add(this.lbltot);
            this.GroupBox2.Controls.Add(this.label9);
            this.GroupBox2.Controls.Add(this.lbltax);
            this.GroupBox2.Controls.Add(this.label7);
            this.GroupBox2.Controls.Add(this.Btnall);
            this.GroupBox2.Controls.Add(this.Btnclose);
            this.GroupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.GroupBox2.Location = new System.Drawing.Point(0, 720);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(1312, 85);
            this.GroupBox2.TabIndex = 57;
            this.GroupBox2.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.PowderBlue;
            this.panel2.Controls.Add(this.picMinimize);
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Controls.Add(this.lblTitle);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1312, 54);
            this.panel2.TabIndex = 56;
            // 
            // Show
            // 
            this.Show.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Show.HeaderText = "عرض الفاتورة";
            this.Show.Name = "Show";
            this.Show.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Show.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Show.Text = "Show";
            this.Show.ToolTipText = "عرض الفاتورة";
            this.Show.UseColumnTextForButtonValue = true;
            // 
            // Print
            // 
            this.Print.HeaderText = "طباعه";
            this.Print.Name = "Print";
            this.Print.Text = "Print";
            this.Print.UseColumnTextForButtonValue = true;
            // 
            // Invoiceno
            // 
            this.Invoiceno.DataPropertyName = "Invoiceno";
            this.Invoiceno.HeaderText = "رقم الفاتورة";
            this.Invoiceno.Name = "Invoiceno";
            this.Invoiceno.Visible = false;
            // 
            // Invoicenumber
            // 
            this.Invoicenumber.DataPropertyName = "Invoicenumber";
            this.Invoicenumber.HeaderText = "رقم الفاتوره";
            this.Invoicenumber.Name = "Invoicenumber";
            // 
            // Date
            // 
            this.Date.DataPropertyName = "TDate";
            this.Date.HeaderText = "التاريخ";
            this.Date.Name = "Date";
            // 
            // Time
            // 
            this.Time.DataPropertyName = "TTime";
            this.Time.HeaderText = "التوقيت";
            this.Time.Name = "Time";
            // 
            // Subtotal
            // 
            this.Subtotal.DataPropertyName = "NonVatTotal";
            this.Subtotal.HeaderText = "الاجمالي الجزئي";
            this.Subtotal.Name = "Subtotal";
            // 
            // Discount
            // 
            this.Discount.DataPropertyName = "Discount";
            this.Discount.HeaderText = "الخصم";
            this.Discount.Name = "Discount";
            // 
            // Tax
            // 
            this.Tax.DataPropertyName = "VatAmount";
            this.Tax.HeaderText = "الضريبة";
            this.Tax.Name = "Tax";
            // 
            // Total
            // 
            this.Total.DataPropertyName = "TotalAmount";
            this.Total.HeaderText = "الاجمالي الكلي";
            this.Total.Name = "Total";
            // 
            // Cash
            // 
            this.Cash.DataPropertyName = "Cash";
            this.Cash.HeaderText = "النقدي";
            this.Cash.Name = "Cash";
            // 
            // Bank
            // 
            this.Bank.DataPropertyName = "Bank";
            this.Bank.HeaderText = "البنكي";
            this.Bank.Name = "Bank";
            // 
            // Customer
            // 
            this.Customer.DataPropertyName = "ThirdParty";
            this.Customer.HeaderText = "العميل";
            this.Customer.Name = "Customer";
            // 
            // Billtype
            // 
            this.Billtype.DataPropertyName = "Type";
            this.Billtype.HeaderText = "نوع الفاتوره";
            this.Billtype.Name = "Billtype";
            // 
            // Status
            // 
            this.Status.DataPropertyName = "Status";
            this.Status.HeaderText = "التسجيل";
            this.Status.Name = "Status";
            // 
            // Note
            // 
            this.Note.DataPropertyName = "Note";
            this.Note.HeaderText = "ملاحظات";
            this.Note.Name = "Note";
            // 
            // Frmzatcalist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1312, 805);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.GroupBox2);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frmzatcalist";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frmzatcalist";
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMinimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.GroupBox GroupBox1;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox IN;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox clientID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView DGV;
        private System.Windows.Forms.DateTimePicker DTF;
        private System.Windows.Forms.Button Btnsearch;
        private System.Windows.Forms.CheckBox Searchbytime;
        private System.Windows.Forms.Label lblsubtotal;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbldisc;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.PictureBox picMinimize;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lbltot;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lbltax;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button Btnall;
        private System.Windows.Forms.Button Btnclose;
        private System.Windows.Forms.Panel panel1;
        internal System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DateTimePicker TTF;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker TTT;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox Searchbydate;
        private System.Windows.Forms.DateTimePicker DTT;
        internal System.Windows.Forms.GroupBox GroupBox2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridViewButtonColumn Show;
        private System.Windows.Forms.DataGridViewButtonColumn Print;
        private System.Windows.Forms.DataGridViewTextBoxColumn Invoiceno;
        private System.Windows.Forms.DataGridViewTextBoxColumn Invoicenumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn Subtotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Discount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tax;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cash;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bank;
        private System.Windows.Forms.DataGridViewTextBoxColumn Customer;
        private System.Windows.Forms.DataGridViewTextBoxColumn Billtype;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn Note;
    }
}