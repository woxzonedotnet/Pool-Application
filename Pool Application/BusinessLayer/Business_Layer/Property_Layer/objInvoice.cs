namespace Business_Layer.Property_Layer
{
    using System;

    public class objInvoice
    {
        private double _Discount;
        private double _GrandTotal;
        private DateTime _InvoiceDate;
        private string _InvoiceNo;
        private string _InvoiceStatus;
        private bool _IsExistInvoice;
        private bool _IsTax;
        private string _LocationCode;
        private double _NBTAmount;
        private double _PanaltyAmount;
        private DateTime _PaymentFromDate;
        private DateTime _PaymentToDate;
        private string _StudentNo;
        private double _TotalItemAmount;
        private double _TotalTaxAmount;
        private string _UserCode;

        public double Discount
        {
            get
            {
                return this._Discount;
            }
            set
            {
                this._Discount = value;
            }
        }

        public double GrandTotal
        {
            get
            {
                return this._GrandTotal;
            }
            set
            {
                this._GrandTotal = value;
            }
        }

        public DateTime InvoiceDate
        {
            get
            {
                return this._InvoiceDate;
            }
            set
            {
                this._InvoiceDate = value;
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

        public string InvoiceStatus
        {
            get
            {
                return this._InvoiceStatus;
            }
            set
            {
                this._InvoiceStatus = value;
            }
        }

        public bool IsExistInvoice
        {
            get
            {
                return this._IsExistInvoice;
            }
            set
            {
                this._IsExistInvoice = value;
            }
        }

        public bool IsTax
        {
            get
            {
                return this._IsTax;
            }
            set
            {
                this._IsTax = value;
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

        public double NBTAmount
        {
            get
            {
                return this._NBTAmount;
            }
            set
            {
                this._NBTAmount = value;
            }
        }

        public double PanaltyAmount
        {
            get
            {
                return this._PanaltyAmount;
            }
            set
            {
                this._PanaltyAmount = value;
            }
        }

        public DateTime PaymentFromDate
        {
            get
            {
                return this._PaymentFromDate;
            }
            set
            {
                this._PaymentFromDate = value;
            }
        }

        public DateTime PaymentToDate
        {
            get
            {
                return this._PaymentToDate;
            }
            set
            {
                this._PaymentToDate = value;
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

        public double TotalItemAmount
        {
            get
            {
                return this._TotalItemAmount;
            }
            set
            {
                this._TotalItemAmount = value;
            }
        }

        public double TotalTaxAmount
        {
            get
            {
                return this._TotalTaxAmount;
            }
            set
            {
                this._TotalTaxAmount = value;
            }
        }

        public string UserCode
        {
            get
            {
                return this._UserCode;
            }
            set
            {
                this._UserCode = value;
            }
        }
    }
}

