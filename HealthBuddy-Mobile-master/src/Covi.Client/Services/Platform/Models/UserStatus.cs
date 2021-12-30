// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Covi.Client.Services.Platform.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    public partial class UserStatus
    {
        /// <summary>
        /// Initializes a new instance of the UserStatus class.
        /// </summary>
        public UserStatus()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the UserStatus class.
        /// </summary>
        public UserStatus(int? statusId = default(int?), System.DateTime? statusChangedOn = default(System.DateTime?))
        {
            StatusId = statusId;
            StatusChangedOn = statusChangedOn;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "statusId")]
        public int? StatusId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "statusChangedOn")]
        public System.DateTime? StatusChangedOn { get; set; }

    }
}
