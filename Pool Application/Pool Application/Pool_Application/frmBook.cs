namespace Pool_Application
{
    using AxMSHierarchicalFlexGridLib;
    using AxMSFlexGridLib;
    using Business_Layer;
    using Database_Layer;
    using JTG;
    using MSHierarchicalFlexGridLib;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;

    public class frmBook : Form
    {
        private int AvailableCoverUps = 0;
        private AxMSHFlexGrid axMSHFlexGrid1;
        private Button button1;
        private clsAttendanceProcess cAttendanceProcess = new clsAttendanceProcess();
        private clsClassMaster cClassMaster = new clsClassMaster();
        private clsClassTimeTable cClassTimeTable = new clsClassTimeTable();
        private clsCommenMethods cCommenMethods = new clsCommenMethods();
        private clsConfirmStudentAttendance cConfirmStudentAttendance = new clsConfirmStudentAttendance();
        private clsGlobleVariable cGlobleVariable = new clsGlobleVariable();
        private clsInvoice cInvoice = new clsInvoice();
        private clsLeavalChangeClassTime cLeavalChangeClassTime = new clsLeavalChangeClassTime();
        private ColumnComboBox cmbClassName;
        private ColumnComboBox cmbClassTime;
        private ComboBox cmbDay;
        private ComboBox cmbMonth;
        private ComboBox cmbYear;
        private IContainer components = null;
        private clsStudentClassTimes cStudentClassTimes = new clsStudentClassTimes();
        private clsStudentMaster cStudentMaster = new clsStudentMaster();
        private clsStudentPromotion cStudentPromotion = new clsStudentPromotion();
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private clsDBConnect dbconnect = new clsDBConnect();
        private Label label1;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label label14;
        private Label label15;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private string sStudentId;
        private string strCoverupStudents = "";
        private string strWeekEndDate = "";
        private string strWeekStartDate = "";
        private int WeekSelectedIndex = 0;

        public frmBook()
        {
            this.InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.FillBook();
        }

        private void cmbClassName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbDay.SelectedIndex > 0)
            {
                DataTable dtFillData = this.cClassTimeTable.GetClassTimeDetails(this.cGlobleVariable.LocationCode, this.cmbClassName["fldClassCode"].ToString(), this.cmbDay.Text, "A");
                int[] viewColumn = new int[] { 4, 5, 6 };
                this.cCommenMethods.LoadComboViewMultyColunm(dtFillData, this.cmbClassTime, viewColumn);
                this.axMSHFlexGrid1.Rows = 0;
            }
        }

        private void cmbClassTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.axMSHFlexGrid1.Rows = 0;
        }

        private void cmbDay_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dtFillData = this.cClassTimeTable.GetClassTimeDetails(this.cGlobleVariable.LocationCode, this.cmbClassName["fldClassCode"].ToString(), this.cmbDay.Text, "A");
            int[] viewColumn = new int[] { 4, 5, 6 };
            this.cCommenMethods.LoadComboViewMultyColunm(dtFillData, this.cmbClassTime, viewColumn);
            this.axMSHFlexGrid1.Rows = 0;
        }

        private void cmbMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.axMSHFlexGrid1.Rows = 0;
        }

        private void cmbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.axMSHFlexGrid1.Rows = 0;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void FillBook()
        {
            DateTime time = Convert.ToDateTime(this.cmbYear.Text + "-" + this.cmbMonth.Text + "-" + Convert.ToDateTime(this.cmbYear.Text + "-" + this.cmbMonth.Text + " - 01").AddMonths(1).AddDays(-1.0).ToString("dd"));
            if (this.cmbClassName.SelectedIndex < 0)
            {
                MessageBox.Show("Please select level.", "Pool System", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else if (this.cmbYear.SelectedIndex < 0)
            {
                MessageBox.Show("Please select year.", "Pool System", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else if (this.cmbMonth.SelectedIndex < 0)
            {
                MessageBox.Show("Please select month.", "Pool System", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else if (this.cmbDay.SelectedIndex < 0)
            {
                MessageBox.Show("Please select day.", "Pool System", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                int num2;
                DataTable table2;
                this.axMSHFlexGrid1.set_Cols(12);
                this.axMSHFlexGrid1.Rows = 0;
                this.axMSHFlexGrid1.set_RowHeight(this.axMSHFlexGrid1.Rows - 1, 100);
                this.axMSHFlexGrid1.set_ColWidth(0, 400);
                this.axMSHFlexGrid1.set_ColWidth(2, 0x5dc);
                this.axMSHFlexGrid1.set_ColWidth(3, 0x5dc);
                this.axMSHFlexGrid1.set_ColWidth(4, 0x834);
                this.axMSHFlexGrid1.set_ColWidth(5, 0x44c);
                this.axMSHFlexGrid1.set_ColWidth(6, 0x44c);
                this.axMSHFlexGrid1.set_ColWidth(7, 600);
                this.axMSHFlexGrid1.set_ColWidth(8, 600);
                this.axMSHFlexGrid1.set_ColWidth(9, 600);
                this.axMSHFlexGrid1.set_ColWidth(10, 600);
                this.axMSHFlexGrid1.set_ColWidth(11, 0x9c4);
                string textMatrix = "Student Number and Name";
                this.axMSHFlexGrid1.Rows++;
                this.axMSHFlexGrid1.set_RowHeight(this.axMSHFlexGrid1.Rows - 1, 300);
                for (int i = 0; i < this.axMSHFlexGrid1.get_Cols(); i++)
                {
                    this.axMSHFlexGrid1.Row = this.axMSHFlexGrid1.Rows - 1;
                    this.axMSHFlexGrid1.Col = i;
                    this.axMSHFlexGrid1.CellBackColor = Color.DarkGray;
                }
                this.axMSHFlexGrid1.set_ColAlignment(4);
                this.axMSHFlexGrid1.set_ColAlignment(2, 1);
                this.axMSHFlexGrid1.set_TextMatrix(this.axMSHFlexGrid1.Rows - 1, 1, textMatrix);
                this.axMSHFlexGrid1.set_TextMatrix(this.axMSHFlexGrid1.Rows - 1, 2, textMatrix);
                this.axMSHFlexGrid1.set_TextMatrix(this.axMSHFlexGrid1.Rows - 1, 3, "Join Date To Level");
                this.axMSHFlexGrid1.set_TextMatrix(this.axMSHFlexGrid1.Rows - 1, 4, "Level");
                this.axMSHFlexGrid1.set_TextMatrix(this.axMSHFlexGrid1.Rows - 1, 5, "Receipt No");
                this.axMSHFlexGrid1.set_TextMatrix(this.axMSHFlexGrid1.Rows - 1, 6, "Last Payment");
                this.axMSHFlexGrid1.MergeCells = MergeCellsSettings.flexMergeRestrictRows;
                this.axMSHFlexGrid1.set_MergeRow(this.axMSHFlexGrid1.Rows - 1, true);
                DateTime time2 = Convert.ToDateTime(this.cmbMonth.Text + "/01/" + this.cmbYear.Text);
                DateTime time3 = time2.AddMonths(1).AddDays(-1.0);
                int num4 = 5;
                for (int j = 1; j <= time3.Day; j++)
                {
                    if (time2.DayOfWeek.ToString() == this.cmbDay.Text)
                    {
                        num4++;
                        this.axMSHFlexGrid1.set_TextMatrix(this.axMSHFlexGrid1.Rows - 1, num4 + 1, time2.Day.ToString());
                    }
                    time2 = time2.AddDays(1.0);
                }
                DataTable table = this.cStudentClassTimes.GetAllStudentInClass(this.cGlobleVariable.LocationCode, this.cmbClassName["fldClassCode"].ToString(), this.cmbClassTime["fldClassTimeCode"].ToString());
                for (int k = 0; k < table.Rows.Count; k++)
                {
                    int num7 = Convert.ToInt32(this.axMSHFlexGrid1.Col.ToString());
                    bool flag = false;
                    bool flag2 = false;
                    bool flag3 = false;
                    string str3 = table.Rows[k]["fldStudentNo"].ToString();
                    string str4 = Convert.ToString((int) (k + 1));
                    this.axMSHFlexGrid1.Rows++;
                    this.axMSHFlexGrid1.set_RowHeight(this.axMSHFlexGrid1.Rows - 1, 300);
                    this.axMSHFlexGrid1.set_TextMatrix(this.axMSHFlexGrid1.Rows - 1, 0, str4);
                    this.axMSHFlexGrid1.set_TextMatrix(this.axMSHFlexGrid1.Rows - 1, 1, str3);
                    table2 = this.cStudentMaster.GetStudentDetailsNonCancel(this.cGlobleVariable.LocationCode, str3, "C");
                    if (table2.Rows.Count > 0)
                    {
                        DateTime time4 = Convert.ToDateTime(table2.Rows[0]["fldDateOfJoin"].ToString());
                        this.axMSHFlexGrid1.set_TextMatrix(this.axMSHFlexGrid1.Rows - 1, 2, table2.Rows[0]["fldNameInFullL1"].ToString());
                        this.axMSHFlexGrid1.set_TextMatrix(this.axMSHFlexGrid1.Rows - 1, 3, time4.ToString("yyyy-MM-dd"));
                        if (Convert.ToString(table2.Rows[0]["fldStatus"].ToString()) == "R")
                        {
                            flag2 = true;
                        }
                        this.axMSHFlexGrid1.Col = 4;
                        this.axMSHFlexGrid1.Row = this.axMSHFlexGrid1.Rows - 1;
                        this.axMSHFlexGrid1.CellForeColor = Color.Red;
                        string str5 = Convert.ToString(table2.Rows[0]["fldRemarks"]);
                        this.axMSHFlexGrid1.set_TextMatrix(this.axMSHFlexGrid1.Rows - 1, 4, str5);
                    }
                    string str6 = Convert.ToDateTime(this.cmbYear.SelectedItem.ToString() + "-" + this.cmbMonth.SelectedItem.ToString() + "-01").ToString("yyyy-MM-dd");
                    string str7 = Convert.ToDateTime(str6).AddMonths(1).AddDays(-1.0).ToString("yyyy-MM-dd");
                    string str8 = "fldLocationCode ='" + this.cGlobleVariable.LocationCode + "' AND fldStudentNo ='" + str3 + "' AND fldClassCode ='" + this.cmbClassName["fldClassCode"].ToString() + "' AND fldPromotedDate BETWEEN '" + str6 + "' AND '" + str7 + "'";
                    if (this.dbconnect.SearchData("tbl_leval_changed_details", str8).Rows.Count > 0)
                    {
                        flag = true;
                    }
                    DataTable lastInvoiceDetails = this.cInvoice.GetLastInvoiceDetails(this.cGlobleVariable.LocationCode, str3);
                    if (lastInvoiceDetails.Rows.Count > 0)
                    {
                        this.axMSHFlexGrid1.set_TextMatrix(this.axMSHFlexGrid1.Rows - 1, 5, lastInvoiceDetails.Rows[0]["fldInvoiceNo"].ToString());
                        this.axMSHFlexGrid1.set_TextMatrix(this.axMSHFlexGrid1.Rows - 1, 6, Convert.ToDateTime(lastInvoiceDetails.Rows[0]["fldPaymentToDate"].ToString()).ToString("yyyy-MMM"));
                    }
                    else
                    {
                        this.axMSHFlexGrid1.set_TextMatrix(this.axMSHFlexGrid1.Rows - 1, 5, "N/A");
                        this.axMSHFlexGrid1.set_TextMatrix(this.axMSHFlexGrid1.Rows - 1, 6, "N/A");
                    }
                    for (int n = 7; n < this.axMSHFlexGrid1.get_Cols(); n++)
                    {
                        if (this.axMSHFlexGrid1.get_TextMatrix(0, n) != string.Empty)
                        {
                            if (this.cAttendanceProcess.EmployeeIsexist(this.cGlobleVariable.LocationCode, this.axMSHFlexGrid1.get_TextMatrix(this.axMSHFlexGrid1.Rows - 1, 1), Convert.ToDateTime(this.cmbMonth.Text + "/" + this.axMSHFlexGrid1.get_TextMatrix(0, n) + "/" + this.cmbYear.Text)))
                            {
                                this.axMSHFlexGrid1.set_TextMatrix(this.axMSHFlexGrid1.Rows - 1, n, Convert.ToChar(0xfe).ToString());
                                this.axMSHFlexGrid1.Col = n;
                                this.axMSHFlexGrid1.Row = this.axMSHFlexGrid1.Rows - 1;
                                this.axMSHFlexGrid1.CellFontName = "Wingdings";
                                this.axMSHFlexGrid1.CellFontSize = 13f;
                            }
                            else
                            {
                                DataTable table5 = this.cConfirmStudentAttendance.GetConfirnAttDetails(this.cGlobleVariable.LocationCode, this.axMSHFlexGrid1.get_TextMatrix(this.axMSHFlexGrid1.Rows - 1, 1), Convert.ToDateTime(this.cmbMonth.Text + "/" + this.axMSHFlexGrid1.get_TextMatrix(0, n) + "/" + this.cmbYear.Text));
                                if (table5.Rows.Count > 0)
                                {
                                    if (this.cAttendanceProcess.EmployeeIsexist(this.cGlobleVariable.LocationCode, this.axMSHFlexGrid1.get_TextMatrix(this.axMSHFlexGrid1.Rows - 1, 1), Convert.ToDateTime(table5.Rows[0]["fldAttendanceDate"].ToString())))
                                    {
                                        this.axMSHFlexGrid1.set_TextMatrix(this.axMSHFlexGrid1.Rows - 1, n, Convert.ToDateTime(table5.Rows[0]["fldAttendanceDate"].ToString()).ToString("MM/dd"));
                                    }
                                    else
                                    {
                                        this.axMSHFlexGrid1.set_TextMatrix(this.axMSHFlexGrid1.Rows - 1, n, Convert.ToChar(0xfd).ToString());
                                        this.axMSHFlexGrid1.Col = n;
                                        this.axMSHFlexGrid1.Row = this.axMSHFlexGrid1.Rows - 1;
                                        this.axMSHFlexGrid1.CellFontName = "Wingdings";
                                        this.axMSHFlexGrid1.CellFontSize = 13f;
                                    }
                                }
                                else
                                {
                                    this.axMSHFlexGrid1.set_TextMatrix(this.axMSHFlexGrid1.Rows - 1, n, Convert.ToChar(0xfd).ToString());
                                    this.axMSHFlexGrid1.Col = n;
                                    this.axMSHFlexGrid1.Row = this.axMSHFlexGrid1.Rows - 1;
                                    this.axMSHFlexGrid1.CellFontName = "Wingdings";
                                    this.axMSHFlexGrid1.CellFontSize = 13f;
                                }
                            }
                        }
                    }
                    DataTable table6 = this.cStudentPromotion.GetPromotion(str3, time2.ToString("yyyy-MM-dd"), Convert.ToDateTime(this.cmbMonth.Text + "/01/" + this.cmbYear.Text).AddDays(30.0).ToString("yyyy-MM-dd"), this.cmbClassName["fldClassCode"].ToString());
                    string str9 = "";
                    if ((table6.Rows.Count > 0) && (table6.Rows[0]["fldCurrentClassCode"].ToString() != table6.Rows[0]["fldPromotedClassCode"].ToString()))
                    {
                        str9 = "Student >>" + this.cClassMaster.GetClassData(this.cGlobleVariable.LocationCode, table6.Rows[0]["fldPromotedClassCode"].ToString()).ClassName;
                        this.axMSHFlexGrid1.set_TextMatrix(this.axMSHFlexGrid1.Rows - 1, 11, str9);
                        flag3 = true;
                    }
                    if (flag)
                    {
                        num2 = 0;
                        while (num2 < 12)
                        {
                            if (this.axMSHFlexGrid1.CellBackColor == Color.Green)
                            {
                                num2 = 5;
                            }
                            this.axMSHFlexGrid1.Col = num2;
                            this.axMSHFlexGrid1.Row = this.axMSHFlexGrid1.Rows - 1;
                            this.axMSHFlexGrid1.CellBackColor = Color.Orange;
                            num2++;
                        }
                    }
                    if (flag2)
                    {
                        num2 = 0;
                        while (num2 < 12)
                        {
                            this.axMSHFlexGrid1.Col = num2;
                            this.axMSHFlexGrid1.Row = this.axMSHFlexGrid1.Rows - 1;
                            this.axMSHFlexGrid1.CellBackColor = Color.SkyBlue;
                            num2++;
                        }
                    }
                    if (flag3)
                    {
                        num2 = 0;
                        while (num2 < 12)
                        {
                            this.axMSHFlexGrid1.Col = num2;
                            this.axMSHFlexGrid1.Row = this.axMSHFlexGrid1.Rows - 1;
                            this.axMSHFlexGrid1.CellBackColor = Color.Yellow;
                            num2++;
                        }
                    }
                }
                string strStartDate = time2.ToString("yyyy-MM-dd");
                DataTable table7 = this.cStudentPromotion.GetPromotedStudents(strStartDate, time2.AddDays(30.0).ToString("yyyy-MM-dd"), this.cmbClassName["fldClassCode"].ToString());
                for (int m = 0; m < table7.Rows.Count; m++)
                {
                    DataTable table8 = this.cStudentPromotion.GetPromotedClassTimes(this.cGlobleVariable.LocationCode, table7.Rows[m]["fldPromoID"].ToString(), this.cmbClassName["fldClassCode"].ToString(), this.cmbClassTime["fldClassTimeCode"].ToString());
                    for (int num10 = 0; num10 < table8.Rows.Count; num10++)
                    {
                        string str10 = table8.Rows[num10]["fldStudentNo"].ToString();
                        this.axMSHFlexGrid1.Rows++;
                        this.axMSHFlexGrid1.set_TextMatrix(this.axMSHFlexGrid1.Rows - 1, 0, this.axMSHFlexGrid1.Rows.ToString());
                        this.axMSHFlexGrid1.set_TextMatrix(this.axMSHFlexGrid1.Rows - 1, 1, str10);
                        table2 = this.cStudentMaster.GetStudentDetailsNonCancel(this.cGlobleVariable.LocationCode, str10, "C");
                        string str11 = "";
                        if (table2.Rows.Count > 0)
                        {
                            str11 = table2.Rows[0]["fldNameInFullL1"].ToString();
                        }
                        str11 = str11 + " will promote from level " + this.cClassMaster.GetClassData(this.cGlobleVariable.LocationCode, table7.Rows[m]["fldCurrentClassCode"].ToString()).ClassName;
                        this.axMSHFlexGrid1.set_TextMatrix(this.axMSHFlexGrid1.Rows - 1, 2, str11);
                        this.axMSHFlexGrid1.set_TextMatrix(this.axMSHFlexGrid1.Rows - 1, 3, str11);
                        this.axMSHFlexGrid1.set_TextMatrix(this.axMSHFlexGrid1.Rows - 1, 4, str11);
                        this.axMSHFlexGrid1.set_TextMatrix(this.axMSHFlexGrid1.Rows - 1, 5, str11);
                        this.axMSHFlexGrid1.set_TextMatrix(this.axMSHFlexGrid1.Rows - 1, 6, str11);
                        this.axMSHFlexGrid1.set_MergeRow(this.axMSHFlexGrid1.Rows - 1, true);
                        for (num2 = 0; num2 < 12; num2++)
                        {
                            this.axMSHFlexGrid1.Col = num2;
                            this.axMSHFlexGrid1.Row = this.axMSHFlexGrid1.Rows - 1;
                            this.axMSHFlexGrid1.CellBackColor = Color.Yellow;
                        }
                    }
                }
            }
        }

        private void frmBook_Load(object sender, EventArgs e)
        {
            DataTable classDetails = this.cClassMaster.GetClassDetails(this.cGlobleVariable.LocationCode, this.cGlobleVariable.ActiveStatusCode);
            this.cCommenMethods.LoadCombo(classDetails, this.cmbClassName, 3);
            this.cmbClassName.SelectedIndex = 0;
            this.cmbDay.Items.Add(Day.Monday.ToString());
            this.cmbDay.Items.Add(Day.Tuesday.ToString());
            this.cmbDay.Items.Add(Day.Wednesday.ToString());
            this.cmbDay.Items.Add(Day.Thursday.ToString());
            this.cmbDay.Items.Add(Day.Friday.ToString());
            this.cmbDay.Items.Add(Day.Saturday.ToString());
            this.cmbDay.Items.Add(Day.Sunday.ToString());
            string str = DateTime.Now.DayOfWeek.ToString();
            this.cmbDay.Text = str;
            int year = DateTime.Now.Year;
            for (int i = year - 10; i < (year + 10); i++)
            {
                this.cmbYear.Items.Add(i.ToString());
            }
            this.cmbYear.Text = year.ToString();
            for (int j = 0; j < 12; j++)
            {
                DateTime time = Convert.ToDateTime("2010/January/01");
                this.cmbMonth.Items.Add(time.AddMonths(j).ToString("MMMM"));
            }
            this.cmbMonth.Text = DateTime.Now.ToString("MMMM");
        }

        private void InitializeComponent()
        {
            ComponentResourceManager manager = new ComponentResourceManager(typeof(frmBook));
            this.cmbDay = new ComboBox();
            this.axMSHFlexGrid1 = new AxMSHFlexGrid();
            this.label1 = new Label();
            this.label2 = new Label();
            this.cmbYear = new ComboBox();
            this.cmbMonth = new ComboBox();
            this.label3 = new Label();
            this.label4 = new Label();
            this.button1 = new Button();
            this.label6 = new Label();
            this.label7 = new Label();
            this.label8 = new Label();
            this.label9 = new Label();
            this.label10 = new Label();
            this.label11 = new Label();
            this.label12 = new Label();
            this.label13 = new Label();
            this.label5 = new Label();
            this.label14 = new Label();
            this.label15 = new Label();
            this.cmbClassTime = new ColumnComboBox();
            this.cmbClassName = new ColumnComboBox();
            this.dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
            this.axMSHFlexGrid1.BeginInit();
            base.SuspendLayout();
            this.cmbDay.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbDay.FormattingEnabled = true;
            this.cmbDay.Location = new Point(410, 0x24);
            this.cmbDay.Name = "cmbDay";
            this.cmbDay.Size = new Size(0x6a, 0x15);
            this.cmbDay.TabIndex = 0xd1;
            this.cmbDay.SelectedIndexChanged += new EventHandler(this.cmbDay_SelectedIndexChanged);
            this.axMSHFlexGrid1.Location = new Point(0x13, 0x3e);
            this.axMSHFlexGrid1.Name = "axMSHFlexGrid1";
            this.axMSHFlexGrid1.OcxState = (AxHost.State) manager.GetObject("axMSHFlexGrid1.OcxState");
            this.axMSHFlexGrid1.Size = new Size(0x3b3, 0x17e);
            this.axMSHFlexGrid1.TabIndex = 0xd4;
            this.label1.AutoSize = true;
            this.label1.Location = new Point(12, 0x13);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x21, 13);
            this.label1.TabIndex = 0xd5;
            this.label1.Text = "Level";
            this.label2.AutoSize = true;
            this.label2.Location = new Point(0x197, 20);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x1a, 13);
            this.label2.TabIndex = 0xd6;
            this.label2.Text = "Day";
            this.cmbYear.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbYear.FormattingEnabled = true;
            this.cmbYear.Location = new Point(0xbc, 0x23);
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.Size = new Size(0x61, 0x15);
            this.cmbYear.TabIndex = 0xd7;
            this.cmbYear.SelectedIndexChanged += new EventHandler(this.cmbYear_SelectedIndexChanged);
            this.cmbMonth.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbMonth.FormattingEnabled = true;
            this.cmbMonth.Location = new Point(0x123, 0x23);
            this.cmbMonth.Name = "cmbMonth";
            this.cmbMonth.Size = new Size(0x71, 0x15);
            this.cmbMonth.TabIndex = 0xd8;
            this.cmbMonth.SelectedIndexChanged += new EventHandler(this.cmbMonth_SelectedIndexChanged);
            this.label3.AutoSize = true;
            this.label3.Location = new Point(0xb9, 0x13);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x1d, 13);
            this.label3.TabIndex = 0xd9;
            this.label3.Text = "Year";
            this.label4.AutoSize = true;
            this.label4.Location = new Point(0x120, 0x13);
            this.label4.Name = "label4";
            this.label4.Size = new Size(0x25, 13);
            this.label4.TabIndex = 0xda;
            this.label4.Text = "Month";
            this.button1.Location = new Point(0x30e, 0x1f);
            this.button1.Name = "button1";
            this.button1.Size = new Size(0x4f, 0x1a);
            this.button1.TabIndex = 0xdd;
            this.button1.Text = "Re-load";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new EventHandler(this.button1_Click);
            this.label6.BackColor = Color.Green;
            this.label6.Location = new Point(0x10, 0x1bf);
            this.label6.Name = "label6";
            this.label6.Size = new Size(0x1d, 0x15);
            this.label6.TabIndex = 0xde;
            this.label7.AutoSize = true;
            this.label7.Location = new Point(0x30, 0x1c3);
            this.label7.Name = "label7";
            this.label7.Size = new Size(0x9b, 13);
            this.label7.TabIndex = 0xdf;
            this.label7.Text = "Non paid students in last month";
            this.label8.AutoSize = true;
            this.label8.Location = new Point(0x30, 0x1da);
            this.label8.Name = "label8";
            this.label8.Size = new Size(0x74, 13);
            this.label8.TabIndex = 0xe1;
            this.label8.Text = "Level changed student";
            this.label9.BackColor = Color.Orange;
            this.label9.Location = new Point(0x10, 470);
            this.label9.Name = "label9";
            this.label9.Size = new Size(0x1d, 0x15);
            this.label9.TabIndex = 0xe0;
            this.label10.AutoSize = true;
            this.label10.Location = new Point(0x30, 0x1f3);
            this.label10.Name = "label10";
            this.label10.Size = new Size(0x53, 13);
            this.label10.TabIndex = 0xe3;
            this.label10.Text = "Re-join students";
            this.label11.BackColor = Color.SkyBlue;
            this.label11.Location = new Point(0x10, 0x1ef);
            this.label11.Name = "label11";
            this.label11.Size = new Size(0x1d, 0x15);
            this.label11.TabIndex = 0xe2;
            this.label12.AutoSize = true;
            this.label12.Location = new Point(0x120, 0x1c3);
            this.label12.Name = "label12";
            this.label12.Size = new Size(0xad, 13);
            this.label12.TabIndex = 0xe5;
            this.label12.Text = "New student (Joined on this month)";
            this.label13.BackColor = Color.Pink;
            this.label13.Location = new Point(0x100, 0x1bf);
            this.label13.Name = "label13";
            this.label13.Size = new Size(0x1d, 0x15);
            this.label13.TabIndex = 0xe4;
            this.label5.AutoSize = true;
            this.label5.Location = new Point(0x207, 0x13);
            this.label5.Name = "label5";
            this.label5.Size = new Size(0x3a, 13);
            this.label5.TabIndex = 0xe7;
            this.label5.Text = "Class Time";
            this.label14.AutoSize = true;
            this.label14.Location = new Point(0x120, 0x1de);
            this.label14.Name = "label14";
            this.label14.Size = new Size(0x54, 13);
            this.label14.TabIndex = 0xea;
            this.label14.Text = "Promote student";
            this.label15.BackColor = Color.Yellow;
            this.label15.Location = new Point(0x100, 0x1da);
            this.label15.Name = "label15";
            this.label15.Size = new Size(0x1d, 0x15);
            this.label15.TabIndex = 0xe9;
            this.cmbClassTime.DrawMode = DrawMode.OwnerDrawVariable;
            this.cmbClassTime.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbClassTime.DropDownWidth = 0x11;
            this.cmbClassTime.FormattingEnabled = true;
            this.cmbClassTime.Location = new Point(0x20a, 0x24);
            this.cmbClassTime.Name = "cmbClassTime";
            this.cmbClassTime.Size = new Size(0xfe, 0x15);
            this.cmbClassTime.TabIndex = 0xe8;
            this.cmbClassTime.ViewColumn = 0;
            this.cmbClassTime.SelectedIndexChanged += new EventHandler(this.cmbClassTime_SelectedIndexChanged);
            this.cmbClassName.DrawMode = DrawMode.OwnerDrawVariable;
            this.cmbClassName.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbClassName.DropDownWidth = 0x11;
            this.cmbClassName.FormattingEnabled = true;
            this.cmbClassName.Location = new Point(15, 0x23);
            this.cmbClassName.Name = "cmbClassName";
            this.cmbClassName.Size = new Size(0xa7, 0x15);
            this.cmbClassName.TabIndex = 0xd0;
            this.cmbClassName.ViewColumn = 0;
            this.cmbClassName.SelectedIndexChanged += new EventHandler(this.cmbClassName_SelectedIndexChanged);
            this.dataGridViewTextBoxColumn1.HeaderText = "Column1";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn2.HeaderText = "Column2";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn3.HeaderText = "Column3";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn4.HeaderText = "Column4";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn5.HeaderText = "Column5";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            base.ClientSize = new Size(0x3e0, 0x20a);
            base.Controls.Add(this.label14);
            base.Controls.Add(this.label15);
            base.Controls.Add(this.cmbClassTime);
            base.Controls.Add(this.label5);
            base.Controls.Add(this.label12);
            base.Controls.Add(this.label13);
            base.Controls.Add(this.label10);
            base.Controls.Add(this.label11);
            base.Controls.Add(this.label8);
            base.Controls.Add(this.label9);
            base.Controls.Add(this.label7);
            base.Controls.Add(this.label6);
            base.Controls.Add(this.button1);
            base.Controls.Add(this.label4);
            base.Controls.Add(this.label3);
            base.Controls.Add(this.cmbMonth);
            base.Controls.Add(this.cmbYear);
            base.Controls.Add(this.label2);
            base.Controls.Add(this.label1);
            base.Controls.Add(this.axMSHFlexGrid1);
            base.Controls.Add(this.cmbDay);
            base.Controls.Add(this.cmbClassName);
            base.Name = "frmBook";
            this.Text = "Student Details";
            base.Load += new EventHandler(this.frmBook_Load);
            this.axMSHFlexGrid1.EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }
    }
}

