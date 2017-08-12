namespace Business_Layer.Property_Layer
{
    using System;

    public class objAttendanceProcessCoacher
    {
        private DateTime _AttendanceDate;
        private string _CoacherCode;
        private string _LocationCode;

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

        public string CoacherCode
        {
            get
            {
                return this._CoacherCode;
            }
            set
            {
                this._CoacherCode = value;
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

