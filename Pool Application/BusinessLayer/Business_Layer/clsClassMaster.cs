namespace Business_Layer
{
    using Business_Layer.Property_Layer;
    using Database_Layer;
    using System;
    using System.Data;

    public class clsClassMaster
    {
        private clsDBConnect DbConn = new clsDBConnect();

        public void DeleteClassMasterData(string strLocationCode, string SearchValue)
        {
            string str = "fldLocationCode ='" + strLocationCode + "' AND fldClassCode='" + SearchValue + "'";
            this.DbConn.DeleteData("tbl_class_master", str);
        }

        public objClassMaster GetClassData(string strLocationCode, string ClassCode)
        {
            objClassMaster master = new objClassMaster();
            clsStatusMaster master2 = new clsStatusMaster();
            string str = "fldLocationCode ='" + strLocationCode + "' AND fldClassCode='" + ClassCode + "'";
            DataTable table = this.DbConn.SearchData("tbl_class_master", str);
            if (table.Rows.Count > 0)
            {
                master.ClassCode = table.Rows[0][2].ToString();
                master.ClassName = table.Rows[0][3].ToString();
                master.ClassStatus = master2.GetStatusByCode(table.Rows[0][4].ToString()).StatusName;
                master.ClassTotalStudents = Convert.ToInt32(table.Rows[0][5].ToString());
                master.ClassCoverUpDays = Convert.ToInt32(table.Rows[0][6].ToString());
                master.ClassIsExist = true;
                return master;
            }
            master.ClassIsExist = false;
            return master;
        }

        public DataTable GetClassDetails(string strLocationCode, string strClassStatus)
        {
            string str = "fldLocationCode ='" + strLocationCode + "' AND fldClassStatus ='" + strClassStatus + "'";
            return this.DbConn.SearchData("tbl_class_master", str);
        }

        public void InsertUpdateData(objClassMaster ClassMaster)
        {
            object[,] arrParameter = new object[,] { { "mfldLocationCode", ClassMaster.LocationCode }, { "mfldClassCode", ClassMaster.ClassCode }, { "mfldClassName", ClassMaster.ClassName }, { "mfldClassStatus", ClassMaster.ClassStatus }, { "mfldTotalStudents", ClassMaster.ClassTotalStudents }, { "mfldCoverUpDays", ClassMaster.ClassCoverUpDays } };
            this.DbConn.Insert("sp_insert_update_class_master", arrParameter);
        }
    }
}

