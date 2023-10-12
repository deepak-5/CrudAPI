// AzureSqlApi/Commands/UpdateItemCommand.cs
using System.ComponentModel.DataAnnotations;

namespace AzureSqlApi.Commands
{
    /// <summary>
    /// Represents a command for updating an item.
    /// </summary>
    public class UpdateItemCommand
    {
        /// <summary>
        /// Gets or sets the ID of the item to be updated.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the updated name of the item (required).
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the updated description of the item.
        /// </summary>
        public string Description { get; set; }
    }
}
