namespace XFCMAPP.Utility
{
    public static class InternetConnectHelper
    {
        public static bool CheckConnection()
        {
            try
            {
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
