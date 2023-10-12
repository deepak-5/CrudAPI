using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using BlazorApp1.Data;

namespace BlazorApp1.Pages
{
    public partial class CrudPage : ComponentBase
    {
        private List<Item> items;
        private Item newItem = new Item();
        private Item selectedItem;

        [Inject]
        private HttpClient HttpClient { get; set; }

        protected override async Task OnInitializedAsync()
        {
            // Load items when the component is initialized
            await LoadItems();
        }

        private async Task LoadItems()
        {
            // Load items from the API
            items = await HttpClient.GetFromJsonAsync<List<Item>>("https://task18.azurewebsites.net/api/items");
        }

        private async Task CreateItem()
        {
            // Create a new item
            var response = await HttpClient.PostAsJsonAsync("https://task18.azurewebsites.net/api/items", newItem);
            response.EnsureSuccessStatusCode();

            // Refresh the items list
            await LoadItems();
            newItem = new Item();
        }

        private async Task EditItem(Item item)
        {
            // Set the selected item for editing
            selectedItem = item;
        }

        private async Task UpdateItem()
        {
            // Update the selected item
            var response = await HttpClient.PutAsJsonAsync($"https://task18.azurewebsites.net/api/items/{selectedItem.Id}", selectedItem);
            response.EnsureSuccessStatusCode();

            // Clear the selected item and refresh the items list
            selectedItem = null;
            await LoadItems();
        }

        private async Task DeleteItem(int id)
        {
            // Delete an item
            var response = await HttpClient.DeleteAsync($"https://task18.azurewebsites.net/api/items/{id}");
            response.EnsureSuccessStatusCode();

            // Refresh the items list
            await LoadItems();
        }
    }
}
