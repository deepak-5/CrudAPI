using System.Threading.Tasks;
using AzureSqlApi.Queries;
using AzureSqlApi.Data;
using AzureSqlApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AzureSqlApi.QueryHandlers
{
    /// <summary>
    /// Handles the execution of the GetItemQuery to retrieve an item by its ID.
    /// </summary>
    public class GetItemQueryHandler : IGetItemQueryHandler
    {
        private readonly ApplicationDbContext _dbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetItemQueryHandler"/> class.
        /// </summary>
        /// <param name="dbContext">The application's database context.</param>
        public GetItemQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Handles the GetItemQuery and retrieves an item by its ID asynchronously.
        /// </summary>
        /// <param name="query">The GetItemQuery instance.</param>
        /// <returns>The requested item or null if not found.</returns>
        public async Task<Item> HandleAsync(GetItemQuery query)
        {
            // Retrieve the item from the database by its ID asynchronously
            var item = await _dbContext.Items.FindAsync(query.Id);

            // If the item is not found, return null (handled as not found)
            if (item == null)
            {
                // Handle item not found here or in the calling code
                return null;
            }

            // Return the item
            return item;
        }
    }
}
