namespace Business_Layer
{
    using Business_Layer.Property_Layer;
    using Database_Layer;
    using System;
    using System.Data;

    public class clsTax
    {
        private clsDBConnect DbConn = new clsDBConnect();

        public DataTable GetTax()
        {
            return this.DbConn.SearchData("tbl_tax_master");
        }

        public objTax GetTaxData(string strTaxCode)
        {
            objTax tax = new objTax();
            clsStatusMaster master = new clsStatusMaster();
            string str = "fldTaxCode ='" + strTaxCode + "'";
            DataTable table = this.DbConn.SearchData("tbl_tax_master", str);
            if (table.Rows.Count > 0)
            {
                tax.TaxCode = table.Rows[0][1].ToString();
                tax.TaxDescription = table.Rows[0][2].ToString();
                tax.TaxValue = Convert.ToDouble(table.Rows[0][3].ToString());
                tax.IsNBTAdded = Convert.ToBoolean(table.Rows[0][4].ToString());
                tax.IsExcistTax = true;
                return tax;
            }
            tax.IsExcistTax = false;
            return tax;
        }
    }
}

