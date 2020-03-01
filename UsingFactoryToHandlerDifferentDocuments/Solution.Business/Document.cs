using Newtonsoft.Json.Linq;
using Solution.Business.Interfaces;

namespace Solution.Business
{
    public class Document : IDocument
    {
        public string DocumentType { get; set; }
        public JObject Data { get; set; }
    }
}
