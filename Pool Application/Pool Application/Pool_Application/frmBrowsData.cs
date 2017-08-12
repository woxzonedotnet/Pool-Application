namespace Pool_Application
{
    using Business_Layer;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;

    public class frmBrowsData : Form
    {
        public Button btnExit;
        public Button btnSelect;
        private clsBrowsData cBrowsData;
        private clsGlobleVariable cGlobleVariable;
        private IContainer components;
        private DataGridView dgvDataView;
        private DataTable dtBroesDataTable;
        private int[] iHeaderFieldWidth;
        private Panel panel1;
        private string[] strFieldS;
        private string[] strHeading;
        private string strReturnFieldName;
        private string strSearchFiled;
        private string strTable;
        private string strWhere_Clause;
        private TextBox txtSearchBox;

        public frmBrowsData(DataTable dtBroesData, string strTableName, string[] strFieldList, string[] strHeadingList, int[] iHeaderWidth, string strReturnField)
        {
            this.components = null;
            this.strTable = "";
            this.strWhere_Clause = "";
            this.strSearchFiled = "";
            this.strReturnFieldName = "";
            this.cBrowsData = new clsBrowsData();
            this.cGlobleVariable = new clsGlobleVariable();
            this.InitializeComponent();
            this.strTable = strTableName;
            this.strFieldS = strFieldList;
            this.strHeading = strHeadingList;
            this.iHeaderFieldWidth = iHeaderWidth;
            this.strReturnFieldName = strReturnField;
            this.dtBroesDataTable = dtBroesData;
            this.SetGridSettings();
        }

        public frmBrowsData(DataTable dtBroesData, string strTableName, string[] strFieldList, string[] strHeadingList, int[] iHeaderWidth, string strReturnField, string Where_Clause)
        {
            this.components = null;
            this.strTable = "";
            this.strWhere_Clause = "";
            this.strSearchFiled = "";
            this.strReturnFieldName = "";
            this.cBrowsData = new clsBrowsData();
            this.cGlobleVariable = new clsGlobleVariable();
            this.InitializeComponent();
            this.strTable = strTableName;
            this.strFieldS = strFieldList;
            this.strHeading = strHeadingList;
            this.iHeaderFieldWidth = iHeaderWidth;
            this.strReturnFieldName = strReturnField;
            this.dtBroesDataTable = dtBroesData;
            this.strWhere_Clause = Where_Clause;
            this.SetGridSettings();
        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            this.cGlobleVariable.BrowsDataValue = "";
            base.Close();
        }

        private void btnSelect_Click_1(object sender, EventArgs e)
        {
            if (this.cGlobleVariable.BrowsDataValue == "")
            {
                MessageBox.Show("Please Click on grid before click Select Button.", "Search data", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                base.Close();
            }
        }

        private void ctrlRadioButton_Click(object sender, EventArgs e)
        {
            RadioButton button = (RadioButton) sender;
            this.strSearchFiled = button.Name.ToString();
            this.txtSearchBox.Focus();
        }

        private void dgvDataView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                this.cGlobleVariable.BrowsDataValue = this.dgvDataView.Rows[e.RowIndex].Cells[this.strReturnFieldName].Value.ToString();
            }
        }

        private void dgvDataView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                this.cGlobleVariable.BrowsDataValue = this.dgvDataView.Rows[e.RowIndex].Cells[this.strReturnFieldName].Value.ToString();
                base.Close();
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

        private void frmBrowsData_KeyDown(object sender, KeyEventArgs e)
        {
            foreach (Control control in base.Controls)
            {
                if (object.ReferenceEquals(control.GetType(), typeof(RadioButton)))
                {
                    int startIndex = ((RadioButton) control).Text.IndexOf("(") + 1;
                    int num2 = ((RadioButton) control).Text.Length - 1;
                    int length = num2 - startIndex;
                    if (((RadioButton) control).Text.Substring(startIndex, length) == e.KeyCode.ToString())
                    {
                        ((RadioButton) control).Checked = true;
                        this.strSearchFiled = ((RadioButton) control).Name.ToString();
                        this.txtSearchBox.Focus();
                    }
                }
            }
        }

        private void frmBrowsData_Load(object sender, EventArgs e)
        {
        }

        private void InitializeComponent()
        {
            this.dgvDataView = new DataGridView();
            this.txtSearchBox = new TextBox();
            this.panel1 = new Panel();
            this.btnSelect = new Button();
            this.btnExit = new Button();
            ((ISupportInitialize) this.dgvDataView).BeginInit();
            this.panel1.SuspendLayout();
            base.SuspendLayout();
            this.dgvDataView.AllowUserToAddRows = false;
            this.dgvDataView.AllowUserToDeleteRows = false;
            this.dgvDataView.AllowUserToResizeRows = false;
            this.dgvDataView.BackgroundColor = SystemColors.Control;
            this.dgvDataView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDataView.GridColor = Color.Pink;
            this.dgvDataView.Location = new Point(5, 0x79);
            this.dgvDataView.MultiSelect = false;
            this.dgvDataView.Name = "dgvDataView";
            this.dgvDataView.ReadOnly = true;
            this.dgvDataView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvDataView.Size = new Size(0x1de, 0x133);
            this.dgvDataView.TabIndex = 1;
            this.dgvDataView.CellClick += new DataGridViewCellEventHandler(this.dgvDataView_CellClick);
            this.dgvDataView.CellDoubleClick += new DataGridViewCellEventHandler(this.dgvDataView_CellDoubleClick);
            this.txtSearchBox.Location = new Point(5, 0x5f);
            this.txtSearchBox.Name = "txtSearchBox";
            this.txtSearchBox.Size = new Size(0x1de, 20);
            this.txtSearchBox.TabIndex = 2;
            this.txtSearchBox.TextChanged += new EventHandler(this.txtSearchBox_TextChanged);
            this.txtSearchBox.KeyDown += new KeyEventHandler(this.txtSearchBox_KeyDown);
            this.panel1.Controls.Add(this.btnSelect);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Location = new Point(-7, 0x1b2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(510, 0x3b);
            this.panel1.TabIndex = 20;
            this.btnSelect.Location = new Point(0x14d, 0x13);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new Size(0x47, 0x17);
            this.btnSelect.TabIndex = 20;
            this.btnSelect.Text = "&Select";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new EventHandler(this.btnSelect_Click_1);
            this.btnExit.FlatAppearance.BorderColor = Color.FromArgb(0x40, 0x40, 0x40);
            this.btnExit.FlatAppearance.BorderSize = 5;
            this.btnExit.Location = new Point(0x197, 0x13);
            this.btnExit.Margin = new Padding(0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new Size(0x53, 0x17);
            this.btnExit.TabIndex = 0x15;
            this.btnExit.Text = "E&xit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new EventHandler(this.btnExit_Click_1);
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            base.ClientSize = new Size(0x1eb, 490);
            base.ControlBox = false;
            base.Controls.Add(this.panel1);
            base.Controls.Add(this.txtSearchBox);
            base.Controls.Add(this.dgvDataView);
            base.FormBorderStyle = FormBorderStyle.SizableToolWindow;
            base.KeyPreview = true;
            base.Name = "frmBrowsData";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Search Data";
            base.KeyDown += new KeyEventHandler(this.frmBrowsData_KeyDown);
            base.Load += new EventHandler(this.frmBrowsData_Load);
            ((ISupportInitialize) this.dgvDataView).EndInit();
            this.panel1.ResumeLayout(false);
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        private void SetGridSettings()
        {
            int num3;
            int x = -120;
            int num2 = 0;
            for (num3 = 0; num3 < this.strHeading.Length; num3++)
            {
                x += 140;
                num2++;
                string str = " (F" + num2 + ")";
                RadioButton button = new RadioButton {
                    Name = this.strFieldS[num3].ToString(),
                    Text = this.strHeading[num3].ToString() + str,
                    AutoSize = true,
                    Location = new Point(x, 70)
                };
                button.Click += new EventHandler(this.ctrlRadioButton_Click);
                base.Controls.Add(button);
                this.dtBroesDataTable.Columns[num3].ColumnName = this.strHeading[num3];
            }
            this.dgvDataView.DataSource = this.dtBroesDataTable;
            this.dgvDataView.RowHeadersVisible = false;
            for (num3 = 0; num3 < this.dtBroesDataTable.Columns.Count; num3++)
            {
                this.dgvDataView.Columns[num3].Width = this.iHeaderFieldWidth[num3];
            }
        }

        private void txtSearchBox_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode.ToString() == "Down") && (this.dgvDataView.Rows.Count > 1))
            {
                this.dgvDataView.Focus();
            }
        }

        private void txtSearchBox_TextChanged(object sender, EventArgs e)
        {
            int num;
            string str = "";
            if (this.strWhere_Clause == "")
            {
                str = this.strSearchFiled + " LIKE '" + this.txtSearchBox.Text + "%'";
            }
            else if ((this.strTable == "tbl_student_master") & (this.strSearchFiled == "fldNameInFullL1"))
            {
                str = this.strWhere_Clause + " AND " + this.strSearchFiled + " LIKE '%" + this.txtSearchBox.Text + "%'";
            }
            else
            {
                str = this.strWhere_Clause + " AND " + this.strSearchFiled + " LIKE '" + this.txtSearchBox.Text + "%'";
            }
            DataTable table = this.cBrowsData.BrowsData(this.strTable, this.strFieldS, str);
            for (num = 0; num < this.strHeading.Length; num++)
            {
                table.Columns[num].ColumnName = this.strHeading[num];
            }
            this.dgvDataView.DataSource = table;
            for (num = 0; num < table.Columns.Count; num++)
            {
                this.dgvDataView.Columns[num].Width = this.iHeaderFieldWidth[num];
            }
        }
    }
}

