namespace Business_Layer
{
    using Business_Layer.Property_Layer;
    using Database_Layer;
    using System;
    using System.Data;

    public class clsDailyPaymentDetails
    {
        private clsDBConnect DbConn = new clsDBConnect();

        public string GetNextInvNo()
        {
            int num = 1;
            string strSQL = "SELECT MAX(CAST(substring(fldInvoiceNo,2,6) AS unsigned)) as MaxNumber FROM tbl_daily_payment_details";
            DataTable table = this.DbConn.SearchDataWithSQL(strSQL);
            if ((table.Rows.Count > 0) && (Convert.ToString(table.Rows[0]["MaxNumber"]) != ""))
            {
                num = Convert.ToInt32(Convert.ToString(table.Rows[0]["MaxNumber"])) + 1;
            }
            return ("D" + num.ToString("000000"));
        }

        public DataTable GetStudentsNames(string strNamePart)
        {
            string strSQL = "SELECT Distinct(fldStudentName) FROM tbl_daily_payment_details WHERE fldStudentName Like '%" + strNamePart + "%'";
            return this.DbConn.SearchDataWithSQL(strSQL);
        }

        public void InsertUpdateData(objDailyPaymentDetails oDailyPaymentDetails)
        {
            object[,] arrParameter = new object[,] { { "mfldInvoiceNo", oDailyPaymentDetails.InvoiceNo }, { "mfldStudentName", oDailyPaymentDetails.StudentName }, { "mfldInvoiceDate", oDailyPaymentDetails.InvoiceDate }, { "mfldLevelCode", oDailyPaymentDetails.LevelCode }, { "mfldInvoiceAmount", oDailyPaymentDetails.InvoiceAmount }, { "mfldUserCode", oDailyPaymentDetails.UserCode }, { "mfldInvoiceStatus", oDailyPaymentDetails.InvoiceStatus } };
            this.DbConn.Insert("sp_insert_update_daily_payment_details", arrParameter);
        }
    }
}

