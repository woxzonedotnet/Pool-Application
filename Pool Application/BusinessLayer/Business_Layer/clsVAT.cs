namespace Business_Layer
{
    using Database_Layer;
    using System;
    using System.Data;

    public class clsVAT
    {
        private clsDBConnect DbConn = new clsDBConnect();

        public DataTable GetVAT()
        {
            return this.DbConn.SearchData("tbl_vat_master");
        }
    }
}

