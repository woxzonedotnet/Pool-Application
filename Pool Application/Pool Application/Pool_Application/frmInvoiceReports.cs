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

    public class frmInvoiceReports : Form
    {
        private Button btnExit;
        private Button btnPrint;
        private clsGlobleVariable cGlobalVariable = new clsGlobleVariable();
        private clsCommenMethods clsCommen = new clsCommenMethods();
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private IContainer components = null;
        private clsReportMaster cReportMaster = new clsReportMaster();
        private DateTimePicker dtpFromDate;
        private DateTimePicker dtpToDate;
        private GroupBox groupBox1;
        private Label lblFromDate;
        private Label lblToDate;
        private ListView lstDailyReport;
        private ListView lstSummaryReport;
        private objReportMaster oReportMaster = new objReportMaster();
        private ColumnHeader ReportID;
        private ColumnHeader ReportName;
        private string strSeletedTab = "tabDailyReport";
        private TabPage tabDailyReport;
        private TabControl tabReports;
        private TabPage tabSummary;

        public frmInvoiceReports()
        {
            this.InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (this.tabReports.SelectedIndex == 0)
            {
                this.InvoiceReportView(this.lstDailyReport.SelectedItems[0].SubItems[0].Text, this.lstDailyReport.SelectedItems[0].SubItems[1].Text);
            }
            else if (this.tabReports.SelectedIndex == 1)
            {
                this.InvoiceReportView(this.lstSummaryReport.SelectedItems[0].SubItems[0].Text, this.lstSummaryReport.SelectedItems[0].SubItems[1].Text);
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
        }

        private void frmInvoiceReports_Load(object sender, EventArgs e)
        {
            this.tabReports.SelectTab(this.strSeletedTab);
            this.LoadReport();
            this.SelectedTab();
        }

        private void InitializeComponent()
        {
            this.tabReports = new TabControl();
            this.tabDailyReport = new TabPage();
            this.lstDailyReport = new ListView();
            this.ReportID = new ColumnHeader();
            this.ReportName = new ColumnHeader();
            this.tabSummary = new TabPage();
            this.lstSummaryReport = new ListView();
            this.columnHeader3 = new ColumnHeader();
            this.columnHeader4 = new ColumnHeader();
            this.btnPrint = new Button();
            this.btnExit = new Button();
            this.groupBox1 = new GroupBox();
            this.dtpToDate = new DateTimePicker();
            this.lblToDate = new Label();
            this.dtpFromDate = new DateTimePicker();
            this.lblFromDate = new Label();
            this.tabReports.SuspendLayout();
            this.tabDailyReport.SuspendLayout();
            this.tabSummary.SuspendLayout();
            this.groupBox1.SuspendLayout();
            base.SuspendLayout();
            this.tabReports.Controls.Add(this.tabDailyReport);
            this.tabReports.Controls.Add(this.tabSummary);
            this.tabReports.Location = new Point(-3, 0x39);
            this.tabReports.Name = "tabReports";
            this.tabReports.SelectedIndex = 0;
            this.tabReports.Size = new Size(0x1d3, 0x135);
            this.tabReports.TabIndex = 7;
            this.tabReports.Click += new EventHandler(this.tabReports_Click);
            this.tabDailyReport.Controls.Add(this.lstDailyReport);
            this.tabDailyReport.Location = new Point(4, 0x16);
            this.tabDailyReport.Name = "tabDailyReport";
            this.tabDailyReport.Padding = new Padding(3);
            this.tabDailyReport.Size = new Size(0x1cb, 0x11b);
            this.tabDailyReport.TabIndex = 0;
            this.tabDailyReport.Text = "Daily Report";
            this.tabDailyReport.UseVisualStyleBackColor = true;
            this.lstDailyReport.Columns.AddRange(new ColumnHeader[] { this.ReportID, this.ReportName });
            this.lstDailyReport.FullRowSelect = true;
            this.lstDailyReport.Location = new Point(3, 6);
            this.lstDailyReport.Name = "lstDailyReport";
            this.lstDailyReport.Size = new Size(450, 0x10f);
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
            this.tabSummary.Size = new Size(0x1cb, 0x11b);
            this.tabSummary.TabIndex = 1;
            this.tabSummary.Text = "Summary";
            this.tabSummary.UseVisualStyleBackColor = true;
            this.lstSummaryReport.Columns.AddRange(new ColumnHeader[] { this.columnHeader3, this.columnHeader4 });
            this.lstSummaryReport.FullRowSelect = true;
            this.lstSummaryReport.Location = new Point(3, 6);
            this.lstSummaryReport.Name = "lstSummaryReport";
            this.lstSummaryReport.Size = new Size(450, 0x10f);
            this.lstSummaryReport.TabIndex = 2;
            this.lstSummaryReport.UseCompatibleStateImageBehavior = false;
            this.lstSummaryReport.View = View.Details;
            this.lstSummaryReport.DoubleClick += new EventHandler(this.lstSummaryReport_DoubleClick);
            this.columnHeader3.Width = 0;
            this.columnHeader4.Text = "Report";
            this.columnHeader4.Width = 0x11f;
            this.btnPrint.Location = new Point(0x13a, 0x174);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new Size(0x45, 0x17);
            this.btnPrint.TabIndex = 15;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new EventHandler(this.btnPrint_Click);
            this.btnExit.Location = new Point(0x185, 0x174);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new Size(0x4b, 0x17);
            this.btnExit.TabIndex = 14;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new EventHandler(this.btnExit_Click);
            this.groupBox1.Controls.Add(this.dtpToDate);
            this.groupBox1.Controls.Add(this.lblToDate);
            this.groupBox1.Controls.Add(this.dtpFromDate);
            this.groupBox1.Controls.Add(this.lblFromDate);
            this.groupBox1.Location = new Point(3, -8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(0x1cd, 0x3d);
            this.groupBox1.TabIndex = 0x11;
            this.groupBox1.TabStop = false;
            this.dtpToDate.Format = DateTimePickerFormat.Short;
            this.dtpToDate.Location = new Point(0xeb, 20);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new Size(0x54, 20);
            this.dtpToDate.TabIndex = 0x19;
            this.dtpToDate.Visible = false;
            this.lblToDate.AutoSize = true;
            this.lblToDate.Location = new Point(0xb7, 0x18);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.Size = new Size(0x2e, 13);
            this.lblToDate.TabIndex = 0x18;
            this.lblToDate.Text = "To Date";
            this.lblToDate.Visible = false;
            this.dtpFromDate.Format = DateTimePickerFormat.Short;
            this.dtpFromDate.Location = new Point(0x47, 20);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new Size(0x54, 20);
            this.dtpFromDate.TabIndex = 0x15;
            this.dtpFromDate.ValueChanged += new EventHandler(this.dtpFromDate_ValueChanged);
            this.lblFromDate.AutoSize = true;
            this.lblFromDate.Location = new Point(9, 0x18);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new Size(0x38, 13);
            this.lblFromDate.TabIndex = 20;
            this.lblFromDate.Text = "From Date";
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x1d9, 0x197);
            base.Controls.Add(this.groupBox1);
            base.Controls.Add(this.btnPrint);
            base.Controls.Add(this.btnExit);
            base.Controls.Add(this.tabReports);
            base.Name = "frmInvoiceReports";
            this.Text = "Income Reports";
            base.Load += new EventHandler(this.frmInvoiceReports_Load);
            this.tabReports.ResumeLayout(false);
            this.tabDailyReport.ResumeLayout(false);
            this.tabSummary.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            base.ResumeLayout(false);
        }

        private void InvoiceReportView(string strReportID, string strReportName)
        {
            int reportID = Convert.ToInt16(strReportID);
            string selectionFormular = string.Empty;
            this.oReportMaster = this.cReportMaster.GetReports(reportID);
            if (this.oReportMaster.SelectionFormular.ToString() != string.Empty)
            {
                selectionFormular = "{tbl_location_master.fldLocationCode} ='" + this.cGlobalVariable.LocationCode + "' AND " + this.oReportMaster.SelectionFormular;
            }
            else
            {
                selectionFormular = "{tbl_location_master.fldLocationCode} ='" + this.cGlobalVariable.LocationCode + "'";
            }
            object[,] arrParameter = new object[7, 2];
            arrParameter = new object[,] { { "strCompanyName", this.cGlobalVariable.CustomerName }, { "strCopyRight", this.cGlobalVariable.CopyRight }, { "dFromDate", this.dtpFromDate.Value }, { "strReportTitle", strReportName }, { "dToDate", this.dtpToDate.Value } };
            new frmReportViewer(reportID, this.cGlobalVariable.LocationCode, selectionFormular, arrParameter).Show();
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
                if (reports.Rows[i][5].ToString() == "ID")
                {
                    this.lstDailyReport.Items.Add(item);
                }
                else if (reports.Rows[i][5].ToString() == "IS")
                {
                    this.lstSummaryReport.Items.Add(item);
                }
            }
        }

        private void lstDailyReport_DoubleClick(object sender, EventArgs e)
        {
            this.InvoiceReportView(this.lstDailyReport.SelectedItems[0].SubItems[0].Text, this.lstDailyReport.SelectedItems[0].SubItems[1].Text);
        }

        private void lstSummaryReport_DoubleClick(object sender, EventArgs e)
        {
            this.InvoiceReportView(this.lstSummaryReport.SelectedItems[0].SubItems[0].Text, this.lstSummaryReport.SelectedItems[0].SubItems[1].Text);
        }

        private void SelectedTab()
        {
            if (this.tabReports.SelectedIndex == 0)
            {
                this.lblFromDate.Text = "Date";
                this.lblToDate.Visible = false;
                this.dtpToDate.Visible = false;
                this.dtpFromDate.Value = this.dtpToDate.Value;
            }
            else
            {
                this.lblFromDate.Text = "From Date";
                this.lblToDate.Visible = true;
                this.dtpToDate.Visible = true;
            }
        }

        private void tabReports_Click(object sender, EventArgs e)
        {
            this.SelectedTab();
        }
    }
}

