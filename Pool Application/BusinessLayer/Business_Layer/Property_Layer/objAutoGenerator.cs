namespace Business_Layer.Property_Layer
{
    using System;

    public class objAutoGenerator
    {
        private int _AutoNumber;
        private string _AutoNumberDescription;
        private bool _IsExistNumber;
        private string _LocationCode;

        public int AutoNumber
        {
            get
            {
                return this._AutoNumber;
            }
            set
            {
                this._AutoNumber = value;
            }
        }

        public string AutoNumberDescription
        {
            get
            {
                return this._AutoNumberDescription;
            }
            set
            {
                this._AutoNumberDescription = value;
            }
        }

        public bool IsExistNumber
        {
            get
            {
                return this._IsExistNumber;
            }
            set
            {
                this._IsExistNumber = value;
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
    }
}

