namespace Business_Layer
{
    using Business_Layer.Property_Layer;
    using Database_Layer;
    using System;
    using System.Data;

    public class clsAutoGenerator
    {
        private clsDBConnect DbConn = new clsDBConnect();

        public objAutoGenerator GetAutoGeneratorNumber(string strLocationCode)
        {
            objAutoGenerator generator = new objAutoGenerator();
            string str = "fldLocationCode ='" + strLocationCode + "'";
            DataTable table = this.DbConn.SearchData("tbl_generator_maste", str);
            if (table.Rows.Count > 0)
            {
                generator.LocationCode = table.Rows[0][1].ToString();
                generator.AutoNumber = Convert.ToInt32(table.Rows[0][3].ToString());
                generator.AutoNumberDescription = table.Rows[0][2].ToString();
                generator.IsExistNumber = true;
                return generator;
            }
            generator.IsExistNumber = false;
            return generator;
        }
    }
}

