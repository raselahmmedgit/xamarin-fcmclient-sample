using System;
using System.Collections.Generic;
using System.Text;

namespace XFCMAPP.Poll.Models
{
    public class Message
    {
        public string Text { get; set; }
        public string User { get; set; }
        public ICollection<MessageAction> MessageActions { get; set; }
    }

    public class MessageAction
    {
        public string ActionText { get; set; }
        public string ActionValue { get; set; }
    }
}
