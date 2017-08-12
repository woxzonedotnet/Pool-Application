namespace Business_Layer
{
    using Business_Layer.Property_Layer;
    using Database_Layer;
    using System;
    using System.Data;

    public class clsBluedGroupMaster
    {
        private clsDBConnect DbConn = new clsDBConnect();

        public DataTable GetBluedGroup()
        {
            return this.DbConn.SearchData("tbl_blued_group_master");
        }

        public objBluedGroupMaster GetBluedGroupData(string strBluedGroupCode)
        {
            objBluedGroupMaster master = new objBluedGroupMaster();
            string str = "fldBluedGroupCode ='" + strBluedGroupCode + "'";
            DataTable table = this.DbConn.SearchData("tbl_blued_group_master", str);
            if (table.Rows.Count > 0)
            {
                master.BluedGroupCode = table.Rows[0][1].ToString();
                master.BluedGroup = table.Rows[0][2].ToString();
                master.BluedGroupIsExist = true;
                return master;
            }
            master.BluedGroupIsExist = false;
            return master;
        }
    }
}

