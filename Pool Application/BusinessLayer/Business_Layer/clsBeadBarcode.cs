namespace Business_Layer
{
    using Business_Layer.Property_Layer;
    using Database_Layer;
    using System;

    public class clsBeadBarcode
    {
        private clsDBConnect DbConn = new clsDBConnect();

        public void InsertUpdate(objBeadBarcode oBeadBarcode)
        {
            object[,] arrParameter = new object[,] { { "mfldLocationCode", oBeadBarcode.LocationCode }, { "mfldStudentNo", oBeadBarcode.StudentNo }, { "mAttendanceDate", Convert.ToDateTime(oBeadBarcode.LogDate).ToString("yyyy-MM-dd") }, { "mIntime", Convert.ToDateTime(oBeadBarcode.LogTime).ToString("HH:mm:ss") }, { "mOutTime", Convert.ToDateTime(oBeadBarcode.LogTime).ToString("HH:mm:ss") } };
            this.DbConn.Insert("sp_attendance_process", arrParameter);
        }
    }
}

