namespace Business_Layer.Property_Layer
{
    using System;

    public class objDuePayStudent
    {
        private string _LocationCode;
        private DateTime _ProcessDate;
        private string _Status;

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

        public DateTime ProcessDate
        {
            get
            {
                return this._ProcessDate;
            }
            set
            {
                this._ProcessDate = value;
            }
        }

        public string Status
        {
            get
            {
                return this._Status;
            }
            set
            {
                this._Status = value;
            }
        }
    }
}

