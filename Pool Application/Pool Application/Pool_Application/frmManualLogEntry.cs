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

    public class frmManualLogEntry : Form
    {
        private Button btnEntryAll;
        private Button btnEntrySelected;
        private Button btnExit;
        private Button btnNew;
        private Button btnRemove;
        private Button btnRemoveAll;
        private Button btnRemoveSelected;
        private Button btnSave;
        private clsAuditLog cAuditLog = new clsAuditLog();
        private clsBeadBarcode cBeadBarcode = new clsBeadBarcode();
        private clsClassMaster cClassMaster = new clsClassMaster();
        private clsClassTimeTable cClassTimeTable = new clsClassTimeTable();
        private clsDayTypes cDayTypes = new clsDayTypes();
        private clsGlobleVariable cGlobalVariable = new clsGlobleVariable();
        private DataGridViewTextBoxColumn clmEmpName;
        private DataGridViewTextBoxColumn clmNumber;
        private clsCommenMethods clsCommen = new clsCommenMethods();
        private clsManualLogEntry cManualLogEntry = new clsManualLogEntry();
        private ColumnComboBox cmbLevel;
        private ColumnComboBox cmdDay;
        private ColumnComboBox cmdSession;
        private IContainer components = null;
        private clsStudentMaster cStudentMaster = new clsStudentMaster();
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridView dgvEmployee;
        private DataGridView dgvLogTime;
        private DateTimePicker dtpLogDate;
        private DateTimePicker dtpLogTime;
        private ErrorProvider errManualLogentry;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox4;
        private GroupBox grpDatetime;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private objAuditLog oAuditLog = new objAuditLog();
        private objBeadBarcode oBeadBarcode = new objBeadBarcode();
        private objManualLogEntry oManualLogEntry = new objManualLogEntry();

        public frmManualLogEntry()
        {
            this.InitializeComponent();
        }

        private void btnEntryAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= (this.dgvEmployee.Rows.Count - 1); i++)
            {
                this.InsertUpdateData(Convert.ToString(this.dgvEmployee.Rows[i].Cells[0].Value), this.dtpLogDate.Value, this.dtpLogTime.Value);
            }
            MessageBox.Show("Successfully Saved...!", "Manual Log Details", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            this.grpDatetime.Visible = false;
            this.oAuditLog.LocationCode = this.cGlobalVariable.LocationCode;
            this.oAuditLog.UserID = this.cGlobalVariable.CurrentUserID;
            this.oAuditLog.MachineID = clsGlobleVariable.MachineID;
            this.oAuditLog.DateEntered = Convert.ToDateTime(this.cAuditLog.getCurrentDate().Rows[0][0].ToString());
            this.oAuditLog.TimeEntered = Convert.ToDateTime(this.cAuditLog.getCurrentTime().Rows[0][0].ToString());
            this.oAuditLog.Task = clsGlobleVariable.InsertData + "Manual Log entry for all Employees on " + this.dtpLogDate.Value;
            this.cAuditLog.AuditLog(this.oAuditLog);
        }

        private void btnEntrySelected_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= (this.dgvEmployee.Rows.Count - 1); i++)
            {
                if (this.dgvEmployee.Rows[i].Selected)
                {
                    this.InsertUpdateData(Convert.ToString(this.dgvEmployee.Rows[i].Cells[0].Value), this.dtpLogDate.Value, this.dtpLogTime.Value);
                }
            }
            MessageBox.Show("Successfully Saved...!", "Manual Log Details", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            this.grpDatetime.Visible = false;
            this.oAuditLog.LocationCode = this.cGlobalVariable.LocationCode;
            this.oAuditLog.UserID = this.cGlobalVariable.CurrentUserID;
            this.oAuditLog.MachineID = clsGlobleVariable.MachineID;
            this.oAuditLog.DateEntered = Convert.ToDateTime(this.cAuditLog.getCurrentDate().Rows[0][0].ToString());
            this.oAuditLog.TimeEntered = Convert.ToDateTime(this.cAuditLog.getCurrentTime().Rows[0][0].ToString());
            this.oAuditLog.Task = clsGlobleVariable.InsertData + "Manual Log entry for selected Employees on " + this.dtpLogDate.Value;
            this.cAuditLog.AuditLog(this.oAuditLog);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            base.Close();
            this.oAuditLog.LocationCode = this.cGlobalVariable.LocationCode;
            this.oAuditLog.UserID = this.cGlobalVariable.CurrentUserID;
            this.oAuditLog.MachineID = clsGlobleVariable.MachineID;
            this.oAuditLog.DateEntered = Convert.ToDateTime(this.cAuditLog.getCurrentDate().Rows[0][0].ToString());
            this.oAuditLog.TimeEntered = Convert.ToDateTime(this.cAuditLog.getCurrentTime().Rows[0][0].ToString());
            this.oAuditLog.Task = "Exited from Invoice entry ";
            this.cAuditLog.AuditLog(this.oAuditLog);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            this.oAuditLog.LocationCode = this.cGlobalVariable.LocationCode;
            this.oAuditLog.UserID = this.cGlobalVariable.CurrentUserID;
            this.oAuditLog.MachineID = clsGlobleVariable.MachineID;
            this.oAuditLog.DateEntered = Convert.ToDateTime(this.cAuditLog.getCurrentDate().Rows[0][0].ToString());
            this.oAuditLog.TimeEntered = Convert.ToDateTime(this.cAuditLog.getCurrentTime().Rows[0][0].ToString());
            this.oAuditLog.Task = "New button is clicked in Manual log entry";
            this.cAuditLog.AuditLog(this.oAuditLog);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (this.dgvLogTime.CurrentCell.RowIndex > -1)
            {
                this.cManualLogEntry.DeleteManualLogEntryData(this.cGlobalVariable.LocationCode, Convert.ToString(this.dgvEmployee.Rows[this.dgvEmployee.CurrentCell.RowIndex].Cells[0].Value), this.dtpLogDate.Value, Convert.ToDateTime(this.dgvLogTime.Rows[this.dgvLogTime.CurrentCell.RowIndex].Cells[0].Value));
                this.Get_Manual_Log_Entry_Data(Convert.ToString(this.dgvEmployee.Rows[this.dgvEmployee.CurrentCell.RowIndex].Cells[0].Value), this.dtpLogDate.Value);
            }
            this.oAuditLog.LocationCode = this.cGlobalVariable.LocationCode;
            this.oAuditLog.UserID = this.cGlobalVariable.CurrentUserID;
            this.oAuditLog.MachineID = clsGlobleVariable.MachineID;
            this.oAuditLog.DateEntered = Convert.ToDateTime(this.cAuditLog.getCurrentDate().Rows[0][0].ToString());
            this.oAuditLog.TimeEntered = Convert.ToDateTime(this.cAuditLog.getCurrentTime().Rows[0][0].ToString());
            this.oAuditLog.Task = string.Concat(new object[] { "Manual log entry for Employee (", Convert.ToString(this.dgvEmployee.Rows[this.dgvEmployee.CurrentCell.RowIndex].Cells[0].Value), ") on", this.dtpLogDate.Value, " deleted" });
            this.cAuditLog.AuditLog(this.oAuditLog);
        }

        private void btnRemoveAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= (this.dgvEmployee.Rows.Count - 1); i++)
            {
                this.cManualLogEntry.DeleteManualLogEntryData(this.cGlobalVariable.LocationCode, Convert.ToString(this.dgvEmployee.Rows[i].Cells[0].Value), this.dtpLogDate.Value);
                this.Get_Manual_Log_Entry_Data(Convert.ToString(this.dgvEmployee.Rows[this.dgvEmployee.CurrentCell.RowIndex].Cells[0].Value), this.dtpLogDate.Value);
            }
            this.oAuditLog.LocationCode = this.cGlobalVariable.LocationCode;
            this.oAuditLog.UserID = this.cGlobalVariable.CurrentUserID;
            this.oAuditLog.MachineID = clsGlobleVariable.MachineID;
            this.oAuditLog.DateEntered = Convert.ToDateTime(this.cAuditLog.getCurrentDate().Rows[0][0].ToString());
            this.oAuditLog.TimeEntered = Convert.ToDateTime(this.cAuditLog.getCurrentTime().Rows[0][0].ToString());
            this.oAuditLog.Task = "Manual Log entry for all the Employees on " + this.dtpLogDate.Value + " were deleted";
            this.cAuditLog.AuditLog(this.oAuditLog);
        }

        private void btnRemoveSelected_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= (this.dgvEmployee.Rows.Count - 1); i++)
            {
                if (this.dgvEmployee.Rows[i].Selected)
                {
                    this.cManualLogEntry.DeleteManualLogEntryData(this.cGlobalVariable.LocationCode, Convert.ToString(this.dgvEmployee.Rows[i].Cells[0].Value), this.dtpLogDate.Value);
                    this.Get_Manual_Log_Entry_Data(Convert.ToString(this.dgvEmployee.Rows[this.dgvEmployee.CurrentCell.RowIndex].Cells[0].Value), this.dtpLogDate.Value);
                }
            }
            this.oAuditLog.LocationCode = this.cGlobalVariable.LocationCode;
            this.oAuditLog.UserID = this.cGlobalVariable.CurrentUserID;
            this.oAuditLog.MachineID = clsGlobleVariable.MachineID;
            this.oAuditLog.DateEntered = Convert.ToDateTime(this.cAuditLog.getCurrentDate().Rows[0][0].ToString());
            this.oAuditLog.TimeEntered = Convert.ToDateTime(this.cAuditLog.getCurrentTime().Rows[0][0].ToString());
            this.oAuditLog.Task = "Manual Log entry for selected Employees on " + this.dtpLogDate.Value + " were deleted";
            this.cAuditLog.AuditLog(this.oAuditLog);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.dgvLogTime.Rows.Count; i++)
            {
                this.InsertUpdateData(Convert.ToString(this.dgvEmployee.Rows[this.dgvEmployee.CurrentCell.RowIndex].Cells[0].Value), this.dtpLogDate.Value, Convert.ToDateTime(this.dgvLogTime.Rows[i].Cells[0].Value.ToString()));
            }
            MessageBox.Show("Successfully Saved...!", "Manual Log Details", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            this.grpDatetime.Visible = false;
            this.oAuditLog.LocationCode = this.cGlobalVariable.LocationCode;
            this.oAuditLog.UserID = this.cGlobalVariable.CurrentUserID;
            this.oAuditLog.MachineID = clsGlobleVariable.MachineID;
            this.oAuditLog.DateEntered = Convert.ToDateTime(this.cAuditLog.getCurrentDate().Rows[0][0].ToString());
            this.oAuditLog.TimeEntered = Convert.ToDateTime(this.cAuditLog.getCurrentTime().Rows[0][0].ToString());
            this.oAuditLog.Task = string.Concat(new object[] { clsGlobleVariable.InsertData, "Manual Log entry for Employee ", Convert.ToString(this.dgvEmployee.Rows[this.dgvEmployee.CurrentCell.RowIndex].Cells[0].Value), " on ", this.dtpLogDate.Value });
            this.cAuditLog.AuditLog(this.oAuditLog);
            this.dgvLogTime.Rows.Clear();
        }

        private bool CheckDuplicate()
        {
            bool flag = true;
            for (int i = 0; i < this.dgvLogTime.Rows.Count; i++)
            {
                if (Convert.ToDateTime(this.dgvLogTime.Rows[i].Cells[0].Value).ToString("hh:mm tt") == Convert.ToDateTime(this.dtpLogTime.Value).ToString("hh:mm tt"))
                {
                    this.errManualLogentry.SetError(this.dgvLogTime, "Duplicate Log  Times");
                    return false;
                }
                this.errManualLogentry.SetError(this.dgvLogTime, "");
                flag = true;
                this.errManualLogentry.Dispose();
            }
            return flag;
        }

        private void cmbLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbLevel.SelectedIndex > -1)
            {
                this.oManualLogEntry.ClassCode = this.cmbLevel["fldClassCode"].ToString();
                if (this.oManualLogEntry.ClassCode == "$00")
                {
                    this.oManualLogEntry.ClassCode = "%";
                }
                this.Show_Employees_Grid();
            }
        }

        private void cmdDay_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmdDay.SelectedIndex > -1)
            {
                this.oManualLogEntry.DayType = this.cmdDay["fldDay"].ToString();
                if (this.oManualLogEntry.DayType == "ALL")
                {
                    this.oManualLogEntry.DayType = "%";
                }
                this.Show_Employees_Grid();
            }
        }

        private void cmdSession_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmdDay.SelectedIndex > -1)
            {
                this.oManualLogEntry.DaySession = this.cmdSession["Column2"].ToString();
                if (this.oManualLogEntry.DaySession == "ALL")
                {
                    this.oManualLogEntry.DaySession = "%";
                }
                this.Show_Employees_Grid();
            }
        }

        private void dgvEmployee_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Get_Manual_Log_Entry_Data(Convert.ToString(this.dgvEmployee.Rows[this.dgvEmployee.CurrentCell.RowIndex].Cells[0].Value), this.dtpLogDate.Value);
            this.errManualLogentry.Dispose();
        }

        private void dgvEmployee_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.dgvLogTime.Rows.Clear();
            this.Get_Manual_Log_Entry_Data(Convert.ToString(this.dgvEmployee.Rows[this.dgvEmployee.CurrentCell.RowIndex].Cells[0].Value), this.dtpLogDate.Value);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void dtpLogDate_ValueChanged(object sender, EventArgs e)
        {
            this.Get_Manual_Log_Entry_Data(Convert.ToString(this.dgvEmployee.Rows[this.dgvEmployee.CurrentCell.RowIndex].Cells[0].Value), this.dtpLogDate.Value);
        }

        private void dtpLogTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                this.grpDatetime.Visible = true;
                this.dgvLogTime.Visible = true;
                if (this.CheckDuplicate())
                {
                    int count = this.dgvLogTime.Rows.Count;
                    this.dgvLogTime.Rows.Add(1);
                    this.dgvLogTime.Rows[count].Cells[0].Value = this.dtpLogTime.Value.ToString("hh:mm:ss tt");
                }
            }
        }

        private void frmManualLogEntry_Load(object sender, EventArgs e)
        {
            DataTable classDetails = this.cClassMaster.GetClassDetails(this.cGlobalVariable.LocationCode, this.cGlobalVariable.ActiveStatusCode);
            DataRow row = classDetails.NewRow();
            row[0] = "0";
            row[1] = "$00";
            row[2] = "$00";
            row[3] = "ALL";
            classDetails.Rows.InsertAt(row, 0);
            this.clsCommen.LoadCombo(classDetails, this.cmbLevel, 3);
            if (this.cmbLevel.Items.Count > 0)
            {
                this.cmbLevel.SelectedIndex = 0;
            }
            DataTable dtFillData = this.cDayTypes.GetClassDetails();
            DataRow row2 = dtFillData.NewRow();
            row2[0] = "D";
            row2[1] = "ALL";
            dtFillData.Rows.InsertAt(row2, 0);
            this.clsCommen.LoadCombo(dtFillData, this.cmdDay, 1);
            if (this.cmdDay.Items.Count > 0)
            {
                this.cmdDay.SelectedIndex = 0;
            }
            DataTable table3 = new DataTable();
            table3.Columns.Add();
            table3.Columns.Add();
            DataRow row3 = table3.NewRow();
            row3[0] = "$00";
            row3[1] = "ALL";
            table3.Rows.InsertAt(row3, 0);
            row3 = table3.NewRow();
            row3[0] = "$01";
            row3[1] = "Evening";
            table3.Rows.InsertAt(row3, 1);
            row3 = table3.NewRow();
            row3[0] = "$02";
            row3[1] = "Morning";
            table3.Rows.InsertAt(row3, 2);
            this.clsCommen.LoadCombo(table3, this.cmdSession, 1);
            if (this.cmdSession.Items.Count > 0)
            {
                this.cmdSession.SelectedIndex = 0;
            }
        }

        private void Get_Manual_Log_Entry_Data(string strEmployeeCode, DateTime dtLogDate)
        {
            this.dgvLogTime.Rows.Clear();
            DataTable table = new DataTable();
            table = this.cManualLogEntry.GetManualLogEntryData(this.cGlobalVariable.LocationCode, strEmployeeCode, dtLogDate);
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i <= (table.Rows.Count - 1); i++)
                {
                    int count = this.dgvLogTime.Rows.Count;
                    this.dgvLogTime.Rows.Add(1);
                    this.dgvLogTime.Rows[count].Cells[0].Value = Convert.ToDateTime(table.Rows[i][3].ToString()).ToString("hh:mm:ss tt");
                }
                this.grpDatetime.Visible = true;
                this.dgvLogTime.Visible = true;
            }
            else
            {
                this.dgvLogTime.Visible = false;
            }
            this.dgvLogTime.Visible = true;
            this.grpDatetime.Visible = true;
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            DataGridViewCellStyle style = new DataGridViewCellStyle();
            DataGridViewCellStyle style2 = new DataGridViewCellStyle();
            DataGridViewCellStyle style3 = new DataGridViewCellStyle();
            ComponentResourceManager manager = new ComponentResourceManager(typeof(frmManualLogEntry));
            DataGridViewCellStyle style4 = new DataGridViewCellStyle();
            DataGridViewCellStyle style5 = new DataGridViewCellStyle();
            this.groupBox2 = new GroupBox();
            this.label2 = new Label();
            this.dtpLogDate = new DateTimePicker();
            this.groupBox4 = new GroupBox();
            this.btnExit = new Button();
            this.btnRemoveSelected = new Button();
            this.btnEntrySelected = new Button();
            this.btnRemoveAll = new Button();
            this.btnEntryAll = new Button();
            this.btnRemove = new Button();
            this.btnNew = new Button();
            this.btnSave = new Button();
            this.grpDatetime = new GroupBox();
            this.label1 = new Label();
            this.dtpLogTime = new DateTimePicker();
            this.dgvLogTime = new DataGridView();
            this.dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            this.dgvEmployee = new DataGridView();
            this.groupBox1 = new GroupBox();
            this.cmbLevel = new ColumnComboBox();
            this.cmdSession = new ColumnComboBox();
            this.label3 = new Label();
            this.label4 = new Label();
            this.cmdDay = new ColumnComboBox();
            this.label5 = new Label();
            this.errManualLogentry = new ErrorProvider(this.components);
            this.clmNumber = new DataGridViewTextBoxColumn();
            this.clmEmpName = new DataGridViewTextBoxColumn();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.grpDatetime.SuspendLayout();
            ((ISupportInitialize) this.dgvLogTime).BeginInit();
            ((ISupportInitialize) this.dgvEmployee).BeginInit();
            this.groupBox1.SuspendLayout();
            ((ISupportInitialize) this.errManualLogentry).BeginInit();
            base.SuspendLayout();
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.dtpLogDate);
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.grpDatetime);
            this.groupBox2.Controls.Add(this.dgvEmployee);
            this.groupBox2.Location = new Point(4, 0x5e);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new Size(0x25c, 0x19c);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.label2.AutoSize = true;
            this.label2.ForeColor = SystemColors.Highlight;
            this.label2.Location = new Point(0x16b, 0x17);
            this.label2.Name = "label2";
            this.label2.Size = new Size(30, 13);
            this.label2.TabIndex = 0x13;
            this.label2.Text = "Date";
            this.dtpLogDate.Format = DateTimePickerFormat.Short;
            this.dtpLogDate.Location = new Point(0x198, 0x13);
            this.dtpLogDate.Name = "dtpLogDate";
            this.dtpLogDate.Size = new Size(0x57, 20);
            this.dtpLogDate.TabIndex = 0x12;
            this.dtpLogDate.ValueChanged += new EventHandler(this.dtpLogDate_ValueChanged);
            this.groupBox4.Controls.Add(this.btnExit);
            this.groupBox4.Controls.Add(this.btnRemoveSelected);
            this.groupBox4.Controls.Add(this.btnEntrySelected);
            this.groupBox4.Controls.Add(this.btnRemoveAll);
            this.groupBox4.Controls.Add(this.btnEntryAll);
            this.groupBox4.Controls.Add(this.btnRemove);
            this.groupBox4.Controls.Add(this.btnNew);
            this.groupBox4.Controls.Add(this.btnSave);
            this.groupBox4.Location = new Point(0x155, 0x112);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new Size(0xff, 0x84);
            this.groupBox4.TabIndex = 11;
            this.groupBox4.TabStop = false;
            this.btnExit.Location = new Point(0x5b, 0x67);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new Size(0x4b, 0x17);
            this.btnExit.TabIndex = 0x1c;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new EventHandler(this.btnExit_Click);
            this.btnRemoveSelected.Location = new Point(0x83, 0x4c);
            this.btnRemoveSelected.Name = "btnRemoveSelected";
            this.btnRemoveSelected.Size = new Size(0x74, 0x17);
            this.btnRemoveSelected.TabIndex = 0x1b;
            this.btnRemoveSelected.Text = "Remove Selected";
            this.btnRemoveSelected.UseVisualStyleBackColor = true;
            this.btnRemoveSelected.Click += new EventHandler(this.btnRemoveSelected_Click);
            this.btnEntrySelected.Location = new Point(8, 0x4c);
            this.btnEntrySelected.Name = "btnEntrySelected";
            this.btnEntrySelected.Size = new Size(0x74, 0x17);
            this.btnEntrySelected.TabIndex = 0x1a;
            this.btnEntrySelected.Text = "Entry For Selected";
            this.btnEntrySelected.UseVisualStyleBackColor = true;
            this.btnEntrySelected.Click += new EventHandler(this.btnEntrySelected_Click);
            this.btnRemoveAll.Location = new Point(130, 0x2f);
            this.btnRemoveAll.Name = "btnRemoveAll";
            this.btnRemoveAll.Size = new Size(0x74, 0x17);
            this.btnRemoveAll.TabIndex = 0x19;
            this.btnRemoveAll.Text = "Remove All";
            this.btnRemoveAll.UseVisualStyleBackColor = true;
            this.btnRemoveAll.Click += new EventHandler(this.btnRemoveAll_Click);
            this.btnEntryAll.Location = new Point(8, 0x2f);
            this.btnEntryAll.Name = "btnEntryAll";
            this.btnEntryAll.Size = new Size(0x74, 0x17);
            this.btnEntryAll.TabIndex = 0x18;
            this.btnEntryAll.Text = "Entry For All";
            this.btnEntryAll.UseVisualStyleBackColor = true;
            this.btnEntryAll.Click += new EventHandler(this.btnEntryAll_Click);
            this.btnRemove.Location = new Point(0xac, 0x12);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new Size(0x4b, 0x17);
            this.btnRemove.TabIndex = 0x17;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new EventHandler(this.btnRemove_Click);
            this.btnNew.Location = new Point(8, 0x12);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new Size(0x4b, 0x17);
            this.btnNew.TabIndex = 0x16;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new EventHandler(this.btnNew_Click);
            this.btnSave.Location = new Point(0x5b, 0x12);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new Size(0x4b, 0x17);
            this.btnSave.TabIndex = 0x15;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new EventHandler(this.btnSave_Click);
            this.grpDatetime.Controls.Add(this.label1);
            this.grpDatetime.Controls.Add(this.dtpLogTime);
            this.grpDatetime.Controls.Add(this.dgvLogTime);
            this.grpDatetime.Location = new Point(0x155, 0x2d);
            this.grpDatetime.Name = "grpDatetime";
            this.grpDatetime.Size = new Size(0xff, 0xdf);
            this.grpDatetime.TabIndex = 10;
            this.grpDatetime.TabStop = false;
            this.grpDatetime.Visible = false;
            this.label1.AutoSize = true;
            this.label1.BackColor = Color.Transparent;
            this.label1.Location = new Point(0x16, 14);
            this.label1.Name = "label1";
            this.label1.Size = new Size(30, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Time";
            this.dtpLogTime.Format = DateTimePickerFormat.Time;
            this.dtpLogTime.Location = new Point(0x43, 10);
            this.dtpLogTime.Name = "dtpLogTime";
            this.dtpLogTime.ShowUpDown = true;
            this.dtpLogTime.Size = new Size(0x57, 20);
            this.dtpLogTime.TabIndex = 11;
            this.dtpLogTime.KeyPress += new KeyPressEventHandler(this.dtpLogTime_KeyPress);
            this.dgvLogTime.AllowUserToAddRows = false;
            this.dgvLogTime.AllowUserToDeleteRows = false;
            this.dgvLogTime.AllowUserToResizeColumns = false;
            this.dgvLogTime.AllowUserToResizeRows = false;
            style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            style.BackColor = SystemColors.Control;
            style.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            style.ForeColor = SystemColors.WindowText;
            style.SelectionBackColor = SystemColors.Highlight;
            style.SelectionForeColor = SystemColors.HighlightText;
            style.WrapMode = DataGridViewTriState.True;
            this.dgvLogTime.ColumnHeadersDefaultCellStyle = style;
            this.dgvLogTime.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLogTime.Columns.AddRange(new DataGridViewColumn[] { this.dataGridViewTextBoxColumn1 });
            this.dgvLogTime.Location = new Point(0x43, 0x24);
            this.dgvLogTime.Name = "dgvLogTime";
            this.dgvLogTime.RowHeadersVisible = false;
            this.dgvLogTime.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvLogTime.Size = new Size(0x57, 0xb5);
            this.dgvLogTime.TabIndex = 0x11;
            this.dgvLogTime.Visible = false;
            style2.Alignment = DataGridViewContentAlignment.TopLeft;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = style2;
            this.dataGridViewTextBoxColumn1.HeaderText = "Log Time";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 0x4b;
            this.dgvEmployee.AllowUserToAddRows = false;
            this.dgvEmployee.AllowUserToDeleteRows = false;
            this.dgvEmployee.AllowUserToResizeColumns = false;
            this.dgvEmployee.AllowUserToResizeRows = false;
            style3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            style3.BackColor = SystemColors.Control;
            style3.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            style3.ForeColor = SystemColors.WindowText;
            style3.SelectionBackColor = SystemColors.Highlight;
            style3.SelectionForeColor = SystemColors.HighlightText;
            style3.WrapMode = DataGridViewTriState.True;
            this.dgvEmployee.ColumnHeadersDefaultCellStyle = style3;
            this.dgvEmployee.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmployee.Columns.AddRange(new DataGridViewColumn[] { this.clmNumber, this.clmEmpName });
            this.dgvEmployee.Location = new Point(3, 15);
            this.dgvEmployee.Name = "dgvEmployee";
            this.dgvEmployee.RowHeadersVisible = false;
            this.dgvEmployee.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvEmployee.Size = new Size(0x149, 0x185);
            this.dgvEmployee.TabIndex = 0;
            this.dgvEmployee.CellClick += new DataGridViewCellEventHandler(this.dgvEmployee_CellClick);
            this.dgvEmployee.CellContentClick += new DataGridViewCellEventHandler(this.dgvEmployee_CellContentClick);
            this.groupBox1.Controls.Add(this.cmbLevel);
            this.groupBox1.Controls.Add(this.cmdSession);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cmdDay);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new Point(4, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(0x25b, 0x4c);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.cmbLevel.DrawMode = DrawMode.OwnerDrawVariable;
            this.cmbLevel.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbLevel.DropDownWidth = 0x11;
            this.cmbLevel.FormattingEnabled = true;
            this.cmbLevel.Location = new Point(6, 0x22);
            this.cmbLevel.Name = "cmbLevel";
            this.cmbLevel.Size = new Size(0x90, 0x15);
            this.cmbLevel.TabIndex = 230;
            this.cmbLevel.ViewColumn = 0;
            this.cmbLevel.SelectedIndexChanged += new EventHandler(this.cmbLevel_SelectedIndexChanged);
            this.cmdSession.DrawMode = DrawMode.OwnerDrawVariable;
            this.cmdSession.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmdSession.DropDownWidth = 0x11;
            this.cmdSession.FormattingEnabled = true;
            this.cmdSession.Location = new Point(0x1c7, 0x24);
            this.cmdSession.Name = "cmdSession";
            this.cmdSession.Size = new Size(0x84, 0x15);
            this.cmdSession.TabIndex = 0xe4;
            this.cmdSession.ViewColumn = 0;
            this.cmdSession.SelectedIndexChanged += new EventHandler(this.cmdSession_SelectedIndexChanged);
            this.label3.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label3.Location = new Point(0x1c4, 0x10);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x70, 0x13);
            this.label3.TabIndex = 0xe5;
            this.label3.Text = "Session";
            this.label3.TextAlign = ContentAlignment.MiddleLeft;
            this.label4.AutoSize = true;
            this.label4.Location = new Point(220, 0x13);
            this.label4.Name = "label4";
            this.label4.Size = new Size(0x1a, 13);
            this.label4.TabIndex = 0xe3;
            this.label4.Text = "Day";
            this.cmdDay.DrawMode = DrawMode.OwnerDrawVariable;
            this.cmdDay.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmdDay.DropDownWidth = 0x11;
            this.cmdDay.FormattingEnabled = true;
            this.cmdDay.Location = new Point(0xdf, 0x24);
            this.cmdDay.Name = "cmdDay";
            this.cmdDay.Size = new Size(0x90, 0x15);
            this.cmdDay.TabIndex = 0xe2;
            this.cmdDay.ViewColumn = 0;
            this.cmdDay.SelectedIndexChanged += new EventHandler(this.cmdDay_SelectedIndexChanged);
            this.label5.AutoSize = true;
            this.label5.Location = new Point(8, 0x10);
            this.label5.Name = "label5";
            this.label5.Size = new Size(0x21, 13);
            this.label5.TabIndex = 0xe1;
            this.label5.Text = "Level";
            this.errManualLogentry.ContainerControl = this;
            style4.Alignment = DataGridViewContentAlignment.TopLeft;
            this.clmNumber.DefaultCellStyle = style4;
            this.clmNumber.HeaderText = "Number";
            this.clmNumber.Name = "clmNumber";
            this.clmNumber.ReadOnly = true;
            this.clmNumber.Width = 0x4b;
            style5.Alignment = DataGridViewContentAlignment.TopLeft;
            this.clmEmpName.DefaultCellStyle = style5;
            this.clmEmpName.HeaderText = "Student Name";
            this.clmEmpName.Name = "clmEmpName";
            this.clmEmpName.ReadOnly = true;
            this.clmEmpName.Width = 250;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            base.ClientSize = new Size(0x268, 0x200);
            base.Controls.Add(this.groupBox2);
            base.Controls.Add(this.groupBox1);
            base.FormBorderStyle = FormBorderStyle.FixedSingle;
            base.MaximizeBox = false;
            base.Name = "frmManualLogEntry";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Manual LogEntry";
            base.Load += new EventHandler(this.frmManualLogEntry_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.grpDatetime.ResumeLayout(false);
            this.grpDatetime.PerformLayout();
            ((ISupportInitialize) this.dgvLogTime).EndInit();
            ((ISupportInitialize) this.dgvEmployee).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((ISupportInitialize) this.errManualLogentry).EndInit();
            base.ResumeLayout(false);
        }

        private void InsertUpdateData(string strStudentNo, DateTime dtLogDate, DateTime dtLogTime)
        {
            this.oBeadBarcode.LocationCode = this.cGlobalVariable.LocationCode;
            this.oBeadBarcode.StudentNo = strStudentNo.ToString();
            this.oBeadBarcode.LogDate = dtLogDate;
            this.oBeadBarcode.LogTime = dtLogTime;
            this.cBeadBarcode.InsertUpdate(this.oBeadBarcode);
        }

        public void Show_Employees_Grid()
        {
            this.dgvEmployee.Rows.Clear();
            DataTable table = this.cStudentMaster.GetStudentData(this.cGlobalVariable.LocationCode, this.oManualLogEntry.ClassCode, this.cGlobalVariable.ActiveStatusCode);
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i <= (table.Rows.Count - 1); i++)
                {
                    if (this.cClassTimeTable.GetClassDetails(this.cGlobalVariable.LocationCode, table.Rows[i][2].ToString(), this.oManualLogEntry.DayType, this.oManualLogEntry.DaySession).Rows.Count > 0)
                    {
                        int count = this.dgvEmployee.Rows.Count;
                        this.dgvEmployee.Rows.Add(1);
                        this.dgvEmployee.Rows[count].Cells[0].Value = table.Rows[i][2].ToString();
                        this.dgvEmployee.Rows[count].Cells[1].Value = table.Rows[i][3].ToString();
                    }
                }
            }
        }
    }
}

