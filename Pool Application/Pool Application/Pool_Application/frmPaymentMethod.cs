namespace Pool_Application
{
    using Business_Layer;
    using Business_Layer.Property_Layer;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class frmPaymentMethod : Form
    {
        public Button btnDelete;
        public Button btnExit;
        public Button btnRefresh;
        public Button btnSave;
        public Button btnView;
        private clsCommenMethods cCommenMethods = new clsCommenMethods();
        private clsGlobleVariable cGlobleVariable = new clsGlobleVariable();
        private IContainer components = null;
        private clsPaymentMethod cPaymentMethod = new clsPaymentMethod();
        private clsStatusMaster cStatusMaster = new clsStatusMaster();
        private GroupBox groupBox1;
        private Label label1;
        private Label label2;
        private Label label5;
        private objPaymentMethod oPaymentMethod = new objPaymentMethod();
        private Panel panel1;
        private TextBox txtPaymentCode;
        private TextBox txtPaymentDays;
        private TextBox txtPaymentDescription;

        public frmPaymentMethod()
        {
            this.InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.cCommenMethods.ClearForm(this);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if ((this.txtPaymentCode.Text != string.Empty) && (this.txtPaymentDays.Text != string.Empty))
            {
                this.oPaymentMethod.LocationCode = this.cGlobleVariable.LocationCode;
                this.oPaymentMethod.PaymentCode = this.txtPaymentCode.Text;
                this.oPaymentMethod.PaymentDays = Convert.ToDouble(this.txtPaymentDays.Text);
                this.oPaymentMethod.PaymentDescription = this.txtPaymentDescription.Text;
                this.cPaymentMethod.InsertUpdateData(this.oPaymentMethod);
                MessageBox.Show(this.cGlobleVariable.SeavedMessage, "Student Master details", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            this.ViewPaymentMethod();
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
            this.groupBox1 = new GroupBox();
            this.txtPaymentDescription = new TextBox();
            this.txtPaymentDays = new TextBox();
            this.label1 = new Label();
            this.txtPaymentCode = new TextBox();
            this.label2 = new Label();
            this.label5 = new Label();
            this.panel1 = new Panel();
            this.btnView = new Button();
            this.btnRefresh = new Button();
            this.btnSave = new Button();
            this.btnDelete = new Button();
            this.btnExit = new Button();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            base.SuspendLayout();
            this.groupBox1.Controls.Add(this.txtPaymentDescription);
            this.groupBox1.Controls.Add(this.txtPaymentDays);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtPaymentCode);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new Point(2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(0x1da, 0x6a);
            this.groupBox1.TabIndex = 0xd5;
            this.groupBox1.TabStop = false;
            this.txtPaymentDescription.BackColor = SystemColors.ActiveCaptionText;
            this.txtPaymentDescription.Location = new Point(0x7f, 0x45);
            this.txtPaymentDescription.MaxLength = 10;
            this.txtPaymentDescription.Name = "txtPaymentDescription";
            this.txtPaymentDescription.Size = new Size(0x151, 20);
            this.txtPaymentDescription.TabIndex = 2;
            this.txtPaymentDays.BackColor = SystemColors.ActiveCaptionText;
            this.txtPaymentDays.Location = new Point(0x7f, 40);
            this.txtPaymentDays.MaxLength = 10;
            this.txtPaymentDays.Name = "txtPaymentDays";
            this.txtPaymentDays.Size = new Size(0xc1, 20);
            this.txtPaymentDays.TabIndex = 1;
            this.label1.AutoSize = true;
            this.label1.Location = new Point(3, 0x45);
            this.label1.Name = "label1";
            this.label1.Size = new Size(90, 0x1a);
            this.label1.TabIndex = 0xd7;
            this.label1.Text = "Payment Method \r\nDescription:";
            this.txtPaymentCode.BackColor = SystemColors.ActiveCaptionText;
            this.txtPaymentCode.Location = new Point(0x7f, 14);
            this.txtPaymentCode.MaxLength = 10;
            this.txtPaymentCode.Name = "txtPaymentCode";
            this.txtPaymentCode.Size = new Size(0xc1, 20);
            this.txtPaymentCode.TabIndex = 0;
            this.txtPaymentCode.TextChanged += new EventHandler(this.txtPaymentCode_TextChanged);
            this.label2.AutoSize = true;
            this.label2.Location = new Point(3, 0x11);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x76, 13);
            this.label2.TabIndex = 0xd6;
            this.label2.Text = "Payment Method Code:";
            this.label5.AutoSize = true;
            this.label5.Location = new Point(3, 40);
            this.label5.Name = "label5";
            this.label5.Size = new Size(0x48, 13);
            this.label5.TabIndex = 0xd5;
            this.label5.Text = "Day Duration:";
            this.panel1.Controls.Add(this.btnView);
            this.panel1.Controls.Add(this.btnRefresh);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Location = new Point(2, 0x72);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(0x1da, 0x23);
            this.panel1.TabIndex = 0xd6;
            this.btnView.Location = new Point(0x52, 6);
            this.btnView.Name = "btnView";
            this.btnView.Size = new Size(0x49, 0x17);
            this.btnView.TabIndex = 0x24;
            this.btnView.Text = "&View";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new EventHandler(this.btnView_Click);
            this.btnRefresh.Location = new Point(0xa1, 6);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new Size(0x49, 0x17);
            this.btnRefresh.TabIndex = 0x20;
            this.btnRefresh.Text = "&Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new EventHandler(this.btnRefresh_Click);
            this.btnSave.Location = new Point(3, 6);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new Size(0x49, 0x17);
            this.btnSave.TabIndex = 0x15;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new EventHandler(this.btnSave_Click);
            this.btnDelete.Location = new Point(240, 6);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new Size(0x49, 0x17);
            this.btnDelete.TabIndex = 0x22;
            this.btnDelete.Text = "D&elete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnExit.FlatAppearance.BorderColor = Color.FromArgb(0x40, 0x40, 0x40);
            this.btnExit.FlatAppearance.BorderSize = 5;
            this.btnExit.Location = new Point(0x17d, 6);
            this.btnExit.Margin = new Padding(0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new Size(0x53, 0x17);
            this.btnExit.TabIndex = 0x23;
            this.btnExit.Text = "E&xit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new EventHandler(this.btnExit_Click);
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x1de, 0x99);
            base.Controls.Add(this.panel1);
            base.Controls.Add(this.groupBox1);
            base.Name = "frmPaymentMethod";
            this.Text = "Pool Attendance System";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            base.ResumeLayout(false);
        }

        private void txtPaymentCode_TextChanged(object sender, EventArgs e)
        {
            this.oPaymentMethod = this.cPaymentMethod.GetPaymentMethod(this.cGlobleVariable.LocationCode, this.txtPaymentCode.Text.ToString());
            if (this.oPaymentMethod.IxExist)
            {
                this.txtPaymentDays.Text = Convert.ToString(this.oPaymentMethod.PaymentDays);
                this.txtPaymentDescription.Text = this.oPaymentMethod.PaymentDescription;
            }
        }

        public void ViewPaymentMethod()
        {
            string[] strFieldList = new string[] { "fldPaymentMethodCode", "fldPaymentMethodDescription" };
            string[] strHeadingList = new string[] { "Payment Code", "Payment Description" };
            int[] iHeaderWidth = new int[] { 80, 100 };
            string strReturnField = "Payment Code";
            string str2 = "fldLocationCode = '" + this.cGlobleVariable.LocationCode + "' ";
            this.txtPaymentCode.Text = this.cCommenMethods.BrowsData("tbl_payment_method", strFieldList, strHeadingList, iHeaderWidth, strReturnField, str2);
        }
    }
}

