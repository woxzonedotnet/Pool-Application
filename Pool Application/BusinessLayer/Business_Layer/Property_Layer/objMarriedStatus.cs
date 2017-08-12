namespace Business_Layer.Property_Layer
{
    using System;

    public class objMarriedStatus
    {
        private bool _MarridStatusIsExist;
        private string _MarriedStatus;
        private string _MarriedStatusCode;

        public bool MarridStatusIsExist
        {
            get
            {
                return this._MarridStatusIsExist;
            }
            set
            {
                this._MarridStatusIsExist = value;
            }
        }

        public string MarriedStatus
        {
            get
            {
                return this._MarriedStatus;
            }
            set
            {
                this._MarriedStatus = value;
            }
        }

        public string MarriedStatusCode
        {
            get
            {
                return this._MarriedStatusCode;
            }
            set
            {
                this._MarriedStatusCode = value;
            }
        }
    }
}

