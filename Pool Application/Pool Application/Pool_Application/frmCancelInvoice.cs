namespace Pool_Application
{
    using Business_Layer;
    using Business_Layer.Property_Layer;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;

    public class frmCancelInvoice : Form
    {
        public Button btnCancelInvoice;
        public Button btnExit;
        public Button btnRefresh;
        private Button btnView;
        private clsAuditLog cAuditLog = new clsAuditLog();
        private clsCancelInvoice cCancelInvoice = new clsCancelInvoice();
        private clsClassMaster cClassMaster = new clsClassMaster();
        private clsCommenMethods cCommanMethods = new clsCommenMethods();
        private clsGlobleVariable cGlobleVariable = new clsGlobleVariable();
        private clsInvoice cInvoice = new clsInvoice();
        private clsInvoiceItemAmounts cInvoiceItemAmounts = new clsInvoiceItemAmounts();
        private clsInvoiceTaxAmount cInvoiceTaxAmount = new clsInvoiceTaxAmount();
        private clsNBT cNBT = new clsNBT();
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private IContainer components = null;
        private clsStudentMaster cStudentMaster = new clsStudentMaster();
        private clsTax cTax = new clsTax();
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private DataGridView dgvFeesItem;
        private DataGridView dgvTax;
        private DateTimePicker dtpDateOfInvoice;
        private DateTimePicker dtpInvoiceCancel;
        private DateTimePicker dtpPayFrom;
        private DateTimePicker dtpPayTo;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Label label1;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label label14;
        private Label label16;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label94;
        private objAuditLog oAuditLog = new objAuditLog();
        private objCancelInvoice oCancelInvoice = new objCancelInvoice();
        private objInvoice oInvoice = new objInvoice();
        private objInvoiceItemAmounts oInvoiceItemAmounts = new objInvoiceItemAmounts();
        private objInvoiceTaxAmount oInvoiceTaxAmount = new objInvoiceTaxAmount();
        private objStudentMaster oStudentMaster = new objStudentMaster();
        private Panel panel1;
        private TextBox txtFullNameLineOne;
        private TextBox txtFullNameLineTwo;
        private TextBox txtGrandTotal;
        private TextBox txtInvoiceNo;
        private TextBox txtNBT;
        private TextBox txtPenaltyAmount;
        private TextBox txtStudentDiscount;
        private TextBox txtStudentNo;
        private TextBox txtTotal;
        private TextBox txtTotalAmt;
        private TextBox txtTotTax;

        public frmCancelInvoice()
        {
            this.InitializeComponent();
        }

        private void btnCancelInvoice_Click(object sender, EventArgs e)
        {
            if ((this.txtStudentNo.Text != string.Empty) && (this.txtInvoiceNo.Text != string.Empty))
            {
                this.oCancelInvoice.LocationCode = this.cGlobleVariable.LocationCode;
                this.oCancelInvoice.InvoiceNo = this.txtInvoiceNo.Text;
                this.oCancelInvoice.InvCancelDate = this.dtpInvoiceCancel.Value;
                this.oCancelInvoice.UserCode = this.cGlobleVariable.CurrentUserID;
                this.cCancelInvoice.InsertUpdateData(this.oCancelInvoice);
                this.cInvoice.UpdateInvoice(this.cGlobleVariable.LocationCode, "C", this.txtStudentNo.Text, this.txtInvoiceNo.Text);
                this.oAuditLog.LocationCode = this.cGlobleVariable.LocationCode;
                this.oAuditLog.UserID = this.cGlobleVariable.CurrentUserID;
                this.oAuditLog.MachineID = clsGlobleVariable.MachineID;
                this.oAuditLog.DateEntered = Convert.ToDateTime(this.cAuditLog.getCurrentDate().Rows[0][0].ToString());
                this.oAuditLog.TimeEntered = Convert.ToDateTime(this.cAuditLog.getCurrentTime().Rows[0][0].ToString());
                this.oAuditLog.Task = "Canceled Invoice No " + this.txtInvoiceNo.Text;
                this.cAuditLog.AuditLog(this.oAuditLog);
                MessageBox.Show(this.cGlobleVariable.SeavedMessage, "Receipt Cancel details", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.oAuditLog.LocationCode = this.cGlobleVariable.LocationCode;
            this.oAuditLog.UserID = this.cGlobleVariable.CurrentUserID;
            this.oAuditLog.MachineID = clsGlobleVariable.MachineID;
            this.oAuditLog.DateEntered = Convert.ToDateTime(this.cAuditLog.getCurrentDate().Rows[0][0].ToString());
            this.oAuditLog.TimeEntered = Convert.ToDateTime(this.cAuditLog.getCurrentTime().Rows[0][0].ToString());
            this.oAuditLog.Task = "Exited Cancel Invoice Entry";
            this.cAuditLog.AuditLog(this.oAuditLog);
            base.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.cCommanMethods.ClearForm(this);
            this.txtTotal.Text = "0.00";
            this.txtNBT.Text = "0.00";
            this.txtTotalAmt.Text = "0.00";
            this.txtTotTax.Text = "0.00";
            this.txtGrandTotal.Text = "0.00";
            this.txtStudentDiscount.Text = "0.00";
            this.txtPenaltyAmount.Text = "0.00";
            this.txtInvoiceNo.Text = string.Empty;
            this.dgvFeesItem.Rows.Clear();
            this.dgvTax.Rows.Clear();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            this.ViewInvoice();
            this.oAuditLog.LocationCode = this.cGlobleVariable.LocationCode;
            this.oAuditLog.UserID = this.cGlobleVariable.CurrentUserID;
            this.oAuditLog.MachineID = clsGlobleVariable.MachineID;
            this.oAuditLog.DateEntered = Convert.ToDateTime(this.cAuditLog.getCurrentDate().Rows[0][0].ToString());
            this.oAuditLog.TimeEntered = Convert.ToDateTime(this.cAuditLog.getCurrentTime().Rows[0][0].ToString());
            this.oAuditLog.Task = "Viewed Invoice No " + this.txtInvoiceNo.Text + " For Cancelation";
            this.cAuditLog.AuditLog(this.oAuditLog);
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
            DataGridViewCellStyle style = new DataGridViewCellStyle();
            DataGridViewCellStyle style2 = new DataGridViewCellStyle();
            DataGridViewCellStyle style3 = new DataGridViewCellStyle();
            DataGridViewCellStyle style4 = new DataGridViewCellStyle();
            DataGridViewCellStyle style5 = new DataGridViewCellStyle();
            DataGridViewCellStyle style6 = new DataGridViewCellStyle();
            DataGridViewCellStyle style7 = new DataGridViewCellStyle();
            DataGridViewCellStyle style8 = new DataGridViewCellStyle();
            DataGridViewCellStyle style9 = new DataGridViewCellStyle();
            DataGridViewCellStyle style10 = new DataGridViewCellStyle();
            this.txtInvoiceNo = new TextBox();
            this.label1 = new Label();
            this.label94 = new Label();
            this.dtpDateOfInvoice = new DateTimePicker();
            this.txtFullNameLineTwo = new TextBox();
            this.txtFullNameLineOne = new TextBox();
            this.txtStudentNo = new TextBox();
            this.label2 = new Label();
            this.label5 = new Label();
            this.label7 = new Label();
            this.txtNBT = new TextBox();
            this.label8 = new Label();
            this.txtTotTax = new TextBox();
            this.dgvTax = new DataGridView();
            this.Column4 = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new DataGridViewTextBoxColumn();
            this.txtTotal = new TextBox();
            this.panel1 = new Panel();
            this.btnView = new Button();
            this.btnRefresh = new Button();
            this.btnCancelInvoice = new Button();
            this.btnExit = new Button();
            this.label14 = new Label();
            this.groupBox1 = new GroupBox();
            this.dtpInvoiceCancel = new DateTimePicker();
            this.label16 = new Label();
            this.label3 = new Label();
            this.label13 = new Label();
            this.dgvFeesItem = new DataGridView();
            this.Column3 = new DataGridViewTextBoxColumn();
            this.Column1 = new DataGridViewTextBoxColumn();
            this.Column2 = new DataGridViewTextBoxColumn();
            this.label11 = new Label();
            this.dtpPayTo = new DateTimePicker();
            this.dtpPayFrom = new DateTimePicker();
            this.label10 = new Label();
            this.dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new DataGridViewTextBoxColumn();
            this.groupBox2 = new GroupBox();
            this.label12 = new Label();
            this.txtGrandTotal = new TextBox();
            this.txtTotalAmt = new TextBox();
            this.label9 = new Label();
            this.txtPenaltyAmount = new TextBox();
            this.label6 = new Label();
            this.txtStudentDiscount = new TextBox();
            this.label4 = new Label();
            ((ISupportInitialize) this.dgvTax).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((ISupportInitialize) this.dgvFeesItem).BeginInit();
            this.groupBox2.SuspendLayout();
            base.SuspendLayout();
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
            this.label94.AutoSize = true;
            this.label94.Location = new Point(680, 0x15);
            this.label94.Name = "label94";
            this.label94.Size = new Size(0x4a, 13);
            this.label94.TabIndex = 0xdb;
            this.label94.Text = "Invoice Date :";
            this.dtpDateOfInvoice.Enabled = false;
            this.dtpDateOfInvoice.Format = DateTimePickerFormat.Short;
            this.dtpDateOfInvoice.Location = new Point(0x301, 0x13);
            this.dtpDateOfInvoice.Name = "dtpDateOfInvoice";
            this.dtpDateOfInvoice.Size = new Size(0x66, 20);
            this.dtpDateOfInvoice.TabIndex = 0;
            this.txtFullNameLineTwo.BackColor = SystemColors.ActiveCaptionText;
            this.txtFullNameLineTwo.Location = new Point(0x75, 0x61);
            this.txtFullNameLineTwo.MaxLength = 100;
            this.txtFullNameLineTwo.Name = "txtFullNameLineTwo";
            this.txtFullNameLineTwo.ReadOnly = true;
            this.txtFullNameLineTwo.Size = new Size(0x2f2, 20);
            this.txtFullNameLineTwo.TabIndex = 0xd4;
            this.txtFullNameLineOne.BackColor = SystemColors.ActiveCaptionText;
            this.txtFullNameLineOne.Location = new Point(0x75, 0x4a);
            this.txtFullNameLineOne.MaxLength = 100;
            this.txtFullNameLineOne.Name = "txtFullNameLineOne";
            this.txtFullNameLineOne.ReadOnly = true;
            this.txtFullNameLineOne.Size = new Size(0x2f2, 20);
            this.txtFullNameLineOne.TabIndex = 0xd3;
            this.txtStudentNo.BackColor = SystemColors.ActiveCaptionText;
            this.txtStudentNo.Location = new Point(0x75, 0x33);
            this.txtStudentNo.MaxLength = 10;
            this.txtStudentNo.Name = "txtStudentNo";
            this.txtStudentNo.ReadOnly = true;
            this.txtStudentNo.Size = new Size(0xc1, 20);
            this.txtStudentNo.TabIndex = 1;
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
            this.label7.AutoSize = true;
            this.label7.Location = new Point(8, 0x14c);
            this.label7.Name = "label7";
            this.label7.Size = new Size(0x25, 13);
            this.label7.TabIndex = 0xef;
            this.label7.Text = "Total :";
            this.txtNBT.BackColor = SystemColors.ActiveCaptionText;
            this.txtNBT.Location = new Point(0x164, 0x163);
            this.txtNBT.MaxLength = 10;
            this.txtNBT.Name = "txtNBT";
            this.txtNBT.ReadOnly = true;
            this.txtNBT.Size = new Size(190, 20);
            this.txtNBT.TabIndex = 0xee;
            this.txtNBT.Text = "0.00";
            this.txtNBT.TextAlign = HorizontalAlignment.Right;
            this.label8.AutoSize = true;
            this.label8.Location = new Point(9, 0x163);
            this.label8.Name = "label8";
            this.label8.Size = new Size(0x2c, 13);
            this.label8.TabIndex = 0xed;
            this.label8.Text = "N. B. T.";
            this.txtTotTax.BackColor = SystemColors.ActiveCaptionText;
            this.txtTotTax.Location = new Point(0x2a5, 0x149);
            this.txtTotTax.MaxLength = 10;
            this.txtTotTax.Name = "txtTotTax";
            this.txtTotTax.ReadOnly = true;
            this.txtTotTax.Size = new Size(190, 20);
            this.txtTotTax.TabIndex = 0xec;
            this.txtTotTax.Text = "0.00";
            this.txtTotTax.TextAlign = HorizontalAlignment.Right;
            this.dgvTax.AllowUserToAddRows = false;
            this.dgvTax.AllowUserToDeleteRows = false;
            this.dgvTax.AllowUserToResizeColumns = false;
            this.dgvTax.AllowUserToResizeRows = false;
            this.dgvTax.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTax.Columns.AddRange(new DataGridViewColumn[] { this.Column4, this.dataGridViewTextBoxColumn8, this.dataGridViewTextBoxColumn9 });
            this.dgvTax.Location = new Point(0x228, 0xb2);
            this.dgvTax.Name = "dgvTax";
            this.dgvTax.Size = new Size(0x13e, 0x91);
            this.dgvTax.TabIndex = 0xeb;
            this.Column4.HeaderText = "ItemCode";
            this.Column4.Name = "Column4";
            this.Column4.Visible = false;
            style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.dataGridViewTextBoxColumn8.DefaultCellStyle = style;
            this.dataGridViewTextBoxColumn8.HeaderText = "Item";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Resizable = DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn8.Width = 0xaf;
            style2.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn9.DefaultCellStyle = style2;
            this.dataGridViewTextBoxColumn9.HeaderText = "Amount";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Resizable = DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn9.Width = 0x61;
            this.txtTotal.BackColor = SystemColors.ActiveCaptionText;
            this.txtTotal.Location = new Point(0x164, 0x149);
            this.txtTotal.MaxLength = 10;
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new Size(190, 20);
            this.txtTotal.TabIndex = 0xea;
            this.txtTotal.Text = "0.00";
            this.txtTotal.TextAlign = HorizontalAlignment.Right;
            this.panel1.Controls.Add(this.btnView);
            this.panel1.Controls.Add(this.btnRefresh);
            this.panel1.Controls.Add(this.btnCancelInvoice);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Location = new Point(3, 0x21d);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(880, 40);
            this.panel1.TabIndex = 0xe1;
            this.btnView.Location = new Point(100, 6);
            this.btnView.Name = "btnView";
            this.btnView.Size = new Size(0x4b, 0x17);
            this.btnView.TabIndex = 0x26;
            this.btnView.Text = "&View";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new EventHandler(this.btnView_Click);
            this.btnRefresh.Location = new Point(0xb5, 6);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new Size(0x49, 0x17);
            this.btnRefresh.TabIndex = 0x25;
            this.btnRefresh.Text = "&Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new EventHandler(this.btnRefresh_Click);
            this.btnCancelInvoice.Location = new Point(3, 6);
            this.btnCancelInvoice.Name = "btnCancelInvoice";
            this.btnCancelInvoice.Size = new Size(0x5b, 0x17);
            this.btnCancelInvoice.TabIndex = 8;
            this.btnCancelInvoice.Text = "&Cancel Invoice";
            this.btnCancelInvoice.UseVisualStyleBackColor = true;
            this.btnCancelInvoice.Click += new EventHandler(this.btnCancelInvoice_Click);
            this.btnExit.FlatAppearance.BorderColor = Color.FromArgb(0x40, 0x40, 0x40);
            this.btnExit.FlatAppearance.BorderSize = 5;
            this.btnExit.Location = new Point(0x313, 6);
            this.btnExit.Margin = new Padding(0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new Size(0x53, 0x17);
            this.btnExit.TabIndex = 0x23;
            this.btnExit.Text = "E&xit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new EventHandler(this.btnExit_Click);
            this.label14.AutoSize = true;
            this.label14.Location = new Point(0x228, 0x14c);
            this.label14.Name = "label14";
            this.label14.Size = new Size(0x37, 13);
            this.label14.TabIndex = 0xf3;
            this.label14.Text = "Total Tax:";
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.dtpInvoiceCancel);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtNBT);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtTotTax);
            this.groupBox1.Controls.Add(this.dgvTax);
            this.groupBox1.Controls.Add(this.txtTotal);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.dgvFeesItem);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.dtpPayTo);
            this.groupBox1.Controls.Add(this.dtpPayFrom);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.txtInvoiceNo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtpDateOfInvoice);
            this.groupBox1.Controls.Add(this.label94);
            this.groupBox1.Controls.Add(this.txtFullNameLineTwo);
            this.groupBox1.Controls.Add(this.txtFullNameLineOne);
            this.groupBox1.Controls.Add(this.txtStudentNo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new Point(1, -2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(0x374, 0x250);
            this.groupBox1.TabIndex = 0xd6;
            this.groupBox1.TabStop = false;
            this.dtpInvoiceCancel.Format = DateTimePickerFormat.Short;
            this.dtpInvoiceCancel.Location = new Point(0x1e1, 0x11);
            this.dtpInvoiceCancel.Name = "dtpInvoiceCancel";
            this.dtpInvoiceCancel.Size = new Size(0x66, 20);
            this.dtpInvoiceCancel.TabIndex = 0xf5;
            this.label16.AutoSize = true;
            this.label16.Location = new Point(0x16d, 0x15);
            this.label16.Name = "label16";
            this.label16.Size = new Size(110, 13);
            this.label16.TabIndex = 0xf6;
            this.label16.Text = "Invoice Cancel Date :";
            this.label3.AutoSize = true;
            this.label3.Location = new Point(7, 0x98);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x24, 13);
            this.label3.TabIndex = 0xf4;
            this.label3.Text = "Fees :";
            this.label13.AutoSize = true;
            this.label13.Location = new Point(0x228, 0x98);
            this.label13.Name = "label13";
            this.label13.Size = new Size(0x1f, 13);
            this.label13.TabIndex = 0xf2;
            this.label13.Text = "Tax :";
            this.dgvFeesItem.AllowUserToAddRows = false;
            this.dgvFeesItem.AllowUserToResizeColumns = false;
            this.dgvFeesItem.AllowUserToResizeRows = false;
            this.dgvFeesItem.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFeesItem.Columns.AddRange(new DataGridViewColumn[] { this.Column3, this.Column1, this.Column2 });
            this.dgvFeesItem.Location = new Point(12, 0xb2);
            this.dgvFeesItem.Name = "dgvFeesItem";
            this.dgvFeesItem.Size = new Size(0x216, 0x91);
            this.dgvFeesItem.TabIndex = 0xe7;
            this.Column3.HeaderText = "ItemCode";
            this.Column3.Name = "Column3";
            this.Column3.Visible = false;
            style3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.Column1.DefaultCellStyle = style3;
            this.Column1.HeaderText = "Item";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Resizable = DataGridViewTriState.False;
            this.Column1.Width = 0x131;
            style4.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.Column2.DefaultCellStyle = style4;
            this.Column2.HeaderText = "Amount";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Resizable = DataGridViewTriState.False;
            this.Column2.Width = 0xb9;
            this.label11.AutoSize = true;
            this.label11.Location = new Point(0xf9, 0x7c);
            this.label11.Name = "label11";
            this.label11.Size = new Size(20, 13);
            this.label11.TabIndex = 230;
            this.label11.Text = "To";
            this.dtpPayTo.Enabled = false;
            this.dtpPayTo.Format = DateTimePickerFormat.Short;
            this.dtpPayTo.Location = new Point(0x11c, 120);
            this.dtpPayTo.Name = "dtpPayTo";
            this.dtpPayTo.Size = new Size(0x66, 20);
            this.dtpPayTo.TabIndex = 3;
            this.dtpPayFrom.Enabled = false;
            this.dtpPayFrom.Format = DateTimePickerFormat.Short;
            this.dtpPayFrom.Location = new Point(0x75, 120);
            this.dtpPayFrom.Name = "dtpPayFrom";
            this.dtpPayFrom.Size = new Size(0x66, 20);
            this.dtpPayFrom.TabIndex = 2;
            this.label10.AutoSize = true;
            this.label10.Location = new Point(7, 0x7c);
            this.label10.Name = "label10";
            this.label10.Size = new Size(0x4b, 13);
            this.label10.TabIndex = 0xe5;
            this.label10.Text = "Payment Term";
            style5.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = style5;
            this.dataGridViewTextBoxColumn1.HeaderText = "Amount";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Resizable = DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn1.Visible = false;
            this.dataGridViewTextBoxColumn1.Width = 0x61;
            style6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = style6;
            this.dataGridViewTextBoxColumn2.HeaderText = "Item";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Resizable = DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn2.Width = 0x131;
            style7.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = style7;
            this.dataGridViewTextBoxColumn3.HeaderText = "Amount";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Resizable = DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn3.Width = 0x61;
            this.dataGridViewTextBoxColumn4.HeaderText = "ItemCode";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Visible = false;
            style8.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.dataGridViewTextBoxColumn5.DefaultCellStyle = style8;
            this.dataGridViewTextBoxColumn5.HeaderText = "Item";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Resizable = DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn5.Width = 0x131;
            style9.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn6.DefaultCellStyle = style9;
            this.dataGridViewTextBoxColumn6.HeaderText = "Amount";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Resizable = DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn6.Width = 0xb9;
            this.dataGridViewTextBoxColumn7.HeaderText = "ItemCode";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Visible = false;
            style10.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn10.DefaultCellStyle = style10;
            this.dataGridViewTextBoxColumn10.HeaderText = "Amount";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.Resizable = DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn10.Width = 0xb9;
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.txtGrandTotal);
            this.groupBox2.Controls.Add(this.txtTotalAmt);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtPenaltyAmount);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtStudentDiscount);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new Point(4, 0x17d);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new Size(880, 0x98);
            this.groupBox2.TabIndex = 0xf7;
            this.groupBox2.TabStop = false;
            this.label12.AutoSize = true;
            this.label12.Location = new Point(9, 0x43);
            this.label12.Name = "label12";
            this.label12.Size = new Size(0x3b, 13);
            this.label12.TabIndex = 0xf5;
            this.label12.Text = "Sub Total :";
            this.txtGrandTotal.BackColor = SystemColors.ActiveCaptionText;
            this.txtGrandTotal.Location = new Point(0x2a5, 0x79);
            this.txtGrandTotal.MaxLength = 10;
            this.txtGrandTotal.Name = "txtGrandTotal";
            this.txtGrandTotal.ReadOnly = true;
            this.txtGrandTotal.Size = new Size(0xc1, 20);
            this.txtGrandTotal.TabIndex = 0xeb;
            this.txtGrandTotal.Text = "0.00";
            this.txtGrandTotal.TextAlign = HorizontalAlignment.Right;
            this.txtTotalAmt.BackColor = SystemColors.ActiveCaptionText;
            this.txtTotalAmt.Location = new Point(0x2a6, 0x40);
            this.txtTotalAmt.MaxLength = 10;
            this.txtTotalAmt.Name = "txtTotalAmt";
            this.txtTotalAmt.ReadOnly = true;
            this.txtTotalAmt.Size = new Size(0xc1, 20);
            this.txtTotalAmt.TabIndex = 0xf4;
            this.txtTotalAmt.Text = "0.00";
            this.txtTotalAmt.TextAlign = HorizontalAlignment.Right;
            this.label9.AutoSize = true;
            this.label9.Location = new Point(9, 0x7c);
            this.label9.Name = "label9";
            this.label9.Size = new Size(0x3f, 13);
            this.label9.TabIndex = 0xea;
            this.label9.Text = "Grand Total";
            this.txtPenaltyAmount.BackColor = SystemColors.ActiveCaptionText;
            this.txtPenaltyAmount.Location = new Point(0x2a6, 0x29);
            this.txtPenaltyAmount.MaxLength = 10;
            this.txtPenaltyAmount.Name = "txtPenaltyAmount";
            this.txtPenaltyAmount.ReadOnly = true;
            this.txtPenaltyAmount.Size = new Size(0xc1, 20);
            this.txtPenaltyAmount.TabIndex = 7;
            this.txtPenaltyAmount.Text = "0.00";
            this.txtPenaltyAmount.TextAlign = HorizontalAlignment.Right;
            this.label6.AutoSize = true;
            this.label6.Location = new Point(9, 0x2c);
            this.label6.Name = "label6";
            this.label6.Size = new Size(0x57, 13);
            this.label6.TabIndex = 0xe4;
            this.label6.Text = "Penalty Amount :";
            this.txtStudentDiscount.BackColor = SystemColors.ActiveCaptionText;
            this.txtStudentDiscount.Location = new Point(0x2a6, 0x12);
            this.txtStudentDiscount.MaxLength = 10;
            this.txtStudentDiscount.Name = "txtStudentDiscount";
            this.txtStudentDiscount.ReadOnly = true;
            this.txtStudentDiscount.Size = new Size(0xc1, 20);
            this.txtStudentDiscount.TabIndex = 6;
            this.txtStudentDiscount.Text = "0.00";
            this.txtStudentDiscount.TextAlign = HorizontalAlignment.Right;
            this.label4.AutoSize = true;
            this.label4.Location = new Point(9, 0x15);
            this.label4.Name = "label4";
            this.label4.Size = new Size(0x37, 13);
            this.label4.TabIndex = 0xe2;
            this.label4.Text = "Discount :";
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x377, 0x24d);
            base.Controls.Add(this.groupBox1);
            base.Name = "frmCancelInvoice";
            this.Text = "Invoice Cancellation";
            ((ISupportInitialize) this.dgvTax).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((ISupportInitialize) this.dgvFeesItem).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            base.ResumeLayout(false);
        }

        private void LoadStudent()
        {
            if (this.txtStudentNo.Text.ToString().Length == 6)
            {
                this.oStudentMaster = this.cStudentMaster.GetStudentData(this.cGlobleVariable.LocationCode, this.txtStudentNo.Text.ToString());
                if (this.oStudentMaster.IsExistStudent)
                {
                    this.txtStudentNo.Text = this.oStudentMaster.StudentNo;
                    this.txtFullNameLineOne.Text = this.oStudentMaster.NameInFullL1;
                    this.txtFullNameLineTwo.Text = this.oStudentMaster.NameInFullL2;
                }
            }
            if (this.txtPenaltyAmount.Text == string.Empty)
            {
                this.txtPenaltyAmount.Text = "0.00";
            }
            else
            {
                this.txtPenaltyAmount.Text = string.Format("{0:0.00}", Convert.ToDouble(this.txtPenaltyAmount.Text));
            }
            if (this.txtStudentDiscount.Text == string.Empty)
            {
                this.txtStudentDiscount.Text = "0.00";
            }
            else
            {
                this.txtStudentDiscount.Text = string.Format("{0:0.00}", Convert.ToDouble(this.txtStudentDiscount.Text));
            }
        }

        private void txtInvoiceNo_TextChanged(object sender, EventArgs e)
        {
            this.oInvoice = this.cInvoice.GetInvDetails(this.cGlobleVariable.LocationCode, this.txtInvoiceNo.Text);
            if (this.oInvoice.IsExistInvoice)
            {
                int num;
                int count;
                this.txtInvoiceNo.Text = this.oInvoice.InvoiceNo;
                this.dtpDateOfInvoice.Value = this.oInvoice.InvoiceDate;
                this.txtStudentNo.Text = this.oInvoice.StudentNo;
                this.dtpPayFrom.Value = this.oInvoice.PaymentFromDate;
                this.dtpPayTo.Value = this.oInvoice.PaymentToDate;
                this.txtTotal.Text = string.Format("{0:0.00}", this.oInvoice.TotalItemAmount);
                this.txtNBT.Text = string.Format("{0:0.00}", this.oInvoice.NBTAmount);
                this.txtTotalAmt.Text = string.Format("{0:0.00}", Convert.ToDouble(this.txtTotal.Text) + Convert.ToDouble(this.txtNBT.Text));
                this.txtTotTax.Text = string.Format("{0:0.00}", this.oInvoice.TotalTaxAmount);
                this.txtStudentDiscount.Text = Convert.ToString(this.oInvoice.Discount);
                this.txtStudentDiscount.Text = string.Format("{0:0.00}", Convert.ToDouble(this.txtStudentDiscount.Text));
                this.txtPenaltyAmount.Text = Convert.ToString(this.oInvoice.PanaltyAmount);
                this.txtPenaltyAmount.Text = string.Format("{0:0.00}", Convert.ToDouble(this.txtPenaltyAmount.Text));
                this.txtTotalAmt.Text = string.Format("{0:0.00}", ((Convert.ToDouble(this.txtTotal.Text) + Convert.ToDouble(this.txtNBT.Text)) + Convert.ToDouble(this.txtPenaltyAmount.Text)) - Convert.ToDouble(this.txtStudentDiscount.Text));
                this.txtGrandTotal.Text = string.Format("{0:0.00}", this.oInvoice.GrandTotal);
                DataTable table = this.cInvoiceItemAmounts.GetInvoiceItemDetails(this.cGlobleVariable.LocationCode, this.txtInvoiceNo.Text, this.txtStudentNo.Text);
                this.dgvFeesItem.Rows.Clear();
                if (table.Rows.Count > 0)
                {
                    for (num = 0; num <= (table.Rows.Count - 1); num++)
                    {
                        count = this.dgvFeesItem.Rows.Count;
                        this.dgvFeesItem.Rows.Add(1);
                        this.dgvFeesItem.Rows[count].Cells[0].Value = table.Rows[num][4].ToString();
                        this.dgvFeesItem.Rows[count].Cells[1].Value = this.cClassMaster.GetClassData(this.cGlobleVariable.LocationCode, table.Rows[num][4].ToString()).ClassName;
                        this.dgvFeesItem.Rows[count].Cells[2].Value = string.Format("{0:0.00}", Convert.ToDouble(table.Rows[num][5].ToString()));
                    }
                }
                DataTable table2 = this.cInvoiceTaxAmount.GetInvoiceTaxDetails(this.cGlobleVariable.LocationCode, this.txtInvoiceNo.Text, this.txtStudentNo.Text);
                this.dgvTax.Rows.Clear();
                if (table2.Rows.Count > 0)
                {
                    for (num = 0; num <= (table2.Rows.Count - 1); num++)
                    {
                        count = this.dgvTax.Rows.Count;
                        this.dgvTax.Rows.Add(1);
                        this.dgvTax.Rows[count].Cells[0].Value = table2.Rows[num][4].ToString();
                        this.dgvTax.Rows[count].Cells[1].Value = this.cTax.GetTaxData(table2.Rows[num][4].ToString()).TaxDescription;
                        this.dgvTax.Rows[count].Cells[2].Value = string.Format("{0:0.00}", Convert.ToDouble(table2.Rows[num][5].ToString()));
                    }
                }
            }
        }

        private void txtStudentNo_TextChanged(object sender, EventArgs e)
        {
            this.LoadStudent();
        }

        public void ViewInvoice()
        {
            string[] strFieldList = new string[] { "fldInvoiceNo", "fldInvoiceDate" };
            string[] strHeadingList = new string[] { "Invoice No", "Invoice Name" };
            int[] iHeaderWidth = new int[] { 80, 100 };
            string strReturnField = "Invoice No";
            string str2 = "fldLocationCode = '" + this.cGlobleVariable.LocationCode + "' AND fldInvoiceStatus='" + this.cGlobleVariable.ActiveStatusCode + "'";
            this.txtInvoiceNo.Text = this.cCommanMethods.BrowsData("tbl_invoice_master", strFieldList, strHeadingList, iHeaderWidth, strReturnField, str2);
        }
    }
}

