namespace Business_Layer.Property_Layer
{
    using System;

    public class objCompanyMaster
    {
        private string _CustomerAddNo;
        private string _CustomerAddRoad;
        private string _CustomerAddStreet;
        private string _CustomerEmail;
        private string _CustomerFax;
        private string _CustomerName;
        private string _CustomerTelNo;
        private string _CustomerWebSite;
        private bool _IsCompanyExist;

        public string CustomerAddNo
        {
            get
            {
                return this._CustomerAddNo;
            }
            set
            {
                this._CustomerAddNo = value;
            }
        }

        public string CustomerAddRoad
        {
            get
            {
                return this._CustomerAddRoad;
            }
            set
            {
                this._CustomerAddRoad = value;
            }
        }

        public string CustomerAddStreet
        {
            get
            {
                return this._CustomerAddStreet;
            }
            set
            {
                this._CustomerAddStreet = value;
            }
        }

        public string CustomerEmail
        {
            get
            {
                return this._CustomerEmail;
            }
            set
            {
                this._CustomerEmail = value;
            }
        }

        public string CustomerFax
        {
            get
            {
                return this._CustomerFax;
            }
            set
            {
                this._CustomerFax = value;
            }
        }

        public string CustomerName
        {
            get
            {
                return this._CustomerName;
            }
            set
            {
                this._CustomerName = value;
            }
        }

        public string CustomerTelNo
        {
            get
            {
                return this._CustomerTelNo;
            }
            set
            {
                this._CustomerTelNo = value;
            }
        }

        public string CustomerWebSite
        {
            get
            {
                return this._CustomerWebSite;
            }
            set
            {
                this._CustomerWebSite = value;
            }
        }

        public bool IsCompanyExist
        {
            get
            {
                return this._IsCompanyExist;
            }
            set
            {
                this._IsCompanyExist = value;
            }
        }
    }
}

