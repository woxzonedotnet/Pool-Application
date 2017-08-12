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

    public class frmLevelChange : Form
    {
        public Button btnExit;
        public Button btnRefresh;
        public Button btnSave;
        public Button btnView;
        private clsAuditLog cAuditLog = new clsAuditLog();
        private clsClassMaster cClassMaster = new clsClassMaster();
        private clsClassTimeTable cClassTimeTable = new clsClassTimeTable();
        private clsCoacherMaster cCoacherMaster = new clsCoacherMaster();
        private clsCommenMethods cCommenMethods = new clsCommenMethods();
        private clsGlobleVariable cGlobleVariable = new clsGlobleVariable();
        private clsLeavalChange cLeavalChange = new clsLeavalChange();
        private clsLeavalChangeClassTime cLeavalChangeClassTime = new clsLeavalChangeClassTime();
        private ColumnComboBox cmbClassName;
        private DataGridViewTextBoxColumn Column1;
        private IContainer components = null;
        private clsStudentClassTimes cStudentClassTimes = new clsStudentClassTimes();
        private clsStudentMaster cStudentMaster = new clsStudentMaster();
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
        private DataGridView dgvClassTimeDTL;
        private DateTimePicker dtpDateOfPromote;
        private ErrorProvider errLevel;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Label label1;
        private Label label13;
        private Label label2;
        private Label label3;
        private Label label5;
        private Label label94;
        private DataGridView lstClassTimes;
        private objAuditLog oAuditLog = new objAuditLog();
        private objClassTimeTable oClassTimeTable = new objClassTimeTable();
        private objLeavalChange oLeavalChange = new objLeavalChange();
        private objLeavalChangeClassTime oLeavalChangeClassTime = new objLeavalChangeClassTime();
        private objStudentClassTimes oStudentClassTimes = new objStudentClassTimes();
        private objStudentMaster oStudentMaster = new objStudentMaster();
        private Panel panel1;
        private TextBox txtFullNameLineOne;
        private TextBox txtFullNameLineTwo;
        private TextBox txtLevel;
        private TextBox txtStudentNo;

        public frmLevelChange()
        {
            this.InitializeComponent();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            this.cLeavalChange.DeleteTimeDetails(this.cGlobleVariable.LocationCode, this.txtStudentNo.Text, this.cmbClassName["fldClassCode"].ToString(), this.dtpDateOfPromote.Value);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.oAuditLog.LocationCode = this.cGlobleVariable.LocationCode;
            this.oAuditLog.UserID = this.cGlobleVariable.CurrentUserID;
            this.oAuditLog.MachineID = clsGlobleVariable.MachineID;
            this.oAuditLog.DateEntered = Convert.ToDateTime(this.cAuditLog.getCurrentDate().Rows[0][0].ToString());
            this.oAuditLog.TimeEntered = Convert.ToDateTime(this.cAuditLog.getCurrentTime().Rows[0][0].ToString());
            this.oAuditLog.Task = "Exited From Level Changed Entry";
            this.cAuditLog.AuditLog(this.oAuditLog);
            base.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.cCommenMethods.ClearForm(this);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.ValidateData())
            {
                this.oLeavalChangeClassTime.LocationCode = this.cGlobleVariable.LocationCode;
                this.oLeavalChangeClassTime.StudentNo = this.txtStudentNo.Text;
                this.oLeavalChangeClassTime.ClassCode = this.cmbClassName["fldClassCode"].ToString();
                this.oLeavalChangeClassTime.PromotedDate = this.dtpDateOfPromote.Value;
                this.oLeavalChangeClassTime.PreviousClassCode = Convert.ToString(this.txtLevel.Tag);
                this.cStudentMaster.UpdateValues(this.cGlobleVariable.LocationCode, this.txtStudentNo.Text, this.cmbClassName["fldClassCode"].ToString(), this.dtpDateOfPromote.Value);
                this.cLeavalChangeClassTime.InsertUpdateData(this.oLeavalChangeClassTime);
                this.oStudentClassTimes.LocationCode = this.cGlobleVariable.LocationCode;
                this.oStudentClassTimes.ClassCode = this.cmbClassName["fldClassCode"].ToString();
                this.oStudentClassTimes.StudentNo = this.txtStudentNo.Text;
                this.cStudentClassTimes.DeleteTimeDetails(this.cGlobleVariable.LocationCode, this.txtStudentNo.Text);
                for (int i = 0; i < this.dgvClassTimeDTL.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(this.dgvClassTimeDTL.Rows[i].Cells[0].Value))
                    {
                        this.oStudentClassTimes.ClassTimeCode = this.dgvClassTimeDTL.Rows[i].Cells[1].Value.ToString();
                        this.cStudentClassTimes.InsertUpdateStudentClassTimes(this.oStudentClassTimes);
                    }
                }
                MessageBox.Show(this.cGlobleVariable.SeavedMessage, "Leval Changed Details", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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
            this.oAuditLog.Task = "Viewed Student Details of Student No: " + this.txtStudentNo.Text + "- Level Changed";
            this.cAuditLog.AuditLog(this.oAuditLog);
        }

        private void cmbClassName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbClassName.SelectedIndex > -1)
            {
                DataTable table = this.cClassTimeTable.GetClassTimeDetails(this.cGlobleVariable.LocationCode, this.cmbClassName["fldClassCode"].ToString(), this.cGlobleVariable.ActiveStatusCode);
                this.dgvClassTimeDTL.Rows.Clear();
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    int count = this.dgvClassTimeDTL.Rows.Count;
                    this.dgvClassTimeDTL.Rows.Add(1);
                    this.dgvClassTimeDTL.Rows[count].Cells[1].Value = table.Rows[i]["fldClassTimeCode"].ToString();
                    this.dgvClassTimeDTL.Rows[count].Cells[2].Value = table.Rows[i]["fldDayType"].ToString();
                    this.dgvClassTimeDTL.Rows[count].Cells[3].Value = table.Rows[i]["fldInTime"].ToString() + " : " + table.Rows[i]["fldOutTime"].ToString();
                }
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void frmLeavalChange_Load(object sender, EventArgs e)
        {
            this.loadCombo();
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
            ComponentResourceManager manager = new ComponentResourceManager(typeof(frmLevelChange));
            this.groupBox1 = new GroupBox();
            this.label3 = new Label();
            this.txtLevel = new TextBox();
            this.groupBox2 = new GroupBox();
            this.label13 = new Label();
            this.label94 = new Label();
            this.dtpDateOfPromote = new DateTimePicker();
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
            this.dgvClassTimeDTL = new DataGridView();
            this.label1 = new Label();
            this.dataGridViewCheckBoxColumn2 = new DataGridViewCheckBoxColumn();
            this.lstClassTimes = new DataGridView();
            this.dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new DataGridViewTextBoxColumn();
            this.Column1 = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new DataGridViewTextBoxColumn();
            this.cmbClassName = new ColumnComboBox();
            this.dataGridViewTextBoxColumn7 = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new DataGridViewTextBoxColumn();
            this.errLevel = new ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((ISupportInitialize) this.dgvClassTimeDTL).BeginInit();
            ((ISupportInitialize) this.lstClassTimes).BeginInit();
            ((ISupportInitialize) this.errLevel).BeginInit();
            base.SuspendLayout();
            this.groupBox1.Controls.Add(this.lstClassTimes);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtLevel);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.txtFullNameLineTwo);
            this.groupBox1.Controls.Add(this.txtFullNameLineOne);
            this.groupBox1.Controls.Add(this.txtStudentNo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(0x227, 0x18f);
            this.groupBox1.TabIndex = 0xd1;
            this.groupBox1.TabStop = false;
            this.label3.AutoSize = true;
            this.label3.Location = new Point(6, 0x59);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x6a, 13);
            this.label3.TabIndex = 0xe8;
            this.label3.Text = "Student Current level";
            this.txtLevel.BackColor = Color.White;
            this.txtLevel.Location = new Point(0x71, 0x56);
            this.txtLevel.MaxLength = 100;
            this.txtLevel.Name = "txtLevel";
            this.txtLevel.ReadOnly = true;
            this.txtLevel.Size = new Size(0x102, 20);
            this.txtLevel.TabIndex = 0xe7;
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.dgvClassTimeDTL);
            this.groupBox2.Controls.Add(this.cmbClassName);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label94);
            this.groupBox2.Controls.Add(this.dtpDateOfPromote);
            this.groupBox2.Location = new Point(6, 0xd0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new Size(0x218, 0xb6);
            this.groupBox2.TabIndex = 0xd7;
            this.groupBox2.TabStop = false;
            this.label13.AutoSize = true;
            this.label13.Location = new Point(6, 0x10);
            this.label13.Name = "label13";
            this.label13.Size = new Size(0x40, 13);
            this.label13.TabIndex = 0xd0;
            this.label13.Text = "New Level :";
            this.label94.AutoSize = true;
            this.label94.Location = new Point(0x14e, 0x10);
            this.label94.Name = "label94";
            this.label94.Size = new Size(0x58, 13);
            this.label94.TabIndex = 0xd9;
            this.label94.Text = "Date of Change :";
            this.dtpDateOfPromote.Format = DateTimePickerFormat.Short;
            this.dtpDateOfPromote.Location = new Point(0x1ac, 13);
            this.dtpDateOfPromote.Name = "dtpDateOfPromote";
            this.dtpDateOfPromote.Size = new Size(0x66, 20);
            this.dtpDateOfPromote.TabIndex = 0xd8;
            this.txtFullNameLineTwo.BackColor = Color.White;
            this.txtFullNameLineTwo.Location = new Point(0x71, 60);
            this.txtFullNameLineTwo.MaxLength = 100;
            this.txtFullNameLineTwo.Name = "txtFullNameLineTwo";
            this.txtFullNameLineTwo.ReadOnly = true;
            this.txtFullNameLineTwo.Size = new Size(0x199, 20);
            this.txtFullNameLineTwo.TabIndex = 0xd4;
            this.txtFullNameLineOne.BackColor = Color.White;
            this.txtFullNameLineOne.Location = new Point(0x71, 0x25);
            this.txtFullNameLineOne.MaxLength = 100;
            this.txtFullNameLineOne.Name = "txtFullNameLineOne";
            this.txtFullNameLineOne.ReadOnly = true;
            this.txtFullNameLineOne.Size = new Size(0x199, 20);
            this.txtFullNameLineOne.TabIndex = 0xd3;
            this.txtStudentNo.BackColor = Color.White;
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
            this.panel1.Location = new Point(12, 0x1a2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(0x227, 0x2d);
            this.panel1.TabIndex = 210;
            this.btnView.Location = new Point(0x53, 11);
            this.btnView.Name = "btnView";
            this.btnView.Size = new Size(0x49, 0x17);
            this.btnView.TabIndex = 0x26;
            this.btnView.Text = "&View";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new EventHandler(this.btnView_Click);
            this.btnRefresh.Location = new Point(0xa2, 11);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new Size(0x47, 0x17);
            this.btnRefresh.TabIndex = 7;
            this.btnRefresh.Text = "&Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new EventHandler(this.btnRefresh_Click);
            this.btnSave.Enabled = false;
            this.btnSave.Location = new Point(6, 11);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new Size(0x47, 0x17);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new EventHandler(this.btnSave_Click);
            this.btnExit.FlatAppearance.BorderColor = Color.FromArgb(0x40, 0x40, 0x40);
            this.btnExit.FlatAppearance.BorderSize = 5;
            this.btnExit.Location = new Point(0x1d1, 11);
            this.btnExit.Margin = new Padding(0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new Size(0x53, 0x17);
            this.btnExit.TabIndex = 10;
            this.btnExit.Text = "E&xit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new EventHandler(this.btnExit_Click);
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
            this.dgvClassTimeDTL.Columns.AddRange(new DataGridViewColumn[] { this.dataGridViewCheckBoxColumn2, this.dataGridViewTextBoxColumn13, this.Column1, this.dataGridViewTextBoxColumn14 });
            this.dgvClassTimeDTL.Location = new Point(0x6b, 0x27);
            this.dgvClassTimeDTL.Name = "dgvClassTimeDTL";
            this.dgvClassTimeDTL.RowHeadersVisible = false;
            this.dgvClassTimeDTL.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvClassTimeDTL.Size = new Size(0x199, 130);
            this.dgvClassTimeDTL.TabIndex = 0xe9;
            this.label1.AutoSize = true;
            this.label1.Location = new Point(7, 0x2d);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x54, 13);
            this.label1.TabIndex = 0xea;
            this.label1.Text = "New Class times";
            style2.Alignment = DataGridViewContentAlignment.TopLeft;
            style2.NullValue = false;
            this.dataGridViewCheckBoxColumn2.DefaultCellStyle = style2;
            this.dataGridViewCheckBoxColumn2.HeaderText = "";
            this.dataGridViewCheckBoxColumn2.Name = "dataGridViewCheckBoxColumn2";
            this.dataGridViewCheckBoxColumn2.Width = 0x19;
            this.lstClassTimes.AllowUserToAddRows = false;
            this.lstClassTimes.AllowUserToDeleteRows = false;
            this.lstClassTimes.AllowUserToResizeColumns = false;
            this.lstClassTimes.AllowUserToResizeRows = false;
            this.lstClassTimes.BackgroundColor = SystemColors.ControlLightLight;
            style3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            style3.BackColor = SystemColors.Control;
            style3.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            style3.ForeColor = SystemColors.WindowText;
            style3.SelectionBackColor = SystemColors.Highlight;
            style3.SelectionForeColor = SystemColors.HighlightText;
            style3.WrapMode = DataGridViewTriState.True;
            this.lstClassTimes.ColumnHeadersDefaultCellStyle = style3;
            this.lstClassTimes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.lstClassTimes.Columns.AddRange(new DataGridViewColumn[] { this.dataGridViewTextBoxColumn10, this.dataGridViewTextBoxColumn11, this.dataGridViewTextBoxColumn12 });
            this.lstClassTimes.Location = new Point(0x71, 0x6f);
            this.lstClassTimes.Name = "lstClassTimes";
            this.lstClassTimes.RowHeadersVisible = false;
            this.lstClassTimes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.lstClassTimes.Size = new Size(0x102, 0x61);
            this.lstClassTimes.TabIndex = 0xea;
            style4.Alignment = DataGridViewContentAlignment.TopLeft;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = style4;
            this.dataGridViewTextBoxColumn1.HeaderText = "Number";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            this.dataGridViewTextBoxColumn1.Width = 70;
            style5.Alignment = DataGridViewContentAlignment.TopLeft;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = style5;
            this.dataGridViewTextBoxColumn2.HeaderText = "Class Day";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Visible = false;
            this.dataGridViewTextBoxColumn2.Width = 80;
            style6.Alignment = DataGridViewContentAlignment.TopLeft;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = style6;
            this.dataGridViewTextBoxColumn3.HeaderText = "Class Times";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 0x9b;
            style7.Alignment = DataGridViewContentAlignment.TopLeft;
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = style7;
            this.dataGridViewTextBoxColumn4.HeaderText = "Strat Time";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Visible = false;
            this.dataGridViewTextBoxColumn4.Width = 80;
            style8.Alignment = DataGridViewContentAlignment.TopLeft;
            this.dataGridViewTextBoxColumn5.DefaultCellStyle = style8;
            this.dataGridViewTextBoxColumn5.HeaderText = "End Time";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 80;
            style9.Alignment = DataGridViewContentAlignment.TopLeft;
            this.dataGridViewTextBoxColumn6.DefaultCellStyle = style9;
            this.dataGridViewTextBoxColumn6.HeaderText = "Coacher No";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Resizable = DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn6.Visible = false;
            this.dataGridViewTextBoxColumn6.Width = 0xff;
            style10.Alignment = DataGridViewContentAlignment.TopLeft;
            this.dataGridViewTextBoxColumn10.DefaultCellStyle = style10;
            this.dataGridViewTextBoxColumn10.HeaderText = "Number";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.Visible = false;
            this.dataGridViewTextBoxColumn10.Width = 70;
            this.dataGridViewTextBoxColumn11.HeaderText = "Class Day";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            style11.Alignment = DataGridViewContentAlignment.TopLeft;
            this.dataGridViewTextBoxColumn12.DefaultCellStyle = style11;
            this.dataGridViewTextBoxColumn12.HeaderText = "Class Times";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            this.dataGridViewTextBoxColumn12.Width = 150;
            style12.Alignment = DataGridViewContentAlignment.TopLeft;
            this.dataGridViewTextBoxColumn13.DefaultCellStyle = style12;
            this.dataGridViewTextBoxColumn13.HeaderText = "Number";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.ReadOnly = true;
            this.dataGridViewTextBoxColumn13.Visible = false;
            this.dataGridViewTextBoxColumn13.Width = 70;
            this.Column1.HeaderText = "Class Day";
            this.Column1.Name = "Column1";
            style13.Alignment = DataGridViewContentAlignment.TopLeft;
            this.dataGridViewTextBoxColumn14.DefaultCellStyle = style13;
            this.dataGridViewTextBoxColumn14.HeaderText = "Class Times";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.ReadOnly = true;
            this.dataGridViewTextBoxColumn14.Width = 0xff;
            this.cmbClassName.DrawMode = DrawMode.OwnerDrawVariable;
            this.cmbClassName.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbClassName.DropDownWidth = 0x11;
            this.cmbClassName.FormattingEnabled = true;
            this.cmbClassName.Location = new Point(0x6b, 13);
            this.cmbClassName.Name = "cmbClassName";
            this.cmbClassName.Size = new Size(0xc5, 0x15);
            this.cmbClassName.TabIndex = 0xcf;
            this.cmbClassName.ViewColumn = 0;
            this.cmbClassName.SelectedIndexChanged += new EventHandler(this.cmbClassName_SelectedIndexChanged);
            this.dataGridViewTextBoxColumn7.HeaderText = "Coacher Name";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn8.HeaderText = "Ass Coacher No";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Visible = false;
            this.dataGridViewTextBoxColumn9.HeaderText = "Ass Coacher Name";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.errLevel.ContainerControl = this;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x23d, 0x1d5);
            base.Controls.Add(this.panel1);
            base.Controls.Add(this.groupBox1);
            base.Name = "frmLevelChange";
            this.Text = "Level Change";
            base.Load += new EventHandler(this.frmLeavalChange_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((ISupportInitialize) this.dgvClassTimeDTL).EndInit();
            ((ISupportInitialize) this.lstClassTimes).EndInit();
            ((ISupportInitialize) this.errLevel).EndInit();
            base.ResumeLayout(false);
        }

        private void loadCombo()
        {
            DataTable classDetails = this.cClassMaster.GetClassDetails(this.cGlobleVariable.LocationCode, this.cGlobleVariable.ActiveStatusCode);
            this.cCommenMethods.LoadCombo(classDetails, this.cmbClassName, 3);
        }

        private void LoadStudent()
        {
            this.oStudentMaster = this.cStudentMaster.GetStudentData(this.cGlobleVariable.LocationCode, this.txtStudentNo.Text.ToString());
            if (this.oStudentMaster.IsExistStudent)
            {
                this.btnSave.Enabled = true;
                this.txtStudentNo.Text = this.oStudentMaster.StudentNo;
                this.txtFullNameLineOne.Text = this.oStudentMaster.NameInFullL1;
                this.txtFullNameLineTwo.Text = this.oStudentMaster.NameInFullL2;
                this.txtLevel.Text = this.cClassMaster.GetClassData(this.cGlobleVariable.LocationCode, this.oStudentMaster.Level).ClassName;
                this.txtLevel.Tag = this.oStudentMaster.Level;
                DataTable studentClassDeails = this.cStudentClassTimes.GetStudentClassDeails(this.cGlobleVariable.LocationCode, this.txtStudentNo.Text);
                this.lstClassTimes.Rows.Clear();
                for (int i = 0; i < studentClassDeails.Rows.Count; i++)
                {
                    int count = this.lstClassTimes.Rows.Count;
                    this.lstClassTimes.Rows.Add(1);
                    this.lstClassTimes.Rows[count].Cells[0].Value = studentClassDeails.Rows[i]["fldClassTimeCode"].ToString();
                    this.lstClassTimes.Rows[count].Cells[1].Value = studentClassDeails.Rows[i]["fldDayType"].ToString();
                    this.lstClassTimes.Rows[count].Cells[2].Value = studentClassDeails.Rows[i]["fldInTime"].ToString() + " : " + studentClassDeails.Rows[i]["fldOutTime"].ToString();
                }
                this.cmbClassName.SetText(this.cClassMaster.GetClassData(this.cGlobleVariable.LocationCode, this.oStudentMaster.Level).ClassName);
            }
            else
            {
                this.btnSave.Enabled = false;
            }
        }

        private void txtStudentNo_TextChanged(object sender, EventArgs e)
        {
            if (this.txtStudentNo.Text != "")
            {
                this.LoadStudent();
            }
        }

        private bool ValidateData()
        {
            bool flag = true;
            if (this.txtStudentNo.Text == "")
            {
                flag = false;
                this.errLevel.SetError(this.txtStudentNo, "Please enter valid student number");
            }
            else
            {
                this.errLevel.SetError(this.txtStudentNo, "");
            }
            if (this.txtFullNameLineOne.Text == "")
            {
                flag = false;
                this.errLevel.SetError(this.txtStudentNo, "Please enter valid student number");
            }
            else
            {
                this.errLevel.SetError(this.txtStudentNo, "");
            }
            if (this.dgvClassTimeDTL.Rows.Count > 0)
            {
                flag = false;
                this.errLevel.SetError(this.cmbClassName, "");
                this.errLevel.SetError(this.dgvClassTimeDTL, "Please select  class time.");
                for (int i = 0; i < this.dgvClassTimeDTL.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(this.dgvClassTimeDTL.Rows[i].Cells[0].Value))
                    {
                        flag = true;
                        this.errLevel.SetError(this.dgvClassTimeDTL, "");
                    }
                }
                return flag;
            }
            flag = false;
            this.errLevel.SetError(this.cmbClassName, "Please select  Confirm date.");
            return flag;
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

