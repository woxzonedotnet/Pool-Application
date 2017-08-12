namespace Pool_Application
{
    using Business_Layer;
    using Business_Layer.Property_Layer;
    using Report_Layer;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;

    public class frmInvoice : Form
    {
        public Button btnExit;
        private Button btnPrint;
        public Button btnRefresh;
        public Button btnSave;
        private Button btnView;
        private clsAutoGenerator cAutoGenerator = new clsAutoGenerator();
        private clsCommenMethods cCommanMethods = new clsCommenMethods();
        private clsGlobleVariable cGlobleVariable = new clsGlobleVariable();
        private clsInvoice cInvoice = new clsInvoice();
        private IContainer components = null;
        private clsPaymentDeatils cPaymentDeatil = new clsPaymentDeatils();
        private clsPaymentDeatils cPaymentDeatils = new clsPaymentDeatils();
        private clsPaymentMethod cPaymentMethod = new clsPaymentMethod();
        private clsStudentMaster cStudentMaster = new clsStudentMaster();
        private clsVAT cVAT = new clsVAT();
        private DateTimePicker dtpDateOfInvoice;
        private DateTimePicker dtpPayFrom;
        private DateTimePicker dtpPayTo;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Label label1;
        private Label label10;
        private Label label11;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label94;
        private objAutoGenerator oAutoGenerator = new objAutoGenerator();
        private objInvoice oInvoice = new objInvoice();
        private objPaymentDeatils oPaymentDeatils = new objPaymentDeatils();
        private objPaymentMethod oPaymentMethod = new objPaymentMethod();
        private objStudentMaster oStudentMaster = new objStudentMaster();
        private Panel panel1;
        private TextBox txtFullNameLineOne;
        private TextBox txtFullNameLineTwo;
        private TextBox txtGrandTotal;
        private TextBox txtInvoiceNo;
        private TextBox txtPenaltyAmount;
        private TextBox txtStudentDiscount;
        private TextBox txtStudentFees;
        private TextBox txtStudentNo;
        private TextBox txtTotalAmount;
        private TextBox txtVAT;

        public frmInvoice()
        {
            this.InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            this.ReportViwer();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.ClearThisForm();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if ((this.txtStudentNo.Text != string.Empty) && (this.txtFullNameLineOne.Text != string.Empty))
            {
                this.oAutoGenerator = this.cAutoGenerator.GetAutoGeneratorNumber(this.cGlobleVariable.LocationCode);
                if (this.txtInvoiceNo.Text == string.Empty)
                {
                    if (this.oAutoGenerator.IsExistNumber)
                    {
                        this.oInvoice.InvoiceNo = this.oAutoGenerator.AutoNumberDescription + string.Format("{0:00000}", this.oAutoGenerator.AutoNumber);
                    }
                }
                else
                {
                    this.oInvoice.InvoiceNo = this.txtInvoiceNo.Text;
                }
                this.oInvoice.InvoiceDate = this.dtpDateOfInvoice.Value;
                this.oInvoice.LocationCode = this.cGlobleVariable.LocationCode;
                this.oInvoice.StudentNo = this.txtStudentNo.Text;
                this.oInvoice.PanaltyAmount = Convert.ToDouble(this.txtPenaltyAmount.Text);
                this.oInvoice.Discount = Convert.ToDouble(this.txtStudentDiscount.Text);
                this.oInvoice.GrandTotal = Convert.ToDouble(this.txtGrandTotal.Text);
                this.cInvoice.InsertUpdateData(this.oInvoice);
                MessageBox.Show(this.cGlobleVariable.SeavedMessage, "Receipt details", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.txtInvoiceNo.Text = this.oInvoice.InvoiceNo;
                this.ReportViwer();
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            this.ViewInvoice();
        }

        private void ClearThisForm()
        {
            this.txtInvoiceNo.Text = string.Empty;
            this.txtStudentNo.Text = string.Empty;
            this.txtFullNameLineOne.Text = string.Empty;
            this.txtFullNameLineTwo.Text = string.Empty;
            this.txtStudentFees.Text = "0";
            this.txtStudentDiscount.Text = "0";
            this.txtPenaltyAmount.Text = "0";
            this.txtTotalAmount.Text = "0";
            this.txtVAT.Text = "0";
            this.txtGrandTotal.Text = "0";
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void dtpDateOfInvoice_ValueChanged(object sender, EventArgs e)
        {
            this.LoadStudent();
        }

        private void dtpPayFrom_ValueChanged(object sender, EventArgs e)
        {
            this.LoadStudent();
        }

        private void dtpPayTo_ValueChanged(object sender, EventArgs e)
        {
            this.LoadStudent();
        }

        private void frmInvoice_Load(object sender, EventArgs e)
        {
            this.dtpPayFrom.CustomFormat = this.cGlobleVariable.SystemDateFormat;
            this.dtpPayFrom.Format = DateTimePickerFormat.Custom;
            this.dtpPayTo.CustomFormat = this.cGlobleVariable.SystemDateFormat;
            this.dtpPayTo.Format = DateTimePickerFormat.Custom;
            this.ClearThisForm();
        }

        private void InitializeComponent()
        {
            this.groupBox1 = new GroupBox();
            this.label11 = new Label();
            this.dtpPayTo = new DateTimePicker();
            this.dtpPayFrom = new DateTimePicker();
            this.label10 = new Label();
            this.panel1 = new Panel();
            this.btnPrint = new Button();
            this.btnView = new Button();
            this.btnRefresh = new Button();
            this.btnSave = new Button();
            this.btnExit = new Button();
            this.groupBox2 = new GroupBox();
            this.txtGrandTotal = new TextBox();
            this.label9 = new Label();
            this.txtVAT = new TextBox();
            this.label8 = new Label();
            this.txtTotalAmount = new TextBox();
            this.label7 = new Label();
            this.txtPenaltyAmount = new TextBox();
            this.label6 = new Label();
            this.txtStudentDiscount = new TextBox();
            this.label4 = new Label();
            this.txtStudentFees = new TextBox();
            this.label3 = new Label();
            this.txtInvoiceNo = new TextBox();
            this.label1 = new Label();
            this.dtpDateOfInvoice = new DateTimePicker();
            this.label94 = new Label();
            this.txtFullNameLineTwo = new TextBox();
            this.txtFullNameLineOne = new TextBox();
            this.txtStudentNo = new TextBox();
            this.label2 = new Label();
            this.label5 = new Label();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            base.SuspendLayout();
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.dtpPayTo);
            this.groupBox1.Controls.Add(this.dtpPayFrom);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.txtInvoiceNo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtpDateOfInvoice);
            this.groupBox1.Controls.Add(this.label94);
            this.groupBox1.Controls.Add(this.txtFullNameLineTwo);
            this.groupBox1.Controls.Add(this.txtFullNameLineOne);
            this.groupBox1.Controls.Add(this.txtStudentNo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new Point(4, -2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(0x22b, 0x199);
            this.groupBox1.TabIndex = 0xd4;
            this.groupBox1.TabStop = false;
            this.label11.AutoSize = true;
            this.label11.Location = new Point(0xf9, 0x7c);
            this.label11.Name = "label11";
            this.label11.Size = new Size(20, 13);
            this.label11.TabIndex = 230;
            this.label11.Text = "To";
            this.dtpPayTo.Format = DateTimePickerFormat.Short;
            this.dtpPayTo.Location = new Point(0x11c, 120);
            this.dtpPayTo.Name = "dtpPayTo";
            this.dtpPayTo.Size = new Size(0x66, 20);
            this.dtpPayTo.TabIndex = 0xe5;
            this.dtpPayTo.ValueChanged += new EventHandler(this.dtpPayTo_ValueChanged);
            this.dtpPayFrom.Format = DateTimePickerFormat.Short;
            this.dtpPayFrom.Location = new Point(0x75, 120);
            this.dtpPayFrom.Name = "dtpPayFrom";
            this.dtpPayFrom.Size = new Size(0x66, 20);
            this.dtpPayFrom.TabIndex = 0xe4;
            this.dtpPayFrom.ValueChanged += new EventHandler(this.dtpPayFrom_ValueChanged);
            this.label10.AutoSize = true;
            this.label10.Location = new Point(7, 0x7c);
            this.label10.Name = "label10";
            this.label10.Size = new Size(0x4b, 13);
            this.label10.TabIndex = 0xe5;
            this.label10.Text = "Payment Term";
            this.panel1.Controls.Add(this.btnPrint);
            this.panel1.Controls.Add(this.btnView);
            this.panel1.Controls.Add(this.btnRefresh);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Location = new Point(1, 0x163);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(0x227, 0x23);
            this.panel1.TabIndex = 0xe1;
            this.btnPrint.Location = new Point(240, 6);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new Size(0x4b, 0x17);
            this.btnPrint.TabIndex = 0x27;
            this.btnPrint.Text = "&Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new EventHandler(this.btnPrint_Click);
            this.btnView.Location = new Point(80, 6);
            this.btnView.Name = "btnView";
            this.btnView.Size = new Size(0x4b, 0x17);
            this.btnView.TabIndex = 0x26;
            this.btnView.Text = "&View";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new EventHandler(this.btnView_Click);
            this.btnRefresh.Location = new Point(0xa1, 6);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new Size(0x49, 0x17);
            this.btnRefresh.TabIndex = 0x25;
            this.btnRefresh.Text = "&Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new EventHandler(this.btnRefresh_Click);
            this.btnSave.Location = new Point(3, 6);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new Size(0x49, 0x17);
            this.btnSave.TabIndex = 0x15;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new EventHandler(this.btnSave_Click);
            this.btnExit.FlatAppearance.BorderColor = Color.FromArgb(0x40, 0x40, 0x40);
            this.btnExit.FlatAppearance.BorderSize = 5;
            this.btnExit.Location = new Point(0x1d1, 6);
            this.btnExit.Margin = new Padding(0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new Size(0x53, 0x17);
            this.btnExit.TabIndex = 0x23;
            this.btnExit.Text = "E&xit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new EventHandler(this.btnExit_Click);
            this.groupBox2.Controls.Add(this.txtGrandTotal);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtVAT);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txtTotalAmount);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtPenaltyAmount);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtStudentDiscount);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtStudentFees);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new Point(0, 0x92);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new Size(0x228, 0xcb);
            this.groupBox2.TabIndex = 0xe0;
            this.groupBox2.TabStop = false;
            this.txtGrandTotal.BackColor = SystemColors.ActiveCaptionText;
            this.txtGrandTotal.Location = new Point(0x161, 0x8f);
            this.txtGrandTotal.MaxLength = 10;
            this.txtGrandTotal.Name = "txtGrandTotal";
            this.txtGrandTotal.ReadOnly = true;
            this.txtGrandTotal.Size = new Size(0xc1, 20);
            this.txtGrandTotal.TabIndex = 0xeb;
            this.txtGrandTotal.TextAlign = HorizontalAlignment.Right;
            this.txtGrandTotal.TextChanged += new EventHandler(this.txtGrandTotal_TextChanged);
            this.label9.AutoSize = true;
            this.label9.Location = new Point(9, 0x92);
            this.label9.Name = "label9";
            this.label9.Size = new Size(0x3f, 13);
            this.label9.TabIndex = 0xea;
            this.label9.Text = "Grand Total";
            this.txtVAT.BackColor = SystemColors.ActiveCaptionText;
            this.txtVAT.Location = new Point(0x161, 0x6f);
            this.txtVAT.MaxLength = 10;
            this.txtVAT.Name = "txtVAT";
            this.txtVAT.ReadOnly = true;
            this.txtVAT.Size = new Size(0xc1, 20);
            this.txtVAT.TabIndex = 0xe9;
            this.txtVAT.TextAlign = HorizontalAlignment.Right;
            this.txtVAT.TextChanged += new EventHandler(this.txtVAT_TextChanged);
            this.label8.AutoSize = true;
            this.label8.Location = new Point(9, 0x72);
            this.label8.Name = "label8";
            this.label8.Size = new Size(0x2b, 13);
            this.label8.TabIndex = 0xe8;
            this.label8.Text = "V. A. T.";
            this.txtTotalAmount.BackColor = SystemColors.ActiveCaptionText;
            this.txtTotalAmount.Location = new Point(0x161, 0x58);
            this.txtTotalAmount.MaxLength = 10;
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.ReadOnly = true;
            this.txtTotalAmount.Size = new Size(0xc1, 20);
            this.txtTotalAmount.TabIndex = 230;
            this.txtTotalAmount.TextAlign = HorizontalAlignment.Right;
            this.txtTotalAmount.TextChanged += new EventHandler(this.txtTotalAmount_TextChanged);
            this.label7.AutoSize = true;
            this.label7.Location = new Point(9, 0x5b);
            this.label7.Name = "label7";
            this.label7.Size = new Size(0x4c, 13);
            this.label7.TabIndex = 0xe7;
            this.label7.Text = "Total Amount :";
            this.txtPenaltyAmount.BackColor = SystemColors.ActiveCaptionText;
            this.txtPenaltyAmount.Location = new Point(0x161, 0x41);
            this.txtPenaltyAmount.MaxLength = 10;
            this.txtPenaltyAmount.Name = "txtPenaltyAmount";
            this.txtPenaltyAmount.Size = new Size(0xc1, 20);
            this.txtPenaltyAmount.TabIndex = 0xe5;
            this.txtPenaltyAmount.TextAlign = HorizontalAlignment.Right;
            this.txtPenaltyAmount.TextChanged += new EventHandler(this.txtPenaltyAmount_TextChanged);
            this.label6.AutoSize = true;
            this.label6.Location = new Point(9, 0x43);
            this.label6.Name = "label6";
            this.label6.Size = new Size(0x51, 13);
            this.label6.TabIndex = 0xe4;
            this.label6.Text = "Penalty Amount";
            this.txtStudentDiscount.BackColor = SystemColors.ActiveCaptionText;
            this.txtStudentDiscount.Location = new Point(0x161, 0x2a);
            this.txtStudentDiscount.MaxLength = 10;
            this.txtStudentDiscount.Name = "txtStudentDiscount";
            this.txtStudentDiscount.Size = new Size(0xc1, 20);
            this.txtStudentDiscount.TabIndex = 0xe3;
            this.txtStudentDiscount.TextAlign = HorizontalAlignment.Right;
            this.txtStudentDiscount.TextChanged += new EventHandler(this.txtStudentDiscount_TextChanged);
            this.label4.AutoSize = true;
            this.label4.Location = new Point(9, 0x2d);
            this.label4.Name = "label4";
            this.label4.Size = new Size(0x37, 13);
            this.label4.TabIndex = 0xe2;
            this.label4.Text = "Discount :";
            this.txtStudentFees.BackColor = SystemColors.ActiveCaptionText;
            this.txtStudentFees.Location = new Point(0x161, 0x13);
            this.txtStudentFees.MaxLength = 10;
            this.txtStudentFees.Name = "txtStudentFees";
            this.txtStudentFees.ReadOnly = true;
            this.txtStudentFees.Size = new Size(0xc1, 20);
            this.txtStudentFees.TabIndex = 0xe0;
            this.txtStudentFees.TextAlign = HorizontalAlignment.Right;
            this.txtStudentFees.TextChanged += new EventHandler(this.txtStudentFees_TextChanged);
            this.label3.AutoSize = true;
            this.label3.Location = new Point(9, 0x16);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x24, 13);
            this.label3.TabIndex = 0xe1;
            this.label3.Text = "Fees :";
            this.txtInvoiceNo.BackColor = SystemColors.ActiveCaptionText;
            this.txtInvoiceNo.Location = new Point(0x75, 12);
            this.txtInvoiceNo.MaxLength = 10;
            this.txtInvoiceNo.Name = "txtInvoiceNo";
            this.txtInvoiceNo.ReadOnly = true;
            this.txtInvoiceNo.Size = new Size(0xc1, 20);
            this.txtInvoiceNo.TabIndex = 220;
            this.txtInvoiceNo.TextChanged += new EventHandler(this.txtInvoiceNo_TextChanged);
            this.label1.AutoSize = true;
            this.label1.Location = new Point(7, 0x10);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x41, 13);
            this.label1.TabIndex = 0xdd;
            this.label1.Text = "Invoice No :";
            this.dtpDateOfInvoice.Format = DateTimePickerFormat.Short;
            this.dtpDateOfInvoice.Location = new Point(0x1aa, 12);
            this.dtpDateOfInvoice.Name = "dtpDateOfInvoice";
            this.dtpDateOfInvoice.Size = new Size(0x66, 20);
            this.dtpDateOfInvoice.TabIndex = 0xda;
            this.dtpDateOfInvoice.ValueChanged += new EventHandler(this.dtpDateOfInvoice_ValueChanged);
            this.label94.AutoSize = true;
            this.label94.Location = new Point(0x151, 14);
            this.label94.Name = "label94";
            this.label94.Size = new Size(0x4a, 13);
            this.label94.TabIndex = 0xdb;
            this.label94.Text = "Invoice Date :";
            this.txtFullNameLineTwo.BackColor = SystemColors.ActiveCaptionText;
            this.txtFullNameLineTwo.Location = new Point(0x75, 0x61);
            this.txtFullNameLineTwo.MaxLength = 100;
            this.txtFullNameLineTwo.Name = "txtFullNameLineTwo";
            this.txtFullNameLineTwo.ReadOnly = true;
            this.txtFullNameLineTwo.Size = new Size(0x1b3, 20);
            this.txtFullNameLineTwo.TabIndex = 0xd4;
            this.txtFullNameLineOne.BackColor = SystemColors.ActiveCaptionText;
            this.txtFullNameLineOne.Location = new Point(0x75, 0x4a);
            this.txtFullNameLineOne.MaxLength = 100;
            this.txtFullNameLineOne.Name = "txtFullNameLineOne";
            this.txtFullNameLineOne.ReadOnly = true;
            this.txtFullNameLineOne.Size = new Size(0x1b3, 20);
            this.txtFullNameLineOne.TabIndex = 0xd3;
            this.txtStudentNo.BackColor = SystemColors.ActiveCaptionText;
            this.txtStudentNo.Location = new Point(0x75, 0x33);
            this.txtStudentNo.MaxLength = 10;
            this.txtStudentNo.Name = "txtStudentNo";
            this.txtStudentNo.Size = new Size(0xc1, 20);
            this.txtStudentNo.TabIndex = 210;
            this.txtStudentNo.TextChanged += new EventHandler(this.txtStudentNo_TextChanged);
            this.label2.AutoSize = true;
            this.label2.Location = new Point(7, 0x36);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x43, 13);
            this.label2.TabIndex = 0xd6;
            this.label2.Text = "Student No :";
            this.label5.AutoSize = true;
            this.label5.Location = new Point(7, 0x4d);
            this.label5.Name = "label5";
            this.label5.Size = new Size(0x47, 13);
            this.label5.TabIndex = 0xd5;
            this.label5.Text = "Name in Full :";
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x232, 0x1a3);
            base.Controls.Add(this.groupBox1);
            base.Name = "frmInvoice";
            this.Text = "Pool Attendance System";
            base.Load += new EventHandler(this.frmInvoice_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            base.ResumeLayout(false);
        }

        private void InvoiceProcess(string strStudentNo, DateTime dtInvoiceDate)
        {
            DataTable invoiceDetails = this.cInvoice.GetInvoiceDetails(this.cGlobleVariable.LocationCode, strStudentNo);
            this.txtPenaltyAmount.Text = "0.00";
            if (invoiceDetails.Rows.Count > 0)
            {
                this.oInvoice = this.cInvoice.GetInvoiceData(this.cGlobleVariable.LocationCode, strStudentNo, dtInvoiceDate);
                if (this.oInvoice.IsExistInvoice)
                {
                    this.txtInvoiceNo.Text = this.oInvoice.InvoiceNo.ToString();
                    this.txtStudentDiscount.Text = this.oInvoice.Discount.ToString();
                }
                else if (this.cInvoice.GetInvoiceDetails(this.cGlobleVariable.LocationCode, strStudentNo, Convert.ToDateTime(invoiceDetails.Rows[0][4].ToString())).Rows.Count > 0)
                {
                    this.oPaymentMethod = this.cPaymentMethod.GetPaymentMethod(this.cGlobleVariable.LocationCode, this.oPaymentDeatils.StudentPayMethodCode);
                    if (this.oPaymentMethod.IxExist)
                    {
                        TimeSpan span = (TimeSpan) (this.dtpPayTo.Value - this.dtpPayFrom.Value);
                        int num = Convert.ToInt32(span.Days);
                        double d = ((double) num) / this.oPaymentMethod.PaymentDays;
                        if (num > 0)
                        {
                            this.txtStudentFees.Text = Convert.ToString((double) (Math.Floor(d) * this.oStudentMaster.Fees));
                        }
                        DateTime time = Convert.ToDateTime(invoiceDetails.Rows[invoiceDetails.Rows.Count - 1][4].ToString()).AddDays(this.oPaymentMethod.PaymentDays);
                        if (dtInvoiceDate > time)
                        {
                            TimeSpan span2 = (TimeSpan) (dtInvoiceDate - time);
                            int num3 = Convert.ToInt32(span2.Days);
                            this.oPaymentMethod = this.cPaymentMethod.GetPaymentMethod(this.cGlobleVariable.LocationCode, this.oPaymentDeatils.PenaltyPayMethodCode);
                            if (this.oPaymentMethod.IxExist && (num3 > this.oPaymentMethod.PaymentDays))
                            {
                                this.txtInvoiceNo.Text = "";
                                this.txtPenaltyAmount.Text = "0";
                                this.txtTotalAmount.Text = "0";
                                double num4 = ((double) num3) / this.oPaymentMethod.PaymentDays;
                                this.txtPenaltyAmount.Text = Convert.ToString((double) (this.oPaymentDeatils.PenaltyPayAmount * Math.Floor(num4)));
                            }
                        }
                    }
                }
            }
        }

        private void LoadStudent()
        {
            this.oStudentMaster = this.cStudentMaster.GetStudentData(this.cGlobleVariable.LocationCode, this.txtStudentNo.Text.ToString());
            if (this.oStudentMaster.IsExistStudent)
            {
                this.txtStudentNo.Text = this.oStudentMaster.StudentNo;
                this.txtFullNameLineOne.Text = this.oStudentMaster.NameInFullL1;
                this.txtFullNameLineTwo.Text = this.oStudentMaster.NameInFullL2;
                this.txtStudentFees.Text = this.oStudentMaster.Fees.ToString();
            }
            this.oPaymentDeatils = this.cPaymentDeatils.GetPaymentDeatils(this.cGlobleVariable.LocationCode, this.txtStudentNo.Text.ToString());
            if (this.oPaymentDeatils.IsPaymentExist)
            {
                this.txtStudentDiscount.Text = this.oPaymentDeatils.StudentDicount.ToString();
                this.InvoiceProcess(this.txtStudentNo.Text, this.dtpDateOfInvoice.Value);
            }
            this.txtTotalAmount.Text = Convert.ToString((double) ((Convert.ToDouble(this.txtStudentFees.Text) - Convert.ToDouble(this.txtStudentDiscount.Text)) + Convert.ToDouble(this.txtPenaltyAmount.Text)));
            DataTable vAT = this.cVAT.GetVAT();
            if (vAT.Rows.Count > 0)
            {
                this.txtVAT.Text = Convert.ToString((double) (Convert.ToDouble(this.txtTotalAmount.Text) * (Convert.ToDouble(vAT.Rows[0][2].ToString()) / 100.0)));
                this.txtGrandTotal.Text = Convert.ToString((double) (Convert.ToDouble(this.txtTotalAmount.Text) + Convert.ToDouble(this.txtVAT.Text)));
            }
        }

        private void ReportViwer()
        {
            string strReportName = "rptInvoice.rpt";
            object[,] arrParameter = new object[,] { { "strCopyRight", this.cGlobleVariable.CopyRight }, { "strInvoiceNo", this.txtInvoiceNo.Text } };
            new frmReportViever(strReportName, this.SelectionFormularValues(), arrParameter).Show();
        }

        private string SelectionFormularValues()
        {
            return "{tbl_invoice_master.fldInvoiceNo}={?strInvoiceNo}";
        }

        private void txtGrandTotal_TextChanged(object sender, EventArgs e)
        {
            this.txtGrandTotal.Text = string.Format("{0:0.00}", Convert.ToDouble(this.txtGrandTotal.Text));
        }

        private void txtInvoiceNo_TextChanged(object sender, EventArgs e)
        {
            this.oInvoice = this.cInvoice.GetInvDetails(this.cGlobleVariable.LocationCode, this.txtInvoiceNo.Text);
            if (this.oInvoice.IsExistInvoice)
            {
                this.txtInvoiceNo.Text = this.oInvoice.InvoiceNo;
                this.dtpDateOfInvoice.Value = this.oInvoice.InvoiceDate;
                this.txtStudentNo.Text = this.oInvoice.StudentNo;
            }
        }

        private void txtPenaltyAmount_TextChanged(object sender, EventArgs e)
        {
            this.txtPenaltyAmount.Text = string.Format("{0:0.00}", Convert.ToDouble(this.txtPenaltyAmount.Text));
        }

        private void txtStudentDiscount_TextChanged(object sender, EventArgs e)
        {
            this.txtStudentDiscount.Text = string.Format("{0:0.00}", Convert.ToDouble(this.txtStudentDiscount.Text));
        }

        private void txtStudentFees_TextChanged(object sender, EventArgs e)
        {
            this.txtStudentFees.Text = string.Format("{0:0.00}", Convert.ToDouble(this.txtStudentFees.Text));
        }

        private void txtStudentNo_TextChanged(object sender, EventArgs e)
        {
            this.txtInvoiceNo.Text = string.Empty;
            this.LoadStudent();
        }

        private void txtTotalAmount_TextChanged(object sender, EventArgs e)
        {
            this.txtTotalAmount.Text = string.Format("{0:0.00}", Convert.ToDouble(this.txtTotalAmount.Text));
        }

        private void txtVAT_TextChanged(object sender, EventArgs e)
        {
            this.txtVAT.Text = string.Format("{0:0.00}", Convert.ToDouble(this.txtVAT.Text));
        }

        public void ViewInvoice()
        {
            string[] strFieldList = new string[] { "fldInvoiceNo", "fldInvoiceDate" };
            string[] strHeadingList = new string[] { "Invoice No", "Invoice Name" };
            int[] iHeaderWidth = new int[] { 80, 100 };
            string strReturnField = "Invoice No";
            string str2 = "fldLocationCode = '" + this.cGlobleVariable.LocationCode + "' ";
            this.txtInvoiceNo.Text = this.cCommanMethods.BrowsData("tbl_invoice_master", strFieldList, strHeadingList, iHeaderWidth, strReturnField, str2);
        }
    }
}

