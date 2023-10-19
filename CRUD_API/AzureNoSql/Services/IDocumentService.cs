using AzureNoSql.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AzureNoSql.Services
{
    /// <summary>
    /// Interface for service responsible for handling document-related operations.
    /// </summary>
    public interface IDocumentService
    {
        /// <summary>
        /// Creates a new document.
        /// </summary>
        /// <param name="document">The document to create.</param>
        /// <returns>The created document.</returns>
        Task<Document> CreateDocumentAsync(Document document);

        /// <summary>
        /// Retrieves a document by its ID.
        /// </summary>
        /// <param name="id">The ID of the document to retrieve.</param>
        /// <returns>The requested document or null if not found.</returns>
        Task<Document> GetDocumentByIdAsync(string id);

        /// <summary>
        /// Retrieves all documents.
        /// </summary>
        /// <returns>A collection of all documents.</returns>
        Task<IEnumerable<Document>> GetAllDocumentsAsync();

        /// <summary>
        /// Updates an existing document.
        /// </summary>
        /// <param name="document">The updated document data.</param>
        /// <returns>The updated document.</returns>
        Task<Document> UpdateDocumentAsync(Document document);

        /// <summary>
        /// Deletes a document by its ID.
        /// </summary>
        /// <param name="id">The ID of the document to delete.</param>
        Task DeleteDocumentAsync(string id);
    }
}
