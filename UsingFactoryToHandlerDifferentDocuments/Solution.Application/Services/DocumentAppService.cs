using Microsoft.Extensions.Options;
using Solution.Application.Interfaces;
using Solution.Business;
using Solution.Business.Config;
using Solution.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Solution.Application.Services
{
    public class DocumentAppService : IDocumentAppService
    {
        private DocumentType _documentTypes { get; set; }
        private IDocumentFactory _documentFactory { get; set; }

        public DocumentAppService(
            IOptions<DocumentType> options,
            IDocumentFactory documentFactory)
        {
            if (options == null) throw new ArgumentNullException(nameof(options));

            _documentTypes = options.Value;
            _documentFactory = documentFactory;
        }

        public string ProcessRequest(Document document)
        {
            //var doc = _documentTypes.Documents.FirstOrDefault(x => x.Type.Equals(document.DocumentType.ToLower()));

            //// add on the string the name of the assembly where the class is
            //var type = Type.GetType($"{doc.AssemblyType}, Solution.Business");

            //var documentHandler = Activator.CreateInstance(type) as IDocumentHandler;
            var documentHandler = _documentFactory.GetInstance(_documentTypes, document.DocumentType);
            documentHandler.Execute();

            return $"Handled by instance of {documentHandler.GetType()}";
        }

        public DocumentType GetDocumentTypes()
        {
            return _documentTypes;
        }
    }
}
