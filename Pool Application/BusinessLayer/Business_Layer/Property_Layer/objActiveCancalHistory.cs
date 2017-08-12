namespace Business_Layer.Property_Layer
{
    using System;

    public class objActiveCancalHistory
    {
        private DateTime _ActiveDate;
        private bool _IsAciveCancel;
        private string _LocationCode;
        private string _Status;
        private string _StudentNo;

        public DateTime ActiveDate
        {
            get
            {
                return this._ActiveDate;
            }
            set
            {
                this._ActiveDate = value;
            }
        }

        public bool IsAciveCancel
        {
            get
            {
                return this._IsAciveCancel;
            }
            set
            {
                this._IsAciveCancel = value;
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

