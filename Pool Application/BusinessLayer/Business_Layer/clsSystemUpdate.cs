namespace Business_Layer
{
    using Database_Layer;
    using System;

    public class clsSystemUpdate
    {
        private clsDBConnect DbConn = new clsDBConnect();

        public bool CheckIsUpdated()
        {
            string str = "SysUpdateDate ='" + DateTime.Now.ToString("yyyy-MM-dd") + "'";
            return (this.DbConn.SearchData("tbl_system_update", str).Rows.Count > 0);
        }

        public void InsertUpdateSystemUpdateDate()
        {
            object[,] arrParameter = new object[,] { { "mSysUpdateDate", DateTime.Now.ToString("yyyy-MM-dd") } };
            this.DbConn.Insert("sp_insert_update_system_update", arrParameter);
        }
    }
}

