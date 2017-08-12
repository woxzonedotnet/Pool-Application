namespace Pool_Application
{
    using Business_Layer;
    using Business_Layer.Property_Layer;
    using JTG;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;

    public class frmActiveCancalHistory : Form
    {
        public Button btnExit;
        public Button btnRefresh;
        public Button btnSave;
        public Button btnView;
        private clsActiveCancalHistory cActiveCancalHistory = new clsActiveCancalHistory();
        private clsAuditLog cAuditLog = new clsAuditLog();
        private clsCommenMethods cCommenMethods = new clsCommenMethods();
        private clsGlobleVariable cGlobleVariable = new clsGlobleVariable();
        private ColumnComboBox cmbStudentStatus;
        private IContainer components = null;
        private clsStatusMaster cStatusMaster = new clsStatusMaster();
        private clsStudentMaster cStudentMaster = new clsStudentMaster();
        private DateTimePicker dtpDateOfActCancel;
        private GroupBox groupBox1;
        private Label label2;
        private Label label5;
        private Label label82;
        private Label label94;
        private objActiveCancalHistory oActiveCancalHistory = new objActiveCancalHistory();
        private objAuditLog oAuditLog = new objAuditLog();
        private objStudentMaster oStudentMaster = new objStudentMaster();
        private Panel panel1;
        private TextBox txtFullNameLineOne;
        private TextBox txtFullNameLineTwo;
        private TextBox txtStudentNo;

        public frmActiveCancalHistory()
        {
            this.InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.oAuditLog.LocationCode = this.cGlobleVariable.LocationCode;
            this.oAuditLog.UserID = this.cGlobleVariable.CurrentUserID;
            this.oAuditLog.MachineID = clsGlobleVariable.MachineID;
            this.oAuditLog.DateEntered = Convert.ToDateTime(this.cAuditLog.getCurrentDate().Rows[0][0].ToString());
            this.oAuditLog.TimeEntered = Convert.ToDateTime(this.cAuditLog.getCurrentTime().Rows[0][0].ToString());
            this.oAuditLog.Task = "Exited Active Cancel Details Entry";
            this.cAuditLog.AuditLog(this.oAuditLog);
            base.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.cCommenMethods.ClearForm(this);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.cStudentMaster.UpdateStatus(this.cGlobleVariable.LocationCode, this.txtStudentNo.Text, this.cmbStudentStatus["fld_Status_Code"].ToString());
            this.oAuditLog.LocationCode = this.cGlobleVariable.LocationCode;
            this.oAuditLog.UserID = this.cGlobleVariable.CurrentUserID;
            this.oAuditLog.MachineID = clsGlobleVariable.MachineID;
            this.oAuditLog.DateEntered = Convert.ToDateTime(this.cAuditLog.getCurrentDate().Rows[0][0].ToString());
            this.oAuditLog.TimeEntered = Convert.ToDateTime(this.cAuditLog.getCurrentTime().Rows[0][0].ToString());
            this.oAuditLog.Task = "Saved Active/ Cancel Details For Student No: " + this.txtStudentNo.Text;
            this.cAuditLog.AuditLog(this.oAuditLog);
            MessageBox.Show(this.cGlobleVariable.SeavedMessage, "Student Active / Cancel details", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            this.ViewEmployee();
            this.oAuditLog.LocationCode = this.cGlobleVariable.LocationCode;
            this.oAuditLog.UserID = this.cGlobleVariable.CurrentUserID;
            this.oAuditLog.MachineID = clsGlobleVariable.MachineID;
            this.oAuditLog.DateEntered = Convert.ToDateTime(this.cAuditLog.getCurrentDate().Rows[0][0].ToString());
            this.oAuditLog.TimeEntered = Convert.ToDateTime(this.cAuditLog.getCurrentTime().Rows[0][0].ToString());
            this.oAuditLog.Task = "Viewed Student Details For Student No: " + this.txtStudentNo.Text + " Active/ Cancel Details";
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

        private void frmActiveCancalHistory_Load(object sender, EventArgs e)
        {
            this.LoadCombos();
            this.txtStudentNo.Select();
        }

        private void InitializeComponent()
        {
            ComponentResourceManager manager = new ComponentResourceManager(typeof(frmActiveCancalHistory));
            this.groupBox1 = new GroupBox();
            this.dtpDateOfActCancel = new DateTimePicker();
            this.label94 = new Label();
            this.cmbStudentStatus = new ColumnComboBox();
            this.label82 = new Label();
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
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            base.SuspendLayout();
            this.groupBox1.Controls.Add(this.dtpDateOfActCancel);
            this.groupBox1.Controls.Add(this.label94);
            this.groupBox1.Controls.Add(this.cmbStudentStatus);
            this.groupBox1.Controls.Add(this.label82);
            this.groupBox1.Controls.Add(this.txtFullNameLineTwo);
            this.groupBox1.Controls.Add(this.txtFullNameLineOne);
            this.groupBox1.Controls.Add(this.txtStudentNo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new Point(8, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(0x227, 0x87);
            this.groupBox1.TabIndex = 0xd1;
            this.groupBox1.TabStop = false;
            this.dtpDateOfActCancel.Format = DateTimePickerFormat.Short;
            this.dtpDateOfActCancel.Location = new Point(0x1be, 0x56);
            this.dtpDateOfActCancel.Name = "dtpDateOfActCancel";
            this.dtpDateOfActCancel.Size = new Size(0x66, 20);
            this.dtpDateOfActCancel.TabIndex = 0xda;
            this.label94.AutoSize = true;
            this.label94.Location = new Point(0x13b, 90);
            this.label94.Name = "label94";
            this.label94.Size = new Size(0x7d, 13);
            this.label94.TabIndex = 0xdb;
            this.label94.Text = "Date of Active / Cancel :";
            this.cmbStudentStatus.DrawMode = DrawMode.OwnerDrawVariable;
            this.cmbStudentStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbStudentStatus.DropDownWidth = 0x11;
            this.cmbStudentStatus.FormattingEnabled = true;
            this.cmbStudentStatus.Location = new Point(0x71, 0x53);
            this.cmbStudentStatus.Name = "cmbStudentStatus";
            this.cmbStudentStatus.Size = new Size(0xa3, 0x15);
            this.cmbStudentStatus.TabIndex = 0xd7;
            this.cmbStudentStatus.ViewColumn = 0;
            this.label82.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label82.Location = new Point(6, 0x53);
            this.label82.Name = "label82";
            this.label82.Size = new Size(0x70, 0x13);
            this.label82.TabIndex = 0xd8;
            this.label82.Text = "Status";
            this.label82.TextAlign = ContentAlignment.MiddleLeft;
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
            this.label2.Size = new Size(0x40, 13);
            this.label2.TabIndex = 0xd6;
            this.label2.Text = "Student No:";
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
            this.panel1.Location = new Point(8, 0x99);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(0x227, 0x23);
            this.panel1.TabIndex = 210;
            this.btnView.Location = new Point(0x52, 6);
            this.btnView.Name = "btnView";
            this.btnView.Size = new Size(0x49, 0x17);
            this.btnView.TabIndex = 0x24;
            this.btnView.Text = "&View";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new EventHandler(this.btnView_Click);
            this.btnRefresh.Location = new Point(0xa1, 6);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new Size(0x49, 0x17);
            this.btnRefresh.TabIndex = 0x20;
            this.btnRefresh.Text = "Re&fresh";
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
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x233, 200);
            base.Controls.Add(this.panel1);
            base.Controls.Add(this.groupBox1);
            base.Name = "frmActiveCancalHistory";
            this.Text = "Pool Attendance System";
            base.Load += new EventHandler(this.frmActiveCancalHistory_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            base.ResumeLayout(false);
        }

        private void LoadCombos()
        {
            DataTable statusDetails = this.cStatusMaster.GetStatusDetails();
            this.cCommenMethods.LoadCombo(statusDetails, this.cmbStudentStatus, 1);
        }

        private void LoadStudent()
        {
            this.oStudentMaster = this.cStudentMaster.GetStudentData(this.cGlobleVariable.LocationCode, this.txtStudentNo.Text.ToString());
            if (this.oStudentMaster.IsExistStudent)
            {
                this.txtStudentNo.Text = this.oStudentMaster.StudentNo;
                this.txtFullNameLineOne.Text = this.oStudentMaster.NameInFullL1;
                this.txtFullNameLineTwo.Text = this.oStudentMaster.NameInFullL2;
                this.cmbStudentStatus.SetText(this.cStatusMaster.GetStatusByCode(this.oStudentMaster.Status).StatusName);
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

