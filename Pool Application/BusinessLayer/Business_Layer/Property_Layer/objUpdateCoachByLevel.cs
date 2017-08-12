namespace Business_Layer.Property_Layer
{
    using System;

    public class objUpdateCoachByLevel
    {
        private string _AssCoacherCode;
        private DateTime _ChangedDate;
        private string _ChangedLeval;
        private string _CoacherCode;
        private string _DayType;
        private string _LocationCode;
        private bool _UpdateCoachByLevel;

        public string AssCoacherCode
        {
            get
            {
                return this._AssCoacherCode;
            }
            set
            {
                this._AssCoacherCode = value;
            }
        }

        public DateTime ChangedDate
        {
            get
            {
                return this._ChangedDate;
            }
            set
            {
                this._ChangedDate = value;
            }
        }

        public string ChangedLeval
        {
            get
            {
                return this._ChangedLeval;
            }
            set
            {
                this._ChangedLeval = value;
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

        public bool UpdateCoachByLevel
        {
            get
            {
                return this._UpdateCoachByLevel;
            }
            set
            {
                this._UpdateCoachByLevel = value;
            }
        }
    }
}

