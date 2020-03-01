using Solution.Business;
using Solution.Business.Config;
using System.Collections.Generic;

namespace Solution.Application.Interfaces
{
    public interface IDocumentAppService
    {
        string ProcessRequest(Document document);
        DocumentType GetDocumentTypes();
    }
}
