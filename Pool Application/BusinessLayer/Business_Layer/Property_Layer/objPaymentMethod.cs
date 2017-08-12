namespace Business_Layer.Property_Layer
{
    using System;

    public class objPaymentMethod
    {
        private bool _IxExist;
        private string _LocationCode;
        private string _PaymentCode;
        private double _PaymentDays;
        private string _PaymentDescription;

        public bool IxExist
        {
            get
            {
                return this._IxExist;
            }
            set
            {
                this._IxExist = value;
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

        public string PaymentCode
        {
            get
            {
                return this._PaymentCode;
            }
            set
            {
                this._PaymentCode = value;
            }
        }

        public double PaymentDays
        {
            get
            {
                return this._PaymentDays;
            }
            set
            {
                this._PaymentDays = value;
            }
        }

        public string PaymentDescription
        {
            get
            {
                return this._PaymentDescription;
            }
            set
            {
                this._PaymentDescription = value;
            }
        }
    }
}

