namespace Business_Layer.Property_Layer
{
    using System;

    public class objEmployeeWorkingDays
    {
        private string _DayType;
        private string _EmployeeCode;
        private string _LocationCode;
        private DateTime _WorkingDate;

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

        public string EmployeeCode
        {
            get
            {
                return this._EmployeeCode;
            }
            set
            {
                this._EmployeeCode = value;
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

        public DateTime WorkingDate
        {
            get
            {
                return this._WorkingDate;
            }
            set
            {
                this._WorkingDate = value;
            }
        }
    }
}

