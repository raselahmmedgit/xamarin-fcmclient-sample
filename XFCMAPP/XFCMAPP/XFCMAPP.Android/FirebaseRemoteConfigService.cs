using Firebase.RemoteConfig;
using System;
using System.Threading.Tasks;
using XFCMAPP.Service;

namespace XFCMAPP.Droid
{
    public class FirebaseRemoteConfigService : IFirebaseRemoteConfigService
    {
        public FirebaseRemoteConfigService()
        {
            FirebaseRemoteConfigSettings configSettings = new FirebaseRemoteConfigSettings.Builder()
                .SetDeveloperModeEnabled(true)
                .Build();
            FirebaseRemoteConfig.Instance.SetConfigSettings(configSettings);
            //FirebaseRemoteConfig.Instance.SetDefaults(Resource.Xml.RemoteConfigDefaults);
        }

        public async Task FetchAndActivateAsync()
        {
            try
            {
                await FirebaseRemoteConfig.Instance.FetchAsync(0);
                FirebaseRemoteConfig.Instance.ActivateFetched();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<T> GetAsync<T>(string key)
        {
            try
            {
                var settings = FirebaseRemoteConfig.Instance.GetString(key);
                return await Task.FromResult(Newtonsoft.Json.JsonConvert.DeserializeObject<T>(settings));
            }
            catch (Exception)
            {
                throw;
            }
        }

        //public Task FetchAndActivateAsync()
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<T> GetAsync<T>(string key)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
