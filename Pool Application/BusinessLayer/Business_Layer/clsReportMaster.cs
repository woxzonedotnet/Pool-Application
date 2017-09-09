namespace Business_Layer
{
    using Business_Layer.Property_Layer;
    using BusinessLayer;
    using Database_Layer;
    using System;
    using System.Data;

    public class clsReportMaster
    {
        private clsDBConnect DbConn = new clsDBConnect();

        public void ExecuteAttendanceSheet(objReportMaster ReportMaster)
        {
            object[,] arrParameter = new object[,] { { "mFromDate", ReportMaster.AttFromDate.ToString("yyyy-MM-dd") }, { "mToDate", ReportMaster.AttToDate.ToString("yyyy-MM-dd") } };
            this.DbConn.Insert("sp_select_return_date", arrParameter);
        }

        public void ExecuteLeaveBalance(objReportMaster ReportMaster)
        {
            object[,] arrParameter = new object[,] { { "mFromDate", ReportMaster.AttFromDate.ToString("yyyy-MM-dd") }, { "mToDate", ReportMaster.AttToDate.ToString("yyyy-MM-dd") }, { "mLocationcode", ReportMaster.LocationCode }, { "mStatus", ReportMaster.StatusCode } };
            this.DbConn.Insert("sp_leave_balance", arrParameter);
        }

        public DataTable GetReports()
        {
            return this.DbConn.SearchData("tbl_report_master");
        }

        public objReportMaster GetReports(int ReportID)
        {
            objReportMaster master = new objReportMaster();
            string str = "fldReportID =" + ReportID;
            DataTable table = this.DbConn.SearchData("tbl_report_master", str);
            if (table.Rows.Count > 0)
            {
                master.ReportID = table.Rows[0][1].ToString();
                master.ReportName = table.Rows[0][2].ToString();
                master.ReportTitle = table.Rows[0][3].ToString();
                master.SelectionFormular = table.Rows[0][4].ToString();
                master.SelectedTable = table.Rows[0][6].ToString();
            }
            return master;
        }
    }
}

