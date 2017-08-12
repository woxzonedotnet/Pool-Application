namespace Pool_Application
{
    using Business_Layer;
    using Business_Layer.Property_Layer;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class frmHoloidayCalender : Form
    {
        public Button btnRefresh;
        public Button btnSave;
        public Button button1;
        private Color clrCalenderBackColor = Color.Silver;
        private Color clrCalenderColor = Color.BurlyWood;
        private Color clrMechantileHolidayColor = Color.Green;
        private Color clrPoyadayColor = Color.Yellow;
        private Color clrSaturdayColor = Color.Blue;
        private Color clrSpecialHolodayColor = Color.Pink;
        private Color clrSundayColor = Color.Red;
        private clsCommenMethods clsCommen = new clsCommenMethods();
        private Pool_Application.clsGlobleVariable clsGlobleVariable = new Pool_Application.clsGlobleVariable();
        private clsHoloidayCalender clsHolidayCalander = new clsHoloidayCalender();
        private IContainer components = null;
        private DataGridView dataGridView12;
        private DateTimePicker FromDate;
        private GroupBox groupBox1;
        private GroupBox grpHoliday;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label lblFrom;
        private Label lblTo;
        private objHoloidayCalender obHolidayCalander = new objHoloidayCalender();
        private RadioButton optGeneralWorkingDay;
        private RadioButton optMechantileHoliday;
        private RadioButton optPoyaday;
        private RadioButton optSaturday;
        private RadioButton optSpecialHoloday;
        private RadioButton optSunday;
        private ProgressBar prgProgress;
        private string strGeneralWorkingDayCode = "GW";
        private string strMechantileHolidayCode = "MH";
        private string strPoyadayCode = "PD";
        private string strSaturdayCode = "SAT";
        private string strSpecialHolodayCode = "SH";
        private string strSundayCode = "SUN";
        private DateTimePicker TODate;
        private TextBox txtRemarks;

        public frmHoloidayCalender()
        {
            this.InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.InsertUpdateData();
        }

        private void dataGridView12_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dataGridView12_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.grpHoliday.Visible = false;
            if ((e.ColumnIndex > 0) && (this.dataGridView12.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null))
            {
                this.grpHoliday.Visible = true;
                if (this.dataGridView12.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor == this.clrSaturdayColor)
                {
                    this.optSaturday.Select();
                }
                else if (this.dataGridView12.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor == this.clrSundayColor)
                {
                    this.optSunday.Select();
                }
                else if (this.dataGridView12.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor == this.clrMechantileHolidayColor)
                {
                    this.optMechantileHoliday.Select();
                }
                else if (this.dataGridView12.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor == this.clrPoyadayColor)
                {
                    this.optPoyaday.Select();
                }
                else if (this.dataGridView12.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor == this.clrCalenderColor)
                {
                    this.optGeneralWorkingDay.Select();
                }
                else if (this.dataGridView12.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor == this.clrSpecialHolodayColor)
                {
                    this.optSpecialHoloday.Select();
                }
                if (this.dataGridView12.Rows[e.RowIndex].Cells[e.ColumnIndex].Tag != null)
                {
                    this.txtRemarks.Text = this.dataGridView12.Rows[e.RowIndex].Cells[e.ColumnIndex].Tag.ToString();
                }
                else
                {
                    this.txtRemarks.Text = "";
                }
            }
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
            return this.clrCalenderColor;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private Color FontColour(string DayType)
        {
            if (DayType == this.strSaturdayCode)
            {
                return this.clrSaturdayColor;
            }
            if (DayType == this.strSundayCode)
            {
                return this.clrSundayColor;
            }
            return Color.Black;
        }

        private void frmHoloidayCalender_Load(object sender, EventArgs e)
        {
            this.FromDate.CustomFormat = this.clsGlobleVariable.SystemDateFormat;
            this.FromDate.Format = DateTimePickerFormat.Custom;
            this.TODate.CustomFormat = this.clsGlobleVariable.SystemDateFormat;
            this.TODate.Format = DateTimePickerFormat.Custom;
            this.LoadCalendar();
        }

        private void FromDate_ValueChanged(object sender, EventArgs e)
        {
            this.LoadCalendar();
        }

        private string GetDayType(Color clrCalanderBackColour, Color clrForeColour)
        {
            if (clrCalanderBackColour == this.clrCalenderColor)
            {
                if (clrForeColour == this.clrSaturdayColor)
                {
                    return this.strSaturdayCode;
                }
                if (clrForeColour == this.clrSundayColor)
                {
                    return this.strSundayCode;
                }
                return this.strGeneralWorkingDayCode;
            }
            if (clrCalanderBackColour == this.clrMechantileHolidayColor)
            {
                return this.strMechantileHolidayCode;
            }
            if (clrCalanderBackColour == this.clrPoyadayColor)
            {
                return this.strPoyadayCode;
            }
            if (clrCalanderBackColour == this.clrSpecialHolodayColor)
            {
                return this.strSpecialHolodayCode;
            }
            return this.strGeneralWorkingDayCode;
        }

        private void InitializeComponent()
        {
            this.dataGridView12 = new DataGridView();
            this.grpHoliday = new GroupBox();
            this.label1 = new Label();
            this.txtRemarks = new TextBox();
            this.optSunday = new RadioButton();
            this.optPoyaday = new RadioButton();
            this.optSpecialHoloday = new RadioButton();
            this.optGeneralWorkingDay = new RadioButton();
            this.optSaturday = new RadioButton();
            this.optMechantileHoliday = new RadioButton();
            this.btnSave = new Button();
            this.btnRefresh = new Button();
            this.button1 = new Button();
            this.FromDate = new DateTimePicker();
            this.TODate = new DateTimePicker();
            this.lblFrom = new Label();
            this.lblTo = new Label();
            this.prgProgress = new ProgressBar();
            this.label2 = new Label();
            this.groupBox1 = new GroupBox();
            this.label3 = new Label();
            ((ISupportInitialize) this.dataGridView12).BeginInit();
            this.grpHoliday.SuspendLayout();
            this.groupBox1.SuspendLayout();
            base.SuspendLayout();
            this.dataGridView12.AllowUserToAddRows = false;
            this.dataGridView12.AllowUserToDeleteRows = false;
            this.dataGridView12.AllowUserToOrderColumns = true;
            this.dataGridView12.AllowUserToResizeColumns = false;
            this.dataGridView12.AllowUserToResizeRows = false;
            this.dataGridView12.BackgroundColor = Color.Silver;
            this.dataGridView12.BorderStyle = BorderStyle.None;
            this.dataGridView12.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Sunken;
            this.dataGridView12.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView12.ImeMode = ImeMode.Close;
            this.dataGridView12.Location = new Point(0xbb, 0x3f);
            this.dataGridView12.MultiSelect = false;
            this.dataGridView12.Name = "dataGridView12";
            this.dataGridView12.ReadOnly = true;
            this.dataGridView12.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            this.dataGridView12.RowHeadersVisible = false;
            this.dataGridView12.Size = new Size(0x120, 0x198);
            this.dataGridView12.TabIndex = 3;
            this.dataGridView12.CellMouseClick += new DataGridViewCellMouseEventHandler(this.dataGridView12_CellMouseClick);
            this.dataGridView12.CellContentClick += new DataGridViewCellEventHandler(this.dataGridView12_CellContentClick);
            this.grpHoliday.BackColor = Color.Silver;
            this.grpHoliday.BackgroundImageLayout = ImageLayout.Stretch;
            this.grpHoliday.Controls.Add(this.label1);
            this.grpHoliday.Controls.Add(this.txtRemarks);
            this.grpHoliday.Controls.Add(this.optSunday);
            this.grpHoliday.Controls.Add(this.optPoyaday);
            this.grpHoliday.Controls.Add(this.optSpecialHoloday);
            this.grpHoliday.Controls.Add(this.optGeneralWorkingDay);
            this.grpHoliday.Controls.Add(this.optSaturday);
            this.grpHoliday.Controls.Add(this.optMechantileHoliday);
            this.grpHoliday.Location = new Point(7, 0x6f);
            this.grpHoliday.Name = "grpHoliday";
            this.grpHoliday.Size = new Size(0xae, 0x131);
            this.grpHoliday.TabIndex = 4;
            this.grpHoliday.TabStop = false;
            this.grpHoliday.Text = "Holiday";
            this.label1.AutoSize = true;
            this.label1.Location = new Point(9, 0xac);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x31, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Remarks";
            this.txtRemarks.Location = new Point(6, 0xc2);
            this.txtRemarks.MaxLength = 100;
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new Size(0x9f, 0x5f);
            this.txtRemarks.TabIndex = 6;
            this.txtRemarks.TextChanged += new EventHandler(this.txtRemarks_TextChanged);
            this.optSunday.AutoSize = true;
            this.optSunday.Location = new Point(12, 0x89);
            this.optSunday.Name = "optSunday";
            this.optSunday.Size = new Size(0x3d, 0x11);
            this.optSunday.TabIndex = 4;
            this.optSunday.TabStop = true;
            this.optSunday.Text = "Sunday";
            this.optSunday.TextImageRelation = TextImageRelation.TextBeforeImage;
            this.optSunday.UseVisualStyleBackColor = true;
            this.optSunday.CheckedChanged += new EventHandler(this.optSunday_CheckedChanged);
            this.optPoyaday.AutoSize = true;
            this.optPoyaday.Location = new Point(12, 0x2d);
            this.optPoyaday.Name = "optPoyaday";
            this.optPoyaday.Size = new Size(0x47, 0x11);
            this.optPoyaday.TabIndex = 1;
            this.optPoyaday.TabStop = true;
            this.optPoyaday.Text = "Poya Day";
            this.optPoyaday.UseVisualStyleBackColor = true;
            this.optPoyaday.CheckedChanged += new EventHandler(this.optPoyaday_CheckedChanged);
            this.optSpecialHoloday.AutoSize = true;
            this.optSpecialHoloday.Location = new Point(12, 0x5b);
            this.optSpecialHoloday.Name = "optSpecialHoloday";
            this.optSpecialHoloday.Size = new Size(0x62, 0x11);
            this.optSpecialHoloday.TabIndex = 5;
            this.optSpecialHoloday.TabStop = true;
            this.optSpecialHoloday.Text = "Special Holiday";
            this.optSpecialHoloday.UseVisualStyleBackColor = true;
            this.optSpecialHoloday.CheckedChanged += new EventHandler(this.optSpecialHoloday_CheckedChanged);
            this.optGeneralWorkingDay.AutoSize = true;
            this.optGeneralWorkingDay.Location = new Point(12, 0x16);
            this.optGeneralWorkingDay.Name = "optGeneralWorkingDay";
            this.optGeneralWorkingDay.Size = new Size(0x4c, 0x11);
            this.optGeneralWorkingDay.TabIndex = 0;
            this.optGeneralWorkingDay.TabStop = true;
            this.optGeneralWorkingDay.Text = "Week Day";
            this.optGeneralWorkingDay.TextImageRelation = TextImageRelation.ImageAboveText;
            this.optGeneralWorkingDay.UseVisualStyleBackColor = true;
            this.optGeneralWorkingDay.CheckedChanged += new EventHandler(this.optGeneralWorkingDay_CheckedChanged);
            this.optSaturday.AutoSize = true;
            this.optSaturday.Location = new Point(12, 0x72);
            this.optSaturday.Name = "optSaturday";
            this.optSaturday.Size = new Size(0x43, 0x11);
            this.optSaturday.TabIndex = 3;
            this.optSaturday.TabStop = true;
            this.optSaturday.Text = "Saturday";
            this.optSaturday.UseVisualStyleBackColor = true;
            this.optSaturday.CheckedChanged += new EventHandler(this.optSaturday_CheckedChanged);
            this.optMechantileHoliday.AutoSize = true;
            this.optMechantileHoliday.Location = new Point(12, 0x44);
            this.optMechantileHoliday.Name = "optMechantileHoliday";
            this.optMechantileHoliday.Size = new Size(0x76, 0x11);
            this.optMechantileHoliday.TabIndex = 2;
            this.optMechantileHoliday.TabStop = true;
            this.optMechantileHoliday.Text = "Merchantile Holiday";
            this.optMechantileHoliday.UseVisualStyleBackColor = true;
            this.optMechantileHoliday.CheckedChanged += new EventHandler(this.optMechantileHoliday_CheckedChanged);
            this.btnSave.Location = new Point(7, 0x1a6);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new Size(0x49, 0x17);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new EventHandler(this.btnSave_Click);
            this.btnRefresh.Location = new Point(110, 0x1a6);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new Size(0x47, 0x17);
            this.btnRefresh.TabIndex = 11;
            this.btnRefresh.Text = "&Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.button1.FlatAppearance.BorderColor = Color.FromArgb(0x40, 0x40, 0x40);
            this.button1.FlatAppearance.BorderSize = 5;
            this.button1.Location = new Point(7, 0x1c0);
            this.button1.Margin = new Padding(0);
            this.button1.Name = "button1";
            this.button1.Size = new Size(0xae, 0x17);
            this.button1.TabIndex = 12;
            this.button1.Text = "E&xit";
            this.button1.UseVisualStyleBackColor = true;
            this.FromDate.Format = DateTimePickerFormat.Short;
            this.FromDate.Location = new Point(7, 0x4e);
            this.FromDate.Name = "FromDate";
            this.FromDate.Size = new Size(0x54, 20);
            this.FromDate.TabIndex = 13;
            this.FromDate.Value = new DateTime(0x7d8, 1, 1, 11, 0x3b, 0, 0);
            this.FromDate.ValueChanged += new EventHandler(this.FromDate_ValueChanged);
            this.TODate.Format = DateTimePickerFormat.Short;
            this.TODate.Location = new Point(0x61, 0x4e);
            this.TODate.Name = "TODate";
            this.TODate.Size = new Size(0x54, 20);
            this.TODate.TabIndex = 14;
            this.TODate.Value = new DateTime(0x7d8, 12, 0x1f, 12, 0, 0, 0);
            this.TODate.ValueChanged += new EventHandler(this.TODate_ValueChanged);
            this.lblFrom.AutoSize = true;
            this.lblFrom.BackColor = Color.Transparent;
            this.lblFrom.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.lblFrom.Location = new Point(11, 0x3f);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new Size(0x24, 13);
            this.lblFrom.TabIndex = 15;
            this.lblFrom.Text = "From";
            this.lblTo.AutoSize = true;
            this.lblTo.BackColor = Color.Transparent;
            this.lblTo.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.lblTo.Location = new Point(0x65, 0x3d);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new Size(0x15, 13);
            this.lblTo.TabIndex = 0x10;
            this.lblTo.Text = "To";
            this.prgProgress.BackColor = Color.SlateGray;
            this.prgProgress.ForeColor = SystemColors.HighlightText;
            this.prgProgress.Location = new Point(7, 0x1dd);
            this.prgProgress.Name = "prgProgress";
            this.prgProgress.Size = new Size(0x1d5, 13);
            this.prgProgress.Style = ProgressBarStyle.Continuous;
            this.prgProgress.TabIndex = 0x11;
            this.label2.AutoSize = true;
            this.label2.BackColor = Color.Transparent;
            this.label2.Font = new Font("Verdana", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.label2.ForeColor = Color.Black;
            this.label2.Location = new Point(0x16, 11);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x9c, 0x12);
            this.label2.TabIndex = 0x13;
            this.label2.Text = "Holiday Calendar";
            this.groupBox1.BackColor = Color.White;
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new Point(3, -2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(0x1e2, 0x3b);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.label3.AutoSize = true;
            this.label3.BackColor = Color.Transparent;
            this.label3.Font = new Font("Microsoft Sans Serif", 8f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label3.ForeColor = Color.Black;
            this.label3.Location = new Point(0x4e, 0x25);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x87, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "User can maintain Holidays";
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.Silver;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            base.ClientSize = new Size(0x1e4, 0x1f1);
            base.Controls.Add(this.groupBox1);
            base.Controls.Add(this.prgProgress);
            base.Controls.Add(this.lblTo);
            base.Controls.Add(this.lblFrom);
            base.Controls.Add(this.TODate);
            base.Controls.Add(this.FromDate);
            base.Controls.Add(this.btnRefresh);
            base.Controls.Add(this.button1);
            base.Controls.Add(this.btnSave);
            base.Controls.Add(this.grpHoliday);
            base.Controls.Add(this.dataGridView12);
            base.FormBorderStyle = FormBorderStyle.FixedSingle;
            base.MaximizeBox = false;
            base.Name = "frmHoloidayCalender";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Holoiday Calendar";
            base.Load += new EventHandler(this.frmHoloidayCalender_Load);
            ((ISupportInitialize) this.dataGridView12).EndInit();
            this.grpHoliday.ResumeLayout(false);
            this.grpHoliday.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        private void InsertUpdateData()
        {
            this.obHolidayCalander.LocationCode = this.clsGlobleVariable.LocationCode.ToString();
            this.prgProgress.Maximum = this.dataGridView12.Rows.Count;
            this.prgProgress.Value = 0;
            for (int i = 0; i < this.dataGridView12.Rows.Count; i++)
            {
                this.prgProgress.Value++;
                for (int j = 1; j < 8; j++)
                {
                    if (this.dataGridView12.Rows[i].Cells[j].Value != null)
                    {
                        DateTime time = new DateTime(Convert.ToInt16(this.dataGridView12.Rows[i].Cells[9].Value), Convert.ToInt16(this.dataGridView12.Rows[i].Cells[8].Value), Convert.ToInt16(this.dataGridView12.Rows[i].Cells[j].Value));
                        string str = string.Concat(new object[] { this.dataGridView12.Rows[i].Cells[j].Value, "/", time.ToString("MMM"), "/", this.dataGridView12.Rows[i].Cells[9].Value });
                        this.obHolidayCalander.WorkingDate = Convert.ToDateTime(str);
                        this.obHolidayCalander.DayType = this.GetDayType(this.dataGridView12.Rows[i].Cells[j].Style.BackColor, this.dataGridView12.Rows[i].Cells[j].Style.ForeColor);
                        this.obHolidayCalander.DayRemarks = this.dataGridView12.Rows[i].Cells[j].Tag + "";
                        this.clsHolidayCalander.InsertUpdateData(this.obHolidayCalander);
                    }
                }
            }
            MessageBox.Show("Successfully Saved...!", "Holiday Calander", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void LoadCalendar()
        {
            this.dataGridView12.RowCount = 1;
            this.dataGridView12.ColumnCount = 0;
            this.dataGridView12.Columns.Add("A", "Month");
            this.dataGridView12.Columns.Add("Sunday", "S");
            this.dataGridView12.Columns.Add("Monday", "M");
            this.dataGridView12.Columns.Add("Tuesday", "T");
            this.dataGridView12.Columns.Add("Wednesday", "W");
            this.dataGridView12.Columns.Add("Thursday", "T");
            this.dataGridView12.Columns.Add("Friday", "F");
            this.dataGridView12.Columns.Add("Saturday", "S");
            this.dataGridView12.Columns.Add("Month", "Month");
            this.dataGridView12.Columns.Add("Year", "Year");
            for (int i = 1; i <= 7; i++)
            {
                this.dataGridView12.Columns[i].Width = 0x19;
            }
            this.dataGridView12.Columns[8].Visible = false;
            this.dataGridView12.Columns[9].Visible = false;
            this.dataGridView12.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.dataGridView12.Columns[0].Width = 90;
            DateTime time = this.clsCommen.ConvertDateTime(this.FromDate.Text.ToString());
            DateTime time2 = this.clsCommen.ConvertDateTime(this.TODate.Text.ToString());
            this.dataGridView12.GridColor = Color.Silver;
            int num2 = 0;
            this.dataGridView12.Rows.Add(1);
            int month = time.Month;
            this.dataGridView12.Rows[0].Cells[0].Value = string.Format("{0:MMMM/yyyy}", time);
            this.dataGridView12.Rows[0].Cells[0].Style.ForeColor = this.clrSaturdayColor;
            int num4 = 1;
            while (num4 < 8)
            {
                this.dataGridView12.Rows[0].Cells[num4].Style.BackColor = this.clrCalenderColor;
                num4++;
            }
            DateTime dtDate = time;
            while (dtDate <= time2)
            {
                int num5 = 1;
                this.obHolidayCalander = this.clsHolidayCalander.GetCalanderDetails(this.clsGlobleVariable.LocationCode, dtDate);
                if (dtDate.DayOfWeek.ToString() == "Sunday")
                {
                    num5 = 1;
                }
                if (dtDate.DayOfWeek.ToString() == "Monday")
                {
                    num5 = 2;
                }
                if (dtDate.DayOfWeek.ToString() == "Tuesday")
                {
                    num5 = 3;
                }
                if (dtDate.DayOfWeek.ToString() == "Wednesday")
                {
                    num5 = 4;
                }
                if (dtDate.DayOfWeek.ToString() == "Thursday")
                {
                    num5 = 5;
                }
                if (dtDate.DayOfWeek.ToString() == "Friday")
                {
                    num5 = 6;
                }
                if (dtDate.DayOfWeek.ToString() == "Saturday")
                {
                    num5 = 7;
                }
                this.dataGridView12.Rows[num2].Cells[num5].Value = dtDate.Day.ToString();
                this.dataGridView12.Rows[num2].Cells[num5].Style.BackColor = this.clrCalenderColor;
                this.dataGridView12.Rows[num2].Cells[8].Value = dtDate.Month;
                this.dataGridView12.Rows[num2].Cells[9].Value = dtDate.Year;
                this.dataGridView12.Rows[num2].Cells[num5].Tag = this.obHolidayCalander.DayRemarks;
                this.dataGridView12.Rows[num2].Cells[num5].Style.BackColor = this.DayBackColour(this.obHolidayCalander.DayType);
                if (this.obHolidayCalander.DayType == null)
                {
                    this.dataGridView12.Rows[num2].Cells[1].Style.ForeColor = Color.Red;
                }
                else
                {
                    this.dataGridView12.Rows[num2].Cells[num5].Style.ForeColor = this.FontColour(this.obHolidayCalander.DayType);
                }
                this.dataGridView12.Rows[num2].Cells[0].Style.BackColor = this.clrCalenderBackColor;
                this.dataGridView12.Rows[num2].Cells[0].Style.ForeColor = Color.Red;
                this.dataGridView12.ReadOnly = true;
                dtDate = dtDate.AddDays(1.0);
                if (num5 == 7)
                {
                    if (this.obHolidayCalander.DayType == null)
                    {
                        this.dataGridView12.Rows[num2].Cells[7].Style.ForeColor = Color.Blue;
                    }
                    else
                    {
                        this.dataGridView12.Rows[num2].Cells[7].Style.ForeColor = this.FontColour(this.obHolidayCalander.DayType);
                    }
                    num2++;
                    if (dtDate <= time2)
                    {
                        this.dataGridView12.Rows.Add(1);
                        num4 = 1;
                        while (num4 < 8)
                        {
                            this.dataGridView12.Rows[num2].Cells[num4].Style.BackColor = this.clrCalenderColor;
                            num4++;
                        }
                    }
                }
                if (dtDate.Month != month)
                {
                    month = dtDate.Month;
                    if (dtDate <= time2)
                    {
                        this.dataGridView12.Rows.Add(2);
                        this.dataGridView12.Rows[num2 + 2].Cells[0].Value = string.Format("{0:MMMM/yyyy}", dtDate);
                        for (num4 = 1; num4 < 8; num4++)
                        {
                            this.dataGridView12.Rows[num2 + 2].Cells[num4].Style.BackColor = this.clrCalenderColor;
                            this.dataGridView12.Rows[num2 + 1].Cells[num4].Style.BackColor = this.clrCalenderBackColor;
                        }
                        this.dataGridView12.Rows[num2 + 1].Cells[0].Style.BackColor = this.clrCalenderBackColor;
                        this.dataGridView12.Rows[num2].Cells[0].Style.BackColor = this.clrCalenderBackColor;
                    }
                    num2 += 2;
                }
            }
        }

        private void optGeneralWorkingDay_CheckedChanged(object sender, EventArgs e)
        {
            this.dataGridView12.CurrentCell.Style.BackColor = this.clrCalenderColor;
            this.dataGridView12.CurrentCell.Style.ForeColor = Color.Black;
        }

        private void optMechantileHoliday_CheckedChanged(object sender, EventArgs e)
        {
            this.dataGridView12.CurrentCell.Style.BackColor = this.clrMechantileHolidayColor;
            this.dataGridView12.CurrentCell.Style.ForeColor = Color.Black;
        }

        private void optPoyaday_CheckedChanged(object sender, EventArgs e)
        {
            this.dataGridView12.CurrentCell.Style.BackColor = this.clrPoyadayColor;
            this.dataGridView12.CurrentCell.Style.ForeColor = Color.Black;
        }

        private void optSaturday_CheckedChanged(object sender, EventArgs e)
        {
            this.dataGridView12.CurrentCell.Style.BackColor = this.clrCalenderColor;
            this.dataGridView12.CurrentCell.Style.ForeColor = this.clrSaturdayColor;
        }

        private void optSpecialHoloday_CheckedChanged(object sender, EventArgs e)
        {
            this.dataGridView12.CurrentCell.Style.BackColor = this.clrSpecialHolodayColor;
            this.dataGridView12.CurrentCell.Style.ForeColor = Color.Black;
        }

        private void optSunday_CheckedChanged(object sender, EventArgs e)
        {
            this.dataGridView12.CurrentCell.Style.BackColor = this.clrCalenderColor;
            this.dataGridView12.CurrentCell.Style.ForeColor = this.clrSundayColor;
        }

        private void TODate_ValueChanged(object sender, EventArgs e)
        {
            this.LoadCalendar();
        }

        private void txtRemarks_TextChanged(object sender, EventArgs e)
        {
            this.dataGridView12.CurrentCell.Tag = this.txtRemarks.Text;
        }
    }
}

