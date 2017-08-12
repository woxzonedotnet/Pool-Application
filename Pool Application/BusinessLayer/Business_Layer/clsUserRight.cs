namespace Business_Layer
{
    using Business_Layer.Property_Layer;
    using Database_Layer;
    using System;
    using System.Data;

    public class clsUserRight
    {
        private clsDBConnect dbConn = new clsDBConnect();

        public void DeleteUserRights(string strUserId, string strLocationCode)
        {
            string str = "fldUserId='" + strUserId + "' AND fldLocationCode='" + strLocationCode + "'";
            this.dbConn.DeleteData("tbl_user_rights", str);
        }

        public DataTable getUserRights_Data(string UserCode, string LocationCode)
        {
            string str = "fldUserId='" + UserCode + "' AND fldLocationCode='" + LocationCode + "'";
            return this.dbConn.SearchData("tbl_User_Rights", str);
        }

        public void InsertUpdateData(objUserRight oUserRight)
        {
            object[,] arrParameter = new object[,] { { "mLocationCode", oUserRight.LocationCode }, { "mflUserId", oUserRight.UserCode }, { "mflUserRight", oUserRight.UserRight }, { "mMenuType", oUserRight.MenuType }, { "mflMenuName", oUserRight.MenuName } };
            this.dbConn.Insert("sp_insert_update_UserRights", arrParameter);
        }
    }
}

