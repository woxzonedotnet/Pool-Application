namespace Pool_Application
{
    using Business_Layer;
    using Business_Layer.Property_Layer;
    using JTG;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;

    public class frmUpdateCoachByLevel : Form
    {
        private Button btnExit;
        private Button btnProcess;
        private clsAuditLog cAuditLog = new clsAuditLog();
        private clsClassMaster cClassMaster = new clsClassMaster();
        private clsCoacherMaster cCoacherMaster = new clsCoacherMaster();
        private clsCommenMethods cCommanMethods = new clsCommenMethods();
        private clsDayTypes cDayTypes = new clsDayTypes();
        private clsGlobleVariable cGlobleVariable = new clsGlobleVariable();
        private ColumnComboBox cmbAssCoacherName;
        private ColumnComboBox cmbClassName;
        private ColumnComboBox cmbCoacherName;
        private ColumnComboBox cmdDay;
        private IContainer components = null;
        private clsUpdateCoachByLevel cUpdateCoachByLevel = new clsUpdateCoachByLevel();
        private DateTimePicker dtpDateOfJoin;
        private ErrorProvider errUpdateLeval;
        private Label label10;
        private Label label13;
        private Label label16;
        private Label label3;
        private Label label94;
        private objAuditLog oAuditLog = new objAuditLog();
        private objUpdateCoachByLevel oUpdateCoachByLevel = new objUpdateCoachByLevel();

        public frmUpdateCoachByLevel()
        {
            this.InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.oAuditLog.LocationCode = this.cGlobleVariable.LocationCode;
            this.oAuditLog.UserID = this.cGlobleVariable.CurrentUserID;
            this.oAuditLog.MachineID = clsGlobleVariable.MachineID;
            this.oAuditLog.DateEntered = Convert.ToDateTime(this.cAuditLog.getCurrentDate().Rows[0][0].ToString());
            this.oAuditLog.TimeEntered = Convert.ToDateTime(this.cAuditLog.getCurrentTime().Rows[0][0].ToString());
            this.oAuditLog.Task = "Exited Coacher Change By Level";
            this.cAuditLog.AuditLog(this.oAuditLog);
            base.Close();
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            if (this.ValidateData())
            {
                this.oUpdateCoachByLevel.LocationCode = this.cGlobleVariable.LocationCode;
                this.oUpdateCoachByLevel.ChangedLeval = this.cmbClassName["fldClassCode"].ToString();
                this.oUpdateCoachByLevel.CoacherCode = this.cmbCoacherName["fldCoacherCode"].ToString();
                this.oUpdateCoachByLevel.AssCoacherCode = this.cmbAssCoacherName["fldCoacherCode"].ToString();
                this.oUpdateCoachByLevel.DayType = this.cmdDay["fldDay"].ToString();
                this.oUpdateCoachByLevel.ChangedDate = this.dtpDateOfJoin.Value;
                this.cUpdateCoachByLevel.InsertUpdateData(this.oUpdateCoachByLevel);
                this.oAuditLog.LocationCode = this.cGlobleVariable.LocationCode;
                this.oAuditLog.UserID = this.cGlobleVariable.CurrentUserID;
                this.oAuditLog.MachineID = clsGlobleVariable.MachineID;
                this.oAuditLog.DateEntered = Convert.ToDateTime(this.cAuditLog.getCurrentDate().Rows[0][0].ToString());
                this.oAuditLog.TimeEntered = Convert.ToDateTime(this.cAuditLog.getCurrentTime().Rows[0][0].ToString());
                this.oAuditLog.Task = "Changed Class Level: " + this.cmbClassName["fldClassName"].ToString() + " Coacher To: " + this.cmbCoacherName["fldCoacherCode"].ToString() + " And Ass Coacher To: " + this.cmbAssCoacherName["fldCoacherCode"].ToString() + " For Day Type :" + this.cmdDay["fldDay"].ToString();
                this.cAuditLog.AuditLog(this.oAuditLog);
                MessageBox.Show(this.cGlobleVariable.SeavedMessage, "Caocher Change By Leval", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void frmUpdateCoachByLevel_Load(object sender, EventArgs e)
        {
            DataTable classDetails = this.cClassMaster.GetClassDetails(this.cGlobleVariable.LocationCode, this.cGlobleVariable.ActiveStatusCode);
            this.cCommanMethods.LoadCombo(classDetails, this.cmbClassName, 3);
            if (this.cmbClassName.Items.Count > 0)
            {
                this.cmbClassName.SelectedIndex = 0;
            }
            DataTable coacherData = this.cCoacherMaster.GetCoacherData(this.cGlobleVariable.LocationCode);
            this.cCommanMethods.LoadCombo(coacherData, this.cmbCoacherName, 4);
            if (this.cmbCoacherName.Items.Count > 0)
            {
                this.cmbCoacherName.SelectedIndex = 0;
            }
            this.cCommanMethods.LoadCombo(coacherData, this.cmbAssCoacherName, 4);
            if (this.cmbAssCoacherName.Items.Count > 0)
            {
                this.cmbAssCoacherName.SelectedIndex = 0;
            }
            DataTable dtFillData = this.cDayTypes.GetClassDetails();
            this.cCommanMethods.LoadCombo(dtFillData, this.cmdDay, 1);
            if (this.cmdDay.Items.Count > 0)
            {
                this.cmdDay.SelectedIndex = 1;
            }
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            ComponentResourceManager manager = new ComponentResourceManager(typeof(frmUpdateCoachByLevel));
            this.label13 = new Label();
            this.label10 = new Label();
            this.label16 = new Label();
            this.dtpDateOfJoin = new DateTimePicker();
            this.label94 = new Label();
            this.btnExit = new Button();
            this.btnProcess = new Button();
            this.errUpdateLeval = new ErrorProvider(this.components);
            this.cmbAssCoacherName = new ColumnComboBox();
            this.cmbCoacherName = new ColumnComboBox();
            this.cmbClassName = new ColumnComboBox();
            this.label3 = new Label();
            this.cmdDay = new ColumnComboBox();
            ((ISupportInitialize) this.errUpdateLeval).BeginInit();
            base.SuspendLayout();
            this.label13.AutoSize = true;
            this.label13.Location = new Point(8, 15);
            this.label13.Name = "label13";
            this.label13.Size = new Size(0x21, 13);
            this.label13.TabIndex = 0xc0;
            this.label13.Text = "Level";
            this.label10.AutoSize = true;
            this.label10.Location = new Point(10, 0x72);
            this.label10.Name = "label10";
            this.label10.Size = new Size(0x43, 13);
            this.label10.TabIndex = 0xc6;
            this.label10.Text = "Ass Coacher";
            this.label16.AutoSize = true;
            this.label16.Location = new Point(8, 0x58);
            this.label16.Name = "label16";
            this.label16.Size = new Size(0x2f, 13);
            this.label16.TabIndex = 0xc5;
            this.label16.Text = "Coacher";
            this.dtpDateOfJoin.Format = DateTimePickerFormat.Short;
            this.dtpDateOfJoin.Location = new Point(0x79, 0x3e);
            this.dtpDateOfJoin.Name = "dtpDateOfJoin";
            this.dtpDateOfJoin.Size = new Size(0x66, 20);
            this.dtpDateOfJoin.TabIndex = 0xc1;
            this.label94.AutoSize = true;
            this.label94.Location = new Point(8, 0x42);
            this.label94.Name = "label94";
            this.label94.Size = new Size(0x5e, 13);
            this.label94.TabIndex = 0xc4;
            this.label94.Text = "Date of Changed :";
            this.btnExit.Location = new Point(0xef, 0x95);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new Size(0x4b, 0x17);
            this.btnExit.TabIndex = 200;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new EventHandler(this.btnExit_Click);
            this.btnProcess.Location = new Point(0xa2, 0x95);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new Size(0x47, 0x17);
            this.btnProcess.TabIndex = 0xc7;
            this.btnProcess.Text = "Process";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new EventHandler(this.btnProcess_Click);
            this.errUpdateLeval.ContainerControl = this;
            this.cmbAssCoacherName.DrawMode = DrawMode.OwnerDrawVariable;
            this.cmbAssCoacherName.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbAssCoacherName.DropDownWidth = 0x11;
            this.cmbAssCoacherName.FormattingEnabled = true;
            this.cmbAssCoacherName.Location = new Point(0x79, 0x6f);
            this.cmbAssCoacherName.Name = "cmbAssCoacherName";
            this.cmbAssCoacherName.Size = new Size(0xc1, 0x15);
            this.cmbAssCoacherName.TabIndex = 0xc3;
            this.cmbAssCoacherName.ViewColumn = 0;
            this.cmbCoacherName.DrawMode = DrawMode.OwnerDrawVariable;
            this.cmbCoacherName.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbCoacherName.DropDownWidth = 0x11;
            this.cmbCoacherName.FormattingEnabled = true;
            this.cmbCoacherName.Location = new Point(0x79, 0x56);
            this.cmbCoacherName.Name = "cmbCoacherName";
            this.cmbCoacherName.Size = new Size(0xc1, 0x15);
            this.cmbCoacherName.TabIndex = 0xc2;
            this.cmbCoacherName.ViewColumn = 0;
            this.cmbClassName.DrawMode = DrawMode.OwnerDrawVariable;
            this.cmbClassName.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbClassName.DropDownWidth = 0x11;
            this.cmbClassName.FormattingEnabled = true;
            this.cmbClassName.Location = new Point(0x79, 12);
            this.cmbClassName.Name = "cmbClassName";
            this.cmbClassName.Size = new Size(0xc1, 0x15);
            this.cmbClassName.TabIndex = 0xbf;
            this.cmbClassName.ViewColumn = 0;
            this.label3.AutoSize = true;
            this.label3.Location = new Point(8, 40);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x1a, 13);
            this.label3.TabIndex = 0xe0;
            this.label3.Text = "Day";
            this.cmdDay.DrawMode = DrawMode.OwnerDrawVariable;
            this.cmdDay.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmdDay.DropDownWidth = 0x11;
            this.cmdDay.FormattingEnabled = true;
            this.cmdDay.Location = new Point(0x79, 0x25);
            this.cmdDay.Name = "cmdDay";
            this.cmdDay.Size = new Size(0xbf, 0x15);
            this.cmdDay.TabIndex = 0xdf;
            this.cmdDay.ViewColumn = 0;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x144, 0xb2);
            base.Controls.Add(this.label3);
            base.Controls.Add(this.cmdDay);
            base.Controls.Add(this.btnExit);
            base.Controls.Add(this.btnProcess);
            base.Controls.Add(this.label10);
            base.Controls.Add(this.cmbAssCoacherName);
            base.Controls.Add(this.label16);
            base.Controls.Add(this.cmbCoacherName);
            base.Controls.Add(this.dtpDateOfJoin);
            base.Controls.Add(this.label94);
            base.Controls.Add(this.label13);
            base.Controls.Add(this.cmbClassName);
            base.Name = "frmUpdateCoachByLevel";
            this.Text = "Caocher Change By Leval";
            base.Load += new EventHandler(this.frmUpdateCoachByLevel_Load);
            ((ISupportInitialize) this.errUpdateLeval).EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        private bool ValidateData()
        {
            bool flag = true;
            if (this.cmbClassName.SelectedIndex < 0)
            {
                this.errUpdateLeval.SetError(this.cmbClassName, "Please select the Class");
                flag = false;
            }
            else
            {
                this.errUpdateLeval.SetError(this.cmbClassName, "");
            }
            if (this.cmbCoacherName.SelectedIndex < 0)
            {
                this.errUpdateLeval.SetError(this.cmbCoacherName, "Please select the Coacher");
                flag = false;
            }
            else
            {
                this.errUpdateLeval.SetError(this.cmbCoacherName, "");
            }
            if (this.cmbAssCoacherName.SelectedIndex < 0)
            {
                this.errUpdateLeval.SetError(this.cmbAssCoacherName, "Please select the Ass. Coacher");
                return false;
            }
            this.errUpdateLeval.SetError(this.cmbAssCoacherName, "");
            return flag;
        }
    }
}

