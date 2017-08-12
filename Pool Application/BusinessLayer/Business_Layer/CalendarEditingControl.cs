namespace Business_Layer
{
    using System;
    using System.Windows.Forms;

    public class CalendarEditingControl : DateTimePicker, IDataGridViewEditingControl
    {
        private DataGridView dataGridView;
        private int rowIndex;
        private bool valueChanged = false;

        public CalendarEditingControl()
        {
            base.Format = DateTimePickerFormat.Time;
            base.ShowUpDown = true;
        }

        public void ApplyCellStyleToEditingControl(DataGridViewCellStyle dataGridViewCellStyle)
        {
            this.Font = dataGridViewCellStyle.Font;
            base.CalendarForeColor = dataGridViewCellStyle.ForeColor;
            base.CalendarMonthBackground = dataGridViewCellStyle.BackColor;
        }

        public bool EditingControlWantsInputKey(Keys key, bool dataGridViewWantsInputKey)
        {
            switch ((key & Keys.KeyCode))
            {
                case Keys.PageUp:
                case Keys.Next:
                case Keys.End:
                case Keys.Home:
                case Keys.Left:
                case Keys.Up:
                case Keys.Right:
                case Keys.Down:
                    return true;
            }
            return false;
        }

        public object GetEditingControlFormattedValue(DataGridViewDataErrorContexts context)
        {
            return this.EditingControlFormattedValue;
        }

        protected override void OnValueChanged(EventArgs eventargs)
        {
            this.valueChanged = true;
            this.EditingControlDataGridView.NotifyCurrentCellDirty(true);
            base.OnValueChanged(eventargs);
        }

        public void PrepareEditingControlForEdit(bool selectAll)
        {
        }

        public DataGridView EditingControlDataGridView
        {
            get
            {
                return this.dataGridView;
            }
            set
            {
                this.dataGridView = value;
            }
        }

        public object EditingControlFormattedValue
        {
            get
            {
                return base.Value.ToLongTimeString();
            }
            set
            {
                if (value is string)
                {
                    base.Value = DateTime.Parse((string) value);
                }
            }
        }

        public int EditingControlRowIndex
        {
            get
            {
                return this.rowIndex;
            }
            set
            {
                this.rowIndex = value;
            }
        }

        public bool EditingControlValueChanged
        {
            get
            {
                return this.valueChanged;
            }
            set
            {
                this.valueChanged = value;
            }
        }

        public Cursor EditingPanelCursor
        {
            get
            {
                return base.Cursor;
            }
        }

        public bool RepositionEditingControlOnValueChange
        {
            get
            {
                return false;
            }
        }
    }
}

