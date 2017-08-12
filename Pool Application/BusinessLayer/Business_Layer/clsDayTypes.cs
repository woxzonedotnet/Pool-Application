namespace Business_Layer
{
    using Database_Layer;
    using System;
    using System.Data;

    public class clsDayTypes
    {
        private clsDBConnect DbConn = new clsDBConnect();

        public DataTable GetClassDetails()
        {
            return this.DbConn.SearchData("tbl_daytype_master");
        }
    }
}

