namespace Pool_Application
{
    using Business_Layer;
    using Business_Layer.Property_Layer;
    using JTG;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Threading;
    using System.Windows.Forms;

    public class frmUserRights : Form
    {
        private Button btnClear;
        private Button btnExit;
        private Button btnSave;
        private Button btnSelectAll;
        private clsGlobleVariable cGlobleVariable = new clsGlobleVariable();
        private clsCommenMethods clsCommen = new clsCommenMethods();
        private ColumnComboBox cmbUserName;
        private DataGridViewTextBoxColumn ColMenu;
        private DataGridViewTextBoxColumn ColMenuName;
        private DataGridViewCheckBoxColumn ColRight;
        private IContainer components = null;
        private clsUserMaster cUserMaster = new clsUserMaster();
        private clsUserRight cUserRight = new clsUserRight();
        private DataGridView dgUserRights;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Label label1;
        private Label lblUserName;
        private frmMain objMain = new frmMain();
        private objUserMaster oUserMaster = new objUserMaster();
        private objUserRight oUserRight = new objUserRight();

        public frmUserRights()
        {
            this.InitializeComponent();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.selected(false);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.oUserRight.UserCode = this.cmbUserName["fldUserCode"].ToString();
            this.oUserRight.LocationCode = this.cGlobleVariable.LocationCode;
            this.cUserRight.DeleteUserRights(this.oUserRight.UserCode, this.oUserRight.LocationCode);
            foreach (DataGridViewRow row in (IEnumerable) this.dgUserRights.Rows)
            {
                if (Convert.ToInt16(row.Cells["ColRight"].Value) == 0)
                {
                    this.oUserRight.UserRight = row.Cells["ColMenu"].Value.ToString();
                    this.oUserRight.MenuType = row.Cells[3].Value.ToString();
                    this.oUserRight.MenuName = row.Cells[2].Value.ToString();
                    this.oUserRight.LocationCode = this.cGlobleVariable.LocationCode;
                    this.cUserRight.InsertUpdateData(this.oUserRight);
                }
            }
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            this.selected(true);
        }

        private void chkMenuItems(Control ctrl)
        {
            this.dgUserRights.Columns.Add("colRightPrefixName", "MenuRightPrefix");
            foreach (Control control in this.objMain.Controls)
            {
                if (object.ReferenceEquals(control.GetType(), typeof(MenuStrip)))
                {
                    int num = 0;
                    foreach (ToolStripMenuItem item in this.objMain.menuStrip.Items)
                    {
                        int num2 = item.DropDownItems.Count + 1;
                        this.dgUserRights.Rows.Add(1);
                        this.dgUserRights.Rows[num].Cells[0].Value = item.Text.Replace("&", "");
                        this.dgUserRights.Rows[num].Cells[2].Value = item.Name;
                        this.dgUserRights.Rows[num].Cells[3].Value = "M";
                        this.dgUserRights.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                        foreach (ToolStripItem item2 in item.DropDownItems)
                        {
                            if ((item2.Text != "") && (item2.Text != "Developer Area"))
                            {
                                num++;
                                this.dgUserRights.Rows.Add(1);
                                this.dgUserRights.Rows[num].Cells[0].Style.ForeColor = Color.Blue;
                                this.dgUserRights.Rows[num].Cells[0].Style.Padding = new Padding(0x19, 0, 0, 0);
                                this.dgUserRights.Rows[num].Cells[0].Style.Font = new Font("Arial", 9f);
                                this.dgUserRights.Rows[num].Cells[0].Value = item2.Text.Replace("&", "");
                                this.dgUserRights.Rows[num].Cells[2].Value = item2.Name;
                                this.dgUserRights.Rows[num].Cells[3].Value = "S";
                            }
                        }
                        num++;
                    }
                }
            }
            this.dgUserRights.Columns[0].ReadOnly = true;
            this.dgUserRights.AllowUserToAddRows = false;
            this.dgUserRights.Columns[1].Width = 120;
            this.dgUserRights.Columns[2].Width = 50;
            this.dgUserRights.Columns[3].Width = 50;
        }

