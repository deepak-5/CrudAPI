// AzureNoSql/Data/Repositories/DocumentRepository.cs
using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AzureNoSql.Models;
using System.Collections.Concurrent;
using System.ComponentModel;

namespace AzureNoSql.Data.Repositories
{
    /// <summary>
    /// Represents a repository for managing documents in a Cosmos DB container.
    /// </summary>
    public class DocumentRepository : IDocumentRepository
    {
        private readonly Microsoft.Azure.Cosmos.Container _container;

        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentRepository"/> class.
        /// </summary>
        /// <param name="container">The Cosmos DB container used for document storage.</param>
        public DocumentRepository(Microsoft.Azure.Cosmos.Container container)
        {
            _container = container ?? throw new ArgumentNullException(nameof(container));
        }

        /// <summary>
        /// Creates a new document in the Cosmos DB container.
        /// </summary>
        public async Task<Document> CreateAsync(Document document)
        {
            var response = await _container.CreateItemAsync(document, new PartitionKey(document.id));
            return response.Resource;
        }

        /// <summary>
        /// Retrieves a document by its ID.
        /// </summary>
        public async Task<Document> GetByIdAsync(string id)
        {
            try
            {
                var response = await _container.ReadItemAsync<Document>(id, new PartitionKey(id));
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null; // Document with the given ID not found
            }
        }

        /// <summary>
        /// Retrieves a list of all documents in the container.
        /// </summary>
        public async Task<IEnumerable<Document>> GetAllAsync()
        {
            var query = new QueryDefinition("SELECT * FROM c");
            var documents = new List<Document>();

            using (var resultSet = _container.GetItemQueryIterator<Document>(query))
            {
                while (resultSet.HasMoreResults)
                {
                    var response = await resultSet.ReadNextAsync();
                    documents.AddRange(response.ToList());
                }
            }

            return documents;
        }

        /// <summary>
        /// Updates an existing document in the container.
        /// </summary>
        public async Task<Document> UpdateAsync(Document document)
        {
            var response = await _container.UpsertItemAsync(document, new PartitionKey(document.id));
            return response.Resource;
        }

        /// <summary>
        /// Deletes a document by its ID from the container.
        /// </summary>
        public async Task DeleteAsync(string id)
        {
            await _container.DeleteItemAsync<Document>(id, new PartitionKey(id));
        }
    }
}
