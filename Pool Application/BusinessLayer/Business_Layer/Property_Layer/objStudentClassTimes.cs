namespace Business_Layer.Property_Layer
{
    using System;

    public class objStudentClassTimes
    {
        private string _ClassCode;
        private string _ClassTimeCode;
        private string _LocationCode;
        private string _StudentNo;

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

        public string ClassTimeCode
        {
            get
            {
                return this._ClassTimeCode;
            }
            set
            {
                this._ClassTimeCode = value;
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

        public string StudentNo
        {
            get
            {
                return this._StudentNo;
            }
            set
            {
                this._StudentNo = value;
            }
        }
    }
}

