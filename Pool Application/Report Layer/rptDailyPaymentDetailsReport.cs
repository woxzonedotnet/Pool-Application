﻿namespace Report_Layer
{
    using CrystalDecisions.CrystalReports.Engine;
    using CrystalDecisions.Shared;
    using System;
    using System.ComponentModel;

    public class rptDailyPaymentDetailsReport : ReportClass
    {
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IParameterField Parameter_dFromDate
        {
            get
            {
                return this.DataDefinition.ParameterFields[1];
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public IParameterField Parameter_dToDate
        {
            get
            {
                return this.DataDefinition.ParameterFields[3];
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IParameterField Parameter_strCompanyName
        {
            get
            {
                return this.DataDefinition.ParameterFields[2];
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IParameterField Parameter_strCopyRight
        {
            get
            {
                return this.DataDefinition.ParameterFields[4];
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IParameterField Parameter_strReportTitle
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
                return "rptDailyPaymentDetailsReport.rpt";
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

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
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
                return this.ReportDefinition.Sections[2];
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public Section Section4
        {
            get
            {
                return this.ReportDefinition.Sections[3];
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public Section Section5
        {
            get
            {
                return this.ReportDefinition.Sections[4];
            }
        }
    }
}

