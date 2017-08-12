namespace Business_Layer.Property_Layer
{
    using System;

    public class objReadBarcodeCoacher
    {
        private string _CoacherCode;
        private bool _IsExist;
        private string _LocationCode;
        private DateTime _LogDate;
        private DateTime _LogTime;

        public string CoacherCode
        {
            get
            {
                return this._CoacherCode;
            }
            set
            {
                this._CoacherCode = value;
            }
        }

        public bool IsExist
        {
            get
            {
                return this._IsExist;
            }
            set
            {
                this._IsExist = value;
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

        public DateTime LogDate
        {
            get
            {
                return this._LogDate;
            }
            set
            {
                this._LogDate = value;
            }
        }

        public DateTime LogTime
        {
            get
            {
                return this._LogTime;
            }
            set
            {
                this._LogTime = value;
            }
        }
    }
}

