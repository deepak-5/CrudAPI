// AzureNoSql/Handlers/Commands/UpdateDocumentCommand.cs
using AzureNoSql.Models;
using AzureNoSql.Data.Repositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AzureNoSql.Handlers.Commands
{
    /// <summary>
    /// Represents a command to update an existing document.
    /// </summary>
    public class UpdateDocumentCommand : IRequest<Document>
    {
        /// <summary>
        /// Gets or sets the document to be updated.
        /// </summary>
        public Document Document { get; set; }
    }

    /// <summary>
    /// Handles the UpdateDocumentCommand and returns the updated document.
    /// </summary>
    public class UpdateDocumentCommandHandler : IRequestHandler<UpdateDocumentCommand, Document>
    {
        private readonly DocumentRepository _documentRepository;

        public UpdateDocumentCommandHandler(DocumentRepository documentRepository)
        {
            _documentRepository = documentRepository ?? throw new ArgumentNullException(nameof(documentRepository));
        }

        /// <summary>
        /// Handles the UpdateDocumentCommand request and updates an existing document.
        /// </summary>
        /// <param name="request">The UpdateDocumentCommand request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The updated document.</returns>
        public async Task<Document> Handle(UpdateDocumentCommand request, CancellationToken cancellationToken)
        {
            // Implement logic to update a document
            return await _documentRepository.UpdateAsync(request.Document);
        }
    }
}
