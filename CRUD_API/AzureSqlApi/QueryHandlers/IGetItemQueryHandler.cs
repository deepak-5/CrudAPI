// AzureSqlApi/QueryHandlers/IGetItemQueryHandler.cs
using System.Threading.Tasks;
using AzureSqlApi.Models;
using AzureSqlApi.Queries;

namespace AzureSqlApi.QueryHandlers
{
    /// <summary>
    /// Defines the contract for handling the GetItemQuery to retrieve an item by its ID.
    /// </summary>
    public interface IGetItemQueryHandler
    {
        /// <summary>
        /// Handles the GetItemQuery and retrieves an item by its ID asynchronously.
        /// </summary>
        /// <param name="query">The GetItemQuery instance.</param>
        /// <returns>The requested item or null if not found.</returns>
        Task<Item> HandleAsync(GetItemQuery query);
    }
}
