namespace JTG
{
    using System;
    using System.Collections;
    using System.Reflection;
    using System.Runtime.CompilerServices;

    public class CCBColumnCollection : IEnumerator, IEnumerable
    {
        private bool m_bFireEvents = true;
        private CCBColumn[] m_DOA = new CCBColumn[0x10];
        private int m_iCount = 0;
        private int m_iEnumeratorPos;
        private int m_iSize = 0x10;

        public event AddCCBColumnHandler AddColumnEvent;

        public event RemoveCCBColumnHandler RemoveColumnEvent;

        public void Add(CCBColumn DO)
        {
            if (this.Contains(DO))
            {
                throw new Exception("Column collection already contains a column named \"" + DO.Name + "\"");
            }
            this.CheckGrow();
            this.m_DOA[this.m_iCount] = DO;
            this.m_iCount++;
            if ((this.AddColumnEvent != null) && this.m_bFireEvents)
            {
                CCBColumnCollectionEventArgs e = new CCBColumnCollectionEventArgs(this.m_iCount, DO);
                this.AddColumnEvent(this, e);
            }
        }

        public bool AddNoDuplicate(CCBColumn DO)
        {
            bool flag = true;
            if (this.Contains(DO))
            {
                this.Remove(DO);
                flag = false;
            }
            this.Add(DO);
            return flag;
        }

        private void CheckGrow()
        {
            if (this.m_iCount >= this.m_iSize)
            {
                this.m_iSize *= 2;
                CCBColumn[] array = new CCBColumn[this.m_iSize];
                this.m_DOA.CopyTo(array, 0);
                this.m_DOA = array;
            }
        }

        public void Clear()
        {
            this.m_iSize = 0x10;
            this.m_iCount = 0;
            this.m_DOA = new CCBColumn[this.m_iSize];
        }

        public bool Contains(CCBColumn DO)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.m_DOA[i].Name == DO.Name)
                {
                    return true;
                }
            }
            return false;
        }

        public IEnumerator GetEnumerator()
        {
            this.m_iEnumeratorPos = -1;
            return this;
        }

        public void Insert(CCBColumn DO, int iPos)
        {
            this.CheckGrow();
            if (iPos < 0)
            {
                this.Insert(DO, 0);
            }
            if ((iPos >= this.m_iCount) && (iPos != 0))
            {
                this.Insert(DO, this.m_iCount - 1);
            }
            CCBColumn[] columnArray = new CCBColumn[this.m_iSize];
            int index = 0;
            while (index < iPos)
            {
                columnArray[index] = this.m_DOA[index];
                index++;
            }
            columnArray[index] = DO;
            while (index < this.m_iCount)
            {
                columnArray[index + 1] = this.m_DOA[index];
                index++;
            }
            this.m_DOA = columnArray;
            this.m_iCount++;
        }

        public void ItemAdded(object sender, CCBColumnCollectionEventArgs e)
        {
        }

        public bool MoveNext()
        {
            if (this.m_iEnumeratorPos >= (this.m_iCount - 1))
            {
                return false;
            }
            this.m_iEnumeratorPos++;
            return true;
        }

        public void MoveToFront(CCBColumn DO)
        {
            this.m_bFireEvents = false;
            this.Remove(DO);
            this.Insert(DO, 0);
            this.m_bFireEvents = true;
        }

        public void Remove(CCBColumn DO)
        {
            int index = 0;
            while (index < this.m_iCount)
            {
                if (this.m_DOA[index].Name == DO.Name)
                {
                    break;
                }
                index++;
            }
            if (index != this.m_iCount)
            {
                while (index < (this.m_iCount - 1))
                {
                    this.m_DOA[index] = this.m_DOA[index + 1];
                    index++;
                }
                this.m_iCount--;
                this.Remove(DO);
                if ((this.RemoveColumnEvent != null) && this.m_bFireEvents)
                {
                    CCBColumnCollectionEventArgs e = new CCBColumnCollectionEventArgs(this.m_iCount, DO);
                    this.RemoveColumnEvent(this, e);
                }
            }
        }

        public void RemoveAt(int index)
        {
            if ((index >= 0) && (index < this.m_iCount))
            {
                while (index < (this.m_iCount - 1))
                {
                    this.m_DOA[index] = this.m_DOA[index + 1];
                    index++;
                }
                this.m_iCount--;
            }
        }

        public void Reset()
        {
            this.m_iEnumeratorPos = -1;
        }

        public int Count
        {
            get
            {
                return this.m_iCount;
            }
        }

        public object Current
        {
            get
            {
                return this.m_DOA[this.m_iEnumeratorPos];
            }
        }

        public CCBColumn this[int index]
        {
            get
            {
                return this.m_DOA[index];
            }
        }

        public CCBColumn this[string sName]
        {
            get
            {
                for (int i = 0; i < this.m_iCount; i++)
                {
                    if (this.m_DOA[i].Name == sName)
                    {
                        return this.m_DOA[i];
                    }
                }
                throw new Exception("Column \"" + sName + "\" is not a valid column.");
            }
        }
    }
}

