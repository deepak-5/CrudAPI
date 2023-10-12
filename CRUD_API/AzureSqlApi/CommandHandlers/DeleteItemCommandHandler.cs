// AzureSqlApi/CommandHandlers/DeleteItemCommandHandler.cs
using System;
using System.Threading.Tasks;
using AzureSqlApi.Commands;
using AzureSqlApi.Data;
using Microsoft.EntityFrameworkCore;

namespace AzureSqlApi.CommandHandlers
{
    /// <summary>
    /// Handles the deletion of an item from the database based on the provided command.
    /// </summary>
    public class DeleteItemCommandHandler : IDeleteItemCommandHandler
    {
        private readonly ApplicationDbContext _dbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteItemCommandHandler"/> class.
        /// </summary>
        /// <param name="dbContext">The application's database context.</param>
        public DeleteItemCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Asynchronously handles the deletion of an item.
        /// </summary>
        /// <param name="command">The command for deleting the item.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task HandleAsync(DeleteItemCommand command)
        {
            // Find the existing item by ID
            var existingItem = await _dbContext.Items.FindAsync(command.Id);

            // Check if the item exists
            if (existingItem == null)
            {
                throw new InvalidOperationException("Item not found.");
            }

            // Remove the item from the database
            _dbContext.Items.Remove(existingItem);
            await _dbContext.SaveChangesAsync();
        }
    }
}
