namespace Pool_Application
{
    using Business_Layer;
    using Business_Layer.Property_Layer;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;

    public class frmSystemUpdate : Form
    {
        private clsGlobleVariable cGlobleVariable = new clsGlobleVariable();
        private IContainer components = null;
        private clsSystemUpdate cSystemUpdate = new clsSystemUpdate();
        private Label label1;
        private ProgressBar progressBar1;
        private Timer timer1;

        public frmSystemUpdate()
        {
            this.InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void frmSystemUpdate_Activated(object sender, EventArgs e)
        {
        }

        private void frmSystemUpdate_BindingContextChanged(object sender, EventArgs e)
        {
        }

        private void frmSystemUpdate_Enter(object sender, EventArgs e)
        {
        }

        private void frmSystemUpdate_Load(object sender, EventArgs e)
        {
            this.timer1.Enabled = true;
        }

        private void frmSystemUpdate_MouseCaptureChanged(object sender, EventArgs e)
        {
        }

        private void frmSystemUpdate_Paint(object sender, PaintEventArgs e)
        {
        }

        private void frmSystemUpdate_Validated(object sender, EventArgs e)
        {
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            this.progressBar1 = new ProgressBar();
            this.timer1 = new Timer(this.components);
            this.label1 = new Label();
            base.SuspendLayout();
            this.progressBar1.Location = new Point(15, 0x1f);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new Size(570, 0x1a);
            this.progressBar1.TabIndex = 0;
            this.timer1.Interval = 0x3e8;
            this.timer1.Tick += new EventHandler(this.timer1_Tick);
            this.label1.AutoSize = true;
            this.label1.Location = new Point(0x105, 0x4a);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x73, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Updating system .........";
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x255, 0x60);
            base.ControlBox = false;
            base.Controls.Add(this.label1);
            base.Controls.Add(this.progressBar1);
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "frmSystemUpdate";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "System Updates";
            base.TopMost = true;
            base.Load += new EventHandler(this.frmSystemUpdate_Load);
            base.BindingContextChanged += new EventHandler(this.frmSystemUpdate_BindingContextChanged);
            base.Paint += new PaintEventHandler(this.frmSystemUpdate_Paint);
            base.MouseCaptureChanged += new EventHandler(this.frmSystemUpdate_MouseCaptureChanged);
            base.Activated += new EventHandler(this.frmSystemUpdate_Activated);
            base.Enter += new EventHandler(this.frmSystemUpdate_Enter);
            base.Validated += new EventHandler(this.frmSystemUpdate_Validated);
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.timer1.Enabled = false;
            clsStudentPromotion promotion = new clsStudentPromotion();
            clsStudentMaster master = new clsStudentMaster();
            clsStudentClassTimes times = new clsStudentClassTimes();
            objStudentClassTimes oStudentClassTimes = new objStudentClassTimes();
            DataTable pendingPromotions = promotion.GetPendingPromotions(this.cGlobleVariable.LocationCode, DateTime.Now);
            this.progressBar1.Maximum = pendingPromotions.Rows.Count;
            for (int i = 0; i < pendingPromotions.Rows.Count; i++)
            {
                master.UpdateValues(this.cGlobleVariable.LocationCode, pendingPromotions.Rows[i]["fldStudentNo"].ToString(), pendingPromotions.Rows[i]["fldPromotedClassCode"].ToString(), Convert.ToDateTime(pendingPromotions.Rows[i]["fldPromoteDate"].ToString()));
                times.DeleteTimeDetails(this.cGlobleVariable.LocationCode, pendingPromotions.Rows[i]["fldStudentNo"].ToString());
                DataTable promotionDetails = promotion.GetPromotionDetails(pendingPromotions.Rows[i]["fldPromoID"].ToString());
                oStudentClassTimes.LocationCode = this.cGlobleVariable.LocationCode;
                for (int k = 0; k < promotionDetails.Rows.Count; k++)
                {
                    oStudentClassTimes.StudentNo = promotionDetails.Rows[k]["fldStudentNo"].ToString();
                    oStudentClassTimes.ClassCode = promotionDetails.Rows[k]["fldClassCode"].ToString();
                    oStudentClassTimes.ClassTimeCode = promotionDetails.Rows[k]["fldClassTimeCode"].ToString();
                    times.InsertUpdateStudentClassTimes(oStudentClassTimes);
                }
                promotion.UpdateValues(pendingPromotions.Rows[i]["fldPromoID"].ToString());
                this.progressBar1.Value = i + 1;
            }
            DataTable lastPaymentDates = new clsInvoice().GetLastPaymentDates();
            this.progressBar1.Value = 0;
            this.progressBar1.Maximum = lastPaymentDates.Rows.Count;
            for (int j = 0; j < lastPaymentDates.Rows.Count; j++)
            {
                master.UpdateStatus(this.cGlobleVariable.LocationCode, lastPaymentDates.Rows[j]["fldStudentNo"].ToString(), "C");
                this.progressBar1.Value = j + 1;
                Application.DoEvents();
            }
            this.cSystemUpdate.InsertUpdateSystemUpdateDate();
            base.Close();
        }
    }
}

