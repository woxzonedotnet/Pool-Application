namespace JTG
{
    using System;

    public class CCBColumnEventArgs : EventArgs
    {
        public CCBColumn Column;

        public CCBColumnEventArgs(CCBColumn col)
        {
            this.Column = col;
        }
    }
}

