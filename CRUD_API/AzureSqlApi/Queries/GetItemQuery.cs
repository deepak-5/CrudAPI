// AzureSqlApi/Queries/GetItemQuery.cs
namespace AzureSqlApi.Queries
{
    /// <summary>
    /// Represents a query to retrieve an item by its ID.
    /// </summary>
    public class GetItemQuery
    {
        /// <summary>
        /// Gets or sets the unique identifier of the item to retrieve.
        /// </summary>
        public int Id { get; set; }
    }
}
