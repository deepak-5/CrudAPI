// AzureSqlApi/Services/ItemService.cs
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AzureSqlApi.Models;
using AzureSqlApi.Commands;
using AzureSqlApi.Queries;
using AzureSqlApi.CommandHandlers;
using AzureSqlApi.QueryHandlers;

namespace AzureSqlApi.Services
{
    /// <summary>
    /// Provides business logic and coordination for managing items.
    /// </summary>
    public class ItemService : IItemService
    {
        private readonly ICreateItemCommandHandler _createItemCommandHandler;
        private readonly IUpdateItemCommandHandler _updateItemCommandHandler;
        private readonly IDeleteItemCommandHandler _deleteItemCommandHandler;
        private readonly IGetItemQueryHandler _getItemQueryHandler;
        private readonly IGetAllItemsQueryHandler _getAllItemsQueryHandler;

        /// <summary>
        /// Initializes a new instance of the <see cref="ItemService"/> class.
        /// </summary>
        /// <param name="createItemCommandHandler">The handler for creating items.</param>
        /// <param name="updateItemCommandHandler">The handler for updating items.</param>
        /// <param name="deleteItemCommandHandler">The handler for deleting items.</param>
        /// <param name="getItemQueryHandler">The handler for retrieving items by ID.</param>
        /// <param name="getAllItemsQueryHandler">The handler for retrieving all items.</param>
        public ItemService(
            ICreateItemCommandHandler createItemCommandHandler,
            IUpdateItemCommandHandler updateItemCommandHandler,
            IDeleteItemCommandHandler deleteItemCommandHandler,
            IGetItemQueryHandler getItemQueryHandler,
            IGetAllItemsQueryHandler getAllItemsQueryHandler)
        {
            _createItemCommandHandler = createItemCommandHandler;
            _updateItemCommandHandler = updateItemCommandHandler;
            _deleteItemCommandHandler = deleteItemCommandHandler;
            _getItemQueryHandler = getItemQueryHandler;
            _getAllItemsQueryHandler = getAllItemsQueryHandler;
        }

        /// <summary>
        /// Asynchronously creates a new item based on the provided command.
        /// </summary>
        /// <param name="command">The command for creating the item.</param>
        /// <returns>The ID of the created item.</returns>
        public async Task<int> CreateItemAsync(CreateItemCommand command)
        {
            // Add business logic and validation as needed
            return await _createItemCommandHandler.HandleAsync(command);
        }

        /// <summary>
        /// Asynchronously updates an existing item based on the provided command.
        /// </summary>
        /// <param name="command">The command for updating the item.</param>
        public async Task UpdateItemAsync(UpdateItemCommand command)
        {
            // Add business logic and validation as needed
            await _updateItemCommandHandler.HandleAsync(command);
        }

        /// <summary>
        /// Asynchronously retrieves an item by its ID based on the provided query.
        /// </summary>
        /// <param name="query">The query for retrieving the item.</param>
        /// <returns>The requested item or null if not found.</returns>
        public async Task<Item> GetItemByIdAsync(GetItemQuery query)
        {
            return await _getItemQueryHandler.HandleAsync(query);
        }

        /// <summary>
        /// Asynchronously retrieves a list of all items based on the provided query.
        /// </summary>
        /// <param name="query">The query for retrieving all items.</param>
        /// <returns>A list of items.</returns>
        public async Task<List<Item>> GetAllItemsAsync(GetAllItemsQuery query)
        {
            return await _getAllItemsQueryHandler.HandleAsync(query);
        }

        /// <summary>
        /// Asynchronously deletes an item based on the provided command.
        /// </summary>
        /// <param name="command">The command for deleting the item.</param>
        public async Task DeleteItemAsync(DeleteItemCommand command)
        {
            await _deleteItemCommandHandler.HandleAsync(command);
        }
    }
}
