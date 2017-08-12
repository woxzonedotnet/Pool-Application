namespace Business_Layer.Property_Layer
{
    using System;

    public class objClassTimeTable
    {
        private string _ClassCode;
        private string _ClassTimeCode;
        private string _DayType;
        private string _InTime;
        private string _LocationCode;
        private string _OutTime;
        private string _Session;
        private string _Status;

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

        public string ClassTimeCode
        {
            get
            {
                return this._ClassTimeCode;
            }
            set
            {
                this._ClassTimeCode = value;
            }
        }

        public string DayType
        {
            get
            {
                return this._DayType;
            }
            set
            {
                this._DayType = value;
            }
        }

        public string InTime
        {
            get
            {
                return this._InTime;
            }
            set
            {
                this._InTime = value;
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

        public string OutTime
        {
            get
            {
                return this._OutTime;
            }
            set
            {
                this._OutTime = value;
            }
        }

        public string Session
        {
            get
            {
                return this._Session;
            }
            set
            {
                this._Session = value;
            }
        }

        public string Status
        {
            get
            {
                return this._Status;
            }
            set
            {
                this._Status = value;
            }
        }
    }
}

