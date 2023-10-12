// AzureSqlApi/Models/Item.cs
namespace AzureSqlApi.Models
{
    /// <summary>
    /// Represents an item in the application.
    /// </summary>
    public class Item
    {
        /// <summary>
        /// Gets or sets the unique identifier of the item.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the item.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description of the item.
        /// </summary>
        public string Description { get; set; }
    }
}
