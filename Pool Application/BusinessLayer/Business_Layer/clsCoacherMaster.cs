namespace Business_Layer
{
    using Business_Layer.Property_Layer;
    using Database_Layer;
    using System;
    using System.Data;

    public class clsCoacherMaster
    {
        private clsDBConnect DbConn = new clsDBConnect();

        public void DeleteClassMasterData(string strLocationCode, string SearchValue)
        {
            string str = "fldLocationCode ='" + strLocationCode + "' AND fldCoacherCode='" + SearchValue + "'";
            this.DbConn.DeleteData("tbl_coacher_master", str);
        }

        public DataTable GetCoacherData(string strLocationCode)
        {
            string str = "fldLocationCode ='" + strLocationCode + "'";
            return this.DbConn.SearchData("tbl_coacher_master", str);
        }

        public objCoacherMaster GetCoacherData(string strLocationCode, string CoacherCode)
        {
            objCoacherMaster master = new objCoacherMaster();
            clsStatusMaster master2 = new clsStatusMaster();
            string str = "fldLocationCode ='" + strLocationCode + "' AND fldCoacherCode='" + CoacherCode + "'";
            DataTable table = this.DbConn.SearchData("tbl_coacher_master", str);
            if (table.Rows.Count > 0)
            {
                master.LocationCode = table.Rows[0][1].ToString();
                master.CoacherCode = table.Rows[0][2].ToString();
                master.Initials = table.Rows[0][3].ToString();
                master.FullNameLineOne = table.Rows[0][4].ToString();
                master.FullNameLineTwo = table.Rows[0][5].ToString();
                master.PrefName = table.Rows[0][6].ToString();
                master.DateOfJoined = Convert.ToDateTime(table.Rows[0][7].ToString());
                master.Religion = table.Rows[0][8].ToString();
                master.OtherName = table.Rows[0][9].ToString();
                master.NICNo = table.Rows[0][10].ToString();
                master.NICDateOfIssued = Convert.ToDateTime(table.Rows[0][11].ToString());
                master.EPFNo = table.Rows[0][12].ToString();
                master.SurName = table.Rows[0][13].ToString();
                master.PINNumber = table.Rows[0][14].ToString();
                master.Passport = table.Rows[0][15].ToString();
                master.PassportDateOfIssued = Convert.ToDateTime(table.Rows[0][0x10].ToString());
                master.PassportDateOfExpire = Convert.ToDateTime(table.Rows[0][0x11].ToString());
                master.DrivingLicenseNo = table.Rows[0][0x12].ToString();
                master.DrivingLicenseIssued = Convert.ToDateTime(table.Rows[0][0x13].ToString());
                master.DrivingLicenseExpire = Convert.ToDateTime(table.Rows[0][20].ToString());
                master.DOB = Convert.ToDateTime(table.Rows[0][0x15].ToString());
                master.MarriedStatus = table.Rows[0][0x16].ToString();
                master.PermanentAddNo = table.Rows[0][0x17].ToString();
                master.PermanentRoad = table.Rows[0][0x18].ToString();
                master.PermanentTown = table.Rows[0][0x19].ToString();
                master.PermanentCity = table.Rows[0][0x1a].ToString();
                master.TemporyAddNo = table.Rows[0][0x1b].ToString();
                master.TemporyRoad = table.Rows[0][0x1c].ToString();
                master.TemporyTown = table.Rows[0][0x1d].ToString();
                master.TemporyCity = table.Rows[0][30].ToString();
                master.MobileNo = table.Rows[0][0x1f].ToString();
                master.HomeTPNo = table.Rows[0][0x20].ToString();
                master.EmailAddress = table.Rows[0][0x21].ToString();
                master.BluedGroup = table.Rows[0][0x22].ToString();
                master.CoacherStatus = master2.GetStatusByCode(table.Rows[0][0x23].ToString()).StatusName;
                master.Gender = table.Rows[0][0x24].ToString();
                master.CoacherIsExist = true;
                return master;
            }
            master.CoacherIsExist = false;
            return master;
        }

        public void InsertUpdateData(objCoacherMaster oCoacherMaster)
        {
            object[,] arrParameter = new object[,] { 
                { "mfldLocationCode", oCoacherMaster.LocationCode }, { "mfldCoacherCode", oCoacherMaster.CoacherCode }, { "mfldInitials", oCoacherMaster.Initials }, { "mfldFullNameLineOne", oCoacherMaster.FullNameLineOne }, { "mfldFullNameLineTwo", oCoacherMaster.FullNameLineTwo }, { "mfldPrefName", oCoacherMaster.PrefName }, { "mfldDateOfJoined", oCoacherMaster.DateOfJoined }, { "mfldReligion", oCoacherMaster.Religion }, { "mfldOtherName", oCoacherMaster.OtherName }, { "mfldNIC", oCoacherMaster.NICNo }, { "mfldNICDateOfIssued", oCoacherMaster.NICDateOfIssued }, { "mfldEPFNo", oCoacherMaster.EPFNo }, { "mfldSurName", oCoacherMaster.SurName }, { "mfldPINNumber", oCoacherMaster.PINNumber }, { "mfldPassport", oCoacherMaster.Passport }, { "mfldPassportDateOfIssued", oCoacherMaster.PassportDateOfIssued }, 
                { "mfldPassportDateOfExpire", oCoacherMaster.PassportDateOfExpire }, { "mfldDrivingLicenseNo", oCoacherMaster.DrivingLicenseNo }, { "mfldDrivingLicenseIssued", oCoacherMaster.DrivingLicenseIssued }, { "mfldDrivingLicenseExpire", oCoacherMaster.DrivingLicenseExpire }, { "mfldDOB", oCoacherMaster.DOB }, { "mfldMarriedStatus", oCoacherMaster.MarriedStatus }, { "mfldPermanentAddNo", oCoacherMaster.PermanentAddNo }, { "mfldPermanentRoad", oCoacherMaster.PermanentRoad }, { "mfldPermanentTown", oCoacherMaster.PermanentTown }, { "mfldPermanentCity", oCoacherMaster.PermanentCity }, { "mfldTemporyAddNo", oCoacherMaster.TemporyAddNo }, { "mfldTemporyRoad", oCoacherMaster.TemporyRoad }, { "mfldTemporyTown", oCoacherMaster.TemporyTown }, { "mfldTemporyCity", oCoacherMaster.TemporyCity }, { "mfldMobileNo", oCoacherMaster.MobileNo }, { "mfldHomeTPNo", oCoacherMaster.HomeTPNo }, 
                { "mfldEmailAddress", oCoacherMaster.EmailAddress }, { "mfldBluedGroup", oCoacherMaster.BluedGroup }, { "mfldCoacherStatus", oCoacherMaster.CoacherStatus }, { "mfldGender", oCoacherMaster.Gender }
             };
            this.DbConn.Insert("sp_insert_update_coacher_master", arrParameter);
        }
    }
}

