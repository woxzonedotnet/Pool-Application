namespace Business_Layer.Property_Layer
{
    using System;

    public class objMasterReport
    {
        private string _ActiveCode;
        private string _ClassCode;

        public string ActiveCode
        {
            get
            {
                return this._ActiveCode;
            }
            set
            {
                this._ActiveCode = value;
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
    }
}

