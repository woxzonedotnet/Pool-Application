namespace Business_Layer.Property_Layer
{
    using System;

    public class objAttendanceProcess
    {
        private DateTime _AttendanceDate;
        private string _ClassCode;
        private string _DaySession;
        private string _DayType;
        private string _LocationCode;
        private string _StudentNo;

        public DateTime AttendanceDate
        {
            get
            {
                return this._AttendanceDate;
            }
            set
            {
                this._AttendanceDate = value;
            }
        }

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

        public string DaySession
        {
            get
            {
                return this._DaySession;
            }
            set
            {
                this._DaySession = value;
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

        public string StudentNo
        {
            get
            {
                return this._StudentNo;
            }
            set
            {
                this._StudentNo = value;
            }
        }
    }
}

