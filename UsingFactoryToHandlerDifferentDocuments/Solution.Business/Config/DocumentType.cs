using Newtonsoft.Json;
using System.Collections.Generic;

namespace Solution.Business.Config
{
    public class DocumentType
    {
        [JsonProperty(PropertyName = "documents")]
        public IEnumerable<DocumentPath> Documents { get; set; }
    }

    public class DocumentPath
    {
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "assemblyType")]
        public string AssemblyType { get; set; }
    }
}
