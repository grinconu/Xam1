using System;
using Newtonsoft.Json;

namespace Entities
{
    public class Log
    {
        /// <summary>
        /// Gets or sets the policy.
        /// </summary>
        /// <value>The policy.</value>
        [JsonProperty("policy")]
        public string Policy
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        [JsonProperty("type")]
        public string Type
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        [JsonProperty("description")]
        public string Description
        {
            get;
            set;
        }


    }
}
