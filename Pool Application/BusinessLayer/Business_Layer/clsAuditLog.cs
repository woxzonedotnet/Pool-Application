namespace Business_Layer
{
    using Business_Layer.Property_Layer;
    using Database_Layer;
    using System;
    using System.Data;

    public class clsAuditLog
    {
        private clsUserMaster cAuditLog = new clsUserMaster();
        private clsDBConnect cDBConnect = new clsDBConnect();
        private objAuditLog oAuditLog = new objAuditLog();

        public void AuditLog(objAuditLog oAuditLog)
        {
            object[,] arrParameter = new object[,] { { "mflLocationCode", oAuditLog.LocationCode }, { "mflMachineID", oAuditLog.MachineID }, { "mflUserId", oAuditLog.UserID }, { "mflTask", oAuditLog.Task }, { "mflDate", oAuditLog.DateEntered }, { "mflTimeEntered", oAuditLog.TimeEntered } };
            this.cDBConnect.Insert("sp_Insert_Update_Audit_Log", arrParameter);
        }

        public DataTable getCurrentDate()
        {
            return this.cDBConnect.Execute("sp_get_current_date");
        }

        public DataTable getCurrentTime()
        {
            return this.cDBConnect.Execute("sp_get_current_time");
        }

        public DataTable getDistinctTask()
        {
            return this.cDBConnect.Execute("sp_select_Distinct_AuditLogTask");
        }
    }
}

