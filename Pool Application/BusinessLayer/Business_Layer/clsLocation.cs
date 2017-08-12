namespace Business_Layer
{
    using Business_Layer.Property_Layer;
    using Database_Layer;
    using System;
    using System.Data;
    using System.Drawing;
    using System.IO;

    public class clsLocation
    {
        private clsDBConnect DbConn = new clsDBConnect();

        public void DeleteLocationData(string SearchValue)
        {
            string str = "fldLocationCode='" + SearchValue + "'";
            this.DbConn.DeleteData("tbl_location_master", str);
        }

        public DataTable GetLocationAllData(string strStatusCode)
        {
            string str = "fldLocationStatus='" + strStatusCode + "'";
            return this.DbConn.SearchData("tbl_location_master", str);
        }

        public objLocation GetLocationData(string SearchValue)
        {
            clsStatusMaster master = new clsStatusMaster();
            objLocation location = new objLocation();
            string str = "fldLocationCode='" + SearchValue + "'";
            DataTable table = this.DbConn.SearchData("tbl_location_master", str);
            if (table.Rows.Count > 0)
            {
                location.LocationCode = table.Rows[0][1].ToString();
                location.LocationName = table.Rows[0][2].ToString();
                location.LocationAddNo = table.Rows[0][3].ToString();
                location.LocationAddRoad = table.Rows[0][4].ToString();
                location.LocationAddStreat = table.Rows[0][5].ToString();
                location.LocationTP = table.Rows[0][6].ToString();
                location.LocationExt = table.Rows[0][7].ToString();
                location.LocationFax = table.Rows[0][8].ToString();
                location.LocationEmail = table.Rows[0][9].ToString();
                location.LocationStatus = master.GetStatusByCode(table.Rows[0][10].ToString()).StatusName;
                if (table.Rows[0][11] != DBNull.Value)
                {
                    byte[] buffer = (byte[]) table.Rows[0][11];
                    int upperBound = buffer.GetUpperBound(0);
                    MemoryStream stream = new MemoryStream(buffer, 0, upperBound);
                    location.LocationLogo = Image.FromStream(stream);
                }
                location.LocationIsExist = true;
                return location;
            }
            location.LocationIsExist = false;
            return location;
        }

        public DataTable GetLocationsData(string strLocatopnCode, string strStatusCode)
        {
            string str = "fldLocationCode LIKE '" + strLocatopnCode + "' AND fldLocationStatus='" + strStatusCode + "'";
            return this.DbConn.SearchData("tbl_location_master", str);
        }

        public void InsertUpdateData(objLocation Location)
        {
            object[,] arrParameter = new object[,] { { "mfldLocationCode", Location.LocationCode }, { "mfldLocationName", Location.LocationName }, { "mfldLocationAddNo", Location.LocationAddNo }, { "mfldLocationAddRoad", Location.LocationAddRoad }, { "mfldLocationAddStreet", Location.LocationAddStreat }, { "mfldLocationTP", Location.LocationTP }, { "mfldLocationExt", Location.LocationExt }, { "mfldLocationFax", Location.LocationFax }, { "mfldLocationEmail", Location.LocationEmail }, { "mfldLocationStatus", Location.LocationStatus }, { "mfldLocationLogo", Location.LocationLogoSaving } };
            this.DbConn.Insert("sp_insert_update_location", arrParameter);
        }
    }
}

