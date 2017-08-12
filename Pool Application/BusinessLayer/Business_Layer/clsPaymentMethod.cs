namespace Business_Layer
{
    using Business_Layer.Property_Layer;
    using Database_Layer;
    using System;
    using System.Data;

    public class clsPaymentMethod
    {
        private clsDBConnect DbConn = new clsDBConnect();

        public objPaymentMethod GetPaymentMethod(string strLocationCode, string strPaymentMethodCode)
        {
            objPaymentMethod method = new objPaymentMethod();
            string str = "fldLocationCode ='" + strLocationCode + "' AND fldPaymentMethodCode='" + strPaymentMethodCode + "'";
            DataTable table = this.DbConn.SearchData("tbl_payment_method", str);
            if (table.Rows.Count > 0)
            {
                method.LocationCode = table.Rows[0][1].ToString();
                method.PaymentCode = table.Rows[0][2].ToString();
                method.PaymentDays = Convert.ToInt16(table.Rows[0][3].ToString());
                method.PaymentDescription = table.Rows[0][4].ToString();
                method.IxExist = true;
                return method;
            }
            method.IxExist = false;
            return method;
        }

        public DataTable GetPaymentMethods(string strLocationCode)
        {
            string str = "fldLocationCode ='" + strLocationCode + "'";
            return this.DbConn.SearchData("tbl_payment_method", str);
        }

        public void InsertUpdateData(objPaymentMethod oPaymentMethod)
        {
            object[,] arrParameter = new object[,] { { "mfldLocationCode", oPaymentMethod.LocationCode }, { "mfldPaymentMethodCode", oPaymentMethod.PaymentCode }, { "mfldPaymentDayDuration", oPaymentMethod.PaymentDays }, { "mfldPaymentMethodDescription", oPaymentMethod.PaymentDescription } };
            this.DbConn.Insert("sp_insert_update_payment_method", arrParameter);
        }
    }
}

