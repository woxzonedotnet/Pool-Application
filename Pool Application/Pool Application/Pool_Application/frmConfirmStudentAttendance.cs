namespace Pool_Application
{
    using Business_Layer;
    using Business_Layer.Property_Layer;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;

    public class frmConfirmStudentAttendance : Form
    {
        public Button btnCancel;
        public Button btnExit;
        public Button btnRefresh;
        public Button btnSave;
        public Button btnView;
        private clsAttendanceProcess cAttendanceProcess = new clsAttendanceProcess();
        private clsAuditLog cAuditLog = new clsAuditLog();
        private clsClassMaster cClassMaster = new clsClassMaster();
        private clsClassTimeTable cClassTimeTable = new clsClassTimeTable();
        private clsCoacherMaster cCoacherMaster = new clsCoacherMaster();
        private clsCommenMethods cCommanMethods = new clsCommenMethods();
        private clsConfirmStudentAttendance cConfirmStudentAttendance = new clsConfirmStudentAttendance();
        private clsGlobleVariable cGlobleVariable = new clsGlobleVariable();
        private DataGridViewTextBoxColumn clmEmpName;
        private DataGridViewTextBoxColumn clmNumber;
        private ComboBox cmbAbsebtDates;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column7;
        private DataGridViewTextBoxColumn Column8;
        private IContainer components = null;
        private clsStatusMaster cStatusMaster = new clsStatusMaster();
        private clsStudentClassTimes cStudentClassTimes = new clsStudentClassTimes();
        private clsStudentMaster cStudentMaster = new clsStudentMaster();
        private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private DataGridView dgAttendanceDates;
        private DataGridView dgvClassTimeDTL;
        private DateTimePicker dtpDateOfConfirm;
        private ErrorProvider err1;
        private GroupBox groupBox1;
        private int iRowIndex = 0;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label5;
        private Label label94;
        private DataGridView lstRegularEmployee;
        private objAuditLog oAuditLog = new objAuditLog();
        private objClassMaster oClassMaster = new objClassMaster();
        private objConfirmStudentAttendance oConfirmStudentAttendance = new objConfirmStudentAttendance();
        private objStudentMaster oStudentMaster = new objStudentMaster();
        private Panel panel1;
        private TextBox txtFullNameLineOne;
        private TextBox txtFullNameLineTwo;
        private TextBox txtLevel;
        private TextBox txtStudentNo;

        public frmConfirmStudentAttendance()
        {
            this.InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to cancel this?", "Delete Data", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.cConfirmStudentAttendance.CancelEntry(this.cGlobleVariable.LocationCode, this.txtStudentNo.Text, this.dtpDateOfConfirm.Value);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.oAuditLog.LocationCode = this.cGlobleVariable.LocationCode;
            this.oAuditLog.UserID = this.cGlobleVariable.CurrentUserID;
            this.oAuditLog.MachineID = clsGlobleVariable.MachineID;
            this.oAuditLog.DateEntered = Convert.ToDateTime(this.cAuditLog.getCurrentDate().Rows[0][0].ToString());
            this.oAuditLog.TimeEntered = Convert.ToDateTime(this.cAuditLog.getCurrentTime().Rows[0][0].ToString());
            this.oAuditLog.Task = "Exited Confirmed Student Attendance";
            this.cAuditLog.AuditLog(this.oAuditLog);
            base.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.cCommanMethods.ClearForm(this);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.ValidateData() && ((this.txtStudentNo.Text != string.Empty) && (this.txtFullNameLineOne.Text != string.Empty)))
            {
                this.oConfirmStudentAttendance.LocationCode = this.cGlobleVariable.LocationCode;
                this.oConfirmStudentAttendance.StudentNo = this.txtStudentNo.Text;
                this.oConfirmStudentAttendance.AttendanceDate = this.dtpDateOfConfirm.Value;
                this.oConfirmStudentAttendance.ClassCode = this.txtLevel.Tag.ToString();
                if (this.cmbAbsebtDates.Text != "None")
                {
                    this.oConfirmStudentAttendance.AbsentDate = Convert.ToDateTime(this.cmbAbsebtDates.Text);
                }
                for (int i = 0; i < this.dgvClassTimeDTL.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(this.dgvClassTimeDTL.Rows[i].Cells[0].Value))
                    {
                        this.oConfirmStudentAttendance.ClassTimeCode = Convert.ToString(this.dgvClassTimeDTL.Rows[i].Cells[1].Value);
                        break;
                    }
                }
                this.cConfirmStudentAttendance.InsertUpdateData(this.oConfirmStudentAttendance);
                this.oAuditLog.LocationCode = this.cGlobleVariable.LocationCode;
                this.oAuditLog.UserID = this.cGlobleVariable.CurrentUserID;
                this.oAuditLog.MachineID = clsGlobleVariable.MachineID;
                this.oAuditLog.DateEntered = Convert.ToDateTime(this.cAuditLog.getCurrentDate().Rows[0][0].ToString());
                this.oAuditLog.TimeEntered = Convert.ToDateTime(this.cAuditLog.getCurrentTime().Rows[0][0].ToString());
                this.oAuditLog.Task = "Confirmed Student No: " + this.txtStudentNo.Text + " For Class on" + this.dtpDateOfConfirm.Value.ToString();
                this.cAuditLog.AuditLog(this.oAuditLog);
                MessageBox.Show(this.cGlobleVariable.SeavedMessage, "Student Master details", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            this.ViewEmployee();
            this.oAuditLog.LocationCode = this.cGlobleVariable.LocationCode;
            this.oAuditLog.UserID = this.cGlobleVariable.CurrentUserID;
            this.oAuditLog.MachineID = clsGlobleVariable.MachineID;
            this.oAuditLog.DateEntered = Convert.ToDateTime(this.cAuditLog.getCurrentDate().Rows[0][0].ToString());
            this.oAuditLog.TimeEntered = Convert.ToDateTime(this.cAuditLog.getCurrentTime().Rows[0][0].ToString());
            this.oAuditLog.Task = "Viewed Details of Student No: " + this.txtStudentNo.Text + " - Confirm Student Attendance";
            this.cAuditLog.AuditLog(this.oAuditLog);
        }

        private void dgClassTimes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.iRowIndex = e.RowIndex;
        }

        private void dgClassTimes_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            this.iRowIndex = e.RowIndex;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void dtpDateOfConfirm_CloseUp(object sender, EventArgs e)
        {
            this.oConfirmStudentAttendance = this.cConfirmStudentAttendance.GetAttendanceDetails(this.cGlobleVariable.LocationCode, this.txtStudentNo.Text, this.dtpDateOfConfirm.Value);
            if (this.oConfirmStudentAttendance.IsConfirmAttendance)
            {
                if (MessageBox.Show("Attendance Details alredy exist do you want to cancel this?", "Delete Data", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.cConfirmStudentAttendance.CancelEntry(this.cGlobleVariable.LocationCode, this.txtStudentNo.Text, this.dtpDateOfConfirm.Value);
                }
                this.cCommanMethods.ClearForm(this);
            }
            else
            {
                this.LoadClass(this.cGlobleVariable.LocationCode, this.txtLevel.Tag.ToString(), this.dtpDateOfConfirm.Value);
            }
        }

        private void dtpDateOfConfirm_ValueChanged(object sender, EventArgs e)
        {
        }

        private void frmConfirmStudentAttendance_Load(object sender, EventArgs e)
        {
        }

        private void InitializeComponent()
        {
            this.components = new Container();
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
            DataGridViewCellStyle style11 = new DataGridViewCellStyle();
            DataGridViewCellStyle style12 = new DataGridViewCellStyle();
            DataGridViewCellStyle style13 = new DataGridViewCellStyle();
            DataGridViewCellStyle style14 = new DataGridViewCellStyle();
            DataGridViewCellStyle style15 = new DataGridViewCellStyle();
            DataGridViewCellStyle style16 = new DataGridViewCellStyle();
            DataGridViewCellStyle style17 = new DataGridViewCellStyle();
            DataGridViewCellStyle style18 = new DataGridViewCellStyle();
            DataGridViewCellStyle style19 = new DataGridViewCellStyle();
            DataGridViewCellStyle style20 = new DataGridViewCellStyle();
            DataGridViewCellStyle style21 = new DataGridViewCellStyle();
            DataGridViewCellStyle style22 = new DataGridViewCellStyle();
            this.panel1 = new Panel();
            this.btnCancel = new Button();
            this.btnView = new Button();
            this.btnRefresh = new Button();
            this.btnSave = new Button();
            this.btnExit = new Button();
            this.groupBox1 = new GroupBox();
            this.cmbAbsebtDates = new ComboBox();
            this.label1 = new Label();
            this.dgvClassTimeDTL = new DataGridView();
            this.dataGridViewCheckBoxColumn2 = new DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn13 = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new DataGridViewTextBoxColumn();
            this.Column8 = new DataGridViewTextBoxColumn();
            this.dgAttendanceDates = new DataGridView();
            this.Column7 = new DataGridViewTextBoxColumn();
            this.lstRegularEmployee = new DataGridView();
            this.clmNumber = new DataGridViewTextBoxColumn();
            this.Column1 = new DataGridViewTextBoxColumn();
            this.clmEmpName = new DataGridViewTextBoxColumn();
            this.label3 = new Label();
            this.txtLevel = new TextBox();
            this.dtpDateOfConfirm = new DateTimePicker();
            this.label94 = new Label();
            this.txtFullNameLineTwo = new TextBox();
            this.txtFullNameLineOne = new TextBox();
            this.txtStudentNo = new TextBox();
            this.label2 = new Label();
            this.label5 = new Label();
            this.dataGridViewCheckBoxColumn1 = new DataGridViewCheckBoxColumn();
            this.err1 = new ErrorProvider(this.components);
            this.dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((ISupportInitialize) this.dgvClassTimeDTL).BeginInit();
            ((ISupportInitialize) this.dgAttendanceDates).BeginInit();
            ((ISupportInitialize) this.lstRegularEmployee).BeginInit();
            ((ISupportInitialize) this.err1).BeginInit();
            base.SuspendLayout();
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnView);
            this.panel1.Controls.Add(this.btnRefresh);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Location = new Point(7, 0x195);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(0x20e, 0x2c);
            this.panel1.TabIndex = 0xd4;
            this.btnCancel.Location = new Point(0xf1, 10);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new Size(0x49, 0x17);
            this.btnCancel.TabIndex = 0x25;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new EventHandler(this.btnCancel_Click);
            this.btnView.Location = new Point(0x53, 10);
            this.btnView.Name = "btnView";
            this.btnView.Size = new Size(0x49, 0x17);
            this.btnView.TabIndex = 0x24;
            this.btnView.Text = "&View";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new EventHandler(this.btnView_Click);
            this.btnRefresh.Location = new Point(0xa2, 10);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new Size(0x49, 0x17);
            this.btnRefresh.TabIndex = 0x20;
            this.btnRefresh.Text = "&Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new EventHandler(this.btnRefresh_Click);
            this.btnSave.Location = new Point(4, 10);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new Size(0x49, 0x17);
            this.btnSave.TabIndex = 0x15;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new EventHandler(this.btnSave_Click);
            this.btnExit.FlatAppearance.BorderColor = Color.FromArgb(0x40, 0x40, 0x40);
            this.btnExit.FlatAppearance.BorderSize = 5;
            this.btnExit.Location = new Point(0x1aa, 10);
            this.btnExit.Margin = new Padding(0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new Size(0x53, 0x17);
            this.btnExit.TabIndex = 0x23;
            this.btnExit.Text = "E&xit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new EventHandler(this.btnExit_Click);
            this.groupBox1.Controls.Add(this.cmbAbsebtDates);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dgvClassTimeDTL);
            this.groupBox1.Controls.Add(this.dgAttendanceDates);
            this.groupBox1.Controls.Add(this.lstRegularEmployee);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtLevel);
            this.groupBox1.Controls.Add(this.dtpDateOfConfirm);
            this.groupBox1.Controls.Add(this.label94);
            this.groupBox1.Controls.Add(this.txtFullNameLineTwo);
            this.groupBox1.Controls.Add(this.txtFullNameLineOne);
            this.groupBox1.Controls.Add(this.txtStudentNo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new Point(8, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(0x20d, 0x18c);
            this.groupBox1.TabIndex = 0xd3;
            this.groupBox1.TabStop = false;
            this.cmbAbsebtDates.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbAbsebtDates.FormattingEnabled = true;
            this.cmbAbsebtDates.Location = new Point(0x100, 0xd0);
            this.cmbAbsebtDates.Name = "cmbAbsebtDates";
            this.cmbAbsebtDates.Size = new Size(0x66, 0x15);
            this.cmbAbsebtDates.TabIndex = 0xeb;
            this.label1.AutoSize = true;
            this.label1.Location = new Point(120, 0xd3);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x51, 13);
            this.label1.TabIndex = 0xea;
            this.label1.Text = "Date of Absent:";
            this.dgvClassTimeDTL.AllowUserToAddRows = false;
            this.dgvClassTimeDTL.AllowUserToDeleteRows = false;
            this.dgvClassTimeDTL.AllowUserToResizeColumns = false;
            this.dgvClassTimeDTL.AllowUserToResizeRows = false;
            this.dgvClassTimeDTL.BackgroundColor = SystemColors.ControlLightLight;
            style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            style.BackColor = SystemColors.Control;
            style.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            style.ForeColor = SystemColors.WindowText;
            style.SelectionBackColor = SystemColors.Highlight;
            style.SelectionForeColor = SystemColors.HighlightText;
            style.WrapMode = DataGridViewTriState.True;
            this.dgvClassTimeDTL.ColumnHeadersDefaultCellStyle = style;
            this.dgvClassTimeDTL.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClassTimeDTL.Columns.AddRange(new DataGridViewColumn[] { this.dataGridViewCheckBoxColumn2, this.dataGridViewTextBoxColumn13, this.dataGridViewTextBoxColumn14, this.Column8 });
            this.dgvClassTimeDTL.Location = new Point(120, 260);
            this.dgvClassTimeDTL.Name = "dgvClassTimeDTL";
            this.dgvClassTimeDTL.RowHeadersVisible = false;
            this.dgvClassTimeDTL.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvClassTimeDTL.Size = new Size(0x16f, 130);
            this.dgvClassTimeDTL.TabIndex = 0xe8;
            style2.Alignment = DataGridViewContentAlignment.TopLeft;
            style2.NullValue = false;
            this.dataGridViewCheckBoxColumn2.DefaultCellStyle = style2;
            this.dataGridViewCheckBoxColumn2.HeaderText = "";
            this.dataGridViewCheckBoxColumn2.Name = "dataGridViewCheckBoxColumn2";
            this.dataGridViewCheckBoxColumn2.Width = 0x19;
            style3.Alignment = DataGridViewContentAlignment.TopLeft;
            this.dataGridViewTextBoxColumn13.DefaultCellStyle = style3;
            this.dataGridViewTextBoxColumn13.HeaderText = "Number";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.ReadOnly = true;
            this.dataGridViewTextBoxColumn13.Visible = false;
            this.dataGridViewTextBoxColumn13.Width = 70;
            style4.Alignment = DataGridViewContentAlignment.TopLeft;
            this.dataGridViewTextBoxColumn14.DefaultCellStyle = style4;
            this.dataGridViewTextBoxColumn14.HeaderText = "Class Times";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.ReadOnly = true;
            this.dataGridViewTextBoxColumn14.Width = 0xeb;
            style5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.Column8.DefaultCellStyle = style5;
            this.Column8.HeaderText = "Availability";
            this.Column8.Name = "Column8";
            this.dgAttendanceDates.AllowUserToAddRows = false;
            this.dgAttendanceDates.AllowUserToDeleteRows = false;
            this.dgAttendanceDates.AllowUserToResizeColumns = false;
            this.dgAttendanceDates.AllowUserToResizeRows = false;
            this.dgAttendanceDates.BackgroundColor = SystemColors.ControlLightLight;
            style6.Alignment = DataGridViewContentAlignment.MiddleCenter;
            style6.BackColor = SystemColors.Control;
            style6.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            style6.ForeColor = SystemColors.WindowText;
            style6.SelectionBackColor = SystemColors.Highlight;
            style6.SelectionForeColor = SystemColors.HighlightText;
            style6.WrapMode = DataGridViewTriState.True;
            this.dgAttendanceDates.ColumnHeadersDefaultCellStyle = style6;
            this.dgAttendanceDates.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgAttendanceDates.Columns.AddRange(new DataGridViewColumn[] { this.Column7 });
            this.dgAttendanceDates.Location = new Point(9, 0x6d);
            this.dgAttendanceDates.MultiSelect = false;
            this.dgAttendanceDates.Name = "dgAttendanceDates";
            this.dgAttendanceDates.ReadOnly = true;
            this.dgAttendanceDates.RowHeadersVisible = false;
            style7.ForeColor = Color.Black;
            style7.SelectionBackColor = SystemColors.Highlight;
            style7.SelectionForeColor = Color.Black;
            this.dgAttendanceDates.RowsDefaultCellStyle = style7;
            this.dgAttendanceDates.RowTemplate.DefaultCellStyle.SelectionBackColor = Color.White;
            this.dgAttendanceDates.RowTemplate.DefaultCellStyle.SelectionForeColor = Color.Black;
            this.dgAttendanceDates.SelectionMode = DataGridViewSelectionMode.CellSelect;
            this.dgAttendanceDates.Size = new Size(0x69, 0x119);
            this.dgAttendanceDates.TabIndex = 0xe7;
            this.Column7.HeaderText = "Absebt Dates";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.lstRegularEmployee.AllowUserToAddRows = false;
            this.lstRegularEmployee.AllowUserToDeleteRows = false;
            this.lstRegularEmployee.AllowUserToResizeColumns = false;
            this.lstRegularEmployee.AllowUserToResizeRows = false;
            this.lstRegularEmployee.BackgroundColor = SystemColors.ControlLightLight;
            style8.Alignment = DataGridViewContentAlignment.MiddleCenter;
            style8.BackColor = SystemColors.Control;
            style8.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            style8.ForeColor = SystemColors.WindowText;
            style8.SelectionBackColor = SystemColors.Highlight;
            style8.SelectionForeColor = SystemColors.HighlightText;
            style8.WrapMode = DataGridViewTriState.True;
            this.lstRegularEmployee.ColumnHeadersDefaultCellStyle = style8;
            this.lstRegularEmployee.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.lstRegularEmployee.Columns.AddRange(new DataGridViewColumn[] { this.clmNumber, this.Column1, this.clmEmpName });
            this.lstRegularEmployee.Location = new Point(120, 0x6d);
            this.lstRegularEmployee.Name = "lstRegularEmployee";
            this.lstRegularEmployee.RowHeadersVisible = false;
            style9.ForeColor = Color.Black;
            style9.SelectionBackColor = Color.White;
            style9.SelectionForeColor = Color.Black;
            this.lstRegularEmployee.RowsDefaultCellStyle = style9;
            this.lstRegularEmployee.Size = new Size(0xee, 0x5d);
            this.lstRegularEmployee.TabIndex = 230;
            style10.Alignment = DataGridViewContentAlignment.TopLeft;
            this.clmNumber.DefaultCellStyle = style10;
            this.clmNumber.HeaderText = "Number";
            this.clmNumber.Name = "clmNumber";
            this.clmNumber.ReadOnly = true;
            this.clmNumber.Visible = false;
            this.clmNumber.Width = 70;
            this.Column1.HeaderText = "Class Day";
            this.Column1.Name = "Column1";
            this.Column1.Width = 80;
            style11.Alignment = DataGridViewContentAlignment.TopLeft;
            this.clmEmpName.DefaultCellStyle = style11;
            this.clmEmpName.HeaderText = "Class Times";
            this.clmEmpName.Name = "clmEmpName";
            this.clmEmpName.ReadOnly = true;
            this.clmEmpName.Width = 0x9b;
            this.label3.AutoSize = true;
            this.label3.Location = new Point(6, 0x56);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x21, 13);
            this.label3.TabIndex = 0xe3;
            this.label3.Text = "Level";
            this.txtLevel.BackColor = Color.White;
            this.txtLevel.Location = new Point(120, 0x53);
            this.txtLevel.MaxLength = 100;
            this.txtLevel.Name = "txtLevel";
            this.txtLevel.ReadOnly = true;
            this.txtLevel.Size = new Size(0xee, 20);
            this.txtLevel.TabIndex = 0xe2;
            this.dtpDateOfConfirm.Format = DateTimePickerFormat.Short;
            this.dtpDateOfConfirm.Location = new Point(0x100, 0xea);
            this.dtpDateOfConfirm.Name = "dtpDateOfConfirm";
            this.dtpDateOfConfirm.Size = new Size(0x66, 20);
            this.dtpDateOfConfirm.TabIndex = 0xda;
            this.dtpDateOfConfirm.ValueChanged += new EventHandler(this.dtpDateOfConfirm_ValueChanged);
            this.dtpDateOfConfirm.CloseUp += new EventHandler(this.dtpDateOfConfirm_CloseUp);
            this.label94.AutoSize = true;
            this.label94.Location = new Point(120, 0xed);
            this.label94.Name = "label94";
            this.label94.Size = new Size(0x53, 13);
            this.label94.TabIndex = 0xdb;
            this.label94.Text = "Date of Confirm:";
            this.txtFullNameLineTwo.BackColor = Color.White;
            this.txtFullNameLineTwo.Location = new Point(120, 0x3a);
            this.txtFullNameLineTwo.MaxLength = 100;
            this.txtFullNameLineTwo.Name = "txtFullNameLineTwo";
            this.txtFullNameLineTwo.ReadOnly = true;
            this.txtFullNameLineTwo.Size = new Size(0x16f, 20);
            this.txtFullNameLineTwo.TabIndex = 0xd4;
            this.txtFullNameLineOne.BackColor = Color.White;
            this.txtFullNameLineOne.Location = new Point(120, 0x21);
            this.txtFullNameLineOne.MaxLength = 100;
            this.txtFullNameLineOne.Name = "txtFullNameLineOne";
            this.txtFullNameLineOne.ReadOnly = true;
            this.txtFullNameLineOne.Size = new Size(0x16f, 20);
            this.txtFullNameLineOne.TabIndex = 0xd3;
            this.txtStudentNo.BackColor = Color.White;
            this.txtStudentNo.Location = new Point(120, 10);
            this.txtStudentNo.MaxLength = 10;
            this.txtStudentNo.Name = "txtStudentNo";
            this.txtStudentNo.Size = new Size(0xc1, 20);
            this.txtStudentNo.TabIndex = 210;
            this.txtStudentNo.TextChanged += new EventHandler(this.txtStudentNo_TextChanged);
            this.label2.AutoSize = true;
            this.label2.Location = new Point(7, 15);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x40, 13);
            this.label2.TabIndex = 0xd6;
            this.label2.Text = "Student No:";
            this.label5.AutoSize = true;
            this.label5.Location = new Point(7, 40);
            this.label5.Name = "label5";
            this.label5.Size = new Size(0x47, 13);
            this.label5.TabIndex = 0xd5;
            this.label5.Text = "Name in Full :";
            style12.Alignment = DataGridViewContentAlignment.TopLeft;
            style12.NullValue = false;
            this.dataGridViewCheckBoxColumn1.DefaultCellStyle = style12;
            this.dataGridViewCheckBoxColumn1.HeaderText = "";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.Width = 0x19;
            this.err1.ContainerControl = this;
            style13.Alignment = DataGridViewContentAlignment.TopLeft;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = style13;
            this.dataGridViewTextBoxColumn1.HeaderText = "Column1";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            this.dataGridViewTextBoxColumn1.Width = 110;
            style14.Alignment = DataGridViewContentAlignment.TopLeft;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = style14;
            this.dataGridViewTextBoxColumn2.HeaderText = "Column2";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Visible = false;
            this.dataGridViewTextBoxColumn2.Width = 110;
            style15.Alignment = DataGridViewContentAlignment.TopLeft;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = style15;
            this.dataGridViewTextBoxColumn3.HeaderText = "Column3";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Visible = false;
            this.dataGridViewTextBoxColumn3.Width = 110;
            style16.Alignment = DataGridViewContentAlignment.TopLeft;
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = style16;
            this.dataGridViewTextBoxColumn4.HeaderText = "Column4";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Visible = false;
            this.dataGridViewTextBoxColumn4.Width = 110;
            style17.Alignment = DataGridViewContentAlignment.TopLeft;
            this.dataGridViewTextBoxColumn5.DefaultCellStyle = style17;
            this.dataGridViewTextBoxColumn5.HeaderText = "Column5";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Visible = false;
            this.dataGridViewTextBoxColumn5.Width = 110;
            style18.Alignment = DataGridViewContentAlignment.TopLeft;
            this.dataGridViewTextBoxColumn6.DefaultCellStyle = style18;
            this.dataGridViewTextBoxColumn6.HeaderText = "Column6";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Visible = false;
            this.dataGridViewTextBoxColumn6.Width = 110;
            style19.Alignment = DataGridViewContentAlignment.TopLeft;
            this.dataGridViewTextBoxColumn7.DefaultCellStyle = style19;
            this.dataGridViewTextBoxColumn7.HeaderText = "Column5";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Visible = false;
            this.dataGridViewTextBoxColumn7.Width = 110;
            this.dataGridViewTextBoxColumn8.HeaderText = "Column6";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Visible = false;
            this.dataGridViewTextBoxColumn8.Width = 110;
            this.dataGridViewTextBoxColumn9.HeaderText = "Column6";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Visible = false;
            this.dataGridViewTextBoxColumn9.Width = 110;
            style20.Alignment = DataGridViewContentAlignment.TopLeft;
            this.dataGridViewTextBoxColumn10.DefaultCellStyle = style20;
            this.dataGridViewTextBoxColumn10.HeaderText = "Student Dates";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.Visible = false;
            this.dataGridViewTextBoxColumn10.Width = 110;
            style21.Alignment = DataGridViewContentAlignment.TopLeft;
            this.dataGridViewTextBoxColumn11.DefaultCellStyle = style21;
            this.dataGridViewTextBoxColumn11.HeaderText = "Number";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            this.dataGridViewTextBoxColumn11.Visible = false;
            this.dataGridViewTextBoxColumn11.Width = 70;
            style22.Alignment = DataGridViewContentAlignment.TopLeft;
            this.dataGridViewTextBoxColumn12.DefaultCellStyle = style22;
            this.dataGridViewTextBoxColumn12.HeaderText = "Class Times";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            this.dataGridViewTextBoxColumn12.Visible = false;
            this.dataGridViewTextBoxColumn12.Width = 0x14f;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(540, 0x1c6);
            base.Controls.Add(this.panel1);
            base.Controls.Add(this.groupBox1);
            base.Name = "frmConfirmStudentAttendance";
            this.Text = "Pool Attendance System";
            base.Load += new EventHandler(this.frmConfirmStudentAttendance_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((ISupportInitialize) this.dgvClassTimeDTL).EndInit();
            ((ISupportInitialize) this.dgAttendanceDates).EndInit();
            ((ISupportInitialize) this.lstRegularEmployee).EndInit();
            ((ISupportInitialize) this.err1).EndInit();
            base.ResumeLayout(false);
        }

        private void LoadClass(string strStudentCode, string strLevel, DateTime dtDate)
        {
            string dayType = dtDate.DayOfWeek.ToString();
            DataTable table = this.cClassTimeTable.GetClassTimeDetails(this.cGlobleVariable.LocationCode, strLevel, dayType, this.cGlobleVariable.ActiveStatusCode);
            this.dgvClassTimeDTL.Rows.Clear();
            this.oClassMaster = this.cClassMaster.GetClassData(this.cGlobleVariable.LocationCode, strLevel);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                int count = this.dgvClassTimeDTL.Rows.Count;
                this.dgvClassTimeDTL.Rows.Add(1);
                this.dgvClassTimeDTL.Rows[count].Cells[1].Value = table.Rows[i]["fldClassTimeCode"].ToString();
                this.dgvClassTimeDTL.Rows[count].Cells[2].Value = table.Rows[i]["fldDayType"].ToString() + " : " + table.Rows[i]["fldInTime"].ToString() + " : " + table.Rows[i]["fldOutTime"].ToString();
                int num3 = this.cStudentClassTimes.GetStudentClassCount(this.cGlobleVariable.LocationCode, strLevel, table.Rows[i]["fldClassTimeCode"].ToString());
                this.dgvClassTimeDTL.Rows[count].Cells[3].Value = (this.oClassMaster.ClassTotalStudents + this.oClassMaster.ClassCoverUpDays) - num3;
            }
        }

        private void LoadStudent()
        {
            this.cmbAbsebtDates.Items.Clear();
            this.cmbAbsebtDates.Items.Add("None");
            this.oStudentMaster = this.cStudentMaster.GetStudentData(this.cGlobleVariable.LocationCode, this.txtStudentNo.Text.ToString());
            if (this.oStudentMaster.IsExistStudent)
            {
                this.txtStudentNo.Text = this.oStudentMaster.StudentNo;
                this.txtFullNameLineOne.Text = this.oStudentMaster.NameInFullL1;
                this.txtFullNameLineTwo.Text = this.oStudentMaster.NameInFullL2;
                this.oClassMaster = this.cClassMaster.GetClassData(this.cGlobleVariable.LocationCode, this.oStudentMaster.Level);
                this.txtLevel.Text = this.oClassMaster.ClassName;
                this.txtLevel.Tag = this.oClassMaster.ClassCode;
                DataTable studentClassDeails = this.cStudentClassTimes.GetStudentClassDeails(this.cGlobleVariable.LocationCode, this.txtStudentNo.Text);
                this.lstRegularEmployee.Rows.Clear();
                for (int i = 0; i < studentClassDeails.Rows.Count; i++)
                {
                    int count = this.lstRegularEmployee.Rows.Count;
                    this.lstRegularEmployee.Rows.Add(1);
                    this.lstRegularEmployee.Rows[count].Cells[0].Value = studentClassDeails.Rows[i]["fldClassTimeCode"].ToString();
                    this.lstRegularEmployee.Rows[count].Cells[1].Value = studentClassDeails.Rows[i]["fldDayType"].ToString();
                    this.lstRegularEmployee.Rows[count].Cells[2].Value = studentClassDeails.Rows[i]["fldInTime"].ToString() + " : " + studentClassDeails.Rows[i]["fldOutTime"].ToString();
                }
                DateTime time = DateTime.Now.AddDays(30.0);
                DateTime time2 = time.AddDays(-60.0);
                this.dgAttendanceDates.Rows.Clear();
                for (DateTime time3 = time2; time3 <= time; time3 = time3.AddDays(1.0))
                {
                    for (int j = 0; j < this.lstRegularEmployee.Rows.Count; j++)
                    {
                        int num4;
                        string str = Convert.ToString(this.lstRegularEmployee.Rows[j].Cells[1].Value);
                        if (time3.DayOfWeek.ToString() == str)
                        {
                            if (!this.cAttendanceProcess.EmployeeIsexist(this.cGlobleVariable.LocationCode, this.txtStudentNo.Text, time3))
                            {
                                this.dgAttendanceDates.Rows.Add(1);
                                num4 = this.dgAttendanceDates.Rows.Count;
                                this.dgAttendanceDates.Rows[num4 - 1].Cells[0].Value = string.Format("{0:yyyy/MM/dd}", time3);
                                this.cmbAbsebtDates.Items.Add(string.Format("{0:yyyy/MM/dd}", time3));
                                if (this.cConfirmStudentAttendance.GetConfirnAttDetails(this.cGlobleVariable.LocationCode, this.txtStudentNo.Text, time3).Rows.Count > 0)
                                {
                                    this.dgAttendanceDates.Rows[num4 - 1].DefaultCellStyle.BackColor = Color.Red;
                                    this.dgAttendanceDates.Rows[num4 - 1].Tag = "False";
                                }
                                else
                                {
                                    this.dgAttendanceDates.Rows[num4 - 1].Tag = "True";
                                }
                            }
                        }
                        else if (!this.cAttendanceProcess.EmployeeIsexist(this.cGlobleVariable.LocationCode, this.txtStudentNo.Text, time3) && (this.cConfirmStudentAttendance.GetConfirnAttDetails(this.cGlobleVariable.LocationCode, this.txtStudentNo.Text, time3).Rows.Count > 0))
                        {
                            this.dgAttendanceDates.Rows.Add(1);
                            num4 = this.dgAttendanceDates.Rows.Count;
                            this.dgAttendanceDates.Rows[num4 - 1].Cells[0].Value = string.Format("{0:yyyy/MM/dd}", time3);
                            this.dgAttendanceDates.Rows[num4 - 1].DefaultCellStyle.BackColor = Color.Yellow;
                            this.dgAttendanceDates.Rows[num4 - 1].Tag = "False";
                        }
                    }
                }
            }
        }

        private void txtStudentNo_TextChanged(object sender, EventArgs e)
        {
            this.LoadStudent();
        }

        private bool ValidateData()
        {
            bool flag = true;
            if (this.txtStudentNo.Text == "")
            {
                flag = false;
                this.err1.SetError(this.txtStudentNo, "Please enter valid student number");
            }
            else
            {
                this.err1.SetError(this.txtStudentNo, "");
            }
            if (this.txtFullNameLineOne.Text == "")
            {
                flag = false;
                this.err1.SetError(this.txtStudentNo, "Please enter valid student number");
            }
            else
            {
                this.err1.SetError(this.txtStudentNo, "");
            }
            if (this.dgvClassTimeDTL.Rows.Count > 0)
            {
                flag = false;
                this.err1.SetError(this.dtpDateOfConfirm, "");
                this.err1.SetError(this.dgvClassTimeDTL, "Please select  class time.");
                for (int j = 0; j < this.dgvClassTimeDTL.Rows.Count; j++)
                {
                    if (Convert.ToBoolean(this.dgvClassTimeDTL.Rows[j].Cells[0].Value))
                    {
                        flag = true;
                        this.err1.SetError(this.dgvClassTimeDTL, "");
                    }
                }
                if (!flag)
                {
                    return flag;
                }
            }
            else
            {
                flag = false;
                this.err1.SetError(this.dtpDateOfConfirm, "Please select  Confirm date.");
                return flag;
            }
            bool flag2 = false;
            bool flag3 = false;
            this.err1.SetError(this.cmbAbsebtDates, "");
            for (int i = 0; i < this.dgAttendanceDates.Rows.Count; i++)
            {
                if (string.Format("{0:yyyy/MM/dd}", this.dgAttendanceDates.Rows[i].Cells[0].Value) == string.Format("{0:yyyy/MM/dd}", this.cmbAbsebtDates.Text))
                {
                    if (Convert.ToString(this.dgAttendanceDates.Rows[i].Tag) == "False")
                    {
                        this.err1.SetError(this.cmbAbsebtDates, "Seleted date is already taken. Please select different date");
                        flag = false;
                        flag3 = true;
                    }
                    else
                    {
                        flag2 = true;
                    }
                    break;
                }
            }
            if ((!flag2 && !flag3) && (MessageBox.Show("Seleted date is not in the absent date list. Do you want to continute?", "Validate Details", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No))
            {
                flag = false;
            }
            return flag;
        }

        public void ViewEmployee()
        {
            string[] strFieldList = new string[] { "fldStudentNo", "fldNameInFullL1" };
            string[] strHeadingList = new string[] { "Student No", "Student Name" };
            int[] iHeaderWidth = new int[] { 80, 100 };
            string strReturnField = "Student No";
            string str2 = "fldLocationCode = '" + this.cGlobleVariable.LocationCode + "' ";
            this.txtStudentNo.Text = this.cCommanMethods.BrowsData("tbl_student_master", strFieldList, strHeadingList, iHeaderWidth, strReturnField, str2);
        }
    }
}

