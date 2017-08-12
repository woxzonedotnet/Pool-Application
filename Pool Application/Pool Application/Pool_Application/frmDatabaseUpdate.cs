namespace Pool_Application
{
    using Business_Layer;
    using Business_Layer.Property_Layer;
    using Database_Layer;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;

    public class frmDatabaseUpdate : Form
    {
        private IContainer components = null;

        public frmDatabaseUpdate()
        {
            this.InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void frmDatabaseUpdate_Load(object sender, EventArgs e)
        {
            clsDBConnect connect = new clsDBConnect();
            objClassTimeTable oClassTimeTable = new objClassTimeTable();
            clsClassTimeTable table2 = new clsClassTimeTable();
            clsGlobleVariable variable = new clsGlobleVariable();
            string strSQL = "";
            foreach (string str2 in new string[] { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" })
            {
                strSQL = "SELECT * FROM tbl_class_master";
                DataTable table3 = connect.SearchDataWithSQL(strSQL);
                for (int i = 0; i < table3.Rows.Count; i++)
                {
                    strSQL = "SELECT * FROM tbl_class_times WHERE fldClassCode ='" + table3.Rows[i]["fldClassCode"].ToString() + "' AND fldDayType='" + str2 + "'";
                    DataTable table4 = connect.SearchDataWithSQL(strSQL);
                    for (int j = 0; j < table4.Rows.Count; j++)
                    {
                        string newClassTimeCode = table2.GetNewClassTimeCode(variable.LocationCode, table4.Rows[j]["fldClassCode"].ToString());
                        oClassTimeTable.LocationCode = variable.LocationCode;
                        oClassTimeTable.ClassTimeCode = newClassTimeCode;
                        oClassTimeTable.ClassCode = table4.Rows[j]["fldClassCode"].ToString();
                        oClassTimeTable.DayType = table4.Rows[j]["fldDayType"].ToString();
                        string str4 = string.Format("{0:HH:mm tt}", Convert.ToDateTime(table4.Rows[j]["fldInTime"].ToString()));
                        string str5 = string.Format("{0:HH:mm tt}", Convert.ToDateTime(table4.Rows[j]["fldOutTime"].ToString()));
                        if (Convert.ToInt32(str4.Substring(0, 2)) < 8)
                        {
                            str4 = str4.Replace("AM", "PM");
                        }
                        if (Convert.ToInt32(str5.Substring(0, 2)) < 8)
                        {
                            str5 = str5.Replace("AM", "PM");
                        }
                        oClassTimeTable.InTime = str4;
                        oClassTimeTable.OutTime = str5;
                        oClassTimeTable.Session = table4.Rows[j]["fldSession"].ToString();
                        oClassTimeTable.Status = "A";
                        strSQL = "SELECT * FROM tbl_class_time_master WHERE fldClassCode ='" + oClassTimeTable.ClassCode + "' AND fldDayType='" + str2 + "' AND fldInTime ='" + oClassTimeTable.InTime + "' AND fldOutTime ='" + oClassTimeTable.OutTime + "'";
                        DataTable table5 = connect.SearchDataWithSQL(strSQL);
                        if (table5.Rows.Count == 0)
                        {
                            table2.InsertUpdateData(oClassTimeTable);
                        }
                        else
                        {
                            newClassTimeCode = table5.Rows[0]["fldClassTimeCode"].ToString();
                        }
                        objStudentClassTimes oStudentClassTimes = new objStudentClassTimes();
                        clsStudentClassTimes times2 = new clsStudentClassTimes();
                        oStudentClassTimes.LocationCode = variable.LocationCode;
                        oStudentClassTimes.ClassCode = table4.Rows[j]["fldClassCode"].ToString();
                        oStudentClassTimes.StudentNo = table4.Rows[j]["fldStudentNo"].ToString();
                        oStudentClassTimes.ClassTimeCode = newClassTimeCode;
                        times2.InsertUpdateStudentClassTimes(oStudentClassTimes);
                    }
                }
            }
        }

        private void InitializeComponent()
        {
            base.SuspendLayout();
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x11c, 0x106);
            base.Name = "frmDatabaseUpdate";
            this.Text = "frmDatabaseUpdate";
            base.Load += new EventHandler(this.frmDatabaseUpdate_Load);
            base.ResumeLayout(false);
        }
    }
}

