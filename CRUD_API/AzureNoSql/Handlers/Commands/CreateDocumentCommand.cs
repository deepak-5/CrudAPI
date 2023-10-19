// AzureNoSql/Handlers/Commands/CreateDocumentCommand.cs
using AzureNoSql.Models;
using MediatR;
using System;

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
    }
}
