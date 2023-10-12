using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AzureSqlApi.Queries;
using AzureSqlApi.Data;
using AzureSqlApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AzureSqlApi.QueryHandlers
{
    /// <summary>
    /// Handles the execution of the GetAllItemsQuery to retrieve a list of all items.
    /// </summary>
    public class GetAllItemsQueryHandler : IGetAllItemsQueryHandler
    {
        private readonly ApplicationDbContext _dbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllItemsQueryHandler"/> class.
        /// </summary>
        /// <param name="dbContext">The application's database context.</param>
        public GetAllItemsQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Handles the GetAllItemsQuery and retrieves a list of all items asynchronously.
        /// </summary>
        /// <param name="query">The GetAllItemsQuery instance.</param>
        /// <returns>A list of all items.</returns>
        public async Task<List<Item>> HandleAsync(GetAllItemsQuery query)
        {
            // Retrieve all items from the database asynchronously
            var items = await _dbContext.Items.ToListAsync();

            // Return the list of items
            return items;
        }
    }
}
