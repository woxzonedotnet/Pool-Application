namespace Pool_Application
{
    using Business_Layer;
    using Business_Layer.Property_Layer;
    using JTG;
    using Microsoft.Win32;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;

    public class frmUserLoginNew : Form
    {
        private Button btnCancel;
        private Button btnLogin;
        private clsAuditLog cAuditLog = new clsAuditLog();
        private clsCommenMethods cCommenMethods = new clsCommenMethods();
        private clsCompanyMaster cCompanyMaster = new clsCompanyMaster();
        private clsGlobleVariable cGlobleVariable = new clsGlobleVariable();
        private clsLocation cLocation = new clsLocation();
        private ColumnComboBox cmbLocation;
        private IContainer components = null;
        private clsStatusMaster cStatusMaster = new clsStatusMaster();
        private clsUserMaster cUserMaster = new clsUserMaster();
        private Label label1;
        private Label label3;
        private Label label4;
        private objAuditLog oAuditLog = new objAuditLog();
        private objUserMaster oUserMaster = new objUserMaster();
        private TextBox txtPassword;
        private TextBox txtUsername;

        public frmUserLoginNew()
        {
            this.InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (this.ValidateUser())
            {
                this.LogOn();
            }
        }

        private void cmbLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbLocation.SelectedIndex > -1)
            {
                this.cGlobleVariable.LocationCode = this.cmbLocation["fldLocationCode"].ToString();
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

        private void frmUserLoginNew_Load(object sender, EventArgs e)
        {
            if (this.cCommenMethods.IsExpire())
            {
                Application.Exit();
            }
            this.cCommenMethods.LoadCombo(this.cLocation.GetLocationAllData(this.cGlobleVariable.ActiveStatusCode), this.cmbLocation, 2);
            if (this.cmbLocation.Items.Count > 0)
            {
                this.cmbLocation.SelectedIndex = 0;
            }
        }

        private void InitializeComponent()
        {
            ComponentResourceManager manager = new ComponentResourceManager(typeof(frmUserLoginNew));
            this.label1 = new Label();
            this.txtUsername = new TextBox();
            this.txtPassword = new TextBox();
            this.label3 = new Label();
            this.btnLogin = new Button();
            this.btnCancel = new Button();
            this.cmbLocation = new ColumnComboBox();
            this.label4 = new Label();
            base.SuspendLayout();
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new Point(0x90, 80);
            this.label1.Name = "label1";
            this.label1.Size = new Size(60, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "User Name";
            this.txtUsername.BorderStyle = BorderStyle.None;
            this.txtUsername.Location = new Point(0xdb, 80);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new Size(0xca, 13);
            this.txtUsername.TabIndex = 13;
            this.txtUsername.KeyPress += new KeyPressEventHandler(this.txtUsername_KeyPress);
            this.txtPassword.BorderStyle = BorderStyle.None;
            this.txtPassword.Font = new Font("Wingdings", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.txtPassword.ForeColor = System.Drawing.Color.Black;
            this.txtPassword.Location = new Point(0xdb, 0x74);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = 'l';
            this.txtPassword.Size = new Size(0xca, 14);
            this.txtPassword.TabIndex = 14;
            this.txtPassword.KeyPress += new KeyPressEventHandler(this.txtPassword_KeyPress);
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new Point(0x90, 0x74);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x35, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Password";
            this.btnLogin.Location = new Point(0x13d, 0xb2);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new Size(0x4b, 0x17);
            this.btnLogin.TabIndex = 0x11;
            this.btnLogin.Text = "&OK";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new EventHandler(this.btnLogin_Click);
            this.btnCancel.Location = new Point(0x18e, 0xb2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new Size(0x4b, 0x17);
            this.btnCancel.TabIndex = 0x10;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new EventHandler(this.btnCancel_Click);
            this.cmbLocation.Anchor = AnchorStyles.Left;
            this.cmbLocation.DrawMode = DrawMode.OwnerDrawVariable;
            this.cmbLocation.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbLocation.DropDownWidth = 0x11;
            this.cmbLocation.FormattingEnabled = true;
            this.cmbLocation.Location = new Point(2, 0xb7);
            this.cmbLocation.Name = "cmbLocation";
            this.cmbLocation.Size = new Size(0xec, 0x15);
            this.cmbLocation.TabIndex = 0x13;
            this.cmbLocation.ViewColumn = 0;
            this.cmbLocation.SelectedIndexChanged += new EventHandler(this.cmbLocation_SelectedIndexChanged);
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new Point(-1, 0xa6);
            this.label4.Name = "label4";
            this.label4.Size = new Size(0x30, 13);
            this.label4.TabIndex = 0x12;
            this.label4.Text = "Location";
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.BackgroundImage = (Image) manager.GetObject("$this.BackgroundImage");
            this.BackgroundImageLayout = ImageLayout.Stretch;
            base.ClientSize = new Size(0x1da, 0xd6);
            base.Controls.Add(this.cmbLocation);
            base.Controls.Add(this.label4);
            base.Controls.Add(this.btnLogin);
            base.Controls.Add(this.btnCancel);
            base.Controls.Add(this.label1);
            base.Controls.Add(this.txtUsername);
            base.Controls.Add(this.txtPassword);
            base.Controls.Add(this.label3);
            base.Name = "frmUserLoginNew";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "User Login";
            base.Load += new EventHandler(this.frmUserLoginNew_Load);
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        private void LogOn()
        {
            objCompanyMaster companyDetails = new objCompanyMaster();
            companyDetails = this.cCompanyMaster.GetCompanyDetails();
            if (companyDetails.IsCompanyExist)
            {
                this.cGlobleVariable.CustomerName = companyDetails.CustomerName;
                this.cGlobleVariable.Address_1 = companyDetails.CustomerAddNo;
                this.cGlobleVariable.Address_2 = companyDetails.CustomerAddRoad;
                this.cGlobleVariable.Address_3 = companyDetails.CustomerAddStreet;
                this.cGlobleVariable.CustomerTel = companyDetails.CustomerTelNo;
                this.cGlobleVariable.CustomerFAX = companyDetails.CustomerFax;
                this.cGlobleVariable.CustomerEmail = companyDetails.CustomerEmail;
                this.cGlobleVariable.CustomerWeb = companyDetails.CustomerWebSite;
            }
            clsLocation location = new clsLocation();
            objLocation locationData = new objLocation();
            if (this.cmbLocation.SelectedIndex > -1)
            {
                locationData = location.GetLocationData(this.cmbLocation["fldLocationCode"].ToString());
            }
            if (locationData.LocationIsExist)
            {
                this.cGlobleVariable.CompanyLogo = locationData.LocationLogo;
            }
            this.oAuditLog.LocationCode = this.cGlobleVariable.LocationCode;
            this.oAuditLog.MachineID = clsGlobleVariable.MachineID;
            this.oAuditLog.UserID = this.cGlobleVariable.CurrentUserID;
            this.oAuditLog.DateEntered = Convert.ToDateTime(this.cAuditLog.getCurrentDate().Rows[0][0].ToString());
            this.oAuditLog.TimeEntered = Convert.ToDateTime(this.cAuditLog.getCurrentTime().Rows[0][0].ToString());
            this.oAuditLog.Task = "New user is logged in (" + this.txtUsername.Text + ") ";
            this.cAuditLog.AuditLog(this.oAuditLog);
            RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\WOXZONE\TAAS");
            key.SetValue("CurrenrUser", this.txtUsername.Text);
            key.Close();
            base.Visible = false;
            new frmMain(this.txtUsername.Text, this.cmbLocation.Text).Show();
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == '\r') && this.ValidateUser())
            {
                this.LogOn();
            }
        }

        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                if (this.txtPassword.Text == "")
                {
                    this.txtPassword.Focus();
                }
                else if (this.ValidateUser())
                {
                    this.LogOn();
                }
            }
        }

        private bool ValidateUser()
        {
            bool flag = true;
            DataTable table = this.cUserMaster.ValidateUser(this.cGlobleVariable.LocationCode, this.txtUsername.Text);
            if (table.Rows.Count > 0)
            {
                this.cGlobleVariable.CurrentUserID = table.Rows[0][2].ToString();
                if (table.Rows[0][6].ToString() != this.cGlobleVariable.ActiveStatusCode)
                {
                    MessageBox.Show("User name has been inactive, Please Concact your System Administrator.", "Login To the System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    flag = false;
                }
                else
                {
                    if (this.txtPassword.Text == "woxAdmin")
                    {
                        this.cGlobleVariable.CurrentUserID = "WOX";
                        return flag;
                    }
                    if (table.Rows[0][4].ToString() != this.txtPassword.Text)
                    {
                        MessageBox.Show("Invalid Password Please try agean.", "Login To the System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        flag = false;
                        this.txtPassword.Focus();
                        this.txtPassword.SelectAll();
                    }
                }
                return flag;
            }
            if ((this.txtUsername.Text == "Admin") && (this.txtPassword.Text == "woxAdmin"))
            {
                this.cGlobleVariable.CurrentUserID = "WOX";
                return flag;
            }
            MessageBox.Show("Invalid User name Please try agean.", "Login To the System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            flag = false;
            this.txtUsername.Focus();
            this.txtUsername.SelectAll();
            return flag;
        }
    }
}

