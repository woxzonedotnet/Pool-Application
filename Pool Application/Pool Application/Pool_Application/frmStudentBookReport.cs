namespace Pool_Application
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class frmStudentBookReport : Form
    {
        private ComboBox cmbDays;
        private ComboBox cmbMonths;
        private ComboBox cmbYear;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column10;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column6;
        private DataGridViewTextBoxColumn Column7;
        private DataGridViewTextBoxColumn Column8;
        private DataGridViewTextBoxColumn Column9;
        private IContainer components = null;
        private DataGridView dataGridView1;
        private Label label1;
        private Label label2;
        private Label label3;

        public frmStudentBookReport()
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

        private void InitializeComponent()
        {
            this.cmbYear = new ComboBox();
            this.cmbDays = new ComboBox();
            this.label1 = new Label();
            this.label2 = new Label();
            this.label3 = new Label();
            this.dataGridView1 = new DataGridView();
            this.Column1 = new DataGridViewTextBoxColumn();
            this.Column2 = new DataGridViewTextBoxColumn();
            this.Column3 = new DataGridViewTextBoxColumn();
            this.Column4 = new DataGridViewTextBoxColumn();
            this.Column5 = new DataGridViewTextBoxColumn();
            this.Column6 = new DataGridViewTextBoxColumn();
            this.Column7 = new DataGridViewTextBoxColumn();
            this.Column8 = new DataGridViewTextBoxColumn();
            this.Column9 = new DataGridViewTextBoxColumn();
            this.Column10 = new DataGridViewTextBoxColumn();
            this.cmbMonths = new ComboBox();
            ((ISupportInitialize) this.dataGridView1).BeginInit();
            base.SuspendLayout();
            this.cmbYear.FormattingEnabled = true;
            this.cmbYear.Location = new Point(0x40, 12);
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.Size = new Size(0x79, 0x15);
            this.cmbYear.TabIndex = 1;
            this.cmbDays.FormattingEnabled = true;
            this.cmbDays.Location = new Point(0x194, 12);
            this.cmbDays.Name = "cmbDays";
            this.cmbDays.Size = new Size(0x79, 0x15);
            this.cmbDays.TabIndex = 2;
            this.label1.AutoSize = true;
            this.label1.Location = new Point(0x17, 15);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x1d, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Year";
            this.label2.AutoSize = true;
            this.label2.Location = new Point(0xbf, 0x10);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x25, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Month";
            this.label2.TextAlign = ContentAlignment.MiddleCenter;
            this.label3.AutoSize = true;
            this.label3.Location = new Point(0x169, 0x11);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x25, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Month";
            this.label3.TextAlign = ContentAlignment.MiddleCenter;
            this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new DataGridViewColumn[] { this.Column1, this.Column2, this.Column3, this.Column4, this.Column5, this.Column6, this.Column7, this.Column8, this.Column9, this.Column10 });
            this.dataGridView1.Location = new Point(6, 40);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new Size(0x2e5, 0x193);
            this.dataGridView1.TabIndex = 6;
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            this.Column2.HeaderText = "Column2";
            this.Column2.Name = "Column2";
            this.Column3.HeaderText = "Column3";
            this.Column3.Name = "Column3";
            this.Column4.HeaderText = "Column4";
            this.Column4.Name = "Column4";
            this.Column5.HeaderText = "Column5";
            this.Column5.Name = "Column5";
            this.Column6.HeaderText = "Column6";
            this.Column6.Name = "Column6";
            this.Column7.HeaderText = "Column7";
            this.Column7.Name = "Column7";
            this.Column8.HeaderText = "Column8";
            this.Column8.Name = "Column8";
            this.Column9.HeaderText = "Column9";
            this.Column9.Name = "Column9";
            this.Column10.HeaderText = "Column10";
            this.Column10.Name = "Column10";
            this.cmbMonths.FormattingEnabled = true;
            this.cmbMonths.Location = new Point(0xea, 13);
            this.cmbMonths.Name = "cmbMonths";
            this.cmbMonths.Size = new Size(0x79, 0x15);
            this.cmbMonths.TabIndex = 7;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x2ef, 0x1be);
            base.Controls.Add(this.cmbMonths);
            base.Controls.Add(this.dataGridView1);
            base.Controls.Add(this.label3);
            base.Controls.Add(this.label2);
            base.Controls.Add(this.label1);
            base.Controls.Add(this.cmbDays);
            base.Controls.Add(this.cmbYear);
            base.Name = "frmStudentBookReport";
            this.Text = "StudentBookReport";
            base.Load += new EventHandler(this.StudentBookReport_Load);
            ((ISupportInitialize) this.dataGridView1).EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        private void LoadMonths()
        {
            for (int i = 1; i <= 12; i++)
            {
                DateTime time = new DateTime(1, i, 1);
                this.cmbMonths.Items.Add(time.ToString("MMMM"));
            }
        }

        private void LoadWeekDays()
        {
            this.cmbDays.Items.Add("Sunday");
            this.cmbDays.Items.Add("Monday");
            this.cmbDays.Items.Add("Tuesday");
            this.cmbDays.Items.Add("Wednesday");
            this.cmbDays.Items.Add("Thursday");
            this.cmbDays.Items.Add("Friday");
            this.cmbDays.Items.Add("Saturday");
        }

        private void LoadYears()
        {
            int year = DateTime.Now.Year;
            for (int i = year - 10; i < (year + 10); i++)
            {
                this.cmbYear.Items.Add(i);
            }
            this.cmbYear.Text = year.ToString();
        }

        private void StudentBookReport_Load(object sender, EventArgs e)
        {
            this.LoadYears();
            this.LoadMonths();
            this.LoadWeekDays();
        }
    }
}

