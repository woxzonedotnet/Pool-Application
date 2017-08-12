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

    public class frmAttendanceProcess : Form
    {
        private Button btnClearAll;
        private Button btnExit;
        private Button btnProcess;
        private Button btnSelectAll;
        private clsAttendanceProcess cAttendanceProcess = new clsAttendanceProcess();
        private clsAuditLog cAuditLog = new clsAuditLog();
        private clsClassMaster cClassMaster = new clsClassMaster();
        private clsClassTimeTable cClassTimeTable = new clsClassTimeTable();
        private clsCommenMethods cCommenMethod = new clsCommenMethods();
        private clsDayTypes cDayTypes = new clsDayTypes();
        private clsGlobleVariable cGlobleVariable = new clsGlobleVariable();
        private ColumnComboBox cmbLevel;
        private ColumnComboBox cmdDay;
        private ColumnComboBox cmdSession;
        private DataGridViewCheckBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private IContainer components = null;
        private clsStudentMaster cStudentMaster = new clsStudentMaster();
        private DataGridView dgvStudent;
        private DateTimePicker dtpFromDate;
        private DateTimePicker dtpToDate;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private objAttendanceProcess oAttendanceProcess = new objAttendanceProcess();
        private objAuditLog oAuditLog = new objAuditLog();
        private Panel panel1;
        private Panel panel2;
        private ProgressBar prgProgress;
        private string strProcessResult = string.Empty;

        public frmAttendanceProcess()
        {
            this.InitializeComponent();
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= (this.dgvStudent.Rows.Count - 1); i++)
            {
                this.dgvStudent.Rows[i].Cells[0].Value = "false";
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.oAuditLog.LocationCode = this.cGlobleVariable.LocationCode;
            this.oAuditLog.UserID = this.cGlobleVariable.CurrentUserID;
            this.oAuditLog.MachineID = clsGlobleVariable.MachineID;
            this.oAuditLog.DateEntered = Convert.ToDateTime(this.cAuditLog.getCurrentDate().Rows[0][0].ToString());
            this.oAuditLog.TimeEntered = Convert.ToDateTime(this.cAuditLog.getCurrentTime().Rows[0][0].ToString());
            this.oAuditLog.Task = "Exited Student Process Entry";
            this.cAuditLog.AuditLog(this.oAuditLog);
            base.Close();
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            this.prgProgress.Value = 0;
            TimeSpan span = (TimeSpan) (this.dtpToDate.Value - this.dtpFromDate.Value);
            int num = Convert.ToInt32(span.Days);
            this.prgProgress.Maximum = num + 1;
            this.oAttendanceProcess.LocationCode = this.cGlobleVariable.LocationCode;
            for (DateTime time = this.dtpFromDate.Value; time <= this.dtpToDate.Value; time = time.AddDays(1.0))
            {
                this.prgProgress.Value++;
                this.oAttendanceProcess.AttendanceDate = time;
                for (int i = 0; i < this.dgvStudent.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(this.dgvStudent.Rows[i].Cells[0].Value))
                    {
                        this.oAttendanceProcess.StudentNo = this.dgvStudent.Rows[i].Cells[1].Value.ToString();
                        DataTable table = this.cAttendanceProcess.AttendanceProcess(this.oAttendanceProcess);
                        for (int j = 0; j < (table.Rows.Count - 1); j++)
                        {
                            this.strProcessResult = this.strProcessResult + table.Rows[j][1].ToString() + "\n";
                        }
                    }
                }
            }
            this.oAuditLog.LocationCode = this.cGlobleVariable.LocationCode;
            this.oAuditLog.UserID = this.cGlobleVariable.CurrentUserID;
            this.oAuditLog.MachineID = clsGlobleVariable.MachineID;
            this.oAuditLog.DateEntered = Convert.ToDateTime(this.cAuditLog.getCurrentDate().Rows[0][0].ToString());
            this.oAuditLog.TimeEntered = Convert.ToDateTime(this.cAuditLog.getCurrentTime().Rows[0][0].ToString());
            this.oAuditLog.Task = "Processed Date From " + this.dtpFromDate.Value.ToString() + " To " + this.dtpToDate.Value.ToString() + " For Level: " + this.cmbLevel["fldClassName"].ToString() + ", Day: " + this.cmdDay["fldDay"].ToString() + " And Session: " + this.cmdSession["Column2"].ToString();
            this.cAuditLog.AuditLog(this.oAuditLog);
            MessageBox.Show("Successfully Completed", "Attendance Process", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            this.strProcessResult = string.Empty;
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= (this.dgvStudent.Rows.Count - 1); i++)
            {
                this.dgvStudent.Rows[i].Cells[0].Value = "True";
            }
        }

        private void cmbLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void cmbLevel_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (this.cmbLevel.SelectedIndex > -1)
            {
                this.oAttendanceProcess.ClassCode = this.cmbLevel["fldClassCode"].ToString();
                if (this.oAttendanceProcess.ClassCode == "$00")
                {
                    this.oAttendanceProcess.ClassCode = "%";
                }
                this.Show_Employees_Grid();
            }
        }

        private void cmdDay_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmdDay.SelectedIndex > -1)
            {
                this.oAttendanceProcess.DayType = this.cmdDay["fldDay"].ToString();
                if (this.oAttendanceProcess.DayType == "ALL")
                {
                    this.oAttendanceProcess.DayType = "%";
                }
                this.Show_Employees_Grid();
            }
        }

        private void cmdSession_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmdDay.SelectedIndex > -1)
            {
                this.oAttendanceProcess.DaySession = this.cmdSession["Column2"].ToString();
                if (this.oAttendanceProcess.DaySession == "ALL")
                {
                    this.oAttendanceProcess.DaySession = "%";
                }
                this.Show_Employees_Grid();
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

        private void frmAttendanceProcess_Load(object sender, EventArgs e)
        {
            this.dtpFromDate.CustomFormat = this.cGlobleVariable.SystemDateFormat;
            this.dtpFromDate.Format = DateTimePickerFormat.Custom;
            this.dtpToDate.CustomFormat = this.cGlobleVariable.SystemDateFormat;
            this.dtpToDate.Format = DateTimePickerFormat.Custom;
            DataTable classDetails = this.cClassMaster.GetClassDetails(this.cGlobleVariable.LocationCode, this.cGlobleVariable.ActiveStatusCode);
            DataRow row = classDetails.NewRow();
            row[0] = "0";
            row[1] = "$00";
            row[2] = "$00";
            row[3] = "ALL";
            classDetails.Rows.InsertAt(row, 0);
            this.cCommenMethod.LoadCombo(classDetails, this.cmbLevel, 3);
            if (this.cmbLevel.Items.Count > 0)
            {
                this.cmbLevel.SelectedIndex = 0;
            }
            DataTable dtFillData = this.cDayTypes.GetClassDetails();
            DataRow row2 = dtFillData.NewRow();
            row2[0] = "D";
            row2[1] = "ALL";
            dtFillData.Rows.InsertAt(row2, 0);
            this.cCommenMethod.LoadCombo(dtFillData, this.cmdDay, 1);
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
            this.cCommenMethod.LoadCombo(table3, this.cmdSession, 1);
            if (this.cmdSession.Items.Count > 0)
            {
                this.cmdSession.SelectedIndex = 0;
            }
        }

        private void InitializeComponent()
        {
            ComponentResourceManager manager = new ComponentResourceManager(typeof(frmAttendanceProcess));
            this.dgvStudent = new DataGridView();
            this.Column1 = new DataGridViewCheckBoxColumn();
            this.Column2 = new DataGridViewTextBoxColumn();
            this.Column3 = new DataGridViewTextBoxColumn();
            this.label5 = new Label();
            this.btnProcess = new Button();
            this.dtpFromDate = new DateTimePicker();
            this.dtpToDate = new DateTimePicker();
            this.prgProgress = new ProgressBar();
            this.groupBox1 = new GroupBox();
            this.btnExit = new Button();
            this.btnClearAll = new Button();
            this.btnSelectAll = new Button();
            this.groupBox2 = new GroupBox();
            this.groupBox3 = new GroupBox();
            this.cmdSession = new ColumnComboBox();
            this.label9 = new Label();
            this.label8 = new Label();
            this.cmdDay = new ColumnComboBox();
            this.cmbLevel = new ColumnComboBox();
            this.label7 = new Label();
            this.panel2 = new Panel();
            this.label3 = new Label();
            this.label4 = new Label();
            this.label6 = new Label();
            this.panel1 = new Panel();
            this.label2 = new Label();
            this.label1 = new Label();
            ((ISupportInitialize) this.dgvStudent).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            base.SuspendLayout();
            this.dgvStudent.AllowUserToAddRows = false;
            this.dgvStudent.AllowUserToDeleteRows = false;
            this.dgvStudent.AllowUserToOrderColumns = true;
            this.dgvStudent.AllowUserToResizeColumns = false;
            this.dgvStudent.AllowUserToResizeRows = false;
            this.dgvStudent.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStudent.Columns.AddRange(new DataGridViewColumn[] { this.Column1, this.Column2, this.Column3 });
            this.dgvStudent.Location = new Point(0, 8);
            this.dgvStudent.Name = "dgvStudent";
            this.dgvStudent.Size = new Size(0x231, 0x124);
            this.dgvStudent.TabIndex = 0x18;
            this.Column1.HeaderText = "";
            this.Column1.Name = "Column1";
            this.Column1.Resizable = DataGridViewTriState.True;
            this.Column1.SortMode = DataGridViewColumnSortMode.Automatic;
            this.Column1.Width = 40;
            this.Column2.HeaderText = "Student No";
            this.Column2.Name = "Column2";
            this.Column3.HeaderText = "Student Name";
            this.Column3.Name = "Column3";
            this.Column3.Resizable = DataGridViewTriState.True;
            this.Column3.SortMode = DataGridViewColumnSortMode.NotSortable;
            this.Column3.Width = 350;
            this.label5.AutoSize = true;
            this.label5.Location = new Point(0xf7, 0x41);
            this.label5.Name = "label5";
            this.label5.Size = new Size(20, 13);
            this.label5.TabIndex = 0x17;
            this.label5.Text = "To";
            this.btnProcess.Location = new Point(400, 15);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new Size(0x47, 0x17);
            this.btnProcess.TabIndex = 0x19;
            this.btnProcess.Text = "Process";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new EventHandler(this.btnProcess_Click);
            this.dtpFromDate.Format = DateTimePickerFormat.Short;
            this.dtpFromDate.Location = new Point(0x4a, 0x3d);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new Size(0x7d, 20);
            this.dtpFromDate.TabIndex = 0x1a;
            this.dtpToDate.Format = DateTimePickerFormat.Short;
            this.dtpToDate.Location = new Point(290, 0x3d);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new Size(0x7d, 20);
            this.dtpToDate.TabIndex = 0x1b;
            this.prgProgress.Location = new Point(6, 0x11);
            this.prgProgress.Name = "prgProgress";
            this.prgProgress.Size = new Size(0xef, 0x13);
            this.prgProgress.TabIndex = 0x1c;
            this.groupBox1.BackColor = Color.Transparent;
            this.groupBox1.Controls.Add(this.btnExit);
            this.groupBox1.Controls.Add(this.btnClearAll);
            this.groupBox1.Controls.Add(this.btnSelectAll);
            this.groupBox1.Controls.Add(this.prgProgress);
            this.groupBox1.Controls.Add(this.btnProcess);
            this.groupBox1.Location = new Point(0, 0x1b5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(0x231, 0x2c);
            this.groupBox1.TabIndex = 0x1d;
            this.groupBox1.TabStop = false;
            this.btnExit.Location = new Point(0x1dd, 15);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new Size(0x4b, 0x17);
            this.btnExit.TabIndex = 0x1f;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new EventHandler(this.btnExit_Click);
            this.btnClearAll.Location = new Point(0x145, 15);
            this.btnClearAll.Name = "btnClearAll";
            this.btnClearAll.Size = new Size(0x45, 0x17);
            this.btnClearAll.TabIndex = 30;
            this.btnClearAll.Text = "Clear All";
            this.btnClearAll.UseVisualStyleBackColor = true;
            this.btnClearAll.Click += new EventHandler(this.btnClearAll_Click);
            this.btnSelectAll.Location = new Point(250, 15);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new Size(0x45, 0x17);
            this.btnSelectAll.TabIndex = 0x1d;
            this.btnSelectAll.Text = "Select All";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new EventHandler(this.btnSelectAll_Click);
            this.groupBox2.BackColor = Color.Transparent;
            this.groupBox2.Controls.Add(this.dgvStudent);
            this.groupBox2.Location = new Point(0, 0x8d);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new Size(0x22d, 0x12a);
            this.groupBox2.TabIndex = 30;
            this.groupBox2.TabStop = false;
            this.groupBox3.BackColor = Color.Transparent;
            this.groupBox3.Controls.Add(this.cmdSession);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.cmdDay);
            this.groupBox3.Controls.Add(this.cmbLevel);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.panel2);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.dtpToDate);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.dtpFromDate);
            this.groupBox3.Location = new Point(0, 0x39);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new Size(0x231, 0x57);
            this.groupBox3.TabIndex = 0x1c;
            this.groupBox3.TabStop = false;
            this.cmdSession.DrawMode = DrawMode.OwnerDrawVariable;
            this.cmdSession.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmdSession.DropDownWidth = 0x11;
            this.cmdSession.FormattingEnabled = true;
            this.cmdSession.Location = new Point(400, 0x1d);
            this.cmdSession.Name = "cmdSession";
            this.cmdSession.Size = new Size(0x84, 0x15);
            this.cmdSession.TabIndex = 0xed;
            this.cmdSession.ViewColumn = 0;
            this.cmdSession.SelectedIndexChanged += new EventHandler(this.cmdSession_SelectedIndexChanged);
            this.label9.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label9.Location = new Point(0x18d, 9);
            this.label9.Name = "label9";
            this.label9.Size = new Size(0x70, 0x13);
            this.label9.TabIndex = 0xee;
            this.label9.Text = "Session";
            this.label9.TextAlign = ContentAlignment.MiddleLeft;
            this.label8.AutoSize = true;
            this.label8.Location = new Point(0xc9, 12);
            this.label8.Name = "label8";
            this.label8.Size = new Size(0x1a, 13);
            this.label8.TabIndex = 0xec;
            this.label8.Text = "Day";
            this.cmdDay.DrawMode = DrawMode.OwnerDrawVariable;
            this.cmdDay.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmdDay.DropDownWidth = 0x11;
            this.cmdDay.FormattingEnabled = true;
            this.cmdDay.Location = new Point(0xcc, 0x1d);
            this.cmdDay.Name = "cmdDay";
            this.cmdDay.Size = new Size(0x90, 0x15);
            this.cmdDay.TabIndex = 0xeb;
            this.cmdDay.ViewColumn = 0;
            this.cmdDay.SelectedIndexChanged += new EventHandler(this.cmdDay_SelectedIndexChanged);
            this.cmbLevel.DrawMode = DrawMode.OwnerDrawVariable;
            this.cmbLevel.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbLevel.DropDownWidth = 0x11;
            this.cmbLevel.FormattingEnabled = true;
            this.cmbLevel.Location = new Point(9, 0x1d);
            this.cmbLevel.Name = "cmbLevel";
            this.cmbLevel.Size = new Size(0x90, 0x15);
            this.cmbLevel.TabIndex = 0xea;
            this.cmbLevel.ViewColumn = 0;
            this.cmbLevel.SelectedIndexChanged += new EventHandler(this.cmbLevel_SelectedIndexChanged_1);
            this.label7.AutoSize = true;
            this.label7.Location = new Point(6, 12);
            this.label7.Name = "label7";
            this.label7.Size = new Size(0x21, 13);
            this.label7.TabIndex = 0xe9;
            this.label7.Text = "Level";
            this.panel2.BackColor = Color.White;
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Location = new Point(0, -60);
            this.panel2.Name = "panel2";
            this.panel2.Size = new Size(0x231, 0x3f);
            this.panel2.TabIndex = 0x1f;
            this.label3.AutoSize = true;
            this.label3.Font = new Font("Tahoma", 8f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label3.ForeColor = Color.Black;
            this.label3.Location = new Point(0x4c, 0x20);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0xb8, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "User can maintain attendance details";
            this.label4.AutoSize = true;
            this.label4.Font = new Font("Tahoma", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.label4.ForeColor = Color.Black;
            this.label4.Location = new Point(0x22, 9);
            this.label4.Name = "label4";
            this.label4.Size = new Size(0xa5, 0x13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Attendance Details";
            this.label6.AutoSize = true;
            this.label6.Location = new Point(6, 0x41);
            this.label6.Name = "label6";
            this.label6.Size = new Size(0x38, 13);
            this.label6.TabIndex = 0x16;
            this.label6.Text = "From Date";
            this.panel1.BackColor = Color.White;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(0x231, 0x3f);
            this.panel1.TabIndex = 0x1f;
            this.label2.AutoSize = true;
            this.label2.Font = new Font("Tahoma", 8f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label2.ForeColor = Color.Black;
            this.label2.Location = new Point(0x4c, 0x20);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0xb8, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "User can maintain attendance details";
            this.label1.AutoSize = true;
            this.label1.Font = new Font("Tahoma", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.label1.ForeColor = Color.Black;
            this.label1.Location = new Point(0x22, 9);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0xa5, 0x13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Attendance Details";
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = SystemColors.ActiveCaptionText;
            base.ClientSize = new Size(0x22e, 0x1e1);
            base.Controls.Add(this.panel1);
            base.Controls.Add(this.groupBox3);
            base.Controls.Add(this.groupBox2);
            base.Controls.Add(this.groupBox1);
            base.FormBorderStyle = FormBorderStyle.FixedSingle;
            base.MaximizeBox = false;
            base.Name = "frmAttendanceProcess";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Attendance Process";
            base.Load += new EventHandler(this.frmAttendanceProcess_Load);
            ((ISupportInitialize) this.dgvStudent).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            base.ResumeLayout(false);
        }

        public void Show_Employees_Grid()
        {
            this.dgvStudent.Rows.Clear();
            DataTable table = this.cStudentMaster.GetStudentData(this.cGlobleVariable.LocationCode, this.oAttendanceProcess.ClassCode, this.cGlobleVariable.ActiveStatusCode);
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i <= (table.Rows.Count - 1); i++)
                {
                    if (this.cClassTimeTable.GetClassDetails(this.cGlobleVariable.LocationCode, table.Rows[i][2].ToString(), this.oAttendanceProcess.DayType, this.oAttendanceProcess.DaySession).Rows.Count > 0)
                    {
                        int count = this.dgvStudent.Rows.Count;
                        this.dgvStudent.Rows.Add(1);
                        this.dgvStudent.Rows[count].Cells[1].Value = table.Rows[i][2].ToString();
                        this.dgvStudent.Rows[count].Cells[2].Value = table.Rows[i][3].ToString();
                    }
                }
            }
        }
    }
}

