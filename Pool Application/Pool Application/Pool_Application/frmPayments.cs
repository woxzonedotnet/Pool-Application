namespace Pool_Application
{
    using Business_Layer;
    using Business_Layer.Property_Layer;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class frmPayments : Form
    {
        public Button btnExit;
        public Button btnRefresh;
        public Button btnSave;
        public Button btnView;
        private clsCommenMethods cCommenMethods = new clsCommenMethods();
        private clsGlobleVariable cGlobleVariable = new clsGlobleVariable();
        private IContainer components = null;
        private clsStudentMaster cStudentMaster = new clsStudentMaster();
        private DateTimePicker dateTimePicker1;
        private DateTimePicker dateTimePicker2;
        private DateTimePicker dtpDateOfPromote;
        private GroupBox groupBox1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label94;
        private objStudentMaster oStudentMaster = new objStudentMaster();
        private Panel panel1;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox txtFullNameLineOne;
        private TextBox txtFullNameLineTwo;
        private TextBox txtStudentNo;

        public frmPayments()
        {
            this.InitializeComponent();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            this.ViewEmployee();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.groupBox1 = new GroupBox();
            this.dateTimePicker1 = new DateTimePicker();
            this.label1 = new Label();
            this.dtpDateOfPromote = new DateTimePicker();
            this.label94 = new Label();
            this.txtFullNameLineTwo = new TextBox();
            this.txtFullNameLineOne = new TextBox();
            this.txtStudentNo = new TextBox();
            this.label2 = new Label();
            this.label5 = new Label();
            this.panel1 = new Panel();
            this.btnView = new Button();
            this.btnRefresh = new Button();
            this.btnSave = new Button();
            this.btnExit = new Button();
            this.textBox1 = new TextBox();
            this.label3 = new Label();
            this.dateTimePicker2 = new DateTimePicker();
            this.label4 = new Label();
            this.textBox2 = new TextBox();
            this.label6 = new Label();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            base.SuspendLayout();
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.dateTimePicker2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtpDateOfPromote);
            this.groupBox1.Controls.Add(this.label94);
            this.groupBox1.Controls.Add(this.txtFullNameLineTwo);
            this.groupBox1.Controls.Add(this.txtFullNameLineOne);
            this.groupBox1.Controls.Add(this.txtStudentNo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new Point(1, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(0x227, 0x109);
            this.groupBox1.TabIndex = 0xd1;
            this.groupBox1.TabStop = false;
            this.dateTimePicker1.Format = DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new Point(0x10b, 0x54);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new Size(0x66, 20);
            this.dateTimePicker1.TabIndex = 220;
            this.label1.AutoSize = true;
            this.label1.Location = new Point(0xeb, 0x58);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x1a, 13);
            this.label1.TabIndex = 0xdd;
            this.label1.Text = "To :";
            this.dtpDateOfPromote.Format = DateTimePickerFormat.Short;
            this.dtpDateOfPromote.Location = new Point(0x71, 0x54);
            this.dtpDateOfPromote.Name = "dtpDateOfPromote";
            this.dtpDateOfPromote.Size = new Size(0x66, 20);
            this.dtpDateOfPromote.TabIndex = 0xda;
            this.label94.AutoSize = true;
            this.label94.Location = new Point(3, 0x58);
            this.label94.Name = "label94";
            this.label94.Size = new Size(0x61, 13);
            this.label94.TabIndex = 0xdb;
            this.label94.Text = "Payment Duration :";
            this.txtFullNameLineTwo.BackColor = SystemColors.ActiveCaptionText;
            this.txtFullNameLineTwo.Location = new Point(0x71, 60);
            this.txtFullNameLineTwo.MaxLength = 100;
            this.txtFullNameLineTwo.Name = "txtFullNameLineTwo";
            this.txtFullNameLineTwo.ReadOnly = true;
            this.txtFullNameLineTwo.Size = new Size(0x1b3, 20);
            this.txtFullNameLineTwo.TabIndex = 0xd4;
            this.txtFullNameLineOne.BackColor = SystemColors.ActiveCaptionText;
            this.txtFullNameLineOne.Location = new Point(0x71, 0x25);
            this.txtFullNameLineOne.MaxLength = 100;
            this.txtFullNameLineOne.Name = "txtFullNameLineOne";
            this.txtFullNameLineOne.ReadOnly = true;
            this.txtFullNameLineOne.Size = new Size(0x1b3, 20);
            this.txtFullNameLineOne.TabIndex = 0xd3;
            this.txtStudentNo.BackColor = SystemColors.ActiveCaptionText;
            this.txtStudentNo.Location = new Point(0x71, 14);
            this.txtStudentNo.MaxLength = 10;
            this.txtStudentNo.Name = "txtStudentNo";
            this.txtStudentNo.Size = new Size(0xa4, 20);
            this.txtStudentNo.TabIndex = 210;
            this.txtStudentNo.TextChanged += new EventHandler(this.txtStudentNo_TextChanged);
            this.label2.AutoSize = true;
            this.label2.Location = new Point(3, 0x11);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x43, 13);
            this.label2.TabIndex = 0xd6;
            this.label2.Text = "Student No :";
            this.label5.AutoSize = true;
            this.label5.Location = new Point(3, 40);
            this.label5.Name = "label5";
            this.label5.Size = new Size(0x47, 13);
            this.label5.TabIndex = 0xd5;
            this.label5.Text = "Name in Full :";
            this.panel1.Controls.Add(this.btnView);
            this.panel1.Controls.Add(this.btnRefresh);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Location = new Point(1, 0x110);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(0x227, 50);
            this.panel1.TabIndex = 210;
            this.btnView.Location = new Point(0x53, 12);
            this.btnView.Name = "btnView";
            this.btnView.Size = new Size(0x49, 0x17);
            this.btnView.TabIndex = 0x26;
            this.btnView.Text = "&View";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new EventHandler(this.btnView_Click);
            this.btnRefresh.Location = new Point(0xa2, 12);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new Size(0x47, 0x17);
            this.btnRefresh.TabIndex = 7;
            this.btnRefresh.Text = "&Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnSave.Location = new Point(6, 12);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new Size(0x47, 0x17);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnExit.FlatAppearance.BorderColor = Color.FromArgb(0x40, 0x40, 0x40);
            this.btnExit.FlatAppearance.BorderSize = 5;
            this.btnExit.Location = new Point(0x1d1, 12);
            this.btnExit.Margin = new Padding(0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new Size(0x53, 0x17);
            this.btnExit.TabIndex = 10;
            this.btnExit.Text = "E&xit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.textBox1.BackColor = SystemColors.ActiveCaptionText;
            this.textBox1.Location = new Point(0x71, 0x6c);
            this.textBox1.MaxLength = 10;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Size(0xa4, 20);
            this.textBox1.TabIndex = 0xde;
            this.label3.AutoSize = true;
            this.label3.Location = new Point(3, 0x6f);
            this.label3.Name = "label3";
            this.label3.Size = new Size(70, 13);
            this.label3.TabIndex = 0xdf;
            this.label3.Text = "Pay Amount :";
            this.dateTimePicker2.Format = DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new Point(0x1b9, 0x71);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new Size(0x66, 20);
            this.dateTimePicker2.TabIndex = 0xe0;
            this.label4.AutoSize = true;
            this.label4.Location = new Point(0x14b, 0x73);
            this.label4.Name = "label4";
            this.label4.Size = new Size(80, 13);
            this.label4.TabIndex = 0xe1;
            this.label4.Text = "Payment Date :";
            this.textBox2.BackColor = SystemColors.ActiveCaptionText;
            this.textBox2.Location = new Point(0x71, 0x84);
            this.textBox2.MaxLength = 10;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new Size(0xa4, 20);
            this.textBox2.TabIndex = 0xe2;
            this.label6.AutoSize = true;
            this.label6.Location = new Point(3, 0x87);
            this.label6.Name = "label6";
            this.label6.Size = new Size(0x37, 13);
            this.label6.TabIndex = 0xe3;
            this.label6.Text = "Discount :";
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x22c, 0x18d);
            base.Controls.Add(this.panel1);
            base.Controls.Add(this.groupBox1);
            base.Name = "frmPayments";
            this.Text = "frmPayments";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            base.ResumeLayout(false);
        }

        private void LoadStudent()
        {
            this.oStudentMaster = this.cStudentMaster.GetStudentData(this.cGlobleVariable.LocationCode, this.txtStudentNo.Text.ToString());
            if (this.oStudentMaster.IsExistStudent)
            {
                this.txtStudentNo.Text = this.oStudentMaster.StudentNo;
                this.txtFullNameLineOne.Text = this.oStudentMaster.NameInFullL1;
                this.txtFullNameLineTwo.Text = this.oStudentMaster.NameInFullL2;
            }
        }

        private void txtStudentNo_TextChanged(object sender, EventArgs e)
        {
            this.LoadStudent();
        }

        public void ViewEmployee()
        {
            string[] strFieldList = new string[] { "fldStudentNo", "fldNameInFullL1" };
            string[] strHeadingList = new string[] { "Student No", "Student Name" };
            int[] iHeaderWidth = new int[] { 80, 100 };
            string strReturnField = "Student No";
            string str2 = "fldLocationCode = '" + this.cGlobleVariable.LocationCode + "' ";
            this.txtStudentNo.Text = this.cCommenMethods.BrowsData("tbl_student_master", strFieldList, strHeadingList, iHeaderWidth, strReturnField, str2);
        }
    }
}

