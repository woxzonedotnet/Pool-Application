namespace Pool_Application
{
    using Business_Layer;
    using JTG;
    using System;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;

    public class clsCommenMethods
    {
        private clsBrowsData cBrowsData = new clsBrowsData();
        private clsGlobleVariable cGlobleVariable = new clsGlobleVariable();

        public string BrowsData(string strTableName, string[] strFieldList, string[] strHeadingList, int[] iHeaderWidth, string strReturnField, string Where_Clause)
        {
            new frmBrowsData(this.cBrowsData.BrowsData(strTableName, strFieldList, Where_Clause), strTableName, strFieldList, strHeadingList, iHeaderWidth, strReturnField, Where_Clause).ShowDialog();
            return this.cGlobleVariable.BrowsDataValue;
        }

        public void ClearForm(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                if (object.ReferenceEquals(control.GetType(), typeof(TextBox)))
                {
                    ((TextBox) control).Text = string.Empty;
                }
                else if (object.ReferenceEquals(control.GetType(), typeof(RichTextBox)))
                {
                    ((RichTextBox) control).Text = string.Empty;
                }
                else if (object.ReferenceEquals(control.GetType(), typeof(ComboBox)))
                {
                    ((ComboBox) control).Items.Clear();
                }
                else if (object.ReferenceEquals(control.GetType(), typeof(CheckBox)))
                {
                    ((CheckBox) control).Checked = false;
                }
                else if (object.ReferenceEquals(control.GetType(), typeof(RadioButton)))
                {
                    ((RadioButton) control).Checked = false;
                }
                else if (object.ReferenceEquals(control.GetType(), typeof(ColumnComboBox)))
                {
                    ((ColumnComboBox) control).ClearItems();
                }
                else if (object.ReferenceEquals(control.GetType(), typeof(PictureBox)))
                {
                    ((PictureBox) control).Image = null;
                }
                else if (object.ReferenceEquals(control.GetType(), typeof(DateTimePicker)))
                {
                    ((DateTimePicker) control).Value = DateTime.Now;
                }
                else if (object.ReferenceEquals(control.GetType(), typeof(DataGridView)))
                {
                    ((DataGridView) control).Rows.Clear();
                }
                if (control.Controls.Count > 0)
                {
                    this.ClearForm(control);
                }
            }
        }

        public void ClearForm(Control parent, bool IsLeftColumnComboBox)
        {
            foreach (Control control in parent.Controls)
            {
                if (object.ReferenceEquals(control.GetType(), typeof(TextBox)))
                {
                    ((TextBox) control).Text = string.Empty;
                }
                else if (object.ReferenceEquals(control.GetType(), typeof(RichTextBox)))
                {
                    ((RichTextBox) control).Text = string.Empty;
                }
                else if (object.ReferenceEquals(control.GetType(), typeof(ComboBox)))
                {
                    ((ComboBox) control).Items.Clear();
                }
                else if (object.ReferenceEquals(control.GetType(), typeof(CheckBox)))
                {
                    ((CheckBox) control).Checked = false;
                }
                else if (object.ReferenceEquals(control.GetType(), typeof(RadioButton)))
                {
                    ((RadioButton) control).Checked = false;
                }
                else if (object.ReferenceEquals(control.GetType(), typeof(PictureBox)))
                {
                    ((PictureBox) control).Image = null;
                }
                else if (object.ReferenceEquals(control.GetType(), typeof(DateTimePicker)))
                {
                    ((DateTimePicker) control).Value = DateTime.Now;
                }
                if (control.Controls.Count > 0)
                {
                    this.ClearForm(control, true);
                }
            }
        }

        public DateTime ConvertDateTime(string strDate)
        {
            int index = this.cGlobleVariable.SystemDateFormat.IndexOf("d");
            int startIndex = this.cGlobleVariable.SystemDateFormat.IndexOf("M");
            int num3 = this.cGlobleVariable.SystemDateFormat.IndexOf("y");
            string str = strDate.Substring(index, 2);
            string str2 = strDate.Substring(startIndex, 2);
            string str3 = strDate.Substring(num3, 4);
            DateTime time = new DateTime(Convert.ToInt16(str3), Convert.ToInt16(str2), Convert.ToInt16(str));
            return Convert.ToDateTime(str3 + "/" + time.ToString("MMM") + "/" + str);
        }

        public bool IsExpire()
        {
            clsExpire expire = new clsExpire();
            if (expire.LastLogDateTime().Rows.Count > 0)
            {
                MessageBox.Show("Invalid Date time");
                return true;
            }
            return false;
        }

        public bool IsNumber(string str)
        {
            bool flag = true;
            try
            {
                double num = Convert.ToDouble(str);
            }
            catch
            {
                flag = false;
            }
            return flag;
        }

        public void LoadCombo(DataTable dtFillData, ColumnComboBox objFillComb, int ViewColumn)
        {
            objFillComb.Data = dtFillData;
            objFillComb.ViewColumn = ViewColumn;
            for (int i = 0; i < dtFillData.Columns.Count; i++)
            {
                objFillComb.Columns[i].Display = false;
            }
            objFillComb.Columns[ViewColumn].Display = true;
        }

        public void LoadComboViewMultyColunm(DataTable dtFillData, ColumnComboBox objFillComb, int[] ViewColumn)
        {
            objFillComb.Data = dtFillData;
            for (int i = 0; i < dtFillData.Columns.Count; i++)
            {
                objFillComb.Columns[i].Display = false;
            }
            for (int j = 0; j < ViewColumn.GetLength(0); j++)
            {
                objFillComb.Columns[ViewColumn[j]].Display = true;
            }
        }

        public string LoadDialog(PictureBox ptbName)
        {
            OpenFileDialog dialog = new OpenFileDialog {
                Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp"
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                ptbName.Image = new Bitmap(dialog.FileName);
            }
            return dialog.FileName;
        }

        public void LoadMonths(ComboBox cmbCombo)
        {
            for (int i = 1; i <= 12; i++)
            {
                DateTime time = new DateTime(1, i, 1);
                cmbCombo.Items.Add(time.ToString("MMMM"));
            }
        }

        public void Loadyears(ComboBox cmbCombo)
        {
            int year = DateTime.Now.Year;
            for (int i = year - 10; i <= (year + 10); i++)
            {
                cmbCombo.Items.Add(i);
            }
        }

        public void MoveNextControl(KeyPressEventArgs KeyAschii)
        {
            if (KeyAschii.KeyChar == '\r')
            {
                SendKeys.Send("{TAB}");
            }
        }
    }
}

