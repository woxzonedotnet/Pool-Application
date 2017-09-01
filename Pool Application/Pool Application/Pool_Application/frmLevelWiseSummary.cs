namespace Pool_Application
{
    using Business_Layer;
    using Report_Layer;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class frmLevelWiseSummary : Form
    {
        private Button btnABCReport;
        private Button btnLoadReport;
        private clsGlobleVariable cGlobalVariable = new clsGlobleVariable();
        private ComboBox cmbMonths;
        private IContainer components = null;

        public frmLevelWiseSummary()
        {
            this.InitializeComponent();
        }

        private void btnABCReport_Click(object sender, EventArgs e)
        {
            string selectionFormular = string.Empty;
            object[,] arrParameter = new object[7, 2];
            arrParameter = new object[4, 2];
            string str2 = Convert.ToDateTime(this.cmbMonths.Text + "01").ToString("yyyy-MM-dd");
            arrParameter[0, 0] = "strCompanyName";
            arrParameter[0, 1] = this.cGlobalVariable.CustomerName;
            arrParameter[1, 0] = "strCopyRight";
            arrParameter[1, 1] = this.cGlobalVariable.CopyRight;
            arrParameter[2, 0] = "dFromDate";
            arrParameter[2, 1] = str2;
            arrParameter[3, 0] = "strReportTitle";
            arrParameter[3, 1] = "ABC Report - " + this.cmbMonths.Text;
            new frmReportViewer("rptABCReport.rpt", selectionFormular, arrParameter).Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string strStartDate = Convert.ToDateTime(this.cmbMonths.Text + "01").ToString("yyyy-MM-dd");
            string strEndDate = Convert.ToDateTime(this.cmbMonths.Text + "01").AddMonths(1).AddDays(-1.0).ToString("yyyy-MM-dd");
            new clsReportProcess().LevelSummaryReport(strStartDate, strEndDate);
            string selectionFormular = string.Empty;
            object[,] arrParameter = new object[7, 2];
            arrParameter = new object[,] { { "strCompanyName", this.cGlobalVariable.CustomerName }, { "strCopyRight", this.cGlobalVariable.CopyRight }, { "dFromDate", strStartDate }, { "strReportTitle", "Level Wise Summary Report" }, { "dToDate", strEndDate } };
            new frmReportViewer("rptMonthlyLevelWiseSummary.rpt", selectionFormular, arrParameter).Show();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void frmLevelWiseSummary_Load(object sender, EventArgs e)
        {
            for (int i = -6; i < 6; i++)
            {
                DateTime time = DateTime.Now.AddMonths(i);
                this.cmbMonths.Items.Add(time.ToString("yyyy-MMMM"));
            }
            this.cmbMonths.Text = DateTime.Now.ToString("yyyy-MMMM");
        }

        private void InitializeComponent()
        {
            this.btnLoadReport = new Button();
            this.cmbMonths = new ComboBox();
            this.btnABCReport = new Button();
            base.SuspendLayout();
            this.btnLoadReport.Location = new Point(0x25, 0x55);
            this.btnLoadReport.Name = "btnLoadReport";
            this.btnLoadReport.Size = new Size(0xe3, 0x17);
            this.btnLoadReport.TabIndex = 0;
            this.btnLoadReport.Text = "Level Wise Summary report";
            this.btnLoadReport.UseVisualStyleBackColor = true;
            this.btnLoadReport.Click += new EventHandler(this.button1_Click);
            this.cmbMonths.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbMonths.FormattingEnabled = true;
            this.cmbMonths.Location = new Point(0x25, 0x1b);
            this.cmbMonths.Name = "cmbMonths";
            this.cmbMonths.Size = new Size(0xe3, 0x15);
            this.cmbMonths.TabIndex = 1;
            this.btnABCReport.Location = new Point(0x25, 0x72);
            this.btnABCReport.Name = "btnABCReport";
            this.btnABCReport.Size = new Size(0xe3, 0x17);
            this.btnABCReport.TabIndex = 2;
            this.btnABCReport.Text = "ABC Report";
            this.btnABCReport.UseVisualStyleBackColor = true;
            this.btnABCReport.Click += new EventHandler(this.btnABCReport_Click);
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x12d, 0x90);
            base.Controls.Add(this.btnABCReport);
            base.Controls.Add(this.cmbMonths);
            base.Controls.Add(this.btnLoadReport);
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "frmLevelWiseSummary";
            this.Text = "Level wise summary";
            base.Load += new EventHandler(this.frmLevelWiseSummary_Load);
            base.ResumeLayout(false);
        }
    }
}

