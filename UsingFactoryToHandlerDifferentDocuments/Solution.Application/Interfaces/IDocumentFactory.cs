using Solution.Business.Config;
using Solution.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Solution.Application.Interfaces
{
    public interface IDocumentFactory
    {
        IDocumentHandler GetInstance(DocumentType documentTypes, string documentType);
    }
}
