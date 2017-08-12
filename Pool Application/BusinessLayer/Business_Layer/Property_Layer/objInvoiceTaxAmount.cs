namespace Business_Layer.Property_Layer
{
    using System;

    public class objInvoiceTaxAmount
    {
        private string _InvoiceNo;
        private double _InvoiceTaxAmount;
        private string _InvoiceTaxCode;
        private bool _IsExistInvoiceTax;
        private string _LocationCode;
        private string _StudentNo;

        public string InvoiceNo
        {
            get
            {
                return this._InvoiceNo;
            }
            set
            {
                this._InvoiceNo = value;
            }
        }

        public double InvoiceTaxAmount
        {
            get
            {
                return this._InvoiceTaxAmount;
            }
            set
            {
                this._InvoiceTaxAmount = value;
            }
        }

        public string InvoiceTaxCode
        {
            get
            {
                return this._InvoiceTaxCode;
            }
            set
            {
                this._InvoiceTaxCode = value;
            }
        }

        public bool IsExistInvoiceTax
        {
            get
            {
                return this._IsExistInvoiceTax;
            }
            set
            {
                this._IsExistInvoiceTax = value;
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

