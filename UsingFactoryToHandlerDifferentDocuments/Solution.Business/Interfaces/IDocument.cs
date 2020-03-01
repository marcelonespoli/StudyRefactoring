using Newtonsoft.Json.Linq;

namespace Solution.Business.Interfaces
{
    public interface IDocument
    {
        string DocumentType { get; set; }
        JObject Data { get; set; }
    }
}
