using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Solution.Application.Interfaces;
using Solution.Business;
using Solution.Business.Config;

namespace Solution.APi.Controllers
{
    [Route("api")]
    public class DocumentsController : ControllerBase
    {
        private readonly IDocumentAppService _documentAppService;

        public DocumentsController(IDocumentAppService documentAppService)
        {
            _documentAppService = documentAppService;
        }

        [HttpPost]
        [Route("document")]
        public IActionResult Post([FromBody] Document document)
        {
            if (document == null )
                return BadRequest();

            var message = _documentAppService.ProcessRequest(document);
            return Ok(message);
        }

        [HttpGet]
        [Route("document-types-handled")]
        public DocumentType Get()
        {
            return _documentAppService.GetDocumentTypes();
        }
    }
}