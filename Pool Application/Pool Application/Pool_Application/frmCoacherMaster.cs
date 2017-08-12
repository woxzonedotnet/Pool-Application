namespace Pool_Application
{
    using Business_Layer;
    using Business_Layer.Property_Layer;
    using JTG;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class frmCoacherMaster : Form
    {
        public Button btnDelete;
        public Button btnExit;
        public Button btnRefresh;
        public Button btnSave;
        public Button btnUpdate;
        private clsCoacherMaster cCoacherMaster = new clsCoacherMaster();
        private clsCommenMethods cCommanMethods = new clsCommenMethods();
        private clsGlobleVariable cGlobleVariable = new clsGlobleVariable();
        private ColumnComboBox cmbCoacherStatus;
        private IContainer components = null;
        private clsStatusMaster cStatusMaster = new clsStatusMaster();
        private ErrorProvider errCoacher;
        private GroupBox groupBox1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label8;
        private Label label9;
        private objCoacherMaster oCoacherMaster = new objCoacherMaster();
        private Panel panel1;
        private Panel panel2;
        private PictureBox pictureBox1;
        private TextBox txtCoacherCode;
        private TextBox txtCoacherName;

        public frmCoacherMaster()
        {
            this.InitializeComponent();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this?", "Delete Class", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.cCoacherMaster.DeleteClassMasterData(this.cGlobleVariable.LocationCode, this.txtCoacherCode.Text.ToString());
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
                this.oCoacherMaster.LocationCode = this.cGlobleVariable.LocationCode;
                this.oCoacherMaster.CoacherCode = this.txtCoacherCode.Text.ToString();
                this.oCoacherMaster.FullNameLineOne = this.txtCoacherName.Text.ToString();
                this.oCoacherMaster.CoacherStatus = this.cmbCoacherStatus["fld_Status_Code"].ToString();
                this.cCoacherMaster.InsertUpdateData(this.oCoacherMaster);
                MessageBox.Show(this.cGlobleVariable.SeavedMessage, "Coacher Details", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.cCommanMethods.ClearForm(this);
                this.txtCoacherCode.Focus();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (this.ValidateData())
            {
                this.oCoacherMaster.LocationCode = this.cGlobleVariable.LocationCode;
                this.oCoacherMaster.CoacherCode = this.txtCoacherCode.Text.ToString();
                this.oCoacherMaster.FullNameLineOne = this.txtCoacherName.Text.ToString();
                this.oCoacherMaster.CoacherStatus = this.cmbCoacherStatus["fld_Status_Code"].ToString();
                this.cCoacherMaster.InsertUpdateData(this.oCoacherMaster);
                MessageBox.Show(this.cGlobleVariable.UpdateMessage, "Coacher Details", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.cCommanMethods.ClearForm(this);
                this.txtCoacherCode.Focus();
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

        private void frmCoacher_Load(object sender, EventArgs e)
        {
            this.cCommanMethods.LoadCombo(this.cStatusMaster.GetStatusDetails(), this.cmbCoacherStatus, 1);
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            ComponentResourceManager manager = new ComponentResourceManager(typeof(frmCoacherMaster));
            this.label2 = new Label();
            this.groupBox1 = new GroupBox();
            this.label1 = new Label();
            this.label3 = new Label();
            this.txtCoacherName = new TextBox();
            this.txtCoacherCode = new TextBox();
            this.label9 = new Label();
            this.panel2 = new Panel();
            this.label8 = new Label();
            this.panel1 = new Panel();
            this.btnUpdate = new Button();
            this.btnRefresh = new Button();
            this.btnSave = new Button();
            this.btnDelete = new Button();
            this.btnExit = new Button();
            this.errCoacher = new ErrorProvider(this.components);
            this.cmbCoacherStatus = new ColumnComboBox();
            this.pictureBox1 = new PictureBox();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((ISupportInitialize) this.errCoacher).BeginInit();
            ((ISupportInitialize) this.pictureBox1).BeginInit();
            base.SuspendLayout();
            this.label2.AutoSize = true;
            this.label2.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label2.ForeColor = Color.Black;
            this.label2.Location = new Point(0x81, 0x23);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x12d, 0x10);
            this.label2.TabIndex = 1;
            this.label2.Text = "User can maintain coacher details using this wizard";
            this.groupBox1.BackColor = Color.Transparent;
            this.groupBox1.Controls.Add(this.cmbCoacherStatus);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtCoacherName);
            this.groupBox1.Controls.Add(this.txtCoacherCode);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.FlatStyle = FlatStyle.Popup;
            this.groupBox1.Location = new Point(5, 0x47);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(0x1f7, 0x69);
            this.groupBox1.TabIndex = 0x13;
            this.groupBox1.TabStop = false;
            this.label1.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label1.ForeColor = SystemColors.Highlight;
            this.label1.Location = new Point(12, 0x48);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x70, 0x13);
            this.label1.TabIndex = 0x22;
            this.label1.Text = "Status";
            this.label1.TextAlign = ContentAlignment.MiddleLeft;
            this.label3.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label3.ForeColor = SystemColors.Highlight;
            this.label3.Location = new Point(12, 0x2b);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x52, 0x13);
            this.label3.TabIndex = 0x1c;
            this.label3.Text = "Coacher Name";
            this.label3.TextAlign = ContentAlignment.MiddleLeft;
            this.txtCoacherName.BackColor = Color.White;
            this.txtCoacherName.Location = new Point(0x5e, 0x2c);
            this.txtCoacherName.MaxLength = 100;
            this.txtCoacherName.Name = "txtCoacherName";
            this.txtCoacherName.Size = new Size(0x16c, 20);
            this.txtCoacherName.TabIndex = 1;
            this.txtCoacherCode.BackColor = Color.White;
            this.txtCoacherCode.Location = new Point(0x5e, 15);
            this.txtCoacherCode.MaxLength = 10;
            this.txtCoacherCode.Name = "txtCoacherCode";
            this.txtCoacherCode.Size = new Size(0x98, 20);
            this.txtCoacherCode.TabIndex = 0;
            this.txtCoacherCode.KeyPress += new KeyPressEventHandler(this.txtCoacherCode_KeyPress);
            this.label9.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label9.ForeColor = SystemColors.Highlight;
            this.label9.Location = new Point(12, 15);
            this.label9.Name = "label9";
            this.label9.Size = new Size(110, 0x13);
            this.label9.TabIndex = 0x1a;
            this.label9.Text = "Coacher Code";
            this.label9.TextAlign = ContentAlignment.MiddleLeft;
            this.panel2.BackColor = Color.White;
            this.panel2.BorderStyle = BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Location = new Point(-15, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new Size(570, 0x45);
            this.panel2.TabIndex = 0x15;
            this.label8.AutoSize = true;
            this.label8.Font = new Font("Tahoma", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.label8.ForeColor = Color.Black;
            this.label8.Location = new Point(0x65, 8);
            this.label8.Name = "label8";
            this.label8.Size = new Size(0xc6, 0x13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Coacher Master Details";
            this.panel1.Controls.Add(this.btnUpdate);
            this.panel1.Controls.Add(this.btnRefresh);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Location = new Point(6, 0xb6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(0x1f7, 0x3f);
            this.panel1.TabIndex = 20;
            this.btnUpdate.Location = new Point(0x9d, 0x15);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new Size(0x47, 0x17);
            this.btnUpdate.TabIndex = 6;
            this.btnUpdate.Text = "&Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new EventHandler(this.btnUpdate_Click);
            this.btnRefresh.Location = new Point(3, 0x15);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new Size(0x47, 0x17);
            this.btnRefresh.TabIndex = 7;
            this.btnRefresh.Text = "&Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new EventHandler(this.btnRefresh_Click);
            this.btnSave.Location = new Point(80, 0x15);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new Size(0x47, 0x17);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new EventHandler(this.btnSave_Click);
            this.btnDelete.Location = new Point(0xea, 0x15);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new Size(0x47, 0x17);
            this.btnDelete.TabIndex = 9;
            this.btnDelete.Text = "D&elete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new EventHandler(this.btnDelete_Click);
            this.btnExit.FlatAppearance.BorderColor = Color.FromArgb(0x40, 0x40, 0x40);
            this.btnExit.FlatAppearance.BorderSize = 5;
            this.btnExit.Location = new Point(0x1a2, 0x15);
            this.btnExit.Margin = new Padding(0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new Size(0x53, 0x17);
            this.btnExit.TabIndex = 10;
            this.btnExit.Text = "E&xit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new EventHandler(this.btnExit_Click);
            this.errCoacher.ContainerControl = this;
            this.cmbCoacherStatus.DrawMode = DrawMode.OwnerDrawVariable;
            this.cmbCoacherStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbCoacherStatus.DropDownWidth = 0x11;
            this.cmbCoacherStatus.FormattingEnabled = true;
            this.cmbCoacherStatus.Location = new Point(0x5e, 0x48);
            this.cmbCoacherStatus.Name = "cmbCoacherStatus";
            this.cmbCoacherStatus.Size = new Size(0x98, 0x15);
            this.cmbCoacherStatus.TabIndex = 4;
            this.cmbCoacherStatus.ViewColumn = 0;
            this.pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            this.pictureBox1.Image = (Image) manager.GetObject("pictureBox1.Image");
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new Point(0x13, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new Size(0x4c, 0x34);
            this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0xab;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Tag = "operator_128.jpg";
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x205, 0xfd);
            base.Controls.Add(this.groupBox1);
            base.Controls.Add(this.panel2);
            base.Controls.Add(this.panel1);
            base.Name = "frmCoacherMaster";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Pool Attendance System";
            base.Load += new EventHandler(this.frmCoacher_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((ISupportInitialize) this.errCoacher).EndInit();
            ((ISupportInitialize) this.pictureBox1).EndInit();
            base.ResumeLayout(false);
        }

        private void txtCoacherCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                this.oCoacherMaster = this.cCoacherMaster.GetCoacherData(this.cGlobleVariable.LocationCode, this.txtCoacherCode.Text.ToString());
                if (this.oCoacherMaster.CoacherIsExist)
                {
                    this.cmbCoacherStatus.SetText(this.oCoacherMaster.CoacherStatus);
                }
                this.cCommanMethods.MoveNextControl(e);
            }
        }

        private bool ValidateData()
        {
            bool flag = true;
            if (this.txtCoacherCode.Text == "")
            {
                this.errCoacher.SetError(this.txtCoacherCode, "Please enter coacher code");
                flag = false;
            }
            else
            {
                this.errCoacher.SetError(this.txtCoacherCode, "");
            }
            if (this.txtCoacherName.Text == "")
            {
                this.errCoacher.SetError(this.txtCoacherName, "Please enter coacher name");
                flag = false;
            }
            else
            {
                this.errCoacher.SetError(this.txtCoacherName, "");
            }
            if (this.cmbCoacherStatus.Text == "")
            {
                this.errCoacher.SetError(this.cmbCoacherStatus, "Please select status");
                return false;
            }
            this.errCoacher.SetError(this.cmbCoacherStatus, "");
            return flag;
        }
    }
}

