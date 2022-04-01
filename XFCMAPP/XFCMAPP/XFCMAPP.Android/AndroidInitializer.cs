using Prism;
using Prism.Ioc;
using XFCMAPP.Service;

namespace XFCMAPP.Droid
{
    public class AndroidInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IFirebaseRemoteConfigService, FirebaseRemoteConfigService>();
        }
    }
}