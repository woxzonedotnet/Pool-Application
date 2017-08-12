namespace Business_Layer
{
    using Business_Layer.Property_Layer;
    using Database_Layer;
    using System;
    using System.Data;

    public class clsStudentClassTimes
    {
        private clsDBConnect DbConn = new clsDBConnect();

        public void DeleteTimeDetails(string strLocationCode, string strStudentNumber)
        {
            string str = "fldLocationCode ='" + strLocationCode + "' AND fldStudentNo='" + strStudentNumber + "'";
            this.DbConn.DeleteData("tbl_student_class_times", str);
        }

        public DataTable GetAllStudentInClass(string strLocationCode, string strClassCode, string strClassTimeCode)
        {
            string strSQL = "SELECT tbl_student_class_times.* FROM tbl_student_master ";
            strSQL = (((((strSQL + "Inner Join tbl_student_class_times ON tbl_student_class_times.fldLocationCode = tbl_student_master.fldLocationCode ") + "AND tbl_student_class_times.fldStudentNo = tbl_student_master.fldStudentNo AND tbl_student_class_times.fldClassCode = tbl_student_master.fldClassCode " + "WHERE ") + "tbl_student_master.fldLocationCode ='" + strLocationCode + "' AND ") + "tbl_student_master.fldClassCode = '" + strClassCode + "' AND ") + "tbl_student_class_times.fldClassTimeCode ='" + strClassTimeCode + "' AND ") + "tbl_student_master.fldStatus <>'C'";
            return this.DbConn.SearchDataWithSQL(strSQL);
        }

        public int GetStudentClassCount(string strLocationCode, string strClassCode, string strClassTimeCode)
        {
            string strSQL = "SELECT Count(fldStudentNo) as TotalStudents FROM tbl_student_class_times WHERE fldClassCode =  '" + strClassCode + "' AND fldClassTimeCode =  '" + strClassTimeCode + "' AND fldLocationCode =  '" + strLocationCode + "'";
            DataTable table = this.DbConn.SearchDataWithSQL(strSQL);
            int num = 0;
            if (table.Rows.Count > 0)
            {
                num = Convert.ToInt32(table.Rows[0]["TotalStudents"].ToString());
            }
            return num;
        }

        public DataTable GetStudentClassDeails(string strLocationCode, string strStudentNo)
        {
            string strSQL = "SELECT tbl_class_time_master.fldLocationCode,tbl_class_time_master.fldClassCode,tbl_class_time_master.fldClassTimeCode,tbl_class_time_master.fldDayType,tbl_class_time_master.fldInTime,tbl_class_time_master.fldOutTime,tbl_class_time_master.fldSession FROM tbl_class_time_master ";
            string str2 = strSQL + "Inner Join tbl_student_class_times ON tbl_class_time_master.fldLocationCode = tbl_student_class_times.fldLocationCode " + "AND tbl_class_time_master.fldClassCode = tbl_student_class_times.fldClassCode AND tbl_class_time_master.fldClassTimeCode = tbl_student_class_times.fldClassTimeCode ";
            strSQL = str2 + "WHERE tbl_student_class_times.fldStudentNo =  '" + strStudentNo + "' and tbl_student_class_times.fldLocationCode ='" + strLocationCode + "'";
            return this.DbConn.SearchDataWithSQL(strSQL);
        }

        public void InsertUpdateStudentClassTimes(objStudentClassTimes oStudentClassTimes)
        {
            object[,] arrParameter = new object[,] { { "mfldLocationCode", oStudentClassTimes.LocationCode }, { "mfldClassCode", oStudentClassTimes.ClassCode }, { "mfldClassTimeCode", oStudentClassTimes.ClassTimeCode }, { "mfldStudentNo", oStudentClassTimes.StudentNo } };
            this.DbConn.Insert("sp_insert_update_student_class_times", arrParameter);
        }
    }
}

