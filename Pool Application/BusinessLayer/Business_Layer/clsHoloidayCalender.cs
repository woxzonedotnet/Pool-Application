namespace Business_Layer
{
    using Business_Layer.Property_Layer;
    using Database_Layer;
    using System;
    using System.Data;

    public class clsHoloidayCalender
    {
        private clsDBConnect DbConn = new clsDBConnect();

        public objHoloidayCalender GetCalanderDetails(string strLocationCode, DateTime dtDate)
        {
            objHoloidayCalender calender = new objHoloidayCalender();
            string str = "fldLocationCode='" + strLocationCode + "' AND fldWorkingDate ='" + string.Format("{0:yyyy/MM/dd}", dtDate) + "'";
            DataTable table = this.DbConn.SearchData("tbl_holiday_calander", str);
            if (table.Rows.Count > 0)
            {
                calender.DayType = table.Rows[0][2].ToString();
                calender.DayRemarks = table.Rows[0][3].ToString();
            }
            return calender;
        }

        public DataTable GetDayType(string strLocationCode, DateTime dtDate)
        {
            string str = "fldLocationCode='" + strLocationCode + "' AND fldWorkingDate='" + string.Format("{0:yyyy/MM/dd}", dtDate) + "'";
            return this.DbConn.SearchData("tbl_holiday_calander", str);
        }

        public void InsertUpdateData(objHoloidayCalender obHilidayCalander)
        {
            object[,] arrParameter = new object[,] { { "$fldLocationCode", obHilidayCalander.LocationCode }, { "$fldWorkingDate", obHilidayCalander.WorkingDate }, { "$fldDayType", obHilidayCalander.DayType }, { "$fldDayRemarks", obHilidayCalander.DayRemarks } };
            this.DbConn.Insert("sp_insert_update_holiday_calander", arrParameter);
        }
    }
}

