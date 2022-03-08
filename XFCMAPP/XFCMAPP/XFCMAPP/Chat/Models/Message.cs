using System;
using System.Collections.Generic;
using System.Text;

namespace XFCMAPP.Chat.Models
{
    public class Message
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public string Value { get; set; }
        public string User { get; set; }
        public bool MessageAction { get; set; }
        public bool IsVisible { get; set; }
        public string ChannelId { get; set; }
        public DateTime CreatedDateTime { get; set; }
    }
}
