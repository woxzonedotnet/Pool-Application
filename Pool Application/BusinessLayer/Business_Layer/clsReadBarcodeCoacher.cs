namespace Business_Layer
{
    using Business_Layer.Property_Layer;
    using Database_Layer;
    using System;

    public class clsReadBarcodeCoacher
    {
        private clsDBConnect DbConn = new clsDBConnect();

        public void InsertUpdate(objReadBarcodeCoacher oReadBarcodeCoacher)
        {
            object[,] arrParameter = new object[,] { { "mfldLocationCode", oReadBarcodeCoacher.LocationCode }, { "mfldCoacherCode", oReadBarcodeCoacher.CoacherCode }, { "mfldLogDate", Convert.ToDateTime(oReadBarcodeCoacher.LogDate).ToString("yyyy-MM-dd") }, { "mfldLogTime", Convert.ToDateTime(oReadBarcodeCoacher.LogTime).ToString("HH:mm:ss") } };
            this.DbConn.Insert("sp_insert_update_coacher_attendance_log", arrParameter);
        }
    }
}

