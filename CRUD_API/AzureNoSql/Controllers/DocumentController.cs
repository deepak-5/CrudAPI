// AzureNoSql/Controllers/DocumentController.cs
using AzureNoSql.Models;
using AzureNoSql.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AzureNoSql.Controllers
{
    /// <summary>
    /// Represents a controller for managing documents.
    /// </summary>
    [Route("api/documents")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private readonly DocumentService _documentService;

        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentController"/> class.
        /// </summary>
        /// <param name="documentService">The document service for handling document-related operations.</param>
        public DocumentController(DocumentService documentService)
        {
            _documentService = documentService ?? throw new ArgumentNullException(nameof(documentService));
        }

        /// <summary>
        /// Creates a new document.
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<Document>> CreateDocumentAsync(Document document)
        {
            var createdDocument = await _documentService.CreateDocumentAsync(document);
            return Ok(createdDocument);
        }

        /// <summary>
        /// Retrieves a document by its ID.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<Document>> GetDocumentByIdAsync(string id)
        {
            var document = await _documentService.GetDocumentByIdAsync(id);
            if (document == null)
            {
                return NotFound();
            }
            return Ok(document);
        }

        /// <summary>
        /// Retrieves a list of all documents.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Document>>> GetAllDocumentsAsync()
        {
            var documents = await _documentService.GetAllDocumentsAsync();
            return Ok(documents);
        }

        /// <summary>
        /// Updates an existing document by its ID.
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDocumentAsync(string id, Document document)
        {
            if (id != document.id)
            {
                return BadRequest();
            }
            var updatedDocument = await _documentService.UpdateDocumentAsync(document);
            return Ok(updatedDocument);
        }

        /// <summary>
        /// Deletes a document by its ID.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDocumentAsync(string id)
        {
            await _documentService.DeleteDocumentAsync(id);
            return NoContent();
        }
    }
}
