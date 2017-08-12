namespace Pool_Application
{
    using Business_Layer;
    using Business_Layer.Property_Layer;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.IO;
    using System.Windows.Forms;

    public class frmBeadBarcode : Form
    {
        public Button btnRefresh;
        public Button btnSave;
        private clsAuditLog cAuditLog = new clsAuditLog();
        private clsBeadBarcode cBeadBarcode = new clsBeadBarcode();
        private clsClassMaster cClassMaster = new clsClassMaster();
        private clsClassTimeTable cClassTimeTable = new clsClassTimeTable();
        private clsCoacherMaster cCoacherMaster = new clsCoacherMaster();
        private clsCommenMethods cCommanMethods = new clsCommenMethods();
        private clsConfirmStudentAttendance cConfirmStudentAttendance = new clsConfirmStudentAttendance();
        private clsGlobleVariable cGlobleVariable = new clsGlobleVariable();
        private clsInvoice cInvoice = new clsInvoice();
        private IContainer components = null;
        private clsStudentMaster cStudentMaster = new clsStudentMaster();
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label7;
        private Label label9;
        private Label lblClass;
        private Label lblCoacher;
        private Label lblDate;
        private Label lblLastPaymentMonth;
        private Label lblTime;
        private objAuditLog oAuditLog = new objAuditLog();
        private objBeadBarcode oBeadBarcode = new objBeadBarcode();
        private objConfirmStudentAttendance oConfirmStudentAttendance = new objConfirmStudentAttendance();
        private objStudentMaster oStudentMaster = new objStudentMaster();
        private PictureBox ptbPhotograph;
        private Timer timer1;
        private TextBox txtPINNumber;
        private TextBox txtStudentName;

        public frmBeadBarcode()
        {
            this.InitializeComponent();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.cCommanMethods.ClearForm(this);
            this.txtPINNumber.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string str = string.Empty;
            str = this.txtPINNumber.Text.Trim();
            if (str.Length == 6)
            {
                this.oStudentMaster = this.cStudentMaster.GetStudentData(this.cGlobleVariable.LocationCode, str.ToString());
                if (this.oStudentMaster.IsExistStudent)
                {
                    if (this.ValidClassDay())
                    {
                        this.oBeadBarcode.LocationCode = this.cGlobleVariable.LocationCode;
                        this.oBeadBarcode.StudentNo = str.ToString();
                        this.oBeadBarcode.LogDate = Convert.ToDateTime(this.lblDate.Text);
                        this.oBeadBarcode.LogTime = Convert.ToDateTime(this.lblTime.Text);
                        this.cBeadBarcode.InsertUpdate(this.oBeadBarcode);
                        MessageBox.Show("Attendance Marked Successfully!", "Attendance Mark", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        this.btnRefresh.Focus();
                    }
                    else
                    {
                        this.oConfirmStudentAttendance = this.cConfirmStudentAttendance.GetAttendanceDetails(this.cGlobleVariable.LocationCode, this.oStudentMaster.StudentNo, Convert.ToDateTime(this.lblDate.Text));
                        if (this.oConfirmStudentAttendance.IsConfirmAttendance)
                        {
                            this.lblCoacher.Text = this.cCoacherMaster.GetCoacherData(this.cGlobleVariable.LocationCode, "").FullNameLineOne;
                            this.oBeadBarcode.LocationCode = this.cGlobleVariable.LocationCode;
                            this.oBeadBarcode.StudentNo = str.ToString();
                            this.oBeadBarcode.LogDate = Convert.ToDateTime(this.lblDate.Text);
                            this.oBeadBarcode.LogTime = Convert.ToDateTime(this.lblTime.Text);
                            this.cBeadBarcode.InsertUpdate(this.oBeadBarcode);
                            MessageBox.Show("Attendance Marked Successfully!", "Attendance Mark", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            this.btnRefresh.Focus();
                        }
                        else
                        {
                            MessageBox.Show("Student is not allow to Class.........", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            this.btnRefresh.Focus();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Student Not Found.........", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    this.btnRefresh.Focus();
                }
            }
            this.cCommanMethods.ClearForm(this);
            this.txtPINNumber.Focus();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void frmBeadBarcode_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.oAuditLog.LocationCode = this.cGlobleVariable.LocationCode;
            this.oAuditLog.UserID = this.cGlobleVariable.CurrentUserID;
            this.oAuditLog.MachineID = clsGlobleVariable.MachineID;
            this.oAuditLog.DateEntered = Convert.ToDateTime(this.cAuditLog.getCurrentDate().Rows[0][0].ToString());
            this.oAuditLog.TimeEntered = Convert.ToDateTime(this.cAuditLog.getCurrentTime().Rows[0][0].ToString());
            this.oAuditLog.Task = "Exited Student Attendance Entry ";
            this.cAuditLog.AuditLog(this.oAuditLog);
        }

        private void frmBeadBarcode_Load(object sender, EventArgs e)
        {
            this.oAuditLog.LocationCode = this.cGlobleVariable.LocationCode;
            this.oAuditLog.UserID = this.cGlobleVariable.CurrentUserID;
            this.oAuditLog.MachineID = clsGlobleVariable.MachineID;
            this.oAuditLog.DateEntered = Convert.ToDateTime(this.cAuditLog.getCurrentDate().Rows[0][0].ToString());
            this.oAuditLog.TimeEntered = Convert.ToDateTime(this.cAuditLog.getCurrentTime().Rows[0][0].ToString());
            this.oAuditLog.Task = "Entered Student Attendance Entry ";
            this.cAuditLog.AuditLog(this.oAuditLog);
        }

        private string GetLastPaymentMonth()
        {
            DataTable lastInvoiceDetails = this.cInvoice.GetLastInvoiceDetails(this.cGlobleVariable.LocationCode, this.txtPINNumber.Text.ToString());
            string str = "";
            if (lastInvoiceDetails.Rows.Count > 0)
            {
                str = "Last Payment Date : ";
                string str3 = str + Convert.ToDateTime(lastInvoiceDetails.Rows[0][6].ToString()).ToString("MMMM-yyyy");
                str = str3 + " Invoice Date : " + Convert.ToDateTime(lastInvoiceDetails.Rows[0][4].ToString()).ToString("dd-MM-yyyy") + "\nInvoice No: " + lastInvoiceDetails.Rows[0]["fldInvoiceNo"].ToString();
            }
            return str;
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            ComponentResourceManager manager = new ComponentResourceManager(typeof(frmBeadBarcode));
            this.txtPINNumber = new TextBox();
            this.label9 = new Label();
            this.label1 = new Label();
            this.txtStudentName = new TextBox();
            this.label2 = new Label();
            this.lblDate = new Label();
            this.lblTime = new Label();
            this.label5 = new Label();
            this.timer1 = new Timer(this.components);
            this.ptbPhotograph = new PictureBox();
            this.lblClass = new Label();
            this.label4 = new Label();
            this.lblCoacher = new Label();
            this.label7 = new Label();
            this.btnRefresh = new Button();
            this.label3 = new Label();
            this.lblLastPaymentMonth = new Label();
            this.btnSave = new Button();
            ((ISupportInitialize) this.ptbPhotograph).BeginInit();
            base.SuspendLayout();
            this.txtPINNumber.BackColor = Color.White;
            this.txtPINNumber.Location = new Point(0x71, 12);
            this.txtPINNumber.MaxLength = 10;
            this.txtPINNumber.Name = "txtPINNumber";
            this.txtPINNumber.Size = new Size(0x9b, 20);
            this.txtPINNumber.TabIndex = 1;
            this.txtPINNumber.TextChanged += new EventHandler(this.txtPINNumber_TextChanged);
            this.label9.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label9.ForeColor = SystemColors.Highlight;
            this.label9.Location = new Point(14, 13);
            this.label9.Name = "label9";
            this.label9.Size = new Size(0x5d, 0x13);
            this.label9.TabIndex = 0x1b;
            this.label9.Text = "Barcode Number";
            this.label9.TextAlign = ContentAlignment.MiddleLeft;
            this.label1.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label1.ForeColor = SystemColors.Highlight;
            this.label1.Location = new Point(14, 0x27);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x5d, 0x13);
            this.label1.TabIndex = 0x1d;
            this.label1.Text = "Student No";
            this.label1.TextAlign = ContentAlignment.MiddleLeft;
            this.txtStudentName.BackColor = Color.White;
            this.txtStudentName.Location = new Point(0x71, 0x26);
            this.txtStudentName.MaxLength = 10;
            this.txtStudentName.Name = "txtStudentName";
            this.txtStudentName.Size = new Size(0x14f, 20);
            this.txtStudentName.TabIndex = 0x1c;
            this.label2.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label2.ForeColor = SystemColors.Highlight;
            this.label2.Location = new Point(14, 0x45);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x5d, 0x13);
            this.label2.TabIndex = 30;
            this.label2.Text = "Date";
            this.label2.TextAlign = ContentAlignment.MiddleLeft;
            this.lblDate.BorderStyle = BorderStyle.Fixed3D;
            this.lblDate.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.lblDate.ForeColor = SystemColors.Highlight;
            this.lblDate.Location = new Point(0x71, 0x45);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new Size(0x9b, 0x13);
            this.lblDate.TabIndex = 0x1f;
            this.lblDate.Text = "Date";
            this.lblDate.TextAlign = ContentAlignment.MiddleLeft;
            this.lblTime.BorderStyle = BorderStyle.Fixed3D;
            this.lblTime.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.lblTime.ForeColor = SystemColors.Highlight;
            this.lblTime.Location = new Point(0x70, 0x61);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new Size(0x9b, 0x13);
            this.lblTime.TabIndex = 0x21;
            this.lblTime.Text = "Date";
            this.lblTime.TextAlign = ContentAlignment.MiddleLeft;
            this.label5.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label5.ForeColor = SystemColors.Highlight;
            this.label5.Location = new Point(14, 0x61);
            this.label5.Name = "label5";
            this.label5.Size = new Size(0x5d, 0x13);
            this.label5.TabIndex = 0x20;
            this.label5.Text = "Time";
            this.label5.TextAlign = ContentAlignment.MiddleLeft;
            this.timer1.Enabled = true;
            this.timer1.Tick += new EventHandler(this.timer1_Tick);
            this.ptbPhotograph.BackgroundImageLayout = ImageLayout.Stretch;
            this.ptbPhotograph.BorderStyle = BorderStyle.Fixed3D;
            this.ptbPhotograph.Image = (Image) manager.GetObject("ptbPhotograph.Image");
            this.ptbPhotograph.InitialImage = null;
            this.ptbPhotograph.Location = new Point(0x14f, 0x45);
            this.ptbPhotograph.Name = "ptbPhotograph";
            this.ptbPhotograph.Size = new Size(0x71, 0x69);
            this.ptbPhotograph.SizeMode = PictureBoxSizeMode.StretchImage;
            this.ptbPhotograph.TabIndex = 170;
            this.ptbPhotograph.TabStop = false;
            this.ptbPhotograph.Tag = "operator_128.jpg";
            this.lblClass.BorderStyle = BorderStyle.Fixed3D;
            this.lblClass.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.lblClass.ForeColor = SystemColors.Highlight;
            this.lblClass.Location = new Point(0x70, 0x7e);
            this.lblClass.Name = "lblClass";
            this.lblClass.Size = new Size(0xd9, 0x13);
            this.lblClass.TabIndex = 0xac;
            this.lblClass.Text = "None";
            this.lblClass.TextAlign = ContentAlignment.MiddleLeft;
            this.label4.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label4.ForeColor = SystemColors.Highlight;
            this.label4.Location = new Point(14, 0x7e);
            this.label4.Name = "label4";
            this.label4.Size = new Size(0x5d, 0x13);
            this.label4.TabIndex = 0xab;
            this.label4.Text = "Class";
            this.label4.TextAlign = ContentAlignment.MiddleLeft;
            this.lblCoacher.BorderStyle = BorderStyle.Fixed3D;
            this.lblCoacher.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.lblCoacher.ForeColor = SystemColors.Highlight;
            this.lblCoacher.Location = new Point(0x70, 0x9b);
            this.lblCoacher.Name = "lblCoacher";
            this.lblCoacher.Size = new Size(0xd9, 0x13);
            this.lblCoacher.TabIndex = 0xae;
            this.lblCoacher.Text = "None";
            this.lblCoacher.TextAlign = ContentAlignment.MiddleLeft;
            this.label7.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label7.ForeColor = SystemColors.Highlight;
            this.label7.Location = new Point(14, 0x9b);
            this.label7.Name = "label7";
            this.label7.Size = new Size(0x5d, 0x13);
            this.label7.TabIndex = 0xad;
            this.label7.Text = "Coacher";
            this.label7.TextAlign = ContentAlignment.MiddleLeft;
            this.btnRefresh.Location = new Point(0x178, 0xc7);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new Size(0x49, 0x17);
            this.btnRefresh.TabIndex = 0xaf;
            this.btnRefresh.Text = "&Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new EventHandler(this.btnRefresh_Click);
            this.label3.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label3.ForeColor = SystemColors.Highlight;
            this.label3.Location = new Point(12, 13);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x5d, 0x13);
            this.label3.TabIndex = 0x1b;
            this.label3.Text = "Barcode Number";
            this.label3.TextAlign = ContentAlignment.MiddleLeft;
            this.lblLastPaymentMonth.AutoSize = true;
            this.lblLastPaymentMonth.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.lblLastPaymentMonth.ForeColor = Color.Red;
            this.lblLastPaymentMonth.Location = new Point(0x15, 0xb9);
            this.lblLastPaymentMonth.Name = "lblLastPaymentMonth";
            this.lblLastPaymentMonth.Size = new Size(0, 13);
            this.lblLastPaymentMonth.TabIndex = 0xf6;
            this.btnSave.Location = new Point(290, 0xc7);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new Size(0x47, 0x17);
            this.btnSave.TabIndex = 0xf7;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new EventHandler(this.btnSave_Click);
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x1c5, 0xe4);
            base.Controls.Add(this.btnSave);
            base.Controls.Add(this.lblLastPaymentMonth);
            base.Controls.Add(this.btnRefresh);
            base.Controls.Add(this.lblCoacher);
            base.Controls.Add(this.label7);
            base.Controls.Add(this.lblClass);
            base.Controls.Add(this.label4);
            base.Controls.Add(this.ptbPhotograph);
            base.Controls.Add(this.lblTime);
            base.Controls.Add(this.label5);
            base.Controls.Add(this.lblDate);
            base.Controls.Add(this.label2);
            base.Controls.Add(this.label1);
            base.Controls.Add(this.txtStudentName);
            base.Controls.Add(this.label3);
            base.Controls.Add(this.label9);
            base.Controls.Add(this.txtPINNumber);
            base.Name = "frmBeadBarcode";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Pool Attendance System";
            base.FormClosed += new FormClosedEventHandler(this.frmBeadBarcode_FormClosed);
            base.Load += new EventHandler(this.frmBeadBarcode_Load);
            ((ISupportInitialize) this.ptbPhotograph).EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        private void PhotoIsExist(string strPhotoFilePath)
        {
            if (File.Exists(this.cGlobleVariable.strImagePath + @"\" + strPhotoFilePath))
            {
                this.ptbPhotograph.Load(this.cGlobleVariable.strImagePath + @"\" + strPhotoFilePath);
                this.ptbPhotograph.Tag = strPhotoFilePath;
            }
            else
            {
                this.ptbPhotograph.Image = null;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.lblTime.Text = DateTime.Now.ToShortTimeString();
            this.lblDate.Text = DateTime.Now.ToShortDateString();
        }

        private void txtPINNumber_TextChanged(object sender, EventArgs e)
        {
            string str = string.Empty;
            this.txtStudentName.Text = string.Empty;
            this.txtStudentName.Tag = string.Empty;
            this.lblClass.Text = string.Empty;
            this.lblCoacher.Text = string.Empty;
            str = this.txtPINNumber.Text.Trim();
            if (str.Length == 6)
            {
                this.oStudentMaster = this.cStudentMaster.GetStudentData(this.cGlobleVariable.LocationCode, str.ToString());
                if (this.oStudentMaster.IsExistStudent)
                {
                    this.txtStudentName.Tag = this.oStudentMaster.StudentNo;
                    this.txtStudentName.Text = this.oStudentMaster.NameInFullL1;
                    this.PhotoIsExist(this.oStudentMaster.Photograph);
                    this.lblClass.Tag = this.cClassMaster.GetClassData(this.cGlobleVariable.LocationCode, this.oStudentMaster.Level).ClassCode;
                    this.lblClass.Text = this.cClassMaster.GetClassData(this.cGlobleVariable.LocationCode, this.oStudentMaster.Level).ClassName;
                    this.lblLastPaymentMonth.Text = this.GetLastPaymentMonth();
                    this.btnSave.Focus();
                }
                else
                {
                    MessageBox.Show("Student Not Found.........", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    this.btnRefresh.Focus();
                }
            }
        }

        private bool ValidClassDay()
        {
            bool flag = false;
            if (this.cClassTimeTable.GetStudentClassDetails(this.cGlobleVariable.LocationCode, this.oStudentMaster.StudentNo, Convert.ToString(this.lblClass.Tag), DateTime.Today.DayOfWeek.ToString()).Rows.Count > 0)
            {
                flag = true;
            }
            return flag;
        }
    }
}

