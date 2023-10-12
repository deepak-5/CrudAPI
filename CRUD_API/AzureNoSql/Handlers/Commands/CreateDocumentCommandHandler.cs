// AzureNoSql/Handlers/Commands/CreateDocumentCommand.cs
using AzureNoSql.Models;
using AzureNoSql.Data.Repositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AzureNoSql.Handlers.Commands
{
    /// <summary>
    /// Represents a command to create a new document.
    /// </summary>
    public class CreateDocumentCommand : IRequest<Document>
    {
        /// <summary>
        /// Gets or sets the document to be created.
        /// </summary>
        public Document Document { get; set; }

        /// <summary>
        /// Handles the CreateDocumentCommand and returns the created document.
        /// </summary>
        public class CreateDocumentCommandHandler : IRequestHandler<CreateDocumentCommand, Document>
        {
            private readonly DocumentRepository _documentRepository;

            public CreateDocumentCommandHandler(DocumentRepository documentRepository)
            {
                _documentRepository = documentRepository ?? throw new ArgumentNullException(nameof(documentRepository));
            }

            /// <summary>
            /// Handles the CreateDocumentCommand request and creates a new document.
            /// </summary>
            /// <param name="request">The CreateDocumentCommand request.</param>
            /// <param name="cancellationToken">The cancellation token.</param>
            /// <returns>The created document.</returns>
            public async Task<Document> Handle(CreateDocumentCommand request, CancellationToken cancellationToken)
            {
                // Implement logic to create a document
                return await _documentRepository.CreateAsync(request.Document);
            }
        }
    }
}
