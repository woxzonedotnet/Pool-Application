namespace Business_Layer.Property_Layer
{
    using System;

    public class objUserMaster
    {
        private string _ConfirmPass;
        private string _LocationCode;
        private string _Password;
        private string _UserCode;
        private string _UserLevel;
        private bool _UserMasterExists;
        private string _UserMasterStatus;
        private string _UserName;

        public string ConfirmPass
        {
            get
            {
                return this._ConfirmPass;
            }
            set
            {
                this._ConfirmPass = value;
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

        public string Password
        {
            get
            {
                return this._Password;
            }
            set
            {
                this._Password = value;
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

        public bool UserMasterExists
        {
            get
            {
                return this._UserMasterExists;
            }
            set
            {
                this._UserMasterExists = value;
            }
        }

        public string UserMasterStatus
        {
            get
            {
                return this._UserMasterStatus;
            }
            set
            {
                this._UserMasterStatus = value;
            }
        }

        public string UserName
        {
            get
            {
                return this._UserName;
            }
            set
            {
                this._UserName = value;
            }
        }
    }
}

