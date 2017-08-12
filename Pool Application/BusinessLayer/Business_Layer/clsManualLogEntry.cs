namespace Business_Layer
{
    using Database_Layer;
    using System;
    using System.Data;
    using System.Xml;

    public class clsManualLogEntry
    {
        private clsDBConnect dbconn = new clsDBConnect();

        public void DeleteManualLogEntryData(string strLoctationCode, string strEmployeeCode, DateTime dtLogDate)
        {
            string str = "fldLocationCode='" + strLoctationCode + "' AND fldStudentNo ='" + strEmployeeCode + "' AND fldLogDate ='" + dtLogDate.ToString("yyyy-MM-dd") + "'";
            this.dbconn.DeleteData("tbl_attendance_log", str);
        }

        public void DeleteManualLogEntryData(string strLoctationCode, string strEmployeeCode, DateTime dtLogDate, DateTime dtLogTime)
        {
            string str = "fldLocationCode='" + strLoctationCode + "' AND fldStudentNo ='" + strEmployeeCode + "' AND fldLogDate ='" + dtLogDate.ToString("yyyy-MM-dd") + "' AND fldLogTime='" + dtLogTime.ToString("HH:mm:ss") + "'";
            this.dbconn.DeleteData("tbl_attendance_log", str);
        }

        public DataTable GetManualLogEntryData(string strLoctationCode, string strEmployeeCode, DateTime dtLogDate)
        {
            string str = "fldLocationCode='" + strLoctationCode + "' AND fldStudentNo ='" + strEmployeeCode + "' AND fldLogDate ='" + dtLogDate.ToString("yyyy-MM-dd") + "'";
            return this.dbconn.SearchData("tbl_attendance_log", str);
        }
    }
}

