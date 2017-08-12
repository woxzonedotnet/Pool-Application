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

    public class frmEmployeeWorkingDays : Form
    {
        private Button btnAssingalongtheColumn;
        private Button btnAssingalongtheRow;
        private Button btnClearAll;
        public Button btnClose;
        public Button btnSave;
        private Button btnSelectAll;
        private clsClassMaster cClassMaster = new clsClassMaster();
        private clsClassTimeTable cClassTimeTable = new clsClassTimeTable();
        private clsCommenMethods cCommen = new clsCommenMethods();
        private clsEmployeeWorkingDays cEmployeeWorkingDays = new clsEmployeeWorkingDays();
        private clsGlobleVariable cGlobleVariable = new clsGlobleVariable();
        private CheckBox chkDayOff;
        private clsHoloidayCalender cHoloidayCalender = new clsHoloidayCalender();
        private DataGridViewTextBoxColumn clmEmpName;
        private DataGridViewTextBoxColumn clmNumber;
        private Color clrCalenderColor = Color.BurlyWood;
        private Color clrMechantileHolidayColor = Color.Green;
        private Color clrPoyadayColor = Color.Yellow;
        private Color clrSpecialHolodayColor = Color.Pink;
        private Color clrWorkingDay = Color.DarkOrange;
        private ColumnComboBox cmbClassName;
        private DataGridViewTextBoxColumn Column1;
        private IContainer components = null;
        private clsStudentMaster cStudentMaster = new clsStudentMaster();
        private DataGridView dgvMonths;
        private DataGridView dgvStudent;
        private DateTimePicker FromDate;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private int iMouseDownColumn;
        private int iMouseDownRow;
        private int iMouseUpColumn;
        private int iMouseUpRow;
        private Label label1;
        private Label label2;
        private Label lblDayOff;
        private Label lblFrom;
        private Label lblTo;
        private objEmployeeWorkingDays oEmployeeWorkingDays = new objEmployeeWorkingDays();
        private objStudentMaster oStudentMaster = new objStudentMaster();
        private ProgressBar prgProgressBar;
        private string strMechantileHolidayCode = "MH";
        private string strPoyadayCode = "PD";
        private string strSpecialHolodayCode = "SH";
        private string strWorkingDay = "WD";
        private DateTimePicker TODate;

        public frmEmployeeWorkingDays()
        {
            this.InitializeComponent();
        }

        private void btnAssingalongtheColumn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.dgvMonths.Rows.Count; i++)
            {
                this.SetGrid(i, this.dgvMonths.CurrentCell.ColumnIndex);
            }
        }

        private void btnAssingalongtheRow_Click(object sender, EventArgs e)
        {
            for (int i = 2; i < this.dgvMonths.Columns.Count; i++)
            {
                this.SetGrid(this.dgvMonths.CurrentCell.RowIndex, i);
            }
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            this.EmployeeChecked("False");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= (this.dgvStudent.Rows.Count - 1); i++)
            {
                if (Convert.ToBoolean(this.dgvStudent.Rows[i].Cells[0].Value))
                {
                    this.oEmployeeWorkingDays.EmployeeCode = this.dgvStudent.Rows[i].Cells[1].Value.ToString();
                    this.InsertUpdateData();
                }
            }
            MessageBox.Show("Successfully Saved...!", "Employee Working Days", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            this.EmployeeChecked("True");
        }

        private Color DayBackColour(string DayType)
        {
            if (DayType == this.strMechantileHolidayCode)
            {
                return this.clrMechantileHolidayColor;
            }
            if (DayType == this.strPoyadayCode)
            {
                return this.clrPoyadayColor;
            }
            if (DayType == this.strSpecialHolodayCode)
            {
                return this.clrSpecialHolodayColor;
            }
            if (DayType == this.strWorkingDay)
            {
                return this.clrWorkingDay;
            }
            return this.clrCalenderColor;
        }

        private void dgvMonths_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.iMouseDownColumn = e.ColumnIndex;
            this.iMouseDownRow = e.RowIndex;
        }

        private void dgvMonths_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if ((e.RowIndex > -1) && (e.ColumnIndex > 1))
            {
                this.iMouseUpColumn = e.ColumnIndex;
                this.iMouseUpRow = e.RowIndex;
                if (this.iMouseDownColumn == this.iMouseUpColumn)
                {
                    for (int i = this.iMouseDownRow; i <= this.iMouseUpRow; i++)
                    {
                        this.SetGrid(i, this.iMouseUpColumn);
                    }
                }
                else if (this.iMouseDownRow == this.iMouseUpRow)
                {
                    for (int j = this.iMouseDownColumn; j <= this.iMouseUpColumn; j++)
                    {
                        this.SetGrid(this.iMouseDownRow, j);
                    }
                }
            }
        }

        private void dgvStudent_MouseClick(object sender, MouseEventArgs e)
        {
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        public void EmployeeChecked(string strChecked)
        {
            for (int i = 0; i <= (this.dgvStudent.Rows.Count - 1); i++)
            {
                this.dgvStudent.Rows[i].Cells[0].Value = strChecked;
            }
        }

        private void frmEmployeeWorkingDays_Load(object sender, EventArgs e)
        {
            this.LoadStudent();
            this.FromDate.Value = this.cCommen.ConvertDateTime("01/01/" + DateTime.Today.Year);
            this.TODate.Value = this.cCommen.ConvertDateTime("31/12/" + DateTime.Today.Year);
            this.LoadCalendar();
        }

        private void FromDate_ValueChanged(object sender, EventArgs e)
        {
            this.LoadCalendar();
        }

        private void InitializeComponent()
        {
            DataGridViewCellStyle style = new DataGridViewCellStyle();
            DataGridViewCellStyle style2 = new DataGridViewCellStyle();
            DataGridViewCellStyle style3 = new DataGridViewCellStyle();
            ComponentResourceManager manager = new ComponentResourceManager(typeof(frmEmployeeWorkingDays));
            this.dgvMonths = new DataGridView();
            this.dgvStudent = new DataGridView();
            this.clmNumber = new DataGridViewTextBoxColumn();
            this.clmEmpName = new DataGridViewTextBoxColumn();
            this.Column1 = new DataGridViewTextBoxColumn();
            this.groupBox3 = new GroupBox();
            this.prgProgressBar = new ProgressBar();
            this.groupBox2 = new GroupBox();
            this.lblTo = new Label();
            this.lblFrom = new Label();
            this.TODate = new DateTimePicker();
            this.FromDate = new DateTimePicker();
            this.groupBox1 = new GroupBox();
            this.label2 = new Label();
            this.label1 = new Label();
            this.cmbClassName = new ColumnComboBox();
            this.btnAssingalongtheColumn = new Button();
            this.btnAssingalongtheRow = new Button();
            this.btnSave = new Button();
            this.btnClose = new Button();
            this.lblDayOff = new Label();
            this.chkDayOff = new CheckBox();
            this.btnClearAll = new Button();
            this.btnSelectAll = new Button();
            ((ISupportInitialize) this.dgvMonths).BeginInit();
            ((ISupportInitialize) this.dgvStudent).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            base.SuspendLayout();
            this.dgvMonths.AllowUserToAddRows = false;
            this.dgvMonths.AllowUserToDeleteRows = false;
            this.dgvMonths.AllowUserToResizeColumns = false;
            this.dgvMonths.AllowUserToResizeRows = false;
            this.dgvMonths.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMonths.Location = new Point(0x106, 0x30);
            this.dgvMonths.Name = "dgvMonths";
            this.dgvMonths.RowHeadersVisible = false;
            this.dgvMonths.Size = new Size(0x1ca, 380);
            this.dgvMonths.TabIndex = 0x47;
            this.dgvMonths.CellMouseDown += new DataGridViewCellMouseEventHandler(this.dgvMonths_CellMouseDown);
            this.dgvMonths.CellMouseUp += new DataGridViewCellMouseEventHandler(this.dgvMonths_CellMouseUp);
            this.dgvStudent.AllowUserToAddRows = false;
            this.dgvStudent.AllowUserToDeleteRows = false;
            this.dgvStudent.AllowUserToResizeColumns = false;
            this.dgvStudent.AllowUserToResizeRows = false;
            style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            style.BackColor = SystemColors.Control;
            style.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            style.ForeColor = SystemColors.WindowText;
            style.SelectionBackColor = SystemColors.Highlight;
            style.SelectionForeColor = SystemColors.HighlightText;
            style.WrapMode = DataGridViewTriState.True;
            this.dgvStudent.ColumnHeadersDefaultCellStyle = style;
            this.dgvStudent.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStudent.Columns.AddRange(new DataGridViewColumn[] { this.clmNumber, this.clmEmpName, this.Column1 });
            this.dgvStudent.Location = new Point(3, 0x30);
            this.dgvStudent.Name = "dgvStudent";
            this.dgvStudent.RowHeadersVisible = false;
            this.dgvStudent.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvStudent.Size = new Size(0xfd, 0x15f);
            this.dgvStudent.TabIndex = 0x4a;
            this.dgvStudent.MouseClick += new MouseEventHandler(this.dgvStudent_MouseClick);
            style2.Alignment = DataGridViewContentAlignment.TopLeft;
            this.clmNumber.DefaultCellStyle = style2;
            this.clmNumber.HeaderText = "Number";
            this.clmNumber.Name = "clmNumber";
            this.clmNumber.ReadOnly = true;
            this.clmNumber.Width = 50;
            style3.Alignment = DataGridViewContentAlignment.TopLeft;
            this.clmEmpName.DefaultCellStyle = style3;
            this.clmEmpName.HeaderText = "Employee Name";
            this.clmEmpName.Name = "clmEmpName";
            this.clmEmpName.ReadOnly = true;
            this.clmEmpName.Width = 0xaf;
            this.Column1.HeaderText = "Student Class";
            this.Column1.Name = "Column1";
            this.groupBox3.BackColor = Color.Transparent;
            this.groupBox3.Controls.Add(this.prgProgressBar);
            this.groupBox3.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.groupBox3.ForeColor = Color.Transparent;
            this.groupBox3.Location = new Point(-1, 0x1b2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new Size(0x2d1, 0x24);
            this.groupBox3.TabIndex = 0x49;
            this.groupBox3.TabStop = false;
            this.prgProgressBar.Location = new Point(4, 0x10);
            this.prgProgressBar.Name = "prgProgressBar";
            this.prgProgressBar.Size = new Size(0x2cd, 14);
            this.prgProgressBar.TabIndex = 14;
            this.groupBox2.BackColor = Color.Transparent;
            this.groupBox2.Controls.Add(this.lblTo);
            this.groupBox2.Controls.Add(this.lblFrom);
            this.groupBox2.Controls.Add(this.TODate);
            this.groupBox2.Controls.Add(this.FromDate);
            this.groupBox2.Location = new Point(1, 1);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new Size(0x3a7, 0x2b);
            this.groupBox2.TabIndex = 0x48;
            this.groupBox2.TabStop = false;
            this.lblTo.AutoSize = true;
            this.lblTo.BackColor = Color.Transparent;
            this.lblTo.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.lblTo.Location = new Point(0x183, 0x15);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new Size(0x15, 13);
            this.lblTo.TabIndex = 0x4d;
            this.lblTo.Text = "To";
            this.lblFrom.AutoSize = true;
            this.lblFrom.BackColor = Color.Transparent;
            this.lblFrom.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.lblFrom.Location = new Point(0xf3, 0x15);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new Size(0x24, 13);
            this.lblFrom.TabIndex = 0x4c;
            this.lblFrom.Text = "From";
            this.TODate.CustomFormat = "dd/MM/yyyy";
            this.TODate.Format = DateTimePickerFormat.Custom;
            this.TODate.Location = new Point(0x19e, 0x11);
            this.TODate.Name = "TODate";
            this.TODate.Size = new Size(0x54, 20);
            this.TODate.TabIndex = 0x4b;
            this.TODate.Value = new DateTime(0x7d8, 12, 0x1f, 12, 0, 0, 0);
            this.TODate.ValueChanged += new EventHandler(this.TODate_ValueChanged);
            this.FromDate.CustomFormat = "dd/MM/yyyy";
            this.FromDate.Format = DateTimePickerFormat.Custom;
            this.FromDate.Location = new Point(0x11d, 0x11);
            this.FromDate.Name = "FromDate";
            this.FromDate.Size = new Size(0x54, 20);
            this.FromDate.TabIndex = 0x4a;
            this.FromDate.Value = new DateTime(0x7d8, 1, 1, 11, 0x3b, 0, 0);
            this.FromDate.ValueChanged += new EventHandler(this.FromDate_ValueChanged);
            this.groupBox1.BackColor = Color.Transparent;
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbClassName);
            this.groupBox1.Controls.Add(this.btnAssingalongtheColumn);
            this.groupBox1.Controls.Add(this.btnAssingalongtheRow);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Controls.Add(this.lblDayOff);
            this.groupBox1.Controls.Add(this.chkDayOff);
            this.groupBox1.Location = new Point(720, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(0xd8, 430);
            this.groupBox1.TabIndex = 70;
            this.groupBox1.TabStop = false;
            this.label2.AutoSize = true;
            this.label2.Location = new Point(0x10, 0x6f);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x24, 13);
            this.label2.TabIndex = 0x4f;
            this.label2.Text = "Group";
            this.label1.AutoSize = true;
            this.label1.Location = new Point(9, 0x72);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0, 13);
            this.label1.TabIndex = 0x4e;
            this.cmbClassName.DrawMode = DrawMode.OwnerDrawVariable;
            this.cmbClassName.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbClassName.DropDownWidth = 0x11;
            this.cmbClassName.FormattingEnabled = true;
            this.cmbClassName.Location = new Point(12, 130);
            this.cmbClassName.Name = "cmbClassName";
            this.cmbClassName.Size = new Size(0xc0, 0x15);
            this.cmbClassName.TabIndex = 0x44;
            this.cmbClassName.ViewColumn = 0;
            this.btnAssingalongtheColumn.Location = new Point(12, 0x4d);
            this.btnAssingalongtheColumn.Name = "btnAssingalongtheColumn";
            this.btnAssingalongtheColumn.Size = new Size(0xab, 0x15);
            this.btnAssingalongtheColumn.TabIndex = 0x43;
            this.btnAssingalongtheColumn.Text = "Assign along the column";
            this.btnAssingalongtheColumn.UseVisualStyleBackColor = true;
            this.btnAssingalongtheColumn.Click += new EventHandler(this.btnAssingalongtheColumn_Click);
            this.btnAssingalongtheRow.Location = new Point(12, 50);
            this.btnAssingalongtheRow.Name = "btnAssingalongtheRow";
            this.btnAssingalongtheRow.Size = new Size(0xab, 0x15);
            this.btnAssingalongtheRow.TabIndex = 0x42;
            this.btnAssingalongtheRow.Text = "Assign along the row";
            this.btnAssingalongtheRow.UseVisualStyleBackColor = true;
            this.btnAssingalongtheRow.Click += new EventHandler(this.btnAssingalongtheRow_Click);
            this.btnSave.Location = new Point(12, 0x157);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new Size(0x49, 0x17);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new EventHandler(this.btnSave_Click);
            this.btnClose.Location = new Point(110, 0x157);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new Size(0x49, 0x17);
            this.btnClose.TabIndex = 13;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new EventHandler(this.btnClose_Click);
            this.lblDayOff.BackColor = Color.DarkOrange;
            this.lblDayOff.BorderStyle = BorderStyle.FixedSingle;
            this.lblDayOff.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.lblDayOff.ForeColor = Color.MidnightBlue;
            this.lblDayOff.Location = new Point(0x9f, 15);
            this.lblDayOff.Name = "lblDayOff";
            this.lblDayOff.Size = new Size(0x26, 0x18);
            this.lblDayOff.TabIndex = 0x41;
            this.lblDayOff.TextAlign = ContentAlignment.MiddleCenter;
            this.chkDayOff.AutoSize = true;
            this.chkDayOff.ForeColor = SystemColors.Highlight;
            this.chkDayOff.Location = new Point(12, 0x13);
            this.chkDayOff.Name = "chkDayOff";
            this.chkDayOff.Size = new Size(0x8d, 0x11);
            this.chkDayOff.TabIndex = 0x40;
            this.chkDayOff.Text = "Expected To be Present\r\n";
            this.chkDayOff.UseVisualStyleBackColor = true;
            this.btnClearAll.Location = new Point(0x4e, 0x195);
            this.btnClearAll.Name = "btnClearAll";
            this.btnClearAll.Size = new Size(0x45, 0x17);
            this.btnClearAll.TabIndex = 0x4c;
            this.btnClearAll.Text = "Clear All";
            this.btnClearAll.UseVisualStyleBackColor = true;
            this.btnClearAll.Click += new EventHandler(this.btnClearAll_Click);
            this.btnSelectAll.Location = new Point(3, 0x195);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new Size(0x45, 0x17);
            this.btnSelectAll.TabIndex = 0x4b;
            this.btnSelectAll.Text = "Select All";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new EventHandler(this.btnSelectAll_Click);
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x3a6, 470);
            base.Controls.Add(this.btnClearAll);
            base.Controls.Add(this.btnSelectAll);
            base.Controls.Add(this.dgvStudent);
            base.Controls.Add(this.groupBox3);
            base.Controls.Add(this.groupBox2);
            base.Controls.Add(this.groupBox1);
            base.Controls.Add(this.dgvMonths);
            base.FormBorderStyle = FormBorderStyle.FixedSingle;
            base.MaximizeBox = false;
            base.Name = "frmEmployeeWorkingDays";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Employee Working Calendar";
            base.Load += new EventHandler(this.frmEmployeeWorkingDays_Load);
            ((ISupportInitialize) this.dgvMonths).EndInit();
            ((ISupportInitialize) this.dgvStudent).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            base.ResumeLayout(false);
        }

        private void InsertUpdateData()
        {
            this.oEmployeeWorkingDays.LocationCode = this.cGlobleVariable.LocationCode;
            this.prgProgressBar.Maximum = this.dgvMonths.Rows.Count;
            this.prgProgressBar.Value = 0;
            for (int i = 0; i < this.dgvMonths.Rows.Count; i++)
            {
                this.prgProgressBar.Value++;
                for (int j = 3; j < 40; j++)
                {
                    if (this.dgvMonths.Rows[i].Cells[j].Value != null)
                    {
                        DateTime time = new DateTime(Convert.ToInt16(this.dgvMonths.Rows[i].Cells[2].Value), Convert.ToInt16(this.dgvMonths.Rows[i].Cells[1].Value), Convert.ToInt16(this.dgvMonths.Rows[i].Cells[j].Value));
                        string str = string.Concat(new object[] { this.dgvMonths.Rows[i].Cells[j].Value, "/", time.ToString("MMM"), "/", this.dgvMonths.Rows[i].Cells[2].Value });
                        this.oEmployeeWorkingDays.WorkingDate = Convert.ToDateTime(str);
                        if (this.dgvMonths.Rows[i].Cells[j].Style.BackColor == this.lblDayOff.BackColor)
                        {
                            this.oEmployeeWorkingDays.DayType = "WD";
                        }
                        else
                        {
                            this.oEmployeeWorkingDays.DayType = this.dgvMonths.Rows[i].Cells[j].Tag.ToString();
                        }
                        this.cEmployeeWorkingDays.InsertUpdateData(this.oEmployeeWorkingDays);
                    }
                }
            }
        }

        private void LoadCalendar()
        {
            this.dgvMonths.RowCount = 1;
            this.dgvMonths.ColumnCount = 0;
            this.dgvMonths.Columns.Add("A", "Month");
            this.dgvMonths.Columns.Add("Month", "Month");
            this.dgvMonths.Columns.Add("Year", "Year");
            this.dgvMonths.Columns[0].Frozen = true;
            this.dgvMonths.Columns[1].Visible = false;
            this.dgvMonths.Columns[2].Visible = false;
            for (int i = 3; i < 9; i++)
            {
                if (this.dgvMonths.Columns.Count < 40)
                {
                    this.dgvMonths.Columns.Add("Sunday", "S");
                }
                if (this.dgvMonths.Columns.Count < 40)
                {
                    this.dgvMonths.Columns.Add("Monday", "M");
                }
                if (this.dgvMonths.Columns.Count < 40)
                {
                    this.dgvMonths.Columns.Add("Tuesday", "T");
                }
                if (this.dgvMonths.Columns.Count < 40)
                {
                    this.dgvMonths.Columns.Add("Wednesday", "W");
                }
                if (this.dgvMonths.Columns.Count < 40)
                {
                    this.dgvMonths.Columns.Add("Thursday", "T");
                }
                if (this.dgvMonths.Columns.Count < 40)
                {
                    this.dgvMonths.Columns.Add("Friday", "F");
                }
                if (this.dgvMonths.Columns.Count < 40)
                {
                    this.dgvMonths.Columns.Add("Saturday", "S");
                }
            }
            for (int j = 3; j < 40; j++)
            {
                this.dgvMonths.Columns[j].Width = 0x19;
                this.dgvMonths.Columns[j].ReadOnly = true;
            }
            DateTime time = this.cCommen.ConvertDateTime(this.FromDate.Text.ToString());
            DateTime time2 = this.cCommen.ConvertDateTime(this.TODate.Value.ToString("dd/MM/yyyy"));
            this.dgvMonths.GridColor = Color.Silver;
            int num3 = 0;
            DateTime time3 = time;
            while (time3 <= time2)
            {
                this.dgvMonths.Rows.Add(1);
                this.dgvMonths.Rows[num3].Cells[0].Value = string.Format("{0:MMMM/yyyy}", time3);
                this.dgvMonths.Rows[num3].Cells[0].Style.ForeColor = Color.Indigo;
                this.dgvMonths.Rows[num3].Cells[0].Style.BackColor = Color.Silver;
                this.dgvMonths.Rows[num3].Cells[1].Value = time3.Month;
                this.dgvMonths.Rows[num3].Cells[2].Value = time3.Year;
                int num4 = 3;
                Color black = Color.Black;
                if (time3.DayOfWeek.ToString() == "Sunday")
                {
                    num4 = 3;
                }
                if (time3.DayOfWeek.ToString() == "Monday")
                {
                    num4 = 4;
                }
                if (time3.DayOfWeek.ToString() == "Tuesday")
                {
                    num4 = 5;
                }
                if (time3.DayOfWeek.ToString() == "Wednesday")
                {
                    num4 = 6;
                }
                if (time3.DayOfWeek.ToString() == "Thursday")
                {
                    num4 = 7;
                }
                if (time3.DayOfWeek.ToString() == "Friday")
                {
                    num4 = 8;
                }
                if (time3.DayOfWeek.ToString() == "Saturday")
                {
                    num4 = 9;
                }
                DateTime time4 = time3;
                for (int k = 3; k < 40; k++)
                {
                    this.dgvMonths.Rows[num3].Cells[k].Style.BackColor = Color.BurlyWood;
                }
                DateTime dtDate = time3;
                while (dtDate < time4.AddMonths(1))
                {
                    this.dgvMonths.Rows[num3].Cells[num4].Value = dtDate.Day.ToString();
                    if (dtDate.DayOfWeek.ToString() == "Sunday")
                    {
                        black = Color.Red;
                    }
                    if (dtDate.DayOfWeek.ToString() == "Monday")
                    {
                        black = Color.Black;
                    }
                    if (dtDate.DayOfWeek.ToString() == "Tuesday")
                    {
                        black = Color.Black;
                    }
                    if (dtDate.DayOfWeek.ToString() == "Wednesday")
                    {
                        black = Color.Black;
                    }
                    if (dtDate.DayOfWeek.ToString() == "Thursday")
                    {
                        black = Color.Black;
                    }
                    if (dtDate.DayOfWeek.ToString() == "Friday")
                    {
                        black = Color.Black;
                    }
                    if (dtDate.DayOfWeek.ToString() == "Saturday")
                    {
                        black = Color.Blue;
                    }
                    this.dgvMonths.Rows[num3].Cells[num4].Style.ForeColor = black;
                    DataTable dayType = this.cHoloidayCalender.GetDayType(this.cGlobleVariable.LocationCode, dtDate);
                    if (dayType.Rows.Count > 0)
                    {
                        this.dgvMonths.Rows[num3].Cells[num4].Style.BackColor = this.DayBackColour(dayType.Rows[0][2].ToString());
                        this.dgvMonths.Rows[num3].Cells[num4].Tag = dayType.Rows[0][2].ToString();
                    }
                    DataTable table2 = this.cEmployeeWorkingDays.GetWorkingDays(this.cGlobleVariable.LocationCode, this.oStudentMaster.StudentNo, dtDate);
                    if (table2.Rows.Count > 0)
                    {
                        this.dgvMonths.Rows[num3].Cells[num4].Style.BackColor = this.DayBackColour(table2.Rows[0][3].ToString());
                    }
                    dtDate = dtDate.AddDays(1.0);
                    num4++;
                }
                time3 = time3.AddMonths(1);
                num3++;
            }
        }

        private void LoadStudent()
        {
            this.dgvStudent.Rows.Clear();
            DataTable studentData = this.cStudentMaster.GetStudentData(this.cGlobleVariable.LocationCode);
            for (int i = 0; i < studentData.Rows.Count; i++)
            {
                this.dgvStudent.Rows.Add(1);
                this.dgvStudent.Rows[i].Cells[0].Value = studentData.Rows[i][2].ToString();
                this.dgvStudent.Rows[i].Cells[1].Value = studentData.Rows[i][4].ToString() + " " + studentData.Rows[i][6].ToString();
                this.dgvStudent.Rows[i].Cells[2].Value = this.cClassMaster.GetClassData(this.cGlobleVariable.LocationCode, studentData.Rows[i][14].ToString()).ClassName;
            }
        }

        private void SetGrid(int iRowIndex, int iColumnIndex)
        {
            if (this.chkDayOff.Checked)
            {
                if (this.dgvMonths.Rows[iRowIndex].Cells[iColumnIndex].Value != null)
                {
                    this.dgvMonths.Rows[iRowIndex].Cells[iColumnIndex].Style.BackColor = this.lblDayOff.BackColor;
                }
            }
            else if (this.dgvMonths.Rows[iRowIndex].Cells[iColumnIndex].Value != null)
            {
                if (((Convert.ToString(this.dgvMonths.Rows[iRowIndex].Cells[iColumnIndex].Tag) == "MH") || (Convert.ToString(this.dgvMonths.Rows[iRowIndex].Cells[iColumnIndex].Tag) == "PD")) || (Convert.ToString(this.dgvMonths.Rows[iRowIndex].Cells[iColumnIndex].Tag) == "SH"))
                {
                    this.dgvMonths.Rows[iRowIndex].Cells[iColumnIndex].Style.BackColor = this.DayBackColour(Convert.ToString(this.dgvMonths.Rows[iRowIndex].Cells[iColumnIndex].Tag));
                }
                else
                {
                    this.dgvMonths.Rows[iRowIndex].Cells[iColumnIndex].Style.BackColor = Color.BurlyWood;
                }
            }
        }

        private void TODate_ValueChanged(object sender, EventArgs e)
        {
            this.LoadCalendar();
        }
    }
}

