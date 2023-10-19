// AzureNoSql/Handlers/Commands/IUpdateDocumentCommandHandler.cs
using AzureNoSql.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AzureNoSql.Handlers.Commands
{
    public interface IUpdateDocumentCommandHandler : IRequestHandler<UpdateDocumentCommand, Document>
    {
    }
}
