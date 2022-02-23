using System.ComponentModel;

namespace XFCMAPP.Poll.Helpers
{
    public enum MessageUserEnum
    {
        [Description("UserHealthBuddy")]
        UserHealthBuddy = 1,
        [Description("UserLogin")]
        UserLogin = 2,
        [Description("UserAnonymous")]
        UserAnonymous = 3
    }
}
