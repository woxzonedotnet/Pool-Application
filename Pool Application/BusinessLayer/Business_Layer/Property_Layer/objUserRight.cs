namespace Business_Layer.Property_Layer
{
    using System;

    public class objUserRight
    {
        private string _LocationCode;
        private string _MenuName;
        private string _MenuType;
        private string _UserCode;
        private string _UserRight;

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

        public string MenuName
        {
            get
            {
                return this._MenuName;
            }
            set
            {
                this._MenuName = value;
            }
        }

        public string MenuType
        {
            get
            {
                return this._MenuType;
            }
            set
            {
                this._MenuType = value;
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

        public string UserRight
        {
            get
            {
                return this._UserRight;
            }
            set
            {
                this._UserRight = value;
            }
        }
    }
}

