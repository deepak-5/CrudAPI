using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using BlazorApp1.Data;

namespace BlazorApp1.Pages
{
    public partial class NoSqlCrudPage : ComponentBase
    {
        private List<Document> documents = new List<Document>();
        private Document newDocument = new Document();
        private Document editingDocument;

        [Inject]
        protected HttpClient HttpClientService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await LoadDocuments();
        }

        private async Task LoadDocuments()
        {
            // Retrieve and display the list of documents from the API
            documents = await HttpClientService.GetFromJsonAsync<List<Document>>("https://task19.azurewebsites.net/api/documents");
        }

        private async Task CreateDocument()
        {
            // Send a POST request to create a new document
            var response = await HttpClientService.PostAsJsonAsync("https://task19.azurewebsites.net/api/documents", newDocument);
            if (response.IsSuccessStatusCode)
            {
                newDocument = new Document(); // Clear the form
                await LoadDocuments(); // Refresh the document list
            }
        }

        private void EditDocument(Document document)
        {
            // Show the edit form for a specific document
            editingDocument = document;
        }

        private async Task UpdateDocument()
        {
            // Send a PUT request to update an existing document
            var response = await HttpClientService.PutAsJsonAsync($"https://task19.azurewebsites.net/api/documents/{editingDocument.id}", editingDocument);
            if (response.IsSuccessStatusCode)
            {
                editingDocument = null; // Hide the edit form
                await LoadDocuments(); // Refresh the document list
            }
        }

        private async Task DeleteDocument(string id)
        {
            // Send a DELETE request to delete a document by id
            var response = await HttpClientService.DeleteAsync($"https://task19.azurewebsites.net/api/documents/{id}");
            if (response.IsSuccessStatusCode)
            {
                await LoadDocuments(); // Refresh the document list
            }
        }
    }
}
