// AzureSqlApi/Commands/CreateItemCommand.cs
using System.ComponentModel.DataAnnotations;

namespace AzureSqlApi.Commands
{
    /// <summary>
    /// Represents a command for creating a new item.
    /// </summary>
    public class CreateItemCommand
    {
        /// <summary>
        /// Gets or sets the name of the item (required).
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description of the item.
        /// </summary>
        public string Description { get; set; }
    }
}
