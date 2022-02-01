using XFCMAPP.Utility;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Internals;
using Xamarin.Forms;

namespace XFCMAPP.Services
{
    public class RapidProService
    {
        #region RapidPro Container

        private const string RapidProFcmTokenKey = "RapidProFcmToken";
        private const string RapidProUrnKey = "RapidProUrn";
        private const string RapidProFromKey = "RapidProFrom";
        private const string RapidProStartMsgKey = "RapidProStartMsg";
        private const string RapidProLastMsgKey = "RapidProLastMsg";

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
                    if (!Application.Current.Properties.ContainsKey(RapidProFcmTokenKey))
                    {
                        Application.Current.Properties[RapidProFcmTokenKey] = value;
                        Application.Current.SavePropertiesAsync();
                    }
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
                    if (!Application.Current.Properties.ContainsKey(RapidProUrnKey))
                    {
                        Application.Current.Properties[RapidProUrnKey] = value;
                        Application.Current.SavePropertiesAsync();
                    }
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
                    if (!Application.Current.Properties.ContainsKey(RapidProFromKey))
                    {
                        Application.Current.Properties[RapidProFromKey] = value;
                        Application.Current.SavePropertiesAsync();
                    }
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
                    if (!Application.Current.Properties.ContainsKey(RapidProStartMsgKey))
                    {
                        Application.Current.Properties[RapidProStartMsgKey] = value;
                        Application.Current.SavePropertiesAsync();
                    }
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
                    if (!Application.Current.Properties.ContainsKey(RapidProLastMsgKey))
                    {
                        Application.Current.Properties[RapidProLastMsgKey] = value;
                        Application.Current.SavePropertiesAsync();
                    }
                }
            }
        }

        public void ClearChatContainer()
        {
            Application.Current.Properties.Clear();
            Application.Current.SavePropertiesAsync();
        }

        #endregion

        private HttpClient InitializeHttpClient()
        {
            var httpClient = new HttpClient();
            httpClient.MaxResponseContentBufferSize = 556000;
            return httpClient;
        }

        #region Rapid Pro Api Call

        public async Task<bool> RapidProRegister(string rapidProUrn, string rapidProFcmToken)
        {
            string contactUuid = string.Empty;
            try
            {
                var values = new Dictionary<string, string>
                {
                   { "urn", rapidProUrn + "" },
                   { "fcm_token", rapidProFcmToken}
                };
                var content = new FormUrlEncodedContent(values);

                var restUrl = AppConstant.RapidProFcmRegisterUrl + "?urn=" + rapidProUrn + "&fcm_token=" + rapidProFcmToken;
                var absoluteUrl = restUrl;

                using (var httpClient = InitializeHttpClient())
                {
                    var response = await httpClient.PostAsync(absoluteUrl, content);
                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        contactUuid = Convert.ToString(result);

                        return true;
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"RapidProService - RapidProRegister: Exception - {ex.Message.ToString()}");
            }

            return false;
        }

        public async Task<bool> RapidProReceive(string rapidProUrn, string rapidProFcmToken, string rapidProMsg)
        {
            string contactUuid = string.Empty;
            try
            {
                var values = new Dictionary<string, string>
                {
                   { "from", rapidProUrn + "" },
                   { "msg", rapidProMsg + "" },
                   { "fcm_token", rapidProFcmToken}
                };
                var content = new FormUrlEncodedContent(values);

                var restUrl = AppConstant.RapidProFcmRegisterUrl + "?from=fcm:" + rapidProUrn + "&msg=" + rapidProMsg + "&fcm_token=" + rapidProFcmToken;
                var absoluteUrl = restUrl;

                using (var httpClient = InitializeHttpClient())
                {
                    var response = await httpClient.PostAsync(absoluteUrl, content);
                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadAsStringAsync();

                        string patient = JsonConvert.DeserializeObject<string>(result);

                        return true;
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"RapidProService - RapidProReceive: Exception - {ex.Message.ToString()}");
            }

            return false;
        }

        #endregion
    }
}
