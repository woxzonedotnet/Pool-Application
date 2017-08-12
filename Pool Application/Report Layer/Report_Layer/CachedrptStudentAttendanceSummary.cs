namespace Report_Layer
{
    using CrystalDecisions.CrystalReports.Engine;
    using CrystalDecisions.ReportSource;
    using CrystalDecisions.Shared;
    using System;
    using System.ComponentModel;
    using System.Drawing;

    [ToolboxBitmap(typeof(ExportOptions), "report.bmp")]
    public class CachedrptStudentAttendanceSummary : Component, ICachedReport
    {
        public virtual ReportDocument CreateReport()
        {
            return new rptStudentAttendanceSummary { Site = this.Site };
        }

        public virtual string GetCustomizedCacheKey(RequestContext request)
        {
            return null;
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual TimeSpan CacheTimeOut
        {
            get
            {
                return CachedReportConstants.DEFAULT_TIMEOUT;
            }
            set
            {
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual bool IsCacheable
        {
            get
            {
                return true;
            }
            set
            {
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual bool ShareDBLogonInfo
        {
            get
            {
                return false;
            }
            set
            {
            }
        }
    }
}

