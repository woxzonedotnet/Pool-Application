namespace Business_Layer
{
    using Business_Layer.Property_Layer;
    using Database_Layer;
    using System;
    using System.Data;

    public class clsInvoiceItemAmounts
    {
        private clsDBConnect DbConn = new clsDBConnect();

        public objInvoiceItemAmounts GetInvoiceItem(string strLocationCode, string strInvoiceNo, string strStudentNo)
        {
            objInvoiceItemAmounts amounts = new objInvoiceItemAmounts();
            string str = "fldLocationCode ='" + strLocationCode + "' AND fldInvoiceNo='" + strInvoiceNo + "' AND fldStudentNo='" + strStudentNo + "'";
            DataTable table = this.DbConn.SearchData("tbl_invoice_item_amounts", str);
            if (table.Rows.Count > 0)
            {
                amounts.LocationCode = table.Rows[0][1].ToString();
                amounts.InvoiceNo = table.Rows[0][2].ToString();
                amounts.StudentNo = table.Rows[0][3].ToString();
                amounts.InvoiceItemCode = table.Rows[0][4].ToString();
                amounts.InvoiceItemAmount = Convert.ToDouble(table.Rows[0][5].ToString());
                amounts.IsExistInvoiceItem = true;
                return amounts;
            }
            amounts.IsExistInvoiceItem = false;
            return amounts;
        }

        public DataTable GetInvoiceItemDetails(string strLocationCode, string strInvoiceNo, string strStudentNo)
        {
            string str = "fldLocationCode ='" + strLocationCode + "' AND fldInvoiceNo='" + strInvoiceNo + "' AND fldStudentNo='" + strStudentNo + "'";
            return this.DbConn.SearchData("tbl_invoice_item_amounts", str);
        }

        public void InsertUpdateData(objInvoiceItemAmounts oInvoiceItemAmounts)
        {
            object[,] arrParameter = new object[,] { { "mfldLocationCode", oInvoiceItemAmounts.LocationCode }, { "mfldInvoiceNo", oInvoiceItemAmounts.InvoiceNo }, { "mfldStudentNo", oInvoiceItemAmounts.StudentNo }, { "mfldItemCode", oInvoiceItemAmounts.InvoiceItemCode }, { "mfldItemAmount", oInvoiceItemAmounts.InvoiceItemAmount } };
            this.DbConn.Insert("sp_insert_update_invoice_item_amounts", arrParameter);
        }
    }
}

