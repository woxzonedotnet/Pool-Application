namespace Business_Layer
{
    using Business_Layer.Property_Layer;
    using Database_Layer;
    using System;
    using System.Data;

    public class clsStudentPromotion
    {
        private clsDBConnect DbConn = new clsDBConnect();

        public string GetNewPromoID()
        {
            string strSQL = "SELECT Max(fldLevalChangeID) as MaxID FROM tbl_student_promotion";
            DataTable table = this.DbConn.SearchDataWithSQL(strSQL);
            int num = 1;
            if (table.Rows.Count > 0)
            {
                string str2 = Convert.ToString(table.Rows[0]["MaxID"]);
                if (str2 != "")
                {
                    num = Convert.ToInt32(str2) + 1;
                }
            }
            return num.ToString("000000");
        }

        public DataTable GetPendingPromotions(string strLocationCode, DateTime dPromotedDate)
        {
            string str = "fldLocationCode ='" + strLocationCode + "' AND fldPromoteDate ='" + dPromotedDate.ToString("yyyy-MM-dd") + "' AND fldPromotedStatus='P'";
            return this.DbConn.SearchData("tbl_student_promotion", str);
        }

        public DataTable GetPromotedClassTimes(string strLocationCode, string strPromoID, string strClassCode, string strClassTimeCode)
        {
            string str = " fldLocationCode ='" + strLocationCode + "' AND fldPromoID ='" + strPromoID + "' AND  fldClassCode ='" + strClassCode + "' AND  fldClassTimeCode ='" + strClassTimeCode + "'";
            return this.DbConn.SearchData("tbl_student_promotion_details", str);
        }

        public DataTable GetPromotedStudents(string strStartDate, string strEndDate, string strPromotedClassCode)
        {
            string strSQL = ("SELECT * FROM tbl_student_promotion WHERE fldPromoteDate BETWEEN  '" + strStartDate + "' AND '" + strEndDate + "' AND ") + "fldPromotedStatus =  'P' AND fldPromotedClassCode='" + strPromotedClassCode + "'";
            return this.DbConn.SearchDataWithSQL(strSQL);
        }

        public DataTable GetPromotion(string strStudentNumber, string strStartDate, string strEndDate, string strCurrentClassCode)
        {
            string str2 = "SELECT * FROM tbl_student_promotion WHERE fldPromoteDate BETWEEN  '" + strStartDate + "' AND '" + strEndDate + "' AND ";
            string strSQL = str2 + "fldPromotedStatus =  'P' AND fldStudentNo =  '" + strStudentNumber + "' AND fldCurrentClassCode='" + strCurrentClassCode + "'";
            return this.DbConn.SearchDataWithSQL(strSQL);
        }

        public DataTable GetPromotionDetails(string strPromotionID)
        {
            string str = "fldPromoID ='" + strPromotionID + "'";
            return this.DbConn.SearchData("tbl_student_promotion_details", str);
        }

        public void InsertUpdateStudentPromotion(objStudentPromotion oStudentPromotion)
        {
            object[,] arrParameter = new object[,] { { "mfldPromoID", oStudentPromotion.PromoID }, { "mfldLocationCode", oStudentPromotion.LocationCode }, { "mfldStudentNo", oStudentPromotion.StudentNo }, { "mfldCurrentClassCode", oStudentPromotion.CurrentClassCode }, { "mfldPromotedClassCode", oStudentPromotion.PromotedClassCode }, { "mfldPromoteDate", oStudentPromotion.PromoteDate }, { "mfldPromotedStatus", oStudentPromotion.PromotedStatus } };
            this.DbConn.Insert("sp_insert_update_student_promotion", arrParameter);
        }

        public void InsertUpdateStudentPromotionDetails(objStudentPromotion oStudentPromotion)
        {
            object[,] arrParameter = new object[,] { { "mfldPromoID", oStudentPromotion.PromoID }, { "mfldLocationCode", oStudentPromotion.LocationCode }, { "mfldStudentNo", oStudentPromotion.StudentNo }, { "mfldClassCode", oStudentPromotion.ClassCode }, { "mfldClassTimeCode", oStudentPromotion.ClassTimeCode } };
            this.DbConn.Insert("sp_insert_update_student_promotion_details", arrParameter);
        }

        public void UpdateValues(string strPromoID)
        {
            this.DbConn.UpdateData("tbl_student_promotion", "fldPromotedStatus='D'", "fldPromoID='" + strPromoID + "'");
        }
    }
}

