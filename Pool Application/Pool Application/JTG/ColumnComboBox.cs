namespace JTG
{
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Reflection;
    using System.Windows.Forms;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    //using System.Linq;
    using System.Text;
    //using System.Threading.Tasks;
    using System.Runtime.InteropServices;
    using System.Xml;

    public class ColumnComboBox : ComboBox
    {
        public uint ColumnSpacing;
        private Container components;
        public bool DropDownOnSuggestion;
        private bool m_bInitDisplay;
        private bool m_bInitItems;
        private bool m_bInitSuggestionList;
        private bool m_bTextChangedInternal;
        private CCBColumnCollection m_Cols;
        private DataTable m_dtData = null;
        private DataView m_dvView;
        private int[] m_iaColWidths;
        private int m_iSelectedIndex;
        private int m_iViewColumn;
        private Keys m_kcLastKey;
        private StringList m_slSuggestions;
        public bool Suggest;

        public ColumnComboBox()
        {
            this.m_slSuggestions = new StringList();
            this.m_kcLastKey = Keys.Space;
            this.m_iaColWidths = new int[1];
            this.ColumnSpacing = 4;
            this.m_Cols = new CCBColumnCollection();
            this.m_dtData = null;
            this.m_dvView = null;
            this.m_iViewColumn = 0;
            this.m_bInitItems = true;
            this.m_bInitDisplay = true;
            this.m_bInitSuggestionList = true;
            this.m_bTextChangedInternal = false;
            this.DropDownOnSuggestion = true;
            this.Suggest = true;
            this.m_iSelectedIndex = -1;
            this.components = null;
            if (this.components == null)
            {
                this.components = null;
            }
            this.Data = new DataTable();
            this.Init();
        }

        public ColumnComboBox(DataTable dtData)
        {
            this.m_slSuggestions = new StringList();
            this.m_kcLastKey = Keys.Space;
            this.m_iaColWidths = new int[1];
            this.ColumnSpacing = 4;
            this.m_Cols = new CCBColumnCollection();
            this.m_dtData = null;
            this.m_dvView = null;
            this.m_iViewColumn = 0;
            this.m_bInitItems = true;
            this.m_bInitDisplay = true;
            this.m_bInitSuggestionList = true;
            this.m_bTextChangedInternal = false;
            this.DropDownOnSuggestion = true;
            this.Suggest = true;
            this.m_iSelectedIndex = -1;
            this.components = null;
            this.Data = dtData;
            this.Init();
        }

        public void ClearItems()
        {
            this.SelectedIndex = -1;
        }

        private void ColumnComboBox_OnColumnDisplayChanged(object sender, CCBColumnEventArgs e)
        {
            this.m_bInitDisplay = true;
        }

        private void Init()
        {
            base.DrawMode = DrawMode.OwnerDrawVariable;
        }

        private void InitDisplay()
        {
            try
            {
                int num;
                int[] numArray = new int[this.m_Cols.Count];
                SizeF layoutArea = new SizeF(10000f, (float) base.ItemHeight);
                Graphics graphics = base.CreateGraphics();
                numArray = new int[this.m_Cols.Count];
                foreach (DataRowView view in this.m_dvView)
                {
                    num = 0;
                    while (num < this.m_Cols.Count)
                    {
                        string text = view[num].ToString();
                        int width = (int) graphics.MeasureString(text, this.Font, layoutArea).Width;
                        if (width > numArray[num])
                        {
                            numArray[num] = width;
                        }
                        num++;
                    }
                }
                base.DropDownWidth = 1;
                for (num = 0; num < numArray.Length; num++)
                {
                    if (this.m_Cols[num].Width < 0)
                    {
                        this.m_Cols[num].CalculatedWidth = numArray[num] + ((int) this.ColumnSpacing);
                    }
                    else
                    {
                        this.m_Cols[num].CalculatedWidth = this.m_Cols[num].Width + ((int) this.ColumnSpacing);
                    }
                    int num3 = 0;
                    num3++;
                    if (this.m_Cols[num].Display)
                    {
                        base.DropDownWidth += this.m_Cols[num].CalculatedWidth;
                    }
                }
                base.DropDownWidth += 0x10;
                this.m_bInitDisplay = false;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message + "\r\nIn ColumnComboBox.InitDisplay().");
            }
        }

        private void InitializeComponent()
        {
        }

        private void InitItems()
        {
            try
            {
                this.m_Cols.Clear();
                foreach (DataColumn column in this.m_dtData.Columns)
                {
                    this.m_Cols.Add(new CCBColumn(column.Caption));
                }
                if (this.m_iViewColumn > (this.m_Cols.Count - 1))
                {
                    this.m_iViewColumn = this.m_Cols.Count - 1;
                }
                if (this.m_iViewColumn < 0)
                {
                    this.m_iViewColumn = 0;
                }
                for (int i = 0; i < this.m_Cols.Count; i++)
                {
                    this.m_Cols[i].OnColumnDisplayChanged += new ChangeColumnDisplayHandler(this.ColumnComboBox_OnColumnDisplayChanged);
                }
                base.Items.Clear();
                foreach (DataRowView view in this.m_dvView)
                {
                    string item = view[this.m_iViewColumn].ToString();
                    base.Items.Add(item);
                }
                this.m_bInitItems = false;
                this.m_bInitDisplay = true;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message + "\r\nIn ColumnComboBox.InitItems().");
            }
        }

        private void InitSuggestionList()
        {
            this.m_slSuggestions.Clear();
            foreach (DataRowView view in this.m_dvView)
            {
                string s = view[this.m_iViewColumn].ToString();
                this.m_slSuggestions.Add(s);
            }
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            try
            {
                int index = e.Index;
                if (index > -1)
                {
                    int num2 = 0;
                    int num3 = 0;
                    DataRow row = this.m_dvView[index].Row;
                    e.DrawBackground();
                    for (int i = 0; i < this.m_Cols.Count; i++)
                    {
                        if (this.m_Cols[i].Display)
                        {
                            e.Graphics.DrawString(row[i].ToString(), this.Font, new SolidBrush(e.ForeColor), new RectangleF((float) num2, (float) e.Bounds.Y, (float) this.m_Cols[i].CalculatedWidth, (float) base.ItemHeight));
                            num2 += this.m_Cols[i].CalculatedWidth - 4;
                        }
                    }
                    num2 = 0;
                    num3 += base.ItemHeight;
                    e.DrawFocusRectangle();
                    base.OnDrawItem(e);
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message + "\r\nIn ColumnComboBox.OnDrawItem(DrawItemEventArgs).");
            }
        }

        protected override void OnDropDown(EventArgs e)
        {
            try
            {
                if (this.m_bInitItems)
                {
                    this.InitItems();
                }
                if (this.m_bInitDisplay)
                {
                    this.InitDisplay();
                }
                base.OnDropDown(e);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message + "\r\nIn ColumnComboBox.OnDropDown(EventArgs).");
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            try
            {
                if (this.m_bInitSuggestionList)
                {
                    this.InitSuggestionList();
                }
                base.OnKeyDown(e);
                this.m_kcLastKey = e.KeyCode;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message + "\r\nIn ColumnComboBox.OnKeyDown(KeyEventArgs).");
            }
        }

        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            try
            {
                this.m_iSelectedIndex = base.SelectedIndex;
                if (this.m_iSelectedIndex > -1)
                {
                    base.OnSelectedIndexChanged(e);
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message + "\r\nIn ColumnComboBox.OnSelectedIndexChanged(EventArgs).");
            }
        }

        protected override void OnTextChanged(EventArgs e)
        {
        }

        public void SetText(string sText)
        {
            for (int i = 0; i < base.Items.Count; i++)
            {
                if (this.Data.Rows[i][this.ViewColumn].ToString() == sText)
                {
                    base.SelectedIndex = i;
                    return;
                }
            }
            base.SelectedIndex = -1;
        }

        public int SetToIndexOf(string sText)
        {
            int num2;
            try
            {
                int num = 0;
                num = 0;
                while (num < this.m_slSuggestions.Count)
                {
                    if (this.m_slSuggestions[num].ToUpper() == sText)
                    {
                        break;
                    }
                    num++;
                }
                if (num >= this.m_slSuggestions.Count)
                {
                    num = -1;
                }
                this.m_iSelectedIndex = num;
                this.SelectedIndex = num;
                base.OnSelectedIndexChanged(new EventArgs());
                num2 = num;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message + "\r\nIn ColumnComboBox.SetToIndexOf(string).");
            }
            return num2;
        }

        public void SortBy(string sCol, JTG.SortOrder so)
        {
            this.m_dvView.Sort = sCol + " " + so.ToString();
            this.m_bInitItems = true;
        }

        public void UpdateIndex()
        {
            try
            {
                if (this.m_bInitItems)
                {
                    this.InitItems();
                }
                if (this.m_bInitSuggestionList)
                {
                    this.InitSuggestionList();
                }
                string text = this.Text;
                int num = 0;
                num = 0;
                while (num < this.m_dvView.Count)
                {
                    if (this.m_dvView[num][this.ViewColumn].ToString() == text)
                    {
                        if (this.SelectedIndex != num)
                        {
                            this.m_bTextChangedInternal = true;
                            this.m_iSelectedIndex = num;
                            this.SelectedIndex = num;
                            base.OnSelectedIndexChanged(new EventArgs());
                            this.m_bTextChangedInternal = false;
                        }
                        break;
                    }
                    num++;
                }
                if (num >= this.m_dvView.Count)
                {
                    this.m_bTextChangedInternal = true;
                    this.m_iSelectedIndex = -1;
                    this.SelectedIndex = -1;
                    base.OnSelectedIndexChanged(new EventArgs());
                    this.m_bTextChangedInternal = false;
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message + "\r\nIn ColumnComboBox.UpdateIndex().");
            }
        }

        public CCBColumnCollection Columns
        {
            get
            {
                if (this.m_bInitItems)
                {
                    this.InitItems();
                }
                if (this.m_bInitDisplay)
                {
                    this.InitDisplay();
                }
                return this.m_Cols;
            }
        }

        public DataTable Data
        {
            get
            {
                return this.m_dtData;
            }
            set
            {
                if (value == null)
                {
                    throw new Exception("Data cannot be set to null.\r\n ColumnComboBox.Data (set)");
                }
                this.m_dtData = value;
                this.m_dvView = new DataView(this.m_dtData);
                this.m_bInitItems = true;
                this.m_bInitSuggestionList = true;
                base.Invalidate();
            }
        }

        public object this[string sCol]
        {
            get
            {
                object obj3;
                try
                {
                    if (this.m_iSelectedIndex < 0)
                    {
                        return null;
                    }
                    obj3 = this.Data.Rows[this.m_iSelectedIndex][sCol];
                }
                catch (Exception exception)
                {
                    throw new Exception(exception.Message + "\r\nIn ColumnComboBox[string](get).");
                }
                return obj3;
            }
            set
            {
                try
                {
                    this.Data.Rows[this.SelectedIndex][sCol] = value;
                }
                catch (Exception exception)
                {
                    throw new Exception(exception.Message + "\r\nIn ColumnComboBox[string](set).");
                }
            }
        }

        //public DataView Items
        //{
        //    get
        //    {
        //        return this.m_dvView;
        //    }
        //}

        //public bool Sorted
        //{
        //    get
        //    {
        //        return false;
        //    }
        //}

        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                if (base.Text != value)
                {
                    base.Text = value;
                }
            }
        }

        public int ViewColumn
        {
            get
            {
                return this.m_iViewColumn;
            }
            set
            {
                if (value < 0)
                {
                    throw new Exception("ViewColumn must be greater than zero\r\n(set)ColumnComboBox.ViewColumn");
                }
                this.m_iViewColumn = value;
                this.m_bInitItems = true;
                this.m_bInitDisplay = true;
                this.m_bInitSuggestionList = true;
            }
        }
    }
}

