namespace Business_Layer.Property_Layer
{
    using System;

    public class objTax
    {
        private bool _IsExcistTax;
        private bool _IsNBTAdded;
        private string _TaxCode;
        private string _TaxDescription;
        private double _TaxValue;

        public bool IsExcistTax
        {
            get
            {
                return this._IsExcistTax;
            }
            set
            {
                this._IsExcistTax = value;
            }
        }

        public bool IsNBTAdded
        {
            get
            {
                return this._IsNBTAdded;
            }
            set
            {
                this._IsNBTAdded = value;
            }
        }

        public string TaxCode
        {
            get
            {
                return this._TaxCode;
            }
            set
            {
                this._TaxCode = value;
            }
        }

        public string TaxDescription
        {
            get
            {
                return this._TaxDescription;
            }
            set
            {
                this._TaxDescription = value;
            }
        }

        public double TaxValue
        {
            get
            {
                return this._TaxValue;
            }
            set
            {
                this._TaxValue = value;
            }
        }
    }
}

