using AzureSqlApi.Commands;
using AzureSqlApi.Models;
using AzureSqlApi.Queries;
using AzureSqlApi.Services;
using Microsoft.AspNetCore.Mvc;
/// <summary>
/// Controller for managing items in the API.
/// </summary>
[ApiController]
[Route("api/items")]
public class ItemController : ControllerBase
{
    private readonly IItemService _itemService;

    /// <summary>
    /// Initializes a new instance of the <see cref="ItemController"/> class.
    /// </summary>
    /// <param name="itemService">The item service to use for item operations.</param>
    public ItemController(IItemService itemService)
    {
        _itemService = itemService;
    }

    /// <summary>
    /// Retrieves a list of all items.
    /// </summary>
    /// <returns>A list of items.</returns>
    [HttpGet]
    public async Task<ActionResult<List<Item>>> GetAllItems()
    {
        // Create a query object to get all items
        var query = new GetAllItemsQuery();

        // Call the item service to retrieve all items asynchronously
        var items = await _itemService.GetAllItemsAsync(query);

        // Return the list of items with an HTTP 200 (OK) status code
        return Ok(items);
    }

    /// <summary>
    /// Retrieves an item by its ID.
    /// </summary>
    /// <param name="id">The ID of the item to retrieve.</param>
    /// <returns>The requested item or a NotFound response if not found.</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<Item>> GetItemById(int id)
    {
        // Create a query object to get an item by its ID
        var query = new GetItemQuery { Id = id };

        // Call the item service to retrieve the item by ID asynchronously
        var item = await _itemService.GetItemByIdAsync(query);

        // If the item is not found, return an HTTP 404 (Not Found) response
        if (item == null)
        {
            return NotFound();
        }

        // Return the item with an HTTP 200 (OK) status code
        return Ok(item);
    }

    /// <summary>
    /// Creates a new item.
    /// </summary>
    /// <param name="command">The command to create the item.</param>
    /// <returns>A CreatedAtAction response with the created item.</returns>
    [HttpPost]
    public async Task<ActionResult<Item>> CreateItem(CreateItemCommand command)
    {
        // Call the item service to create a new item asynchronously
        var createdItemId = await _itemService.CreateItemAsync(command);

        // Return a CreatedAtAction response with the created item's ID
        return CreatedAtAction(nameof(GetItemById), new { id = createdItemId }, null);
    }

    /// <summary>
    /// Updates an existing item by its ID.
    /// </summary>
    /// <param name="id">The ID of the item to update.</param>
    /// <param name="command">The updated item data.</param>
    /// <returns>NoContent if successful, BadRequest if the ID doesn't match any existing item.</returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateItem(int id, UpdateItemCommand command)
    {
        // Set the ID in the command to match the route parameter
        command.Id = id;
        try
        {
            // Call the item service to update the item asynchronously
            await _itemService.UpdateItemAsync(command);

            // Return a NoContent response if the update is successful
            return NoContent();
        }
        catch (InvalidOperationException ex)
        {
            // If the item is not found, return an HTTP 404 (Not Found) response with an error message
            return NotFound(ex.Message);
        }
    }

    /// <summary>
    /// Deletes an item by its ID.
    /// </summary>
    /// <param name="id">The ID of the item to delete.</param>
    /// <returns>NoContent if successful, NotFound if the item does not exist.</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteItem(int id)
    {
        // Create a delete command with the item's ID
        var command = new DeleteItemCommand { Id = id };

        // Call the item service to delete the item asynchronously
        await _itemService.DeleteItemAsync(command);

        // Return a NoContent response if the delete is successful
        return NoContent();
    }
}
