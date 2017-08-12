namespace Business_Layer.Property_Layer
{
    using System;

    public class objCancelInvoice
    {
        private DateTime _InvCancelDate;
        private string _InvoiceNo;
        private string _LocationCode;
        private string _UserCode;

        public DateTime InvCancelDate
        {
            get
            {
                return this._InvCancelDate;
            }
            set
            {
                this._InvCancelDate = value;
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

