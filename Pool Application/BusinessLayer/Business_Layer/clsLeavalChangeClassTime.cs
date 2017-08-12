namespace Business_Layer
{
    using Business_Layer.Property_Layer;
    using Database_Layer;
    using System;
    using System.Data;

    public class clsLeavalChangeClassTime
    {
        private clsDBConnect DbConn = new clsDBConnect();

        public void DeleteStudentClass(string strLocationCode, string strStudentNo)
        {
            string str = "fldLocationCode ='" + strLocationCode + "' AND fldStudentNo ='" + strStudentNo + "'";
            this.DbConn.DeleteData("tbl_class_times", str);
        }

        public void DeleteStudentDayChange(string strLocationcode, string strStudentNo)
        {
            string str = "fldLocationCode ='" + strLocationcode + "' AND fldStudentNo ='" + strStudentNo + "'";
            this.DbConn.DeleteData("tbl_day_changed_details", str);
        }

        public void InsertUpdateData(objLeavalChangeClassTime oLeavalChangeClassTime)
        {
            object[,] arrParameter = new object[,] { { "mfldLocationCode", oLeavalChangeClassTime.LocationCode }, { "mfldStudentNo", oLeavalChangeClassTime.StudentNo }, { "mfldPromotedDate", oLeavalChangeClassTime.PromotedDate.ToString("yyyy-MM-dd") }, { "mfldPreviousClassCode", oLeavalChangeClassTime.PreviousClassCode }, { "mfldClassCode", oLeavalChangeClassTime.ClassCode } };
            this.DbConn.Insert("sp_insert_update_leaval_change_details", arrParameter);
        }

        public DataTable StudentIspromotion(string LocationCode, string strStudentCode)
        {
            string str = "fldLocationCode ='" + LocationCode + "' AND fldStudentNo ='" + strStudentCode + "' AND fldPromotedDate >'" + DateTime.Now.ToString("yyyy-MM-dd") + "'";
            return this.DbConn.SearchData("tbl_leval_changed_details", str);
        }

        public DataTable StudentIspromotionByComboDate(string LocationCode, string strStudentCode, string strFilterDate)
        {
            string str = "fldLocationCode ='" + LocationCode + "' AND fldStudentNo ='" + strStudentCode + "' AND fldPromotedDate >'" + strFilterDate + "'";
            return this.DbConn.SearchData("tbl_leval_changed_details", str);
        }
    }
}

