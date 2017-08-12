namespace Business_Layer
{
    using Business_Layer.Property_Layer;
    using Database_Layer;
    using System;
    using System.Data;

    public class clsEmployeeWorkingDays
    {
        private clsDBConnect DbConn = new clsDBConnect();

        public DataTable GetWorkingDays(string strLocationCode, string strEmployeeCode, DateTime dtDate)
        {
            string str = "fldLocationCode='" + strLocationCode + "' AND fldEmployeeNo='" + strEmployeeCode + "' AND fldWorkingDate='" + string.Format("{0:yyyy/MM/dd}", dtDate) + "'";
            return this.DbConn.SearchData("tbl_employee_working_dates", str);
        }

        public void InsertUpdateData(objEmployeeWorkingDays oEmployeeWorkingDays)
        {
            object[,] arrParameter = new object[,] { { "mfldLocationCode", oEmployeeWorkingDays.LocationCode }, { "mfldEmployeeNo", oEmployeeWorkingDays.EmployeeCode }, { "mfldWorkingDate", oEmployeeWorkingDays.WorkingDate }, { "mfldDayType", oEmployeeWorkingDays.DayType } };
            this.DbConn.Insert("sp_insert_update_working_dates", arrParameter);
        }
    }
}

