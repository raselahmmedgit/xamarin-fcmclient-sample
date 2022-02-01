using System;
using System.Collections.Generic;
using System.Text;

namespace XFCMAPP.Utility
{
    public static class AppConstant
    {
        public static string RapidProFcmUrl = "https://rapidpro.ilhasoft.mobi/c/fcm/";

        public static string RapidProFcmRegisterUrl = RapidProFcmUrl + "4a2e5997-f435-4e20-829f-743b86ce0550/register";
        public static string RapidProFcmReceiveUrl = RapidProFcmUrl + "4a2e5997-f435-4e20-829f-743b86ce0550/receive";

        public static string NotFound = "Data not found.";
        public static string Error = "Oops! Exception in application.";
        public static string NullError = "Requested object could not found.";

        public static string NoInternetConnect = "No internet connect please try again.";

        public static string DisplayAlertErrorTitle = "Error!";
        public static string DisplayAlertTitle = "Message!";
        public static string DisplayAlertWarningTitle = "Warning!";
        public static string DisplayAlertErrorMessage = "Oops! Exception in application.";
        public static string DisplayAlertGeocoderErrorMessage = "Oops! Geocoder returns no results.";
        public static string DisplayAlertErrorButtonText = "Ok";
    }
}
