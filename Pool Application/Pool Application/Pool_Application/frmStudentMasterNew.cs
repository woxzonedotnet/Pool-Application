namespace Pool_Application
{
    using Business_Layer;
    using Business_Layer.Property_Layer;
    using JTG;
    using Pool_Application.Properties;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.IO;
    using System.Windows.Forms;

    public class frmStudentMasterNew : Form
    {
        public Button btnDelete;
        public Button btnExit;
        public Button btnFind;
        private Button btnPayment;
        private Button btnPaymentDetails;
        private Button btnPhoto;
        public Button btnRefresh;
        public Button btnSave;
        public Button btnView;
        private clsActiveCancalHistory cActiveCancelHistory = new clsActiveCancalHistory();
        private clsClassMaster cClassMaster = new clsClassMaster();
        private clsClassTimeTable cClassTimeTable = new clsClassTimeTable();
        private clsCoacherMaster cCoacherMaster = new clsCoacherMaster();
        private clsCommenMethods cCommanMethods = new clsCommenMethods();
        private clsGlobleVariable cGlobleVariable = new clsGlobleVariable();
        private DataGridViewTextBoxColumn clmEmpName;
        private DataGridViewTextBoxColumn clmNumber;
        private ColumnComboBox cmbClassName;
        private ColumnComboBox cmbPanalPayMethod;
        private ColumnComboBox cmbPaymentMethod;
        private ColumnComboBox cmbStudentStatus;
        private DataGridViewCheckBoxColumn Column1;
        private IContainer components = null;
        private clsPaymentDeatils cPaymentDeatil = new clsPaymentDeatils();
        private clsPaymentMethod cPaymentMethod = new clsPaymentMethod();
        private clsStatusMaster cStatusMaster = new clsStatusMaster();
        private clsStudentClassTimes cStudentClassTimes = new clsStudentClassTimes();
        private clsStudentMaster cStudentMaster = new clsStudentMaster();
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DateTimePicker dtpDateOfBirth;
        private DateTimePicker dtpDateOfJoin;
        private ErrorProvider errStudent;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private GroupBox groupBox4;
        private GroupBox groupBox6;
        private GroupBox groupBox7;
        private GroupBox groupBox9;
        private GroupBox grpPaymentDetails;
        private Label label1;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label label14;
        private Label label15;
        private Label label16;
        private Label label17;
        private Label label18;
        private Label label19;
        private Label label2;
        private Label label20;
        private Label label21;
        private Label label22;
        private Label label23;
        private Label label24;
        private Label label25;
        private Label label3;
        private Label label30;
        private Label label31;
        private Label label32;
        private Label label33;
        private Label label34;
        private Label label35;
        private Label label36;
        private Label label37;
        private Label label38;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label82;
        private Label label9;
        private Label label94;
        private Label label96;
        private Label label97;
        private DataGridView lstRegularEmployee;
        private objActiveCancalHistory oActiveCancelHistory = new objActiveCancalHistory();
        private objClassTimeTable oClassTimeTable = new objClassTimeTable();
        private objPaymentDeatils oPaymentDeatils = new objPaymentDeatils();
        private objStudentClassTimes oStudentClassTimes = new objStudentClassTimes();
        private objStudentMaster oStudentMaster = new objStudentMaster();
        private Panel panel1;
        private Panel panel2;
        private PictureBox pictureBox1;
        private PictureBox ptbPhotograph;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabControl tbcStudentDetails;
        private TextBox txtContactHomeTP;
        private TextBox txtDiscount;
        private TextBox txtEmailAdd;
        private TextBox txtfatherEmail;
        private TextBox txtfatherMobile;
        private TextBox txtFatherName;
        private TextBox txtFatherOccupation;
        private TextBox txtfatherPleaseAtWork;
        private TextBox txtfatherTelephone;
        private TextBox txtFees;
        private TextBox txtFullNameLineOne;
        private TextBox txtFullNameLineTwo;
        private TextBox txtHomeAddressLine1;
        private TextBox txtHomeAddressLine2;
        private TextBox txtInformarName;
        private TextBox txtInformarTel;
        private TextBox txtMotherEmail;
        private TextBox txtMotherMobile;
        private TextBox txtMotherName;
        private TextBox txtMotherOccupation;
        private TextBox txtMotherTelephone;
        private TextBox txtMotherWorked;
        private TextBox txtPamentAmount;
        private TextBox txtPinNumber;
        private TextBox txtRemarks;
        private TextBox txtSchoolName;
        private TextBox txtStudentNo;

        public frmStudentMasterNew()
        {
            this.InitializeComponent();
            this.cmbStudentStatus.Tag = "";
        }

        private void btnClassTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.cCommanMethods.MoveNextControl(e);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this record?", "Student Details", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.cStudentMaster.DeleteStudentData(this.cGlobleVariable.LocationCode, this.txtStudentNo.Text);
                this.cClassTimeTable.DeleteTimeDetails(this.cGlobleVariable.LocationCode, this.txtStudentNo.Text);
                this.cPaymentDeatil.DeletePaymentDeatils(this.cGlobleVariable.LocationCode, this.txtStudentNo.Text);
                MessageBox.Show("Successfully Deleted", "Student Detilas", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.RefreshPage();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            this.cCommanMethods.ClearForm(this);
            this.txtStudentNo.ReadOnly = false;
            this.txtStudentNo.Focus();
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            this.grpPaymentDetails.Location = new Point(0x88, 0x91);
            this.grpPaymentDetails.Visible = true;
        }

        private void btnPaymentDetails_Click(object sender, EventArgs e)
        {
            this.grpPaymentDetails.Visible = false;
        }

        private void btnPhoto_Click(object sender, EventArgs e)
        {
            string path = this.cCommanMethods.LoadDialog(this.ptbPhotograph);
            if ((path != "") && File.Exists(path))
            {
                this.ptbPhotograph.Tag = this.txtStudentNo.Text + this.GetFileType(this.GetFileName(path));
                this.btnPhoto.Tag = path;
            }
        }

        private void btnPhoto_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.cCommanMethods.MoveNextControl(e);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.RefreshPage();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.ValidateData())
            {
                this.oStudentMaster = this.cStudentMaster.GetStudentData(this.cGlobleVariable.LocationCode, this.txtStudentNo.Text.ToString());
                this.InsertUpdate();
                MessageBox.Show(this.cGlobleVariable.SeavedMessage, "Student Master details", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.RefreshPage();
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            this.ViewEmployee();
        }

        private void cmbClassName_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.cCommanMethods.MoveNextControl(e);
        }

        private void cmbClassName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbClassName.SelectedIndex > -1)
            {
                DataTable table = this.cClassTimeTable.GetClassTimeDetails(this.cGlobleVariable.LocationCode, this.cmbClassName["fldClassCode"].ToString(), this.cGlobleVariable.ActiveStatusCode);
                this.lstRegularEmployee.Rows.Clear();
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    int count = this.lstRegularEmployee.Rows.Count;
                    this.lstRegularEmployee.Rows.Add(1);
                    this.lstRegularEmployee.Rows[count].Cells[1].Value = table.Rows[i]["fldClassTimeCode"].ToString();
                    this.lstRegularEmployee.Rows[count].Cells[2].Value = table.Rows[i]["fldDayType"].ToString() + " : " + table.Rows[i]["fldInTime"].ToString() + " : " + table.Rows[i]["fldOutTime"].ToString();
                }
            }
        }

        private void cmbStudentStatus_KeyPress(object sender, KeyPressEventArgs e)
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

        private void dtpDateOfBirth_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.cCommanMethods.MoveNextControl(e);
        }

        private void dtpDateOfJoin_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.cCommanMethods.MoveNextControl(e);
        }

        private void FileCopyToServer(string FilePath, string FileName)
        {
            if (FilePath != "")
            {
                if (File.Exists(this.cGlobleVariable.strImagePath + @"\" + FileName))
                {
                    File.Delete(this.cGlobleVariable.strImagePath + @"\" + FileName);
                }
                File.Copy(FilePath, this.cGlobleVariable.strImagePath + @"\" + FileName, true);
            }
        }

        private void frmStudentMasterNew_Load(object sender, EventArgs e)
        {
            this.LoadCombos();
            this.NextStudentNumber();
        }

        private string GetFileName(string strPath)
        {
            int startIndex = strPath.LastIndexOf(@"\") + 1;
            int length = strPath.Length - startIndex;
            return strPath.Substring(startIndex, length);
        }

        private string GetFileType(string strFileName)
        {
            int startIndex = strFileName.LastIndexOf(".");
            int length = strFileName.Length - startIndex;
            return strFileName.Substring(startIndex, length);
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            DataGridViewCellStyle style = new DataGridViewCellStyle();
            DataGridViewCellStyle style2 = new DataGridViewCellStyle();
            DataGridViewCellStyle style3 = new DataGridViewCellStyle();
            DataGridViewCellStyle style4 = new DataGridViewCellStyle();
            ComponentResourceManager manager = new ComponentResourceManager(typeof(frmStudentMasterNew));
            DataGridViewCellStyle style5 = new DataGridViewCellStyle();
            DataGridViewCellStyle style6 = new DataGridViewCellStyle();
            this.tbcStudentDetails = new TabControl();
            this.tabPage1 = new TabPage();
            this.lstRegularEmployee = new DataGridView();
            this.Column1 = new DataGridViewCheckBoxColumn();
            this.clmNumber = new DataGridViewTextBoxColumn();
            this.clmEmpName = new DataGridViewTextBoxColumn();
            this.label38 = new Label();
            this.btnPayment = new Button();
            this.txtRemarks = new TextBox();
            this.btnPhoto = new Button();
            this.label23 = new Label();
            this.txtFees = new TextBox();
            this.ptbPhotograph = new PictureBox();
            this.label14 = new Label();
            this.txtPinNumber = new TextBox();
            this.label21 = new Label();
            this.label13 = new Label();
            this.cmbClassName = new ColumnComboBox();
            this.dtpDateOfJoin = new DateTimePicker();
            this.label94 = new Label();
            this.groupBox3 = new GroupBox();
            this.txtInformarTel = new TextBox();
            this.txtInformarName = new TextBox();
            this.label20 = new Label();
            this.label22 = new Label();
            this.txtSchoolName = new TextBox();
            this.label12 = new Label();
            this.dtpDateOfBirth = new DateTimePicker();
            this.label9 = new Label();
            this.groupBox6 = new GroupBox();
            this.txtHomeAddressLine2 = new TextBox();
            this.txtHomeAddressLine1 = new TextBox();
            this.label3 = new Label();
            this.txtEmailAdd = new TextBox();
            this.label97 = new Label();
            this.txtContactHomeTP = new TextBox();
            this.label96 = new Label();
            this.txtFullNameLineTwo = new TextBox();
            this.txtFullNameLineOne = new TextBox();
            this.txtStudentNo = new TextBox();
            this.label2 = new Label();
            this.label5 = new Label();
            this.tabPage2 = new TabPage();
            this.groupBox2 = new GroupBox();
            this.groupBox9 = new GroupBox();
            this.cmbStudentStatus = new ColumnComboBox();
            this.label82 = new Label();
            this.groupBox4 = new GroupBox();
            this.txtMotherEmail = new TextBox();
            this.label8 = new Label();
            this.label15 = new Label();
            this.txtMotherWorked = new TextBox();
            this.txtMotherMobile = new TextBox();
            this.label24 = new Label();
            this.txtMotherTelephone = new TextBox();
            this.label25 = new Label();
            this.txtMotherOccupation = new TextBox();
            this.label1 = new Label();
            this.txtMotherName = new TextBox();
            this.label6 = new Label();
            this.groupBox1 = new GroupBox();
            this.txtfatherEmail = new TextBox();
            this.label19 = new Label();
            this.label11 = new Label();
            this.txtfatherPleaseAtWork = new TextBox();
            this.label4 = new Label();
            this.txtfatherMobile = new TextBox();
            this.label18 = new Label();
            this.txtFatherName = new TextBox();
            this.txtFatherOccupation = new TextBox();
            this.txtfatherTelephone = new TextBox();
            this.label17 = new Label();
            this.label7 = new Label();
            this.panel1 = new Panel();
            this.btnView = new Button();
            this.btnFind = new Button();
            this.btnRefresh = new Button();
            this.btnSave = new Button();
            this.btnDelete = new Button();
            this.btnExit = new Button();
            this.errStudent = new ErrorProvider(this.components);
            this.panel2 = new Panel();
            this.pictureBox1 = new PictureBox();
            this.label30 = new Label();
            this.label31 = new Label();
            this.grpPaymentDetails = new GroupBox();
            this.label10 = new Label();
            this.label16 = new Label();
            this.label32 = new Label();
            this.btnPaymentDetails = new Button();
            this.label37 = new Label();
            this.label33 = new Label();
            this.cmbPaymentMethod = new ColumnComboBox();
            this.groupBox7 = new GroupBox();
            this.txtPamentAmount = new TextBox();
            this.label34 = new Label();
            this.cmbPanalPayMethod = new ColumnComboBox();
            this.label35 = new Label();
            this.txtDiscount = new TextBox();
            this.label36 = new Label();
            this.dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new DataGridViewTextBoxColumn();
            this.tbcStudentDetails.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((ISupportInitialize) this.lstRegularEmployee).BeginInit();
            ((ISupportInitialize) this.ptbPhotograph).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((ISupportInitialize) this.errStudent).BeginInit();
            this.panel2.SuspendLayout();
            ((ISupportInitialize) this.pictureBox1).BeginInit();
            this.grpPaymentDetails.SuspendLayout();
            this.groupBox7.SuspendLayout();
            base.SuspendLayout();
            this.tbcStudentDetails.Controls.Add(this.tabPage1);
            this.tbcStudentDetails.Controls.Add(this.tabPage2);
            this.tbcStudentDetails.Location = new Point(4, 70);
            this.tbcStudentDetails.Name = "tbcStudentDetails";
            this.tbcStudentDetails.SelectedIndex = 0;
            this.tbcStudentDetails.Size = new Size(0x250, 0x1f1);
            this.tbcStudentDetails.TabIndex = 0;
            this.tabPage1.Controls.Add(this.lstRegularEmployee);
            this.tabPage1.Controls.Add(this.label38);
            this.tabPage1.Controls.Add(this.btnPayment);
            this.tabPage1.Controls.Add(this.txtRemarks);
            this.tabPage1.Controls.Add(this.btnPhoto);
            this.tabPage1.Controls.Add(this.label23);
            this.tabPage1.Controls.Add(this.txtFees);
            this.tabPage1.Controls.Add(this.ptbPhotograph);
            this.tabPage1.Controls.Add(this.label14);
            this.tabPage1.Controls.Add(this.txtPinNumber);
            this.tabPage1.Controls.Add(this.label21);
            this.tabPage1.Controls.Add(this.label13);
            this.tabPage1.Controls.Add(this.cmbClassName);
            this.tabPage1.Controls.Add(this.dtpDateOfJoin);
            this.tabPage1.Controls.Add(this.label94);
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.txtSchoolName);
            this.tabPage1.Controls.Add(this.label12);
            this.tabPage1.Controls.Add(this.dtpDateOfBirth);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.groupBox6);
            this.tabPage1.Controls.Add(this.txtFullNameLineTwo);
            this.tabPage1.Controls.Add(this.txtFullNameLineOne);
            this.tabPage1.Controls.Add(this.txtStudentNo);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.tabPage1.Location = new Point(4, 0x16);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new Padding(3);
            this.tabPage1.Size = new Size(0x248, 0x1d7);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Student Details";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.lstRegularEmployee.AllowUserToAddRows = false;
            this.lstRegularEmployee.AllowUserToDeleteRows = false;
            this.lstRegularEmployee.AllowUserToResizeColumns = false;
            this.lstRegularEmployee.AllowUserToResizeRows = false;
            this.lstRegularEmployee.BackgroundColor = SystemColors.ControlLightLight;
            style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            style.BackColor = SystemColors.Control;
            style.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            style.ForeColor = SystemColors.WindowText;
            style.SelectionBackColor = SystemColors.Highlight;
            style.SelectionForeColor = SystemColors.HighlightText;
            style.WrapMode = DataGridViewTriState.True;
            this.lstRegularEmployee.ColumnHeadersDefaultCellStyle = style;
            this.lstRegularEmployee.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.lstRegularEmployee.Columns.AddRange(new DataGridViewColumn[] { this.Column1, this.clmNumber, this.clmEmpName });
            this.lstRegularEmployee.Location = new Point(0x86, 0x137);
            this.lstRegularEmployee.Name = "lstRegularEmployee";
            this.lstRegularEmployee.RowHeadersVisible = false;
            this.lstRegularEmployee.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.lstRegularEmployee.Size = new Size(0x121, 0x5d);
            this.lstRegularEmployee.TabIndex = 200;
            style2.Alignment = DataGridViewContentAlignment.TopLeft;
            style2.NullValue = false;
            this.Column1.DefaultCellStyle = style2;
            this.Column1.HeaderText = "";
            this.Column1.Name = "Column1";
            this.Column1.Width = 0x19;
            style3.Alignment = DataGridViewContentAlignment.TopLeft;
            this.clmNumber.DefaultCellStyle = style3;
            this.clmNumber.HeaderText = "Number";
            this.clmNumber.Name = "clmNumber";
            this.clmNumber.ReadOnly = true;
            this.clmNumber.Visible = false;
            this.clmNumber.Width = 70;
            style4.Alignment = DataGridViewContentAlignment.TopLeft;
            this.clmEmpName.DefaultCellStyle = style4;
            this.clmEmpName.HeaderText = "Class Times";
            this.clmEmpName.Name = "clmEmpName";
            this.clmEmpName.ReadOnly = true;
            this.clmEmpName.Width = 0xeb;
            this.label38.AutoSize = true;
            this.label38.Location = new Point(0x16, 0x142);
            this.label38.Name = "label38";
            this.label38.Size = new Size(0x39, 13);
            this.label38.TabIndex = 0xc7;
            this.label38.Text = "Class Time";
            this.btnPayment.Location = new Point(0x15d, 0x199);
            this.btnPayment.Name = "btnPayment";
            this.btnPayment.Size = new Size(0x1b, 0x16);
            this.btnPayment.TabIndex = 0xc5;
            this.btnPayment.Text = "...";
            this.btnPayment.UseVisualStyleBackColor = true;
            this.btnPayment.Click += new EventHandler(this.btnPayment_Click);
            this.txtRemarks.Location = new Point(0x86, 0x1b5);
            this.txtRemarks.MaxLength = 100;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new Size(0x1b9, 0x15);
            this.txtRemarks.TabIndex = 0x11;
            this.txtRemarks.KeyPress += new KeyPressEventHandler(this.txtRemarks_KeyPress);
            this.btnPhoto.Location = new Point(0x1ad, 0x14f);
            this.btnPhoto.Name = "btnPhoto";
            this.btnPhoto.Size = new Size(0x38, 0x31);
            this.btnPhoto.TabIndex = 15;
            this.btnPhoto.Text = "Photo >>";
            this.btnPhoto.UseVisualStyleBackColor = true;
            this.btnPhoto.Click += new EventHandler(this.btnPhoto_Click);
            this.btnPhoto.KeyPress += new KeyPressEventHandler(this.btnPhoto_KeyPress);
            this.label23.AutoSize = true;
            this.label23.Location = new Point(0x16, 0x1b5);
            this.label23.Name = "label23";
            this.label23.Size = new Size(0x30, 13);
            this.label23.TabIndex = 0xc4;
            this.label23.Text = "Remarks";
            this.txtFees.Location = new Point(0x87, 410);
            this.txtFees.MaxLength = 20;
            this.txtFees.Name = "txtFees";
            this.txtFees.Size = new Size(0xd0, 0x15);
            this.txtFees.TabIndex = 0x10;
            this.txtFees.KeyPress += new KeyPressEventHandler(this.txtFees_KeyPress);
            this.ptbPhotograph.BackgroundImageLayout = ImageLayout.Stretch;
            this.ptbPhotograph.BorderStyle = BorderStyle.Fixed3D;
            this.ptbPhotograph.Image = (Image) manager.GetObject("ptbPhotograph.Image");
            this.ptbPhotograph.InitialImage = null;
            this.ptbPhotograph.Location = new Point(0x1eb, 0x137);
            this.ptbPhotograph.Name = "ptbPhotograph";
            this.ptbPhotograph.Size = new Size(0x57, 0x63);
            this.ptbPhotograph.SizeMode = PictureBoxSizeMode.StretchImage;
            this.ptbPhotograph.TabIndex = 0xc0;
            this.ptbPhotograph.TabStop = false;
            this.ptbPhotograph.Tag = "operator_128.jpg";
            this.label14.AutoSize = true;
            this.label14.Location = new Point(0x16, 410);
            this.label14.Name = "label14";
            this.label14.Size = new Size(30, 13);
            this.label14.TabIndex = 0xc3;
            this.label14.Text = "Fees";
            this.txtPinNumber.Location = new Point(0x87, 0x103);
            this.txtPinNumber.MaxLength = 20;
            this.txtPinNumber.Name = "txtPinNumber";
            this.txtPinNumber.Size = new Size(0xa4, 0x15);
            this.txtPinNumber.TabIndex = 11;
            this.txtPinNumber.KeyPress += new KeyPressEventHandler(this.txtPinNumber_KeyPress);
            this.label21.AutoSize = true;
            this.label21.Location = new Point(0x17, 0x106);
            this.label21.Name = "label21";
            this.label21.Size = new Size(0x40, 13);
            this.label21.TabIndex = 0xc1;
            this.label21.Text = "PIN Number";
            this.label13.AutoSize = true;
            this.label13.Location = new Point(0x17, 0x121);
            this.label13.Name = "label13";
            this.label13.Size = new Size(0x20, 13);
            this.label13.TabIndex = 190;
            this.label13.Text = "Level";
            this.cmbClassName.DrawMode = DrawMode.OwnerDrawVariable;
            this.cmbClassName.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbClassName.DropDownWidth = 0x11;
            this.cmbClassName.FormattingEnabled = true;
            this.cmbClassName.Location = new Point(0x86, 0x11e);
            this.cmbClassName.Name = "cmbClassName";
            this.cmbClassName.Size = new Size(210, 0x16);
            this.cmbClassName.TabIndex = 13;
            this.cmbClassName.ViewColumn = 0;
            this.cmbClassName.SelectedIndexChanged += new EventHandler(this.cmbClassName_SelectedIndexChanged);
            this.cmbClassName.KeyPress += new KeyPressEventHandler(this.cmbClassName_KeyPress);
            this.dtpDateOfJoin.Format = DateTimePickerFormat.Short;
            this.dtpDateOfJoin.Location = new Point(0x1a3, 0x102);
            this.dtpDateOfJoin.Name = "dtpDateOfJoin";
            this.dtpDateOfJoin.Size = new Size(0x55, 0x15);
            this.dtpDateOfJoin.TabIndex = 12;
            this.dtpDateOfJoin.KeyPress += new KeyPressEventHandler(this.dtpDateOfJoin_KeyPress);
            this.label94.AutoSize = true;
            this.label94.Location = new Point(0x131, 0x108);
            this.label94.Name = "label94";
            this.label94.Size = new Size(0x6c, 13);
            this.label94.TabIndex = 0xbd;
            this.label94.Text = "Date of Registration:";
            this.groupBox3.Controls.Add(this.txtInformarTel);
            this.groupBox3.Controls.Add(this.txtInformarName);
            this.groupBox3.Controls.Add(this.label20);
            this.groupBox3.Controls.Add(this.label22);
            this.groupBox3.Location = new Point(8, 0xcd);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new Size(0x23d, 0x33);
            this.groupBox3.TabIndex = 0xa4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "In case of an emergency please inform  ";
            this.txtInformarTel.Location = new Point(0x191, 0x12);
            this.txtInformarTel.MaxLength = 100;
            this.txtInformarTel.Name = "txtInformarTel";
            this.txtInformarTel.Size = new Size(0xa2, 0x15);
            this.txtInformarTel.TabIndex = 10;
            this.txtInformarTel.KeyPress += new KeyPressEventHandler(this.txtInformarTel_KeyPress);
            this.txtInformarName.Location = new Point(0x80, 0x11);
            this.txtInformarName.MaxLength = 100;
            this.txtInformarName.Name = "txtInformarName";
            this.txtInformarName.Size = new Size(0xa4, 0x15);
            this.txtInformarName.TabIndex = 9;
            this.txtInformarName.KeyPress += new KeyPressEventHandler(this.txtInformarName_KeyPress);
            this.label20.AutoSize = true;
            this.label20.Location = new Point(0x13, 0x15);
            this.label20.Name = "label20";
            this.label20.Size = new Size(0x69, 13);
            this.label20.TabIndex = 0x93;
            this.label20.Text = "Name && Relationship";
            this.label22.AutoSize = true;
            this.label22.Location = new Point(0x13a, 20);
            this.label22.Name = "label22";
            this.label22.Size = new Size(0x49, 13);
            this.label22.TabIndex = 0x91;
            this.label22.Text = "Telephone No";
            this.txtSchoolName.Location = new Point(0x114, 0xb5);
            this.txtSchoolName.MaxLength = 100;
            this.txtSchoolName.Name = "txtSchoolName";
            this.txtSchoolName.Size = new Size(0x12b, 0x15);
            this.txtSchoolName.TabIndex = 8;
            this.txtSchoolName.KeyPress += new KeyPressEventHandler(this.txtSchoolName_KeyPress);
            this.label12.AutoSize = true;
            this.label12.Location = new Point(0xe3, 0xb8);
            this.label12.Name = "label12";
            this.label12.Size = new Size(0x26, 13);
            this.label12.TabIndex = 0xa3;
            this.label12.Text = "School";
            this.dtpDateOfBirth.Format = DateTimePickerFormat.Short;
            this.dtpDateOfBirth.Location = new Point(0x87, 0xb2);
            this.dtpDateOfBirth.Name = "dtpDateOfBirth";
            this.dtpDateOfBirth.Size = new Size(0x56, 0x15);
            this.dtpDateOfBirth.TabIndex = 7;
            this.dtpDateOfBirth.KeyPress += new KeyPressEventHandler(this.dtpDateOfBirth_KeyPress);
            this.label9.AutoSize = true;
            this.label9.Location = new Point(0x18, 0xb2);
            this.label9.Name = "label9";
            this.label9.Size = new Size(0x48, 13);
            this.label9.TabIndex = 0xa2;
            this.label9.Text = "Date of Birth:";
            this.groupBox6.Controls.Add(this.txtHomeAddressLine2);
            this.groupBox6.Controls.Add(this.txtHomeAddressLine1);
            this.groupBox6.Controls.Add(this.label3);
            this.groupBox6.Controls.Add(this.txtEmailAdd);
            this.groupBox6.Controls.Add(this.label97);
            this.groupBox6.Controls.Add(this.txtContactHomeTP);
            this.groupBox6.Controls.Add(this.label96);
            this.groupBox6.Location = new Point(2, 0x51);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new Size(0x23d, 0x5e);
            this.groupBox6.TabIndex = 0x5d;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Contact Details";
            this.txtHomeAddressLine2.Location = new Point(130, 0x2a);
            this.txtHomeAddressLine2.MaxLength = 100;
            this.txtHomeAddressLine2.Name = "txtHomeAddressLine2";
            this.txtHomeAddressLine2.Size = new Size(0x1b3, 0x15);
            this.txtHomeAddressLine2.TabIndex = 4;
            this.txtHomeAddressLine2.TextChanged += new EventHandler(this.txtHomeAddressLine2_TextChanged);
            this.txtHomeAddressLine2.KeyPress += new KeyPressEventHandler(this.txtHomeAddressLine2_KeyPress);
            this.txtHomeAddressLine1.Location = new Point(130, 0x12);
            this.txtHomeAddressLine1.MaxLength = 100;
            this.txtHomeAddressLine1.Name = "txtHomeAddressLine1";
            this.txtHomeAddressLine1.Size = new Size(0x1b3, 0x15);
            this.txtHomeAddressLine1.TabIndex = 3;
            this.txtHomeAddressLine1.TextChanged += new EventHandler(this.txtHomeAddressLine1_TextChanged);
            this.txtHomeAddressLine1.KeyPress += new KeyPressEventHandler(this.txtHomeAddressLine1_KeyPress);
            this.label3.AutoSize = true;
            this.label3.Location = new Point(20, 0x17);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x4c, 13);
            this.label3.TabIndex = 0x93;
            this.label3.Text = "Home Address";
            this.label3.Click += new EventHandler(this.label3_Click);
            this.txtEmailAdd.Location = new Point(0x15c, 0x42);
            this.txtEmailAdd.MaxLength = 100;
            this.txtEmailAdd.Name = "txtEmailAdd";
            this.txtEmailAdd.Size = new Size(0xd9, 0x15);
            this.txtEmailAdd.TabIndex = 6;
            this.txtEmailAdd.TextChanged += new EventHandler(this.txtEmailAdd_TextChanged);
            this.txtEmailAdd.KeyPress += new KeyPressEventHandler(this.txtEmailAdd_KeyPress);
            this.label97.AutoSize = true;
            this.label97.Location = new Point(300, 0x45);
            this.label97.Name = "label97";
            this.label97.Size = new Size(0x26, 13);
            this.label97.TabIndex = 0x92;
            this.label97.Text = "Email :";
            this.label97.Click += new EventHandler(this.label97_Click);
            this.txtContactHomeTP.Location = new Point(130, 0x42);
            this.txtContactHomeTP.MaxLength = 20;
            this.txtContactHomeTP.Name = "txtContactHomeTP";
            this.txtContactHomeTP.Size = new Size(0xa4, 0x15);
            this.txtContactHomeTP.TabIndex = 5;
            this.txtContactHomeTP.TextChanged += new EventHandler(this.txtContactHomeTP_TextChanged);
            this.txtContactHomeTP.KeyPress += new KeyPressEventHandler(this.txtContactHomeTP_KeyPress);
            this.label96.AutoSize = true;
            this.label96.Location = new Point(0x16, 0x45);
            this.label96.Name = "label96";
            this.label96.Size = new Size(0x49, 13);
            this.label96.TabIndex = 0x91;
            this.label96.Text = "Telephone No";
            this.label96.Click += new EventHandler(this.label96_Click);
            this.txtFullNameLineTwo.Location = new Point(0x84, 0x3a);
            this.txtFullNameLineTwo.MaxLength = 100;
            this.txtFullNameLineTwo.Name = "txtFullNameLineTwo";
            this.txtFullNameLineTwo.Size = new Size(0x1b3, 0x15);
            this.txtFullNameLineTwo.TabIndex = 2;
            this.txtFullNameLineTwo.KeyPress += new KeyPressEventHandler(this.txtFullNameLineTwo_KeyPress);
            this.txtFullNameLineOne.Location = new Point(0x84, 0x23);
            this.txtFullNameLineOne.MaxLength = 100;
            this.txtFullNameLineOne.Name = "txtFullNameLineOne";
            this.txtFullNameLineOne.Size = new Size(0x1b3, 0x15);
            this.txtFullNameLineOne.TabIndex = 1;
            this.txtFullNameLineOne.KeyPress += new KeyPressEventHandler(this.txtFullNameLineOne_KeyPress);
            this.txtStudentNo.BackColor = Color.White;
            this.txtStudentNo.Location = new Point(0x84, 12);
            this.txtStudentNo.MaxLength = 10;
            this.txtStudentNo.Name = "txtStudentNo";
            this.txtStudentNo.ReadOnly = true;
            this.txtStudentNo.Size = new Size(0xa4, 0x15);
            this.txtStudentNo.TabIndex = 0;
            this.txtStudentNo.TextChanged += new EventHandler(this.txtStudentNo_TextChanged);
            this.txtStudentNo.KeyPress += new KeyPressEventHandler(this.txtStudentNo_KeyPress);
            this.label2.AutoSize = true;
            this.label2.Location = new Point(0x16, 15);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x41, 13);
            this.label2.TabIndex = 0x5c;
            this.label2.Text = "Student No:";
            this.label5.AutoSize = true;
            this.label5.Location = new Point(0x16, 0x26);
            this.label5.Name = "label5";
            this.label5.Size = new Size(0x47, 13);
            this.label5.TabIndex = 0x5b;
            this.label5.Text = "Name in Full :";
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.tabPage2.Location = new Point(4, 0x16);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new Padding(3);
            this.tabPage2.Size = new Size(0x248, 0x1d7);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Parents/ Guardian Details";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.groupBox2.Controls.Add(this.groupBox9);
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.groupBox1);
            this.groupBox2.Location = new Point(6, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new Size(0x23d, 0x1cb);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Parents/ Guardian Details";
            this.groupBox9.Controls.Add(this.cmbStudentStatus);
            this.groupBox9.Controls.Add(this.label82);
            this.groupBox9.Location = new Point(-1, 0x194);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new Size(0x23d, 0x36);
            this.groupBox9.TabIndex = 0xa5;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Activation";
            this.cmbStudentStatus.DrawMode = DrawMode.OwnerDrawVariable;
            this.cmbStudentStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbStudentStatus.DropDownWidth = 0x11;
            this.cmbStudentStatus.FormattingEnabled = true;
            this.cmbStudentStatus.Location = new Point(0x6d, 0x10);
            this.cmbStudentStatus.Name = "cmbStudentStatus";
            this.cmbStudentStatus.Size = new Size(0xa3, 0x16);
            this.cmbStudentStatus.TabIndex = 30;
            this.cmbStudentStatus.ViewColumn = 0;
            this.cmbStudentStatus.KeyPress += new KeyPressEventHandler(this.cmbStudentStatus_KeyPress);
            this.label82.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label82.Location = new Point(12, 0x10);
            this.label82.Name = "label82";
            this.label82.Size = new Size(0x70, 0x13);
            this.label82.TabIndex = 0x99;
            this.label82.Text = "Status";
            this.label82.TextAlign = ContentAlignment.MiddleLeft;
            this.groupBox4.Controls.Add(this.txtMotherEmail);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Controls.Add(this.txtMotherWorked);
            this.groupBox4.Controls.Add(this.txtMotherMobile);
            this.groupBox4.Controls.Add(this.label24);
            this.groupBox4.Controls.Add(this.txtMotherTelephone);
            this.groupBox4.Controls.Add(this.label25);
            this.groupBox4.Controls.Add(this.txtMotherOccupation);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.txtMotherName);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Location = new Point(1, 0xe9);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new Size(0x23c, 0xab);
            this.groupBox4.TabIndex = 0xa2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Mother Details";
            this.txtMotherEmail.Location = new Point(0x68, 0x80);
            this.txtMotherEmail.MaxLength = 100;
            this.txtMotherEmail.Name = "txtMotherEmail";
            this.txtMotherEmail.Size = new Size(0x1c5, 0x15);
            this.txtMotherEmail.TabIndex = 0x1d;
            this.txtMotherEmail.KeyPress += new KeyPressEventHandler(this.txtMotherEmail_KeyPress);
            this.label8.AutoSize = true;
            this.label8.Location = new Point(10, 0x83);
            this.label8.Name = "label8";
            this.label8.Size = new Size(80, 13);
            this.label8.TabIndex = 170;
            this.label8.Text = "Email Address :";
            this.label15.AutoSize = true;
            this.label15.Location = new Point(10, 0x4a);
            this.label15.Name = "label15";
            this.label15.Size = new Size(0x4a, 13);
            this.label15.TabIndex = 0xa6;
            this.label15.Text = "Working Place";
            this.txtMotherWorked.Location = new Point(0x68, 0x4a);
            this.txtMotherWorked.MaxLength = 100;
            this.txtMotherWorked.Name = "txtMotherWorked";
            this.txtMotherWorked.Size = new Size(0x1c5, 0x15);
            this.txtMotherWorked.TabIndex = 0x1a;
            this.txtMotherWorked.KeyPress += new KeyPressEventHandler(this.txtMotherWorked_KeyPress);
            this.txtMotherMobile.Location = new Point(0x171, 0x65);
            this.txtMotherMobile.MaxLength = 20;
            this.txtMotherMobile.Name = "txtMotherMobile";
            this.txtMotherMobile.Size = new Size(0xbc, 0x15);
            this.txtMotherMobile.TabIndex = 0x1c;
            this.txtMotherMobile.KeyPress += new KeyPressEventHandler(this.txtMotherMobile_KeyPress);
            this.label24.AutoSize = true;
            this.label24.Location = new Point(300, 0x68);
            this.label24.Name = "label24";
            this.label24.Size = new Size(0x35, 13);
            this.label24.TabIndex = 0xa8;
            this.label24.Text = "Mobile No";
            this.txtMotherTelephone.Location = new Point(0x68, 0x65);
            this.txtMotherTelephone.MaxLength = 20;
            this.txtMotherTelephone.Name = "txtMotherTelephone";
            this.txtMotherTelephone.Size = new Size(0xa4, 0x15);
            this.txtMotherTelephone.TabIndex = 0x1b;
            this.txtMotherTelephone.KeyPress += new KeyPressEventHandler(this.txtMotherTelephone_KeyPress);
            this.label25.AutoSize = true;
            this.label25.Location = new Point(10, 0x68);
            this.label25.Name = "label25";
            this.label25.Size = new Size(0x49, 13);
            this.label25.TabIndex = 0xa7;
            this.label25.Text = "Telephone No";
            this.txtMotherOccupation.Location = new Point(0x68, 0x2f);
            this.txtMotherOccupation.MaxLength = 100;
            this.txtMotherOccupation.Name = "txtMotherOccupation";
            this.txtMotherOccupation.Size = new Size(0x1c5, 0x15);
            this.txtMotherOccupation.TabIndex = 0x19;
            this.txtMotherOccupation.KeyPress += new KeyPressEventHandler(this.txtMotherOccupation_KeyPress);
            this.label1.AutoSize = true;
            this.label1.Location = new Point(10, 50);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x3d, 13);
            this.label1.TabIndex = 0x99;
            this.label1.Text = "Occupation";
            this.txtMotherName.Location = new Point(0x68, 20);
            this.txtMotherName.MaxLength = 100;
            this.txtMotherName.Name = "txtMotherName";
            this.txtMotherName.Size = new Size(0x1c5, 0x15);
            this.txtMotherName.TabIndex = 0x18;
            this.txtMotherName.KeyPress += new KeyPressEventHandler(this.txtMotherName_KeyPress);
            this.label6.AutoSize = true;
            this.label6.Location = new Point(10, 0x17);
            this.label6.Name = "label6";
            this.label6.Size = new Size(0x47, 13);
            this.label6.TabIndex = 0x97;
            this.label6.Text = "Mother Name";
            this.groupBox1.Controls.Add(this.txtfatherEmail);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txtfatherPleaseAtWork);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtfatherMobile);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.txtFatherName);
            this.groupBox1.Controls.Add(this.txtFatherOccupation);
            this.groupBox1.Controls.Add(this.txtfatherTelephone);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Location = new Point(1, 0x21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(0x23b, 0xb9);
            this.groupBox1.TabIndex = 0xa1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Father Details";
            this.txtfatherEmail.Location = new Point(0x68, 140);
            this.txtfatherEmail.MaxLength = 100;
            this.txtfatherEmail.Name = "txtfatherEmail";
            this.txtfatherEmail.Size = new Size(0x1c5, 0x15);
            this.txtfatherEmail.TabIndex = 0x17;
            this.txtfatherEmail.KeyPress += new KeyPressEventHandler(this.txtfatherEmail_KeyPress);
            this.label19.AutoSize = true;
            this.label19.Location = new Point(10, 0x8f);
            this.label19.Name = "label19";
            this.label19.Size = new Size(80, 13);
            this.label19.TabIndex = 0xa2;
            this.label19.Text = "Email Address :";
            this.label11.AutoSize = true;
            this.label11.Location = new Point(10, 0x56);
            this.label11.Name = "label11";
            this.label11.Size = new Size(0x4a, 13);
            this.label11.TabIndex = 0x9b;
            this.label11.Text = "Working Place";
            this.txtfatherPleaseAtWork.Location = new Point(0x68, 0x56);
            this.txtfatherPleaseAtWork.MaxLength = 100;
            this.txtfatherPleaseAtWork.Name = "txtfatherPleaseAtWork";
            this.txtfatherPleaseAtWork.Size = new Size(0x1c5, 0x15);
            this.txtfatherPleaseAtWork.TabIndex = 20;
            this.txtfatherPleaseAtWork.KeyPress += new KeyPressEventHandler(this.txtfatherPleaseAtWork_KeyPress);
            this.label4.AutoSize = true;
            this.label4.Location = new Point(10, 0x1d);
            this.label4.Name = "label4";
            this.label4.Size = new Size(0x45, 13);
            this.label4.TabIndex = 0x93;
            this.label4.Text = "Father Name";
            this.txtfatherMobile.Location = new Point(0x171, 0x71);
            this.txtfatherMobile.MaxLength = 20;
            this.txtfatherMobile.Name = "txtfatherMobile";
            this.txtfatherMobile.Size = new Size(0xbc, 0x15);
            this.txtfatherMobile.TabIndex = 0x16;
            this.txtfatherMobile.KeyPress += new KeyPressEventHandler(this.txtfatherMobile_KeyPress);
            this.label18.AutoSize = true;
            this.label18.Location = new Point(300, 0x74);
            this.label18.Name = "label18";
            this.label18.Size = new Size(0x35, 13);
            this.label18.TabIndex = 0x9e;
            this.label18.Text = "Mobile No";
            this.txtFatherName.Location = new Point(0x68, 0x1a);
            this.txtFatherName.MaxLength = 100;
            this.txtFatherName.Name = "txtFatherName";
            this.txtFatherName.Size = new Size(0x1c5, 0x15);
            this.txtFatherName.TabIndex = 0x12;
            this.txtFatherName.KeyPress += new KeyPressEventHandler(this.txtFatherName_KeyPress);
            this.txtFatherOccupation.Location = new Point(0x68, 0x37);
            this.txtFatherOccupation.MaxLength = 100;
            this.txtFatherOccupation.Name = "txtFatherOccupation";
            this.txtFatherOccupation.Size = new Size(0x1c5, 0x15);
            this.txtFatherOccupation.TabIndex = 0x13;
            this.txtFatherOccupation.KeyPress += new KeyPressEventHandler(this.txtFatherOccupation_KeyPress);
            this.txtfatherTelephone.Location = new Point(0x68, 0x71);
            this.txtfatherTelephone.MaxLength = 20;
            this.txtfatherTelephone.Name = "txtfatherTelephone";
            this.txtfatherTelephone.Size = new Size(0xa4, 0x15);
            this.txtfatherTelephone.TabIndex = 0x15;
            this.txtfatherTelephone.KeyPress += new KeyPressEventHandler(this.txtfatherTelephone_KeyPress);
            this.label17.AutoSize = true;
            this.label17.Location = new Point(10, 0x74);
            this.label17.Name = "label17";
            this.label17.Size = new Size(0x49, 13);
            this.label17.TabIndex = 0x9c;
            this.label17.Text = "Telephone No";
            this.label7.AutoSize = true;
            this.label7.Location = new Point(10, 0x3a);
            this.label7.Name = "label7";
            this.label7.Size = new Size(0x3d, 13);
            this.label7.TabIndex = 0x97;
            this.label7.Text = "Occupation";
            this.panel1.Controls.Add(this.btnView);
            this.panel1.Controls.Add(this.btnFind);
            this.panel1.Controls.Add(this.btnRefresh);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Location = new Point(3, 570);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(590, 0x23);
            this.panel1.TabIndex = 0x1f;
            this.btnView.Location = new Point(0xa1, 6);
            this.btnView.Name = "btnView";
            this.btnView.Size = new Size(0x49, 0x17);
            this.btnView.TabIndex = 0x21;
            this.btnView.Text = "&View";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new EventHandler(this.btnView_Click);
            this.btnFind.Location = new Point(0xf1, 6);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new Size(0x49, 0x17);
            this.btnFind.TabIndex = 0x22;
            this.btnFind.Text = "&Find";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new EventHandler(this.btnFind_Click);
            this.btnRefresh.Location = new Point(0x52, 6);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new Size(0x49, 0x17);
            this.btnRefresh.TabIndex = 0x20;
            this.btnRefresh.Text = "&Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new EventHandler(this.btnRefresh_Click);
            this.btnSave.Location = new Point(3, 6);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new Size(0x49, 0x17);
            this.btnSave.TabIndex = 0x1f;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new EventHandler(this.btnSave_Click);
            this.btnDelete.Location = new Point(320, 6);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new Size(0x49, 0x17);
            this.btnDelete.TabIndex = 0x23;
            this.btnDelete.Text = "D&elete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new EventHandler(this.btnDelete_Click);
            this.btnExit.FlatAppearance.BorderColor = Color.FromArgb(0x40, 0x40, 0x40);
            this.btnExit.FlatAppearance.BorderSize = 5;
            this.btnExit.Location = new Point(0x1fa, 6);
            this.btnExit.Margin = new Padding(0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new Size(0x53, 0x17);
            this.btnExit.TabIndex = 0x24;
            this.btnExit.Text = "E&xit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new EventHandler(this.btnExit_Click);
            this.errStudent.ContainerControl = this;
            this.panel2.BackColor = Color.White;
            this.panel2.BorderStyle = BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.label30);
            this.panel2.Controls.Add(this.label31);
            this.panel2.Location = new Point(0, -1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new Size(0x2bf, 0x45);
            this.panel2.TabIndex = 0x21;
            this.pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            this.pictureBox1.Image = (Image) manager.GetObject("pictureBox1.Image");
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new Point(8, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new Size(0x4c, 0x34);
            this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 170;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Tag = "operator_128.jpg";
            this.label30.AutoSize = true;
            this.label30.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label30.ForeColor = Color.Black;
            this.label30.Location = new Point(0x81, 0x23);
            this.label30.Name = "label30";
            this.label30.Size = new Size(300, 0x10);
            this.label30.TabIndex = 1;
            this.label30.Text = "User can maintain Student details using this wizard";
            this.label31.AutoSize = true;
            this.label31.Font = new Font("Tahoma", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.label31.ForeColor = Color.Black;
            this.label31.Location = new Point(0x53, 10);
            this.label31.Name = "label31";
            this.label31.Size = new Size(0x86, 0x13);
            this.label31.TabIndex = 0;
            this.label31.Text = "Student Master";
            this.grpPaymentDetails.Controls.Add(this.label10);
            this.grpPaymentDetails.Controls.Add(this.label16);
            this.grpPaymentDetails.Controls.Add(this.label32);
            this.grpPaymentDetails.Controls.Add(this.btnPaymentDetails);
            this.grpPaymentDetails.Controls.Add(this.label37);
            this.grpPaymentDetails.Controls.Add(this.label33);
            this.grpPaymentDetails.Controls.Add(this.cmbPaymentMethod);
            this.grpPaymentDetails.Controls.Add(this.groupBox7);
            this.grpPaymentDetails.Controls.Add(this.txtDiscount);
            this.grpPaymentDetails.Controls.Add(this.label36);
            this.grpPaymentDetails.Location = new Point(0x25a, 0x182);
            this.grpPaymentDetails.Name = "grpPaymentDetails";
            this.grpPaymentDetails.Size = new Size(0x158, 0xb6);
            this.grpPaymentDetails.TabIndex = 0xd7;
            this.grpPaymentDetails.TabStop = false;
            this.label10.BackColor = Color.Blue;
            this.label10.Location = new Point(-7, 0xb3);
            this.label10.Name = "label10";
            this.label10.Size = new Size(0x23d, 0x15);
            this.label10.TabIndex = 230;
            this.label16.BackColor = Color.Blue;
            this.label16.Location = new Point(0x155, 0);
            this.label16.Name = "label16";
            this.label16.Size = new Size(10, 0x12e);
            this.label16.TabIndex = 0xe5;
            this.label32.BackColor = Color.Blue;
            this.label32.Location = new Point(-7, 8);
            this.label32.Name = "label32";
            this.label32.Size = new Size(10, 0x12e);
            this.label32.TabIndex = 0xe3;
            this.btnPaymentDetails.Image = Resources.CloseButton_copy;
            this.btnPaymentDetails.Location = new Point(0x141, 2);
            this.btnPaymentDetails.Name = "btnPaymentDetails";
            this.btnPaymentDetails.Size = new Size(0x16, 0x13);
            this.btnPaymentDetails.TabIndex = 0xe2;
            this.btnPaymentDetails.UseVisualStyleBackColor = true;
            this.btnPaymentDetails.Click += new EventHandler(this.btnPaymentDetails_Click);
            this.label37.BackColor = SystemColors.ActiveCaption;
            this.label37.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.label37.ForeColor = Color.White;
            this.label37.Location = new Point(0, 0);
            this.label37.Name = "label37";
            this.label37.Size = new Size(0x169, 0x16);
            this.label37.TabIndex = 0xe1;
            this.label37.Text = " Enter Payment Details";
            this.label33.AutoSize = true;
            this.label33.Location = new Point(10, 0x8d);
            this.label33.Name = "label33";
            this.label33.Size = new Size(0x5d, 13);
            this.label33.TabIndex = 0xdf;
            this.label33.Text = "Payment Method :";
            this.cmbPaymentMethod.DrawMode = DrawMode.OwnerDrawVariable;
            this.cmbPaymentMethod.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbPaymentMethod.DropDownWidth = 0x11;
            this.cmbPaymentMethod.FormattingEnabled = true;
            this.cmbPaymentMethod.Location = new Point(120, 0x8a);
            this.cmbPaymentMethod.Name = "cmbPaymentMethod";
            this.cmbPaymentMethod.Size = new Size(0xc1, 0x15);
            this.cmbPaymentMethod.TabIndex = 0xde;
            this.cmbPaymentMethod.ViewColumn = 0;
            this.groupBox7.Controls.Add(this.txtPamentAmount);
            this.groupBox7.Controls.Add(this.label34);
            this.groupBox7.Controls.Add(this.cmbPanalPayMethod);
            this.groupBox7.Controls.Add(this.label35);
            this.groupBox7.Location = new Point(7, 0x35);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new Size(0x13f, 0x4f);
            this.groupBox7.TabIndex = 0xdb;
            this.groupBox7.TabStop = false;
            this.txtPamentAmount.BackColor = SystemColors.ActiveCaptionText;
            this.txtPamentAmount.Location = new Point(0x71, 0x2b);
            this.txtPamentAmount.MaxLength = 100;
            this.txtPamentAmount.Name = "txtPamentAmount";
            this.txtPamentAmount.Size = new Size(0xc1, 20);
            this.txtPamentAmount.TabIndex = 0xdf;
            this.txtPamentAmount.TextAlign = HorizontalAlignment.Right;
            this.label34.AutoSize = true;
            this.label34.Location = new Point(3, 0x2e);
            this.label34.Name = "label34";
            this.label34.Size = new Size(0x59, 0x1a);
            this.label34.TabIndex = 0xde;
            this.label34.Text = "Penalty Payment \r\nAmount :";
            this.cmbPanalPayMethod.DrawMode = DrawMode.OwnerDrawVariable;
            this.cmbPanalPayMethod.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbPanalPayMethod.DropDownWidth = 0x11;
            this.cmbPanalPayMethod.FormattingEnabled = true;
            this.cmbPanalPayMethod.Location = new Point(0x71, 0x10);
            this.cmbPanalPayMethod.Name = "cmbPanalPayMethod";
            this.cmbPanalPayMethod.Size = new Size(0xc1, 0x15);
            this.cmbPanalPayMethod.TabIndex = 0xdd;
            this.cmbPanalPayMethod.ViewColumn = 0;
            this.label35.AutoSize = true;
            this.label35.Location = new Point(3, 0x10);
            this.label35.Name = "label35";
            this.label35.Size = new Size(0x56, 0x1a);
            this.label35.TabIndex = 0xda;
            this.label35.Text = "Penalty Payment\r\nMethod :";
            this.txtDiscount.BackColor = SystemColors.ActiveCaptionText;
            this.txtDiscount.Location = new Point(120, 0x1d);
            this.txtDiscount.MaxLength = 100;
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Size = new Size(0xc1, 20);
            this.txtDiscount.TabIndex = 0xda;
            this.txtDiscount.TextAlign = HorizontalAlignment.Right;
            this.label36.AutoSize = true;
            this.label36.Location = new Point(10, 0x20);
            this.label36.Name = "label36";
            this.label36.Size = new Size(0x37, 13);
            this.label36.TabIndex = 0xd9;
            this.label36.Text = "Discount :";
            style5.Alignment = DataGridViewContentAlignment.TopLeft;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = style5;
            this.dataGridViewTextBoxColumn1.HeaderText = "Strat Time";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            this.dataGridViewTextBoxColumn1.Width = 80;
            style6.Alignment = DataGridViewContentAlignment.TopLeft;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = style6;
            this.dataGridViewTextBoxColumn2.HeaderText = "End Time";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 80;
            this.dataGridViewTextBoxColumn3.HeaderText = "Coacher No";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Resizable = DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn3.Visible = false;
            this.dataGridViewTextBoxColumn4.HeaderText = "Coacher Name";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn5.HeaderText = "Ass Coacher No";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Visible = false;
            this.dataGridViewTextBoxColumn6.HeaderText = "Ass Coacher Name";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x254, 0x25e);
            base.Controls.Add(this.grpPaymentDetails);
            base.Controls.Add(this.panel2);
            base.Controls.Add(this.panel1);
            base.Controls.Add(this.tbcStudentDetails);
            base.Name = "frmStudentMasterNew";
            this.Text = "Pool Attendance System";
            base.Load += new EventHandler(this.frmStudentMasterNew_Load);
            this.tbcStudentDetails.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((ISupportInitialize) this.lstRegularEmployee).EndInit();
            ((ISupportInitialize) this.ptbPhotograph).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((ISupportInitialize) this.errStudent).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((ISupportInitialize) this.pictureBox1).EndInit();
            this.grpPaymentDetails.ResumeLayout(false);
            this.grpPaymentDetails.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            base.ResumeLayout(false);
        }

        private void InsertUpdate()
        {
            this.oStudentMaster.LocationCode = this.cGlobleVariable.LocationCode;
            this.oStudentMaster.StudentNo = this.txtStudentNo.Text.ToString();
            this.oStudentMaster.NameInFullL1 = this.txtFullNameLineOne.Text;
            this.oStudentMaster.NameInFullL2 = this.txtFullNameLineTwo.Text;
            this.oStudentMaster.Address_Line1 = this.txtHomeAddressLine1.Text;
            this.oStudentMaster.Address_Line2 = this.txtHomeAddressLine2.Text;
            this.oStudentMaster.Telephone = this.txtContactHomeTP.Text;
            this.oStudentMaster.EmailAddress = this.txtEmailAdd.Text;
            this.oStudentMaster.DateOfBirth = Convert.ToDateTime(this.dtpDateOfBirth.Value);
            this.oStudentMaster.SchoolName = this.txtSchoolName.Text;
            this.oStudentMaster.EmergencyInformarName = this.txtInformarName.Text;
            this.oStudentMaster.EmergencyInformarTelephone = this.txtInformarTel.Text;
            this.oStudentMaster.PINNumber = this.txtPinNumber.Text;
            this.oStudentMaster.Level = this.cmbClassName["fldClassCode"].ToString();
            this.oStudentMaster.DateOfJoin = Convert.ToDateTime(this.dtpDateOfJoin.Value);
            this.oStudentMaster.Fees = Convert.ToDouble(this.txtFees.Text);
            this.oStudentMaster.Remarks = this.txtRemarks.Text;
            this.oStudentMaster.Photograph = this.ptbPhotograph.Tag.ToString();
            this.oStudentMaster.FatherName = this.txtFatherName.Text;
            this.oStudentMaster.FatherOccupation = this.txtFatherOccupation.Text;
            this.oStudentMaster.FatherPlaceOfWork = this.txtfatherPleaseAtWork.Text;
            this.oStudentMaster.FatherTelephone = this.txtfatherTelephone.Text;
            this.oStudentMaster.FatherMobile = this.txtfatherMobile.Text;
            this.oStudentMaster.FatherEmail = this.txtfatherEmail.Text;
            this.oStudentMaster.MotherName = this.txtMotherName.Text;
            this.oStudentMaster.MotherOccupation = this.txtMotherOccupation.Text;
            this.oStudentMaster.MotherPlaceOfWork = this.txtMotherWorked.Text;
            this.oStudentMaster.MotherTelephone = this.txtMotherTelephone.Text;
            this.oStudentMaster.MotherMobile = this.txtMotherMobile.Text;
            this.oStudentMaster.MotherEmail = this.txtMotherEmail.Text;
            this.oStudentMaster.Status = this.cmbStudentStatus["fld_Status_Code"].ToString();
            if ((this.btnPhoto.Tag != null) && File.Exists(this.btnPhoto.Tag.ToString()))
            {
                this.FileCopyToServer(this.btnPhoto.Tag.ToString(), this.ptbPhotograph.Tag.ToString());
            }
            this.oStudentClassTimes.LocationCode = this.cGlobleVariable.LocationCode;
            this.oStudentClassTimes.ClassCode = this.cmbClassName["fldClassCode"].ToString();
            this.oStudentClassTimes.StudentNo = this.txtStudentNo.Text;
            this.cStudentClassTimes.DeleteTimeDetails(this.cGlobleVariable.LocationCode, this.txtStudentNo.Text);
            for (int i = 0; i < this.lstRegularEmployee.Rows.Count; i++)
            {
                if (Convert.ToBoolean(this.lstRegularEmployee.Rows[i].Cells[0].Value))
                {
                    this.oStudentClassTimes.ClassTimeCode = this.lstRegularEmployee.Rows[i].Cells[1].Value.ToString();
                    this.cStudentClassTimes.InsertUpdateStudentClassTimes(this.oStudentClassTimes);
                }
            }
            this.cStudentMaster.InsertUpdate(this.oStudentMaster);
            this.oActiveCancelHistory.LocationCode = this.cGlobleVariable.LocationCode;
            this.oActiveCancelHistory.StudentNo = this.txtStudentNo.Text.ToString();
            this.oActiveCancelHistory.ActiveDate = Convert.ToDateTime(DateTime.Today.ToString("yyyy-MM-dd"));
            this.oActiveCancelHistory.Status = this.cmbStudentStatus["fld_Status_Code"].ToString();
            if ((this.cmbStudentStatus.Tag.ToString() != null) && (this.cmbStudentStatus.Tag.ToString() != this.cmbStudentStatus.Text.ToString()))
            {
                this.cActiveCancelHistory.InsertUpdateData(this.oActiveCancelHistory);
            }
            if (this.VarifyPayments())
            {
                this.oPaymentDeatils.LocationCode = this.cGlobleVariable.LocationCode;
                this.oPaymentDeatils.StudentNo = this.txtStudentNo.Text.ToString();
                this.oPaymentDeatils.StudentDicount = Convert.ToDouble(this.txtDiscount.Text);
                this.oPaymentDeatils.PenaltyPayMethodCode = this.cmbPanalPayMethod["fldPaymentMethodCode"].ToString();
                this.oPaymentDeatils.PenaltyPayAmount = Convert.ToDouble(this.txtPamentAmount.Text);
                this.oPaymentDeatils.StudentPayMethodCode = this.cmbPaymentMethod["fldPaymentMethodCode"].ToString();
                this.cPaymentDeatil.InsertUpdateData(this.oPaymentDeatils);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void label96_Click(object sender, EventArgs e)
        {
        }

        private void label97_Click(object sender, EventArgs e)
        {
        }

        private void LoadCombos()
        {
            DataTable classDetails = this.cClassMaster.GetClassDetails(this.cGlobleVariable.LocationCode, this.cGlobleVariable.ActiveStatusCode);
            this.cCommanMethods.LoadCombo(classDetails, this.cmbClassName, 3);
            DataTable statusDetails = this.cStatusMaster.GetStatusDetails();
            this.cCommanMethods.LoadCombo(statusDetails, this.cmbStudentStatus, 1);
            DataTable paymentMethods = this.cPaymentMethod.GetPaymentMethods(this.cGlobleVariable.LocationCode);
            this.cCommanMethods.LoadCombo(paymentMethods, this.cmbPanalPayMethod, 4);
            this.cCommanMethods.LoadCombo(paymentMethods, this.cmbPaymentMethod, 4);
        }

        private void LoadStudent()
        {
            this.oStudentMaster = this.cStudentMaster.GetStudentData(this.cGlobleVariable.LocationCode, this.txtStudentNo.Text.ToString());
            if (this.oStudentMaster.IsExistStudent)
            {
                this.txtStudentNo.Text = this.oStudentMaster.StudentNo;
                this.txtFullNameLineOne.Text = this.oStudentMaster.NameInFullL1;
                this.txtFullNameLineTwo.Text = this.oStudentMaster.NameInFullL2;
                this.txtHomeAddressLine1.Text = this.oStudentMaster.Address_Line1;
                this.txtHomeAddressLine2.Text = this.oStudentMaster.Address_Line2;
                this.txtContactHomeTP.Text = this.oStudentMaster.Telephone;
                this.txtEmailAdd.Text = this.oStudentMaster.EmailAddress;
                this.dtpDateOfBirth.Value = this.oStudentMaster.DateOfBirth;
                this.txtSchoolName.Text = this.oStudentMaster.SchoolName;
                this.txtInformarName.Text = this.oStudentMaster.EmergencyInformarName;
                this.txtInformarTel.Text = this.oStudentMaster.EmergencyInformarTelephone;
                this.txtPinNumber.Text = this.oStudentMaster.PINNumber;
                this.cmbClassName.SetText(this.cClassMaster.GetClassData(this.cGlobleVariable.LocationCode, this.oStudentMaster.Level).ClassName);
                this.dtpDateOfJoin.Value = this.oStudentMaster.DateOfJoin;
                this.txtFees.Text = this.oStudentMaster.Fees.ToString();
                this.txtRemarks.Text = this.oStudentMaster.Remarks;
                this.ptbPhotograph.Tag = this.oStudentMaster.Photograph;
                this.PhotoIsExist(this.oStudentMaster.Photograph);
                this.txtFatherName.Text = this.oStudentMaster.FatherName;
                this.txtFatherOccupation.Text = this.oStudentMaster.FatherOccupation;
                this.txtfatherPleaseAtWork.Text = this.oStudentMaster.FatherPlaceOfWork;
                this.txtfatherTelephone.Text = this.oStudentMaster.FatherTelephone;
                this.txtfatherMobile.Text = this.oStudentMaster.FatherMobile;
                this.txtfatherEmail.Text = this.oStudentMaster.FatherEmail;
                this.txtMotherName.Text = this.oStudentMaster.MotherName;
                this.txtMotherOccupation.Text = this.oStudentMaster.MotherOccupation;
                this.txtMotherWorked.Text = this.oStudentMaster.MotherPlaceOfWork;
                this.txtMotherTelephone.Text = this.oStudentMaster.MotherTelephone;
                this.txtMotherMobile.Text = this.oStudentMaster.MotherMobile;
                this.txtMotherEmail.Text = this.oStudentMaster.MotherEmail;
                this.cmbStudentStatus.SetText(this.cStatusMaster.GetStatusByCode(this.oStudentMaster.Status).StatusName);
                this.cmbStudentStatus.Tag = this.cmbStudentStatus.Text;
                DataTable studentClassDeails = this.cStudentClassTimes.GetStudentClassDeails(this.cGlobleVariable.LocationCode, this.txtStudentNo.Text);
                for (int i = 0; i < this.lstRegularEmployee.Rows.Count; i++)
                {
                    string str = this.lstRegularEmployee.Rows[i].Cells[1].Value.ToString();
                    for (int j = 0; j < studentClassDeails.Rows.Count; j++)
                    {
                        if (studentClassDeails.Rows[j]["fldClassTimeCode"].ToString() == str)
                        {
                            this.lstRegularEmployee.Rows[i].Cells[0].Value = true;
                            break;
                        }
                    }
                }
                this.oPaymentDeatils = this.cPaymentDeatil.GetPaymentDeatils(this.cGlobleVariable.LocationCode, this.txtStudentNo.Text.ToString());
                if (this.oPaymentDeatils.IsPaymentExist)
                {
                    this.txtDiscount.Text = this.oPaymentDeatils.StudentDicount.ToString();
                    this.txtPamentAmount.Text = this.oPaymentDeatils.PenaltyPayAmount.ToString();
                    this.cmbPanalPayMethod.SetText(this.cPaymentMethod.GetPaymentMethod(this.cGlobleVariable.LocationCode, this.oPaymentDeatils.PenaltyPayMethodCode).PaymentDescription);
                    this.cmbPaymentMethod.SetText(this.cPaymentMethod.GetPaymentMethod(this.cGlobleVariable.LocationCode, this.oPaymentDeatils.StudentPayMethodCode).PaymentDescription);
                }
            }
        }

        public void NextStudentNumber()
        {
            this.txtStudentNo.Text = this.cStudentMaster.NextStudentNumber(this.cGlobleVariable.LocationCode);
        }

        private void PhotoIsExist(string strPhotoFilePath)
        {
            if (File.Exists(this.cGlobleVariable.strImagePath + @"\" + strPhotoFilePath))
            {
                this.ptbPhotograph.Load(this.cGlobleVariable.strImagePath + @"\" + strPhotoFilePath);
                this.ptbPhotograph.Tag = strPhotoFilePath;
            }
            else
            {
                this.ptbPhotograph.Image = null;
            }
        }

        public void RefreshPage()
        {
            this.cCommanMethods.ClearForm(this);
            this.LoadCombos();
            this.NextStudentNumber();
            this.txtStudentNo.ReadOnly = true;
            this.txtFullNameLineOne.Focus();
            this.tbcStudentDetails.SelectTab(0);
        }

        private void txtContactHomeTP_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.cCommanMethods.MoveNextControl(e);
        }

        private void txtContactHomeTP_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtEmailAdd_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.cCommanMethods.MoveNextControl(e);
        }

        private void txtEmailAdd_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtfatherEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.cCommanMethods.MoveNextControl(e);
        }

        private void txtfatherMobile_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.cCommanMethods.MoveNextControl(e);
        }

        private void txtFatherName_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.cCommanMethods.MoveNextControl(e);
        }

        private void txtFatherOccupation_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.cCommanMethods.MoveNextControl(e);
        }

        private void txtfatherPleaseAtWork_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.cCommanMethods.MoveNextControl(e);
        }

        private void txtfatherTelephone_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.cCommanMethods.MoveNextControl(e);
        }

        private void txtFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.cCommanMethods.MoveNextControl(e);
        }

        private void txtFullNameLineOne_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.cCommanMethods.MoveNextControl(e);
        }

        private void txtFullNameLineTwo_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.cCommanMethods.MoveNextControl(e);
        }

        private void txtHomeAddressLine1_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.cCommanMethods.MoveNextControl(e);
        }

        private void txtHomeAddressLine1_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtHomeAddressLine2_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.cCommanMethods.MoveNextControl(e);
        }

        private void txtHomeAddressLine2_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtInformarName_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.cCommanMethods.MoveNextControl(e);
        }

        private void txtInformarTel_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.cCommanMethods.MoveNextControl(e);
        }

        private void txtMotherEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.cCommanMethods.MoveNextControl(e);
        }

        private void txtMotherMobile_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.cCommanMethods.MoveNextControl(e);
        }

        private void txtMotherName_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.cCommanMethods.MoveNextControl(e);
        }

        private void txtMotherOccupation_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.cCommanMethods.MoveNextControl(e);
        }

        private void txtMotherTelephone_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.cCommanMethods.MoveNextControl(e);
        }

        private void txtMotherWorked_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.cCommanMethods.MoveNextControl(e);
        }

        private void txtPinNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.cCommanMethods.MoveNextControl(e);
        }

        private void txtRemarks_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                this.tbcStudentDetails.SelectTab(1);
                this.txtFatherName.Focus();
            }
        }

        private void txtSchoolName_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.cCommanMethods.MoveNextControl(e);
        }

        private void txtStudentNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.cCommanMethods.MoveNextControl(e);
        }

        private void txtStudentNo_TextChanged(object sender, EventArgs e)
        {
            this.LoadStudent();
        }

        private bool ValidateData()
        {
            bool flag = true;
            if (this.txtStudentNo.Text == "")
            {
                this.errStudent.SetError(this.txtStudentNo, "Please enter Student number");
                flag = false;
            }
            else
            {
                this.errStudent.SetError(this.txtStudentNo, "");
            }
            if (this.txtFullNameLineOne.Text == "")
            {
                this.errStudent.SetError(this.txtFullNameLineOne, "Please enter Name In Full");
                flag = false;
            }
            else
            {
                this.errStudent.SetError(this.txtFullNameLineOne, "");
            }
            if (this.txtFees.Text == "")
            {
                this.errStudent.SetError(this.txtFees, "Please enter Fees");
                flag = false;
            }
            else
            {
                this.errStudent.SetError(this.txtFees, "");
            }
            if (this.cmbStudentStatus.SelectedIndex < 0)
            {
                this.errStudent.SetError(this.cmbStudentStatus, "Please select the Status");
                return false;
            }
            this.errStudent.SetError(this.cmbStudentStatus, "");
            return flag;
        }

        private bool VarifyNumbers()
        {
            bool flag = true;
            if (!this.cCommanMethods.IsNumber(this.txtDiscount.Text))
            {
                flag = false;
            }
            return (this.cCommanMethods.IsNumber(this.txtPamentAmount.Text) && flag);
        }

        private bool VarifyPayments()
        {
            bool flag = false;
            if (this.txtDiscount.Text != string.Empty)
            {
                if (this.VarifyNumbers())
                {
                    if (this.cmbPanalPayMethod.SelectedIndex < 0)
                    {
                        flag = false;
                        MessageBox.Show("plz select payment method");
                    }
                    else
                    {
                        flag = true;
                    }
                    if (this.cmbPaymentMethod.SelectedIndex < 0)
                    {
                        flag = false;
                        MessageBox.Show("plz select payment method");
                        return flag;
                    }
                    return true;
                }
                flag = true;
                MessageBox.Show("plz eneter valid amounts");
            }
            return flag;
        }

        public void ViewEmployee()
        {
            string[] strFieldList = new string[] { "fldStudentNo", "fldNameInFullL1" };
            string[] strHeadingList = new string[] { "Student No", "Student Name" };
            int[] iHeaderWidth = new int[] { 80, 100 };
            string strReturnField = "Student No";
            string str2 = "fldLocationCode = '" + this.cGlobleVariable.LocationCode + "' ";
            this.txtStudentNo.Text = this.cCommanMethods.BrowsData("tbl_student_master", strFieldList, strHeadingList, iHeaderWidth, strReturnField, str2);
        }
    }
}

