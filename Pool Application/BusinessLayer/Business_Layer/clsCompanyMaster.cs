namespace Business_Layer
{
    using Business_Layer.Property_Layer;
    using Database_Layer;
    using System;
    using System.Data;

    public class clsCompanyMaster
    {
        private clsDBConnect dbConn = new clsDBConnect();

        public void Delete_LocationData(string strLocationCode)
        {
            string str = "fldLocationCode='" + strLocationCode + "'";
            this.dbConn.DeleteData("tbl_parameter", str);
            this.dbConn.DeleteData("tbl_location_master", str);
        }

        public objCompanyMaster GetCompanyDetails()
        {
            objCompanyMaster master = new objCompanyMaster();
            DataTable table = this.dbConn.SearchData("tbl_Company_Master");
            if (table.Rows.Count > 0)
            {
                master.CustomerName = table.Rows[0][1].ToString();
                master.CustomerAddNo = table.Rows[0][2].ToString();
                master.CustomerAddRoad = table.Rows[0][4].ToString();
                master.CustomerAddStreet = table.Rows[0][3].ToString();
                master.CustomerTelNo = table.Rows[0][5].ToString();
                master.CustomerFax = table.Rows[0][6].ToString();
                master.CustomerEmail = table.Rows[0][7].ToString();
                master.CustomerWebSite = table.Rows[0][8].ToString();
                master.IsCompanyExist = true;
                return master;
            }
            master.IsCompanyExist = false;
            return master;
        }

        public void Insert_UpdateData(objCompanyMaster oCompanyMaster)
        {
            object[,] arrParameter = new object[,] { { "mflCustomerName", oCompanyMaster.CustomerName }, { "mflCustomerAddNo", oCompanyMaster.CustomerAddNo }, { "mflCustomerAddRoad", oCompanyMaster.CustomerAddRoad }, { "mflCustomerStreet", oCompanyMaster.CustomerAddStreet }, { "mflCustomerTelNo", oCompanyMaster.CustomerTelNo }, { "mflCustomerFax", oCompanyMaster.CustomerFax }, { "mflCustomerEmail", oCompanyMaster.CustomerEmail }, { "mflWebSiteAddress", oCompanyMaster.CustomerWebSite } };
            this.dbConn.Execute("sp_insert_update_company_master", arrParameter);
        }
    }
}

