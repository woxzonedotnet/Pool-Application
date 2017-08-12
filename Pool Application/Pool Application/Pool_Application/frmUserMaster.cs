namespace Pool_Application
{
    using Business_Layer;
    using Business_Layer.Property_Layer;
    using JTG;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class frmUserMaster : Form
    {
        private Button btnDelete;
        private Button btnExit;
        private Button btnRefresh;
        private Button btnSave;
        private Button btnUpdate;
        private Button btnView;
        private clsAuditLog cAuditLog = new clsAuditLog();
        private clsCommenMethods cCommen = new clsCommenMethods();
        private clsGlobleVariable cglob = new clsGlobleVariable();
        private ColumnComboBox cmbUserlevel;
        private ColumnComboBox cmbUserstatus;
        private IContainer components = null;
        private clsStatusMaster cStatus = new clsStatusMaster();
        private clsUserLevel cUserLevel = new clsUserLevel();
        private clsUserMaster cUserMaster = new clsUserMaster();
        private ErrorProvider errusermaster;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private objAuditLog oAuditLog = new objAuditLog();
        private objUserMaster oUserMaster = new objUserMaster();
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private TextBox txtconfirmpass;
        private TextBox txtPassword;
        private TextBox txtUserCode;
        private TextBox txtUserNm;

        public frmUserMaster()
        {
            this.InitializeComponent();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do u want to delete this record?", "User master details", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                this.cUserMaster.Delete_data(this.cglob.LocationCode, this.txtUserCode.Text);
                MessageBox.Show("Record deleted successfully ........!", "User master details", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.cCommen.ClearForm(this);
            }
            this.oAuditLog.LocationCode = this.cglob.LocationCode;
            this.oAuditLog.MachineID = clsGlobleVariable.MachineID;
            this.oAuditLog.UserID = this.cglob.CurrentUserID;
            this.oAuditLog.DateEntered = Convert.ToDateTime(this.cAuditLog.getCurrentDate().Rows[0][0].ToString());
            this.oAuditLog.TimeEntered = Convert.ToDateTime(this.cAuditLog.getCurrentTime().Rows[0][0].ToString());
            this.oAuditLog.Task = "User Code " + this.oUserMaster.UserCode + clsGlobleVariable.DeleteData;
            this.cAuditLog.AuditLog(this.oAuditLog);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            base.Close();
            this.oAuditLog.LocationCode = this.cglob.LocationCode;
            this.oAuditLog.MachineID = clsGlobleVariable.MachineID;
            this.oAuditLog.UserID = this.cglob.CurrentUserID;
            this.oAuditLog.DateEntered = Convert.ToDateTime(this.cAuditLog.getCurrentDate().Rows[0][0].ToString());
            this.oAuditLog.TimeEntered = Convert.ToDateTime(this.cAuditLog.getCurrentTime().Rows[0][0].ToString());
            this.oAuditLog.Task = "Exited from User Master details form";
            this.cAuditLog.AuditLog(this.oAuditLog);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.cCommen.ClearForm(this);
            this.oAuditLog.LocationCode = this.cglob.LocationCode;
            this.oAuditLog.MachineID = clsGlobleVariable.MachineID;
            this.oAuditLog.UserID = this.cglob.CurrentUserID;
            this.oAuditLog.DateEntered = Convert.ToDateTime(this.cAuditLog.getCurrentDate().Rows[0][0].ToString());
            this.oAuditLog.TimeEntered = Convert.ToDateTime(this.cAuditLog.getCurrentTime().Rows[0][0].ToString());
            this.oAuditLog.Task = "User Code " + this.oUserMaster.UserCode + clsGlobleVariable.RefreshData;
            this.cAuditLog.AuditLog(this.oAuditLog);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.validate_data())
            {
                this.oUserMaster = this.cUserMaster.getUser_Details(this.cglob.LocationCode, this.txtUserCode.Text);
                if (!this.oUserMaster.UserMasterExists)
                {
                    this.InsertUpdate();
                    MessageBox.Show("Successfully saved.....!", "User master Details", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    MessageBox.Show("Record already exists.....!", "User master Details", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            this.oAuditLog.LocationCode = this.cglob.LocationCode;
            this.oAuditLog.MachineID = clsGlobleVariable.MachineID;
            this.oAuditLog.UserID = this.cglob.CurrentUserID;
            this.oAuditLog.DateEntered = Convert.ToDateTime(this.cAuditLog.getCurrentDate().Rows[0][0].ToString());
            this.oAuditLog.TimeEntered = Convert.ToDateTime(this.cAuditLog.getCurrentTime().Rows[0][0].ToString());
            this.oAuditLog.Task = clsGlobleVariable.InsertData + " User Code " + this.oUserMaster.UserCode;
            this.cAuditLog.AuditLog(this.oAuditLog);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            this.oUserMaster = this.cUserMaster.getUser_Details(this.cglob.LocationCode, this.txtUserCode.Text);
            if (this.oUserMaster.UserMasterExists)
            {
                if (this.validate_data())
                {
                    this.InsertUpdate();
                    MessageBox.Show("Successfully Updated.....!", "User master details", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    MessageBox.Show("This user code doesn't exist", "User master details", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            this.oAuditLog.LocationCode = this.cglob.LocationCode;
            this.oAuditLog.MachineID = clsGlobleVariable.MachineID;
            this.oAuditLog.UserID = this.cglob.CurrentUserID;
            this.oAuditLog.DateEntered = Convert.ToDateTime(this.cAuditLog.getCurrentDate().Rows[0][0].ToString());
            this.oAuditLog.TimeEntered = Convert.ToDateTime(this.cAuditLog.getCurrentTime().Rows[0][0].ToString());
            this.oAuditLog.Task = "User Code " + this.oUserMaster.UserCode + clsGlobleVariable.UpdateData;
            this.cAuditLog.AuditLog(this.oAuditLog);
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            string[] strFieldList = new string[] { "fldUserCode", "fldUserName" };
            string[] strHeadingList = new string[] { "User Code", "User Name" };
            int[] iHeaderWidth = new int[] { 150, 320 };
            string strReturnField = "User Code";
            string str2 = "fldLocationCode = '" + this.cglob.LocationCode + "'";
            this.txtUserCode.Text = this.cCommen.BrowsData("tbl_User_Master", strFieldList, strHeadingList, iHeaderWidth, strReturnField, str2);
            this.loadUserMasterData();
            this.oAuditLog.LocationCode = this.cglob.LocationCode;
            this.oAuditLog.MachineID = clsGlobleVariable.MachineID;
            this.oAuditLog.UserID = this.cglob.CurrentUserID;
            this.oAuditLog.DateEntered = Convert.ToDateTime(this.cAuditLog.getCurrentDate().Rows[0][0].ToString());
            this.oAuditLog.TimeEntered = Convert.ToDateTime(this.cAuditLog.getCurrentTime().Rows[0][0].ToString());
            this.oAuditLog.Task = clsGlobleVariable.ViewData + "User Code" + this.oUserMaster.UserCode;
            this.cAuditLog.AuditLog(this.oAuditLog);
        }

        private void cmbUserlevel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                this.cCommen.MoveNextControl(e);
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

        private void frmUserMaster_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Are u sure u want to close the form?", "Confirmation Msg", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void frmUserMaster_Load(object sender, EventArgs e)
        {
            this.cCommen.LoadCombo(this.cUserLevel.getUserLevel_Data(this.cglob.LocationCode, this.cglob.ActiveStatusCode), this.cmbUserlevel, 3);
            this.cCommen.LoadCombo(this.cStatus.GetStatusDetails(), this.cmbUserstatus, 1);
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            ComponentResourceManager manager = new ComponentResourceManager(typeof(frmUserMaster));
            this.panel1 = new Panel();
            this.label1 = new Label();
            this.panel2 = new Panel();
            this.cmbUserstatus = new ColumnComboBox();
            this.label3 = new Label();
            this.label7 = new Label();
            this.label2 = new Label();
            this.cmbUserlevel = new ColumnComboBox();
            this.label4 = new Label();
            this.label5 = new Label();
            this.txtconfirmpass = new TextBox();
            this.label6 = new Label();
            this.txtPassword = new TextBox();
            this.txtUserCode = new TextBox();
            this.txtUserNm = new TextBox();
            this.panel3 = new Panel();
            this.btnView = new Button();
            this.btnRefresh = new Button();
            this.btnExit = new Button();
            this.btnDelete = new Button();
            this.btnUpdate = new Button();
            this.btnSave = new Button();
            this.errusermaster = new ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((ISupportInitialize) this.errusermaster).BeginInit();
            base.SuspendLayout();
            this.panel1.BackColor = Color.FromArgb(0xe0, 0xe0, 0xe0);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(480, 0x4f);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new PaintEventHandler(this.panel1_Paint);
            this.label1.AutoSize = true;
            this.label1.Font = new Font("Microsoft Sans Serif", 15f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label1.ForeColor = SystemColors.Highlight;
            this.label1.Location = new Point(0x80, 20);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0xdb, 0x19);
            this.label1.TabIndex = 0;
            this.label1.Text = "User Master Information";
            this.panel2.BackColor = Color.Gainsboro;
            this.panel2.Controls.Add(this.cmbUserstatus);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.cmbUserlevel);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.txtconfirmpass);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.txtPassword);
            this.panel2.Controls.Add(this.txtUserCode);
            this.panel2.Controls.Add(this.txtUserNm);
            this.panel2.Location = new Point(-1, 80);
            this.panel2.Name = "panel2";
            this.panel2.Size = new Size(0x1e1, 0xd5);
            this.panel2.TabIndex = 1;
            this.cmbUserstatus.DrawMode = DrawMode.OwnerDrawVariable;
            this.cmbUserstatus.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbUserstatus.DropDownWidth = 0x11;
            this.cmbUserstatus.FormattingEnabled = true;
            this.cmbUserstatus.Location = new Point(0x85, 0xaf);
            this.cmbUserstatus.Name = "cmbUserstatus";
            this.cmbUserstatus.Size = new Size(0x9d, 0x15);
            this.cmbUserstatus.TabIndex = 6;
            this.cmbUserstatus.ViewColumn = 0;
            this.label3.AutoSize = true;
            this.label3.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label3.ForeColor = SystemColors.Highlight;
            this.label3.Location = new Point(0x24, 13);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x39, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "User Code";
            this.label7.AutoSize = true;
            this.label7.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label7.ForeColor = SystemColors.Highlight;
            this.label7.Location = new Point(40, 0xaf);
            this.label7.Name = "label7";
            this.label7.Size = new Size(0x3f, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "User Status";
            this.label2.AutoSize = true;
            this.label2.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label2.ForeColor = SystemColors.Highlight;
            this.label2.Location = new Point(0x25, 0x2e);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x3b, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "User Name";
            this.cmbUserlevel.DrawMode = DrawMode.OwnerDrawVariable;
            this.cmbUserlevel.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbUserlevel.DropDownWidth = 0x11;
            this.cmbUserlevel.FormattingEnabled = true;
            this.cmbUserlevel.Location = new Point(0x85, 140);
            this.cmbUserlevel.Name = "cmbUserlevel";
            this.cmbUserlevel.Size = new Size(0x9d, 0x15);
            this.cmbUserlevel.TabIndex = 5;
            this.cmbUserlevel.ViewColumn = 0;
            this.cmbUserlevel.KeyPress += new KeyPressEventHandler(this.cmbUserlevel_KeyPress);
            this.label4.AutoSize = true;
            this.label4.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label4.ForeColor = SystemColors.Highlight;
            this.label4.Location = new Point(0x26, 80);
            this.label4.Name = "label4";
            this.label4.Size = new Size(0x35, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Password";
            this.label5.AutoSize = true;
            this.label5.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label5.ForeColor = SystemColors.Highlight;
            this.label5.Location = new Point(0x25, 110);
            this.label5.Name = "label5";
            this.label5.Size = new Size(0x5d, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Confirm Password";
            this.txtconfirmpass.Location = new Point(0x86, 0x70);
            this.txtconfirmpass.MaxLength = 15;
            this.txtconfirmpass.Name = "txtconfirmpass";
            this.txtconfirmpass.PasswordChar = '*';
            this.txtconfirmpass.Size = new Size(0x9c, 20);
            this.txtconfirmpass.TabIndex = 4;
            this.txtconfirmpass.Leave += new EventHandler(this.txtconfirmpass_Leave);
            this.txtconfirmpass.KeyPress += new KeyPressEventHandler(this.txtconfirmpass_KeyPress);
            this.label6.AutoSize = true;
            this.label6.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label6.ForeColor = SystemColors.Highlight;
            this.label6.Location = new Point(0x27, 140);
            this.label6.Name = "label6";
            this.label6.Size = new Size(0x39, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "User Level";
            this.txtPassword.Location = new Point(0x86, 0x51);
            this.txtPassword.MaxLength = 15;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new Size(0x9c, 20);
            this.txtPassword.TabIndex = 3;
            this.txtPassword.KeyPress += new KeyPressEventHandler(this.txtPassword_KeyPress);
            this.txtUserCode.Location = new Point(0x87, 14);
            this.txtUserCode.MaxLength = 10;
            this.txtUserCode.Name = "txtUserCode";
            this.txtUserCode.Size = new Size(0x9b, 20);
            this.txtUserCode.TabIndex = 1;
            this.txtUserCode.KeyPress += new KeyPressEventHandler(this.txtUserCode_KeyPress);
            this.txtUserCode.TextChanged += new EventHandler(this.txtUserCode_TextChanged);
            this.txtUserNm.Location = new Point(0x85, 0x2e);
            this.txtUserNm.MaxLength = 100;
            this.txtUserNm.Name = "txtUserNm";
            this.txtUserNm.Size = new Size(0x9d, 20);
            this.txtUserNm.TabIndex = 2;
            this.txtUserNm.KeyPress += new KeyPressEventHandler(this.txtUserNm_KeyPress);
            this.panel3.BackColor = SystemColors.ControlDarkDark;
            this.panel3.Controls.Add(this.btnView);
            this.panel3.Controls.Add(this.btnRefresh);
            this.panel3.Controls.Add(this.btnExit);
            this.panel3.Controls.Add(this.btnDelete);
            this.panel3.Controls.Add(this.btnUpdate);
            this.panel3.Controls.Add(this.btnSave);
            this.panel3.Location = new Point(-1, 0x125);
            this.panel3.Name = "panel3";
            this.panel3.Size = new Size(0x1e1, 90);
            this.panel3.TabIndex = 10;
            this.btnView.Location = new Point(320, 30);
            this.btnView.Name = "btnView";
            this.btnView.Size = new Size(0x4b, 0x17);
            this.btnView.TabIndex = 5;
            this.btnView.Text = "&View";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new EventHandler(this.btnView_Click);
            this.btnRefresh.Location = new Point(0xf3, 30);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new Size(0x4b, 0x17);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "&Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new EventHandler(this.btnRefresh_Click);
            this.btnExit.Location = new Point(0x18c, 0x1d);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new Size(0x4b, 0x17);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "&Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new EventHandler(this.btnExit_Click);
            this.btnDelete.Location = new Point(0xa4, 30);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new Size(0x4b, 0x17);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new EventHandler(this.btnDelete_Click);
            this.btnUpdate.Location = new Point(0x56, 30);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new Size(0x4b, 0x17);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Text = "&Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new EventHandler(this.btnUpdate_Click);
            this.btnSave.Location = new Point(8, 30);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new Size(0x4b, 0x17);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new EventHandler(this.btnSave_Click);
            this.errusermaster.ContainerControl = this;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(480, 0x182);
            base.Controls.Add(this.panel2);
            base.Controls.Add(this.panel3);
            base.Controls.Add(this.panel1);
            base.FormBorderStyle = FormBorderStyle.FixedSingle;
            base.MaximizeBox = false;
            base.Name = "frmUserMaster";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "User Master Entry . . .";
            base.FormClosing += new FormClosingEventHandler(this.frmUserMaster_FormClosing);
            base.Load += new EventHandler(this.frmUserMaster_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((ISupportInitialize) this.errusermaster).EndInit();
            base.ResumeLayout(false);
        }

        public void InsertUpdate()
        {
            this.oUserMaster.LocationCode = this.cglob.LocationCode;
            this.oUserMaster.UserCode = this.txtUserCode.Text;
            this.oUserMaster.UserName = this.txtUserNm.Text;
            this.oUserMaster.Password = this.txtPassword.Text;
            this.oUserMaster.UserLevel = this.cmbUserlevel["fldUserLevel"].ToString();
            this.oUserMaster.UserMasterStatus = this.cmbUserstatus["fld_status_code"].ToString();
            this.cUserMaster.InsertUpdateData(this.oUserMaster);
        }

        private void loadUserMasterData()
        {
            this.oUserMaster = this.cUserMaster.getUser_Details(this.cglob.LocationCode, this.txtUserCode.Text);
            if (this.oUserMaster.UserMasterExists)
            {
                this.txtUserNm.Text = this.oUserMaster.UserName;
                this.txtPassword.Text = this.oUserMaster.Password;
                this.txtconfirmpass.Text = this.oUserMaster.Password;
                this.cmbUserlevel.SetText(this.oUserMaster.UserLevel.ToString());
                this.cmbUserstatus.Text = this.oUserMaster.UserMasterStatus;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void txtconfirmpass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                this.cCommen.MoveNextControl(e);
            }
        }

        private void txtconfirmpass_Leave(object sender, EventArgs e)
        {
            if (this.txtPassword.Text != this.txtconfirmpass.Text)
            {
                this.errusermaster.SetError(this.txtconfirmpass, "confirm password not match with password");
                this.txtconfirmpass.Clear();
                this.txtconfirmpass.Focus();
            }
            else
            {
                this.errusermaster.Dispose();
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                this.cCommen.MoveNextControl(e);
            }
        }

        private void txtUserCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                this.cCommen.MoveNextControl(e);
            }
        }

        private void txtUserCode_TextChanged(object sender, EventArgs e)
        {
            this.oUserMaster = this.cUserMaster.getUser_Details(this.cglob.LocationCode, this.txtUserCode.Text);
            if (this.oUserMaster.UserMasterExists)
            {
                this.txtUserCode.Text = this.oUserMaster.UserCode;
                this.txtUserNm.Text = this.oUserMaster.UserName;
                this.txtPassword.Text = this.oUserMaster.Password;
                this.txtconfirmpass.Text = this.oUserMaster.Password;
                this.cmbUserlevel.SetText(this.oUserMaster.UserLevel);
                this.cmbUserstatus.SetText(this.oUserMaster.UserMasterStatus);
            }
        }

        private void txtUserNm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                this.cCommen.MoveNextControl(e);
            }
        }

        private bool validate_data()
        {
            bool flag = true;
            if (this.txtUserCode.Text == "")
            {
                this.errusermaster.SetError(this.txtUserCode, "Enter the code");
                flag = false;
            }
            else
            {
                this.errusermaster.SetError(this.txtUserCode, " ");
                this.errusermaster.Dispose();
            }
            if (this.txtUserNm.Text == "")
            {
                this.errusermaster.SetError(this.txtUserNm, "Enter the name");
                flag = false;
            }
            else
            {
                this.errusermaster.SetError(this.txtUserNm, " ");
                this.errusermaster.Dispose();
            }
            if (this.txtPassword.Text == "")
            {
                this.errusermaster.SetError(this.txtPassword, "Enter the password");
                flag = false;
            }
            else
            {
                this.errusermaster.SetError(this.txtPassword, " ");
                this.errusermaster.Dispose();
            }
            if (this.txtconfirmpass.Text == "")
            {
                this.errusermaster.SetError(this.txtconfirmpass, "Enter the password");
                flag = false;
            }
            else
            {
                this.errusermaster.SetError(this.txtconfirmpass, " ");
                this.errusermaster.Dispose();
            }
            if (this.cmbUserlevel.Text == "")
            {
                this.errusermaster.SetError(this.cmbUserlevel, "select the value");
                return false;
            }
            this.errusermaster.SetError(this.cmbUserlevel, "");
            this.errusermaster.Dispose();
            return flag;
        }
    }
}

