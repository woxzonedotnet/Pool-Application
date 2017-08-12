namespace Business_Layer
{
    using Business_Layer.Property_Layer;
    using Database_Layer;
    using System;
    using System.Data;

    public class clsUserLevel
    {
        private clsDBConnect dbcon = new clsDBConnect();

        public void DeleteData(string Locationcode, string Userlevelcode)
        {
            string str = "fldLocationCode='" + Locationcode + "' And fldUserlevelCode='" + Userlevelcode + "'";
            this.dbcon.DeleteData("tbl_user_level_master", str);
        }

        public DataTable getUserLevel_Data(string Location_code, string strActivestatus)
        {
            string str = "fldLocationCode='" + Location_code + "' And fldUserLevelStatus='" + strActivestatus + "' ";
            return this.dbcon.SearchData("tbl_user_level_master", str);
        }

        public objUserLevel GetUserLevelData(string locationCode, string UserLevelCode)
        {
            objUserLevel level = new objUserLevel();
            clsStatusMaster master = new clsStatusMaster();
            string str = "fldLocationCode='" + locationCode + "' AND fldUserLevelCode='" + UserLevelCode + "'";
            DataTable table = this.dbcon.SearchData("tbl_User_level_master", str);
            if (table.Rows.Count > 0)
            {
                level.UserLevelCode = table.Rows[0][2].ToString();
                level.UserLevel = table.Rows[0][3].ToString();
                level.UserLevelStatus = master.GetStatusByCode(table.Rows[0][4].ToString()).StatusName;
                level.UserLevelIsExists = true;
                return level;
            }
            level.UserLevelIsExists = false;
            return level;
        }

        public void InsertUpdate(objUserLevel ouserlevel)
        {
            object[,] arrParameter = new object[,] { { "mfllocationcode", ouserlevel.LocationCode }, { "mflUserlevelcode", ouserlevel.UserLevelCode }, { "mflUserLevel", ouserlevel.UserLevel }, { "mflUserStatus", ouserlevel.UserLevelStatus } };
            this.dbcon.Insert("sp_insert_update_user_level", arrParameter);
        }
    }
}

