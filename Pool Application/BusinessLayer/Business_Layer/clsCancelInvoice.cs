namespace Business_Layer
{
    using Business_Layer.Property_Layer;
    using Database_Layer;
    using System;

    public class clsCancelInvoice
    {
        private clsDBConnect DbConn = new clsDBConnect();

        public void InsertUpdateData(objCancelInvoice oCancelInvoice)
        {
            object[,] arrParameter = new object[,] { { "mfldLocationCode", oCancelInvoice.LocationCode }, { "mfldInvoiceNo", oCancelInvoice.InvoiceNo }, { "mfldInvCancelDate", oCancelInvoice.InvCancelDate.ToString("yyyy-MM-dd") }, { "mfldUserCode", oCancelInvoice.UserCode } };
            this.DbConn.Insert("sp_insert_update_invoice_cancel_details", arrParameter);
        }
    }
}

