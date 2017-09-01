using Business_Layer;
using Business_Layer.Property_Layer;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Windows.Forms;
using Database_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Reflection;

namespace Report_Layer
{
    public partial class frmReportViewer : Form
    {
        private object[,] arrParamFields;
        private IContainer components;
        private CrystalReportViewer CryReportViewer;
        private int iReportID;
        private objReportMaster oReportMaster;
        private string ReportType;
        private string strLocationCode;
        private string strReport;
        private string strSelectionFormular;

        clsDBConnect cDBConnection = new clsDBConnect();

        //public frmReportViewer()
        //{
        //    InitializeComponent();
        //}

        public frmReportViewer()
        {
            //this.components = null;
            this.oReportMaster = new objReportMaster();
            this.strSelectionFormular = string.Empty;
            this.strReport = null;
            this.InitializeComponent();
        }

        public frmReportViewer(string strReportName)
        {
            //this.components = null;
            this.oReportMaster = new objReportMaster();
            this.strSelectionFormular = string.Empty;
            this.strReport = null;
            this.InitializeComponent();
            this.strReport = strReportName;
        }

        public frmReportViewer(string SelectionFormular, object[,] arrParameter)
        {
            //this.components = null;
            this.oReportMaster = new objReportMaster();
            this.strSelectionFormular = string.Empty;
            this.strReport = null;
            this.InitializeComponent();
            this.strSelectionFormular = SelectionFormular;
            this.arrParamFields = new object[arrParameter.GetLength(0) - 1, 2];
            this.arrParamFields = arrParameter;
            this.PrintReport(this.arrParamFields);
        }

        public frmReportViewer(string SelectionFormular, object[,] arrParameter, string strReportType)
        {
            //this.components = null;
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

        public frmReportViewer(string strReportName, string SelectionFormular, object[,] arrParameter)
        {
            //this.components = null;
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

        public frmReportViewer(int ReportID, string LocationCode, string SelectionFormular, object[,] arrParameter)
        {
            //this.components = null;
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

        private void frmReportViever_Load(object sender, EventArgs e)
        {
            //this.LoadReportDeta();
            ReportDocument document = new ReportDocument();

            if (this.oReportMaster.ReportName != null)
            {
                //document.FileName = Application.StartupPath + @"\Reports\" + this.oReportMaster.ReportName;
                document.FileName = @"E:\Pool Application\Pool Application\Report Layer\" + this.oReportMaster.ReportName;
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
            ////database login
            //ConnectionInfo connectionInfo = new ConnectionInfo();
            //connectionInfo.ServerName = cDBConnection.strServerName;
            //connectionInfo.DatabaseName = cDBConnection.strDatabaseName;
            //connectionInfo.UserID = cDBConnection.strDBUserName;
            //connectionInfo.Password = cDBConnection.strDBPassword;
            //connectionInfo.IntegratedSecurity = true;

            try
            {
                document.SetDatabaseLogon("root", "root", "localhost", "pool_system");
            }
            catch (Exception ex)
            {

            }
            
            //SetDBLogonForReport(connectionInfo, document);

            this.CryReportViewer.ReportSource = document;
        }

        private void SetDBLogonForReport(ConnectionInfo connectionInfo, ReportDocument reportDocument)
        {
            Tables tables = reportDocument.Database.Tables;
            foreach (CrystalDecisions.CrystalReports.Engine.Table table in tables)
            {
                TableLogOnInfo tableLogonInfo = table.LogOnInfo;
                tableLogonInfo.ConnectionInfo = connectionInfo;
                table.ApplyLogOnInfo(tableLogonInfo);
            }
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
                ParameterField parameterField = new ParameterField
                {
                    Name = arrParameter[i, 0].ToString()
                };
                ParameterDiscreteValue value2 = new ParameterDiscreteValue
                {
                    Value = arrParameter[i, 1].ToString()
                };
                parameterField.CurrentValues.Add((ParameterValue)value2);
                fields.Add(parameterField);
                this.CryReportViewer.ParameterFieldInfo = fields;
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
                        num = (int)document2.PrinterSettings.PaperSizes[i].GetType().GetField("kind", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(document2.PrinterSettings.PaperSizes[i]);
                    }
                }
                document.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)num;
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
