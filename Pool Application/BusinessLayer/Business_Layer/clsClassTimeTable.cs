namespace Business_Layer
{
    using Business_Layer.Property_Layer;
    using Database_Layer;
    using System;
    using System.Data;

    public class clsClassTimeTable
    {
        private clsDBConnect DbConn = new clsDBConnect();

        public void DeleteDayDetails(string strLocationCode, string strStudentNumber)
        {
            string str = "fldLocationCode ='" + strLocationCode + "' AND fldStudentNo='" + strStudentNumber + "'";
            this.DbConn.DeleteData("tbl_day_changed_details", str);
        }

        public void DeleteTimeDetails(string strLocationCode, string strStudentNumber)
        {
            string str = "fldLocationCode ='" + strLocationCode + "' AND fldStudentNo='" + strStudentNumber + "'";
            this.DbConn.DeleteData("tbl_class_times", str);
        }

        public DataTable GetClass(string strLocationCode, string strClassCode, string strDayType)
        {
            string str = "fldLocationCode ='" + strLocationCode + "' AND fldClassCode =  '" + strClassCode + "' AND fldDayType =  '" + strDayType + "' GROUP BY fldInTime, fldOutTime";
            return this.DbConn.SearchData("tbl_class_times", str);
        }

        public DataTable GetClassDetails(string strLocationCode, string strStudentNo, string strDayType)
        {
            string str = "fldLocationCode ='" + strLocationCode + "' AND fldStudentNo='" + strStudentNo + "' AND fldDayType LIKE '" + strDayType + "'";
            return this.DbConn.SearchData("tbl_class_times", str);
        }

        public DataTable GetClassDetails(string strLocationCode, string strStudentNo, string strDayType, string strSession)
        {
            string str = "fldLocationCode ='" + strLocationCode + "' AND fldStudentNo='" + strStudentNo + "' AND fldDayType LIKE '" + strDayType + "' AND fldSession LIKE '" + strSession + "'";
            return this.DbConn.SearchData("tbl_class_times", str);
        }

        public DataTable GetClassEmployee(string strLocationCode, string strClassCode, string strDayType, string strClassStartTime, string strClassEndTime)
        {
            string strSQL = "SELECT tbl_student_master.fldStudentNo,tbl_student_master.fldNameInFullL1,tbl_student_master.fldNameInFullL2, tbl_student_master.fldClassCode, tbl_student_master.fldDateOfJoin ";
            string str2 = strSQL + " FROM tbl_class_times Inner Join tbl_student_master ON " + " tbl_class_times.fldLocationCode = tbl_student_master.fldLocationCode AND tbl_class_times.fldStudentNo = tbl_student_master.fldStudentNo ";
            str2 = str2 + " WHERE tbl_student_master.fldLocationCode = '" + strLocationCode + "' AND tbl_student_master.fldStatus <>'C' AND (tbl_class_times.fldClassCode = '" + strClassCode + "'OR tbl_student_master.fldClassCode='" + strClassCode + "') AND";
            strSQL = str2 + " tbl_class_times.fldDayType = '" + strDayType + "' AND tbl_class_times.fldInTime = '" + strClassStartTime + "' AND tbl_class_times.fldOutTime ='" + strClassEndTime + "'";
            return this.DbConn.SearchDataWithSQL(strSQL);
        }

        public DataTable GetClassTimeDetails(string strLocationCode, string strClassCode, string strStatus)
        {
            string strSQL = "SELECT *,STR_TO_DATE(fldInTime , '%l:%i %p' ) as OrderTime FROM tbl_class_time_master where ";
            string str2 = strSQL;
            strSQL = str2 + "fldLocationCode ='" + strLocationCode + "' and fldClassCode = '" + strClassCode + "' AND fldStatus='" + strStatus + "' order by OrderTime";
            return this.DbConn.SearchDataWithSQL(strSQL);
        }

        public DataTable GetClassTimeDetails(string strLocationCode, string strClassCode, string DayType, string strStatus)
        {
            string str = "fldLocationCode ='" + strLocationCode + "' AND fldClassCode='" + strClassCode + "' AND fldStatus='" + strStatus + "' AND fldDayType ='" + DayType + "'";
            return this.DbConn.SearchData("tbl_class_time_master", str);
        }

        public string GetNewClassTimeCode(string strLocationCode, string strClassCode)
        {
            string str = "fldLocationCode ='" + strLocationCode + "' AND fldClassCode='" + strClassCode + "'";
            int num = this.DbConn.SearchData("tbl_class_time_master", str).Rows.Count + 1;
            return (strClassCode + num.ToString("000"));
        }

        public DataTable GetStudentClassDetails(string strLocationCode, string strStudentID, string strClassCode, string strDayType)
        {
            string strSQL = "SELECT ";
            strSQL = ((((((((((strSQL + "tbl_student_class_times.fldLocationCode,") + "tbl_student_class_times.fldClassCode," + "tbl_student_class_times.fldClassTimeCode,") + "tbl_student_class_times.fldStudentNo," + "tbl_student_master.fldStatus,") + "tbl_class_time_master.fldDayType " + "FROM ") + "tbl_student_master " + "Inner Join tbl_student_class_times ON tbl_student_master.fldLocationCode = tbl_student_class_times.fldLocationCode AND tbl_student_master.fldStudentNo = tbl_student_class_times.fldStudentNo AND tbl_student_master.fldClassCode = tbl_student_class_times.fldClassCode ") + "Inner Join tbl_class_time_master ON tbl_student_class_times.fldLocationCode = tbl_class_time_master.fldLocationCode AND tbl_student_class_times.fldClassCode = tbl_class_time_master.fldClassCode AND tbl_student_class_times.fldClassTimeCode = tbl_class_time_master.fldClassTimeCode " + "WHERE ") + "tbl_student_master.fldStudentNo =  '" + strStudentID + "' AND ") + "tbl_student_master.fldStatus <>  'C' AND ") + "tbl_class_time_master.fldDayType =  '" + strDayType + "' AND ") + "tbl_class_time_master.fldClassCode =  '" + strClassCode + "' AND ") + "tbl_class_time_master.fldLocationCode =  '" + strLocationCode + "'";
            return this.DbConn.SearchDataWithSQL(strSQL);
        }

        public void InsertUpdateData(objClassTimeTable oClassTimeTable)
        {
            object[,] arrParameter = new object[,] { { "mfldLocationCode", oClassTimeTable.LocationCode }, { "mfldClassCode", oClassTimeTable.ClassCode }, { "mfldClassTimeCode", oClassTimeTable.ClassTimeCode }, { "mfldDayType", oClassTimeTable.DayType }, { "mfldInTime", oClassTimeTable.InTime }, { "mfldOutTime", oClassTimeTable.OutTime }, { "mfldSession", oClassTimeTable.Session }, { "mfldStatus", oClassTimeTable.Status } };
            this.DbConn.Insert("sp_insert_update_class_time_master", arrParameter);
        }

        public void InsertUpdateDayType(objClassTimeTable oClassTimeTable)
        {
            object[,] arrParameter = new object[9, 2];
            arrParameter[0, 0] = "mfldLocationCode";
            arrParameter[0, 1] = oClassTimeTable.LocationCode;
            arrParameter[1, 0] = "mfldStudentNo";
            arrParameter[1, 1] = oClassTimeTable.Status;
            arrParameter[2, 0] = "mfldClassCode";
            arrParameter[2, 1] = oClassTimeTable.ClassCode;
            arrParameter[3, 0] = "mfldDayType";
            arrParameter[3, 1] = oClassTimeTable.DayType;
            arrParameter[4, 0] = "mfldInTime";
            arrParameter[4, 1] = oClassTimeTable.InTime;
            arrParameter[5, 0] = "mfldOutTime";
            arrParameter[5, 1] = oClassTimeTable.OutTime;
            arrParameter[6, 0] = "mfldSession";
            arrParameter[6, 1] = oClassTimeTable.Session;
            this.DbConn.Insert("sp_insert_update_day_change_details", arrParameter);
        }
    }
}

