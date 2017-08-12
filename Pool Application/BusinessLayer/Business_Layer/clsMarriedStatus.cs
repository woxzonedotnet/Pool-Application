namespace Business_Layer
{
    using Business_Layer.Property_Layer;
    using Database_Layer;
    using System;
    using System.Data;

    public class clsMarriedStatus
    {
        private clsDBConnect DbConn = new clsDBConnect();

        public objMarriedStatus GetMarriedData(string strMarriedStatusCode)
        {
            objMarriedStatus status = new objMarriedStatus();
            string str = "fldMarriedStatusCode ='" + strMarriedStatusCode + "'";
            DataTable table = this.DbConn.SearchData("tbl_married_status_master", str);
            if (table.Rows.Count > 0)
            {
                status.MarriedStatusCode = table.Rows[0][1].ToString();
                status.MarriedStatus = table.Rows[0][2].ToString();
                status.MarridStatusIsExist = true;
                return status;
            }
            status.MarridStatusIsExist = false;
            return status;
        }

        public DataTable GetMarriedStatus()
        {
            return this.DbConn.SearchData("tbl_married_status_master");
        }
    }
}

