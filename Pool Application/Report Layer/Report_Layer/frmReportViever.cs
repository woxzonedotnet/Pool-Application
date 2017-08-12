namespace Report_Layer
{
    using Business_Layer;
    using Business_Layer.Property_Layer;
    using CrystalDecisions.CrystalReports.Engine;
    using CrystalDecisions.Shared;
    using CrystalDecisions.Windows.Forms;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Printing;
    using System.Reflection;
    using System.Windows.Forms;

    public class frmReportViever : Form
    {
        private object[,] arrParamFields;
        private IContainer components;
        private CrystalReportViewer crystalReportViewer1;
        private int iReportID;
        private objReportMaster oReportMaster;
        private string ReportType;
        private string strLocationCode;
        private string strReport;
        private string strSelectionFormular;

        public frmReportViever()
        {
            this.components = null;
            this.oReportMaster = new objReportMaster();
            this.strSelectionFormular = string.Empty;
            this.strReport = null;
            this.InitializeComponent();
        }

        public frmReportViever(string strReportName)
        {
            this.components = null;
            this.oReportMaster = new objReportMaster();
            this.strSelectionFormular = string.Empty;
            this.strReport = null;
            this.InitializeComponent();
            this.strReport = strReportName;
        }

        public frmReportViever(string SelectionFormular, object[,] arrParameter)
        {
            this.components = null;
            this.oReportMaster = new objReportMaster();
            this.strSelectionFormular = string.Empty;
            this.strReport = null;
            this.InitializeComponent();
            this.strSelectionFormular = SelectionFormular;
            this.arrParamFields = new object[arrParameter.GetLength(0) - 1, 2];
            this.arrParamFields = arrParameter;
            this.PrintReport(this.arrParamFields);
        }

        public frmReportViever(string SelectionFormular, object[,] arrParameter, string strReportType)
        {
            this.components = null;
            this.oReportMaster = new objReportMaster();
            this.strSelectionFormular = string.Empty;
            this.strReport = null;
            this.InitializeComponent();
            this.strSelectionFormular = SelectionFormular;
            this.arrParamFields = new object[arrParameter.GetLength(0) - 1, 2];
            this.arrParamFields = arrParameter;
            this.ReportType = strReportType;
            this.PrintReport(this.arrParamFields);
        }

        public frmReportViever(string strReportName, string SelectionFormular, object[,] arrParameter)
        {
            this.components = null;
            this.oReportMaster = new objReportMaster();
            this.strSelectionFormular = string.Empty;
            this.strReport = null;
            this.InitializeComponent();
            this.strSelectionFormular = SelectionFormular;
            this.strReport = strReportName;
            this.arrParamFields = new object[arrParameter.GetLength(0) - 1, 2];
            this.arrParamFields = arrParameter;
            this.PassParemeterFields(this.arrParamFields);
        }

        public frmReportViever(int ReportID, string LocationCode, string SelectionFormular, object[,] arrParameter)
        {
            this.components = null;
            this.oReportMaster = new objReportMaster();
            this.strSelectionFormular = string.Empty;
            this.strReport = null;
            this.InitializeComponent();
            this.iReportID = ReportID;
            this.strSelectionFormular = SelectionFormular;
            this.strLocationCode = LocationCode;
            this.arrParamFields = new object[arrParameter.GetLength(0) - 1, 2];
            this.arrParamFields = arrParameter;
            this.PassParemeterFields(this.arrParamFields);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void frmReportViever_Load(object sender, EventArgs e)
        {
            this.LoadReportDeta();
            ReportDocument document = new ReportDocument();
            if (this.oReportMaster.ReportName != null)
            {
                document.FileName = Application.StartupPath + @"\Reports\" + this.oReportMaster.ReportName;
            }
            else if (this.strReport != null)
            {
                document.FileName = Application.StartupPath + @"\Reports\" + this.strReport;
            }
            else if (this.strReport == "rptCoacherBarcode.rpt")
            {
                document.FileName = Application.StartupPath + @"\Reports\rptCoacherBarcode.rpt";
            }
            else
            {
                document.FileName = Application.StartupPath + @"\Reports\BarcodePrint.rpt";
            }
            document.RecordSelectionFormula = this.strSelectionFormular;
            this.crystalReportViewer1.ReportSource = document;
        }

        private void InitializeComponent()
        {
            this.crystalReportViewer1 = new CrystalReportViewer();
            base.SuspendLayout();
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = BorderStyle.FixedSingle;
            this.crystalReportViewer1.DisplayGroupTree = false;
            this.crystalReportViewer1.Dock = DockStyle.Fill;
            this.crystalReportViewer1.Location = new Point(0, 0);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.SelectionFormula = "";
            this.crystalReportViewer1.Size = new Size(0x27f, 0x1d3);
            this.crystalReportViewer1.TabIndex = 0;
            this.crystalReportViewer1.ViewTimeSelectionFormula = "";
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x27f, 0x1d3);
            base.Controls.Add(this.crystalReportViewer1);
            base.Name = "frmReportViever";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Pool Attendance System";
            base.WindowState = FormWindowState.Maximized;
            base.Load += new EventHandler(this.frmReportViever_Load);
            base.ResumeLayout(false);
        }

        private void LoadReportDeta()
        {
            this.oReportMaster = new clsReportMaster().GetReports(this.iReportID);
        }

        private void PassParemeterFields(object[,] arrParameter)
        {
            ReportDocument document = new ReportDocument();
            ParameterFields fields = new ParameterFields();
            for (int i = 0; i <= (arrParameter.GetLength(0) - 1); i++)
            {
                ParameterField parameterField = new ParameterField {
                    Name = arrParameter[i, 0].ToString()
                };
                ParameterDiscreteValue value2 = new ParameterDiscreteValue {
                    Value = arrParameter[i, 1].ToString()
                };
                parameterField.CurrentValues.Add((ParameterValue) value2);
                fields.Add(parameterField);
                this.crystalReportViewer1.ParameterFieldInfo = fields;
            }
        }

        private void PrintReport(object[,] arrParameter)
        {
            ReportDocument document = new ReportDocument();
            document = new rptInvoiceNew();
            try
            {
                PrintDocument document2 = new PrintDocument();
                document.PrintOptions.PrinterName = document2.PrinterSettings.PrinterName;
                int num = 0;
                for (int i = 0; i < document2.PrinterSettings.PaperSizes.Count; i++)
                {
                    if (document2.PrinterSettings.PaperSizes[i].PaperName == "Pool")
                    {
                        num = (int) document2.PrinterSettings.PaperSizes[i].GetType().GetField("kind", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(document2.PrinterSettings.PaperSizes[i]);
                    }
                }
                document.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize) num;
                if (this.ReportType == "DP")
                {
                    document.FileName = Application.StartupPath + @"\Reports\rptDailyPaymentInvoice.rpt";
                }
                else
                {
                    document.FileName = Application.StartupPath + @"\Reports\rptInvoiceNew.rpt";
                }
                this.arrParamFields = new object[arrParameter.GetLength(0) - 1, 2];
                this.arrParamFields = arrParameter;
                document.SetParameterValue("strCopyRight", this.arrParamFields[0, 1]);
                document.SetParameterValue("strInvoiceNo", this.arrParamFields[1, 1]);
                document.RecordSelectionFormula = this.strSelectionFormular;
                document.PrintToPrinter(1, false, 1, 1);
                MessageBox.Show("Report finished printing!");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }
        }
    }
}

