// AzureSqlApi/CommandHandlers/ICreateItemCommandHandler.cs
using System.Threading.Tasks;
using AzureSqlApi.Commands;

namespace AzureSqlApi.CommandHandlers
{
    /// <summary>
    /// Defines the contract for handling the creation of a new item.
    /// </summary>
    public interface ICreateItemCommandHandler
    {
        /// <summary>
        /// Asynchronously handles the creation of a new item based on the provided command.
        /// </summary>
        /// <param name="command">The command for creating the item.</param>
        /// <returns>The ID of the newly created item.</returns>
        Task<int> HandleAsync(CreateItemCommand command);
    }
}
