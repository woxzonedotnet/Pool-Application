namespace Pool_Application
{
    using Business_Layer;
    using Business_Layer.Property_Layer;
    using Report_Layer;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;

    public class frmCoacherReports : Form
    {
        private Button btnClearAll;
        private Button btnExit;
        private Button btnPrint;
        private Button btnSelectAll;
        private clsCoacherMaster cCoacherMaster;
        private clsGlobleVariable cGlobalVariable;
        private DataGridViewTextBoxColumn clmEmpName;
        private DataGridViewTextBoxColumn clmNumber;
        private clsCommenMethods clsCommen;
        private DataGridViewCheckBoxColumn Column1;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private IContainer components;
        private clsReportMaster cReportMaster;
        private DateTimePicker dtpFromDate;
        private GroupBox groupBox1;
        private Label lblFromDate;
        private ListView lstDailyReport;
        private DataGridView lstRegularEmployee;
        private ListView lstSummaryReport;
        private objReportMaster oReportMaster;
        private ColumnHeader ReportID;
        private ColumnHeader ReportName;
        private string strSeletedTab;
        private TabPage tabDailyReport;
        private TabControl tabReports;
        private TabPage tabSummary;

        public frmCoacherReports()
        {
            this.strSeletedTab = "tabDailyReport";
            this.cReportMaster = new clsReportMaster();
            this.cGlobalVariable = new clsGlobleVariable();
            this.clsCommen = new clsCommenMethods();
            this.oReportMaster = new objReportMaster();
            this.cCoacherMaster = new clsCoacherMaster();
            this.components = null;
            this.InitializeComponent();
        }

        public frmCoacherReports(string SeletedTabPages)
        {
            this.strSeletedTab = "tabDailyReport";
            this.cReportMaster = new clsReportMaster();
            this.cGlobalVariable = new clsGlobleVariable();
            this.clsCommen = new clsCommenMethods();
            this.oReportMaster = new objReportMaster();
            this.cCoacherMaster = new clsCoacherMaster();
            this.components = null;
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
                this.ReportViwer(this.lstDailyReport.SelectedItems[0].SubItems[0].Text, this.lstDailyReport.SelectedItems[0].SubItems[1].Text);
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

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void frmCoacherReports_Load(object sender, EventArgs e)
        {
            this.dtpFromDate.CustomFormat = this.cGlobalVariable.SystemDateFormat;
            this.dtpFromDate.Format = DateTimePickerFormat.Custom;
            this.tabReports.SelectTab(this.strSeletedTab);
            this.LoadReport();
            this.Show_Employees_Grid();
        }

        private void InitializeComponent()
        {
            DataGridViewCellStyle style = new DataGridViewCellStyle();
            DataGridViewCellStyle style2 = new DataGridViewCellStyle();
            DataGridViewCellStyle style3 = new DataGridViewCellStyle();
            DataGridViewCellStyle style4 = new DataGridViewCellStyle();
            this.Column1 = new DataGridViewCheckBoxColumn();
            this.clmNumber = new DataGridViewTextBoxColumn();
            this.columnHeader3 = new ColumnHeader();
            this.columnHeader4 = new ColumnHeader();
            this.clmEmpName = new DataGridViewTextBoxColumn();
            this.btnPrint = new Button();
            this.btnClearAll = new Button();
            this.btnExit = new Button();
            this.btnSelectAll = new Button();
            this.lstRegularEmployee = new DataGridView();
            this.tabReports = new TabControl();
            this.tabDailyReport = new TabPage();
            this.lstDailyReport = new ListView();
            this.ReportID = new ColumnHeader();
            this.ReportName = new ColumnHeader();
            this.tabSummary = new TabPage();
            this.lstSummaryReport = new ListView();
            this.lblFromDate = new Label();
            this.groupBox1 = new GroupBox();
            this.dtpFromDate = new DateTimePicker();
            ((ISupportInitialize) this.lstRegularEmployee).BeginInit();
            this.tabReports.SuspendLayout();
            this.tabDailyReport.SuspendLayout();
            this.tabSummary.SuspendLayout();
            this.groupBox1.SuspendLayout();
            base.SuspendLayout();
            style.Alignment = DataGridViewContentAlignment.TopLeft;
            style.NullValue = false;
            this.Column1.DefaultCellStyle = style;
            this.Column1.HeaderText = "";
            this.Column1.Name = "Column1";
            this.Column1.Width = 0x19;
            style2.Alignment = DataGridViewContentAlignment.TopLeft;
            this.clmNumber.DefaultCellStyle = style2;
            this.clmNumber.HeaderText = "Number";
            this.clmNumber.Name = "clmNumber";
            this.clmNumber.ReadOnly = true;
            this.clmNumber.Width = 70;
            this.columnHeader3.Width = 0;
            this.columnHeader4.Text = "Report";
            this.columnHeader4.Width = 0x11f;
            style3.Alignment = DataGridViewContentAlignment.TopLeft;
            this.clmEmpName.DefaultCellStyle = style3;
            this.clmEmpName.HeaderText = "Employee Name";
            this.clmEmpName.Name = "clmEmpName";
            this.clmEmpName.ReadOnly = true;
            this.clmEmpName.Width = 380;
            this.btnPrint.Location = new Point(0x285, 0x17b);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new Size(0x45, 0x17);
            this.btnPrint.TabIndex = 20;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new EventHandler(this.btnPrint_Click);
            this.btnClearAll.Location = new Point(0x4c, 0x17b);
            this.btnClearAll.Name = "btnClearAll";
            this.btnClearAll.Size = new Size(0x45, 0x17);
            this.btnClearAll.TabIndex = 0x13;
            this.btnClearAll.Text = "Clear All";
            this.btnClearAll.UseVisualStyleBackColor = true;
            this.btnClearAll.Click += new EventHandler(this.btnClearAll_Click);
            this.btnExit.Location = new Point(720, 0x17b);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new Size(0x4b, 0x17);
            this.btnExit.TabIndex = 0x12;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new EventHandler(this.btnExit_Click);
            this.btnSelectAll.Location = new Point(1, 0x17b);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new Size(0x45, 0x17);
            this.btnSelectAll.TabIndex = 0x11;
            this.btnSelectAll.Text = "Select All";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new EventHandler(this.btnSelectAll_Click);
            this.lstRegularEmployee.AllowUserToAddRows = false;
            this.lstRegularEmployee.AllowUserToDeleteRows = false;
            this.lstRegularEmployee.AllowUserToResizeColumns = false;
            this.lstRegularEmployee.AllowUserToResizeRows = false;
            this.lstRegularEmployee.BackgroundColor = SystemColors.ControlLightLight;
            style4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            style4.BackColor = SystemColors.Control;
            style4.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            style4.ForeColor = SystemColors.WindowText;
            style4.SelectionBackColor = SystemColors.Highlight;
            style4.SelectionForeColor = SystemColors.HighlightText;
            style4.WrapMode = DataGridViewTriState.True;
            this.lstRegularEmployee.ColumnHeadersDefaultCellStyle = style4;
            this.lstRegularEmployee.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.lstRegularEmployee.Columns.AddRange(new DataGridViewColumn[] { this.Column1, this.clmNumber, this.clmEmpName });
            this.lstRegularEmployee.Location = new Point(2, 0x34);
            this.lstRegularEmployee.Name = "lstRegularEmployee";
            this.lstRegularEmployee.RowHeadersVisible = false;
            this.lstRegularEmployee.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.lstRegularEmployee.Size = new Size(0x1e3, 0x141);
            this.lstRegularEmployee.TabIndex = 0x10;
            this.tabReports.Controls.Add(this.tabDailyReport);
            this.tabReports.Controls.Add(this.tabSummary);
            this.tabReports.Location = new Point(0x1eb, 8);
            this.tabReports.Name = "tabReports";
            this.tabReports.SelectedIndex = 0;
            this.tabReports.Size = new Size(0x133, 0x171);
            this.tabReports.TabIndex = 15;
            this.tabDailyReport.Controls.Add(this.lstDailyReport);
            this.tabDailyReport.Location = new Point(4, 0x16);
            this.tabDailyReport.Name = "tabDailyReport";
            this.tabDailyReport.Padding = new Padding(3);
            this.tabDailyReport.Size = new Size(0x12b, 0x157);
            this.tabDailyReport.TabIndex = 0;
            this.tabDailyReport.Text = "Daily Report";
            this.tabDailyReport.UseVisualStyleBackColor = true;
            this.lstDailyReport.Columns.AddRange(new ColumnHeader[] { this.ReportID, this.ReportName });
            this.lstDailyReport.FullRowSelect = true;
            this.lstDailyReport.Location = new Point(3, 6);
            this.lstDailyReport.Name = "lstDailyReport";
            this.lstDailyReport.Size = new Size(0x125, 330);
            this.lstDailyReport.TabIndex = 1;
            this.lstDailyReport.UseCompatibleStateImageBehavior = false;
            this.lstDailyReport.View = View.Details;
            this.lstDailyReport.DoubleClick += new EventHandler(this.lstDailyReport_DoubleClick);
            this.ReportID.Width = 0;
            this.ReportName.Text = "Report";
            this.ReportName.Width = 0x11f;
            this.tabSummary.Controls.Add(this.lstSummaryReport);
            this.tabSummary.Location = new Point(4, 0x16);
            this.tabSummary.Name = "tabSummary";
            this.tabSummary.Padding = new Padding(3);
            this.tabSummary.Size = new Size(0x12b, 0x157);
            this.tabSummary.TabIndex = 1;
            this.tabSummary.Text = "Summary";
            this.tabSummary.UseVisualStyleBackColor = true;
            this.lstSummaryReport.Columns.AddRange(new ColumnHeader[] { this.columnHeader3, this.columnHeader4 });
            this.lstSummaryReport.FullRowSelect = true;
            this.lstSummaryReport.Location = new Point(3, 6);
            this.lstSummaryReport.Name = "lstSummaryReport";
            this.lstSummaryReport.Size = new Size(0x125, 330);
            this.lstSummaryReport.TabIndex = 3;
            this.lstSummaryReport.UseCompatibleStateImageBehavior = false;
            this.lstSummaryReport.View = View.Details;
            this.lblFromDate.AutoSize = true;
            this.lblFromDate.Location = new Point(6, 0x10);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new Size(30, 13);
            this.lblFromDate.TabIndex = 20;
            this.lblFromDate.Text = "Date";
            this.groupBox1.Controls.Add(this.dtpFromDate);
            this.groupBox1.Controls.Add(this.lblFromDate);
            this.groupBox1.Location = new Point(1, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(480, 0x2c);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.dtpFromDate.Format = DateTimePickerFormat.Short;
            this.dtpFromDate.Location = new Point(0x44, 0x10);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new Size(0x54, 20);
            this.dtpFromDate.TabIndex = 0x15;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x31f, 0x194);
            base.Controls.Add(this.btnPrint);
            base.Controls.Add(this.btnClearAll);
            base.Controls.Add(this.btnExit);
            base.Controls.Add(this.btnSelectAll);
            base.Controls.Add(this.lstRegularEmployee);
            base.Controls.Add(this.tabReports);
            base.Controls.Add(this.groupBox1);
            base.Name = "frmCoacherReports";
            this.Text = "Pool Attendance System";
            base.Load += new EventHandler(this.frmCoacherReports_Load);
            ((ISupportInitialize) this.lstRegularEmployee).EndInit();
            this.tabReports.ResumeLayout(false);
            this.tabDailyReport.ResumeLayout(false);
            this.tabSummary.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
                if (reports.Rows[i][7].ToString() == "C")
                {
                    if (reports.Rows[i][5].ToString() == "D")
                    {
                        this.lstDailyReport.Items.Add(item);
                    }
                    else if (reports.Rows[i][5].ToString() == "S")
                    {
                        this.lstSummaryReport.Items.Add(item);
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

        private void ReportViwer(string strReportID, string strReportName)
        {
            int reportID = Convert.ToInt16(strReportID);
            object[,] arrParameter = new object[,] { { "strCompanyName", this.cGlobalVariable.CustomerName }, { "strCopyRight", this.cGlobalVariable.CopyRight }, { "dFromDate", this.dtpFromDate.Value }, { "strReportTitle", strReportName } };
            new frmReportViewer(reportID, this.cGlobalVariable.LocationCode, this.SelectionFormularValues(reportID), arrParameter).Show();
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
                        str = str3 + "{" + this.oReportMaster.SelectedTable + ".fldCoacherCode}='" + this.lstRegularEmployee.Rows[i].Cells[1].Value.ToString() + "'";
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
            DataTable coacherData = this.cCoacherMaster.GetCoacherData(this.cGlobalVariable.LocationCode);
            if (coacherData.Rows.Count > 0)
            {
                for (int i = 0; i <= (coacherData.Rows.Count - 1); i++)
                {
                    int count = this.lstRegularEmployee.Rows.Count;
                    this.lstRegularEmployee.Rows.Add(1);
                    this.lstRegularEmployee.Rows[count].Cells[1].Value = coacherData.Rows[i][2].ToString();
                    this.lstRegularEmployee.Rows[count].Cells[2].Value = coacherData.Rows[i][4].ToString();
                }
            }
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

