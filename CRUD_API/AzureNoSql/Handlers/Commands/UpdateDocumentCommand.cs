// AzureNoSql/Handlers/Commands/UpdateDocumentCommand.cs
using AzureNoSql.Models;
using MediatR;

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
}
