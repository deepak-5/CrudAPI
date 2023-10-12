// AzureNoSql/Data/Repositories/IDocumentRepository.cs
using AzureNoSql.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AzureNoSql.Data.Repositories
{
    /// <summary>
    /// Defines the interface for a repository managing documents.
    /// </summary>
    public interface IDocumentRepository
    {
        /// <summary>
        /// Creates a new document.
        /// </summary>
        Task<Document> CreateAsync(Document document);

        /// <summary>
        /// Retrieves a document by its ID.
        /// </summary>
        Task<Document> GetByIdAsync(string id);

        /// <summary>
        /// Retrieves a list of all documents.
        /// </summary>
        Task<IEnumerable<Document>> GetAllAsync();

        /// <summary>
        /// Updates an existing document.
        /// </summary>
        Task<Document> UpdateAsync(Document document);

        /// <summary>
        /// Deletes a document by its ID.
        /// </summary>
        Task DeleteAsync(string id);
    }
}
