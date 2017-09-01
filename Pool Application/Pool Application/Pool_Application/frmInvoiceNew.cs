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

    public class frmInvoiceNew : Form
    {
        public Button btnExit;
        private Button btnPrint;
        public Button btnRefresh;
        public Button btnSave;
        private Button btnView;
        private clsAuditLog cAuditLog = new clsAuditLog();
        private clsAutoGenerator cAutoGenerator = new clsAutoGenerator();
        private clsClassMaster cClassMaster = new clsClassMaster();
        private clsCommenMethods cCommanMethods = new clsCommenMethods();
        private clsGlobleVariable cGlobleVariable = new clsGlobleVariable();
        private CheckBox chkIsTax;
        private clsInvoice cInvoice = new clsInvoice();
        private clsInvoiceItemAmounts cInvoiceItemAmounts = new clsInvoiceItemAmounts();
        private clsInvoiceTaxAmount cInvoiceTaxAmount = new clsInvoiceTaxAmount();
        private ColumnComboBox cmbClassName;
        private clsNBT cNBT = new clsNBT();
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private IContainer components = null;
        private clsPaymentDeatils cPaymentDeatils = new clsPaymentDeatils();
        private clsPaymentMethod cPaymentMethod = new clsPaymentMethod();
        private clsStudentMaster cStudentMaster = new clsStudentMaster();
        private clsTax cTax = new clsTax();
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        public double dbTotAmount = 0.0;
        private DataGridView dgvFeesItem;
        private DataGridView dgvTax;
        public double dRemoveEnrol = 0.0;
        private DateTimePicker dtpDateOfInvoice;
        private DateTimePicker dtpPayFrom;
        private DateTimePicker dtpPayTo;
        private ErrorProvider errInvoice;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Label label1;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label14;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label94;
        private Label lblLastPaymentMonth;
        private objAuditLog oAuditLog = new objAuditLog();
        private objAutoGenerator oAutoGenerator = new objAutoGenerator();
        private objInvoice oInvoice = new objInvoice();
        private objInvoiceItemAmounts oInvoiceItemAmounts = new objInvoiceItemAmounts();
        private objInvoiceTaxAmount oInvoiceTaxAmount = new objInvoiceTaxAmount();
        private objPaymentDeatils oPaymentDeatils = new objPaymentDeatils();
        private objPaymentMethod oPaymentMethod = new objPaymentMethod();
        private objStudentMaster oStudentMaster = new objStudentMaster();
        private Panel panel1;
        private TextBox txtFullNameLineOne;
        private TextBox txtFullNameLineTwo;
        private TextBox txtGrandTotal;
        private TextBox txtInvoiceNo;
        private TextBox txtNBT;
        private TextBox txtPenaltyAmount;
        private TextBox txtStudentDiscount;
        private TextBox txtStudentFees;
        private TextBox txtStudentNo;
        private TextBox txtTotal;
        private TextBox txtTotalAmt;
        private TextBox txtTotTax;

        public frmInvoiceNew()
        {
            this.InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.oAuditLog.LocationCode = this.cGlobleVariable.LocationCode;
            this.oAuditLog.UserID = this.cGlobleVariable.CurrentUserID;
            this.oAuditLog.MachineID = clsGlobleVariable.MachineID;
            this.oAuditLog.DateEntered = Convert.ToDateTime(this.cAuditLog.getCurrentDate().Rows[0][0].ToString());
            this.oAuditLog.TimeEntered = Convert.ToDateTime(this.cAuditLog.getCurrentTime().Rows[0][0].ToString());
            this.oAuditLog.Task = "Exited Invoice Entry";
            this.cAuditLog.AuditLog(this.oAuditLog);
            base.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            this.ReportViwer();
            this.oAuditLog.LocationCode = this.cGlobleVariable.LocationCode;
            this.oAuditLog.UserID = this.cGlobleVariable.CurrentUserID;
            this.oAuditLog.MachineID = clsGlobleVariable.MachineID;
            this.oAuditLog.DateEntered = Convert.ToDateTime(this.cAuditLog.getCurrentDate().Rows[0][0].ToString());
            this.oAuditLog.TimeEntered = Convert.ToDateTime(this.cAuditLog.getCurrentTime().Rows[0][0].ToString());
            this.oAuditLog.Task = "Printed Invoice No " + this.txtInvoiceNo.Text;
            this.cAuditLog.AuditLog(this.oAuditLog);
            this.RefreshPage();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.RefreshPage();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.txtInvoiceNo.Text == string.Empty)
            {
                if (this.ValidateData())
                {
                    this.oAutoGenerator = this.cAutoGenerator.GetAutoGeneratorNumber(this.cGlobleVariable.LocationCode);
                    if (this.txtInvoiceNo.Text == string.Empty)
                    {
                        if (this.oAutoGenerator.IsExistNumber)
                        {
                            this.oInvoice.InvoiceNo = this.oAutoGenerator.AutoNumberDescription + string.Format("{0:0000000}", this.oAutoGenerator.AutoNumber);
                        }
                    }
                    else
                    {
                        this.oInvoice.InvoiceNo = this.txtInvoiceNo.Text;
                    }
                    this.oInvoice.LocationCode = this.cGlobleVariable.LocationCode;
                    this.oInvoice.StudentNo = this.txtStudentNo.Text;
                    this.oInvoice.InvoiceDate = this.dtpDateOfInvoice.Value;
                    this.oInvoice.PaymentFromDate = this.dtpPayFrom.Value;
                    this.oInvoice.PaymentToDate = this.dtpPayTo.Value;
                    this.oInvoice.TotalItemAmount = Convert.ToDouble(this.txtTotal.Text);
                    this.oInvoice.NBTAmount = Convert.ToDouble(this.txtNBT.Text);
                    this.oInvoice.TotalTaxAmount = Convert.ToDouble(this.txtTotTax.Text);
                    this.oInvoice.Discount = Convert.ToDouble(this.txtStudentDiscount.Text);
                    this.oInvoice.PanaltyAmount = Convert.ToDouble(this.txtPenaltyAmount.Text);
                    this.oInvoice.GrandTotal = Convert.ToDouble(this.txtGrandTotal.Text);
                    this.oInvoice.UserCode = this.cGlobleVariable.CurrentUserID;
                    this.oInvoice.InvoiceStatus = this.cGlobleVariable.ActiveStatusCode;
                    this.oInvoice.IsTax = this.chkIsTax.Checked;
                    this.cInvoice.InsertUpdateData(this.oInvoice);
                    for (int i = 0; i < this.dgvFeesItem.Rows.Count; i++)
                    {
                        this.oInvoiceItemAmounts.LocationCode = this.cGlobleVariable.LocationCode;
                        this.oInvoiceItemAmounts.InvoiceNo = this.oInvoice.InvoiceNo;
                        this.oInvoiceItemAmounts.StudentNo = this.txtStudentNo.Text;
                        this.oInvoiceItemAmounts.InvoiceItemCode = this.dgvFeesItem.Rows[i].Cells[0].Value.ToString();
                        this.oInvoiceItemAmounts.InvoiceItemAmount = Convert.ToDouble(this.dgvFeesItem.Rows[i].Cells[2].Value.ToString());
                        this.cInvoiceItemAmounts.InsertUpdateData(this.oInvoiceItemAmounts);
                        if (this.oStudentMaster.Level == this.oInvoiceItemAmounts.InvoiceItemCode)
                        {
                            this.oStudentMaster.LocationCode = this.cGlobleVariable.LocationCode;
                            this.oStudentMaster.Fees = Convert.ToDouble(this.dgvFeesItem.Rows[i].Cells[2].Value.ToString());
                            this.cStudentMaster.InsertUpdate(this.oStudentMaster);
                        }
                    }
                    for (int j = 0; j < this.dgvTax.Rows.Count; j++)
                    {
                        this.oInvoiceTaxAmount.LocationCode = this.cGlobleVariable.LocationCode;
                        this.oInvoiceTaxAmount.InvoiceNo = this.oInvoice.InvoiceNo;
                        this.oInvoiceTaxAmount.StudentNo = this.txtStudentNo.Text;
                        this.oInvoiceTaxAmount.InvoiceTaxCode = this.dgvTax.Rows[j].Cells[0].Value.ToString();
                        this.oInvoiceTaxAmount.InvoiceTaxAmount = Convert.ToDouble(this.dgvTax.Rows[j].Cells[2].Value.ToString());
                        this.cInvoiceTaxAmount.InsertUpdateData(this.oInvoiceTaxAmount);
                    }
                    this.txtInvoiceNo.Text = this.oInvoice.InvoiceNo;
                    this.oAuditLog.LocationCode = this.cGlobleVariable.LocationCode;
                    this.oAuditLog.UserID = this.cGlobleVariable.CurrentUserID;
                    this.oAuditLog.MachineID = clsGlobleVariable.MachineID;
                    this.oAuditLog.DateEntered = Convert.ToDateTime(this.cAuditLog.getCurrentDate().Rows[0][0].ToString());
                    this.oAuditLog.TimeEntered = Convert.ToDateTime(this.cAuditLog.getCurrentTime().Rows[0][0].ToString());
                    this.oAuditLog.Task = "Saved Invoice No " + this.txtInvoiceNo.Text;
                    this.cAuditLog.AuditLog(this.oAuditLog);
                    this.ReportViwer();
                    this.RefreshPage();
                }
            }
            else
            {
                MessageBox.Show("You can't update invoice data", "Receipt details", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            this.ViewInvoice();
            this.oAuditLog.LocationCode = this.cGlobleVariable.LocationCode;
            this.oAuditLog.UserID = this.cGlobleVariable.CurrentUserID;
            this.oAuditLog.MachineID = clsGlobleVariable.MachineID;
            this.oAuditLog.DateEntered = Convert.ToDateTime(this.cAuditLog.getCurrentDate().Rows[0][0].ToString());
            this.oAuditLog.TimeEntered = Convert.ToDateTime(this.cAuditLog.getCurrentTime().Rows[0][0].ToString());
            this.oAuditLog.Task = "Viewed Invoice No " + this.txtInvoiceNo.Text;
            this.cAuditLog.AuditLog(this.oAuditLog);
        }

        private void CalClearTaxAmount()
        {
            double num = 0.0;
            this.dgvTax.Rows.Clear();
            DataTable tax = this.cTax.GetTax();
            if (tax.Rows.Count > 0)
            {
                for (int i = 0; i <= (tax.Rows.Count - 1); i++)
                {
                    int count = this.dgvTax.Rows.Count;
                    this.dgvTax.Rows.Add(1);
                    this.dgvTax.Rows[count].Cells[0].Value = tax.Rows[i][1].ToString();
                    this.dgvTax.Rows[count].Cells[1].Value = tax.Rows[i][2].ToString();
                    this.dgvTax.Rows[count].Cells[2].Value = string.Format("{0:0.00}", num);
                }
            }
            this.TotalTaxAmount();
        }

        private void CalNBTAmount(double dbTotalAmount)
        {
            DataTable nBT = this.cNBT.GetNBT();
            if (nBT.Rows.Count > 0)
            {
                this.txtNBT.Text = Convert.ToString((double) (dbTotalAmount * (Convert.ToDouble(nBT.Rows[nBT.Rows.Count - 1][1].ToString()) / 100.0)));
            }
            this.txtTotalAmt.Text = Convert.ToString((double) (((Convert.ToDouble(this.txtTotal.Text) + Convert.ToDouble(this.txtNBT.Text)) + Convert.ToDouble(this.txtPenaltyAmount.Text)) - Convert.ToDouble(this.txtStudentDiscount.Text)));
        }

        private void CalTaxAmount()
        {
            double num = 0.0;
            this.dgvTax.Rows.Clear();
            DataTable tax = this.cTax.GetTax();
            if (tax.Rows.Count > 0)
            {
                for (int i = 0; i <= (tax.Rows.Count - 1); i++)
                {
                    int count = this.dgvTax.Rows.Count;
                    this.dgvTax.Rows.Add(1);
                    this.dgvTax.Rows[count].Cells[0].Value = tax.Rows[i][1].ToString();
                    this.dgvTax.Rows[count].Cells[1].Value = tax.Rows[i][2].ToString();
                    if (Convert.ToBoolean(tax.Rows[i][4].ToString()))
                    {
                        num = Convert.ToDouble(this.txtTotalAmt.Text) * (Convert.ToDouble(tax.Rows[i][3].ToString()) / 100.0);
                    }
                    else
                    {
                        num = Convert.ToDouble(this.txtTotal.Text) * (Convert.ToDouble(tax.Rows[i][3].ToString()) / 100.0);
                    }
                    this.dgvTax.Rows[count].Cells[2].Value = string.Format("{0:0.00}", num);
                }
            }
            this.TotalTaxAmount();
        }

        private bool CheckIsValidateInvoiceDate()
        {
            if (this.cStudentMaster.GetStudentData(this.cGlobleVariable.LocationCode, this.txtStudentNo.Text).Status == "R")
            {
                return true;
            }
            DateTime lastPaymentFromDate = this.GetLastPaymentFromDate(Convert.ToDateTime(this.dtpPayFrom.Value));
            DateTime lastPaymentToDate = this.GetLastPaymentToDate();
            DateTime time3 = lastPaymentFromDate.AddMonths(1);
            DateTime time4 = lastPaymentToDate.AddMonths(1);
            if (this.dtpPayFrom.Value >= time3)
            {
                if (this.dtpPayFrom.Value > time4)
                {
                    return false;
                }
                return true;
            }
            return false;
        }

        private void chkIsTax_CheckedChanged(object sender, EventArgs e)
        {
            this.oPaymentDeatils.StudentDicount = Convert.ToDouble(this.txtStudentDiscount.Text);
            if (this.chkIsTax.Checked)
            {
                this.TotalAmountFees();
            }
            else
            {
                this.CalClearTaxAmount();
                this.CalNBTAmount(0.0);
            }
            this.txtGrandTotal.Text = Convert.ToString((double) (Convert.ToDouble(this.txtTotalAmt.Text) + Convert.ToDouble(this.txtTotTax.Text)));
        }

        private void cmbClassName_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.cCommanMethods.MoveNextControl(e);
        }

        private void cmbClassName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbClassName.SelectedIndex > -1)
            {
                if (this.oStudentMaster.Level == this.cmbClassName["fldClassCode"].ToString())
                {
                    this.txtStudentFees.Text = string.Format("{0:0.00}", this.oStudentMaster.Fees);
                }
                else
                {
                    this.txtStudentFees.Text = "0.00";
                }
            }
        }

        private void DateRefresh()
        {
            DateTime time = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            time = time.AddDays((double) -(time.Day - 1));
            DateTime time2 = time;
            time2 = time2.AddMonths(1);
            time2 = time2.AddDays((double) -time2.Day);
            this.dtpPayFrom.Value = time;
            this.dtpPayTo.Value = time2;
        }

        private void dgvFeesItem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dgvFeesItem_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            this.TotalAmountFees();
            this.txtGrandTotal.Text = Convert.ToString((double) (Convert.ToDouble(this.txtTotalAmt.Text) + Convert.ToDouble(this.txtTotTax.Text)));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void dtpDateOfInvoice_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.cCommanMethods.MoveNextControl(e);
        }

        private void dtpDateOfInvoice_ValueChanged(object sender, EventArgs e)
        {
            this.LoadStudent();
        }

        private void dtpPayFrom_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.cCommanMethods.MoveNextControl(e);
        }

        private void dtpPayFrom_ValueChanged(object sender, EventArgs e)
        {
        }

        private void dtpPayTo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                if (!this.CheckIsValidateInvoiceDate())
                {
                    MessageBox.Show("Invoice date is invalid.", "Invoice Deta", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    this.dtpPayTo.Focus();
                }
                this.cCommanMethods.MoveNextControl(e);
            }
        }

        private void dtpPayTo_ValueChanged(object sender, EventArgs e)
        {
        }

        private void frmInvoiceNew_Load(object sender, EventArgs e)
        {
            this.LoadCombos();
            if (this.cmbClassName.Items.Count > 0)
            {
                this.cmbClassName.SelectedIndex = 0;
            }
            this.txtStudentNo.Focus();
            this.DateRefresh();
            this.chkIsTax.Checked = true;
        }

        private DateTime GetLastPaymentFromDate(DateTime dtFromDate)
        {
            DataTable lastInvoiceDetails = this.cInvoice.GetLastInvoiceDetails(this.cGlobleVariable.LocationCode, this.txtStudentNo.Text.ToString());
            DateTime time = dtFromDate.AddMonths(-1);
            if (lastInvoiceDetails.Rows.Count > 0)
            {
                time = Convert.ToDateTime(lastInvoiceDetails.Rows[0][5].ToString());
            }
            return time;
        }

        private string GetLastPaymentMonth()
        {
            DataTable lastInvoiceDetails = this.cInvoice.GetLastInvoiceDetails(this.cGlobleVariable.LocationCode, this.txtStudentNo.Text.ToString());
            string str = "";
            if (lastInvoiceDetails.Rows.Count > 0)
            {
                str = "Last Payment Date : ";
                str = (str + Convert.ToDateTime(lastInvoiceDetails.Rows[0][6].ToString()).ToString("MMMM-yyyy")) + " Invoice Date : " + Convert.ToDateTime(lastInvoiceDetails.Rows[0][4].ToString()).ToString("dd-MM-yyyy");
            }
            return str;
        }

        private DateTime GetLastPaymentToDate()
        {
            DataTable lastInvoiceDetails = this.cInvoice.GetLastInvoiceDetails(this.cGlobleVariable.LocationCode, this.txtStudentNo.Text.ToString());
            DateTime now = DateTime.Now;
            if (lastInvoiceDetails.Rows.Count > 0)
            {
                now = Convert.ToDateTime(lastInvoiceDetails.Rows[0][6].ToString());
            }
            return now;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            DataGridViewCellStyle style = new DataGridViewCellStyle();
            DataGridViewCellStyle style2 = new DataGridViewCellStyle();
            ComponentResourceManager manager = new ComponentResourceManager(typeof(frmInvoiceNew));
            DataGridViewCellStyle style3 = new DataGridViewCellStyle();
            DataGridViewCellStyle style4 = new DataGridViewCellStyle();
            DataGridViewCellStyle style5 = new DataGridViewCellStyle();
            DataGridViewCellStyle style6 = new DataGridViewCellStyle();
            DataGridViewCellStyle style7 = new DataGridViewCellStyle();
            this.groupBox1 = new GroupBox();
            this.lblLastPaymentMonth = new Label();
            this.chkIsTax = new CheckBox();
            this.label14 = new Label();
            this.label7 = new Label();
            this.txtNBT = new TextBox();
            this.label8 = new Label();
            this.txtTotTax = new TextBox();
            this.dgvTax = new DataGridView();
            this.Column4 = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            this.txtTotal = new TextBox();
            this.panel1 = new Panel();
            this.btnPrint = new Button();
            this.btnView = new Button();
            this.btnRefresh = new Button();
            this.btnSave = new Button();
            this.btnExit = new Button();
            this.cmbClassName = new ColumnComboBox();
            this.dgvFeesItem = new DataGridView();
            this.Column3 = new DataGridViewTextBoxColumn();
            this.Column1 = new DataGridViewTextBoxColumn();
            this.Column2 = new DataGridViewTextBoxColumn();
            this.label11 = new Label();
            this.dtpPayTo = new DateTimePicker();
            this.dtpPayFrom = new DateTimePicker();
            this.label10 = new Label();
            this.groupBox2 = new GroupBox();
            this.label12 = new Label();
            this.txtGrandTotal = new TextBox();
            this.txtTotalAmt = new TextBox();
            this.label9 = new Label();
            this.txtPenaltyAmount = new TextBox();
            this.label6 = new Label();
            this.txtStudentDiscount = new TextBox();
            this.label4 = new Label();
            this.txtInvoiceNo = new TextBox();
            this.label1 = new Label();
            this.dtpDateOfInvoice = new DateTimePicker();
            this.label3 = new Label();
            this.label94 = new Label();
            this.txtStudentFees = new TextBox();
            this.txtFullNameLineTwo = new TextBox();
            this.txtFullNameLineOne = new TextBox();
            this.txtStudentNo = new TextBox();
            this.label2 = new Label();
            this.label5 = new Label();
            this.errInvoice = new ErrorProvider(this.components);
            this.dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((ISupportInitialize) this.dgvTax).BeginInit();
            this.panel1.SuspendLayout();
            ((ISupportInitialize) this.dgvFeesItem).BeginInit();
            this.groupBox2.SuspendLayout();
            ((ISupportInitialize) this.errInvoice).BeginInit();
            base.SuspendLayout();
            this.groupBox1.Controls.Add(this.lblLastPaymentMonth);
            this.groupBox1.Controls.Add(this.chkIsTax);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtNBT);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtTotTax);
            this.groupBox1.Controls.Add(this.dgvTax);
            this.groupBox1.Controls.Add(this.txtTotal);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.cmbClassName);
            this.groupBox1.Controls.Add(this.dgvFeesItem);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.dtpPayTo);
            this.groupBox1.Controls.Add(this.dtpPayFrom);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.txtInvoiceNo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtpDateOfInvoice);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label94);
            this.groupBox1.Controls.Add(this.txtStudentFees);
            this.groupBox1.Controls.Add(this.txtFullNameLineTwo);
            this.groupBox1.Controls.Add(this.txtFullNameLineOne);
            this.groupBox1.Controls.Add(this.txtStudentNo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new Point(2, -3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(0x374, 590);
            this.groupBox1.TabIndex = 0xd5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new EventHandler(this.groupBox1_Enter);
            this.lblLastPaymentMonth.AutoSize = true;
            this.lblLastPaymentMonth.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.lblLastPaymentMonth.ForeColor = Color.Red;
            this.lblLastPaymentMonth.Location = new Point(0x76, 0x8d);
            this.lblLastPaymentMonth.Name = "lblLastPaymentMonth";
            this.lblLastPaymentMonth.Size = new Size(0, 13);
            this.lblLastPaymentMonth.TabIndex = 0xf5;
            this.chkIsTax.AutoSize = true;
            this.chkIsTax.Location = new Point(0x229, 0xa2);
            this.chkIsTax.Name = "chkIsTax";
            this.chkIsTax.Size = new Size(60, 0x11);
            this.chkIsTax.TabIndex = 0xf4;
            this.chkIsTax.Text = "Is Taxs";
            this.chkIsTax.UseVisualStyleBackColor = true;
            this.chkIsTax.CheckedChanged += new EventHandler(this.chkIsTax_CheckedChanged);
            this.label14.AutoSize = true;
            this.label14.Location = new Point(0x229, 0x155);
            this.label14.Name = "label14";
            this.label14.Size = new Size(0x37, 13);
            this.label14.TabIndex = 0xf3;
            this.label14.Text = "Total Tax:";
            this.label7.AutoSize = true;
            this.label7.Location = new Point(9, 0x155);
            this.label7.Name = "label7";
            this.label7.Size = new Size(0x25, 13);
            this.label7.TabIndex = 0xef;
            this.label7.Text = "Total :";
            this.txtNBT.BackColor = SystemColors.ActiveCaptionText;
            this.txtNBT.Location = new Point(0x165, 0x16c);
            this.txtNBT.MaxLength = 10;
            this.txtNBT.Name = "txtNBT";
            this.txtNBT.ReadOnly = true;
            this.txtNBT.Size = new Size(190, 20);
            this.txtNBT.TabIndex = 0xee;
            this.txtNBT.Text = "0.00";
            this.txtNBT.TextAlign = HorizontalAlignment.Right;
            this.txtNBT.TextChanged += new EventHandler(this.txtNBT_TextChanged);
            this.label8.AutoSize = true;
            this.label8.Location = new Point(10, 0x16c);
            this.label8.Name = "label8";
            this.label8.Size = new Size(0x2c, 13);
            this.label8.TabIndex = 0xed;
            this.label8.Text = "N. B. T.";
            this.txtTotTax.BackColor = SystemColors.ActiveCaptionText;
            this.txtTotTax.Location = new Point(0x2a6, 0x152);
            this.txtTotTax.MaxLength = 10;
            this.txtTotTax.Name = "txtTotTax";
            this.txtTotTax.ReadOnly = true;
            this.txtTotTax.Size = new Size(190, 20);
            this.txtTotTax.TabIndex = 0xec;
            this.txtTotTax.Text = "0.00";
            this.txtTotTax.TextAlign = HorizontalAlignment.Right;
            this.txtTotTax.TextChanged += new EventHandler(this.txtTotTax_TextChanged);
            this.dgvTax.AllowUserToAddRows = false;
            this.dgvTax.AllowUserToDeleteRows = false;
            this.dgvTax.AllowUserToResizeColumns = false;
            this.dgvTax.AllowUserToResizeRows = false;
            this.dgvTax.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTax.Columns.AddRange(new DataGridViewColumn[] { this.Column4, this.dataGridViewTextBoxColumn1, this.dataGridViewTextBoxColumn2 });
            this.dgvTax.Location = new Point(0x229, 0xbb);
            this.dgvTax.Name = "dgvTax";
            this.dgvTax.Size = new Size(0x13e, 0x91);
            this.dgvTax.TabIndex = 0xeb;
            this.Column4.HeaderText = "ItemCode";
            this.Column4.Name = "Column4";
            this.Column4.Visible = false;
            style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = style;
            this.dataGridViewTextBoxColumn1.HeaderText = "Item";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Resizable = DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn1.Width = 0xaf;
            style2.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = style2;
            this.dataGridViewTextBoxColumn2.HeaderText = "Amount";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Resizable = DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn2.Width = 0x61;
            this.txtTotal.BackColor = SystemColors.ActiveCaptionText;
            this.txtTotal.Location = new Point(0x165, 0x152);
            this.txtTotal.MaxLength = 10;
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new Size(190, 20);
            this.txtTotal.TabIndex = 0xea;
            this.txtTotal.Text = "0.00";
            this.txtTotal.TextAlign = HorizontalAlignment.Right;
            this.txtTotal.TextChanged += new EventHandler(this.txtTotal_TextChanged);
            this.panel1.Controls.Add(this.btnPrint);
            this.panel1.Controls.Add(this.btnView);
            this.panel1.Controls.Add(this.btnRefresh);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Location = new Point(4, 0x222);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(880, 40);
            this.panel1.TabIndex = 0xe1;
            this.btnPrint.Location = new Point(240, 6);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new Size(0x4b, 0x17);
            this.btnPrint.TabIndex = 0x27;
            this.btnPrint.Text = "&Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new EventHandler(this.btnPrint_Click);
            this.btnView.Location = new Point(80, 6);
            this.btnView.Name = "btnView";
            this.btnView.Size = new Size(0x4b, 0x17);
            this.btnView.TabIndex = 0x26;
            this.btnView.Text = "&View";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new EventHandler(this.btnView_Click);
            this.btnRefresh.Location = new Point(0xa1, 6);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new Size(0x49, 0x17);
            this.btnRefresh.TabIndex = 0x25;
            this.btnRefresh.Text = "&Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new EventHandler(this.btnRefresh_Click);
            this.btnSave.Location = new Point(3, 6);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new Size(0x49, 0x17);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new EventHandler(this.btnSave_Click);
            this.btnExit.FlatAppearance.BorderColor = Color.FromArgb(0x40, 0x40, 0x40);
            this.btnExit.FlatAppearance.BorderSize = 5;
            this.btnExit.Location = new Point(0x313, 6);
            this.btnExit.Margin = new Padding(0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new Size(0x53, 0x17);
            this.btnExit.TabIndex = 0x23;
            this.btnExit.Text = "E&xit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new EventHandler(this.btnExit_Click);
            this.cmbClassName.DrawMode = DrawMode.OwnerDrawVariable;
            this.cmbClassName.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbClassName.DropDownWidth = 0x11;
            this.cmbClassName.FormattingEnabled = true;
            this.cmbClassName.Location = new Point(0x75, 160);
            this.cmbClassName.Name = "cmbClassName";
            this.cmbClassName.Size = new Size(0xea, 0x15);
            this.cmbClassName.TabIndex = 3;
            this.cmbClassName.ViewColumn = 0;
            this.cmbClassName.SelectedIndexChanged += new EventHandler(this.cmbClassName_SelectedIndexChanged);
            this.cmbClassName.KeyPress += new KeyPressEventHandler(this.cmbClassName_KeyPress);
            this.dgvFeesItem.AllowUserToAddRows = false;
            this.dgvFeesItem.AllowUserToResizeColumns = false;
            this.dgvFeesItem.AllowUserToResizeRows = false;
            this.dgvFeesItem.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFeesItem.Columns.AddRange(new DataGridViewColumn[] { this.Column3, this.Column1, this.Column2 });
            this.dgvFeesItem.Location = new Point(13, 0xbb);
            this.dgvFeesItem.Name = "dgvFeesItem";
            this.dgvFeesItem.Size = new Size(0x216, 0x91);
            this.dgvFeesItem.TabIndex = 0xe7;
            this.dgvFeesItem.RowsRemoved += new DataGridViewRowsRemovedEventHandler(this.dgvFeesItem_RowsRemoved);
            this.dgvFeesItem.CellContentClick += new DataGridViewCellEventHandler(this.dgvFeesItem_CellContentClick);
            this.Column3.HeaderText = "ItemCode";
            this.Column3.Name = "Column3";
            this.Column3.Visible = false;
            style3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.Column1.DefaultCellStyle = style3;
            this.Column1.HeaderText = "Item";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Resizable = DataGridViewTriState.False;
            this.Column1.Width = 0x131;
            style4.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.Column2.DefaultCellStyle = style4;
            this.Column2.HeaderText = "Amount";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Resizable = DataGridViewTriState.False;
            this.Column2.Width = 0xb9;
            this.label11.AutoSize = true;
            this.label11.Location = new Point(0xd4, 0x75);
            this.label11.Name = "label11";
            this.label11.Size = new Size(20, 13);
            this.label11.TabIndex = 230;
            this.label11.Text = "To";
            this.dtpPayTo.Format = DateTimePickerFormat.Short;
            this.dtpPayTo.Location = new Point(0xeb, 0x71);
            this.dtpPayTo.Name = "dtpPayTo";
            this.dtpPayTo.Size = new Size(0x54, 20);
            this.dtpPayTo.TabIndex = 2;
            this.dtpPayTo.ValueChanged += new EventHandler(this.dtpPayTo_ValueChanged);
            this.dtpPayTo.KeyPress += new KeyPressEventHandler(this.dtpPayTo_KeyPress);
            this.dtpPayFrom.Format = DateTimePickerFormat.Short;
            this.dtpPayFrom.Location = new Point(0x75, 0x71);
            this.dtpPayFrom.Name = "dtpPayFrom";
            this.dtpPayFrom.Size = new Size(0x5d, 20);
            this.dtpPayFrom.TabIndex = 1;
            this.dtpPayFrom.ValueChanged += new EventHandler(this.dtpPayFrom_ValueChanged);
            this.dtpPayFrom.KeyPress += new KeyPressEventHandler(this.dtpPayFrom_KeyPress);
            this.label10.AutoSize = true;
            this.label10.Location = new Point(9, 0x75);
            this.label10.Name = "label10";
            this.label10.Size = new Size(0x4b, 13);
            this.label10.TabIndex = 0xe5;
            this.label10.Text = "Payment Term";
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.txtGrandTotal);
            this.groupBox2.Controls.Add(this.txtTotalAmt);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtPenaltyAmount);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtStudentDiscount);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new Point(1, 0x184);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new Size(880, 0x98);
            this.groupBox2.TabIndex = 0xe0;
            this.groupBox2.TabStop = false;
            this.label12.AutoSize = true;
            this.label12.Location = new Point(9, 0x43);
            this.label12.Name = "label12";
            this.label12.Size = new Size(0x3b, 13);
            this.label12.TabIndex = 0xf5;
            this.label12.Text = "Sub Total :";
            this.txtGrandTotal.BackColor = SystemColors.ActiveCaptionText;
            this.txtGrandTotal.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.txtGrandTotal.Location = new Point(0x2a5, 0x79);
            this.txtGrandTotal.MaxLength = 10;
            this.txtGrandTotal.Name = "txtGrandTotal";
            this.txtGrandTotal.ReadOnly = true;
            this.txtGrandTotal.Size = new Size(0xc1, 20);
            this.txtGrandTotal.TabIndex = 8;
            this.txtGrandTotal.Text = "0.00";
            this.txtGrandTotal.TextAlign = HorizontalAlignment.Right;
            this.txtGrandTotal.TextChanged += new EventHandler(this.txtGrandTotal_TextChanged);
            this.txtGrandTotal.KeyPress += new KeyPressEventHandler(this.txtGrandTotal_KeyPress);
            this.txtTotalAmt.BackColor = SystemColors.ActiveCaptionText;
            this.txtTotalAmt.Location = new Point(0x2a6, 0x40);
            this.txtTotalAmt.MaxLength = 10;
            this.txtTotalAmt.Name = "txtTotalAmt";
            this.txtTotalAmt.ReadOnly = true;
            this.txtTotalAmt.Size = new Size(0xc1, 20);
            this.txtTotalAmt.TabIndex = 7;
            this.txtTotalAmt.Text = "0.00";
            this.txtTotalAmt.TextAlign = HorizontalAlignment.Right;
            this.txtTotalAmt.TextChanged += new EventHandler(this.txtTotalAmt_TextChanged);
            this.txtTotalAmt.KeyPress += new KeyPressEventHandler(this.txtTotalAmt_KeyPress);
            this.label9.AutoSize = true;
            this.label9.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.label9.Location = new Point(9, 0x7c);
            this.label9.Name = "label9";
            this.label9.Size = new Size(0x4a, 13);
            this.label9.TabIndex = 0xea;
            this.label9.Text = "Grand Total";
            this.txtPenaltyAmount.BackColor = SystemColors.ActiveCaptionText;
            this.txtPenaltyAmount.Location = new Point(0x2a6, 0x29);
            this.txtPenaltyAmount.MaxLength = 10;
            this.txtPenaltyAmount.Name = "txtPenaltyAmount";
            this.txtPenaltyAmount.Size = new Size(0xc1, 20);
            this.txtPenaltyAmount.TabIndex = 6;
            this.txtPenaltyAmount.Text = "0.00";
            this.txtPenaltyAmount.TextAlign = HorizontalAlignment.Right;
            this.txtPenaltyAmount.TextChanged += new EventHandler(this.txtPenaltyAmount_TextChanged);
            this.txtPenaltyAmount.Leave += new EventHandler(this.txtPenaltyAmount_Leave);
            this.txtPenaltyAmount.KeyPress += new KeyPressEventHandler(this.txtPenaltyAmount_KeyPress);
            this.label6.AutoSize = true;
            this.label6.Location = new Point(9, 0x2c);
            this.label6.Name = "label6";
            this.label6.Size = new Size(0x57, 13);
            this.label6.TabIndex = 0xe4;
            this.label6.Text = "Penalty Amount :";
            this.txtStudentDiscount.BackColor = SystemColors.ActiveCaptionText;
            this.txtStudentDiscount.Location = new Point(0x2a6, 0x12);
            this.txtStudentDiscount.MaxLength = 10;
            this.txtStudentDiscount.Name = "txtStudentDiscount";
            this.txtStudentDiscount.Size = new Size(0xc1, 20);
            this.txtStudentDiscount.TabIndex = 5;
            this.txtStudentDiscount.Text = "0.00";
            this.txtStudentDiscount.TextAlign = HorizontalAlignment.Right;
            this.txtStudentDiscount.TextChanged += new EventHandler(this.txtStudentDiscount_TextChanged);
            this.txtStudentDiscount.Leave += new EventHandler(this.txtStudentDiscount_Leave);
            this.txtStudentDiscount.KeyPress += new KeyPressEventHandler(this.txtStudentDiscount_KeyPress);
            this.label4.AutoSize = true;
            this.label4.Location = new Point(9, 0x15);
            this.label4.Name = "label4";
            this.label4.Size = new Size(0x37, 13);
            this.label4.TabIndex = 0xe2;
            this.label4.Text = "Discount :";
            this.txtInvoiceNo.BackColor = SystemColors.ActiveCaptionText;
            this.txtInvoiceNo.Location = new Point(0x75, 12);
            this.txtInvoiceNo.MaxLength = 10;
            this.txtInvoiceNo.Name = "txtInvoiceNo";
            this.txtInvoiceNo.ReadOnly = true;
            this.txtInvoiceNo.Size = new Size(0xc1, 20);
            this.txtInvoiceNo.TabIndex = 220;
            this.txtInvoiceNo.TextChanged += new EventHandler(this.txtInvoiceNo_TextChanged);
            this.label1.AutoSize = true;
            this.label1.Location = new Point(7, 0x10);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x41, 13);
            this.label1.TabIndex = 0xdd;
            this.label1.Text = "Invoice No :";
            this.dtpDateOfInvoice.Format = DateTimePickerFormat.Short;
            this.dtpDateOfInvoice.Location = new Point(0x301, 0x13);
            this.dtpDateOfInvoice.Name = "dtpDateOfInvoice";
            this.dtpDateOfInvoice.Size = new Size(0x66, 20);
            this.dtpDateOfInvoice.TabIndex = 11;
            this.dtpDateOfInvoice.ValueChanged += new EventHandler(this.dtpDateOfInvoice_ValueChanged);
            this.dtpDateOfInvoice.KeyPress += new KeyPressEventHandler(this.dtpDateOfInvoice_KeyPress);
            this.label3.AutoSize = true;
            this.label3.Location = new Point(7, 0xa1);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x24, 13);
            this.label3.TabIndex = 0xe1;
            this.label3.Text = "Fees :";
            this.label94.AutoSize = true;
            this.label94.Location = new Point(680, 0x15);
            this.label94.Name = "label94";
            this.label94.Size = new Size(0x4a, 13);
            this.label94.TabIndex = 0xdb;
            this.label94.Text = "Invoice Date :";
            this.txtStudentFees.BackColor = SystemColors.ActiveCaptionText;
            this.txtStudentFees.Location = new Point(0x165, 0xa1);
            this.txtStudentFees.MaxLength = 10;
            this.txtStudentFees.Name = "txtStudentFees";
            this.txtStudentFees.Size = new Size(190, 20);
            this.txtStudentFees.TabIndex = 4;
            this.txtStudentFees.Text = "0.00";
            this.txtStudentFees.TextAlign = HorizontalAlignment.Right;
            this.txtStudentFees.TextChanged += new EventHandler(this.txtStudentFees_TextChanged);
            this.txtStudentFees.KeyPress += new KeyPressEventHandler(this.txtStudentFees_KeyPress);
            this.txtFullNameLineTwo.BackColor = SystemColors.ActiveCaptionText;
            this.txtFullNameLineTwo.Location = new Point(0x75, 0x57);
            this.txtFullNameLineTwo.MaxLength = 100;
            this.txtFullNameLineTwo.Name = "txtFullNameLineTwo";
            this.txtFullNameLineTwo.ReadOnly = true;
            this.txtFullNameLineTwo.Size = new Size(0x2f2, 20);
            this.txtFullNameLineTwo.TabIndex = 0xd4;
            this.txtFullNameLineOne.BackColor = SystemColors.ActiveCaptionText;
            this.txtFullNameLineOne.Location = new Point(0x75, 0x40);
            this.txtFullNameLineOne.MaxLength = 100;
            this.txtFullNameLineOne.Name = "txtFullNameLineOne";
            this.txtFullNameLineOne.ReadOnly = true;
            this.txtFullNameLineOne.Size = new Size(0x2f2, 20);
            this.txtFullNameLineOne.TabIndex = 0xd3;
            this.txtStudentNo.BackColor = SystemColors.ActiveCaptionText;
            this.txtStudentNo.Location = new Point(0x75, 0x26);
            this.txtStudentNo.MaxLength = 10;
            this.txtStudentNo.Name = "txtStudentNo";
            this.txtStudentNo.Size = new Size(0xc1, 20);
            this.txtStudentNo.TabIndex = 0;
            this.txtStudentNo.TextChanged += new EventHandler(this.txtStudentNo_TextChanged);
            this.txtStudentNo.KeyPress += new KeyPressEventHandler(this.txtStudentNo_KeyPress);
            this.label2.AutoSize = true;
            this.label2.Location = new Point(7, 0x2d);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x43, 13);
            this.label2.TabIndex = 0xd6;
            this.label2.Text = "Student No :";
            this.label5.AutoSize = true;
            this.label5.Location = new Point(7, 0x43);
            this.label5.Name = "label5";
            this.label5.Size = new Size(0x47, 13);
            this.label5.TabIndex = 0xd5;
            this.label5.Text = "Name in Full :";
            this.errInvoice.ContainerControl = this;
            style5.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = style5;
            this.dataGridViewTextBoxColumn3.HeaderText = "Amount";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Resizable = DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn3.Width = 0x61;
            this.dataGridViewTextBoxColumn4.HeaderText = "ItemCode";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Visible = false;
            style6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.dataGridViewTextBoxColumn5.DefaultCellStyle = style6;
            this.dataGridViewTextBoxColumn5.HeaderText = "Item";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Resizable = DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn5.Width = 0x131;
            style7.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn6.DefaultCellStyle = style7;
            this.dataGridViewTextBoxColumn6.HeaderText = "Amount";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Resizable = DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn6.Width = 0xb9;
            base.ClientSize = new Size(0x377, 590);
            base.Controls.Add(this.groupBox1);
            base.Name = "frmInvoiceNew";
            this.Text = "Tax Invoice";
            base.Load += new EventHandler(this.frmInvoiceNew_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((ISupportInitialize) this.dgvTax).EndInit();
            this.panel1.ResumeLayout(false);
            ((ISupportInitialize) this.dgvFeesItem).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((ISupportInitialize) this.errInvoice).EndInit();
            base.ResumeLayout(false);
        }

        private void InvoiceProcess(string strStudentNo, DateTime dtInvoiceDate)
        {
            TimeSpan span;
            int num;
            double num2;
            DataTable invoiceDetails = this.cInvoice.GetInvoiceDetails(this.cGlobleVariable.LocationCode, strStudentNo);
            this.txtPenaltyAmount.Text = "0.00";
            if (invoiceDetails.Rows.Count > 0)
            {
                this.oInvoice = this.cInvoice.GetInvoiceData(this.cGlobleVariable.LocationCode, strStudentNo, dtInvoiceDate);
                if (this.oInvoice.IsExistInvoice)
                {
                    this.txtInvoiceNo.Text = this.oInvoice.InvoiceNo.ToString();
                    this.txtStudentDiscount.Text = this.oInvoice.Discount.ToString();
                    this.txtPenaltyAmount.Text = this.oInvoice.PanaltyAmount.ToString();
                }
                else if (this.cInvoice.GetInvoiceDetails(this.cGlobleVariable.LocationCode, strStudentNo, Convert.ToDateTime(invoiceDetails.Rows[0][4].ToString())).Rows.Count > 0)
                {
                    this.oPaymentMethod = this.cPaymentMethod.GetPaymentMethod(this.cGlobleVariable.LocationCode, this.oPaymentDeatils.StudentPayMethodCode);
                    if (this.oPaymentMethod.IxExist)
                    {
                        span = (TimeSpan) (this.dtpPayTo.Value - this.dtpPayFrom.Value);
                        num = Convert.ToInt32(span.Days);
                        num2 = ((double) num) / this.oPaymentMethod.PaymentDays;
                        if ((this.oPaymentMethod.PaymentDays == 30.0) && (Math.Floor(num2) <= 0.0))
                        {
                            num2 = 1.0;
                        }
                        if (num > 0)
                        {
                            this.txtStudentFees.Text = Convert.ToString((double) (Math.Floor(num2) * this.oStudentMaster.Fees));
                        }
                        this.oPaymentMethod = this.cPaymentMethod.GetPaymentMethod(this.cGlobleVariable.LocationCode, this.oPaymentDeatils.PenaltyPayMethodCode);
                        if (this.oPaymentMethod.IxExist)
                        {
                            DateTime time = Convert.ToDateTime(invoiceDetails.Rows[invoiceDetails.Rows.Count - 1][6].ToString()).AddDays(this.oPaymentMethod.PaymentDays);
                            if (dtInvoiceDate > time)
                            {
                                TimeSpan span2 = (TimeSpan) (dtInvoiceDate - Convert.ToDateTime(invoiceDetails.Rows[invoiceDetails.Rows.Count - 1][6].ToString()).AddDays(1.0));
                                int num3 = Convert.ToInt32(span2.Days);
                                this.txtInvoiceNo.Text = "";
                                this.txtPenaltyAmount.Text = "0";
                                double d = ((double) num3) / this.oPaymentMethod.PaymentDays;
                                this.txtPenaltyAmount.Text = string.Format("{0:0.00}", this.oPaymentDeatils.PenaltyPayAmount * Math.Floor(d));
                            }
                        }
                    }
                }
            }
            else
            {
                this.oPaymentMethod = this.cPaymentMethod.GetPaymentMethod(this.cGlobleVariable.LocationCode, this.oPaymentDeatils.StudentPayMethodCode);
                if (this.oPaymentMethod.IxExist)
                {
                    span = (TimeSpan) (this.dtpPayTo.Value - this.dtpPayFrom.Value);
                    num = Convert.ToInt32(span.Days);
                    num2 = ((double) num) / this.oPaymentMethod.PaymentDays;
                    if ((this.oPaymentMethod.PaymentDays == 30.0) && (Math.Floor(num2) <= 0.0))
                    {
                        num2 = 1.0;
                    }
                    if (num > 0)
                    {
                        this.txtStudentFees.Text = Convert.ToString((double) (Math.Floor(num2) * this.oStudentMaster.Fees));
                    }
                }
            }
        }

        private bool isItemExcist(string strItemCode)
        {
            bool flag = false;
            for (int i = 0; i < this.dgvFeesItem.Rows.Count; i++)
            {
                if (this.dgvFeesItem.Rows[i].Cells[0].Value.ToString() == strItemCode)
                {
                    flag = true;
                }
            }
            return flag;
        }

        private void LoadCombos()
        {
            DataTable classDetails = this.cClassMaster.GetClassDetails(this.cGlobleVariable.LocationCode, this.cGlobleVariable.ActiveStatusCode);
            DataRow row = classDetails.NewRow();
            row[0] = "0";
            row[1] = this.cGlobleVariable.LocationCode;
            row[2] = "Enroll";
            row[3] = "Enrolment Fees";
            row[4] = "A";
            classDetails.Rows.InsertAt(row, 0);
            this.cCommanMethods.LoadCombo(classDetails, this.cmbClassName, 3);
        }

        private void LoadStudent()
        {
            string str = this.txtStudentNo.Text.ToString();
            if (str.Length == 6)
            {
                this.oStudentMaster = this.cStudentMaster.GetStudentData(this.cGlobleVariable.LocationCode, this.txtStudentNo.Text.ToString());
                if (this.oStudentMaster.IsExistStudent)
                {
                    this.txtStudentNo.Text = this.oStudentMaster.StudentNo;
                    this.txtFullNameLineOne.Text = this.oStudentMaster.NameInFullL1;
                    this.txtFullNameLineTwo.Text = this.oStudentMaster.NameInFullL2;
                    this.txtStudentFees.Text = this.oStudentMaster.Fees.ToString();
                    this.cmbClassName.SetText(this.cClassMaster.GetClassData(this.cGlobleVariable.LocationCode, this.oStudentMaster.Level).ClassName);
                    this.lblLastPaymentMonth.Text = this.GetLastPaymentMonth();
                    if (this.oPaymentDeatils.IsPaymentExist)
                    {
                        this.txtStudentDiscount.Text = this.oPaymentDeatils.StudentDicount.ToString();
                        this.InvoiceProcess(this.txtStudentNo.Text, this.dtpDateOfInvoice.Value);
                    }
                }
                else
                {
                    this.ViewStudent();
                }
            }
            else if (str.Length > 6)
            {
                this.txtFullNameLineOne.Text = string.Empty;
                this.txtFullNameLineTwo.Text = string.Empty;
            }
            if (this.txtPenaltyAmount.Text == string.Empty)
            {
                this.txtPenaltyAmount.Text = "0.00";
            }
            else
            {
                this.txtPenaltyAmount.Text = string.Format("{0:0.00}", Convert.ToDouble(this.txtPenaltyAmount.Text));
            }
            if (this.txtStudentDiscount.Text == string.Empty)
            {
                this.txtStudentDiscount.Text = "0.00";
            }
            else
            {
                this.txtStudentDiscount.Text = string.Format("{0:0.00}", Convert.ToDouble(this.txtStudentDiscount.Text));
            }
        }

        public static int monthDifference(DateTime startDate, DateTime endDate)
        {
            int num = ((12 * (startDate.Year - endDate.Year)) + startDate.Month) - endDate.Month;
            return Math.Abs(num);
        }

        private void RefreshPage()
        {
            this.cCommanMethods.ClearForm(this);
            this.txtTotal.Text = "0.00";
            this.txtNBT.Text = "0.00";
            this.txtTotalAmt.Text = "0.00";
            this.txtTotTax.Text = "0.00";
            this.txtGrandTotal.Text = "0.00";
            this.txtStudentDiscount.Text = "0.00";
            this.txtPenaltyAmount.Text = "0.00";
            this.txtInvoiceNo.Text = string.Empty;
            this.dgvFeesItem.Rows.Clear();
            this.dgvTax.Rows.Clear();
            this.txtStudentNo.Focus();
            this.DateRefresh();
            this.lblLastPaymentMonth.Text = "";
            this.chkIsTax.Checked = true;
            this.txtStudentFees.Text = "0.00";
        }

        private void ReportViwer()
        {
            object[,] arrParameter = new object[,] { { "strCopyRight", this.cGlobleVariable.CopyRight }, { "strInvoiceNo", this.txtInvoiceNo.Text } };
            frmReportViewer viever = new frmReportViewer(this.SelectionFormularValues(), arrParameter);
        }

        private string SelectionFormularValues()
        {
            return "{tbl_invoice_master.fldInvoiceNo}={?strInvoiceNo}";
        }

        private void TotalAmountFees()
        {
            double dbTotalAmount = 0.0;
            this.dbTotAmount = 0.0;
            this.dRemoveEnrol = 0.0;
            if (this.dgvFeesItem.Rows.Count > 0)
            {
                for (int i = 0; i <= (this.dgvFeesItem.Rows.Count - 1); i++)
                {
                    this.dbTotAmount += Convert.ToDouble(this.dgvFeesItem.Rows[i].Cells[2].Value);
                    if (Convert.ToString(this.dgvFeesItem.Rows[i].Cells[0].Value) == "Enroll")
                    {
                        this.dRemoveEnrol += Convert.ToDouble(this.dgvFeesItem.Rows[i].Cells[2].Value);
                    }
                }
            }
            this.txtTotal.Text = Convert.ToString(this.dbTotAmount);
            if (this.dbTotAmount == this.dRemoveEnrol)
            {
                dbTotalAmount = this.dbTotAmount;
                this.txtStudentDiscount.Text = "0.00";
            }
            else
            {
                this.txtStudentDiscount.Text = string.Format("{0:0.00}", Convert.ToDouble(this.oPaymentDeatils.StudentDicount.ToString()));
                dbTotalAmount = (this.dbTotAmount + Convert.ToDouble(this.txtPenaltyAmount.Text)) - Convert.ToDouble(this.txtStudentDiscount.Text);
            }
            this.CalNBTAmount(dbTotalAmount);
            this.CalTaxAmount();
        }

        private void TotalTaxAmount()
        {
            double num = 0.0;
            if (this.dgvTax.Rows.Count > 0)
            {
                for (int i = 0; i <= (this.dgvTax.Rows.Count - 1); i++)
                {
                    num += Convert.ToDouble(this.dgvTax.Rows[i].Cells[2].Value);
                }
            }
            this.txtTotTax.Text = Convert.ToString(num);
        }

        private void txtGrandTotal_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.cCommanMethods.MoveNextControl(e);
        }

        private void txtGrandTotal_TextChanged(object sender, EventArgs e)
        {
            if (this.txtGrandTotal.Text == string.Empty)
            {
                this.txtGrandTotal.Text = "0.00";
            }
            else
            {
                this.txtGrandTotal.Text = string.Format("{0:0.00}", Convert.ToDouble(this.txtGrandTotal.Text));
            }
        }

        private void txtInvoiceNo_TextChanged(object sender, EventArgs e)
        {
            this.oInvoice = this.cInvoice.GetInvDetails(this.cGlobleVariable.LocationCode, this.txtInvoiceNo.Text);
            this.dgvFeesItem.Rows.Clear();
            if (this.oInvoice.IsExistInvoice)
            {
                int num;
                int count;
                this.txtInvoiceNo.Text = this.oInvoice.InvoiceNo;
                this.dtpDateOfInvoice.Value = this.oInvoice.InvoiceDate;
                this.txtStudentNo.Text = this.oInvoice.StudentNo;
                this.dtpPayFrom.Value = this.oInvoice.PaymentFromDate;
                this.dtpPayTo.Value = this.oInvoice.PaymentToDate;
                this.cmbClassName.SelectedIndex = 0;
                this.chkIsTax.Checked = this.oInvoice.IsTax;
                this.txtTotal.Text = Convert.ToString(this.oInvoice.TotalItemAmount);
                this.txtNBT.Text = Convert.ToString(this.oInvoice.NBTAmount);
                this.txtTotTax.Text = Convert.ToString(this.oInvoice.TotalTaxAmount);
                this.txtStudentDiscount.Text = Convert.ToString(this.oInvoice.Discount);
                this.txtStudentDiscount.Text = string.Format("{0:0.00}", Convert.ToDouble(this.txtStudentDiscount.Text));
                this.txtPenaltyAmount.Text = Convert.ToString(this.oInvoice.PanaltyAmount);
                this.txtPenaltyAmount.Text = string.Format("{0:0.00}", Convert.ToDouble(this.txtPenaltyAmount.Text));
                this.txtTotalAmt.Text = Convert.ToString((double) (((Convert.ToDouble(this.txtTotal.Text) + Convert.ToDouble(this.txtNBT.Text)) + Convert.ToDouble(this.txtPenaltyAmount.Text)) - Convert.ToDouble(this.txtStudentDiscount.Text)));
                this.txtGrandTotal.Text = Convert.ToString(this.oInvoice.GrandTotal);
                DataTable table = this.cInvoiceItemAmounts.GetInvoiceItemDetails(this.cGlobleVariable.LocationCode, this.txtInvoiceNo.Text, this.txtStudentNo.Text);
                if (table.Rows.Count > 0)
                {
                    for (num = 0; num <= (table.Rows.Count - 1); num++)
                    {
                        count = this.dgvFeesItem.Rows.Count;
                        this.dgvFeesItem.Rows.Add(1);
                        this.dgvFeesItem.Rows[count].Cells[0].Value = table.Rows[num][4].ToString();
                        if (table.Rows[num][4].ToString() == "Enroll")
                        {
                            this.dgvFeesItem.Rows[count].Cells[1].Value = "Enrolment Fees";
                        }
                        else
                        {
                            this.dgvFeesItem.Rows[count].Cells[1].Value = this.cClassMaster.GetClassData(this.cGlobleVariable.LocationCode, table.Rows[num][4].ToString()).ClassName;
                        }
                        this.dgvFeesItem.Rows[count].Cells[2].Value = string.Format("{0:0.00}", Convert.ToDouble(table.Rows[num][5].ToString()));
                    }
                }
                DataTable table2 = this.cInvoiceTaxAmount.GetInvoiceTaxDetails(this.cGlobleVariable.LocationCode, this.txtInvoiceNo.Text, this.txtStudentNo.Text);
                this.dgvTax.Rows.Clear();
                if (table2.Rows.Count > 0)
                {
                    for (num = 0; num <= (table2.Rows.Count - 1); num++)
                    {
                        count = this.dgvTax.Rows.Count;
                        this.dgvTax.Rows.Add(1);
                        this.dgvTax.Rows[count].Cells[0].Value = table2.Rows[num][4].ToString();
                        this.dgvTax.Rows[count].Cells[1].Value = this.cTax.GetTaxData(table2.Rows[num][4].ToString()).TaxDescription;
                        this.dgvTax.Rows[count].Cells[2].Value = string.Format("{0:0.00}", Convert.ToDouble(table2.Rows[num][5].ToString()));
                    }
                }
                this.lblLastPaymentMonth.Text = "";
            }
        }

        private void txtNBT_TextChanged(object sender, EventArgs e)
        {
            if (this.txtNBT.Text == string.Empty)
            {
                this.txtNBT.Text = "0.00";
            }
            else
            {
                this.txtNBT.Text = string.Format("{0:0.00}", Convert.ToDouble(this.txtNBT.Text));
            }
        }

        private void txtPenaltyAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.cCommanMethods.MoveNextControl(e);
        }

        private void txtPenaltyAmount_Leave(object sender, EventArgs e)
        {
            this.txtPenaltyAmount.Text = string.Format("{0:0.00}", Convert.ToDouble(this.txtPenaltyAmount.Text));
        }

        private void txtPenaltyAmount_TextChanged(object sender, EventArgs e)
        {
            double dbTotalAmount = 0.0;
            if ((this.txtPenaltyAmount.Text != string.Empty) && (this.txtStudentDiscount.Text != string.Empty))
            {
                if (!this.cCommanMethods.IsNumber(this.txtPenaltyAmount.Text))
                {
                    this.txtPenaltyAmount.Text = "0.00";
                }
                if (this.chkIsTax.Checked)
                {
                    dbTotalAmount = (Convert.ToDouble(this.txtTotal.Text) + Convert.ToDouble(this.txtPenaltyAmount.Text)) - Convert.ToDouble(this.txtStudentDiscount.Text);
                    this.CalNBTAmount(dbTotalAmount);
                    this.CalTaxAmount();
                }
                else
                {
                    dbTotalAmount = 0.0;
                    this.CalNBTAmount(dbTotalAmount);
                    this.CalClearTaxAmount();
                }
                this.txtGrandTotal.Text = Convert.ToString((double) (Convert.ToDouble(this.txtTotalAmt.Text) + Convert.ToDouble(this.txtTotTax.Text)));
            }
            else
            {
                this.txtGrandTotal.Text = "0.00";
            }
        }

        private void txtStudentDiscount_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.cCommanMethods.MoveNextControl(e);
        }

        private void txtStudentDiscount_Leave(object sender, EventArgs e)
        {
            this.txtStudentDiscount.Text = string.Format("{0:0.00}", Convert.ToDouble(this.txtStudentDiscount.Text));
        }

        private void txtStudentDiscount_TextChanged(object sender, EventArgs e)
        {
            double dbTotalAmount = 0.0;
            if ((this.txtPenaltyAmount.Text != string.Empty) && (this.txtStudentDiscount.Text != string.Empty))
            {
                if (this.dgvFeesItem.Rows.Count > 0)
                {
                    if (!this.cCommanMethods.IsNumber(this.txtStudentDiscount.Text))
                    {
                        this.txtStudentDiscount.Text = "0.00";
                    }
                    if (this.chkIsTax.Checked)
                    {
                        dbTotalAmount = (Convert.ToDouble(this.txtTotal.Text) + Convert.ToDouble(this.txtPenaltyAmount.Text)) - Convert.ToDouble(this.txtStudentDiscount.Text);
                        this.CalNBTAmount(dbTotalAmount);
                        this.CalTaxAmount();
                    }
                    else
                    {
                        dbTotalAmount = 0.0;
                        this.CalNBTAmount(dbTotalAmount);
                        this.CalClearTaxAmount();
                    }
                }
                this.txtGrandTotal.Text = Convert.ToString((double) (Convert.ToDouble(this.txtTotalAmt.Text) + Convert.ToDouble(this.txtTotTax.Text)));
            }
            else
            {
                this.txtGrandTotal.Text = "0.00";
            }
        }

        private void txtStudentFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                if (!this.CheckIsValidateInvoiceDate())
                {
                    MessageBox.Show("Invoice date is invalid.", "Invoice Deta", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    this.dtpPayTo.Focus();
                }
                else if (!this.isItemExcist(this.cmbClassName["fldClassCode"].ToString()))
                {
                    int count = this.dgvFeesItem.Rows.Count;
                    this.dgvFeesItem.Rows.Add(1);
                    this.dgvFeesItem.Rows[count].Cells[0].Value = this.cmbClassName["fldClassCode"].ToString();
                    this.dgvFeesItem.Rows[count].Cells[1].Value = this.cmbClassName["fldClassName"].ToString();
                    this.dgvFeesItem.Rows[count].Cells[2].Value = string.Format("{0:0.00}", Convert.ToDouble(this.txtStudentFees.Text));
                    this.txtStudentFees.Text = "0.00";
                    this.cmbClassName.Focus();
                    this.TotalAmountFees();
                    this.txtGrandTotal.Text = Convert.ToString((double) (Convert.ToDouble(this.txtTotalAmt.Text) + Convert.ToDouble(this.txtTotTax.Text)));
                }
            }
        }

        private void txtStudentFees_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtStudentNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.cCommanMethods.MoveNextControl(e);
        }

        private void txtStudentNo_TextChanged(object sender, EventArgs e)
        {
            this.LoadStudent();
        }

        private void txtTotal_TextChanged(object sender, EventArgs e)
        {
            if (this.txtTotal.Text == string.Empty)
            {
                this.txtTotal.Text = "0.00";
            }
            else
            {
                this.txtTotal.Text = string.Format("{0:0.00}", Convert.ToDouble(this.txtTotal.Text));
            }
        }

        private void txtTotalAmt_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.cCommanMethods.MoveNextControl(e);
        }

        private void txtTotalAmt_TextChanged(object sender, EventArgs e)
        {
            if (this.txtTotalAmt.Text == string.Empty)
            {
                this.txtTotalAmt.Text = "0.00";
            }
            else
            {
                this.txtTotalAmt.Text = string.Format("{0:0.00}", Convert.ToDouble(this.txtTotalAmt.Text));
            }
        }

        private void txtTotTax_TextChanged(object sender, EventArgs e)
        {
            if (this.txtTotTax.Text == string.Empty)
            {
                this.txtTotTax.Text = "0.00";
            }
            else
            {
                this.txtTotTax.Text = string.Format("{0:0.00}", Convert.ToDouble(this.txtTotTax.Text));
            }
        }

        private bool ValidateData()
        {
            bool flag = true;
            if (this.txtStudentNo.Text == "")
            {
                this.errInvoice.SetError(this.txtStudentNo, "Please enter Student number");
                flag = false;
            }
            else
            {
                this.errInvoice.SetError(this.txtStudentNo, "");
            }
            if (this.txtFullNameLineOne.Text == "")
            {
                this.errInvoice.SetError(this.txtFullNameLineOne, "Please select Student");
                flag = false;
            }
            else
            {
                this.errInvoice.SetError(this.txtFullNameLineOne, "");
            }
            if (this.dgvFeesItem.Rows.Count <= 0)
            {
                this.errInvoice.SetError(this.dgvFeesItem, "Please enter Student Fees");
                flag = false;
            }
            else
            {
                this.errInvoice.SetError(this.dgvFeesItem, "");
            }
            if (!this.CheckIsValidateInvoiceDate())
            {
                MessageBox.Show("Invoice date is invalid.", "Invoice Deta", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.dtpPayTo.Focus();
                flag = false;
            }
            return flag;
        }

        public void ViewInvoice()
        {
            string[] strFieldList = new string[] { "fldInvoiceNo", "fldInvoiceDate" };
            string[] strHeadingList = new string[] { "Invoice No", "Invoice Name" };
            int[] iHeaderWidth = new int[] { 80, 100 };
            string strReturnField = "Invoice No";
            string str2 = "fldLocationCode = '" + this.cGlobleVariable.LocationCode + "' AND fldInvoiceStatus='" + this.cGlobleVariable.ActiveStatusCode + "'";
            this.txtInvoiceNo.Text = this.cCommanMethods.BrowsData("tbl_invoice_master", strFieldList, strHeadingList, iHeaderWidth, strReturnField, str2);
        }

        public void ViewStudent()
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

