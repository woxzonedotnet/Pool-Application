namespace Business_Layer
{
    using Database_Layer;
    using System;
    using System.Data;

    public class clsNBT
    {
        private clsDBConnect DbConn = new clsDBConnect();

        public DataTable GetNBT()
        {
            return this.DbConn.SearchData("tbl_nbt_tax");
        }
    }
}

