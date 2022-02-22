using System;
using Xamarin.Forms;

namespace XFCMAPP.Service
{
    public class RapidProContainer
    {
        #region Global Variable Declaration

        private const string RapidProFcmTokenKey = "RapidProFcmToken";
        private const string RapidProUrnKey = "RapidProUrn";
        private const string RapidProFromKey = "RapidProFrom";
        private const string RapidProStartMsgKey = "RapidProStartMsg";
        private const string RapidProLastMsgKey = "RapidProLastMsg";

        #endregion

        #region Constructor

        #endregion

        #region Actions

        public string RapidProFcmToken
        {
            get
            {
                return Application.Current.Properties.ContainsKey(RapidProFcmTokenKey) ? Application.Current.Properties[RapidProFcmTokenKey].ToString() : null;
            }
            set
            {
                if (Application.Current.Properties != null)
                {
                    Application.Current.Properties[RapidProFcmTokenKey] = value;
                    Application.Current.SavePropertiesAsync();
                }
            }
        }

        public string RapidProUrn
        {
            get
            {
                return Application.Current.Properties.ContainsKey(RapidProUrnKey) ? Application.Current.Properties[RapidProUrnKey].ToString() : null;
            }
            set
            {
                if (Application.Current.Properties != null)
                {
                    Application.Current.Properties[RapidProUrnKey] = value;
                    Application.Current.SavePropertiesAsync();
                }
            }
        }

        public string RapidProFrom
        {
            get
            {
                return Application.Current.Properties.ContainsKey(RapidProFromKey) ? Application.Current.Properties[RapidProFromKey].ToString() : null;
            }
            set
            {
                if (Application.Current.Properties != null)
                {
                    Application.Current.Properties[RapidProFromKey] = value;
                    Application.Current.SavePropertiesAsync();
                }
            }
        }

        public string RapidProStartMsg
        {
            get
            {
                return Application.Current.Properties.ContainsKey(RapidProStartMsgKey) ? Application.Current.Properties[RapidProStartMsgKey].ToString() : null;
            }
            set
            {
                if (Application.Current.Properties != null)
                {
                    Application.Current.Properties[RapidProStartMsgKey] = value;
                    Application.Current.SavePropertiesAsync();
                }
            }
        }

        public string RapidProLastMsg
        {
            get
            {
                return Application.Current.Properties.ContainsKey(RapidProLastMsgKey) ? Application.Current.Properties[RapidProLastMsgKey].ToString() : null;
            }
            set
            {
                if (Application.Current.Properties != null)
                {
                    Application.Current.Properties[RapidProLastMsgKey] = value;
                    Application.Current.SavePropertiesAsync();
                }
            }
        }

        public void ClearRapidProContainer()
        {
            Application.Current.Properties.Clear();
            Application.Current.SavePropertiesAsync();
        }

        #endregion
    }
}
