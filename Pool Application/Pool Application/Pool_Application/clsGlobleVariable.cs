namespace Pool_Application
{
    using System;
    using System.Drawing;
    using System.Net;
    using System.Windows.Forms;

    public class clsGlobleVariable
    {
        private static string _AccountCode = "";
        private static string _ActiveStatusCode = "A";
        private static string _Address_1 = "";
        private static string _Address_2 = "";
        private static string _Address_3 = "";
        private static string _BrowsDataValue = "";
        private static int _CloseKeyValue = 0x7b;
        private static Image _CompanyLogo;
        private static string _CopyRight = "Copyright \x00a9 2008 WOXZONE (PVT) LTD";
        private static string _CurrentUserID;
        private static string _CustomerEmail = "";
        private static string _CustomerFAX = "";
        private static string _CustomerName = "Rainbow Swimming Acadamy";
        private static string _CustomerTel = "";
        private static string _CustomerWeb = "";
        private static string _DeleteData = " record was Deleted ";
        private static string _DeleteSucessMessage = "Successfully deleted.....";
        private static string _InsertData = "Entered new ";
        private static string _LocationCode = "0001";
        private static string _MachineID = Dns.GetHostName();
        private static string _MainAccountCode = "";
        private static string _RefreshData = " details were Cleared ";
        private static int _RefreshKeyValue = 0x71;
        private static int _RemoveKeyValue = 0x77;
        private static string _SavedMessage = "Successfully saved.....";
        private static int _SaveKeyValue = 0x73;
        private static string _strImagePath = (Application.StartupPath.ToString() + @"\StudentPhotos");
        private static string _strProducName = "WSS POOL SYSTEM";
        private static string _strXMLFilePath = (Application.StartupPath.ToString() + @"\DatFiles");
        private static string _SubnAccountCode = "";
        private static string _SystemDateFormat = "dd/MM/yyyy";
        private static string _UpdateData = " record was Updated ";
        private static int _UpdateKeyValue = 0x72;
        private static string _UpdateMessage = "Successfully Uadated.....";
        private static string _ViewData = "View the details of ";
        private static int _ViewKeyValue = 0x74;

        public string AccountCode
        {
            get
            {
                return _AccountCode;
            }
            set
            {
                _AccountCode = value;
            }
        }

        public string ActiveStatusCode
        {
            get
            {
                return _ActiveStatusCode;
            }
            set
            {
                _ActiveStatusCode = value;
            }
        }

        public string Address_1
        {
            get
            {
                return _Address_1;
            }
            set
            {
                _Address_1 = value;
            }
        }

        public string Address_2
        {
            get
            {
                return _Address_2;
            }
            set
            {
                _Address_2 = value;
            }
        }

        public string Address_3
        {
            get
            {
                return _Address_3;
            }
            set
            {
                _Address_3 = value;
            }
        }

        public string BrowsDataValue
        {
            get
            {
                return _BrowsDataValue;
            }
            set
            {
                _BrowsDataValue = value;
            }
        }

        public int CloseKeyValue
        {
            get
            {
                return _CloseKeyValue;
            }
            set
            {
                _CloseKeyValue = value;
            }
        }

        public Image CompanyLogo
        {
            get
            {
                return _CompanyLogo;
            }
            set
            {
                _CompanyLogo = value;
            }
        }

        public string CopyRight
        {
            get
            {
                return _CopyRight;
            }
            set
            {
                _CopyRight = value;
            }
        }

        public string CurrentUserID
        {
            get
            {
                return _CurrentUserID;
            }
            set
            {
                _CurrentUserID = value;
            }
        }

        public string CustomerEmail
        {
            get
            {
                return _CustomerEmail;
            }
            set
            {
                _CustomerEmail = value;
            }
        }

        public string CustomerFAX
        {
            get
            {
                return _CustomerFAX;
            }
            set
            {
                _CustomerFAX = value;
            }
        }

        public string CustomerName
        {
            get
            {
                return _CustomerName;
            }
            set
            {
                _CustomerName = value;
            }
        }

        public string CustomerTel
        {
            get
            {
                return _CustomerTel;
            }
            set
            {
                _CustomerTel = value;
            }
        }

        public string CustomerWeb
        {
            get
            {
                return _CustomerWeb;
            }
            set
            {
                _CustomerWeb = value;
            }
        }

        public static string DeleteData
        {
            get
            {
                return _DeleteData;
            }
            set
            {
                _DeleteData = value;
            }
        }

        public string DeleteSucessMessage
        {
            get
            {
                return _DeleteSucessMessage;
            }
            set
            {
                _DeleteSucessMessage = value;
            }
        }

        public static string InsertData
        {
            get
            {
                return _InsertData;
            }
            set
            {
                _InsertData = value;
            }
        }

        public string LocationCode
        {
            get
            {
                return _LocationCode;
            }
            set
            {
                _LocationCode = value;
            }
        }

        public static string MachineID
        {
            get
            {
                return _MachineID;
            }
            set
            {
                _MachineID = value;
            }
        }

        public string MainAccountCode
        {
            get
            {
                return _MainAccountCode;
            }
            set
            {
                _MainAccountCode = value;
            }
        }

        public string ProducName
        {
            get
            {
                return _strProducName;
            }
            set
            {
                _strProducName = value;
            }
        }

        public static string RefreshData
        {
            get
            {
                return _RefreshData;
            }
            set
            {
                _RefreshData = value;
            }
        }

        public int RefreshKeyValue
        {
            get
            {
                return _RefreshKeyValue;
            }
            set
            {
                _RefreshKeyValue = value;
            }
        }

        public int RemoveKeyValue
        {
            get
            {
                return _RemoveKeyValue;
            }
            set
            {
                _RemoveKeyValue = value;
            }
        }

        public int SaveKeyValue
        {
            get
            {
                return _SaveKeyValue;
            }
            set
            {
                _SaveKeyValue = value;
            }
        }

        public string SeavedMessage
        {
            get
            {
                return _SavedMessage;
            }
            set
            {
                _SavedMessage = value;
            }
        }

        public string strImagePath
        {
            get
            {
                return _strImagePath;
            }
            set
            {
                _strImagePath = value;
            }
        }

        public string SubnAccountCode
        {
            get
            {
                return _SubnAccountCode;
            }
            set
            {
                _SubnAccountCode = value;
            }
        }

        public string SystemDateFormat
        {
            get
            {
                return _SystemDateFormat;
            }
            set
            {
                _SystemDateFormat = value;
            }
        }

        public static string UpdateData
        {
            get
            {
                return _UpdateData;
            }
            set
            {
                _UpdateData = value;
            }
        }

        public int UpdateKeyValue
        {
            get
            {
                return _UpdateKeyValue;
            }
            set
            {
                _UpdateKeyValue = value;
            }
        }

        public string UpdateMessage
        {
            get
            {
                return _UpdateMessage;
            }
            set
            {
                _UpdateMessage = value;
            }
        }

        public static string ViewData
        {
            get
            {
                return _ViewData;
            }
            set
            {
                _ViewData = value;
            }
        }

        public int ViewKeyValue
        {
            get
            {
                return _ViewKeyValue;
            }
            set
            {
                _ViewKeyValue = value;
            }
        }

        public string XMLPath
        {
            get
            {
                return _strXMLFilePath;
            }
            set
            {
                _strXMLFilePath = value;
            }
        }
    }
}

