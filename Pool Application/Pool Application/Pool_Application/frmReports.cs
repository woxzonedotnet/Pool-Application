namespace Pool_Application
{
    using Business_Layer;
    using Business_Layer.Property_Layer;
    using JTG;
    using Report_Layer;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;

    public class frmReports : Form
    {
        private Button btnClearAll;
        private Button btnExit;
        private Button btnPrint;
        private Button btnSelectAll;
        private clsClassMaster cClassMaster;
        private clsClassTimeTable cClassTimeTable;
        private clsDayTypes cDayTypes;
        private clsGlobleVariable cGlobalVariable;
        private DataGridViewTextBoxColumn clmEmpName;
        private DataGridViewTextBoxColumn clmNumber;
        private clsCommenMethods clsCommen;
        private ColumnComboBox cmbLevel;
        private ColumnComboBox cmbStudentStatus;
        private ColumnComboBox cmdDay;
        private ColumnComboBox cmdSession;
        private DataGridViewCheckBoxColumn Column1;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
        private IContainer components;
        private clsReportMaster cReportMaster;
        private clsStatusMaster cStatusMaster;
        private clsStudentMaster cStudentMaster;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DateTimePicker dtpFromDate;
        private DateTimePicker dtpToDate;
        private GroupBox groupBox1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label lblFromDate;
        private Label lblStatus;
        private Label lblToDate;
        private ListView lstDailyReport;
        private ListView lstMaster;
        private DataGridView lstRegularEmployee;
        private ListView lstSummaryReport;
        private objReportMaster oReportMaster;
        private ColumnHeader ReportID;
        private ColumnHeader ReportName;
        private string strSeletedTab;
        private TabPage tabDailyReport;
        private TabPage tabMaster;
        private TabControl tabReports;
        private TabPage tabSummary;

        public frmReports()
        {
            this.components = null;
            this.strSeletedTab = "tabDailyReport";
            this.cReportMaster = new clsReportMaster();
            this.cGlobalVariable = new clsGlobleVariable();
            this.clsCommen = new clsCommenMethods();
            this.oReportMaster = new objReportMaster();
            this.cStudentMaster = new clsStudentMaster();
            this.cClassMaster = new clsClassMaster();
            this.cStatusMaster = new clsStatusMaster();
            this.cDayTypes = new clsDayTypes();
            this.cClassTimeTable = new clsClassTimeTable();
            this.InitializeComponent();
        }

        public frmReports(string SeletedTabPages)
        {
            this.components = null;
            this.strSeletedTab = "tabDailyReport";
            this.cReportMaster = new clsReportMaster();
            this.cGlobalVariable = new clsGlobleVariable();
            this.clsCommen = new clsCommenMethods();
            this.oReportMaster = new objReportMaster();
            this.cStudentMaster = new clsStudentMaster();
            this.cClassMaster = new clsClassMaster();
            this.cStatusMaster = new clsStatusMaster();
            this.cDayTypes = new clsDayTypes();
            this.cClassTimeTable = new clsClassTimeTable();
            this.strSeletedTab = SeletedTabPages;
            this.InitializeComponent();
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            this.SelectEmployees(false);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (this.ValidateSeletedData())
            {
                if (this.tabReports.SelectedIndex == 0)
                {
                    this.ReportViwer(this.lstDailyReport.SelectedItems[0].SubItems[0].Text, this.lstDailyReport.SelectedItems[0].SubItems[1].Text);
                }
                else if (this.tabReports.SelectedIndex == 1)
                {
                    this.ReportViwer(this.lstSummaryReport.SelectedItems[0].SubItems[0].Text, this.lstSummaryReport.SelectedItems[0].SubItems[1].Text);
                }
                else if (this.tabReports.SelectedIndex == 2)
                {
                    this.ReportViwerMaster(this.lstMaster.SelectedItems[0].SubItems[0].Text);
                }
            }
            else
            {
                MessageBox.Show("Please select employee before view reports.", "View Reports", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            this.SelectEmployees(true);
        }

        private void cmbLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbLevel.SelectedIndex > -1)
            {
                this.Show_Employees_Grid();
            }
        }

        private void cmbStudentStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbStudentStatus.SelectedIndex > -1)
            {
                this.Show_Employees_Grid();
            }
        }

        private void cmdDay_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmdDay.SelectedIndex > -1)
            {
                this.Show_Employees_Grid();
            }
        }

        private void cmdSession_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmdDay.SelectedIndex > -1)
            {
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

        private void dtpFromDate_ValueChanged(object sender, EventArgs e)
        {
            this.dtpToDate.Value = this.dtpFromDate.Value;
            this.Show_Employees_Grid();
        }

        private void dtpToDate_ValueChanged(object sender, EventArgs e)
        {
            this.Show_Employees_Grid();
        }

        private void frmReports_Load(object sender, EventArgs e)
        {
            this.dtpFromDate.CustomFormat = this.cGlobalVariable.SystemDateFormat;
            this.dtpFromDate.Format = DateTimePickerFormat.Custom;
            this.dtpToDate.CustomFormat = this.cGlobalVariable.SystemDateFormat;
            this.dtpToDate.Format = DateTimePickerFormat.Custom;
            this.tabReports.SelectTab(this.strSeletedTab);
            this.LoadReport();
            DataTable classDetails = this.cClassMaster.GetClassDetails(this.cGlobalVariable.LocationCode, this.cGlobalVariable.ActiveStatusCode);
            DataRow row = classDetails.NewRow();
            row[0] = "0";
            row[1] = "$00";
            row[2] = "$00";
            row[3] = "ALL";
            classDetails.Rows.InsertAt(row, 0);
            this.clsCommen.LoadCombo(classDetails, this.cmbLevel, 3);
            DataTable statusDetails = this.cStatusMaster.GetStatusDetails();
            DataRow row2 = statusDetails.NewRow();
            row2[0] = "D";
            row2[1] = "ALL";
            statusDetails.Rows.InsertAt(row2, 0);
            this.clsCommen.LoadCombo(statusDetails, this.cmbStudentStatus, 1);
            DataTable dtFillData = this.cDayTypes.GetClassDetails();
            DataRow row3 = dtFillData.NewRow();
            row3[0] = "D";
            row3[1] = "ALL";
            dtFillData.Rows.InsertAt(row3, 0);
            this.clsCommen.LoadCombo(dtFillData, this.cmdDay, 1);
            DataTable table4 = new DataTable();
            table4.Columns.Add();
            table4.Columns.Add();
            DataRow row4 = table4.NewRow();
            row4[0] = "$00";
            row4[1] = "ALL";
            table4.Rows.InsertAt(row4, 0);
            row4 = table4.NewRow();
            row4[0] = "$01";
            row4[1] = "Evening";
            table4.Rows.InsertAt(row4, 1);
            row4 = table4.NewRow();
            row4[0] = "$02";
            row4[1] = "Morning";
            table4.Rows.InsertAt(row4, 2);
            this.clsCommen.LoadCombo(table4, this.cmdSession, 1);
            if (this.cmbLevel.Items.Count > 0)
            {
                this.cmbLevel.SelectedIndex = 1;
            }
            if (this.cmdDay.Items.Count > 0)
            {
                this.cmdDay.SelectedIndex = 1;
            }
            if (this.cmbStudentStatus.Items.Count > 0)
            {
                this.cmbStudentStatus.SelectedIndex = 1;
            }
            if (this.cmdSession.Items.Count > 0)
            {
                this.cmdSession.SelectedIndex = 1;
            }
            this.SelectedTab();
            this.Show_Employees_Grid();
        }

        private void InitializeComponent()
        {
            DataGridViewCellStyle style = new DataGridViewCellStyle();
            DataGridViewCellStyle style2 = new DataGridViewCellStyle();
            DataGridViewCellStyle style3 = new DataGridViewCellStyle();
            DataGridViewCellStyle style4 = new DataGridViewCellStyle();
            DataGridViewCellStyle style5 = new DataGridViewCellStyle();
            DataGridViewCellStyle style6 = new DataGridViewCellStyle();
            ComponentResourceManager manager = new ComponentResourceManager(typeof(frmReports));
            this.groupBox1 = new GroupBox();
            this.label2 = new Label();
            this.label3 = new Label();
            this.dtpToDate = new DateTimePicker();
            this.lblToDate = new Label();
            this.lblStatus = new Label();
            this.label1 = new Label();
            this.dtpFromDate = new DateTimePicker();
            this.lblFromDate = new Label();
            this.tabReports = new TabControl();
            this.tabDailyReport = new TabPage();
            this.lstDailyReport = new ListView();
            this.ReportID = new ColumnHeader();
            this.ReportName = new ColumnHeader();
            this.tabSummary = new TabPage();
            this.lstSummaryReport = new ListView();
            this.columnHeader3 = new ColumnHeader();
            this.columnHeader4 = new ColumnHeader();
            this.tabMaster = new TabPage();
            this.lstMaster = new ListView();
            this.columnHeader5 = new ColumnHeader();
            this.columnHeader6 = new ColumnHeader();
            this.lstRegularEmployee = new DataGridView();
            this.Column1 = new DataGridViewCheckBoxColumn();
            this.clmNumber = new DataGridViewTextBoxColumn();
            this.clmEmpName = new DataGridViewTextBoxColumn();
            this.btnSelectAll = new Button();
            this.btnExit = new Button();
            this.btnClearAll = new Button();
            this.btnPrint = new Button();
            this.columnHeader1 = new ColumnHeader();
            this.columnHeader2 = new ColumnHeader();
            this.dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            this.cmdSession = new ColumnComboBox();
            this.cmdDay = new ColumnComboBox();
            this.cmbStudentStatus = new ColumnComboBox();
            this.cmbLevel = new ColumnComboBox();
            this.groupBox1.SuspendLayout();
            this.tabReports.SuspendLayout();
            this.tabDailyReport.SuspendLayout();
            this.tabSummary.SuspendLayout();
            this.tabMaster.SuspendLayout();
            ((ISupportInitialize) this.lstRegularEmployee).BeginInit();
            base.SuspendLayout();
            this.groupBox1.Controls.Add(this.cmdSession);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cmdDay);
            this.groupBox1.Controls.Add(this.dtpToDate);
            this.groupBox1.Controls.Add(this.lblToDate);
            this.groupBox1.Controls.Add(this.cmbStudentStatus);
            this.groupBox1.Controls.Add(this.lblStatus);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbLevel);
            this.groupBox1.Controls.Add(this.dtpFromDate);
            this.groupBox1.Controls.Add(this.lblFromDate);
            this.groupBox1.Location = new Point(3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(480, 110);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.label2.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label2.Location = new Point(0x9c, 0x3a);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x70, 0x13);
            this.label2.TabIndex = 0xe0;
            this.label2.Text = "Session";
            this.label2.TextAlign = ContentAlignment.MiddleLeft;
            this.label3.AutoSize = true;
            this.label3.Location = new Point(6, 0x3e);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x1a, 13);
            this.label3.TabIndex = 0xde;
            this.label3.Text = "Day";
            this.dtpToDate.Format = DateTimePickerFormat.Short;
            this.dtpToDate.Location = new Point(390, 0x23);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new Size(0x54, 20);
            this.dtpToDate.TabIndex = 220;
            this.dtpToDate.Visible = false;
            this.lblToDate.AutoSize = true;
            this.lblToDate.Location = new Point(0x183, 0x12);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.Size = new Size(0x2e, 13);
            this.lblToDate.TabIndex = 0xdb;
            this.lblToDate.Text = "To Date";
            this.lblToDate.Visible = false;
            this.lblStatus.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.lblStatus.Location = new Point(0x9c, 13);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new Size(0x70, 0x13);
            this.lblStatus.TabIndex = 0xda;
            this.lblStatus.Text = "Status";
            this.lblStatus.TextAlign = ContentAlignment.MiddleLeft;
            this.lblStatus.Visible = false;
            this.label1.AutoSize = true;
            this.label1.Location = new Point(6, 0x11);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x21, 13);
            this.label1.TabIndex = 0x17;
            this.label1.Text = "Level";
            this.dtpFromDate.Format = DateTimePickerFormat.Short;
            this.dtpFromDate.Location = new Point(0x129, 0x23);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new Size(0x54, 20);
            this.dtpFromDate.TabIndex = 0x15;
            this.dtpFromDate.ValueChanged += new EventHandler(this.dtpFromDate_ValueChanged);
            this.lblFromDate.AutoSize = true;
            this.lblFromDate.Location = new Point(0x126, 0x10);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new Size(0x38, 13);
            this.lblFromDate.TabIndex = 20;
            this.lblFromDate.Text = "From Date";
            this.tabReports.Controls.Add(this.tabDailyReport);
            this.tabReports.Controls.Add(this.tabSummary);
            this.tabReports.Controls.Add(this.tabMaster);
            this.tabReports.Location = new Point(0x1ed, 8);
            this.tabReports.Name = "tabReports";
            this.tabReports.SelectedIndex = 0;
            this.tabReports.Size = new Size(0x133, 430);
            this.tabReports.TabIndex = 6;
            this.tabReports.Click += new EventHandler(this.tabReports_Click);
            this.tabDailyReport.Controls.Add(this.lstDailyReport);
            this.tabDailyReport.Location = new Point(4, 0x16);
            this.tabDailyReport.Name = "tabDailyReport";
            this.tabDailyReport.Padding = new Padding(3);
            this.tabDailyReport.Size = new Size(0x12b, 0x194);
            this.tabDailyReport.TabIndex = 0;
            this.tabDailyReport.Text = "Daily Report";
            this.tabDailyReport.UseVisualStyleBackColor = true;
            this.lstDailyReport.Columns.AddRange(new ColumnHeader[] { this.ReportID, this.ReportName });
            this.lstDailyReport.FullRowSelect = true;
            this.lstDailyReport.Location = new Point(3, 6);
            this.lstDailyReport.Name = "lstDailyReport";
            this.lstDailyReport.Size = new Size(0x125, 0x18b);
            this.lstDailyReport.TabIndex = 1;
            this.lstDailyReport.UseCompatibleStateImageBehavior = false;
            this.lstDailyReport.View = View.Details;
            this.lstDailyReport.DoubleClick += new EventHandler(this.lstDailyReport_DoubleClick);
            this.lstDailyReport.SelectedIndexChanged += new EventHandler(this.lstDailyReport_SelectedIndexChanged);
            this.ReportID.Width = 0;
            this.ReportName.Text = "Report";
            this.ReportName.Width = 0x11f;
            this.tabSummary.Controls.Add(this.lstSummaryReport);
            this.tabSummary.Location = new Point(4, 0x16);
            this.tabSummary.Name = "tabSummary";
            this.tabSummary.Padding = new Padding(3);
            this.tabSummary.Size = new Size(0x12b, 0x194);
            this.tabSummary.TabIndex = 1;
            this.tabSummary.Text = "Summary";
            this.tabSummary.UseVisualStyleBackColor = true;
            this.lstSummaryReport.Columns.AddRange(new ColumnHeader[] { this.columnHeader3, this.columnHeader4 });
            this.lstSummaryReport.FullRowSelect = true;
            this.lstSummaryReport.Location = new Point(3, 6);
            this.lstSummaryReport.Name = "lstSummaryReport";
            this.lstSummaryReport.Size = new Size(0x125, 0x18b);
            this.lstSummaryReport.TabIndex = 3;
            this.lstSummaryReport.UseCompatibleStateImageBehavior = false;
            this.lstSummaryReport.View = View.Details;
            this.lstSummaryReport.DoubleClick += new EventHandler(this.lstSummaryReport_DoubleClick);
            this.columnHeader3.Width = 0;
            this.columnHeader4.Text = "Report";
            this.columnHeader4.Width = 0x11f;
            this.tabMaster.Controls.Add(this.lstMaster);
            this.tabMaster.Location = new Point(4, 0x16);
            this.tabMaster.Name = "tabMaster";
            this.tabMaster.Padding = new Padding(3);
            this.tabMaster.Size = new Size(0x12b, 0x194);
            this.tabMaster.TabIndex = 2;
            this.tabMaster.Text = "Master Reports";
            this.tabMaster.UseVisualStyleBackColor = true;
            this.lstMaster.Columns.AddRange(new ColumnHeader[] { this.columnHeader5, this.columnHeader6 });
            this.lstMaster.FullRowSelect = true;
            this.lstMaster.Location = new Point(3, 6);
            this.lstMaster.Name = "lstMaster";
            this.lstMaster.Size = new Size(0x125, 0x18b);
            this.lstMaster.TabIndex = 2;
            this.lstMaster.UseCompatibleStateImageBehavior = false;
            this.lstMaster.View = View.Details;
            this.lstMaster.DoubleClick += new EventHandler(this.lstMaster_DoubleClick);
            this.columnHeader5.Width = 0;
            this.columnHeader6.Text = "Report";
            this.columnHeader6.Width = 0x11f;
            this.lstRegularEmployee.AllowUserToAddRows = false;
            this.lstRegularEmployee.AllowUserToDeleteRows = false;
            this.lstRegularEmployee.AllowUserToResizeColumns = false;
            this.lstRegularEmployee.AllowUserToResizeRows = false;
            this.lstRegularEmployee.BackgroundColor = SystemColors.ControlLightLight;
            style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            style.BackColor = SystemColors.Control;
            style.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            style.ForeColor = SystemColors.WindowText;
            style.SelectionBackColor = SystemColors.Highlight;
            style.SelectionForeColor = SystemColors.HighlightText;
            style.WrapMode = DataGridViewTriState.True;
            this.lstRegularEmployee.ColumnHeadersDefaultCellStyle = style;
            this.lstRegularEmployee.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.lstRegularEmployee.Columns.AddRange(new DataGridViewColumn[] { this.Column1, this.clmNumber, this.clmEmpName });
            this.lstRegularEmployee.Location = new Point(3, 0x76);
            this.lstRegularEmployee.Name = "lstRegularEmployee";
            this.lstRegularEmployee.RowHeadersVisible = false;
            this.lstRegularEmployee.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.lstRegularEmployee.Size = new Size(0x1e3, 320);
            this.lstRegularEmployee.TabIndex = 7;
            style2.Alignment = DataGridViewContentAlignment.TopLeft;
            style2.NullValue = false;
            this.Column1.DefaultCellStyle = style2;
            this.Column1.HeaderText = "";
            this.Column1.Name = "Column1";
            this.Column1.Width = 0x19;
            style3.Alignment = DataGridViewContentAlignment.TopLeft;
            this.clmNumber.DefaultCellStyle = style3;
            this.clmNumber.HeaderText = "Number";
            this.clmNumber.Name = "clmNumber";
            this.clmNumber.ReadOnly = true;
            this.clmNumber.Width = 70;
            style4.Alignment = DataGridViewContentAlignment.TopLeft;
            this.clmEmpName.DefaultCellStyle = style4;
            this.clmEmpName.HeaderText = "Employee Name";
            this.clmEmpName.Name = "clmEmpName";
            this.clmEmpName.ReadOnly = true;
            this.clmEmpName.Width = 380;
            this.btnSelectAll.Location = new Point(0, 0x1bc);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new Size(0x45, 0x17);
            this.btnSelectAll.TabIndex = 8;
            this.btnSelectAll.Text = "Select All";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new EventHandler(this.btnSelectAll_Click);
            this.btnExit.Location = new Point(0x2d5, 0x1bc);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new Size(0x4b, 0x17);
            this.btnExit.TabIndex = 11;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new EventHandler(this.btnExit_Click);
            this.btnClearAll.Location = new Point(0x4b, 0x1bc);
            this.btnClearAll.Name = "btnClearAll";
            this.btnClearAll.Size = new Size(0x45, 0x17);
            this.btnClearAll.TabIndex = 12;
            this.btnClearAll.Text = "Clear All";
            this.btnClearAll.UseVisualStyleBackColor = true;
            this.btnClearAll.Click += new EventHandler(this.btnClearAll_Click);
            this.btnPrint.Location = new Point(650, 0x1bc);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new Size(0x45, 0x17);
            this.btnPrint.TabIndex = 13;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new EventHandler(this.btnPrint_Click);
            this.columnHeader1.Width = 0;
            this.columnHeader2.Text = "Report";
            this.columnHeader2.Width = 0x11f;
            style5.Alignment = DataGridViewContentAlignment.TopLeft;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = style5;
            this.dataGridViewTextBoxColumn1.HeaderText = "Number";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 70;
            style6.Alignment = DataGridViewContentAlignment.TopLeft;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = style6;
            this.dataGridViewTextBoxColumn2.HeaderText = "Employee Name";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 380;
            this.cmdSession.DrawMode = DrawMode.OwnerDrawVariable;
            this.cmdSession.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmdSession.DropDownWidth = 0x11;
            this.cmdSession.FormattingEnabled = true;
            this.cmdSession.Location = new Point(0x9f, 0x4f);
            this.cmdSession.Name = "cmdSession";
            this.cmdSession.Size = new Size(0x84, 0x15);
            this.cmdSession.TabIndex = 0xdf;
            this.cmdSession.ViewColumn = 0;
            this.cmdSession.SelectedIndexChanged += new EventHandler(this.cmdSession_SelectedIndexChanged);
            this.cmdDay.DrawMode = DrawMode.OwnerDrawVariable;
            this.cmdDay.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmdDay.DropDownWidth = 0x11;
            this.cmdDay.FormattingEnabled = true;
            this.cmdDay.Location = new Point(9, 0x4f);
            this.cmdDay.Name = "cmdDay";
            this.cmdDay.Size = new Size(0x90, 0x15);
            this.cmdDay.TabIndex = 0xdd;
            this.cmdDay.ViewColumn = 0;
            this.cmdDay.SelectedIndexChanged += new EventHandler(this.cmdDay_SelectedIndexChanged);
            this.cmbStudentStatus.DrawMode = DrawMode.OwnerDrawVariable;
            this.cmbStudentStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbStudentStatus.DropDownWidth = 0x11;
            this.cmbStudentStatus.FormattingEnabled = true;
            this.cmbStudentStatus.Location = new Point(0x9f, 0x22);
            this.cmbStudentStatus.Name = "cmbStudentStatus";
            this.cmbStudentStatus.Size = new Size(0x84, 0x15);
            this.cmbStudentStatus.TabIndex = 0xd9;
            this.cmbStudentStatus.ViewColumn = 0;
            this.cmbStudentStatus.Visible = false;
            this.cmbStudentStatus.SelectedIndexChanged += new EventHandler(this.cmbStudentStatus_SelectedIndexChanged);
            this.cmbLevel.DrawMode = DrawMode.OwnerDrawVariable;
            this.cmbLevel.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbLevel.DropDownWidth = 0x11;
            this.cmbLevel.FormattingEnabled = true;
            this.cmbLevel.Location = new Point(9, 0x22);
            this.cmbLevel.Name = "cmbLevel";
            this.cmbLevel.Size = new Size(0x90, 0x15);
            this.cmbLevel.TabIndex = 0x16;
            this.cmbLevel.ViewColumn = 0;
            this.cmbLevel.SelectedIndexChanged += new EventHandler(this.cmbLevel_SelectedIndexChanged);
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            base.ClientSize = new Size(0x321, 470);
            base.Controls.Add(this.btnPrint);
            base.Controls.Add(this.btnClearAll);
            base.Controls.Add(this.btnExit);
            base.Controls.Add(this.btnSelectAll);
            base.Controls.Add(this.lstRegularEmployee);
            base.Controls.Add(this.tabReports);
            base.Controls.Add(this.groupBox1);
            base.FormBorderStyle = FormBorderStyle.FixedSingle;
            base.MaximizeBox = false;
            base.Name = "frmReports";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Pool Attendance System";
            base.Load += new EventHandler(this.frmReports_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabReports.ResumeLayout(false);
            this.tabDailyReport.ResumeLayout(false);
            this.tabSummary.ResumeLayout(false);
            this.tabMaster.ResumeLayout(false);
            ((ISupportInitialize) this.lstRegularEmployee).EndInit();
            base.ResumeLayout(false);
        }

        private void LoadReport()
        {
            DataTable reports = this.cReportMaster.GetReports();
            for (int i = 0; i < reports.Rows.Count; i++)
            {
                ListViewItem item = new ListViewItem {
                    Text = reports.Rows[i][1].ToString()
                };
                item.SubItems.Add(reports.Rows[i][3].ToString());
                item.SubItems.Add(reports.Rows[i][6].ToString());
                if (reports.Rows[i][7].ToString() == "S")
                {
                    if (reports.Rows[i][5].ToString() == "D")
                    {
                        this.lstDailyReport.Items.Add(item);
                    }
                    else if (reports.Rows[i][5].ToString() == "S")
                    {
                        this.lstSummaryReport.Items.Add(item);
                    }
                    else if (reports.Rows[i][5].ToString() == "M")
                    {
                        this.lstMaster.Items.Add(item);
                    }
                }
            }
        }

        private void lstDailyReport_DoubleClick(object sender, EventArgs e)
        {
            if (this.ValidateSeletedData())
            {
                this.ReportViwer(this.lstDailyReport.SelectedItems[0].SubItems[0].Text, this.lstDailyReport.SelectedItems[0].SubItems[1].Text);
            }
            else
            {
                MessageBox.Show("Please select employee before view reports.", "View Reports", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void lstDailyReport_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void lstMaster_DoubleClick(object sender, EventArgs e)
        {
            if (this.ValidateSeletedData())
            {
                this.ReportViwerMaster(this.lstMaster.SelectedItems[0].SubItems[0].Text);
            }
            else
            {
                MessageBox.Show("Please select employee before view reports.", "View Reports", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void lstSummaryReport_DoubleClick(object sender, EventArgs e)
        {
            if (this.ValidateSeletedData())
            {
                this.ReportViwer(this.lstSummaryReport.SelectedItems[0].SubItems[0].Text, this.lstSummaryReport.SelectedItems[0].SubItems[1].Text);
            }
            else
            {
                MessageBox.Show("Please select employee before view reports.", "View Reports", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void ReportViwer(string strReportID, string strReportName)
        {
            string str = string.Empty;
            if (this.cmdDay["fldDay"].ToString() != "ALL")
            {
                str = this.cmdDay["fldDay"].ToString();
            }
            int reportID = Convert.ToInt16(strReportID);
            object[,] arrParameter = new object[,] { { "strCompanyName", this.cGlobalVariable.CustomerName }, { "strCopyRight", this.cGlobalVariable.CopyRight }, { "dFromDate", this.dtpFromDate.Value }, { "strReportTitle", strReportName }, { "dToDate", this.dtpToDate.Value }, { "strDayType", str.ToString() } };
            new frmReportViever(reportID, this.cGlobalVariable.LocationCode, this.SelectionFormularValues(reportID), arrParameter).Show();
        }

        private void ReportViwerMaster(string strReportID)
        {
            string str = string.Empty;
            if (this.cmdDay["fldDay"].ToString() != "ALL")
            {
                str = this.cmdDay["fldDay"].ToString();
            }
            int reportID = Convert.ToInt16(strReportID);
            this.oReportMaster = this.cReportMaster.GetReports(reportID);
            object[,] arrParameter = new object[,] { { "strCompanyName", this.cGlobalVariable.CustomerName }, { "strCopyRight", this.cGlobalVariable.CopyRight }, { "strReportTitle", this.lstMaster.SelectedItems[0].SubItems[1].Text }, { "strStatus", this.cmbStudentStatus["fld_Status_Code"].ToString() }, { "strDayType", str.ToString() } };
            new frmReportViever(this.oReportMaster.ReportName, this.SelectionFormularValuesMaster(reportID, arrParameter[3, 1].ToString()), arrParameter).Show();
        }

        private void SelectedTab()
        {
            if (this.cmbStudentStatus.Items.Count > 0)
            {
                this.cmbStudentStatus.SelectedIndex = 1;
            }
            if (this.tabReports.SelectedIndex == 2)
            {
                this.cmbStudentStatus.Visible = true;
                this.lblStatus.Visible = true;
                this.lblFromDate.Visible = false;
                this.dtpFromDate.Visible = false;
                this.lblToDate.Visible = false;
                this.dtpToDate.Visible = false;
                if (this.cmbStudentStatus.Items.Count > 0)
                {
                    this.cmbStudentStatus.SelectedIndex = 0;
                }
            }
            else if (this.tabReports.SelectedIndex == 1)
            {
                this.cmbStudentStatus.Visible = false;
                this.lblStatus.Visible = false;
                this.lblFromDate.Visible = true;
                this.dtpFromDate.Visible = true;
                this.lblToDate.Visible = true;
                this.dtpToDate.Visible = true;
                this.dtpFromDate.Value = this.dtpToDate.Value;
            }
            else
            {
                this.cmbStudentStatus.Visible = false;
                this.lblStatus.Visible = false;
                this.lblFromDate.Visible = true;
                this.dtpFromDate.Visible = true;
                this.lblToDate.Visible = false;
                this.dtpToDate.Visible = false;
            }
        }

        private void SelectEmployees(bool bEmpStatus)
        {
            for (int i = 0; i <= (this.lstRegularEmployee.Rows.Count - 1); i++)
            {
                this.lstRegularEmployee.Rows[i].Cells[0].Value = bEmpStatus;
            }
        }

        private string SelectionFormularValues(int iReportID)
        {
            int num2;
            string str = string.Empty;
            this.oReportMaster = this.cReportMaster.GetReports(iReportID);
            for (int i = 0; i < this.lstRegularEmployee.Rows.Count; i++)
            {
                if (Convert.ToBoolean(this.lstRegularEmployee.Rows[i].Cells[0].Value))
                {
                    if (this.oReportMaster.SelectedTable.ToString() != string.Empty)
                    {
                        string str3 = str;
                        str = str3 + "{" + this.oReportMaster.SelectedTable + ".fldStudentNo}='" + this.lstRegularEmployee.Rows[i].Cells[1].Value.ToString() + "'";
                    }
                    if (this.oReportMaster.SelectionFormular.ToString() != string.Empty)
                    {
                        str = str + " AND " + this.oReportMaster.SelectionFormular + " OR ";
                    }
                    else
                    {
                        str = str + " OR ";
                    }
                }
            }
            if ((str != string.Empty) && (str.Substring(str.Length - 3, 2) == "OR"))
            {
                num2 = str.LastIndexOf("OR");
                str = str.Substring(0, num2 - 1);
            }
            if ((str != string.Empty) && (str.Substring(str.Length - 3, 3) == "AND"))
            {
                num2 = str.LastIndexOf("AND");
                str = str.Substring(0, num2 - 1);
            }
            return str;
        }

        private string SelectionFormularValuesMaster(int iReportID, string strStatus)
        {
            int num2;
            string str = string.Empty;
            this.oReportMaster = this.cReportMaster.GetReports(iReportID);
            if (this.cmdDay["fldDay"].ToString() == "ALL")
            {
                this.oReportMaster.SelectionFormular = string.Empty;
            }
            for (int i = 0; i < this.lstRegularEmployee.Rows.Count; i++)
            {
                if (Convert.ToBoolean(this.lstRegularEmployee.Rows[i].Cells[0].Value))
                {
                    if (this.oReportMaster.SelectedTable.ToString() != string.Empty)
                    {
                        string str3 = str;
                        str = str3 + "{" + this.oReportMaster.SelectedTable + ".fldStudentNo}='" + this.lstRegularEmployee.Rows[i].Cells[1].Value.ToString() + "'";
                    }
                    if (this.oReportMaster.SelectionFormular.ToString() != string.Empty)
                    {
                        str = str + " AND " + this.oReportMaster.SelectionFormular + " OR ";
                    }
                    else
                    {
                        str = str + " OR ";
                    }
                }
            }
            if ((str != string.Empty) && (str.Substring(str.Length - 3, 2) == "OR"))
            {
                num2 = str.LastIndexOf("OR");
                str = str.Substring(0, num2 - 1);
            }
            if ((str != string.Empty) && (str.Substring(str.Length - 3, 3) == "AND"))
            {
                num2 = str.LastIndexOf("AND");
                str = str.Substring(0, num2 - 1);
            }
            return str;
        }

        public void Show_Employees_Grid()
        {
            this.lstRegularEmployee.Rows.Clear();
            if (this.cmdDay.SelectedIndex > -1)
            {
                this.oReportMaster.DayType = this.cmdDay["fldDay"].ToString();
                if (this.oReportMaster.DayType == "ALL")
                {
                    this.oReportMaster.DayType = "%";
                }
                if ((this.cmdSession.SelectedIndex > -1) && (this.cmdSession["Column2"].ToString() != null))
                {
                    this.oReportMaster.DaySession = this.cmdSession["Column2"].ToString();
                    if (this.oReportMaster.DaySession == "ALL")
                    {
                        this.oReportMaster.DaySession = "%";
                    }
                    if (this.cmbLevel.SelectedIndex > -1)
                    {
                        this.oReportMaster.ClassCode = this.cmbLevel["fldClassCode"].ToString();
                        if (this.oReportMaster.ClassCode == "$00")
                        {
                            this.oReportMaster.ClassCode = "%";
                        }
                        if (this.cmbStudentStatus.SelectedIndex > -1)
                        {
                            this.oReportMaster.StatusCode = this.cmbStudentStatus["fld_Status_Code"].ToString();
                            if (this.oReportMaster.StatusCode == "D")
                            {
                                this.oReportMaster.StatusCode = "%";
                            }
                            DataTable table = this.cStudentMaster.GetStudentData(this.cGlobalVariable.LocationCode, this.oReportMaster.ClassCode, this.oReportMaster.StatusCode);
                            if (table.Rows.Count > 0)
                            {
                                for (int i = 0; i <= (table.Rows.Count - 1); i++)
                                {
                                    if (this.cClassTimeTable.GetClassDetails(this.cGlobalVariable.LocationCode, table.Rows[i][2].ToString(), this.oReportMaster.DayType, this.oReportMaster.DaySession).Rows.Count > 0)
                                    {
                                        int count = this.lstRegularEmployee.Rows.Count;
                                        this.lstRegularEmployee.Rows.Add(1);
                                        this.lstRegularEmployee.Rows[count].Cells[1].Value = table.Rows[i][2].ToString();
                                        this.lstRegularEmployee.Rows[count].Cells[2].Value = table.Rows[i][3].ToString();
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void tabReports_Click(object sender, EventArgs e)
        {
            this.SelectedTab();
        }

        private bool ValidateSeletedData()
        {
            for (int i = 0; i < this.lstRegularEmployee.Rows.Count; i++)
            {
                if (Convert.ToBoolean(this.lstRegularEmployee.Rows[i].Cells[0].Value))
                {
                    return true;
                }
            }
            return false;
        }
    }
}

