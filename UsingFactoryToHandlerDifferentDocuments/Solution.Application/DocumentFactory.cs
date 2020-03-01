using Solution.Application.Interfaces;
using Solution.Business.Config;
using Solution.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Solution.Application
{
    public class DocumentFactory : IDocumentFactory
    {
        public IDocumentHandler GetInstance(DocumentType documentTypes, string documentType)
        {
            var document = documentTypes.Documents.FirstOrDefault(x => x.Type.Equals(documentType.ToLower()));
            if (document == null)
                throw new ArgumentNullException();

            // add on the string the name of the assembly where the class is
            var type = Type.GetType($"{document.AssemblyType}, Solution.Business");

            return Activator.CreateInstance(type) as IDocumentHandler;
        }
    }
}
