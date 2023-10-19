// AzureNoSql/Services/DocumentService.cs
using AzureNoSql.Data.Repositories;
using AzureNoSql.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AzureNoSql.Services
{
    /// <summary>
    /// Service responsible for handling document-related operations.
    /// </summary>
    public class DocumentService : IDocumentService
    
    {
        private readonly DocumentRepository _documentRepository;

        public DocumentService(DocumentRepository documentRepository)
        {
            _documentRepository = documentRepository ?? throw new ArgumentNullException(nameof(documentRepository));
        }

        /// <summary>
        /// Creates a new document.
        /// </summary>
        /// <param name="document">The document to create.</param>
        /// <returns>The created document.</returns>
        public async Task<Document> CreateDocumentAsync(Document document)
        {
            return await _documentRepository.CreateAsync(document);
        }

        /// <summary>
        /// Retrieves a document by its ID.
        /// </summary>
        /// <param name="id">The ID of the document to retrieve.</param>
        /// <returns>The requested document or null if not found.</returns>
        public async Task<Document> GetDocumentByIdAsync(string id)
        {
            return await _documentRepository.GetByIdAsync(id);
        }

        /// <summary>
        /// Retrieves all documents.
        /// </summary>
        /// <returns>A collection of all documents.</returns>
        public async Task<IEnumerable<Document>> GetAllDocumentsAsync()
        {
            return await _documentRepository.GetAllAsync();
        }

        /// <summary>
        /// Updates an existing document.
        /// </summary>
        /// <param name="document">The updated document data.</param>
        /// <returns>The updated document.</returns>
        public async Task<Document> UpdateDocumentAsync(Document document)
        {
            return await _documentRepository.UpdateAsync(document);
        }

        /// <summary>
        /// Deletes a document by its ID.
        /// </summary>
        /// <param name="id">The ID of the document to delete.</param>
        public async Task DeleteDocumentAsync(string id)
        {
            await _documentRepository.DeleteAsync(id);
        }
    }
}
