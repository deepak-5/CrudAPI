// AzureNoSql/Handlers/Queries/IGetDocumentQueryHandler.cs
using AzureNoSql.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AzureNoSql.Handlers.Queries
{
    public interface IGetDocumentQueryHandler : IRequestHandler<GetDocumentQuery, Document>
    {
    }
}
