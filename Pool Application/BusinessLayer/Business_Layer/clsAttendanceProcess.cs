namespace Business_Layer
{
    using Business_Layer.Property_Layer;
    using Database_Layer;
    using System;
    using System.Data;

    public class clsAttendanceProcess
    {
        private clsDBConnect DbConn = new clsDBConnect();

        public DataTable AttendanceProcess(objAttendanceProcess oAttendanceProcess)
        {
            object[,] arrParameter = new object[,] { { "mfldLocationCode", oAttendanceProcess.LocationCode }, { "mfldStudentNo", oAttendanceProcess.StudentNo }, { "mAttendanceDate", oAttendanceProcess.AttendanceDate.ToString("yyyy-MM-dd") } };
            return this.DbConn.Execute("sp_attendance_process", arrParameter);
        }

        public bool EmployeeIsexist(string strLocationCode, string strEmployeeCode, DateTime date)
        {
            string str = "fldLocationCode ='" + strLocationCode + "' AND fldStudentNo ='" + strEmployeeCode + "' AND fldAttendanceDate ='" + date.ToString("yyyy-MM-dd") + "'";
            return (this.DbConn.SearchData("tbl_daily_in_out_details", str).Rows.Count > 0);
        }
    }
}

