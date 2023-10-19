using System;

namespace AzureNoSql.Models
{
    /// <summary>
    /// Represents a document stored in Azure Cosmos DB.
    /// </summary>
    public class Document
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
