// AzureNoSql/DTOs/DocumentDTO.cs
namespace AzureNoSql.DTOs
{
    /// <summary>
    /// Data transfer object (DTO) representing a document for external communication.
    /// </summary>
    public class DocumentDTO
    {
        /// <summary>
        /// Gets or sets the ID of the document.
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// Gets or sets the title of the document.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the content of the document.
        /// </summary>
        public string Content { get; set; }
    }
}
