// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Covi.Client.Services.Platform.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    public partial class Status
    {
        /// <summary>
        /// Initializes a new instance of the Status class.
        /// </summary>
        public Status()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the Status class.
        /// </summary>
        public Status(int? id = default(int?), string name = default(string), int? severity = default(int?), bool? requiresContactDiscovery = default(bool?))
        {
            Id = id;
            Name = name;
            Severity = severity;
            RequiresContactDiscovery = requiresContactDiscovery;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "severity")]
        public int? Severity { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "requiresContactDiscovery")]
        public bool? RequiresContactDiscovery { get; set; }

    }
}
