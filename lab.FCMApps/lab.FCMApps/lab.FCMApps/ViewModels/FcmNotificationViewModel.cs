using System;
using System.Collections.Generic;
using System.Text;

namespace lab.FCMApps.ViewModels
{
    public class FcmNotificationViewModel
    {
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Body { get; set; }
        public string Priority { get; set; }
        public string Icon { get; set; }
        public string Sound { get; set; }
        public bool ChatDataAvailable { get; set; }
        public string ChatData { get; set; }
    }
}
