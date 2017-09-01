namespace Pool_Application
{
    using Business_Layer;
    using Business_Layer.Property_Layer;
    using Report_Layer;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class frmDuePayStudent : Form
    {
        private Button btnExit;
        private Button btnProcess;
        private clsDuePayStudent cDuePayStudent = new clsDuePayStudent();
        private clsGlobleVariable cGlobleVariable = new clsGlobleVariable();
        private IContainer components = null;
        private DateTimePicker dtpFromDate;
        private Label lblFromDate;
        private objDuePayStudent oDuePayStudent = new objDuePayStudent();

        public frmDuePayStudent()
        {
            this.InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            this.oDuePayStudent.LocationCode = this.cGlobleVariable.LocationCode;
            this.oDuePayStudent.ProcessDate = this.dtpFromDate.Value;
            this.oDuePayStudent.Status = this.cGlobleVariable.ActiveStatusCode;
            this.cDuePayStudent.PayDueProcess(this.oDuePayStudent);
            MessageBox.Show("Successfully Completed", "Attendance Process", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            this.ReportViwer();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dtpFromDate = new DateTimePicker();
            this.lblFromDate = new Label();
            this.btnProcess = new Button();
            this.btnExit = new Button();
            base.SuspendLayout();
            this.dtpFromDate.Format = DateTimePickerFormat.Short;
            this.dtpFromDate.Location = new Point(0x42, 8);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new Size(0x54, 20);
            this.dtpFromDate.TabIndex = 0x17;
            this.lblFromDate.AutoSize = true;
            this.lblFromDate.Location = new Point(9, 12);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new Size(30, 13);
            this.lblFromDate.TabIndex = 0x16;
            this.lblFromDate.Text = "Date";
            this.btnProcess.Location = new Point(0x8d, 0x34);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new Size(0x47, 0x17);
            this.btnProcess.TabIndex = 0x1a;
            this.btnProcess.Text = "&Process";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new EventHandler(this.btnProcess_Click);
            this.btnExit.Location = new Point(0xda, 0x34);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new Size(0x4b, 0x17);
            this.btnExit.TabIndex = 0x20;
            this.btnExit.Text = "E&xit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new EventHandler(this.btnExit_Click);
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x131, 0x57);
            base.Controls.Add(this.btnExit);
            base.Controls.Add(this.btnProcess);
            base.Controls.Add(this.dtpFromDate);
            base.Controls.Add(this.lblFromDate);
            base.Name = "frmDuePayStudent";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Pool Attendance System";
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        private void ReportViwer()
        {
            string strReportName = "rptDuePayReport.rpt";
            object[,] arrParameter = new object[,] { { "strCompanyName", this.cGlobleVariable.CustomerName }, { "strCopyRight", this.cGlobleVariable.CopyRight }, { "strReportTitle", "Due Payment Report" }, { "dFromDate", this.dtpFromDate.Value }, { "strLocationCode", this.cGlobleVariable.LocationCode } };
            new frmReportViewer(strReportName, this.SelectionFormularValues(), arrParameter).Show();
        }

        private string SelectionFormularValues()
        {
            return "{tbl_student_master.fldLocationCode}={?strLocationCode}";
        }
    }
}

