namespace Business_Layer
{
    using Business_Layer.Property_Layer;
    using Database_Layer;
    using System;
    using System.Data;

    public class clsInvoiceTaxAmount
    {
        private clsDBConnect DbConn = new clsDBConnect();

        public DataTable GetInvoiceTaxDetails(string strLocationCode, string strInvoiceNo, string strStudentNo)
        {
            string str = "fldLocationCode ='" + strLocationCode + "' AND fldInvoiceNo='" + strInvoiceNo + "' AND fldStudentNo='" + strStudentNo + "'";
            return this.DbConn.SearchData("tbl_invoice_tax_amount", str);
        }

        public void InsertUpdateData(objInvoiceTaxAmount oInvoiceTaxAmount)
        {
            object[,] arrParameter = new object[,] { { "mfldLocationCode", oInvoiceTaxAmount.LocationCode }, { "mfldStudentNo", oInvoiceTaxAmount.StudentNo }, { "mfldInvoiceNo", oInvoiceTaxAmount.InvoiceNo }, { "mfldInvTaxCode", oInvoiceTaxAmount.InvoiceTaxCode }, { "mfldInvTaxAmount", oInvoiceTaxAmount.InvoiceTaxAmount } };
            this.DbConn.Insert("sp_insert_update_invoice_tax_amount", arrParameter);
        }
    }
}

