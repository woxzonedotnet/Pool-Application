namespace Business_Layer
{
    using Business_Layer.Property_Layer;
    using Database_Layer;
    using System;

    public class clsActiveCancalHistory
    {
        private clsDBConnect DbConn = new clsDBConnect();

        public void InsertUpdateData(objActiveCancalHistory oActiveCancalHistory)
        {
            object[,] arrParameter = new object[,] { { "mfldLocationCode", oActiveCancalHistory.LocationCode }, { "mfldStudentNo", oActiveCancalHistory.StudentNo }, { "mfldActiveDate", oActiveCancalHistory.ActiveDate.ToString("yyyy-MM-dd") }, { "mfldStatus", oActiveCancalHistory.Status } };
            this.DbConn.Insert("sp_insert_update_active_cancel_history", arrParameter);
        }
    }
}

