namespace Pool_Application
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class AutoUpdate : Form
    {
        private IContainer components = null;

        public AutoUpdate()
        {
            this.InitializeComponent();
        }

        private void AutoUpdate_Load(object sender, EventArgs e)
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

        private void InitializeComponent()
        {
            base.SuspendLayout();
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x11c, 0x106);
            base.Name = "AutoUpdate";
            this.Text = "AutoUpdate";
            base.Load += new EventHandler(this.AutoUpdate_Load);
            base.ResumeLayout(false);
        }
    }
}

