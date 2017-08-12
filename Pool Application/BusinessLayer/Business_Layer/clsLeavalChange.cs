namespace Business_Layer
{
    using Business_Layer.Property_Layer;
    using Database_Layer;
    using System;

    public class clsLeavalChange
    {
        private clsDBConnect DbConn = new clsDBConnect();

        public void DeleteTimeDetails(string strLocationCode, string strStudentNumber, string strClassCode, DateTime dtDate)
        {
            string str = "fldLocationCode ='" + strLocationCode + "' AND fldStudentNo='" + strStudentNumber + "' AND fldClassCode='" + strClassCode + "' AND fldPromotedDate='" + dtDate.ToString("yyyy-MM-dd") + "'";
            this.DbConn.DeleteData("tbl_leval_changed_details", str);
        }

        public void InsertUpdateData(objLeavalChange oLeavalChange)
        {
            object[,] arrParameter = new object[,] { { "mfldLocationCode", oLeavalChange.LocationCode }, { "mfldStudentNo", oLeavalChange.StudentNo }, { "mfldClassCode", oLeavalChange.ClassCode }, { "mfldPromotedDate", oLeavalChange.PromotedDate } };
            this.DbConn.Insert("sp_insert_update_leaval_change_details", arrParameter);
        }
    }
}

