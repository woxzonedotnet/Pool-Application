namespace Business_Layer.Property_Layer
{
    using System;

    public class objPaymentDeatils
    {
        private bool _IsPaymentExist;
        private string _LocationCode;
        private double _PenaltyPayAmount;
        private string _PenaltyPayMethodCode;
        private double _StudentDicount;
        private string _StudentNo;
        private string _StudentPayMethodCode;

        public bool IsPaymentExist
        {
            get
            {
                return this._IsPaymentExist;
            }
            set
            {
                this._IsPaymentExist = value;
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

        public double PenaltyPayAmount
        {
            get
            {
                return this._PenaltyPayAmount;
            }
            set
            {
                this._PenaltyPayAmount = value;
            }
        }

        public string PenaltyPayMethodCode
        {
            get
            {
                return this._PenaltyPayMethodCode;
            }
            set
            {
                this._PenaltyPayMethodCode = value;
            }
        }

        public double StudentDicount
        {
            get
            {
                return this._StudentDicount;
            }
            set
            {
                this._StudentDicount = value;
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

        public string StudentPayMethodCode
        {
            get
            {
                return this._StudentPayMethodCode;
            }
            set
            {
                this._StudentPayMethodCode = value;
            }
        }
    }
}

