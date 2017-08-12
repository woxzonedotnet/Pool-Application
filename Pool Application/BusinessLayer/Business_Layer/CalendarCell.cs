namespace Business_Layer
{
    using System;
    using System.Windows.Forms;

    public class CalendarCell : DataGridViewTextBoxCell
    {
        public CalendarCell()
        {
            base.Style.Format = "t";
        }

        public override void InitializeEditingControl(int rowIndex, object initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);
            CalendarEditingControl editingControl = base.DataGridView.EditingControl as CalendarEditingControl;
        }

        public override System.Type EditType
        {
            get
            {
                return typeof(CalendarEditingControl);
            }
        }

        public override System.Type ValueType
        {
            get
            {
                return typeof(DateTime);
            }
        }
    }
}

