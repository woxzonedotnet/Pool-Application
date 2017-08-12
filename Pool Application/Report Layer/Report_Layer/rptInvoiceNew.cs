namespace Report_Layer
{
    using CrystalDecisions.CrystalReports.Engine;
    using CrystalDecisions.Shared;
    using System;
    using System.ComponentModel;

    public class rptInvoiceNew : ReportClass
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public Section DetailSection1
        {
            get
            {
                return this.ReportDefinition.Sections[5];
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public Section DetailSection2
        {
            get
            {
                return this.ReportDefinition.Sections[6];
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Section DetailSection3
        {
            get
            {
                return this.ReportDefinition.Sections[4];
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public Section GroupFooterSection1
        {
            get
            {
                return this.ReportDefinition.Sections[7];
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Section GroupHeaderSection1
        {
            get
            {
                return this.ReportDefinition.Sections[2];
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IParameterField Parameter_rptInvoiceClassTimerpt_Pm_tbl_student_masterfldStudentNo
        {
            get
            {
                return this.DataDefinition.ParameterFields[2];
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public IParameterField Parameter_rptInvoiceItemReportrpt_Pm_strInvoiceNo
        {
            get
            {
                return this.DataDefinition.ParameterFields[3];
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public IParameterField Parameter_rptInvoiceItemReportrpt_Pm_tbl_student_masterfldStudentNo
        {
            get
            {
                return this.DataDefinition.ParameterFields[4];
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IParameterField Parameter_rptInvoiceTaxReportrpt_Pm_strInvoiceNo
        {
            get
            {
                return this.DataDefinition.ParameterFields[5];
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IParameterField Parameter_rptInvoiceTaxReportrpt_Pm_tbl_student_masterfldStudentNo
        {
            get
            {
                return this.DataDefinition.ParameterFields[6];
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public IParameterField Parameter_strCopyRight
        {
            get
            {
                return this.DataDefinition.ParameterFields[1];
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IParameterField Parameter_strInvoiceNo
        {
            get
            {
                return this.DataDefinition.ParameterFields[0];
            }
        }

        public override string ResourceName
        {
            get
            {
                return "rptInvoiceNew.rpt";
            }
            set
            {
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public Section Section1
        {
            get
            {
                return this.ReportDefinition.Sections[0];
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Section Section2
        {
            get
            {
                return this.ReportDefinition.Sections[1];
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Section Section3
        {
            get
            {
                return this.ReportDefinition.Sections[3];
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public Section Section4
        {
            get
            {
                return this.ReportDefinition.Sections[8];
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Section Section5
        {
            get
            {
                return this.ReportDefinition.Sections[9];
            }
        }
    }
}

