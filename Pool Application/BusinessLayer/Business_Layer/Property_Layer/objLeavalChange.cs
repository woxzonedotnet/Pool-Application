namespace Business_Layer.Property_Layer
{
    using System;

    public class objLeavalChange
    {
        private string _ClassCode;
        private string _LocationCode;
        private DateTime _PromotedDate;
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

        public DateTime PromotedDate
        {
            get
            {
                return this._PromotedDate;
            }
            set
            {
                this._PromotedDate = value;
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

