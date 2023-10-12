// AzureSqlApi/CommandHandlers/IDeleteItemCommandHandler.cs
using System.Threading.Tasks;
using AzureSqlApi.Commands;

namespace AzureSqlApi.CommandHandlers
{
    /// <summary>
    /// Defines the contract for handling the deletion of an item.
    /// </summary>
    public interface IDeleteItemCommandHandler
    {
        /// <summary>
        /// Asynchronously handles the deletion of an item based on the provided command.
        /// </summary>
        /// <param name="command">The command for deleting the item.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task HandleAsync(DeleteItemCommand command);
    }
}
