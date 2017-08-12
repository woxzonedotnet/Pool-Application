namespace Business_Layer.Property_Layer
{
    using System;

    public class objInvoiceItemAmounts
    {
        private double _InvoiceItemAmount;
        private string _InvoiceItemCode;
        private string _InvoiceNo;
        private bool _IsExistInvoiceItem;
        private string _LocationCode;
        private string _StudentNo;

        public double InvoiceItemAmount
        {
            get
            {
                return this._InvoiceItemAmount;
            }
            set
            {
                this._InvoiceItemAmount = value;
            }
        }

        public string InvoiceItemCode
        {
            get
            {
                return this._InvoiceItemCode;
            }
            set
            {
                this._InvoiceItemCode = value;
            }
        }

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

        public bool IsExistInvoiceItem
        {
            get
            {
                return this._IsExistInvoiceItem;
            }
            set
            {
                this._IsExistInvoiceItem = value;
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

