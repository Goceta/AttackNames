using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace AttackNames.Metadata
{
    [JsonObject]
    public class Attack
    {
        [JsonProperty]
        public String Name { get; set; }

        [JsonProperty]
        public String LocalLocation { get; set; }

        [JsonProperty]
        public String ServerLocation { get; set; }

        [JsonProperty]
        public String TitleName { get; set; }

        [JsonProperty]
        public String FranchiseName { get; set; }

        [JsonProperty]
        public String User { get; set; }

        [JsonProperty]
        [JsonConverter(typeof(StringEnumConverter))]
        public MediaType Media { get; set; }

        [JsonProperty]
        public DateTime ReleaseDate { get; set; }
    }
}
