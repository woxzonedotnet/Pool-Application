namespace Pool_Application
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Printing;
    using System.Windows.Forms;

    public class test : Form
    {
        private Button button1;
        private Button button2;
        private Button button3;
        private IContainer components = null;
        private PrintDialog printDialog1;
        private PrintDocument printDocument1;

        public test()
        {
            this.InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.printDialog1.ShowDialog() == DialogResult.OK)
            {
                this.printDocument1.PrinterSettings = this.printDialog1.PrinterSettings;
                this.printDocument1.Print();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new PrintPreviewDialog { Document = this.printDocument1 }.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
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
            this.button1 = new Button();
            this.printDocument1 = new PrintDocument();
            this.printDialog1 = new PrintDialog();
            this.button2 = new Button();
            this.button3 = new Button();
            base.SuspendLayout();
            this.button1.Location = new Point(0x6f, 220);
            this.button1.Name = "button1";
            this.button1.Size = new Size(0x4b, 0x17);
            this.button1.TabIndex = 0;
            this.button1.Text = "print";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new EventHandler(this.button1_Click);
            this.printDocument1.PrintPage += new PrintPageEventHandler(this.printDocument1_PrintPage);
            this.printDialog1.UseEXDialog = true;
            this.button2.Location = new Point(0x2a, 0xa1);
            this.button2.Name = "button2";
            this.button2.Size = new Size(0x4b, 0x17);
            this.button2.TabIndex = 1;
            this.button2.Text = "preview";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new EventHandler(this.button2_Click);
            this.button3.Location = new Point(0xc1, 0xa1);
            this.button3.Name = "button3";
            this.button3.Size = new Size(0x4b, 0x17);
            this.button3.TabIndex = 2;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new EventHandler(this.button3_Click);
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x124, 0x10a);
            base.Controls.Add(this.button3);
            base.Controls.Add(this.button2);
            base.Controls.Add(this.button1);
            base.Name = "test";
            this.Text = "test";
            base.ResumeLayout(false);
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            Font font = new Font("Arial", 12f, FontStyle.Bold);
            e.Graphics.DrawString("Itgem Code", font, Brushes.Black, (float) 50f, (float) 50f);
            e.Graphics.DrawString("Item Name", font, Brushes.Black, (float) 200f, (float) 50f);
            e.Graphics.DrawString("Description", font, Brushes.Black, (float) 350f, (float) 50f);
            e.Graphics.DrawString("Price", font, Brushes.Black, (float) 500f, (float) 50f);
            e.Graphics.DrawString("Qty", font, Brushes.Black, (float) 650f, (float) 50f);
            e.Graphics.DrawString("Value", font, Brushes.Black, (float) 800f, (float) 50f);
        }
    }
}

