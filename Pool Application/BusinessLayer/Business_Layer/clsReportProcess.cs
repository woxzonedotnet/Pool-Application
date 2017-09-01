namespace Business_Layer
{
    using Database_Layer;
    using System;
    using System.Data;

    public class clsReportProcess
    {
        private clsDBConnect cDBConnect = new clsDBConnect();

        public void LevelSummaryReport(string strStartDate, string strEndDate)
        {
            DataTable table = this.cDBConnect.SearchDataWithSQL("SELECT * FROM tbl_class_master WHERE fldClassStatus <> 'C'");
            this.cDBConnect.ExecuteSQL("DELETE FROM tbl_monthly_levelwise_summary");
            for (int i = 0; i < table.Rows.Count; i++)
            {
                string str = table.Rows[i]["fldClassCode"].ToString();
                int num2 = 0;
                int num3 = 0;
                int num4 = 0;
                int num5 = 0;
                int num6 = 0;
                int num7 = 0;
                int num8 = 0;
                DataTable table2 = this.cDBConnect.SearchDataWithSQL("SELECT COUNT(*) as TotalStd FROM tbl_student_master WHERE fldClassCode ='" + str + "' AND fldStatus <> 'C'");
                if (Convert.ToString(table2.Rows[0]["TotalStd"]) != "")
                {
                    num2 = Convert.ToInt32(Convert.ToString(table2.Rows[0]["TotalStd"]));
                }
                string strSQL = "SELECT COUNT(tbl_invoice_master.fldStudentNo) as TotalPaidStudents FROM tbl_invoice_master Inner Join tbl_student_master ON tbl_invoice_master.fldLocationCode = tbl_student_master.fldLocationCode AND tbl_invoice_master.fldStudentNo = tbl_student_master.fldStudentNo WHERE tbl_invoice_master.fldPaymentFromDate <=  '" + strStartDate + "' AND tbl_invoice_master.fldPaymentToDate >=  '" + strEndDate + "' AND tbl_student_master.fldClassCode =  '" + str + "' AND fldStatus <> 'C'";
                DataTable table3 = this.cDBConnect.SearchDataWithSQL(strSQL);
                if (Convert.ToString(table3.Rows[0]["TotalPaidStudents"]) != "")
                {
                    num3 = Convert.ToInt32(Convert.ToString(table3.Rows[0]["TotalPaidStudents"]));
                }
                DataTable table4 = this.cDBConnect.SearchDataWithSQL("SELECT * FROM tbl_student_master WHERE fldClassCode ='" + str + "' AND fldStatus <> 'C'");
                for (int j = 0; j < table4.Rows.Count; j++)
                {
                    strSQL = "SELECT tbl_daily_in_out_details.fldStudentNo FROM tbl_daily_in_out_details WHERE tbl_daily_in_out_details.fldAttendanceDate BETWEEN  '" + strStartDate + "' AND '" + strEndDate + "' AND fldStudentNo ='" + table4.Rows[j]["fldStudentNo"].ToString() + "'";
                    if (this.cDBConnect.SearchDataWithSQL(strSQL).Rows.Count == 0)
                    {
                        num5++;
                    }
                }
                strSQL = "SELECT Count(*) as TotalPromoStudents FROM tbl_student_promotion WHERE tbl_student_promotion.fldPromotedClassCode =  '" + str + "' AND tbl_student_promotion.fldPromoteDate BETWEEN  '2013-03-01' AND '2013-03-31'";
                DataTable table6 = this.cDBConnect.SearchDataWithSQL(strSQL);
                if (Convert.ToString(table6.Rows[0]["TotalPromoStudents"]) != "")
                {
                    num6 = Convert.ToInt32(Convert.ToString(table6.Rows[0]["TotalPromoStudents"]));
                }
                strSQL = "SELECT COUNT(*) as TotalNewStudents FROM tbl_student_master WHERE tbl_student_master.fldStatus <>  'C' AND tbl_student_master.fldClassCode =  '" + str + "' AND tbl_student_master.fldDateOfJoin BETWEEN  '" + strStartDate + "' AND '" + strEndDate + "' AND tbl_student_master.fldNewStudent =  '1'";
                DataTable table7 = this.cDBConnect.SearchDataWithSQL(strSQL);
                if (Convert.ToString(table7.Rows[0]["TotalNewStudents"]) != "")
                {
                    num7 = Convert.ToInt32(Convert.ToString(table7.Rows[0]["TotalNewStudents"]));
                }
                strSQL = "SELECT COUNT(*) as TotalReJoinStudents FROM tbl_student_master WHERE tbl_student_master.fldStatus =  'R' AND tbl_student_master.fldClassCode =  '" + str + "' AND tbl_student_master.fldDateOfJoin BETWEEN  '" + strStartDate + "' AND '" + strEndDate + "'";
                DataTable table8 = this.cDBConnect.SearchDataWithSQL(strSQL);
                if (Convert.ToString(table8.Rows[0]["TotalReJoinStudents"]) != "")
                {
                    num8 = Convert.ToInt32(Convert.ToString(table8.Rows[0]["TotalReJoinStudents"]));
                }
                num4 = num2 - num3;
                strSQL = string.Concat(new object[] { 
                    "insert  into tbl_monthly_levelwise_summary2(fldClassCode, fldTotalStudents,fldPaidTotal,fldNotPaid,fldNotAttendance,fldPromoteTotal,NewJoinStatus,RejoinStatus) Values('", str, "',", num2, ",", num3, ",", num4, ",", num5, ",", num6, ",", num7, ",", num8, 
                    ")"
                 });
                this.cDBConnect.ExecuteSQL(strSQL);
            }
        }
    }
}

