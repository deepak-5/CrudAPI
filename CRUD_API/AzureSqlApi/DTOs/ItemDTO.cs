// AzureSqlApi/DTOs/ItemDTO.cs
namespace AzureSqlApi.DTOs
{
    /// <summary>
    /// Represents a Data Transfer Object (DTO) for an item.
    /// </summary>
    public class ItemDTO
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
