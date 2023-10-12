// AzureSqlApi/CommandHandlers/IUpdateItemCommandHandler.cs
using System.Threading.Tasks;
using AzureSqlApi.Commands;

namespace AzureSqlApi.CommandHandlers
{
    /// <summary>
    /// Defines the contract for handling the update of an item.
    /// </summary>
    public interface IUpdateItemCommandHandler
    {
        /// <summary>
        /// Asynchronously handles the update of an item based on the provided command.
        /// </summary>
        /// <param name="command">The command for updating the item.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task HandleAsync(UpdateItemCommand command);
    }
}
