namespace Pool_Application
{
    using Database_Layer;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;

    public class frmBackupDatabase : Form
    {
        private Button btmBackup;
        private Button btnSelectPath;
        private Button button1;
        private clsDBConnect cDBConn = new clsDBConnect();
        private IContainer components = null;
        private Label lblLastBackupDate;
        private TextBox txtBackupPath;

        public frmBackupDatabase()
        {
            this.InitializeComponent();
        }

        private void btmBackup_Click(object sender, EventArgs e)
        {
            object[,] arrParameter = new object[,] { { "mfldBackupPath", this.txtBackupPath.Text }, { "mfldLastBackupDate", DateTime.Now.ToString("yyyy-MM-dd") }, { "mfldBackupID", "1" } };
            this.cDBConn.Insert("sp_insert_update_backup_details", arrParameter);
            this.cDBConn.DatabaseBackup(this.txtBackupPath.Text);
        }

        private void btnSelectPath_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void frmBackupDatabase_Load(object sender, EventArgs e)
        {
            DataTable table = this.cDBConn.SearchDataWithSQL("SELECT * FROM tbl_backup_details WHERE fldBackupID =1");
            if (table.Rows.Count > 0)
            {
                this.txtBackupPath.Text = table.Rows[0]["fldBackupPath"].ToString();
                this.lblLastBackupDate.Text = "Last Backup date : " + Convert.ToDateTime(table.Rows[0]["fldLastBackupDate"].ToString()).ToString("yyyy-MM-dd");
            }
        }

        private void InitializeComponent()
        {
            this.btmBackup = new Button();
            this.txtBackupPath = new TextBox();
            this.btnSelectPath = new Button();
            this.lblLastBackupDate = new Label();
            this.button1 = new Button();
            base.SuspendLayout();
            this.btmBackup.Location = new Point(0x124, 0x57);
            this.btmBackup.Name = "btmBackup";
            this.btmBackup.Size = new Size(0x6d, 0x1c);
            this.btmBackup.TabIndex = 0;
            this.btmBackup.Text = "Start backup";
            this.btmBackup.UseVisualStyleBackColor = true;
            this.btmBackup.Click += new EventHandler(this.btmBackup_Click);
            this.txtBackupPath.Location = new Point(0x15, 0x35);
            this.txtBackupPath.Name = "txtBackupPath";
            this.txtBackupPath.Size = new Size(520, 20);
            this.txtBackupPath.TabIndex = 1;
            this.btnSelectPath.Location = new Point(0x223, 0x35);
            this.btnSelectPath.Name = "btnSelectPath";
            this.btnSelectPath.Size = new Size(0x23, 20);
            this.btnSelectPath.TabIndex = 2;
            this.btnSelectPath.Text = "...";
            this.btnSelectPath.UseVisualStyleBackColor = true;
            this.btnSelectPath.Click += new EventHandler(this.btnSelectPath_Click);
            this.lblLastBackupDate.AutoSize = true;
            this.lblLastBackupDate.Location = new Point(0x12, 0x12);
            this.lblLastBackupDate.Name = "lblLastBackupDate";
            this.lblLastBackupDate.Size = new Size(0x61, 13);
            this.lblLastBackupDate.TabIndex = 3;
            this.lblLastBackupDate.Text = "Last Backup date :";
            this.button1.Location = new Point(0xb1, 0x57);
            this.button1.Name = "button1";
            this.button1.Size = new Size(0x6d, 0x1c);
            this.button1.TabIndex = 4;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new EventHandler(this.button1_Click);
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x24a, 0x7f);
            base.ControlBox = false;
            base.Controls.Add(this.button1);
            base.Controls.Add(this.lblLastBackupDate);
            base.Controls.Add(this.btnSelectPath);
            base.Controls.Add(this.txtBackupPath);
            base.Controls.Add(this.btmBackup);
            base.Name = "frmBackupDatabase";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Backup database";
            base.Load += new EventHandler(this.frmBackupDatabase_Load);
            base.ResumeLayout(false);
            base.PerformLayout();
        }
    }
}

