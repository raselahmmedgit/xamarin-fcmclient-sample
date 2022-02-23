using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace XFCMAPP.ViewModel
{
    [Serializable]
    public class RapidProRegister
    {
        [JsonProperty(PropertyName = "contact_uuid")]
        public string ContactUuid { get; set; }
    }

    [Serializable]
    public class RapidProReceive
    {
        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }

        [JsonProperty(PropertyName = "data")]
        public List<RapidProReceiveData> Data { get; set; }
    }

    [Serializable]
    public class RapidProReceiveData
    {
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "channel_uuid")]
        public string ChannelUuid { get; set; }

        [JsonProperty(PropertyName = "msg_uuid")]
        public string MsgUuid { get; set; }

        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }

        [JsonProperty(PropertyName = "urn")]
        public string Urn { get; set; }

        [JsonProperty(PropertyName = "received_on")]
        public string ReceivedOn { get; set; }
    }

    [Serializable]
    public class RapidProFcmPushNotification
    {
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "body")]
        public string Body { get; set; }

        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "message_id")]
        public string MessageId { get; set; }

        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }

        [JsonProperty(PropertyName = "quick_replies")]
        public string QuickReplies { get; set; }
    }

    [Serializable]
    public class RapidProFcmPushNotificationQuickReplie
    {
        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }

        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; }
    }
}
