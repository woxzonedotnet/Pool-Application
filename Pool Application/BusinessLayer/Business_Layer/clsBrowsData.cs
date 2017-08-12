namespace Business_Layer
{
    using Database_Layer;
    using System;
    using System.Data;

    public class clsBrowsData
    {
        private clsDBConnect DbConn = new clsDBConnect();

        public DataTable BrowsData(string strTableName, string[] strFieldList)
        {
            string str = "";
            for (int i = 0; i < strFieldList.Length; i++)
            {
                str = str + strFieldList[i].ToString();
                if (i < (strFieldList.Length - 1))
                {
                    str = str + ",";
                }
            }
            object[,] arrParameter = new object[,] { { "tblName", strTableName }, { "FieldList", str } };
            return this.DbConn.Execute("sp_Brows_data", arrParameter);
        }

        public DataTable BrowsData(string strTableName, string[] strFieldList, string where_clause)
        {
            string str = "";
            for (int i = 0; i < strFieldList.Length; i++)
            {
                str = str + strFieldList[i].ToString();
                if (i < (strFieldList.Length - 1))
                {
                    str = str + ",";
                }
            }
            object[,] arrParameter = new object[,] { { "tblName", strTableName }, { "FieldList", str }, { "where_clause", where_clause } };
            return this.DbConn.Execute("sp_Brows_Data_using_where", arrParameter);
        }
    }
}

