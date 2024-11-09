using Items.Domain.Dtos;
using Items.Domain.Interfaz;
using Microsoft.AspNetCore.Mvc;

namespace Items.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly IItemService _itemService;

        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }

        /// <summary>
        /// Obtiene un Item por su identificador.
        /// </summary>
        /// <param name="ItemId">El identificador del Item.</param>
        /// <returns>Un Item DTO si se encuentra, de lo contrario NotFound.</returns>
        [HttpGet("{ItemId}")]
        public async Task<IActionResult> GetItemById(int ItemId)
        {
            var item = await _itemService.GetItemByIdAsync(ItemId);

            if (item == null)
            {
                return NotFound(new { message = $"Item con id {ItemId} no fue encontrado." });
            }

            return Ok(item);
        }

        /// <summary>
        /// Obtiene todos los Items.
        /// </summary>
        /// <returns>Una lista de Items DTO.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllItems()
        {
            var items = await _itemService.GetAllItemsAsync();
            return Ok(items);
        }

        /// <summary>
        /// Crea un nuevo Item.
        /// </summary>
        /// <param name="itemDto"> El DTO del Item a crear.</param>
        /// <returns>El Item creado.</returns>
        [HttpPost]
        public async Task<IActionResult> CreateItem([FromBody] ItemCreateDto itemDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdItem = await _itemService.CreateItemAsync(itemDto);

            return CreatedAtAction(nameof(GetItemById), new { ItemId = createdItem.ItemId }, createdItem);
        }

        /// <summary>
        /// Actualiza un Item existente.
        /// </summary>       
        /// <param name="itemDto">El DTO del Item con los nuevos valores.</param>
        /// <returns>El Item actualizado si se encuentra, de lo contrario NotFound.</returns>
        [HttpPut()]
        public async Task<IActionResult> UpdateItem([FromBody] ItemUpdateDto itemDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedItem = await _itemService.UpdateItemAsync(itemDto);

            if (updatedItem == null)
            {
                return NotFound(new { message = $"Item con id {itemDto.ItemId} no fue encontrado." });
            }

            return Ok(updatedItem);
        }

        /// <summary>
        /// Elimina un Item existente.
        /// </summary>
        /// <param name="ItemId">El identificador del Item a eliminar.</param>
        /// <returns>Status 204 si se elimina correctamente, de lo contrario NotFound.</returns>
        [HttpDelete("{ItemId}")]
        public async Task<IActionResult> DeleteItem(int ItemId)
        {
            var deleted = await _itemService.DeleteItemAsync(ItemId);

            if (!deleted)
            {
                return NotFound(new { message = $"Item con id {ItemId} no fue encontrado." });
            }

            return NoContent();
        }
    }
}
