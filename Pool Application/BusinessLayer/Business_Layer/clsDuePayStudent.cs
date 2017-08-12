namespace Business_Layer
{
    using Business_Layer.Property_Layer;
    using Database_Layer;
    using System;

    public class clsDuePayStudent
    {
        private clsDBConnect DbConn = new clsDBConnect();

        public void PayDueProcess(objDuePayStudent oDuePayStudent)
        {
            object[,] arrParameter = new object[,] { { "mfldLocationCode", oDuePayStudent.LocationCode }, { "mProcessDate", oDuePayStudent.ProcessDate.ToString("yyyy-MM-dd") }, { "mStatus", oDuePayStudent.Status } };
            this.DbConn.Insert("sp_due_to_pay_process", arrParameter);
        }
    }
}

