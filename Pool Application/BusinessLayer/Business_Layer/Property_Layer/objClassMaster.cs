namespace Business_Layer.Property_Layer
{
    using System;

    public class objClassMaster
    {
        private string _ClassCode;
        private int _ClassCoverUpDays;
        private bool _ClassIsExist;
        private string _ClassName;
        private string _ClassStatus;
        private int _ClassTotalStudents;
        private string _LocationCode;

        public string ClassCode
        {
            get
            {
                return this._ClassCode;
            }
            set
            {
                this._ClassCode = value;
            }
        }

        public int ClassCoverUpDays
        {
            get
            {
                return this._ClassCoverUpDays;
            }
            set
            {
                this._ClassCoverUpDays = value;
            }
        }

        public bool ClassIsExist
        {
            get
            {
                return this._ClassIsExist;
            }
            set
            {
                this._ClassIsExist = value;
            }
        }

        public string ClassName
        {
            get
            {
                return this._ClassName;
            }
            set
            {
                this._ClassName = value;
            }
        }

        public string ClassStatus
        {
            get
            {
                return this._ClassStatus;
            }
            set
            {
                this._ClassStatus = value;
            }
        }

        public int ClassTotalStudents
        {
            get
            {
                return this._ClassTotalStudents;
            }
            set
            {
                this._ClassTotalStudents = value;
            }
        }

        public string LocationCode
        {
            get
            {
                return this._LocationCode;
            }
            set
            {
                this._LocationCode = value;
            }
        }
    }
}

