namespace Business_Layer
{
    using Database_Layer;
    using System;
    using System.Data;

    public class clsExpire
    {
        private clsDBConnect DbConn = new clsDBConnect();

        public DataTable LastLogDateTime()
        {
            string str = Convert.ToDateTime(this.DbConn.Execute("sp_get_current_date").Rows[0][0].ToString()).ToString("yyyy/MM/dd");
            string str2 = "fldLogDate>='" + str + "' AND fldLogTime >='" + this.DbConn.Execute("sp_get_current_time").Rows[0][0].ToString() + "'";
            return this.DbConn.SearchData("tbl_log_details", str2);
        }
    }
}

