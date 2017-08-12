namespace Business_Layer.Property_Layer
{
    using System;

    public class objConfirmStudentAttendance
    {
        private DateTime _AbsentDate;
        private DateTime _AttendanceDate;
        private string _ClassCode;
        private string _ClassTimeCode;
        private bool _IsConfirmAttendance;
        private string _LocationCode;
        private string _StudentNo;

        public DateTime AbsentDate
        {
            get
            {
                return this._AbsentDate;
            }
            set
            {
                this._AbsentDate = value;
            }
        }

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

        public bool IsConfirmAttendance
        {
            get
            {
                return this._IsConfirmAttendance;
            }
            set
            {
                this._IsConfirmAttendance = value;
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

