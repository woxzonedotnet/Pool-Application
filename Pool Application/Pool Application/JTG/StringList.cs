namespace JTG
{
    using System;
    using System.Collections;
    using System.Reflection;

    public class StringList
    {
        private ArrayList m_alMain = new ArrayList();

        public int Add(string s)
        {
            this.m_alMain.Add(s);
            return this.m_alMain.Count;
        }

        public int AddNoDuplicate(string s)
        {
            if (this.m_alMain.IndexOf(s) == -1)
            {
                this.m_alMain.Add(s);
            }
            return this.m_alMain.Count;
        }

        public StringList AddRange(StringList sl)
        {
            this.m_alMain.AddRange(sl.m_alMain);
            return null;
        }

        public void Clear()
        {
            this.m_alMain.Clear();
        }

        ~StringList()
        {
            this.m_alMain.Clear();
        }

        public int IndexOf(string sFind)
        {
            return this.m_alMain.IndexOf(sFind);
        }

        public int Insert(int index, string s)
        {
            this.m_alMain.Insert(index, s);
            return this.m_alMain.Count;
        }

        public static implicit operator string[](StringList sl)
        {
            string[] strArray = new string[sl.m_alMain.Count];
            for (int i = 0; i < sl.m_alMain.Count; i++)
            {
                strArray[i] = (string) sl.m_alMain[i];
            }
            return strArray;
        }

        public static implicit operator StringList(object[] sa)
        {
            StringList list = new StringList();
            for (int i = 0; i < sa.Length; i++)
            {
                list.Add(sa[i].ToString());
            }
            return list;
        }

        public static implicit operator StringList(string[] sa)
        {
            StringList list = new StringList();
            for (int i = 0; i < sa.Length; i++)
            {
                list.Add(sa[i]);
            }
            return list;
        }

        public int Remove(string s)
        {
            this.m_alMain.Remove(s);
            return this.m_alMain.Count;
        }

        public int Replace(string sFind, string sReplace)
        {
            int index = this.m_alMain.IndexOf(sFind);
            if (index > -1)
            {
                this.m_alMain.RemoveAt(index);
                this.m_alMain.Insert(index, sReplace);
            }
            return this.m_alMain.Count;
        }

        public void Sort()
        {
            this.m_alMain.Sort();
        }

        public override string ToString()
        {
            string str = "";
            int num = 0;
            while (num < this.m_alMain.Count)
            {
                str = str + ((string) this.m_alMain[num++]) + "\n";
            }
            return str;
        }

        public string ToString(string sSeperator)
        {
            string str = "";
            int num = 0;
            while (num < this.m_alMain.Count)
            {
                str = str + ((string) this.m_alMain[num++]);
                if (num < this.m_alMain.Count)
                {
                    str = str + sSeperator;
                }
            }
            return str;
        }

        public int Count
        {
            get
            {
                return this.m_alMain.Count;
            }
        }

        public string this[int index]
        {
            get
            {
                return (string) this.m_alMain[index];
            }
            set
            {
                if (index >= this.m_alMain.Count)
                {
                    this.m_alMain.Add(value);
                }
                else
                {
                    this.m_alMain[index] = value;
                }
            }
        }
    }
}

