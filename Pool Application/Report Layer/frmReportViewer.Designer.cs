namespace Report_Layer
{
    partial class frmReportViewer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        //private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing && (components != null))
        //    {
        //        components.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.CryReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // CryReportViewer
            // 
            this.CryReportViewer.ActiveViewIndex = -1;
            this.CryReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CryReportViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.CryReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CryReportViewer.Location = new System.Drawing.Point(0, 0);
            this.CryReportViewer.Name = "CryReportViewer";
            this.CryReportViewer.Size = new System.Drawing.Size(682, 258);
            this.CryReportViewer.TabIndex = 0;
            this.CryReportViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // frmReportViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 258);
            this.Controls.Add(this.CryReportViewer);
            this.Name = "frmReportViewer";
            this.Text = "Report Viewer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmReportViever_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
    }
}