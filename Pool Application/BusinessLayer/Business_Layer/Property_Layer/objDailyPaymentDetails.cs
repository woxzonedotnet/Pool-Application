namespace Business_Layer.Property_Layer
{
    using System;

    public class objDailyPaymentDetails
    {
        private double _InvoiceAmount;
        private DateTime _InvoiceDate;
        private string _InvoiceNo;
        private string _InvoiceStatus;
        private string _LevelCode;
        private string _StudentName;
        private string _UserCode;

        public double InvoiceAmount
        {
            get
            {
                return this._InvoiceAmount;
            }
            set
            {
                this._InvoiceAmount = value;
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

        public string LevelCode
        {
            get
            {
                return this._LevelCode;
            }
            set
            {
                this._LevelCode = value;
            }
        }

        public string StudentName
        {
            get
            {
                return this._StudentName;
            }
            set
            {
                this._StudentName = value;
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

