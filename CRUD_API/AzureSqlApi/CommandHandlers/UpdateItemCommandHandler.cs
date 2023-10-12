// AzureSqlApi/CommandHandlers/UpdateItemCommandHandler.cs
using System;
using System.Threading.Tasks;
using AzureSqlApi.Commands;
using AzureSqlApi.Data;
using Microsoft.EntityFrameworkCore;

namespace AzureSqlApi.CommandHandlers
{
    /// <summary>
    /// Handles the update of an existing item in the database based on the provided command.
    /// </summary>
    public class UpdateItemCommandHandler : IUpdateItemCommandHandler
    {
        private readonly ApplicationDbContext _dbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateItemCommandHandler"/> class.
        /// </summary>
        /// <param name="dbContext">The application's database context.</param>
        public UpdateItemCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Asynchronously handles the update of an item.
        /// </summary>
        /// <param name="command">The command for updating the item.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task HandleAsync(UpdateItemCommand command)
        {
            // Find the existing item by ID
            var existingItem = await _dbContext.Items.FindAsync(command.Id);

            // Check if the item exists
            if (existingItem == null)
            {
                throw new InvalidOperationException("Item not found.");
            }

            // Update the item's properties
            existingItem.Name = command.Name;
            existingItem.Description = command.Description;
            // Update other properties as needed

            // Save changes to the database
            await _dbContext.SaveChangesAsync();
        }
    }
}
