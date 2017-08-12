namespace Business_Layer
{
    using Business_Layer.Property_Layer;
    using Database_Layer;
    using System;
    using System.Data;

    public class clsStatusMaster
    {
        private clsDBConnect DbConn = new clsDBConnect();

        public void DeleteStatusData(string strLocationCode, string strStatusCode)
        {
            string str = "fld_Status_Code='" + strStatusCode + "'";
            this.DbConn.DeleteData("tbl_status_master", str);
        }

        public objStatusMaster GetStatusByCode(string SearchCode)
        {
            objStatusMaster master = new objStatusMaster();
            string str = "fld_status_code ='" + SearchCode + "'";
            DataTable table = this.DbConn.SearchData("tbl_status_master", str);
            if (table.Rows.Count > 0)
            {
                master.StatusCode = table.Rows[0][0].ToString();
                master.StatusName = table.Rows[0][1].ToString();
                master.IsExistStatus = true;
                return master;
            }
            master.IsExistStatus = false;
            return master;
        }

        public objStatusMaster GetStatusCodeByName(string StatusNm)
        {
            objStatusMaster master = new objStatusMaster();
            string str = "fld_Status_Name ='" + StatusNm + "'";
            DataTable table = this.DbConn.SearchData("tbl_status_master", str);
            if (table.Rows.Count > 0)
            {
                master.StatusCode = table.Rows[0][0].ToString();
                master.StatusName = table.Rows[0][1].ToString();
                master.IsExistStatus = true;
                return master;
            }
            master.IsExistStatus = false;
            return master;
        }

        public DataTable GetStatusDetails()
        {
            return this.DbConn.SearchData("tbl_status_master");
        }

        public void InsertUpdateStatus(objStatusMaster oStatusMaster)
        {
            object[,] arrParameter = new object[,] { { "mStatusCode", oStatusMaster.StatusCode }, { "mStatusName", oStatusMaster.StatusName } };
            this.DbConn.Insert("sp_insert_update_status_master", arrParameter);
        }
    }
}

