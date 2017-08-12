namespace Business_Layer.Property_Layer
{
    using System;

    public class objReportMaster
    {
        private DateTime _AttFromDate;
        private DateTime _AttToDate;
        private string _ClassCode;
        private string _DaySession;
        private string _DayType;
        private string _LocationCode;
        private string _ReportID;
        private string _ReportName;
        private string _ReportTitle;
        private string _SelectedTable;
        private string _SelectionFormular;
        private string _StatusCode;

        public DateTime AttFromDate
        {
            get
            {
                return this._AttFromDate;
            }
            set
            {
                this._AttFromDate = value;
            }
        }

        public DateTime AttToDate
        {
            get
            {
                return this._AttToDate;
            }
            set
            {
                this._AttToDate = value;
            }
        }

        public string ClassCode
        {
            get
            {
                return this._ClassCode;
            }
            set
            {
                this._ClassCode = value;
            }
        }

        public string DaySession
        {
            get
            {
                return this._DaySession;
            }
            set
            {
                this._DaySession = value;
            }
        }

        public string DayType
        {
            get
            {
                return this._DayType;
            }
            set
            {
                this._DayType = value;
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

        public string ReportID
        {
            get
            {
                return this._ReportID;
            }
            set
            {
                this._ReportID = value;
            }
        }

        public string ReportName
        {
            get
            {
                return this._ReportName;
            }
            set
            {
                this._ReportName = value;
            }
        }

        public string ReportTitle
        {
            get
            {
                return this._ReportTitle;
            }
            set
            {
                this._ReportTitle = value;
            }
        }

        public string SelectedTable
        {
            get
            {
                return this._SelectedTable;
            }
            set
            {
                this._SelectedTable = value;
            }
        }

        public string SelectionFormular
        {
            get
            {
                return this._SelectionFormular;
            }
            set
            {
                this._SelectionFormular = value;
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
    }
}

