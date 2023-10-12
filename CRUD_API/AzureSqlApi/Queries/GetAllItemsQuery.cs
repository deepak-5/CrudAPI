using System.Collections.Generic;
using AzureSqlApi.DTOs;
using MediatR;

namespace AzureSqlApi.Queries
{
    /// <summary>
    /// Represents a query to retrieve a list of all items.
    /// </summary>
    public class GetAllItemsQuery : IRequest<List<ItemDTO>>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllItemsQuery"/> class.
        /// </summary>
        public GetAllItemsQuery()
        {
            // You can add properties to the query if needed (e.g., filtering options)
        }
    }
}
