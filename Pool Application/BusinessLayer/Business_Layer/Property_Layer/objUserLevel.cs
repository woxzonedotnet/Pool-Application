namespace Business_Layer.Property_Layer
{
    using System;

    public class objUserLevel
    {
        private string _LocationCode;
        private string _UserLevel;
        private string _UserLevelCode;
        private bool _UserLevelIsExists;
        private string _UserLevelStatus;

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

        public string UserLevel
        {
            get
            {
                return this._UserLevel;
            }
            set
            {
                this._UserLevel = value;
            }
        }

        public string UserLevelCode
        {
            get
            {
                return this._UserLevelCode;
            }
            set
            {
                this._UserLevelCode = value;
            }
        }

        public bool UserLevelIsExists
        {
            get
            {
                return this._UserLevelIsExists;
            }
            set
            {
                this._UserLevelIsExists = value;
            }
        }

        public string UserLevelStatus
        {
            get
            {
                return this._UserLevelStatus;
            }
            set
            {
                this._UserLevelStatus = value;
            }
        }
    }
}

