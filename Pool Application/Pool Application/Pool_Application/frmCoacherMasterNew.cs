namespace Pool_Application
{
    using Business_Layer;
    using Business_Layer.Property_Layer;
    using JTG;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class frmCoacherMasterNew : Form
    {
        public Button btnDelete;
        public Button btnExit;
        public Button btnRefresh;
        public Button btnSave;
        public Button btnView;
        private clsBluedGroupMaster cBluedGroupMaster = new clsBluedGroupMaster();
        private clsCoacherMaster cCoacherMaster = new clsCoacherMaster();
        private clsCommenMethods cCommanMethods = new clsCommenMethods();
        private clsGlobleVariable cGlobleVariable = new clsGlobleVariable();
        private clsMarriedStatus cMarriedStatus = new clsMarriedStatus();
        private ColumnComboBox cmbBluedGroup;
        private ColumnComboBox cmbCoacherStatus;
        private ComboBox cmbGender;
        private ColumnComboBox cmbMarried;
        private IContainer components = null;
        private clsStatusMaster cStatusMaster = new clsStatusMaster();
        private DateTimePicker dateTimeDOB;
        private DateTimePicker dtpDateOfJoined;
        private DateTimePicker dtpLicenseExpire;
        private DateTimePicker dtpLicenseIssued;
        private DateTimePicker dtpNICIssued;
        private DateTimePicker dtpPassportExpire;
        private DateTimePicker dtpPassportIssued;
        private ErrorProvider errorCoacher;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox5;
        private GroupBox groupBox6;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label70;
        private Label label71;
        private Label label72;
        private Label label73;
        private Label label76;
        private Label label77;
        private Label label78;
        private Label label79;
        private Label label8;
        private Label label80;
        private Label label81;
        private Label label82;
        private Label label84;
        private Label label86;
        private Label label87;
        private Label label88;
        private Label label89;
        private Label label90;
        private Label label91;
        private Label label92;
        private Label label93;
        private Label label94;
        private Label label95;
        private Label label96;
        private Label label97;
        private Label label98;
        private Label label99;
        private objCoacherMaster oCoacherMaster = new objCoacherMaster();
        private Panel panel1;
        private TextBox txtCoacherCode;
        private TextBox txtCoacherName;
        private TextBox txtContactHomeTP;
        private TextBox txtContactMobile;
        private TextBox txtEmailAdd;
        private TextBox txtEPFNo;
        private TextBox txtFullNameLineTwo;
        private TextBox txtLicenseNo;
        private TextBox txtNameInitial;
        private TextBox txtNICNo;
        private TextBox txtOtherName;
        private TextBox txtPassportNo;
        private TextBox txtPermanentNo;
        private TextBox txtPermanentTown;
        private TextBox txtPermenantCity;
        private TextBox txtPermenentRoad;
        private TextBox txtPINNo;
        private TextBox txtPreferName;
        private TextBox txtReligion;
        private TextBox txtSurname;
        private TextBox txtTempCity;
        private TextBox txtTempNo;
        private TextBox txtTemproad;
        private TextBox txtTempTown;

        public frmCoacherMasterNew()
        {
            this.InitializeComponent();
        }

        private void AddGender()
        {
            object[] items = new object[] { "Male", "Female" };
            this.cmbGender.Items.AddRange(items);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!this.cCoacherMaster.GetCoacherData(this.cGlobleVariable.LocationCode, this.txtCoacherCode.Text).CoacherIsExist)
            {
                MessageBox.Show("Coacher not found....!", "Coacher Details", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else if (MessageBox.Show("Do you want to delete this record", "Coacher Master Details", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.cCoacherMaster.DeleteClassMasterData(this.cGlobleVariable.LocationCode, this.txtCoacherCode.Text);
                MessageBox.Show("Deleted Successfully.......", "Coacher Master details", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.cCommanMethods.ClearForm(this);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.cCommanMethods.ClearForm(this);
            this.AddGender();
            this.txtCoacherCode.Select();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.validateData())
            {
                this.InsertUpdate();
                MessageBox.Show("Successfully Saved.....!", "Employee Master details", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.cCommanMethods.ClearForm(this);
                this.AddGender();
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            string[] strFieldList = new string[] { "fldCoacherCode", "fldFullNameLineOne" };
            string[] strHeadingList = new string[] { "Coacher No", "Coacher Name" };
            int[] iHeaderWidth = new int[] { 80, 100 };
            string strReturnField = "Coacher No";
            string str2 = "fldLocationCode = '" + this.cGlobleVariable.LocationCode + "' ";
            this.txtCoacherCode.Text = this.cCommanMethods.BrowsData("tbl_coacher_master", strFieldList, strHeadingList, iHeaderWidth, strReturnField, str2);
        }

        private void cmbBluedGroup_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.cCommanMethods.MoveNextControl(e);
        }

        private void cmbCoacherStatus_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.cCommanMethods.MoveNextControl(e);
        }

        private void cmbGender_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.cCommanMethods.MoveNextControl(e);
        }

        private void cmbMarried_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.cCommanMethods.MoveNextControl(e);
        }

        private void dateTimeDOB_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.cCommanMethods.MoveNextControl(e);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void dtpDateOfJoined_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.cCommanMethods.MoveNextControl(e);
        }

        private void dtpLicenseExpire_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.cCommanMethods.MoveNextControl(e);
        }

        private void dtpLicenseIssued_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.cCommanMethods.MoveNextControl(e);
        }

        private void dtpNICIssued_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.cCommanMethods.MoveNextControl(e);
        }

        private void dtpPassportExpire_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.cCommanMethods.MoveNextControl(e);
        }

        private void dtpPassportIssued_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.cCommanMethods.MoveNextControl(e);
        }

        private void frmCoacherMasterNew_Load(object sender, EventArgs e)
        {
            this.cCommanMethods.LoadCombo(this.cBluedGroupMaster.GetBluedGroup(), this.cmbBluedGroup, 2);
            this.cCommanMethods.LoadCombo(this.cMarriedStatus.GetMarriedStatus(), this.cmbMarried, 2);
            this.cCommanMethods.LoadCombo(this.cStatusMaster.GetStatusDetails(), this.cmbCoacherStatus, 1);
            this.AddGender();
            this.txtCoacherCode.Focus();
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            ComponentResourceManager manager = new ComponentResourceManager(typeof(frmCoacherMasterNew));
            this.txtCoacherName = new TextBox();
            this.groupBox5 = new GroupBox();
            this.groupBox6 = new GroupBox();
            this.label82 = new Label();
            this.cmbCoacherStatus = new ColumnComboBox();
            this.txtEmailAdd = new TextBox();
            this.label97 = new Label();
            this.txtContactHomeTP = new TextBox();
            this.label96 = new Label();
            this.txtContactMobile = new TextBox();
            this.label95 = new Label();
            this.groupBox2 = new GroupBox();
            this.label1 = new Label();
            this.label79 = new Label();
            this.label80 = new Label();
            this.label81 = new Label();
            this.txtTempCity = new TextBox();
            this.txtTempTown = new TextBox();
            this.txtTemproad = new TextBox();
            this.txtTempNo = new TextBox();
            this.groupBox1 = new GroupBox();
            this.label3 = new Label();
            this.label78 = new Label();
            this.label76 = new Label();
            this.label77 = new Label();
            this.txtPermenantCity = new TextBox();
            this.txtPermanentTown = new TextBox();
            this.txtPermenentRoad = new TextBox();
            this.txtPermanentNo = new TextBox();
            this.cmbBluedGroup = new ColumnComboBox();
            this.label98 = new Label();
            this.cmbGender = new ComboBox();
            this.label84 = new Label();
            this.cmbMarried = new ColumnComboBox();
            this.label99 = new Label();
            this.txtCoacherCode = new TextBox();
            this.dateTimeDOB = new DateTimePicker();
            this.txtReligion = new TextBox();
            this.dtpDateOfJoined = new DateTimePicker();
            this.label94 = new Label();
            this.label93 = new Label();
            this.dtpLicenseExpire = new DateTimePicker();
            this.label90 = new Label();
            this.dtpLicenseIssued = new DateTimePicker();
            this.label91 = new Label();
            this.txtLicenseNo = new TextBox();
            this.label92 = new Label();
            this.txtOtherName = new TextBox();
            this.label89 = new Label();
            this.dtpPassportExpire = new DateTimePicker();
            this.label88 = new Label();
            this.dtpPassportIssued = new DateTimePicker();
            this.label87 = new Label();
            this.dtpNICIssued = new DateTimePicker();
            this.label86 = new Label();
            this.txtFullNameLineTwo = new TextBox();
            this.txtPassportNo = new TextBox();
            this.label73 = new Label();
            this.txtPreferName = new TextBox();
            this.label72 = new Label();
            this.txtSurname = new TextBox();
            this.label71 = new Label();
            this.txtEPFNo = new TextBox();
            this.label70 = new Label();
            this.txtPINNo = new TextBox();
            this.label2 = new Label();
            this.label4 = new Label();
            this.txtNICNo = new TextBox();
            this.txtNameInitial = new TextBox();
            this.label5 = new Label();
            this.label6 = new Label();
            this.label7 = new Label();
            this.label8 = new Label();
            this.panel1 = new Panel();
            this.btnView = new Button();
            this.btnRefresh = new Button();
            this.btnSave = new Button();
            this.btnDelete = new Button();
            this.btnExit = new Button();
            this.errorCoacher = new ErrorProvider(this.components);
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((ISupportInitialize) this.errorCoacher).BeginInit();
            base.SuspendLayout();
            this.txtCoacherName.BackColor = Color.White;
            this.txtCoacherName.Location = new Point(0x6f, 0x43);
            this.txtCoacherName.MaxLength = 100;
            this.txtCoacherName.Name = "txtCoacherName";
            this.txtCoacherName.Size = new Size(0x1cb, 20);
            this.txtCoacherName.TabIndex = 5;
            this.txtCoacherName.KeyPress += new KeyPressEventHandler(this.txtCoacherName_KeyPress);
            this.groupBox5.Controls.Add(this.groupBox6);
            this.groupBox5.Controls.Add(this.groupBox2);
            this.groupBox5.Controls.Add(this.groupBox1);
            this.groupBox5.Controls.Add(this.cmbBluedGroup);
            this.groupBox5.Controls.Add(this.label98);
            this.groupBox5.Controls.Add(this.cmbGender);
            this.groupBox5.Controls.Add(this.label84);
            this.groupBox5.Controls.Add(this.cmbMarried);
            this.groupBox5.Controls.Add(this.label99);
            this.groupBox5.Controls.Add(this.txtCoacherCode);
            this.groupBox5.Controls.Add(this.dateTimeDOB);
            this.groupBox5.Controls.Add(this.txtReligion);
            this.groupBox5.Controls.Add(this.txtCoacherName);
            this.groupBox5.Controls.Add(this.dtpDateOfJoined);
            this.groupBox5.Controls.Add(this.label94);
            this.groupBox5.Controls.Add(this.label93);
            this.groupBox5.Controls.Add(this.dtpLicenseExpire);
            this.groupBox5.Controls.Add(this.label90);
            this.groupBox5.Controls.Add(this.dtpLicenseIssued);
            this.groupBox5.Controls.Add(this.label91);
            this.groupBox5.Controls.Add(this.txtLicenseNo);
            this.groupBox5.Controls.Add(this.label92);
            this.groupBox5.Controls.Add(this.txtOtherName);
            this.groupBox5.Controls.Add(this.label89);
            this.groupBox5.Controls.Add(this.dtpPassportExpire);
            this.groupBox5.Controls.Add(this.label88);
            this.groupBox5.Controls.Add(this.dtpPassportIssued);
            this.groupBox5.Controls.Add(this.label87);
            this.groupBox5.Controls.Add(this.dtpNICIssued);
            this.groupBox5.Controls.Add(this.label86);
            this.groupBox5.Controls.Add(this.txtFullNameLineTwo);
            this.groupBox5.Controls.Add(this.txtPassportNo);
            this.groupBox5.Controls.Add(this.label73);
            this.groupBox5.Controls.Add(this.txtPreferName);
            this.groupBox5.Controls.Add(this.label72);
            this.groupBox5.Controls.Add(this.txtSurname);
            this.groupBox5.Controls.Add(this.label71);
            this.groupBox5.Controls.Add(this.txtEPFNo);
            this.groupBox5.Controls.Add(this.label70);
            this.groupBox5.Controls.Add(this.txtPINNo);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.txtNICNo);
            this.groupBox5.Controls.Add(this.txtNameInitial);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Location = new Point(6, 2);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new Size(0x250, 0x20a);
            this.groupBox5.TabIndex = 0x17;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Employee Details";
            this.groupBox6.Controls.Add(this.label82);
            this.groupBox6.Controls.Add(this.cmbCoacherStatus);
            this.groupBox6.Controls.Add(this.txtEmailAdd);
            this.groupBox6.Controls.Add(this.label97);
            this.groupBox6.Controls.Add(this.txtContactHomeTP);
            this.groupBox6.Controls.Add(this.label96);
            this.groupBox6.Controls.Add(this.txtContactMobile);
            this.groupBox6.Controls.Add(this.label95);
            this.groupBox6.Location = new Point(0, 410);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new Size(0x256, 0x60);
            this.groupBox6.TabIndex = 0x9f;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Contact Details";
            this.label82.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label82.Location = new Point(6, 0x47);
            this.label82.Name = "label82";
            this.label82.Size = new Size(0x61, 0x13);
            this.label82.TabIndex = 0x9a;
            this.label82.Text = "Status";
            this.label82.TextAlign = ContentAlignment.MiddleLeft;
            this.cmbCoacherStatus.DrawMode = DrawMode.OwnerDrawVariable;
            this.cmbCoacherStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbCoacherStatus.DropDownWidth = 0x11;
            this.cmbCoacherStatus.FormattingEnabled = true;
            this.cmbCoacherStatus.Location = new Point(0x6d, 0x45);
            this.cmbCoacherStatus.Name = "cmbCoacherStatus";
            this.cmbCoacherStatus.Size = new Size(0x98, 0x15);
            this.cmbCoacherStatus.TabIndex = 0x22;
            this.cmbCoacherStatus.ViewColumn = 0;
            this.cmbCoacherStatus.KeyPress += new KeyPressEventHandler(this.cmbCoacherStatus_KeyPress);
            this.txtEmailAdd.Location = new Point(0x6d, 0x2d);
            this.txtEmailAdd.MaxLength = 100;
            this.txtEmailAdd.Name = "txtEmailAdd";
            this.txtEmailAdd.Size = new Size(0x1ce, 20);
            this.txtEmailAdd.TabIndex = 0x21;
            this.txtEmailAdd.KeyPress += new KeyPressEventHandler(this.txtEmailAdd_KeyPress);
            this.label97.AutoSize = true;
            this.label97.Location = new Point(4, 0x30);
            this.label97.Name = "label97";
            this.label97.Size = new Size(0x4f, 13);
            this.label97.TabIndex = 0x92;
            this.label97.Text = "Email Address :";
            this.txtContactHomeTP.Location = new Point(0x175, 0x13);
            this.txtContactHomeTP.MaxLength = 20;
            this.txtContactHomeTP.Name = "txtContactHomeTP";
            this.txtContactHomeTP.Size = new Size(0xc6, 20);
            this.txtContactHomeTP.TabIndex = 0x20;
            this.txtContactHomeTP.KeyPress += new KeyPressEventHandler(this.txtContactHomeTP_KeyPress);
            this.label96.AutoSize = true;
            this.label96.Location = new Point(0x124, 0x16);
            this.label96.Name = "label96";
            this.label96.Size = new Size(0x4b, 13);
            this.label96.TabIndex = 0x91;
            this.label96.Text = "Home TP No :";
            this.txtContactMobile.Location = new Point(0x6d, 0x13);
            this.txtContactMobile.MaxLength = 20;
            this.txtContactMobile.Name = "txtContactMobile";
            this.txtContactMobile.Size = new Size(0xb7, 20);
            this.txtContactMobile.TabIndex = 0x1f;
            this.txtContactMobile.KeyPress += new KeyPressEventHandler(this.txtContactMobile_KeyPress);
            this.label95.AutoSize = true;
            this.label95.Location = new Point(4, 0x16);
            this.label95.Name = "label95";
            this.label95.Size = new Size(0x3d, 13);
            this.label95.TabIndex = 0x8f;
            this.label95.Text = "Mobile No :";
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label79);
            this.groupBox2.Controls.Add(this.label80);
            this.groupBox2.Controls.Add(this.label81);
            this.groupBox2.Controls.Add(this.txtTempCity);
            this.groupBox2.Controls.Add(this.txtTempTown);
            this.groupBox2.Controls.Add(this.txtTemproad);
            this.groupBox2.Controls.Add(this.txtTempNo);
            this.groupBox2.Location = new Point(300, 0x11d);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new Size(0x124, 120);
            this.groupBox2.TabIndex = 0x9e;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Temporally Address";
            this.label1.AutoSize = true;
            this.label1.Location = new Point(4, 0x12);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x1b, 13);
            this.label1.TabIndex = 0x73;
            this.label1.Text = "No :";
            this.label79.AutoSize = true;
            this.label79.Location = new Point(4, 70);
            this.label79.Name = "label79";
            this.label79.Size = new Size(0x25, 13);
            this.label79.TabIndex = 0x72;
            this.label79.Text = "Town:";
            this.label80.AutoSize = true;
            this.label80.Location = new Point(3, 0x5f);
            this.label80.Name = "label80";
            this.label80.Size = new Size(30, 13);
            this.label80.TabIndex = 0x71;
            this.label80.Text = "City :";
            this.label81.AutoSize = true;
            this.label81.Location = new Point(3, 0x29);
            this.label81.Name = "label81";
            this.label81.Size = new Size(0x24, 13);
            this.label81.TabIndex = 0x70;
            this.label81.Text = "Road:";
            this.txtTempCity.Location = new Point(0x43, 0x5d);
            this.txtTempCity.MaxLength = 100;
            this.txtTempCity.Name = "txtTempCity";
            this.txtTempCity.Size = new Size(0xcd, 20);
            this.txtTempCity.TabIndex = 30;
            this.txtTempCity.KeyPress += new KeyPressEventHandler(this.txtTempCity_KeyPress);
            this.txtTempTown.Location = new Point(0x43, 0x43);
            this.txtTempTown.MaxLength = 100;
            this.txtTempTown.Name = "txtTempTown";
            this.txtTempTown.Size = new Size(0xcd, 20);
            this.txtTempTown.TabIndex = 0x1d;
            this.txtTempTown.KeyPress += new KeyPressEventHandler(this.txtTempTown_KeyPress);
            this.txtTemproad.Location = new Point(0x43, 0x29);
            this.txtTemproad.MaxLength = 100;
            this.txtTemproad.Name = "txtTemproad";
            this.txtTemproad.Size = new Size(0xcd, 20);
            this.txtTemproad.TabIndex = 0x1c;
            this.txtTemproad.KeyPress += new KeyPressEventHandler(this.txtTemproad_KeyPress);
            this.txtTempNo.Location = new Point(0x43, 15);
            this.txtTempNo.MaxLength = 100;
            this.txtTempNo.Name = "txtTempNo";
            this.txtTempNo.Size = new Size(0xcd, 20);
            this.txtTempNo.TabIndex = 0x1b;
            this.txtTempNo.KeyPress += new KeyPressEventHandler(this.txtTempNo_KeyPress);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label78);
            this.groupBox1.Controls.Add(this.label76);
            this.groupBox1.Controls.Add(this.label77);
            this.groupBox1.Controls.Add(this.txtPermenantCity);
            this.groupBox1.Controls.Add(this.txtPermanentTown);
            this.groupBox1.Controls.Add(this.txtPermenentRoad);
            this.groupBox1.Controls.Add(this.txtPermanentNo);
            this.groupBox1.Location = new Point(0, 0x11d);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(0x124, 0x77);
            this.groupBox1.TabIndex = 0x9d;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Permanent Address";
            this.label3.AutoSize = true;
            this.label3.Location = new Point(4, 0x11);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x1b, 13);
            this.label3.TabIndex = 0x73;
            this.label3.Text = "No :";
            this.label78.AutoSize = true;
            this.label78.Location = new Point(4, 70);
            this.label78.Name = "label78";
            this.label78.Size = new Size(0x25, 13);
            this.label78.TabIndex = 0x72;
            this.label78.Text = "Town:";
            this.label76.AutoSize = true;
            this.label76.Location = new Point(4, 0x5f);
            this.label76.Name = "label76";
            this.label76.Size = new Size(30, 13);
            this.label76.TabIndex = 0x71;
            this.label76.Text = "City :";
            this.label77.AutoSize = true;
            this.label77.Location = new Point(4, 0x29);
            this.label77.Name = "label77";
            this.label77.Size = new Size(0x24, 13);
            this.label77.TabIndex = 0x70;
            this.label77.Text = "Road:";
            this.txtPermenantCity.Location = new Point(0x6f, 0x5c);
            this.txtPermenantCity.MaxLength = 100;
            this.txtPermenantCity.Name = "txtPermenantCity";
            this.txtPermenantCity.Size = new Size(0xa3, 20);
            this.txtPermenantCity.TabIndex = 0x1a;
            this.txtPermenantCity.KeyPress += new KeyPressEventHandler(this.txtPermenantCity_KeyPress);
            this.txtPermanentTown.Location = new Point(0x6f, 0x42);
            this.txtPermanentTown.MaxLength = 100;
            this.txtPermanentTown.Name = "txtPermanentTown";
            this.txtPermanentTown.Size = new Size(0xa3, 20);
            this.txtPermanentTown.TabIndex = 0x19;
            this.txtPermanentTown.KeyPress += new KeyPressEventHandler(this.txtPermanentTown_KeyPress);
            this.txtPermenentRoad.Location = new Point(0x6f, 40);
            this.txtPermenentRoad.MaxLength = 100;
            this.txtPermenentRoad.Name = "txtPermenentRoad";
            this.txtPermenentRoad.Size = new Size(0xa3, 20);
            this.txtPermenentRoad.TabIndex = 0x18;
            this.txtPermenentRoad.KeyPress += new KeyPressEventHandler(this.txtPermenentRoad_KeyPress);
            this.txtPermanentNo.Location = new Point(0x6f, 14);
            this.txtPermanentNo.MaxLength = 100;
            this.txtPermanentNo.Name = "txtPermanentNo";
            this.txtPermanentNo.Size = new Size(0xa3, 20);
            this.txtPermanentNo.TabIndex = 0x17;
            this.txtPermanentNo.KeyPress += new KeyPressEventHandler(this.txtPermanentNo_KeyPress);
            this.cmbBluedGroup.DrawMode = DrawMode.OwnerDrawVariable;
            this.cmbBluedGroup.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbBluedGroup.DropDownWidth = 0x11;
            this.cmbBluedGroup.FormattingEnabled = true;
            this.cmbBluedGroup.Location = new Point(0x1db, 0x100);
            this.cmbBluedGroup.Name = "cmbBluedGroup";
            this.cmbBluedGroup.Size = new Size(0x5f, 0x15);
            this.cmbBluedGroup.TabIndex = 0x16;
            this.cmbBluedGroup.ViewColumn = 0;
            this.cmbBluedGroup.KeyPress += new KeyPressEventHandler(this.cmbBluedGroup_KeyPress);
            this.label98.AutoSize = true;
            this.label98.Location = new Point(0x188, 0x103);
            this.label98.Name = "label98";
            this.label98.Size = new Size(0x48, 13);
            this.label98.TabIndex = 0x9c;
            this.label98.Text = "Blued Group :";
            this.cmbGender.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbGender.FormattingEnabled = true;
            this.cmbGender.Location = new Point(0x12a, 0x100);
            this.cmbGender.Name = "cmbGender";
            this.cmbGender.Size = new Size(0x59, 0x15);
            this.cmbGender.TabIndex = 0x15;
            this.cmbGender.KeyPress += new KeyPressEventHandler(this.cmbGender_KeyPress);
            this.label84.AutoSize = true;
            this.label84.Location = new Point(0xd8, 0x103);
            this.label84.Name = "label84";
            this.label84.Size = new Size(0x2a, 13);
            this.label84.TabIndex = 0x9a;
            this.label84.Text = "Gender";
            this.cmbMarried.DrawMode = DrawMode.OwnerDrawVariable;
            this.cmbMarried.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbMarried.DropDownWidth = 0x11;
            this.cmbMarried.FormattingEnabled = true;
            this.cmbMarried.Location = new Point(0x6f, 0xfd);
            this.cmbMarried.Name = "cmbMarried";
            this.cmbMarried.Size = new Size(0x63, 0x15);
            this.cmbMarried.TabIndex = 20;
            this.cmbMarried.ViewColumn = 0;
            this.cmbMarried.KeyPress += new KeyPressEventHandler(this.cmbMarried_KeyPress);
            this.label99.AutoSize = true;
            this.label99.Location = new Point(5, 0x100);
            this.label99.Name = "label99";
            this.label99.Size = new Size(0x51, 13);
            this.label99.TabIndex = 0x98;
            this.label99.Text = "Married Status :";
            this.txtCoacherCode.BackColor = Color.White;
            this.txtCoacherCode.Location = new Point(110, 13);
            this.txtCoacherCode.MaxLength = 10;
            this.txtCoacherCode.Name = "txtCoacherCode";
            this.txtCoacherCode.Size = new Size(0x67, 20);
            this.txtCoacherCode.TabIndex = 0;
            this.txtCoacherCode.KeyPress += new KeyPressEventHandler(this.txtCoacherCode_KeyPress);
            this.txtCoacherCode.TextChanged += new EventHandler(this.txtCoacherCode_TextChanged);
            this.dateTimeDOB.Format = DateTimePickerFormat.Short;
            this.dateTimeDOB.Location = new Point(110, 0xab);
            this.dateTimeDOB.Name = "dateTimeDOB";
            this.dateTimeDOB.Size = new Size(100, 20);
            this.dateTimeDOB.TabIndex = 11;
            this.dateTimeDOB.KeyPress += new KeyPressEventHandler(this.dateTimeDOB_KeyPress);
            this.txtReligion.Location = new Point(0x6f, 0x90);
            this.txtReligion.MaxLength = 100;
            this.txtReligion.Name = "txtReligion";
            this.txtReligion.Size = new Size(0xbf, 20);
            this.txtReligion.TabIndex = 9;
            this.txtReligion.KeyPress += new KeyPressEventHandler(this.txtReligion_KeyPress);
            this.dtpDateOfJoined.Format = DateTimePickerFormat.Short;
            this.dtpDateOfJoined.Location = new Point(0x1db, 0x92);
            this.dtpDateOfJoined.Name = "dtpDateOfJoined";
            this.dtpDateOfJoined.Size = new Size(0x5f, 20);
            this.dtpDateOfJoined.TabIndex = 10;
            this.dtpDateOfJoined.KeyPress += new KeyPressEventHandler(this.dtpDateOfJoined_KeyPress);
            this.label94.AutoSize = true;
            this.label94.Location = new Point(0x187, 0x95);
            this.label94.Name = "label94";
            this.label94.Size = new Size(0x4f, 13);
            this.label94.TabIndex = 0x95;
            this.label94.Text = "Date of Joined:";
            this.label93.AutoSize = true;
            this.label93.Location = new Point(4, 0x92);
            this.label93.Name = "label93";
            this.label93.Size = new Size(0x33, 13);
            this.label93.TabIndex = 0x72;
            this.label93.Text = "Religion :";
            this.dtpLicenseExpire.Format = DateTimePickerFormat.Short;
            this.dtpLicenseExpire.Location = new Point(0x1db, 0xe3);
            this.dtpLicenseExpire.Name = "dtpLicenseExpire";
            this.dtpLicenseExpire.Size = new Size(0x5f, 20);
            this.dtpLicenseExpire.TabIndex = 0x13;
            this.dtpLicenseExpire.KeyPress += new KeyPressEventHandler(this.dtpLicenseExpire_KeyPress);
            this.label90.AutoSize = true;
            this.label90.Location = new Point(0x187, 230);
            this.label90.Name = "label90";
            this.label90.Size = new Size(0x4a, 13);
            this.label90.TabIndex = 0x71;
            this.label90.Text = "Date of Expire";
            this.dtpLicenseIssued.Format = DateTimePickerFormat.Short;
            this.dtpLicenseIssued.Location = new Point(0x12a, 0xe2);
            this.dtpLicenseIssued.Name = "dtpLicenseIssued";
            this.dtpLicenseIssued.Size = new Size(0x58, 20);
            this.dtpLicenseIssued.TabIndex = 0x12;
            this.dtpLicenseIssued.KeyPress += new KeyPressEventHandler(this.dtpLicenseIssued_KeyPress);
            this.label91.AutoSize = true;
            this.label91.Location = new Point(0xd5, 230);
            this.label91.Name = "label91";
            this.label91.Size = new Size(0x4f, 13);
            this.label91.TabIndex = 0x6f;
            this.label91.Text = "Date of Issued:\r\n";
            this.txtLicenseNo.Location = new Point(110, 0xdf);
            this.txtLicenseNo.MaxLength = 20;
            this.txtLicenseNo.Name = "txtLicenseNo";
            this.txtLicenseNo.Size = new Size(100, 20);
            this.txtLicenseNo.TabIndex = 0x11;
            this.txtLicenseNo.KeyPress += new KeyPressEventHandler(this.txtLicenseNo_KeyPress);
            this.label92.AutoSize = true;
            this.label92.Location = new Point(4, 230);
            this.label92.Name = "label92";
            this.label92.Size = new Size(0x67, 13);
            this.label92.TabIndex = 0x6d;
            this.label92.Text = "Driving License No :";
            this.txtOtherName.Location = new Point(380, 0x77);
            this.txtOtherName.MaxLength = 100;
            this.txtOtherName.Name = "txtOtherName";
            this.txtOtherName.Size = new Size(0xbf, 20);
            this.txtOtherName.TabIndex = 8;
            this.txtOtherName.KeyPress += new KeyPressEventHandler(this.txtOtherName_KeyPress);
            this.label89.AutoSize = true;
            this.label89.Location = new Point(0x130, 0x77);
            this.label89.Name = "label89";
            this.label89.Size = new Size(70, 13);
            this.label89.TabIndex = 0x6b;
            this.label89.Text = "Other Name :";
            this.dtpPassportExpire.Format = DateTimePickerFormat.Short;
            this.dtpPassportExpire.Location = new Point(0x1db, 0xc7);
            this.dtpPassportExpire.Name = "dtpPassportExpire";
            this.dtpPassportExpire.Size = new Size(0x5f, 20);
            this.dtpPassportExpire.TabIndex = 0x10;
            this.dtpPassportExpire.KeyPress += new KeyPressEventHandler(this.dtpPassportExpire_KeyPress);
            this.label88.AutoSize = true;
            this.label88.Location = new Point(0x187, 0xca);
            this.label88.Name = "label88";
            this.label88.Size = new Size(0x4a, 13);
            this.label88.TabIndex = 0x69;
            this.label88.Text = "Date of Expire";
            this.dtpPassportIssued.Format = DateTimePickerFormat.Short;
            this.dtpPassportIssued.Location = new Point(0x12a, 0xc6);
            this.dtpPassportIssued.Name = "dtpPassportIssued";
            this.dtpPassportIssued.Size = new Size(0x58, 20);
            this.dtpPassportIssued.TabIndex = 15;
            this.dtpPassportIssued.KeyPress += new KeyPressEventHandler(this.dtpPassportIssued_KeyPress);
            this.label87.AutoSize = true;
            this.label87.Location = new Point(0xd5, 0xca);
            this.label87.Name = "label87";
            this.label87.Size = new Size(0x4f, 13);
            this.label87.TabIndex = 0x67;
            this.label87.Text = "Date of Issued:\r\n";
            this.dtpNICIssued.Format = DateTimePickerFormat.Short;
            this.dtpNICIssued.Location = new Point(0x1db, 0xab);
            this.dtpNICIssued.Name = "dtpNICIssued";
            this.dtpNICIssued.Size = new Size(0x5f, 20);
            this.dtpNICIssued.TabIndex = 13;
            this.dtpNICIssued.KeyPress += new KeyPressEventHandler(this.dtpNICIssued_KeyPress);
            this.label86.AutoSize = true;
            this.label86.Location = new Point(0x187, 0xae);
            this.label86.Name = "label86";
            this.label86.Size = new Size(0x4f, 13);
            this.label86.TabIndex = 0x65;
            this.label86.Text = "Date of Issued:";
            this.txtFullNameLineTwo.Location = new Point(0x6f, 0x5d);
            this.txtFullNameLineTwo.MaxLength = 100;
            this.txtFullNameLineTwo.Name = "txtFullNameLineTwo";
            this.txtFullNameLineTwo.Size = new Size(0x1cb, 20);
            this.txtFullNameLineTwo.TabIndex = 6;
            this.txtFullNameLineTwo.KeyPress += new KeyPressEventHandler(this.txtFullNameLineTwo_KeyPress);
            this.txtPassportNo.Location = new Point(110, 0xc7);
            this.txtPassportNo.MaxLength = 20;
            this.txtPassportNo.Name = "txtPassportNo";
            this.txtPassportNo.Size = new Size(100, 20);
            this.txtPassportNo.TabIndex = 14;
            this.txtPassportNo.KeyPress += new KeyPressEventHandler(this.txtPassportNo_KeyPress);
            this.label73.AutoSize = true;
            this.label73.Location = new Point(4, 0xcd);
            this.label73.Name = "label73";
            this.label73.Size = new Size(0x4a, 13);
            this.label73.TabIndex = 0x62;
            this.label73.Text = "Passport  No :";
            this.txtPreferName.Location = new Point(0x6f, 0x77);
            this.txtPreferName.MaxLength = 100;
            this.txtPreferName.Name = "txtPreferName";
            this.txtPreferName.Size = new Size(0xbf, 20);
            this.txtPreferName.TabIndex = 7;
            this.txtPreferName.KeyPress += new KeyPressEventHandler(this.txtPreferName_KeyPress);
            this.label72.AutoSize = true;
            this.label72.Location = new Point(0xd5, 0xaf);
            this.label72.Name = "label72";
            this.label72.Size = new Size(0x39, 13);
            this.label72.TabIndex = 0x60;
            this.label72.Text = "N I C  No :";
            this.txtSurname.Location = new Point(0x115, 0x29);
            this.txtSurname.MaxLength = 100;
            this.txtSurname.Name = "txtSurname";
            this.txtSurname.Size = new Size(0x125, 20);
            this.txtSurname.TabIndex = 4;
            this.txtSurname.KeyPress += new KeyPressEventHandler(this.txtSurname_KeyPress);
            this.label71.AutoSize = true;
            this.label71.Location = new Point(0xda, 0x2c);
            this.label71.Name = "label71";
            this.label71.Size = new Size(0x37, 13);
            this.label71.TabIndex = 0x5d;
            this.label71.Text = "Surname :";
            this.txtEPFNo.Location = new Point(0x115, 14);
            this.txtEPFNo.MaxLength = 10;
            this.txtEPFNo.Name = "txtEPFNo";
            this.txtEPFNo.Size = new Size(110, 20);
            this.txtEPFNo.TabIndex = 1;
            this.txtEPFNo.KeyPress += new KeyPressEventHandler(this.txtEPFNo_KeyPress);
            this.label70.AutoSize = true;
            this.label70.Location = new Point(0xdb, 0x10);
            this.label70.Name = "label70";
            this.label70.Size = new Size(0x38, 13);
            this.label70.TabIndex = 0x5b;
            this.label70.Text = "E P F  No:";
            this.txtPINNo.Location = new Point(0x1d1, 14);
            this.txtPINNo.MaxLength = 15;
            this.txtPINNo.Name = "txtPINNo";
            this.txtPINNo.Size = new Size(0x69, 20);
            this.txtPINNo.TabIndex = 2;
            this.txtPINNo.KeyPress += new KeyPressEventHandler(this.txtPINNo_KeyPress);
            this.label2.AutoSize = true;
            this.label2.Location = new Point(0x187, 0x11);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x36, 13);
            this.label2.TabIndex = 0x59;
            this.label2.Text = "P I N  No:";
            this.label4.AutoSize = true;
            this.label4.Location = new Point(5, 0x11);
            this.label4.Name = "label4";
            this.label4.Size = new Size(0x49, 13);
            this.label4.TabIndex = 0x57;
            this.label4.Text = "Employee No:";
            this.txtNICNo.Location = new Point(0x12a, 0xab);
            this.txtNICNo.MaxLength = 15;
            this.txtNICNo.Name = "txtNICNo";
            this.txtNICNo.Size = new Size(0x59, 20);
            this.txtNICNo.TabIndex = 12;
            this.txtNICNo.KeyPress += new KeyPressEventHandler(this.txtNICNo_KeyPress);
            this.txtNameInitial.Location = new Point(0x6f, 0x29);
            this.txtNameInitial.MaxLength = 10;
            this.txtNameInitial.Name = "txtNameInitial";
            this.txtNameInitial.Size = new Size(0x65, 20);
            this.txtNameInitial.TabIndex = 3;
            this.txtNameInitial.KeyPress += new KeyPressEventHandler(this.txtNameInitial_KeyPress);
            this.label5.AutoSize = true;
            this.label5.Location = new Point(4, 0xaf);
            this.label5.Name = "label5";
            this.label5.Size = new Size(0x45, 13);
            this.label5.TabIndex = 0x53;
            this.label5.Text = "Date of Birth:";
            this.label6.AutoSize = true;
            this.label6.Location = new Point(6, 0x77);
            this.label6.Name = "label6";
            this.label6.Size = new Size(0x48, 13);
            this.label6.TabIndex = 0x52;
            this.label6.Text = "Prefer Name :";
            this.label7.AutoSize = true;
            this.label7.Location = new Point(6, 70);
            this.label7.Name = "label7";
            this.label7.Size = new Size(0x47, 13);
            this.label7.TabIndex = 0x51;
            this.label7.Text = "Name in Full :";
            this.label8.AutoSize = true;
            this.label8.Location = new Point(6, 0x29);
            this.label8.Name = "label8";
            this.label8.Size = new Size(0x25, 13);
            this.label8.TabIndex = 80;
            this.label8.Text = "Initial :";
            this.panel1.Controls.Add(this.btnView);
            this.panel1.Controls.Add(this.btnRefresh);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Location = new Point(6, 530);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(0x250, 0x23);
            this.panel1.TabIndex = 0x21;
            this.btnView.Location = new Point(0xa1, 6);
            this.btnView.Name = "btnView";
            this.btnView.Size = new Size(0x49, 0x17);
            this.btnView.TabIndex = 0x27;
            this.btnView.Text = "&View";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new EventHandler(this.btnView_Click);
            this.btnRefresh.Location = new Point(0x52, 6);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new Size(0x49, 0x17);
            this.btnRefresh.TabIndex = 0x24;
            this.btnRefresh.Text = "&Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new EventHandler(this.btnRefresh_Click);
            this.btnSave.Location = new Point(3, 6);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new Size(0x49, 0x17);
            this.btnSave.TabIndex = 0x23;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new EventHandler(this.btnSave_Click);
            this.btnDelete.Location = new Point(240, 6);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new Size(0x49, 0x17);
            this.btnDelete.TabIndex = 0x25;
            this.btnDelete.Text = "D&elete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new EventHandler(this.btnDelete_Click);
            this.btnExit.FlatAppearance.BorderColor = Color.FromArgb(0x40, 0x40, 0x40);
            this.btnExit.FlatAppearance.BorderSize = 5;
            this.btnExit.Location = new Point(0x1f2, 6);
            this.btnExit.Margin = new Padding(0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new Size(0x53, 0x17);
            this.btnExit.TabIndex = 0x26;
            this.btnExit.Text = "E&xit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new EventHandler(this.btnExit_Click);
            this.errorCoacher.ContainerControl = this;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x25e, 0x239);
            base.Controls.Add(this.panel1);
            base.Controls.Add(this.groupBox5);
            base.Name = "frmCoacherMasterNew";
            this.Text = "Pool Attendance System";
            base.Load += new EventHandler(this.frmCoacherMasterNew_Load);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((ISupportInitialize) this.errorCoacher).EndInit();
            base.ResumeLayout(false);
        }

        private void InsertUpdate()
        {
            this.oCoacherMaster.LocationCode = this.cGlobleVariable.LocationCode;
            this.oCoacherMaster.CoacherCode = this.txtCoacherCode.Text;
            this.oCoacherMaster.Initials = this.txtNameInitial.Text;
            this.oCoacherMaster.FullNameLineOne = this.txtCoacherName.Text;
            this.oCoacherMaster.FullNameLineTwo = this.txtFullNameLineTwo.Text;
            this.oCoacherMaster.PrefName = this.txtPreferName.Text;
            this.oCoacherMaster.DateOfJoined = this.dtpDateOfJoined.Value;
            this.oCoacherMaster.Religion = this.txtReligion.Text;
            this.oCoacherMaster.OtherName = this.txtOtherName.Text;
            this.oCoacherMaster.NICNo = this.txtNICNo.Text;
            this.oCoacherMaster.NICDateOfIssued = this.dtpNICIssued.Value;
            this.oCoacherMaster.EPFNo = this.txtEPFNo.Text;
            this.oCoacherMaster.SurName = this.txtSurname.Text;
            this.oCoacherMaster.PINNumber = this.txtPINNo.Text;
            this.oCoacherMaster.Passport = this.txtPassportNo.Text;
            this.oCoacherMaster.PassportDateOfIssued = this.dtpPassportIssued.Value;
            this.oCoacherMaster.PassportDateOfExpire = this.dtpPassportExpire.Value;
            this.oCoacherMaster.DrivingLicenseNo = this.txtLicenseNo.Text;
            this.oCoacherMaster.DrivingLicenseIssued = this.dtpLicenseIssued.Value;
            this.oCoacherMaster.DrivingLicenseExpire = this.dtpLicenseExpire.Value;
            this.oCoacherMaster.DOB = this.dateTimeDOB.Value;
            this.oCoacherMaster.MarriedStatus = this.cmbMarried["fldMarriedStatusCode"].ToString();
            this.oCoacherMaster.PermanentAddNo = this.txtPermanentNo.Text;
            this.oCoacherMaster.PermanentRoad = this.txtPermenentRoad.Text;
            this.oCoacherMaster.PermanentTown = this.txtPermanentTown.Text;
            this.oCoacherMaster.PermanentCity = this.txtPermenantCity.Text;
            this.oCoacherMaster.TemporyAddNo = this.txtTempNo.Text;
            this.oCoacherMaster.TemporyRoad = this.txtTemproad.Text;
            this.oCoacherMaster.TemporyTown = this.txtTempTown.Text;
            this.oCoacherMaster.TemporyCity = this.txtTempCity.Text;
            this.oCoacherMaster.MobileNo = this.txtContactMobile.Text;
            this.oCoacherMaster.HomeTPNo = this.txtContactHomeTP.Text;
            this.oCoacherMaster.EmailAddress = this.txtEmailAdd.Text;
            this.oCoacherMaster.BluedGroup = this.cmbBluedGroup["fldBluedGroupCode"].ToString();
            this.oCoacherMaster.CoacherStatus = this.cmbCoacherStatus["fld_Status_Code"].ToString();
            this.oCoacherMaster.Gender = this.cmbGender.Text;
            this.cCoacherMaster.InsertUpdateData(this.oCoacherMaster);
        }

        public void LoadCoacherData()
        {
            this.oCoacherMaster = this.cCoacherMaster.GetCoacherData(this.cGlobleVariable.LocationCode, this.txtCoacherCode.Text);
            if (this.oCoacherMaster.CoacherIsExist)
            {
                this.txtCoacherCode.Text = this.oCoacherMaster.CoacherCode;
                this.txtNameInitial.Text = this.oCoacherMaster.Initials;
                this.txtCoacherName.Text = this.oCoacherMaster.FullNameLineOne;
                this.txtFullNameLineTwo.Text = this.oCoacherMaster.FullNameLineTwo;
                this.txtPreferName.Text = this.oCoacherMaster.PrefName;
                this.dtpDateOfJoined.Value = this.oCoacherMaster.DateOfJoined;
                this.txtReligion.Text = this.oCoacherMaster.Religion;
                this.txtOtherName.Text = this.oCoacherMaster.OtherName;
                this.txtNICNo.Text = this.oCoacherMaster.NICNo;
                this.dtpNICIssued.Value = this.oCoacherMaster.NICDateOfIssued;
                this.txtEPFNo.Text = this.oCoacherMaster.EPFNo;
                this.txtSurname.Text = this.oCoacherMaster.SurName;
                this.txtPINNo.Text = this.oCoacherMaster.PINNumber;
                this.txtPassportNo.Text = this.oCoacherMaster.Passport;
                this.dtpPassportIssued.Value = this.oCoacherMaster.PassportDateOfIssued;
                this.dtpPassportExpire.Value = this.oCoacherMaster.PassportDateOfExpire;
                this.txtLicenseNo.Text = this.oCoacherMaster.DrivingLicenseNo;
                this.dtpLicenseIssued.Value = this.oCoacherMaster.DrivingLicenseIssued;
                this.dtpLicenseExpire.Value = this.oCoacherMaster.DrivingLicenseExpire;
                this.dateTimeDOB.Value = this.oCoacherMaster.DOB;
                this.cmbMarried.SetText(this.cMarriedStatus.GetMarriedData(this.oCoacherMaster.MarriedStatus).MarriedStatus);
                this.txtPermanentNo.Text = this.oCoacherMaster.PermanentAddNo;
                this.txtPermenentRoad.Text = this.oCoacherMaster.PermanentRoad;
                this.txtPermanentTown.Text = this.oCoacherMaster.PermanentTown;
                this.txtPermenantCity.Text = this.oCoacherMaster.PermanentCity;
                this.txtTempNo.Text = this.oCoacherMaster.TemporyAddNo;
                this.txtTemproad.Text = this.oCoacherMaster.TemporyRoad;
                this.txtTempTown.Text = this.oCoacherMaster.TemporyTown;
                this.txtTempCity.Text = this.oCoacherMaster.TemporyCity;
                this.txtContactMobile.Text = this.oCoacherMaster.MobileNo;
                this.txtContactHomeTP.Text = this.oCoacherMaster.HomeTPNo;
                this.txtEmailAdd.Text = this.oCoacherMaster.EmailAddress;
                this.cmbBluedGroup.SetText(this.cBluedGroupMaster.GetBluedGroupData(this.oCoacherMaster.BluedGroup).BluedGroup);
                this.cmbCoacherStatus.SetText(this.oCoacherMaster.CoacherStatus);
                this.cmbGender.Text = this.oCoacherMaster.Gender;
            }
        }

        private void txtCoacherCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.cCommanMethods.MoveNextControl(e);
        }

        private void txtCoacherCode_TextChanged(object sender, EventArgs e)
        {
            this.LoadCoacherData();
        }

        private void txtCoacherName_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.cCommanMethods.MoveNextControl(e);
        }

        private void txtContactHomeTP_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.cCommanMethods.MoveNextControl(e);
        }

        private void txtContactMobile_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.cCommanMethods.MoveNextControl(e);
        }

        private void txtEmailAdd_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.cCommanMethods.MoveNextControl(e);
        }

        private void txtEPFNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.cCommanMethods.MoveNextControl(e);
        }

        private void txtFullNameLineTwo_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.cCommanMethods.MoveNextControl(e);
        }

        private void txtLicenseNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.cCommanMethods.MoveNextControl(e);
        }

        private void txtNameInitial_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.cCommanMethods.MoveNextControl(e);
        }

        private void txtNICNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.cCommanMethods.MoveNextControl(e);
        }

        private void txtOtherName_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.cCommanMethods.MoveNextControl(e);
        }

        private void txtPassportNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.cCommanMethods.MoveNextControl(e);
        }

        private void txtPermanentNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.cCommanMethods.MoveNextControl(e);
        }

        private void txtPermanentTown_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.cCommanMethods.MoveNextControl(e);
        }

        private void txtPermenantCity_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.cCommanMethods.MoveNextControl(e);
        }

        private void txtPermenentRoad_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.cCommanMethods.MoveNextControl(e);
        }

        private void txtPINNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.cCommanMethods.MoveNextControl(e);
        }

        private void txtPreferName_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.cCommanMethods.MoveNextControl(e);
        }

        private void txtReligion_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.cCommanMethods.MoveNextControl(e);
        }

        private void txtSurname_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.cCommanMethods.MoveNextControl(e);
        }

        private void txtTempCity_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.cCommanMethods.MoveNextControl(e);
        }

        private void txtTempNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.cCommanMethods.MoveNextControl(e);
        }

        private void txtTemproad_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.cCommanMethods.MoveNextControl(e);
        }

        private void txtTempTown_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.cCommanMethods.MoveNextControl(e);
        }

        private bool validateData()
        {
            bool flag = true;
            if (this.txtCoacherCode.Text == "")
            {
                this.errorCoacher.SetError(this.txtCoacherCode, "please enter Coacher Code");
                flag = false;
            }
            else
            {
                this.errorCoacher.SetError(this.txtCoacherCode, "");
                this.errorCoacher.Dispose();
            }
            if (this.txtCoacherName.Text == "")
            {
                this.errorCoacher.SetError(this.txtCoacherName, "Please enter Full name");
                flag = false;
            }
            else
            {
                this.errorCoacher.SetError(this.txtCoacherName, "");
                this.errorCoacher.Dispose();
            }
            if (this.txtNameInitial.Text == "")
            {
                this.errorCoacher.SetError(this.txtNameInitial, "Please enter Initials");
                flag = false;
            }
            else
            {
                this.errorCoacher.SetError(this.txtNameInitial, "");
                this.errorCoacher.Dispose();
            }
            if (this.txtSurname.Text == "")
            {
                this.errorCoacher.SetError(this.txtSurname, "Please enter Surname");
                flag = false;
            }
            else
            {
                this.errorCoacher.SetError(this.txtSurname, "");
                this.errorCoacher.Dispose();
            }
            if (this.txtEPFNo.Text == "")
            {
                this.errorCoacher.SetError(this.txtEPFNo, "Please enter EPF no");
                flag = false;
            }
            else
            {
                this.errorCoacher.SetError(this.txtEPFNo, "");
                this.errorCoacher.Dispose();
            }
            if (this.cmbGender.SelectedIndex < 0)
            {
                this.errorCoacher.SetError(this.cmbGender, "Please select the Gender");
                flag = false;
            }
            else
            {
                this.errorCoacher.SetError(this.cmbGender, "");
                this.errorCoacher.Dispose();
            }
            if (this.cmbCoacherStatus.SelectedIndex < 0)
            {
                this.errorCoacher.SetError(this.cmbCoacherStatus, "Please select the Status");
                flag = false;
            }
            else
            {
                this.errorCoacher.SetError(this.cmbCoacherStatus, "");
                this.errorCoacher.Dispose();
            }
            if (this.cmbMarried.SelectedIndex < 0)
            {
                this.errorCoacher.SetError(this.cmbMarried, "Please select the Married Status");
                flag = false;
            }
            else
            {
                this.errorCoacher.SetError(this.cmbMarried, "");
                this.errorCoacher.Dispose();
            }
            if (this.cmbBluedGroup.SelectedIndex < 0)
            {
                this.errorCoacher.SetError(this.cmbBluedGroup, "Please select the Bloud Group");
                return false;
            }
            this.errorCoacher.SetError(this.cmbBluedGroup, "");
            this.errorCoacher.Dispose();
            return flag;
        }
    }
}

