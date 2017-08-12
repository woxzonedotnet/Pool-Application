namespace Pool_Application
{
    using Business_Layer;
    using Business_Layer.Property_Layer;
    using JTG;
    using Report_Layer;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;

    public class frmDailyPaymentDetails : Form
    {
        public Button btnExit;
        private Button btnPrint;
        public Button btnRefresh;
        public Button btnSave;
        private Button btnView;
        private Button button1;
        private clsClassMaster cClassMaster = new clsClassMaster();
        private clsCommenMethods cCommenMethods = new clsCommenMethods();
        private clsDailyPaymentDetails cDailyPaymentDetails = new clsDailyPaymentDetails();
        private clsGlobleVariable cGlobleVariable = new clsGlobleVariable();
        private ColumnComboBox cmbClassName;
        private DataGridViewTextBoxColumn Column1;
        private IContainer components = null;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridView dgvStudentNameList;
        private DateTimePicker dtpInvoiceDate;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label8;
        private Panel panel2;
        private PictureBox pictureBox1;
        private TextBox txtAmount;
        private TextBox txtInvoiceNumber;
        private TextBox txtStudentName;

        public frmDailyPaymentDetails()
        {
            this.InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.cCommenMethods.ClearForm(this);
            this.txtInvoiceNumber.Text = this.cDailyPaymentDetails.GetNextInvNo();
            this.dtpInvoiceDate.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            objDailyPaymentDetails oDailyPaymentDetails = new objDailyPaymentDetails {
                InvoiceNo = this.txtInvoiceNumber.Text,
                StudentName = this.txtStudentName.Text,
                InvoiceDate = this.dtpInvoiceDate.Value,
                LevelCode = this.cmbClassName["fldClassCode"].ToString(),
                InvoiceAmount = Convert.ToDouble(Convert.ToString(this.txtAmount.Text)),
                UserCode = this.cGlobleVariable.CurrentUserID,
                InvoiceStatus = "A"
            };
            this.cDailyPaymentDetails.InsertUpdateData(oDailyPaymentDetails);
            object[,] arrParameter = new object[,] { { "strCopyRight", this.cGlobleVariable.CopyRight }, { "strInvoiceNo", this.txtStudentName.Text } };
            frmReportViever viever = new frmReportViever(this.SelectionFormularValues(), arrParameter, "DP");
            this.cCommenMethods.ClearForm(this);
            this.txtInvoiceNumber.Text = this.cDailyPaymentDetails.GetNextInvNo();
            this.dtpInvoiceDate.Focus();
        }

        private void cmbClassName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                this.txtAmount.Focus();
            }
        }

        private void dgvStudentNameList_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.txtStudentName.Text = this.dgvStudentNameList.Rows[e.RowIndex].Cells[0].Value.ToString();
            this.dgvStudentNameList.Visible = false;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void dtpInvoiceDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtStudentName.Focus();
            }
        }

        private void frmDailyPaymentDetails_Click(object sender, EventArgs e)
        {
            this.dgvStudentNameList.Visible = false;
        }

        private void frmDailyPaymentDetails_Load(object sender, EventArgs e)
        {
            this.txtInvoiceNumber.Text = this.cDailyPaymentDetails.GetNextInvNo();
            DataTable classDetails = this.cClassMaster.GetClassDetails(this.cGlobleVariable.LocationCode, this.cGlobleVariable.ActiveStatusCode);
            this.cCommenMethods.LoadCombo(classDetails, this.cmbClassName, 3);
            this.cmbClassName.SelectedIndex = 0;
        }

        private void InitializeComponent()
        {
            ComponentResourceManager manager = new ComponentResourceManager(typeof(frmDailyPaymentDetails));
            DataGridViewCellStyle style = new DataGridViewCellStyle();
            this.pictureBox1 = new PictureBox();
            this.panel2 = new Panel();
            this.label2 = new Label();
            this.label8 = new Label();
            this.txtInvoiceNumber = new TextBox();
            this.label1 = new Label();
            this.dtpInvoiceDate = new DateTimePicker();
            this.label3 = new Label();
            this.txtStudentName = new TextBox();
            this.label4 = new Label();
            this.txtAmount = new TextBox();
            this.label5 = new Label();
            this.label6 = new Label();
            this.dgvStudentNameList = new DataGridView();
            this.btnPrint = new Button();
            this.btnView = new Button();
            this.btnRefresh = new Button();
            this.btnSave = new Button();
            this.btnExit = new Button();
            this.button1 = new Button();
            this.dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            this.Column1 = new DataGridViewTextBoxColumn();
            this.cmbClassName = new ColumnComboBox();
            ((ISupportInitialize) this.pictureBox1).BeginInit();
            this.panel2.SuspendLayout();
            ((ISupportInitialize) this.dgvStudentNameList).BeginInit();
            base.SuspendLayout();
            this.pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            this.pictureBox1.Image = (Image) manager.GetObject("pictureBox1.Image");
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new Point(13, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new Size(0x4c, 0x34);
            this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0xab;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Tag = "operator_128.jpg";
            this.panel2.BackColor = Color.White;
            this.panel2.BorderStyle = BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Location = new Point(-3, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new Size(0x3e4, 0x45);
            this.panel2.TabIndex = 0x13;
            this.label2.AutoSize = true;
            this.label2.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label2.ForeColor = Color.Black;
            this.label2.Location = new Point(150, 0x1d);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x119, 0x10);
            this.label2.TabIndex = 1;
            this.label2.Text = "User can maintain student daily payment details";
            this.label8.AutoSize = true;
            this.label8.Font = new Font("Tahoma", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.label8.ForeColor = Color.Black;
            this.label8.Location = new Point(0x6d, 8);
            this.label8.Name = "label8";
            this.label8.Size = new Size(0xc9, 0x13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Student daily payments";
            this.txtInvoiceNumber.BackColor = Color.White;
            this.txtInvoiceNumber.Location = new Point(110, 0x54);
            this.txtInvoiceNumber.MaxLength = 10;
            this.txtInvoiceNumber.Name = "txtInvoiceNumber";
            this.txtInvoiceNumber.Size = new Size(0x98, 20);
            this.txtInvoiceNumber.TabIndex = 0x1b;
            this.label1.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label1.ForeColor = SystemColors.Highlight;
            this.label1.Location = new Point(12, 0x54);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x5c, 0x13);
            this.label1.TabIndex = 30;
            this.label1.Text = "Invoice Number";
            this.label1.TextAlign = ContentAlignment.MiddleLeft;
            this.dtpInvoiceDate.Format = DateTimePickerFormat.Short;
            this.dtpInvoiceDate.Location = new Point(110, 110);
            this.dtpInvoiceDate.Name = "dtpInvoiceDate";
            this.dtpInvoiceDate.Size = new Size(0x66, 20);
            this.dtpInvoiceDate.TabIndex = 0xe5;
            this.dtpInvoiceDate.KeyDown += new KeyEventHandler(this.dtpInvoiceDate_KeyDown);
            this.label3.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label3.ForeColor = SystemColors.Highlight;
            this.label3.Location = new Point(12, 0x6b);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x4b, 0x13);
            this.label3.TabIndex = 230;
            this.label3.Text = "Invoice Date";
            this.label3.TextAlign = ContentAlignment.MiddleLeft;
            this.txtStudentName.BackColor = Color.White;
            this.txtStudentName.Location = new Point(0x6d, 0x85);
            this.txtStudentName.MaxLength = 10;
            this.txtStudentName.Name = "txtStudentName";
            this.txtStudentName.Size = new Size(0x22d, 20);
            this.txtStudentName.TabIndex = 0;
            this.txtStudentName.TextChanged += new EventHandler(this.txtStudentName_TextChanged);
            this.txtStudentName.KeyDown += new KeyEventHandler(this.txtStudentName_KeyDown);
            this.txtStudentName.KeyPress += new KeyPressEventHandler(this.txtStudentName_KeyPress);
            this.label4.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label4.ForeColor = SystemColors.Highlight;
            this.label4.Location = new Point(12, 0x85);
            this.label4.Name = "label4";
            this.label4.Size = new Size(110, 0x13);
            this.label4.TabIndex = 0xe8;
            this.label4.Text = "Student Name";
            this.label4.TextAlign = ContentAlignment.MiddleLeft;
            this.txtAmount.BackColor = Color.White;
            this.txtAmount.Location = new Point(110, 0xba);
            this.txtAmount.MaxLength = 10;
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new Size(0x98, 20);
            this.txtAmount.TabIndex = 2;
            this.txtAmount.KeyPress += new KeyPressEventHandler(this.txtAmount_KeyPress);
            this.label5.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label5.ForeColor = SystemColors.Highlight;
            this.label5.Location = new Point(8, 0xc3);
            this.label5.Name = "label5";
            this.label5.Size = new Size(110, 0x13);
            this.label5.TabIndex = 0xec;
            this.label5.Text = "Amount";
            this.label5.TextAlign = ContentAlignment.MiddleLeft;
            this.label6.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label6.ForeColor = SystemColors.Highlight;
            this.label6.Location = new Point(12, 0x9f);
            this.label6.Name = "label6";
            this.label6.Size = new Size(0x4b, 0x13);
            this.label6.TabIndex = 0xed;
            this.label6.Text = "Level";
            this.label6.TextAlign = ContentAlignment.MiddleLeft;
            this.dgvStudentNameList.AllowUserToAddRows = false;
            this.dgvStudentNameList.AllowUserToDeleteRows = false;
            this.dgvStudentNameList.AllowUserToOrderColumns = true;
            this.dgvStudentNameList.AllowUserToResizeColumns = false;
            this.dgvStudentNameList.AllowUserToResizeRows = false;
            this.dgvStudentNameList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStudentNameList.ColumnHeadersVisible = false;
            this.dgvStudentNameList.Columns.AddRange(new DataGridViewColumn[] { this.Column1 });
            style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            style.BackColor = SystemColors.Window;
            style.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            style.ForeColor = SystemColors.ControlText;
            style.SelectionBackColor = Color.FromArgb(0xff, 0x80, 0x80);
            style.SelectionForeColor = SystemColors.HighlightText;
            style.WrapMode = DataGridViewTriState.False;
            this.dgvStudentNameList.DefaultCellStyle = style;
            this.dgvStudentNameList.Location = new Point(110, 0x9a);
            this.dgvStudentNameList.Name = "dgvStudentNameList";
            this.dgvStudentNameList.RowHeadersVisible = false;
            this.dgvStudentNameList.RowHeadersWidth = 100;
            this.dgvStudentNameList.RowTemplate.ReadOnly = true;
            this.dgvStudentNameList.Size = new Size(0x22c, 0xa3);
            this.dgvStudentNameList.TabIndex = 0xee;
            this.dgvStudentNameList.Visible = false;
            this.dgvStudentNameList.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(this.dgvStudentNameList_CellMouseDoubleClick);
            this.btnPrint.Location = new Point(0xab, 0xf2);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new Size(0x4b, 0x1a);
            this.btnPrint.TabIndex = 0xf3;
            this.btnPrint.Text = "&Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new EventHandler(this.btnPrint_Click);
            this.btnView.Location = new Point(0xfc, 0xf3);
            this.btnView.Name = "btnView";
            this.btnView.Size = new Size(0x4b, 0x1a);
            this.btnView.TabIndex = 0xf2;
            this.btnView.Text = "&View";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnRefresh.Location = new Point(11, 0xf2);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new Size(0x49, 0x1a);
            this.btnRefresh.TabIndex = 0xf1;
            this.btnRefresh.Text = "&Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new EventHandler(this.btnRefresh_Click);
            this.btnSave.Location = new Point(-90, 0xab);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new Size(0x49, 0x17);
            this.btnSave.TabIndex = 0xef;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnExit.FlatAppearance.BorderColor = Color.FromArgb(0x40, 0x40, 0x40);
            this.btnExit.FlatAppearance.BorderSize = 5;
            this.btnExit.Location = new Point(0x14e, 0xf2);
            this.btnExit.Margin = new Padding(0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new Size(0x53, 0x1c);
            this.btnExit.TabIndex = 240;
            this.btnExit.Text = "E&xit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new EventHandler(this.btnExit_Click);
            this.button1.Location = new Point(90, 0xf2);
            this.button1.Name = "button1";
            this.button1.Size = new Size(0x4b, 0x1a);
            this.button1.TabIndex = 0xf4;
            this.button1.Text = "&Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new EventHandler(this.button1_Click);
            this.dataGridViewTextBoxColumn1.HeaderText = "Column1";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 520;
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            this.Column1.Width = 520;
            this.cmbClassName.DrawMode = DrawMode.OwnerDrawVariable;
            this.cmbClassName.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbClassName.DropDownWidth = 0x11;
            this.cmbClassName.FormattingEnabled = true;
            this.cmbClassName.Location = new Point(0x6f, 0x9f);
            this.cmbClassName.Name = "cmbClassName";
            this.cmbClassName.Size = new Size(210, 0x15);
            this.cmbClassName.TabIndex = 1;
            this.cmbClassName.ViewColumn = 0;
            this.cmbClassName.KeyPress += new KeyPressEventHandler(this.cmbClassName_KeyPress);
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x2ae, 330);
            base.Controls.Add(this.dgvStudentNameList);
            base.Controls.Add(this.button1);
            base.Controls.Add(this.btnPrint);
            base.Controls.Add(this.btnView);
            base.Controls.Add(this.btnRefresh);
            base.Controls.Add(this.btnSave);
            base.Controls.Add(this.btnExit);
            base.Controls.Add(this.label6);
            base.Controls.Add(this.txtAmount);
            base.Controls.Add(this.label5);
            base.Controls.Add(this.cmbClassName);
            base.Controls.Add(this.txtStudentName);
            base.Controls.Add(this.label4);
            base.Controls.Add(this.label3);
            base.Controls.Add(this.dtpInvoiceDate);
            base.Controls.Add(this.label1);
            base.Controls.Add(this.txtInvoiceNumber);
            base.Controls.Add(this.panel2);
            base.Name = "frmDailyPaymentDetails";
            this.Text = "Daily payments";
            base.Load += new EventHandler(this.frmDailyPaymentDetails_Load);
            base.Click += new EventHandler(this.frmDailyPaymentDetails_Click);
            ((ISupportInitialize) this.pictureBox1).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((ISupportInitialize) this.dgvStudentNameList).EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        private string SelectionFormularValues()
        {
            return "{tbl_daily_payment_details.fldInvoiceNo}={?strInvoiceNo}";
        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                this.btnSave.Focus();
            }
        }

        private void txtStudentName_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Down) && this.dgvStudentNameList.Visible)
            {
                this.dgvStudentNameList.Focus();
            }
        }

        private void txtStudentName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                this.cmbClassName.Focus();
            }
        }

        private void txtStudentName_TextChanged(object sender, EventArgs e)
        {
            this.dgvStudentNameList.Visible = false;
            if (this.txtStudentName.Text != "")
            {
                DataTable studentsNames = this.cDailyPaymentDetails.GetStudentsNames(this.txtStudentName.Text);
                this.dgvStudentNameList.Rows.Clear();
                if (studentsNames.Rows.Count > 0)
                {
                    this.dgvStudentNameList.Visible = true;
                    for (int i = 0; i < studentsNames.Rows.Count; i++)
                    {
                        this.dgvStudentNameList.Rows.Add();
                        this.dgvStudentNameList.Rows[i].Cells[0].Value = studentsNames.Rows[i]["fldStudentName"].ToString();
                    }
                }
            }
        }
    }
}

