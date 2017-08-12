namespace Business_Layer
{
    using Business_Layer.Property_Layer;
    using Database_Layer;
    using System;
    using System.Data;

    public class clsPaymentDeatils
    {
        private clsDBConnect DbConn = new clsDBConnect();

        public void DeletePaymentDeatils(string strLocationCode, string strStudentNumber)
        {
            string str = "fldLocationCode ='" + strLocationCode + "' AND fldStudentNo='" + strStudentNumber + "'";
            this.DbConn.DeleteData("tbl_student_pay_details", str);
        }

        public objPaymentDeatils GetPaymentDeatils(string strLocationCode, string strStudentNo)
        {
            objPaymentDeatils deatils = new objPaymentDeatils();
            string str = "fldLocationCode ='" + strLocationCode + "' AND fldStudentNo='" + strStudentNo + "'";
            DataTable table = this.DbConn.SearchData("tbl_student_pay_details", str);
            if (table.Rows.Count > 0)
            {
                deatils.LocationCode = table.Rows[0][0].ToString();
                deatils.StudentNo = table.Rows[0][1].ToString();
                deatils.StudentDicount = Convert.ToDouble(table.Rows[0][2].ToString());
                deatils.PenaltyPayMethodCode = table.Rows[0][3].ToString();
                deatils.PenaltyPayAmount = Convert.ToDouble(table.Rows[0][4].ToString());
                deatils.StudentPayMethodCode = table.Rows[0][5].ToString();
                deatils.IsPaymentExist = true;
                return deatils;
            }
            deatils.IsPaymentExist = false;
            return deatils;
        }

        public void InsertUpdateData(objPaymentDeatils oPaymentDeatils)
        {
            object[,] arrParameter = new object[,] { { "mfldLocationCode", oPaymentDeatils.LocationCode }, { "mfldStudentNo", oPaymentDeatils.StudentNo }, { "mfldStudentDicount", oPaymentDeatils.StudentDicount }, { "mfldPenaltyPayMethodCode", oPaymentDeatils.PenaltyPayMethodCode }, { "mfldPenaltyPayAmount", oPaymentDeatils.PenaltyPayAmount }, { "mfldStudentPayMethodCode", oPaymentDeatils.StudentPayMethodCode } };
            this.DbConn.Insert("sp_insert_update_payment_details", arrParameter);
        }
    }
}

