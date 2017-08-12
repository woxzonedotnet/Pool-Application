namespace Business_Layer.Property_Layer
{
    using System;

    public class objStatusMaster
    {
        private bool _IsExistStatus;
        private string _StatusCode;
        private string _StatusName;

        public bool IsExistStatus
        {
            get
            {
                return this._IsExistStatus;
            }
            set
            {
                this._IsExistStatus = value;
            }
        }

        public string StatusCode
        {
            get
            {
                return this._StatusCode;
            }
            set
            {
                this._StatusCode = value;
            }
        }

        public string StatusName
        {
            get
            {
                return this._StatusName;
            }
            set
            {
                this._StatusName = value;
            }
        }
    }
}

