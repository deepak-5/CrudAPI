// AzureNoSql/Handlers/Queries/GetDocumentQueryHandler.cs
using AzureNoSql.Models;
using AzureNoSql.Data.Repositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AzureNoSql.Handlers.Queries
{
    /// <summary>
    /// Handles the GetDocumentQuery and returns the requested document.
    /// </summary>
    public class GetDocumentQueryHandler : IGetDocumentQueryHandler
    {
        private readonly DocumentRepository _documentRepository;

        public GetDocumentQueryHandler(DocumentRepository documentRepository)
        {
            _documentRepository = documentRepository ?? throw new ArgumentNullException(nameof(documentRepository));
        }

        /// <summary>
        /// Handles the GetDocumentQuery request and retrieves a document by its ID.
        /// </summary>
        /// <param name="request">The GetDocumentQuery request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The requested document, or null if not found.</returns>
        public async Task<Document> Handle(GetDocumentQuery request, CancellationToken cancellationToken)
        {
            // Implement logic to retrieve a document by ID
            return await _documentRepository.GetByIdAsync(request.DocumentId);
        }
    }
}
