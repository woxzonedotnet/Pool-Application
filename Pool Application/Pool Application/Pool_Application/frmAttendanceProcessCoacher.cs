namespace Pool_Application
{
    using Business_Layer;
    using Business_Layer.Property_Layer;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;

    public class frmAttendanceProcessCoacher : Form
    {
        private Button btnClearAll;
        private Button btnExit;
        private Button btnProcess;
        private Button btnSelectAll;
        private clsAttendanceProcessCoacher cAttendanceProcessCoacher = new clsAttendanceProcessCoacher();
        private clsCoacherMaster cCoacherMaster = new clsCoacherMaster();
        private Pool_Application.clsGlobleVariable cGlobleVariable = new Pool_Application.clsGlobleVariable();
        private clsCommenMethods clsCommenMethod = new clsCommenMethods();
        private Pool_Application.clsGlobleVariable clsGlobleVariable = new Pool_Application.clsGlobleVariable();
        private DataGridViewCheckBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private IContainer components = null;
        private DataGridView dgvStudent;
        private DateTimePicker dtpFromDate;
        private DateTimePicker dtpToDate;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private objAttendanceProcessCoacher oAttendanceProcessCoacher = new objAttendanceProcessCoacher();
        private Panel panel1;
        private Panel panel2;
        private ProgressBar prgProgress;
        private string strProcessResult = string.Empty;

        public frmAttendanceProcessCoacher()
        {
            this.InitializeComponent();
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= (this.dgvStudent.Rows.Count - 1); i++)
            {
                this.dgvStudent.Rows[i].Cells[0].Value = "false";
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            this.prgProgress.Value = 0;
            TimeSpan span = (TimeSpan) (this.dtpToDate.Value - this.dtpFromDate.Value);
            int num = Convert.ToInt32(span.Days);
            this.prgProgress.Maximum = num + 1;
            this.oAttendanceProcessCoacher.LocationCode = this.clsGlobleVariable.LocationCode;
            for (DateTime time = this.dtpFromDate.Value; time <= this.dtpToDate.Value; time = time.AddDays(1.0))
            {
                this.prgProgress.Value++;
                this.oAttendanceProcessCoacher.AttendanceDate = time;
                for (int i = 0; i < this.dgvStudent.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(this.dgvStudent.Rows[i].Cells[0].Value))
                    {
                        this.oAttendanceProcessCoacher.CoacherCode = this.dgvStudent.Rows[i].Cells[1].Value.ToString();
                        DataTable table = this.cAttendanceProcessCoacher.AttendanceProcess(this.oAttendanceProcessCoacher);
                        for (int j = 0; j < (table.Rows.Count - 1); j++)
                        {
                            this.strProcessResult = this.strProcessResult + table.Rows[j][1].ToString() + "\n";
                        }
                    }
                }
            }
            MessageBox.Show("Successfully Completed", "Attendance Process", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            this.strProcessResult = string.Empty;
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= (this.dgvStudent.Rows.Count - 1); i++)
            {
                this.dgvStudent.Rows[i].Cells[0].Value = "True";
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

        private void frmAttendanceProcessCoacher_Load(object sender, EventArgs e)
        {
            this.dtpFromDate.CustomFormat = this.clsGlobleVariable.SystemDateFormat;
            this.dtpFromDate.Format = DateTimePickerFormat.Custom;
            this.dtpToDate.CustomFormat = this.clsGlobleVariable.SystemDateFormat;
            this.dtpToDate.Format = DateTimePickerFormat.Custom;
            this.LoadEmployees();
        }

        private void InitializeComponent()
        {
            this.groupBox2 = new GroupBox();
            this.dgvStudent = new DataGridView();
            this.label3 = new Label();
            this.btnExit = new Button();
            this.btnClearAll = new Button();
            this.btnSelectAll = new Button();
            this.groupBox3 = new GroupBox();
            this.panel2 = new Panel();
            this.label4 = new Label();
            this.label6 = new Label();
            this.dtpToDate = new DateTimePicker();
            this.label5 = new Label();
            this.dtpFromDate = new DateTimePicker();
            this.label1 = new Label();
            this.panel1 = new Panel();
            this.label2 = new Label();
            this.groupBox1 = new GroupBox();
            this.prgProgress = new ProgressBar();
            this.btnProcess = new Button();
            this.Column1 = new DataGridViewCheckBoxColumn();
            this.Column2 = new DataGridViewTextBoxColumn();
            this.Column3 = new DataGridViewTextBoxColumn();
            this.groupBox2.SuspendLayout();
            ((ISupportInitialize) this.dgvStudent).BeginInit();
            this.groupBox3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            base.SuspendLayout();
            this.groupBox2.BackColor = Color.Transparent;
            this.groupBox2.Controls.Add(this.dgvStudent);
            this.groupBox2.Location = new Point(-2, 140);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new Size(0x22d, 0x12a);
            this.groupBox2.TabIndex = 0x22;
            this.groupBox2.TabStop = false;
            this.dgvStudent.AllowUserToAddRows = false;
            this.dgvStudent.AllowUserToDeleteRows = false;
            this.dgvStudent.AllowUserToOrderColumns = true;
            this.dgvStudent.AllowUserToResizeColumns = false;
            this.dgvStudent.AllowUserToResizeRows = false;
            this.dgvStudent.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStudent.Columns.AddRange(new DataGridViewColumn[] { this.Column1, this.Column2, this.Column3 });
            this.dgvStudent.Location = new Point(0, 8);
            this.dgvStudent.Name = "dgvStudent";
            this.dgvStudent.Size = new Size(0x231, 0x124);
            this.dgvStudent.TabIndex = 0x18;
            this.label3.AutoSize = true;
            this.label3.Font = new Font("Tahoma", 8f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label3.ForeColor = Color.Black;
            this.label3.Location = new Point(0x4c, 0x20);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0xb8, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "User can maintain attendance details";
            this.btnExit.Location = new Point(0x1dd, 15);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new Size(0x4b, 0x17);
            this.btnExit.TabIndex = 0x1f;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new EventHandler(this.btnExit_Click);
            this.btnClearAll.Location = new Point(0x145, 15);
            this.btnClearAll.Name = "btnClearAll";
            this.btnClearAll.Size = new Size(0x45, 0x17);
            this.btnClearAll.TabIndex = 30;
            this.btnClearAll.Text = "Clear All";
            this.btnClearAll.UseVisualStyleBackColor = true;
            this.btnClearAll.Click += new EventHandler(this.btnClearAll_Click);
            this.btnSelectAll.Location = new Point(250, 15);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new Size(0x45, 0x17);
            this.btnSelectAll.TabIndex = 0x1d;
            this.btnSelectAll.Text = "Select All";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new EventHandler(this.btnSelectAll_Click);
            this.groupBox3.BackColor = Color.Transparent;
            this.groupBox3.Controls.Add(this.panel2);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.dtpToDate);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.dtpFromDate);
            this.groupBox3.Location = new Point(-2, 0x38);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new Size(0x231, 0x57);
            this.groupBox3.TabIndex = 0x20;
            this.groupBox3.TabStop = false;
            this.panel2.BackColor = Color.White;
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Location = new Point(0, -60);
            this.panel2.Name = "panel2";
            this.panel2.Size = new Size(0x231, 0x3f);
            this.panel2.TabIndex = 0x1f;
            this.label4.AutoSize = true;
            this.label4.Font = new Font("Tahoma", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.label4.ForeColor = Color.Black;
            this.label4.Location = new Point(0x22, 9);
            this.label4.Name = "label4";
            this.label4.Size = new Size(0xa5, 0x13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Attendance Details";
            this.label6.AutoSize = true;
            this.label6.Location = new Point(6, 0x13);
            this.label6.Name = "label6";
            this.label6.Size = new Size(0x38, 13);
            this.label6.TabIndex = 0x16;
            this.label6.Text = "From Date";
            this.dtpToDate.Format = DateTimePickerFormat.Short;
            this.dtpToDate.Location = new Point(290, 12);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new Size(0x7d, 20);
            this.dtpToDate.TabIndex = 0x1b;
            this.label5.AutoSize = true;
            this.label5.Location = new Point(0xf7, 0x10);
            this.label5.Name = "label5";
            this.label5.Size = new Size(20, 13);
            this.label5.TabIndex = 0x17;
            this.label5.Text = "To";
            this.dtpFromDate.Format = DateTimePickerFormat.Short;
            this.dtpFromDate.Location = new Point(0x4a, 15);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new Size(0x7d, 20);
            this.dtpFromDate.TabIndex = 0x1a;
            this.label1.AutoSize = true;
            this.label1.Font = new Font("Tahoma", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.label1.ForeColor = Color.Black;
            this.label1.Location = new Point(0x22, 9);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0xa5, 0x13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Attendance Details";
            this.panel1.BackColor = Color.White;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new Point(-2, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(0x231, 0x3f);
            this.panel1.TabIndex = 0x23;
            this.label2.AutoSize = true;
            this.label2.Font = new Font("Tahoma", 8f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label2.ForeColor = Color.Black;
            this.label2.Location = new Point(0x4c, 0x20);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0xb8, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "User can maintain attendance details";
            this.groupBox1.BackColor = Color.Transparent;
            this.groupBox1.Controls.Add(this.btnExit);
            this.groupBox1.Controls.Add(this.btnClearAll);
            this.groupBox1.Controls.Add(this.btnSelectAll);
            this.groupBox1.Controls.Add(this.prgProgress);
            this.groupBox1.Controls.Add(this.btnProcess);
            this.groupBox1.Location = new Point(-2, 0x1b4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(0x231, 0x2c);
            this.groupBox1.TabIndex = 0x21;
            this.groupBox1.TabStop = false;
            this.prgProgress.Location = new Point(6, 0x11);
            this.prgProgress.Name = "prgProgress";
            this.prgProgress.Size = new Size(0xef, 0x13);
            this.prgProgress.TabIndex = 0x1c;
            this.btnProcess.Location = new Point(400, 15);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new Size(0x47, 0x17);
            this.btnProcess.TabIndex = 0x19;
            this.btnProcess.Text = "Process";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new EventHandler(this.btnProcess_Click);
            this.Column1.HeaderText = "";
            this.Column1.Name = "Column1";
            this.Column1.Resizable = DataGridViewTriState.True;
            this.Column1.SortMode = DataGridViewColumnSortMode.Automatic;
            this.Column1.Width = 40;
            this.Column2.HeaderText = "Coacher No";
            this.Column2.Name = "Column2";
            this.Column3.HeaderText = "Coacher Name";
            this.Column3.Name = "Column3";
            this.Column3.Resizable = DataGridViewTriState.True;
            this.Column3.SortMode = DataGridViewColumnSortMode.NotSortable;
            this.Column3.Width = 350;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x22c, 0x1df);
            base.Controls.Add(this.groupBox2);
            base.Controls.Add(this.groupBox3);
            base.Controls.Add(this.panel1);
            base.Controls.Add(this.groupBox1);
            base.Name = "frmAttendanceProcessCoacher";
            this.Text = "Attendance Process";
            base.Load += new EventHandler(this.frmAttendanceProcessCoacher_Load);
            this.groupBox2.ResumeLayout(false);
            ((ISupportInitialize) this.dgvStudent).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            base.ResumeLayout(false);
        }

        private void LoadEmployees()
        {
            this.dgvStudent.Rows.Clear();
            DataTable coacherData = this.cCoacherMaster.GetCoacherData(this.cGlobleVariable.LocationCode);
            for (int i = 0; i < coacherData.Rows.Count; i++)
            {
                this.dgvStudent.Rows.Add(1);
                this.dgvStudent.Rows[i].Cells[1].Value = coacherData.Rows[i][2].ToString();
                this.dgvStudent.Rows[i].Cells[2].Value = coacherData.Rows[i][4].ToString();
            }
        }
    }
}

