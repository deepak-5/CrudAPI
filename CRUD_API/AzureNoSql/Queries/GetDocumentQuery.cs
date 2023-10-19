// AzureNoSql/Handlers/Queries/GetDocumentQuery.cs
using AzureNoSql.Models;
using MediatR;

namespace AzureNoSql.Handlers.Queries
{
    /// <summary>
    /// Represents a query to retrieve a document by its ID.
    /// </summary>
    public class GetDocumentQuery : IRequest<Document>
    {
        /// <summary>
        /// Gets or sets the ID of the document to retrieve.
        /// </summary>
        public string DocumentId { get; set; }
    }
}
