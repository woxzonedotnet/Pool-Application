namespace Business_Layer.Property_Layer
{
    using System;

    public class objStudentPromotion
    {
        private string _ClassCode;
        private string _ClassTimeCode;
        private string _CurrentClassCode;
        private string _LocationCode;
        private string _PromoID;
        private DateTime _PromoteDate;
        private string _PromotedClassCode;
        private string _PromotedStatus;
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

        public string CurrentClassCode
        {
            get
            {
                return this._CurrentClassCode;
            }
            set
            {
                this._CurrentClassCode = value;
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

        public string PromoID
        {
            get
            {
                return this._PromoID;
            }
            set
            {
                this._PromoID = value;
            }
        }

        public DateTime PromoteDate
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

        public string PromotedClassCode
        {
            get
            {
                return this._PromotedClassCode;
            }
            set
            {
                this._PromotedClassCode = value;
            }
        }

        public string PromotedStatus
        {
            get
            {
                return this._PromotedStatus;
            }
            set
            {
                this._PromotedStatus = value;
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

