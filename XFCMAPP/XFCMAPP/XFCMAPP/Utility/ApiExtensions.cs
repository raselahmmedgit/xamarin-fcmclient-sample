using System;
using System.Collections.Generic;

namespace XFCMAPP.Utility
{
    public static class ApiExtensions
    {
        public static KeyValuePair<string, string> AsPair(this string key, string value)
        {
            return new KeyValuePair<string, string>(key, value);
        }
        public static string ToAbsoluteUrl(this string requestUri)
        {
            string url = (requestUri).Replace("//", "/");
            return url;
        }
    }
}
