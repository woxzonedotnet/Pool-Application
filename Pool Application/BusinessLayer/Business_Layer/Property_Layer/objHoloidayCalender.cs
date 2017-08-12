namespace Business_Layer.Property_Layer
{
    using System;

    public class objHoloidayCalender
    {
        private string _DayRemarks;
        private string _DayType;
        private string _LocationCode;
        private DateTime _WorkingDate;

        public string DayRemarks
        {
            get
            {
                return this._DayRemarks;
            }
            set
            {
                this._DayRemarks = value;
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

