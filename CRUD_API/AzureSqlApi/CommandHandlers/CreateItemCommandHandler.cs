// AzureSqlApi/CommandHandlers/CreateItemCommandHandler.cs
using System.Threading.Tasks;
using AzureSqlApi.Commands;
using AzureSqlApi.Data;
using AzureSqlApi.Models;

namespace AzureSqlApi.CommandHandlers
{
    /// <summary>
    /// Handles the creation of a new item in the database based on the provided command.
    /// </summary>
    public class CreateItemCommandHandler : ICreateItemCommandHandler
    {
        private readonly ApplicationDbContext _dbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateItemCommandHandler"/> class.
        /// </summary>
        /// <param name="dbContext">The application's database context.</param>
        public CreateItemCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Asynchronously handles the creation of a new item.
        /// </summary>
        /// <param name="command">The command for creating the item.</param>
        /// <returns>The ID of the newly created item.</returns>
        public async Task<int> HandleAsync(CreateItemCommand command)
        {
            // Create a new item entity
            var newItem = new Item
            {
                Name = command.Name,
                Description = command.Description
                // You can set other properties as needed here
            };

            // Add the new item to the database
            _dbContext.Items.Add(newItem);
            await _dbContext.SaveChangesAsync();

            return newItem.Id;
        }
    }
}
