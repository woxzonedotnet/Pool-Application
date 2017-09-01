namespace Business_Layer
{
    using Business_Layer.Property_Layer;
    using Database_Layer;
    using System;
    using System.Data;

    public class clsStudentMaster
    {
        private clsDBConnect DbConn = new clsDBConnect();

        public void DeleteStudentData(string strLocationCode, string strStudentCode)
        {
            string str = "fldLocationCode='" + strLocationCode + "' AND fldStudentNo='" + strStudentCode + "'";
            this.DbConn.DeleteData("tbl_student_master", str);
        }

        public DataTable GetStudentData(string strLocationCode)
        {
            string str = "fldLocationCode ='" + strLocationCode + "'";
            return this.DbConn.SearchData("tbl_student_master", str);
        }

        public objStudentMaster GetStudentData(string strLocationCode, string StudentNo)
        {
            objStudentMaster master = new objStudentMaster();
            clsStatusMaster master2 = new clsStatusMaster();
            string str = "fldLocationCode ='" + strLocationCode + "' AND fldStudentNo='" + StudentNo + "'";
            DataTable table = DbConn.SearchData("tbl_student_master", str);
            if (table.Rows.Count > 0)
            {
                master.StudentNo = table.Rows[0][2].ToString();
                master.NameInFullL1 = table.Rows[0][3].ToString();
                master.NameInFullL2 = table.Rows[0][4].ToString();
                master.Address_Line1 = table.Rows[0][5].ToString();
                master.Address_Line2 = table.Rows[0][6].ToString();
                master.Telephone = table.Rows[0][7].ToString();
                master.EmailAddress = table.Rows[0][8].ToString();
                master.DateOfBirth = Convert.ToDateTime(table.Rows[0][9].ToString());
                master.SchoolName = table.Rows[0][10].ToString();
                master.EmergencyInformarName = table.Rows[0][11].ToString();
                master.EmergencyInformarTelephone = table.Rows[0][12].ToString();
                master.PINNumber = table.Rows[0][13].ToString();
                master.Level = table.Rows[0][14].ToString();
                master.DateOfJoin = Convert.ToDateTime(table.Rows[0][15].ToString());
                master.Fees = Convert.ToDouble(table.Rows[0][0x10].ToString());
                master.Remarks = table.Rows[0][0x11].ToString();
                master.Photograph = table.Rows[0][0x12].ToString();
                master.FatherName = table.Rows[0][0x13].ToString();
                master.FatherOccupation = table.Rows[0][20].ToString();
                master.FatherPlaceOfWork = table.Rows[0][0x15].ToString();
                master.FatherTelephone = table.Rows[0][0x16].ToString();
                master.FatherMobile = table.Rows[0][0x17].ToString();
                master.FatherEmail = table.Rows[0][0x18].ToString();
                master.MotherName = table.Rows[0][0x19].ToString();
                master.MotherOccupation = table.Rows[0][0x1a].ToString();
                master.MotherPlaceOfWork = table.Rows[0][0x1b].ToString();
                master.MotherTelephone = table.Rows[0][0x1c].ToString();
                master.MotherMobile = table.Rows[0][0x1d].ToString();
                master.MotherEmail = table.Rows[0][30].ToString();
                master.Status = table.Rows[0][0x1f].ToString();
                master.IsExistStudent = true;
                return master;
            }
            master.IsExistStudent = false;
            return master;
        }

        public DataTable GetStudentData(string strLocationCode, string strLevelCode, string strStatus)
        {
            string str = "fldLocationCode ='" + strLocationCode + "' AND fldClassCode LIKE '" + strLevelCode + "' AND fldStatus LIKE '" + strStatus + "'";
            return this.DbConn.SearchData("tbl_student_master", str);
        }

        public DataTable GetStudentDetails(string strLocationCode, string strStudentNo, string strStatus)
        {
            string str = "fldLocationCode ='" + strLocationCode + "' AND fldStudentNo LIKE '" + strStudentNo + "' AND fldStatus LIKE '" + strStatus + "'";
            return this.DbConn.SearchData("tbl_student_master", str);
        }

        public DataTable GetStudentDetailsNonCancel(string strLocationCode, string strStudentNo, string strCancelStatus)
        {
            string str = "fldLocationCode ='" + strLocationCode + "' AND fldStudentNo LIKE '" + strStudentNo + "' AND fldStatus <> '" + strCancelStatus + "'";
            return this.DbConn.SearchData("tbl_student_master", str);
        }

        public int GetTotalStudentInClass(string strLocationCode, string strLevelCode)
        {
            string strSQL = "SELECT Count(*) as TotalStudents from tbl_student_master WHERE fldLocationCode ='" + strLocationCode + "' AND fldClassCode = '" + strLevelCode + "' AND fldStatus <> 'C'";
            DataTable table = this.DbConn.SearchDataWithSQL(strSQL);
            int num = 0;
            if (table.Rows.Count > 0)
            {
                num = Convert.ToInt32(table.Rows[0]["TotalStudents"].ToString());
            }
            return num;
        }

        public void InsertUpdate(objStudentMaster oStudentMaster)
        {
            object[,] arrParameter = new object[,] { 
                { "mfldLocationCode", oStudentMaster.LocationCode }, { "mfldStudentNo", oStudentMaster.StudentNo }, { "mfldNameInFullL1", oStudentMaster.NameInFullL1 }, { "mfldNameInFullL2", oStudentMaster.NameInFullL2 }, { "mfldAddress_Line1", oStudentMaster.Address_Line1 }, { "mfldAddress_Line2", oStudentMaster.Address_Line2 }, { "mfldTelephone", oStudentMaster.Telephone }, { "mfldEmailAddress", oStudentMaster.EmailAddress }, { "mfldDateOfBirth", oStudentMaster.DateOfBirth }, { "mfldSchoolName", oStudentMaster.SchoolName }, { "mfldFatherName", oStudentMaster.FatherName }, { "mfldFatherOccupation", oStudentMaster.FatherOccupation }, { "mfldFatherWorkingPlace", oStudentMaster.FatherPlaceOfWork }, { "mfldFatherTelNo", oStudentMaster.FatherTelephone }, { "mfldFatherMobileNo", oStudentMaster.FatherMobile }, { "mfldFatherEmailAddress", oStudentMaster.FatherEmail }, 
                { "mfldMotherName", oStudentMaster.MotherName }, { "mfldMotherOccupation", oStudentMaster.MotherOccupation }, { "mfldMotherWorkingPlace", oStudentMaster.MotherPlaceOfWork }, { "mfldMotherTelNo", oStudentMaster.MotherTelephone }, { "mfldMotherMobileNo", oStudentMaster.MotherMobile }, { "mfldMotherEmailAddress", oStudentMaster.MotherEmail }, { "mfldEmergencyInformarName", oStudentMaster.EmergencyInformarName }, { "mfldEmergencyInformarTelephone", oStudentMaster.EmergencyInformarTelephone }, { "mfldPINNumber", oStudentMaster.PINNumber }, { "mfldClassCode", oStudentMaster.Level }, { "mfldDateOfJoin", oStudentMaster.DateOfJoin }, { "mfldCoacherCode", oStudentMaster.CoacherCode }, { "mfldAssCoacherCode", oStudentMaster.AssCoacherCode }, { "mfldFees", oStudentMaster.Fees }, { "mfldRemarks", oStudentMaster.Remarks }, { "mfldPhotograph", oStudentMaster.Photograph }, 
                { "mfldStatus", oStudentMaster.Status }
             };
            this.DbConn.Insert("sp_insert_update_student_master", arrParameter);
        }

        public string NextStudentNumber(string strLocationCode)
        {
            string str = "000001";
            object[,] arrParameter = new object[,] { { "mfldLocationCode", strLocationCode } };
            DataTable table = this.DbConn.Execute("sp_Next_Student_Number", arrParameter);
            if (table.Rows.Count > 0)
            {
                double num = Convert.ToInt16(table.Rows[0][0].ToString()) + 1;
                str = string.Format("{0:000000}", num);
            }
            return str;
        }

        public void UpdatePromotedLevel(string strLocationCode, string strStudentNo, string strClassCode, DateTime dtJoinDate)
        {
            this.DbConn.UpdateData("tbl_student_master", "fldNextPromotedLevel='" + strClassCode + "'", "fldLocationCode='" + strLocationCode + "' AND fldStudentNo='" + strStudentNo + "'");
        }

        public void UpdateStatus(string strLocationCode, string strStudentNo, string strStatus)
        {
            this.DbConn.UpdateData("tbl_student_master", "fldStatus='" + strStatus + "'", "fldLocationCode='" + strLocationCode + "' AND fldStudentNo='" + strStudentNo + "'");
        }

        public void UpdateValues(string strLocationCode, string strStudentNo, string strClassCode, DateTime dtRegDate)
        {
            this.DbConn.UpdateData("tbl_student_master", "fldClassCode='" + strClassCode + "' ,fldDateOfJoin='" + dtRegDate.ToString("yyyy-MM-dd") + "',fldDateOfLevelJoin='" + dtRegDate.ToString("yyyy-MM-dd") + "'", "fldLocationCode='" + strLocationCode + "' AND fldStudentNo='" + strStudentNo + "'");
        }
    }
}

