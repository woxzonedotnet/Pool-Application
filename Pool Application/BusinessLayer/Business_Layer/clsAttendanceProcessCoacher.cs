namespace Business_Layer
{
    using Business_Layer.Property_Layer;
    using Database_Layer;
    using System;
    using System.Data;

    public class clsAttendanceProcessCoacher
    {
        private clsDBConnect DbConn = new clsDBConnect();

        public DataTable AttendanceProcess(objAttendanceProcessCoacher oAttendanceProcessCoacher)
        {
            object[,] arrParameter = new object[,] { { "mfldLocationCode", oAttendanceProcessCoacher.LocationCode }, { "mfldCoacherCode", oAttendanceProcessCoacher.CoacherCode }, { "mAttendanceDate", oAttendanceProcessCoacher.AttendanceDate.ToString("yyyy-MM-dd") } };
            return this.DbConn.Execute("sp_attendance_process_coacher", arrParameter);
        }
    }
}

