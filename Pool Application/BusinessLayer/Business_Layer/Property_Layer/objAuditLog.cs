namespace Business_Layer.Property_Layer
{
    using System;

    public class objAuditLog
    {
        private DateTime _DateEntered;
        private DateTime _FromDate;
        private string _LocationCode;
        private string _MachineID;
        private string _Task;
        private DateTime _TimeEntered;
        private DateTime _ToDate;
        private string _UserID;

        public DateTime DateEntered
        {
            get
            {
                return this._DateEntered;
            }
            set
            {
                this._DateEntered = value;
            }
        }

        public DateTime FromDate
        {
            get
            {
                return this._FromDate;
            }
            set
            {
                this._FromDate = value;
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

        public string MachineID
        {
            get
            {
                return this._MachineID;
            }
            set
            {
                this._MachineID = value;
            }
        }

        public string Task
        {
            get
            {
                return this._Task;
            }
            set
            {
                this._Task = value;
            }
        }

        public DateTime TimeEntered
        {
            get
            {
                return this._TimeEntered;
            }
            set
            {
                this._TimeEntered = value;
            }
        }

        public DateTime ToDate
        {
            get
            {
                return this._ToDate;
            }
            set
            {
                this._ToDate = value;
            }
        }

        public string UserID
        {
            get
            {
                return this._UserID;
            }
            set
            {
                this._UserID = value;
            }
        }
    }
}

