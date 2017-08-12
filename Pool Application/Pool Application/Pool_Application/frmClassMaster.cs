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

    public class frmClassMaster : Form
    {
        public Button btnDelete;
        public Button btnExit;
        public Button btnRefresh;
        public Button btnSave;
        public Button btnUpdate;
        public Button btnView;
        private clsClassMaster cClassMaster = new clsClassMaster();
        private clsClassTimeTable cClassTimeTable = new clsClassTimeTable();
        private clsCommenMethods cCommanMethods = new clsCommenMethods();
        private clsGlobleVariable cGlobleVariable = new clsGlobleVariable();
        private ColumnComboBox cmbClassStatus;
        private DataGridViewComboBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewComboBoxColumn Column4;
        private IContainer components = null;
        private clsStatusMaster cStatusMaster = new clsStatusMaster();
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridView dgvClassTimes;
        private ErrorProvider errClass;
        private GroupBox groupBox1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label8;
        private Label label9;
        private objClassMaster oClassMaster = new objClassMaster();
        private objClassTimeTable oClassTimeTable = new objClassTimeTable();
        private Panel panel1;
        private Panel panel2;
        private PictureBox pictureBox1;
        private TextBox txtClassCode;
        private TextBox txtClassName;
        private TextBox txtCroupDays;
        private TextBox txtTotalStudents;

        public frmClassMaster()
        {
            this.InitializeComponent();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this?", "Delete Class", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.cClassMaster.DeleteClassMasterData(this.cGlobleVariable.LocationCode, this.txtClassCode.Text.ToString());
                MessageBox.Show("Successfully deleted.....", "Delete Details", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.ValidateData())
            {
                this.oClassMaster.LocationCode = this.cGlobleVariable.LocationCode;
                this.oClassMaster.ClassCode = this.txtClassCode.Text.ToString();
                this.oClassMaster.ClassName = this.txtClassName.Text.ToString();
                this.oClassMaster.ClassStatus = this.cmbClassStatus["fld_Status_Code"].ToString();
                this.oClassMaster.ClassTotalStudents = Convert.ToInt32(this.txtTotalStudents.Text);
                this.oClassMaster.ClassCoverUpDays = Convert.ToInt32(this.txtCroupDays.Text);
                this.InsertUpdateClassMasterTimes();
                this.cClassMaster.InsertUpdateData(this.oClassMaster);
                MessageBox.Show(this.cGlobleVariable.SeavedMessage, "Class Details", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.cCommanMethods.ClearForm(this);
                this.txtClassCode.Focus();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (this.ValidateData())
            {
                this.oClassMaster.LocationCode = this.cGlobleVariable.LocationCode;
                this.oClassMaster.ClassCode = this.txtClassCode.Text.ToString();
                this.oClassMaster.ClassName = this.txtClassName.Text.ToString();
                this.oClassMaster.ClassStatus = this.cmbClassStatus["fld_Status_Code"].ToString();
                this.oClassMaster.ClassTotalStudents = Convert.ToInt32(this.txtTotalStudents.Text);
                this.cClassMaster.InsertUpdateData(this.oClassMaster);
                MessageBox.Show(this.cGlobleVariable.UpdateMessage, "Class Details", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.cCommanMethods.ClearForm(this);
                this.txtClassCode.Focus();
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            this.ViewEmployee();
        }

        private void cmbClassStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void dgvClassTimes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void frmClassMaster_Load(object sender, EventArgs e)
        {
            DataGridViewComboBoxColumn dataGridViewColumn = new DataGridViewComboBoxColumn();
            DataGridViewComboBoxColumn column2 = new DataGridViewComboBoxColumn();
            for (int i = 6; i < 0x16; i++)
            {
                string str = " AM";
                int num2 = i;
                if (num2 > 11)
                {
                    str = " PM";
                }
                if (num2 > 12)
                {
                    num2 = i - 12;
                }
                string str2 = num2.ToString("00");
                dataGridViewColumn.Items.Add(str2 + ":00" + str);
                column2.Items.Add(str2 + ":00" + str);
                for (int j = 0x19; j < 100; j += 0x19)
                {
                    str = " AM";
                    int num4 = j - ((j / 0x19) * 10);
                    num2 = i;
                    if (num2 > 11)
                    {
                        str = " PM";
                    }
                    if (num2 > 12)
                    {
                        num2 = i - 12;
                    }
                    str2 = num2.ToString("00");
                    dataGridViewColumn.Items.Add(str2 + ":" + num4.ToString() + str);
                    column2.Items.Add(str2 + ":" + num4.ToString() + str);
                }
            }
            dataGridViewColumn.Name = "Start Time";
            this.dgvClassTimes.Columns.Add(dataGridViewColumn);
            column2.Name = "End Time";
            this.dgvClassTimes.Columns.Add(column2);
            this.cCommanMethods.LoadCombo(this.cStatusMaster.GetStatusDetails(), this.cmbClassStatus, 1);
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            ComponentResourceManager manager = new ComponentResourceManager(typeof(frmClassMaster));
            this.groupBox1 = new GroupBox();
            this.dgvClassTimes = new DataGridView();
            this.Column2 = new DataGridViewTextBoxColumn();
            this.Column1 = new DataGridViewComboBoxColumn();
            this.Column4 = new DataGridViewComboBoxColumn();
            this.txtCroupDays = new TextBox();
            this.label5 = new Label();
            this.txtTotalStudents = new TextBox();
            this.label4 = new Label();
            this.cmbClassStatus = new ColumnComboBox();
            this.label1 = new Label();
            this.label3 = new Label();
            this.txtClassName = new TextBox();
            this.txtClassCode = new TextBox();
            this.label9 = new Label();
            this.panel1 = new Panel();
            this.btnView = new Button();
            this.btnUpdate = new Button();
            this.btnRefresh = new Button();
            this.btnSave = new Button();
            this.btnDelete = new Button();
            this.btnExit = new Button();
            this.label8 = new Label();
            this.label2 = new Label();
            this.panel2 = new Panel();
            this.pictureBox1 = new PictureBox();
            this.errClass = new ErrorProvider(this.components);
            this.dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((ISupportInitialize) this.dgvClassTimes).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((ISupportInitialize) this.pictureBox1).BeginInit();
            ((ISupportInitialize) this.errClass).BeginInit();
            base.SuspendLayout();
            this.groupBox1.BackColor = Color.Transparent;
            this.groupBox1.Controls.Add(this.dgvClassTimes);
            this.groupBox1.Controls.Add(this.txtCroupDays);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtTotalStudents);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cmbClassStatus);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtClassName);
            this.groupBox1.Controls.Add(this.txtClassCode);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.FlatStyle = FlatStyle.Popup;
            this.groupBox1.Location = new Point(7, 70);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(0x1f7, 0x16e);
            this.groupBox1.TabIndex = 0x10;
            this.groupBox1.TabStop = false;
            this.dgvClassTimes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClassTimes.Columns.AddRange(new DataGridViewColumn[] { this.Column2, this.Column1, this.Column4 });
            this.dgvClassTimes.Location = new Point(15, 0x95);
            this.dgvClassTimes.Name = "dgvClassTimes";
            this.dgvClassTimes.Size = new Size(0x1db, 0xd3);
            this.dgvClassTimes.TabIndex = 0x27;
            this.dgvClassTimes.CellContentClick += new DataGridViewCellEventHandler(this.dgvClassTimes_CellContentClick);
            this.Column2.HeaderText = "Column2";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Visible = false;
            this.Column1.HeaderText = "Day";
            this.Column1.Items.AddRange(new object[] { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" });
            this.Column1.Name = "Column1";
            this.Column1.Resizable = DataGridViewTriState.True;
            this.Column1.SortMode = DataGridViewColumnSortMode.Automatic;
            this.Column4.HeaderText = "Session";
            this.Column4.Items.AddRange(new object[] { "Morning", "Evening" });
            this.Column4.Name = "Column4";
            this.Column4.Resizable = DataGridViewTriState.True;
            this.Column4.SortMode = DataGridViewColumnSortMode.Automatic;
            this.txtCroupDays.Location = new Point(90, 0x60);
            this.txtCroupDays.Name = "txtCroupDays";
            this.txtCroupDays.Size = new Size(0x98, 20);
            this.txtCroupDays.TabIndex = 0x26;
            this.label5.AutoSize = true;
            this.label5.ForeColor = SystemColors.Highlight;
            this.label5.Location = new Point(12, 0x63);
            this.label5.Name = "label5";
            this.label5.Size = new Size(0x4a, 13);
            this.label5.TabIndex = 0x25;
            this.label5.Text = "Coverup Days";
            this.txtTotalStudents.Location = new Point(90, 70);
            this.txtTotalStudents.Name = "txtTotalStudents";
            this.txtTotalStudents.Size = new Size(0x98, 20);
            this.txtTotalStudents.TabIndex = 0x24;
            this.label4.AutoSize = true;
            this.label4.ForeColor = SystemColors.Highlight;
            this.label4.Location = new Point(12, 0x49);
            this.label4.Name = "label4";
            this.label4.Size = new Size(0x4c, 13);
            this.label4.TabIndex = 0x23;
            this.label4.Text = "Total Students";
            this.cmbClassStatus.DrawMode = DrawMode.OwnerDrawVariable;
            this.cmbClassStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbClassStatus.DropDownWidth = 0x11;
            this.cmbClassStatus.FormattingEnabled = true;
            this.cmbClassStatus.Location = new Point(90, 0x7a);
            this.cmbClassStatus.Name = "cmbClassStatus";
            this.cmbClassStatus.Size = new Size(0x98, 0x15);
            this.cmbClassStatus.TabIndex = 4;
            this.cmbClassStatus.ViewColumn = 0;
            this.cmbClassStatus.SelectedIndexChanged += new EventHandler(this.cmbClassStatus_SelectedIndexChanged);
            this.label1.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label1.ForeColor = SystemColors.Highlight;
            this.label1.Location = new Point(12, 0x7a);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x70, 0x13);
            this.label1.TabIndex = 0x22;
            this.label1.Text = "Status";
            this.label1.TextAlign = ContentAlignment.MiddleLeft;
            this.label3.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label3.ForeColor = SystemColors.Highlight;
            this.label3.Location = new Point(12, 0x2b);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x48, 0x13);
            this.label3.TabIndex = 0x1c;
            this.label3.Text = "Class Name";
            this.label3.TextAlign = ContentAlignment.MiddleLeft;
            this.txtClassName.BackColor = Color.White;
            this.txtClassName.Location = new Point(90, 0x2c);
            this.txtClassName.MaxLength = 100;
            this.txtClassName.Name = "txtClassName";
            this.txtClassName.Size = new Size(0x16c, 20);
            this.txtClassName.TabIndex = 1;
            this.txtClassCode.BackColor = Color.White;
            this.txtClassCode.Location = new Point(90, 15);
            this.txtClassCode.MaxLength = 10;
            this.txtClassCode.Name = "txtClassCode";
            this.txtClassCode.Size = new Size(0x98, 20);
            this.txtClassCode.TabIndex = 0;
            this.txtClassCode.TextChanged += new EventHandler(this.txtClassCode_TextChanged);
            this.txtClassCode.KeyPress += new KeyPressEventHandler(this.txtClassCode_KeyPress);
            this.label9.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label9.ForeColor = SystemColors.Highlight;
            this.label9.Location = new Point(12, 15);
            this.label9.Name = "label9";
            this.label9.Size = new Size(110, 0x13);
            this.label9.TabIndex = 0x1a;
            this.label9.Text = "Class Code";
            this.label9.TextAlign = ContentAlignment.MiddleLeft;
            this.panel1.Controls.Add(this.btnView);
            this.panel1.Controls.Add(this.btnUpdate);
            this.panel1.Controls.Add(this.btnRefresh);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Location = new Point(6, 0x1ba);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(0x1f7, 0x2c);
            this.panel1.TabIndex = 0x11;
            this.btnView.Location = new Point(0x138, 12);
            this.btnView.Name = "btnView";
            this.btnView.Size = new Size(0x49, 0x17);
            this.btnView.TabIndex = 0x22;
            this.btnView.Text = "&View";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new EventHandler(this.btnView_Click);
            this.btnUpdate.Location = new Point(0x52, 12);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new Size(0x47, 0x17);
            this.btnUpdate.TabIndex = 6;
            this.btnUpdate.Text = "&Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new EventHandler(this.btnUpdate_Click);
            this.btnRefresh.Location = new Point(0x9f, 12);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new Size(0x47, 0x17);
            this.btnRefresh.TabIndex = 7;
            this.btnRefresh.Text = "&Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new EventHandler(this.btnRefresh_Click);
            this.btnSave.Location = new Point(5, 12);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new Size(0x47, 0x17);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new EventHandler(this.btnSave_Click);
            this.btnDelete.Location = new Point(0xeb, 12);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new Size(0x47, 0x17);
            this.btnDelete.TabIndex = 9;
            this.btnDelete.Text = "D&elete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new EventHandler(this.btnDelete_Click);
            this.btnExit.FlatAppearance.BorderColor = Color.FromArgb(0x40, 0x40, 0x40);
            this.btnExit.FlatAppearance.BorderSize = 5;
            this.btnExit.Location = new Point(0x1a3, 12);
            this.btnExit.Margin = new Padding(0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new Size(0x53, 0x17);
            this.btnExit.TabIndex = 10;
            this.btnExit.Text = "E&xit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new EventHandler(this.btnExit_Click);
            this.label8.AutoSize = true;
            this.label8.Font = new Font("Tahoma", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.label8.ForeColor = Color.Black;
            this.label8.Location = new Point(0x69, 9);
            this.label8.Name = "label8";
            this.label8.Size = new Size(0xae, 0x13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Class Master Details";
            this.label2.AutoSize = true;
            this.label2.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label2.ForeColor = Color.Black;
            this.label2.Location = new Point(0x92, 30);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0xe4, 0x10);
            this.label2.TabIndex = 1;
            this.label2.Text = "User can maintain class master details";
            this.panel2.BackColor = Color.White;
            this.panel2.BorderStyle = BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Location = new Point(-11, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new Size(570, 0x45);
            this.panel2.TabIndex = 0x12;
            this.pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            this.pictureBox1.Image = (Image) manager.GetObject("pictureBox1.Image");
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new Point(0x18, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new Size(0x4c, 0x34);
            this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0xab;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Tag = "operator_128.jpg";
            this.errClass.ContainerControl = this;
            this.dataGridViewTextBoxColumn1.HeaderText = "Strat Time";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 80;
            this.dataGridViewTextBoxColumn2.HeaderText = "End Time";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 80;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x209, 0x1e9);
            base.Controls.Add(this.panel2);
            base.Controls.Add(this.panel1);
            base.Controls.Add(this.groupBox1);
            base.Name = "frmClassMaster";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Pool Attendance System";
            base.Load += new EventHandler(this.frmClassMaster_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((ISupportInitialize) this.dgvClassTimes).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((ISupportInitialize) this.pictureBox1).EndInit();
            ((ISupportInitialize) this.errClass).EndInit();
            base.ResumeLayout(false);
        }

        private void InsertUpdateClassMasterTimes()
        {
            this.oClassTimeTable.LocationCode = this.cGlobleVariable.LocationCode;
            this.oClassTimeTable.ClassCode = this.txtClassCode.Text;
            for (int i = 0; i < (this.dgvClassTimes.Rows.Count - 1); i++)
            {
                string newClassTimeCode = this.cClassTimeTable.GetNewClassTimeCode(this.cGlobleVariable.LocationCode, this.txtClassCode.Text);
                if (Convert.ToString(this.dgvClassTimes.Rows[i].Cells[0].Value) != "")
                {
                    newClassTimeCode = this.dgvClassTimes.Rows[i].Cells[0].Value.ToString();
                }
                this.oClassTimeTable.ClassTimeCode = newClassTimeCode;
                this.oClassTimeTable.DayType = this.dgvClassTimes.Rows[i].Cells[1].Value.ToString();
                this.oClassTimeTable.InTime = this.dgvClassTimes.Rows[i].Cells[3].Value.ToString();
                this.oClassTimeTable.OutTime = this.dgvClassTimes.Rows[i].Cells[4].Value.ToString();
                this.oClassTimeTable.Session = this.dgvClassTimes.Rows[i].Cells[2].Value.ToString();
                this.oClassTimeTable.Status = this.cGlobleVariable.ActiveStatusCode;
                this.cClassTimeTable.InsertUpdateData(this.oClassTimeTable);
            }
        }

        private void txtClassCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                this.oClassMaster = this.cClassMaster.GetClassData(this.cGlobleVariable.LocationCode, this.txtClassCode.Text.ToString());
                if (this.oClassMaster.ClassIsExist)
                {
                    this.txtClassName.Text = this.oClassMaster.ClassName;
                    this.cmbClassStatus.SetText(this.oClassMaster.ClassStatus);
                }
                this.cCommanMethods.MoveNextControl(e);
            }
        }

        private void txtClassCode_TextChanged(object sender, EventArgs e)
        {
            this.oClassMaster = this.cClassMaster.GetClassData(this.cGlobleVariable.LocationCode, this.txtClassCode.Text.ToString());
            if (this.oClassMaster.ClassIsExist)
            {
                this.txtClassName.Text = this.oClassMaster.ClassName;
                this.cmbClassStatus.SetText(this.oClassMaster.ClassStatus);
                this.txtTotalStudents.Text = this.oClassMaster.ClassTotalStudents.ToString();
                this.txtCroupDays.Text = this.oClassMaster.ClassCoverUpDays.ToString();
                DataTable table = this.cClassTimeTable.GetClassTimeDetails(this.cGlobleVariable.LocationCode, this.txtClassCode.Text.ToString(), this.cGlobleVariable.ActiveStatusCode);
                this.dgvClassTimes.Rows.Clear();
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    this.dgvClassTimes.Rows.Add(1);
                    this.dgvClassTimes.Rows[i].Cells[0].Value = table.Rows[i][3].ToString();
                    this.dgvClassTimes.Rows[i].Cells[1].Value = table.Rows[i][4].ToString();
                    this.dgvClassTimes.Rows[i].Cells[2].Value = table.Rows[i][7].ToString();
                    this.dgvClassTimes.Rows[i].Cells[3].Value = table.Rows[i][5].ToString();
                    this.dgvClassTimes.Rows[i].Cells[4].Value = table.Rows[i][6].ToString();
                }
            }
        }

        private bool ValidateData()
        {
            bool flag = true;
            if (this.txtClassCode.Text == "")
            {
                this.errClass.SetError(this.txtClassCode, "Please enter class code");
                flag = false;
            }
            else
            {
                this.errClass.SetError(this.txtClassCode, "");
            }
            if (this.txtClassName.Text == "")
            {
                this.errClass.SetError(this.txtClassName, "Please enter class name");
                flag = false;
            }
            else
            {
                this.errClass.SetError(this.txtClassName, "");
            }
            if (this.cmbClassStatus.Text == "")
            {
                this.errClass.SetError(this.cmbClassStatus, "Please select status");
                return false;
            }
            this.errClass.SetError(this.cmbClassStatus, "");
            return flag;
        }

        public void ViewEmployee()
        {
            string[] strFieldList = new string[] { "fldClassCode", "fldClassName" };
            string[] strHeadingList = new string[] { "Class Code", "Class Name" };
            int[] iHeaderWidth = new int[] { 80, 100 };
            string strReturnField = "Class Code";
            string str2 = "fldLocationCode = '" + this.cGlobleVariable.LocationCode + "' ";
            this.txtClassCode.Text = this.cCommanMethods.BrowsData("tbl_class_master", strFieldList, strHeadingList, iHeaderWidth, strReturnField, str2);
        }
    }
}

