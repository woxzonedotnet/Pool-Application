namespace JTG
{
    using System;
    using System.Runtime.CompilerServices;

    public class CCBColumn
    {
        public int CalculatedWidth;
        private bool m_Display;
        private string m_sName;
        public int Width;

        public event ChangeColumnDisplayHandler OnColumnDisplayChanged;

        public CCBColumn(string sName)
        {
            this.Width = -1;
            this.m_Display = true;
            this.CalculatedWidth = 0;
            this.m_sName = sName;
        }

        public CCBColumn(string sName, bool bDisplay)
        {
            this.Width = -1;
            this.m_Display = true;
            this.CalculatedWidth = 0;
            this.m_sName = sName;
            this.Display = bDisplay;
        }

        public CCBColumn(string sName, int iWidth)
        {
            this.Width = -1;
            this.m_Display = true;
            this.CalculatedWidth = 0;
            this.m_sName = sName;
            this.Width = iWidth;
        }

        public bool Display
        {
            get
            {
                return this.m_Display;
            }
            set
            {
                if (this.m_Display != value)
                {
                    this.m_Display = value;
                    if (this.OnColumnDisplayChanged != null)
                    {
                        this.OnColumnDisplayChanged(this, new CCBColumnEventArgs(this));
                    }
                }
            }
        }

        public string Name
        {
            get
            {
                return this.m_sName;
            }
            set
            {
                if (this.m_sName != value)
                {
                    this.m_sName = value;
                    if (this.OnColumnDisplayChanged != null)
                    {
                        this.OnColumnDisplayChanged(this, new CCBColumnEventArgs(this));
                    }
                }
            }
        }
    }
}

