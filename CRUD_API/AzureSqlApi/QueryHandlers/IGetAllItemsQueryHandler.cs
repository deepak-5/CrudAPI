// AzureSqlApi/QueryHandlers/IGetAllItemsQueryHandler.cs
using System.Collections.Generic;
using System.Threading.Tasks;
using AzureSqlApi.Queries;
using AzureSqlApi.Models;

namespace AzureSqlApi.QueryHandlers
{
    /// <summary>
    /// Defines the contract for handling the GetAllItemsQuery to retrieve a list of all items.
    /// </summary>
    public interface IGetAllItemsQueryHandler
    {
        /// <summary>
        /// Handles the GetAllItemsQuery and retrieves a list of all items asynchronously.
        /// </summary>
        /// <param name="query">The GetAllItemsQuery instance.</param>
        /// <returns>A list of all items.</returns>
        Task<List<Item>> HandleAsync(GetAllItemsQuery query);
    }
}
