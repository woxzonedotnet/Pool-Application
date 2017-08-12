namespace Business_Layer
{
    using Business_Layer.Property_Layer;
    using Database_Layer;
    using System;
    using System.Data;

    public class clsInvoice
    {
        private clsDBConnect DbConn = new clsDBConnect();

        public objInvoice GetInvDetails(string strLocationCode, string strInvoiceNo)
        {
            objInvoice invoice = new objInvoice();
            string str = "fldLocationCode ='" + strLocationCode + "' AND fldInvoiceNo='" + strInvoiceNo + "'";
            DataTable table = this.DbConn.SearchData("tbl_invoice_master", str);
            if (table.Rows.Count > 0)
            {
                invoice.LocationCode = table.Rows[0][1].ToString();
                invoice.StudentNo = table.Rows[0][2].ToString();
                invoice.InvoiceNo = table.Rows[0][3].ToString();
                invoice.InvoiceDate = Convert.ToDateTime(table.Rows[0][4].ToString());
                invoice.PaymentFromDate = Convert.ToDateTime(table.Rows[0][5].ToString());
                invoice.PaymentToDate = Convert.ToDateTime(table.Rows[0][6].ToString());
                invoice.TotalItemAmount = Convert.ToDouble(table.Rows[0][7].ToString());
                invoice.NBTAmount = Convert.ToDouble(table.Rows[0][8].ToString());
                invoice.TotalTaxAmount = Convert.ToDouble(table.Rows[0][9].ToString());
                invoice.Discount = Convert.ToDouble(table.Rows[0][10].ToString());
                invoice.PanaltyAmount = Convert.ToDouble(table.Rows[0][11].ToString());
                invoice.GrandTotal = Convert.ToDouble(table.Rows[0][12].ToString());
                invoice.UserCode = table.Rows[0][13].ToString();
                invoice.InvoiceStatus = table.Rows[0][14].ToString();
                invoice.IsTax = Convert.ToBoolean(table.Rows[0][15].ToString());
                invoice.IsExistInvoice = true;
                return invoice;
            }
            invoice.IsExistInvoice = false;
            return invoice;
        }

        public objInvoice GetInvoiceData(string strLocationCode, string strStudentNo, DateTime dtInvoiceDate)
        {
            objInvoice invoice = new objInvoice();
            string str = "fldLocationCode ='" + strLocationCode + "' AND fldStudentNo='" + strStudentNo + "' AND fldInvoiceDate='" + dtInvoiceDate.ToString("yyyy-MM-dd") + "'";
            DataTable table = this.DbConn.SearchData("tbl_invoice_master", str);
            if (table.Rows.Count > 0)
            {
                invoice.LocationCode = table.Rows[0][1].ToString();
                invoice.StudentNo = table.Rows[0][2].ToString();
                invoice.InvoiceNo = table.Rows[0][3].ToString();
                invoice.InvoiceDate = Convert.ToDateTime(table.Rows[0][4].ToString());
                invoice.PaymentFromDate = Convert.ToDateTime(table.Rows[0][5].ToString());
                invoice.PaymentToDate = Convert.ToDateTime(table.Rows[0][6].ToString());
                invoice.TotalItemAmount = Convert.ToDouble(table.Rows[0][7].ToString());
                invoice.NBTAmount = Convert.ToDouble(table.Rows[0][8].ToString());
                invoice.TotalTaxAmount = Convert.ToDouble(table.Rows[0][9].ToString());
                invoice.Discount = Convert.ToDouble(table.Rows[0][10].ToString());
                invoice.PanaltyAmount = Convert.ToDouble(table.Rows[0][11].ToString());
                invoice.GrandTotal = Convert.ToDouble(table.Rows[0][12].ToString());
                invoice.UserCode = table.Rows[0][13].ToString();
                invoice.InvoiceStatus = table.Rows[0][14].ToString();
                invoice.IsTax = Convert.ToBoolean(table.Rows[0][15].ToString());
                invoice.IsExistInvoice = true;
                return invoice;
            }
            invoice.IsExistInvoice = false;
            return invoice;
        }

        public DataTable GetInvoiceDetails(string strLocationCode, string strStudentNo)
        {
            string str = "fldLocationCode ='" + strLocationCode + "' AND fldStudentNo='" + strStudentNo + "' GROUP BY fldInvoiceID";
            return this.DbConn.SearchData("tbl_invoice_master", str);
        }

        public DataTable GetInvoiceDetails(string strLocationCode, string strStudentNo, DateTime dtInvoiceDate)
        {
            string str = "fldLocationCode ='" + strLocationCode + "' AND fldStudentNo='" + strStudentNo + "' AND fldInvoiceDate='" + dtInvoiceDate.ToString("yyyy-MM-dd") + "'";
            return this.DbConn.SearchData("tbl_invoice_master", str);
        }

        public DataTable GetLastInvoiceDetails(string strLocationCode, string strStudentNo)
        {
            string str = "fldLocationCode ='" + strLocationCode + "' AND fldStudentNo='" + strStudentNo + "' AND fldInvoiceStatus ='A' ORDER BY fldPaymentToDate desc";
            return this.DbConn.SearchData("tbl_invoice_master", str);
        }

        public DataTable GetLastPaymentDates()
        {
            string str = DateTime.Now.AddDays(-60.0).ToString("yyyy-MM-dd");
            string strSQL = "SELECT tbl_invoice_master.fldStudentNo, Max(tbl_invoice_master.fldPaymentToDate) FROM tbl_invoice_master ";
            strSQL = strSQL + "GROUP BY tbl_invoice_master.fldStudentNo HAVING Max(tbl_invoice_master.fldPaymentToDate) < '" + str + "'";
            return this.DbConn.SearchDataWithSQL(strSQL);
        }

        public void InsertUpdateData(objInvoice oInvoice)
        {
            object[,] arrParameter = new object[,] { { "mfldLocationCode", oInvoice.LocationCode }, { "mfldStudentNo", oInvoice.StudentNo }, { "mfldInvoiceNo", oInvoice.InvoiceNo }, { "mfldInvoiceDate", oInvoice.InvoiceDate.ToString("yyyy-MM-dd") }, { "mfldPaymentFromDate", oInvoice.PaymentFromDate.ToString("yyyy-MM-dd") }, { "mfldPaymentToDate", oInvoice.PaymentToDate.ToString("yyyy-MM-dd") }, { "mfldTotalItemAmount", oInvoice.TotalItemAmount }, { "mfldNBTAmount", oInvoice.NBTAmount }, { "mfldTotalTaxAmount", oInvoice.TotalTaxAmount }, { "mfldDiscount", oInvoice.Discount }, { "mfldPanaltyAmount", oInvoice.PanaltyAmount }, { "mfldGrandTotal", oInvoice.GrandTotal }, { "mfldUserCode", oInvoice.UserCode }, { "mfldInvoiceStatus", oInvoice.InvoiceStatus }, { "mfldIsTax", oInvoice.IsTax } };
            this.DbConn.Insert("sp_insert_update_invoice_master", arrParameter);
        }

        public void UpdateInvoice(string strLocationCode, string strInvoiceStatus, string strStudentNo, string strInvoiceNo)
        {
            this.DbConn.UpdateData("tbl_invoice_master", "fldInvoiceStatus='" + strInvoiceStatus + "'", "fldLocationCode='" + strLocationCode + "' AND fldStudentNo='" + strStudentNo + "' AND fldInvoiceNo='" + strInvoiceNo + "'");
        }
    }
}

