using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace XFCMAPP.Service
{
    public interface IFirebaseRemoteConfigService
    {
        Task FetchAndActivateAsync();
        Task<T> GetAsync<T>(string key);
    }
}
