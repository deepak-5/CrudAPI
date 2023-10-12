// AzureSqlApi/Services/IItemService.cs
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AzureSqlApi.Models;
using AzureSqlApi.Commands;
using AzureSqlApi.Queries;

namespace AzureSqlApi.Services
{
    /// <summary>
    /// Defines the contract for the item service, which provides operations for managing items.
    /// </summary>
    public interface IItemService
    {
        /// <summary>
        /// Asynchronously creates a new item based on the provided command.
        /// </summary>
        /// <param name="command">The command for creating the item.</param>
        /// <returns>The ID of the created item.</returns>
        Task<int> CreateItemAsync(CreateItemCommand command);

        /// <summary>
        /// Asynchronously updates an existing item based on the provided command.
        /// </summary>
        /// <param name="command">The command for updating the item.</param>
        Task UpdateItemAsync(UpdateItemCommand command);

        /// <summary>
        /// Asynchronously retrieves an item by its ID based on the provided query.
        /// </summary>
        /// <param name="query">The query for retrieving the item.</param>
        /// <returns>The requested item or null if not found.</returns>
        Task<Item> GetItemByIdAsync(GetItemQuery query);

        /// <summary>
        /// Asynchronously retrieves a list of all items based on the provided query.
        /// </summary>
        /// <param name="query">The query for retrieving all items.</param>
        /// <returns>A list of items.</returns>
        Task<List<Item>> GetAllItemsAsync(GetAllItemsQuery query);

        /// <summary>
        /// Asynchronously deletes an item based on the provided command.
        /// </summary>
        /// <param name="command">The command for deleting the item.</param>
        Task DeleteItemAsync(DeleteItemCommand command);
    }
}
