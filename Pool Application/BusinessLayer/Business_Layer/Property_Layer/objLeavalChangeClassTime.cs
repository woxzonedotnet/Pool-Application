namespace Business_Layer.Property_Layer
{
    using System;

    public class objLeavalChangeClassTime
    {
        private string _ClassCode;
        private string _LocationCode;
        private string _PreviousClassCode;
        private DateTime _PromoteDate;
        private string _StudentNo;

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

        public string PreviousClassCode
        {
            get
            {
                return this._PreviousClassCode;
            }
            set
            {
                this._PreviousClassCode = value;
            }
        }

        public DateTime PromotedDate
        {
            get
            {
                return this._PromoteDate;
            }
            set
            {
                this._PromoteDate = value;
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

