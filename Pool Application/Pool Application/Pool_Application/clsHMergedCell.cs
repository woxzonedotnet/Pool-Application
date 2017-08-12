namespace Pool_Application
{
    using System;
    using System.Diagnostics;
    using System.Drawing;
    using System.Windows.Forms;

    public class clsHMergedCell : DataGridViewTextBoxCell
    {
        private int m_nLeftColumn = 0;
        private int m_nRightColumn = 0;

        protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates cellState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
        {
            try
            {
                int num2;
                int num = base.ColumnIndex - this.m_nLeftColumn;
                Pen pen = new Pen(Brushes.Black);
                graphics.FillRectangle(new SolidBrush(SystemColors.Control), cellBounds);
                graphics.DrawLine(new Pen(new SolidBrush(SystemColors.ControlDark)), cellBounds.Left, cellBounds.Bottom - 1, cellBounds.Right, cellBounds.Bottom - 1);
                if (base.ColumnIndex == this.m_nRightColumn)
                {
                    graphics.DrawLine(new Pen(new SolidBrush(SystemColors.ControlDark)), cellBounds.Right - 1, cellBounds.Top, cellBounds.Right - 1, cellBounds.Bottom);
                }
                RectangleF empty = RectangleF.Empty;
                StringFormat format = new StringFormat {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center,
                    Trimming = StringTrimming.EllipsisCharacter
                };
                int num3 = 0;
                for (num2 = this.m_nLeftColumn; num2 <= this.m_nRightColumn; num2++)
                {
                    num3 += base.OwningRow.Cells[num2].Size.Width;
                }
                int num4 = 0;
                for (num2 = this.m_nLeftColumn; num2 < base.ColumnIndex; num2++)
                {
                    num4 += base.OwningRow.Cells[num2].Size.Width;
                }
                string s = base.OwningRow.Cells[this.m_nLeftColumn].Value.ToString();
                empty = new RectangleF((float) (cellBounds.Left - num4), (float) cellBounds.Top, (float) num3, (float) cellBounds.Height);
                graphics.DrawString(s, new Font("Arial", 10f, FontStyle.Regular), Brushes.Black, empty, format);
            }
            catch (Exception exception)
            {
                Trace.WriteLine(exception.ToString());
            }
        }

        public int LeftColumn
        {
            get
            {
                return this.m_nLeftColumn;
            }
            set
            {
                this.m_nLeftColumn = value;
            }
        }

        public int RightColumn
        {
            get
            {
                return this.m_nRightColumn;
            }
            set
            {
                this.m_nRightColumn = value;
            }
        }
    }
}

