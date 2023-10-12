// AzureSqlApi/Commands/DeleteItemCommand.cs
namespace AzureSqlApi.Commands
{
    /// <summary>
    /// Represents a command for deleting an item by its ID.
    /// </summary>
    public class DeleteItemCommand
    {
        /// <summary>
        /// Gets or sets the ID of the item to be deleted.
        /// </summary>
        public int Id { get; set; }
    }
}
