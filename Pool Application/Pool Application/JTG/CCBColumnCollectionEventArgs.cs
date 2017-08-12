namespace JTG
{
    using System;

    public class CCBColumnCollectionEventArgs : EventArgs
    {
        public int Count;
        public CCBColumn DO;

        public CCBColumnCollectionEventArgs(int count, CCBColumn dO)
        {
            this.Count = count;
            this.DO = dO;
        }
    }
}

