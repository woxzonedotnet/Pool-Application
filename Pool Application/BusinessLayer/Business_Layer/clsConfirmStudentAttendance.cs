namespace Business_Layer
{
    using Business_Layer.Property_Layer;
    using Database_Layer;
    using System;
    using System.Data;

    public class clsConfirmStudentAttendance
    {
        private clsDBConnect DbConn = new clsDBConnect();

        public void CancelEntry(string mfldLocationCode, string mfldStudentNo, DateTime mfldAttendanceDate)
        {
            string str = "fldLocationCode='" + mfldLocationCode + "' and  fldStudentNo='" + mfldStudentNo + "' and fldAttendanceDate='" + mfldAttendanceDate.ToString("yyyy-MM-dd") + "'";
            this.DbConn.DeleteData("tbl_confirm_attendance", str);
        }

        public objConfirmStudentAttendance GetAttendanceDetails(string strLocationCode, string strStudentNo, DateTime dtAttendanceDate)
        {
            objConfirmStudentAttendance attendance = new objConfirmStudentAttendance();
            clsConfirmStudentAttendance attendance2 = new clsConfirmStudentAttendance();
            string str = "fldLocationCode ='" + strLocationCode + "' AND fldStudentNo='" + strStudentNo + "' AND fldAttendanceDate='" + dtAttendanceDate.ToString("yyyy-MM-dd") + "'";
            DataTable table = this.DbConn.SearchData("tbl_confirm_attendance", str);
            if (table.Rows.Count > 0)
            {
                attendance.LocationCode = table.Rows[0]["fldLocationCode"].ToString();
                attendance.StudentNo = table.Rows[0]["fldStudentNo"].ToString();
                attendance.AttendanceDate = Convert.ToDateTime(table.Rows[0]["fldAttendanceDate"].ToString());
                attendance.ClassCode = table.Rows[0]["fldClassCode"].ToString();
                attendance.ClassTimeCode = table.Rows[0]["fldClassTimeCode"].ToString();
                attendance.AbsentDate = Convert.ToDateTime(table.Rows[0]["fldAbsentDate"].ToString());
                attendance.IsConfirmAttendance = true;
                return attendance;
            }
            attendance.IsConfirmAttendance = false;
            return attendance;
        }

        public DataTable GetAttendanceDetails(string strLocationCode, string strStudentNo, DateTime dtAttendanceDate, string strClassCode)
        {
            string str = "fldLocationCode ='" + strLocationCode + "' AND fldStudentNo='" + strStudentNo + "' AND fldAttendanceDate='" + dtAttendanceDate.ToString("yyyy-MM-dd") + "' AND fldClassCode ='" + strClassCode + "'";
            return this.DbConn.SearchData("tbl_confirm_attendance", str);
        }

        public DataTable GetConfirnAttDetails(string strLocationCode, string strStudentCode, DateTime dAbsentDate)
        {
            string str = "fldLocationCode ='" + strLocationCode + "' AND fldStudentNo='" + strStudentCode + "' AND fldAbsentDate ='" + dAbsentDate.ToString("yyyy-MM-dd") + "'";
            return this.DbConn.SearchData("tbl_confirm_attendance", str);
        }

        public DataTable GetConfirnAttDetails(string strLocationCode, DateTime dtAttendanceDate, string strClassCode, string strInTime, string strOutTime, string strSession)
        {
            string str = "fldLocationCode ='" + strLocationCode + "' AND fldAttendanceDate='" + dtAttendanceDate.ToString("yyyy-MM-dd") + "' AND fldClassCode ='" + strClassCode + "' AND fldInTime = '" + strInTime + "' AND fldOutTime ='" + strOutTime + "' AND fldSession ='" + strSession + "'";
            return this.DbConn.SearchData("tbl_confirm_attendance", str);
        }

        public void InsertUpdateData(objConfirmStudentAttendance oConfirmStudentAttendance)
        {
            object[,] arrParameter = new object[,] { { "mfldLocationCode", oConfirmStudentAttendance.LocationCode }, { "mfldStudentNo", oConfirmStudentAttendance.StudentNo }, { "mfldAttendanceDate", oConfirmStudentAttendance.AttendanceDate.ToString("yyyy-MM-dd") }, { "mfldClassCode", oConfirmStudentAttendance.ClassCode }, { "mfldClassTimeCode", oConfirmStudentAttendance.ClassTimeCode }, { "mfldAbsentDate", oConfirmStudentAttendance.AbsentDate.ToString("yyyy-MM-dd") } };
            this.DbConn.Insert("sp_insert_update_confirm_attendance", arrParameter);
        }
    }
}

