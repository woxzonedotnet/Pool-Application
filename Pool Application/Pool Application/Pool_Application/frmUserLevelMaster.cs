namespace Pool_Application
{
    using Business_Layer;
    using Business_Layer.Property_Layer;
    using JTG;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class frmUserLevelMaster : Form
    {
        private Button btnDelete;
        private Button btnExit;
        private Button btnrefresh;
        private Button btnSave;
        private Button btnUpdate;
        private Button btnView;
        private clsAuditLog cAuditLog = new clsAuditLog();
        private clsCommenMethods ccommen = new clsCommenMethods();
        private clsGlobleVariable cglobe = new clsGlobleVariable();
        private ColumnComboBox cmbUserStatus;
        private IContainer components = null;
        private clsStatusMaster cstatusmaster = new clsStatusMaster();
        private clsUserLevel cuserlevel = new clsUserLevel();
        private ErrorProvider erroruserlevel;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private objAuditLog oAuditLog = new objAuditLog();
        private objUserLevel ouserlevel = new objUserLevel();
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private TextBox txtuserlevel;
        private TextBox txtUserLevelCode;

        public frmUserLevelMaster()
        {
            this.InitializeComponent();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do u want to delete this record? ", "User level details", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.cuserlevel.DeleteData(this.cglobe.LocationCode, this.txtUserLevelCode.Text);
                MessageBox.Show("Record deleted successfully.....!", "User level details", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.ccommen.ClearForm(this);
            }
            this.oAuditLog.LocationCode = this.cglobe.LocationCode;
            this.oAuditLog.MachineID = clsGlobleVariable.MachineID;
            this.oAuditLog.UserID = this.cglobe.CurrentUserID;
            this.oAuditLog.DateEntered = Convert.ToDateTime(this.cAuditLog.getCurrentDate().Rows[0][0].ToString());
            this.oAuditLog.TimeEntered = Convert.ToDateTime(this.cAuditLog.getCurrentTime().Rows[0][0].ToString());
            this.oAuditLog.Task = " user level code " + this.ouserlevel.UserLevelCode + clsGlobleVariable.DeleteData;
            this.cAuditLog.AuditLog(this.oAuditLog);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            base.Close();
            this.oAuditLog.LocationCode = this.cglobe.LocationCode;
            this.oAuditLog.MachineID = clsGlobleVariable.MachineID;
            this.oAuditLog.UserID = this.cglobe.CurrentUserID;
            this.oAuditLog.DateEntered = Convert.ToDateTime(this.cAuditLog.getCurrentDate().Rows[0][0].ToString());
            this.oAuditLog.TimeEntered = Convert.ToDateTime(this.cAuditLog.getCurrentTime().Rows[0][0].ToString());
            this.oAuditLog.Task = "Exited from User Level Master";
            this.cAuditLog.AuditLog(this.oAuditLog);
        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            this.ccommen.ClearForm(this);
            this.oAuditLog.LocationCode = this.cglobe.LocationCode;
            this.oAuditLog.MachineID = clsGlobleVariable.MachineID;
            this.oAuditLog.UserID = this.cglobe.CurrentUserID;
            this.oAuditLog.DateEntered = Convert.ToDateTime(this.cAuditLog.getCurrentDate().Rows[0][0].ToString());
            this.oAuditLog.TimeEntered = Convert.ToDateTime(this.cAuditLog.getCurrentTime().Rows[0][0].ToString());
            this.oAuditLog.Task = " user level code " + this.ouserlevel.UserLevelCode + clsGlobleVariable.RefreshData;
            this.cAuditLog.AuditLog(this.oAuditLog);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.validate_data())
            {
                this.ouserlevel = this.cuserlevel.GetUserLevelData(this.cglobe.LocationCode, this.txtUserLevelCode.Text);
                if (!this.ouserlevel.UserLevelIsExists)
                {
                    this.InsertUpdate();
                    MessageBox.Show("Successfully saved ........!", "User Level Details", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("Record alredy exisits....!", "User Level Details", MessageBoxButtons.OK);
                }
            }
            this.oAuditLog.LocationCode = this.cglobe.LocationCode;
            this.oAuditLog.MachineID = clsGlobleVariable.MachineID;
            this.oAuditLog.UserID = this.cglobe.CurrentUserID;
            this.oAuditLog.DateEntered = Convert.ToDateTime(this.cAuditLog.getCurrentDate().Rows[0][0].ToString());
            this.oAuditLog.TimeEntered = Convert.ToDateTime(this.cAuditLog.getCurrentTime().Rows[0][0].ToString());
            this.oAuditLog.Task = clsGlobleVariable.InsertData + " user level code " + this.ouserlevel.UserLevelCode;
            this.cAuditLog.AuditLog(this.oAuditLog);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (this.validate_data())
            {
                this.ouserlevel = this.cuserlevel.GetUserLevelData(this.cglobe.LocationCode, this.txtUserLevelCode.Text);
                if (this.ouserlevel.UserLevelIsExists)
                {
                    this.InsertUpdate();
                    MessageBox.Show("Successfully Updated......");
                }
                else
                {
                    MessageBox.Show("User Level Code cannot be found", "User Level Details", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            this.oAuditLog.LocationCode = this.cglobe.LocationCode;
            this.oAuditLog.MachineID = clsGlobleVariable.MachineID;
            this.oAuditLog.UserID = this.cglobe.CurrentUserID;
            this.oAuditLog.DateEntered = Convert.ToDateTime(this.cAuditLog.getCurrentDate().Rows[0][0].ToString());
            this.oAuditLog.TimeEntered = Convert.ToDateTime(this.cAuditLog.getCurrentTime().Rows[0][0].ToString());
            this.oAuditLog.Task = "user level code " + this.ouserlevel.UserLevelCode + clsGlobleVariable.UpdateData;
            this.cAuditLog.AuditLog(this.oAuditLog);
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            string[] strFieldList = new string[] { "fldUserLevelCode", "fldUserLevel" };
            string[] strHeadingList = new string[] { "User Level Code", "User Level" };
            int[] iHeaderWidth = new int[] { 150, 320 };
            string strReturnField = "User Level Code";
            string str2 = "fldLocationCode = '" + this.cglobe.LocationCode + "' ";
            this.txtUserLevelCode.Text = this.ccommen.BrowsData("tbl_User_Level_master", strFieldList, strHeadingList, iHeaderWidth, strReturnField, str2);
            this.LoadUserLevel();
            this.oAuditLog.LocationCode = this.cglobe.LocationCode;
            this.oAuditLog.MachineID = clsGlobleVariable.MachineID;
            this.oAuditLog.UserID = this.cglobe.CurrentUserID;
            this.oAuditLog.DateEntered = Convert.ToDateTime(this.cAuditLog.getCurrentDate().Rows[0][0].ToString());
            this.oAuditLog.TimeEntered = Convert.ToDateTime(this.cAuditLog.getCurrentTime().Rows[0][0].ToString());
            this.oAuditLog.Task = clsGlobleVariable.ViewData + " User level code " + this.ouserlevel.UserLevelCode;
            this.cAuditLog.AuditLog(this.oAuditLog);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void frmUserLevelMaster_Load(object sender, EventArgs e)
        {
            this.ccommen.LoadCombo(this.cstatusmaster.GetStatusDetails(), this.cmbUserStatus, 1);
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            ComponentResourceManager manager = new ComponentResourceManager(typeof(frmUserLevelMaster));
            this.panel1 = new Panel();
            this.label5 = new Label();
            this.label1 = new Label();
            this.panel2 = new Panel();
            this.txtuserlevel = new TextBox();
            this.cmbUserStatus = new ColumnComboBox();
            this.txtUserLevelCode = new TextBox();
            this.label4 = new Label();
            this.label3 = new Label();
            this.label2 = new Label();
            this.erroruserlevel = new ErrorProvider(this.components);
            this.panel3 = new Panel();
            this.btnView = new Button();
            this.btnSave = new Button();
            this.btnExit = new Button();
            this.btnrefresh = new Button();
            this.btnUpdate = new Button();
            this.btnDelete = new Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((ISupportInitialize) this.erroruserlevel).BeginInit();
            this.panel3.SuspendLayout();
            base.SuspendLayout();
            this.panel1.BackColor = Color.FromArgb(0xe0, 0xe0, 0xe0);
            this.panel1.BorderStyle = BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new Point(0, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(550, 0x42);
            this.panel1.TabIndex = 0;
            this.label5.AutoSize = true;
            this.label5.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label5.ForeColor = SystemColors.Highlight;
            this.label5.Location = new Point(0xa4, 0x22);
            this.label5.Name = "label5";
            this.label5.Size = new Size(0xd3, 0x10);
            this.label5.TabIndex = 1;
            this.label5.Text = "User can maintain user level details";
            this.label1.AutoSize = true;
            this.label1.Font = new Font("Tahoma", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.label1.ForeColor = SystemColors.Highlight;
            this.label1.Location = new Point(0xa3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x9c, 0x13);
            this.label1.TabIndex = 0;
            this.label1.Text = "User Level Details";
            this.panel2.BackColor = Color.Gainsboro;
            this.panel2.Controls.Add(this.txtuserlevel);
            this.panel2.Controls.Add(this.cmbUserStatus);
            this.panel2.Controls.Add(this.txtUserLevelCode);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new Point(0, 0x39);
            this.panel2.Name = "panel2";
            this.panel2.Size = new Size(550, 0x90);
            this.panel2.TabIndex = 1;
            this.txtuserlevel.Location = new Point(0x85, 0x3b);
            this.txtuserlevel.MaxLength = 0x19;
            this.txtuserlevel.Name = "txtuserlevel";
            this.txtuserlevel.Size = new Size(0x18b, 20);
            this.txtuserlevel.TabIndex = 3;
            this.txtuserlevel.KeyPress += new KeyPressEventHandler(this.txtuserlevel_KeyPress);
            this.cmbUserStatus.DrawMode = DrawMode.OwnerDrawVariable;
            this.cmbUserStatus.DropDownWidth = 0x11;
            this.cmbUserStatus.FormattingEnabled = true;
            this.cmbUserStatus.Location = new Point(0x85, 0x55);
            this.cmbUserStatus.Name = "cmbUserStatus";
            this.cmbUserStatus.Size = new Size(0x9b, 0x15);
            this.cmbUserStatus.TabIndex = 4;
            this.cmbUserStatus.ViewColumn = 0;
            this.txtUserLevelCode.Location = new Point(0x85, 0x21);
            this.txtUserLevelCode.MaxLength = 10;
            this.txtUserLevelCode.Name = "txtUserLevelCode";
            this.txtUserLevelCode.Size = new Size(0x9b, 20);
            this.txtUserLevelCode.TabIndex = 2;
            this.txtUserLevelCode.KeyPress += new KeyPressEventHandler(this.txtUserLevelCode_KeyPress);
            this.label4.AutoSize = true;
            this.label4.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label4.ForeColor = SystemColors.Highlight;
            this.label4.Location = new Point(0x1b, 0x5b);
            this.label4.Name = "label4";
            this.label4.Size = new Size(0x6b, 0x10);
            this.label4.TabIndex = 3;
            this.label4.Text = "User Level Status";
            this.label3.AutoSize = true;
            this.label3.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label3.ForeColor = SystemColors.Highlight;
            this.label3.Location = new Point(0x1b, 0x3e);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x43, 0x10);
            this.label3.TabIndex = 2;
            this.label3.Text = "User Level";
            this.label2.AutoSize = true;
            this.label2.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label2.ForeColor = SystemColors.Highlight;
            this.label2.Location = new Point(0x19, 0x21);
            this.label2.Name = "label2";
            this.label2.Size = new Size(100, 0x10);
            this.label2.TabIndex = 1;
            this.label2.Text = "User Level Code";
            this.erroruserlevel.ContainerControl = this;
            this.panel3.Controls.Add(this.btnView);
            this.panel3.Controls.Add(this.btnSave);
            this.panel3.Controls.Add(this.btnExit);
            this.panel3.Controls.Add(this.btnrefresh);
            this.panel3.Controls.Add(this.btnUpdate);
            this.panel3.Controls.Add(this.btnDelete);
            this.panel3.Location = new Point(1, 200);
            this.panel3.Name = "panel3";
            this.panel3.Size = new Size(0x225, 0x3b);
            this.panel3.TabIndex = 8;
            this.btnView.Location = new Point(240, 0x11);
            this.btnView.Name = "btnView";
            this.btnView.Size = new Size(0x4b, 0x17);
            this.btnView.TabIndex = 3;
            this.btnView.Text = "View";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new EventHandler(this.btnView_Click);
            this.btnSave.Location = new Point(9, 0x11);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new Size(0x4b, 0x17);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new EventHandler(this.btnSave_Click);
            this.btnExit.Location = new Point(0x1c4, 0x11);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new Size(0x4b, 0x17);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "&Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new EventHandler(this.btnExit_Click);
            this.btnrefresh.Location = new Point(0x13d, 0x11);
            this.btnrefresh.Name = "btnrefresh";
            this.btnrefresh.Size = new Size(0x4b, 0x17);
            this.btnrefresh.TabIndex = 4;
            this.btnrefresh.Text = "Refresh";
            this.btnrefresh.UseVisualStyleBackColor = true;
            this.btnrefresh.Click += new EventHandler(this.btnrefresh_Click);
            this.btnUpdate.Location = new Point(0x55, 0x11);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new Size(0x4b, 0x17);
            this.btnUpdate.TabIndex = 2;
            this.btnUpdate.Text = "&Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new EventHandler(this.btnUpdate_Click);
            this.btnDelete.Location = new Point(0xa2, 0x11);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new Size(0x4b, 0x17);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new EventHandler(this.btnDelete_Click);
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x224, 0x103);
            base.Controls.Add(this.panel3);
            base.Controls.Add(this.panel2);
            base.Controls.Add(this.panel1);
            base.FormBorderStyle = FormBorderStyle.FixedSingle;
            base.MaximizeBox = false;
            base.Name = "frmUserLevelMaster";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "User Level Master Entry . . . ";
            base.Load += new EventHandler(this.frmUserLevelMaster_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((ISupportInitialize) this.erroruserlevel).EndInit();
            this.panel3.ResumeLayout(false);
            base.ResumeLayout(false);
        }

        private void InsertUpdate()
        {
            this.ouserlevel.UserLevelCode = this.txtUserLevelCode.Text;
            this.ouserlevel.UserLevel = this.txtuserlevel.Text;
            this.ouserlevel.UserLevelStatus = this.cmbUserStatus["fld_status_code"].ToString();
            this.ouserlevel.LocationCode = this.cglobe.LocationCode.ToString();
            this.cuserlevel.InsertUpdate(this.ouserlevel);
        }

        private void LoadUserLevel()
        {
            this.ouserlevel = this.cuserlevel.GetUserLevelData(this.cglobe.LocationCode, this.txtUserLevelCode.Text);
            if (this.ouserlevel.UserLevelIsExists)
            {
                this.txtuserlevel.Text = this.ouserlevel.UserLevel;
                this.cmbUserStatus.Text = this.ouserlevel.UserLevelStatus;
            }
        }

        private void txtuserlevel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                this.cmbUserStatus.Focus();
            }
            this.ccommen.MoveNextControl(e);
        }

        private void txtUserLevelCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                this.ouserlevel = this.cuserlevel.GetUserLevelData(this.cglobe.LocationCode, this.txtUserLevelCode.Text);
                this.txtuserlevel.Text = this.ouserlevel.UserLevel;
                this.cmbUserStatus.Text = this.ouserlevel.UserLevelStatus;
                this.txtuserlevel.Focus();
            }
        }

        private bool validate_data()
        {
            bool flag = true;
            if (this.txtUserLevelCode.Text == "")
            {
                this.erroruserlevel.SetError(this.txtUserLevelCode, "pls Enter User level code");
                flag = false;
            }
            else
            {
                this.erroruserlevel.SetError(this.txtUserLevelCode, " ");
                this.erroruserlevel.Dispose();
            }
            if (this.txtuserlevel.Text == "")
            {
                this.erroruserlevel.SetError(this.txtuserlevel, "pls enter User level");
                return false;
            }
            this.erroruserlevel.SetError(this.txtuserlevel, " ");
            this.erroruserlevel.Dispose();
            return flag;
        }
    }
}

