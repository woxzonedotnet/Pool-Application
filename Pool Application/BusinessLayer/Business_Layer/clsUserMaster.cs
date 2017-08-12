namespace Business_Layer
{
    using Business_Layer.Property_Layer;
    using Database_Layer;
    using System;
    using System.Data;

    public class clsUserMaster
    {
        private clsDBConnect cdbconnect = new clsDBConnect();

        public void Delete_data(string strLocationCode, string UserCode)
        {
            string str = "fldLocationCode='" + strLocationCode + "' and fldUserCode='" + UserCode + "' ";
            this.cdbconnect.DeleteData("tbl_user_master", str);
        }

        public objUserMaster getUser_Details(string Locationcode, string UserCode)
        {
            objUserMaster master = new objUserMaster();
            clsStatusMaster master2 = new clsStatusMaster();
            string str = "fldLocationCode ='" + Locationcode + "' And fldUsercode ='" + UserCode + "'  ";
            DataTable table = this.cdbconnect.SearchData("tbl_user_master", str);
            if (table.Rows.Count > 0)
            {
                master.UserCode = table.Rows[0][2].ToString();
                master.Password = table.Rows[0][4].ToString();
                master.UserName = table.Rows[0][3].ToString();
                master.UserLevel = table.Rows[0][5].ToString();
                master.UserMasterStatus = master2.GetStatusByCode(table.Rows[0][6].ToString()).StatusName;
                master.UserMasterExists = true;
                return master;
            }
            master.UserMasterExists = false;
            return master;
        }

        public DataTable GetUsers(string Locationcode, string strStatus)
        {
            string str = "fldLocationCode='" + Locationcode + "' And fldUserStatus='" + strStatus + "' ";
            return this.cdbconnect.SearchData("tbl_user_master", str);
        }

        public void InsertUpdateData(objUserMaster objusermaster)
        {
            object[,] arrParameter = new object[,] { { "mflLocationCode", objusermaster.LocationCode }, { "mflUserCode", objusermaster.UserCode }, { "mflUserName", objusermaster.UserName }, { "mflPassword", objusermaster.Password }, { "mflUserLevel", objusermaster.UserLevel }, { "mflUserStatus", objusermaster.UserMasterStatus } };
            this.cdbconnect.Insert("sp_insert_update_user_master", arrParameter);
        }

        public DataTable ValidateUser(string strLocationCode, string strUserName)
        {
            string str = "fldLocationCode ='" + strLocationCode + "' And fldUserName ='" + strUserName + "'";
            return this.cdbconnect.SearchData("tbl_user_master", str);
        }
    }
}