        private void cmbUserName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbUserName.SelectedIndex > -1)
            {
                DataTable table = this.cUserRight.getUserRights_Data(this.cmbUserName["fldUserCode"].ToString(), this.cGlobleVariable.LocationCode);
                if (table.Rows.Count > 0)
                {
                    for (int i = 0; i < this.dgUserRights.Rows.Count; i++)
                    {
                        this.dgUserRights.Rows[i].Cells[1].Value = true;
                        for (int j = 0; j < table.Rows.Count; j++)
                        {
                            if (this.dgUserRights.Rows[i].Cells[2].Value.ToString() == table.Rows[j][4].ToString())
                            {
                                this.dgUserRights.Rows[i].Cells[1].Value = false;
                                break;
                            }
                        }
                    }
                }
                else
                {
                    this.selected(true);
                }
            }
        }

        private void dgUserRights_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dgUserRights.Rows[e.RowIndex].Cells[3].Value.ToString() == "M")
            {
                Thread.Sleep(200);
                bool flag = Convert.ToBoolean(this.dgUserRights.Rows[e.RowIndex].Cells[1].EditedFormattedValue);
                this.dgUserRights.Cursor = Cursors.Hand;
                for (int i = e.RowIndex + 1; i < this.dgUserRights.Rows.Count; i++)
                {
                    if (this.dgUserRights.Rows[i].Cells[3].Value.ToString() != "M")
                    {
                        this.dgUserRights.Rows[i].Cells[1].Value = flag;
                    }
                    else
                    {
                        break;
                    }
                }
                this.dgUserRights.Cursor = Cursors.Default;
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

        private void frmUserRights_Load(object sender, EventArgs e)
        {
            this.dgUserRights.ScrollBars = ScrollBars.Vertical;
            this.clsCommen.LoadCombo(this.cUserMaster.GetUsers(this.cGlobleVariable.LocationCode, this.cGlobleVariable.ActiveStatusCode), this.cmbUserName, 3);
            frmMain main = new frmMain();
            MainMenu menu = new MainMenu();
            string str = main.MainMenuStrip.Items[1].Name.ToString();
            Control ctrl = null;
            this.chkMenuItems(ctrl);
        }

        private void InitializeComponent()
        {
            DataGridViewCellStyle style = new DataGridViewCellStyle();
            DataGridViewCellStyle style2 = new DataGridViewCellStyle();
            DataGridViewCellStyle style3 = new DataGridViewCellStyle();
            ComponentResourceManager manager = new ComponentResourceManager(typeof(frmUserRights));
            this.groupBox1 = new GroupBox();
            this.label1 = new Label();
            this.groupBox2 = new GroupBox();
            this.btnSelectAll = new Button();
            this.btnExit = new Button();
            this.btnClear = new Button();
            this.btnSave = new Button();
            this.lblUserName = new Label();
            this.dgUserRights = new DataGridView();
            this.ColMenu = new DataGridViewTextBoxColumn();
            this.ColRight = new DataGridViewCheckBoxColumn();
            this.ColMenuName = new DataGridViewTextBoxColumn();
            this.cmbUserName = new ColumnComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((ISupportInitialize) this.dgUserRights).BeginInit();
            base.SuspendLayout();
            this.groupBox1.BackColor = Color.FromArgb(0xe0, 0xe0, 0xe0);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new Point(0, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(0x2bf, 0x3e);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.label1.AutoSize = true;
            this.label1.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.label1.ForeColor = SystemColors.Highlight;
            this.label1.Location = new Point(0x65, 7);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0xf9, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "User Rights Assignment Form";
            this.groupBox2.BackColor = Color.Silver;
            this.groupBox2.Controls.Add(this.btnSelectAll);
            this.groupBox2.Controls.Add(this.btnExit);
            this.groupBox2.Controls.Add(this.btnClear);
            this.groupBox2.Controls.Add(this.btnSave);
            this.groupBox2.Controls.Add(this.lblUserName);
            this.groupBox2.Controls.Add(this.dgUserRights);
            this.groupBox2.Controls.Add(this.cmbUserName);
            this.groupBox2.Location = new Point(0, 60);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new Size(0x19d, 0x199);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.btnSelectAll.Location = new Point(0xc4, 0x169);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new Size(0x4b, 0x17);
            this.btnSelectAll.TabIndex = 7;
            this.btnSelectAll.Text = "&Select All";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new EventHandler(this.btnSelectAll_Click);
            this.btnExit.Location = new Point(0x141, 0x169);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new Size(0x4b, 0x17);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "&Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new EventHandler(this.btnExit_Click);
            this.btnClear.Location = new Point(0x73, 0x169);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new Size(0x4b, 0x17);
            this.btnClear.TabIndex = 5;
            this.btnClear.Text = "&Clear All";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new EventHandler(this.btnClear_Click);
            this.btnSave.Location = new Point(0x1c, 0x169);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new Size(0x4b, 0x17);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new EventHandler(this.btnSave_Click);
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.lblUserName.ForeColor = SystemColors.Highlight;
            this.lblUserName.Location = new Point(0x1a, 0x1a);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new Size(0x3b, 13);
            this.lblUserName.TabIndex = 3;
            this.lblUserName.Text = "User Name";
            style.BackColor = SystemColors.Control;
            style.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            style.ForeColor = SystemColors.WindowText;
            style.SelectionBackColor = SystemColors.Highlight;
            style.SelectionForeColor = SystemColors.HighlightText;
            style.WrapMode = DataGridViewTriState.True;
            this.dgUserRights.ColumnHeadersDefaultCellStyle = style;
            this.dgUserRights.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgUserRights.Columns.AddRange(new DataGridViewColumn[] { this.ColMenu, this.ColRight, this.ColMenuName });
            this.dgUserRights.Location = new Point(12, 0x3a);
            this.dgUserRights.Name = "dgUserRights";
            this.dgUserRights.RowHeadersVisible = false;
            this.dgUserRights.Size = new Size(0x17e, 0x11b);
            this.dgUserRights.TabIndex = 2;
            this.dgUserRights.CellContentClick += new DataGridViewCellEventHandler(this.dgUserRights_CellContentClick);
            style2.BackColor = Color.White;
            style2.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.ColMenu.DefaultCellStyle = style2;
            this.ColMenu.HeaderText = "Menu";
            this.ColMenu.Name = "ColMenu";
            this.ColMenu.Resizable = DataGridViewTriState.True;
            this.ColMenu.Width = 260;
            style3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            style3.BackColor = Color.White;
            style3.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, 0);
            style3.NullValue = false;
            this.ColRight.DefaultCellStyle = style3;
            this.ColRight.HeaderText = "Rights";
            this.ColRight.Name = "ColRight";
            this.ColRight.Resizable = DataGridViewTriState.True;
            this.ColRight.SortMode = DataGridViewColumnSortMode.Automatic;
            this.ColRight.Width = 120;
            this.ColMenuName.HeaderText = "MenuName";
            this.ColMenuName.Name = "ColMenuName";
            this.cmbUserName.DrawMode = DrawMode.OwnerDrawVariable;
            this.cmbUserName.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbUserName.DropDownWidth = 0x11;
            this.cmbUserName.FormattingEnabled = true;
            this.cmbUserName.Location = new Point(120, 0x13);
            this.cmbUserName.Name = "cmbUserName";
            this.cmbUserName.Size = new Size(140, 0x15);
            this.cmbUserName.TabIndex = 0;
            this.cmbUserName.ViewColumn = 0;
            this.cmbUserName.SelectedIndexChanged += new EventHandler(this.cmbUserName_SelectedIndexChanged);
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x199, 0x1d3);
            base.Controls.Add(this.groupBox2);
            base.Controls.Add(this.groupBox1);
            base.FormBorderStyle = FormBorderStyle.FixedSingle;
            base.MaximizeBox = false;
            base.Name = "frmUserRights";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "User Rights";
            base.Load += new EventHandler(this.frmUserRights_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((ISupportInitialize) this.dgUserRights).EndInit();
            base.ResumeLayout(false);
        }

        private void selected(bool bStatus)
        {
            foreach (DataGridViewRow row in (IEnumerable) this.dgUserRights.Rows)
            {
                row.Cells[1].Value = bStatus;
            }
        }
    }
}

