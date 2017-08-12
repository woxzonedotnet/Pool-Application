namespace Pool_Application
{
    using Business_Layer;
    using Business_Layer.Property_Layer;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class frmReadBarcodeCoacher : Form
    {
        public Button btnRefresh;
        private clsCoacherMaster cCoacherMaster = new clsCoacherMaster();
        private clsCommenMethods cCommanMethods = new clsCommenMethods();
        private clsCommenMethods cCommenMethods = new clsCommenMethods();
        private clsGlobleVariable cGlobleVariable = new clsGlobleVariable();
        private IContainer components = null;
        private clsReadBarcodeCoacher cReadBarcodeCoacher = new clsReadBarcodeCoacher();
        private GroupBox groupBox1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label5;
        private Label lblDate;
        private Label lblTime;
        private objCoacherMaster oCoacherMaster = new objCoacherMaster();
        private objReadBarcodeCoacher oReadBarcodeCoacher = new objReadBarcodeCoacher();
        private Timer timer1;
        private TextBox txtCoacherName;
        private TextBox txtCoacherNo;

        public frmReadBarcodeCoacher()
        {
            this.InitializeComponent();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.cCommanMethods.ClearForm(this);
            this.txtCoacherNo.Focus();
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
            this.components = new Container();
            this.timer1 = new Timer(this.components);
            this.groupBox1 = new GroupBox();
            this.btnRefresh = new Button();
            this.label5 = new Label();
            this.lblDate = new Label();
            this.label2 = new Label();
            this.txtCoacherName = new TextBox();
            this.lblTime = new Label();
            this.label1 = new Label();
            this.label3 = new Label();
            this.txtCoacherNo = new TextBox();
            this.groupBox1.SuspendLayout();
            base.SuspendLayout();
            this.timer1.Enabled = true;
            this.timer1.Tick += new EventHandler(this.timer1_Tick);
            this.groupBox1.Controls.Add(this.btnRefresh);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lblDate);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtCoacherName);
            this.groupBox1.Controls.Add(this.lblTime);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtCoacherNo);
            this.groupBox1.Location = new Point(3, -2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(0x1c0, 0xa1);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.btnRefresh.Location = new Point(0x171, 0x7f);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new Size(0x49, 0x17);
            this.btnRefresh.TabIndex = 0xb0;
            this.btnRefresh.Text = "&Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new EventHandler(this.btnRefresh_Click);
            this.label5.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label5.ForeColor = SystemColors.Highlight;
            this.label5.Location = new Point(8, 0x68);
            this.label5.Name = "label5";
            this.label5.Size = new Size(0x5d, 0x13);
            this.label5.TabIndex = 0x30;
            this.label5.Text = "Time";
            this.label5.TextAlign = ContentAlignment.MiddleLeft;
            this.lblDate.BorderStyle = BorderStyle.Fixed3D;
            this.lblDate.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.lblDate.ForeColor = SystemColors.Highlight;
            this.lblDate.Location = new Point(0x69, 0x4c);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new Size(0x9b, 0x13);
            this.lblDate.TabIndex = 0x2f;
            this.lblDate.Text = "Date";
            this.lblDate.TextAlign = ContentAlignment.MiddleLeft;
            this.label2.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label2.ForeColor = SystemColors.Highlight;
            this.label2.Location = new Point(8, 0x4c);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x5d, 0x13);
            this.label2.TabIndex = 0x2e;
            this.label2.Text = "Date";
            this.label2.TextAlign = ContentAlignment.MiddleLeft;
            this.txtCoacherName.BackColor = Color.White;
            this.txtCoacherName.Location = new Point(0x69, 0x2d);
            this.txtCoacherName.MaxLength = 10;
            this.txtCoacherName.Name = "txtCoacherName";
            this.txtCoacherName.Size = new Size(0x14f, 20);
            this.txtCoacherName.TabIndex = 0x2c;
            this.lblTime.BorderStyle = BorderStyle.Fixed3D;
            this.lblTime.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.lblTime.ForeColor = SystemColors.Highlight;
            this.lblTime.Location = new Point(0x69, 0x68);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new Size(0x9b, 0x13);
            this.lblTime.TabIndex = 0x31;
            this.lblTime.Text = "Date";
            this.lblTime.TextAlign = ContentAlignment.MiddleLeft;
            this.label1.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label1.ForeColor = SystemColors.Highlight;
            this.label1.Location = new Point(8, 0x2e);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x5d, 0x13);
            this.label1.TabIndex = 0x2d;
            this.label1.Text = "Coacher Name";
            this.label1.TextAlign = ContentAlignment.MiddleLeft;
            this.label3.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label3.ForeColor = SystemColors.Highlight;
            this.label3.Location = new Point(6, 20);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x5d, 0x13);
            this.label3.TabIndex = 0x2b;
            this.label3.Text = "Barcode Number";
            this.label3.TextAlign = ContentAlignment.MiddleLeft;
            this.txtCoacherNo.BackColor = Color.White;
            this.txtCoacherNo.Location = new Point(0x69, 0x13);
            this.txtCoacherNo.MaxLength = 10;
            this.txtCoacherNo.Name = "txtCoacherNo";
            this.txtCoacherNo.Size = new Size(0x9b, 20);
            this.txtCoacherNo.TabIndex = 0x2a;
            this.txtCoacherNo.TextChanged += new EventHandler(this.txtCoacherNo_TextChanged);
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x1c7, 0xa1);
            base.Controls.Add(this.groupBox1);
            base.Name = "frmReadBarcodeCoacher";
            this.Text = "Pool Attendance System";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            base.ResumeLayout(false);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.lblTime.Text = DateTime.Now.ToShortTimeString();
            this.lblDate.Text = DateTime.Now.ToShortDateString();
        }

        private void txtCoacherNo_TextChanged(object sender, EventArgs e)
        {
            this.oCoacherMaster = this.cCoacherMaster.GetCoacherData(this.cGlobleVariable.LocationCode, this.txtCoacherNo.Text);
            if (this.oCoacherMaster.CoacherIsExist)
            {
                this.txtCoacherName.Text = this.oCoacherMaster.FullNameLineOne;
                this.oReadBarcodeCoacher.LocationCode = this.cGlobleVariable.LocationCode;
                this.oReadBarcodeCoacher.CoacherCode = this.txtCoacherNo.Text;
                this.oReadBarcodeCoacher.LogDate = Convert.ToDateTime(this.lblDate.Text);
                this.oReadBarcodeCoacher.LogTime = Convert.ToDateTime(this.lblTime.Text);
                this.cReadBarcodeCoacher.InsertUpdate(this.oReadBarcodeCoacher);
                this.btnRefresh.Focus();
            }
        }
    }
}

