namespace Business_Layer.Property_Layer
{
    using System;

    public class objBluedGroupMaster
    {
        private string _BluedGroup;
        private string _BluedGroupCode;
        private bool _BluedGroupIsExist;

        public string BluedGroup
        {
            get
            {
                return this._BluedGroup;
            }
            set
            {
                this._BluedGroup = value;
            }
        }

        public string BluedGroupCode
        {
            get
            {
                return this._BluedGroupCode;
            }
            set
            {
                this._BluedGroupCode = value;
            }
        }

        public bool BluedGroupIsExist
        {
            get
            {
                return this._BluedGroupIsExist;
            }
            set
            {
                this._BluedGroupIsExist = value;
            }
        }
    }
}

