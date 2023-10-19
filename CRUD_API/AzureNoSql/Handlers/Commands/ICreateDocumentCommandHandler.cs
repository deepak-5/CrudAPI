// AzureNoSql/Handlers/Commands/ICreateDocumentCommandHandler.cs
using AzureNoSql.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AzureNoSql.Handlers.Commands
{
    public interface ICreateDocumentCommandHandler : IRequestHandler<CreateDocumentCommand, Document>
    {
    }
}
