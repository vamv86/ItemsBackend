using Items.Domain.Dtos;

namespace Items.Domain.Interfaz
{
    public interface IItemService
    {
        Task<ItemDto> GetItemByIdAsync(int itemId);
        Task<List<ItemDto>> GetAllItemsAsync();
        Task<ItemDto> CreateItemAsync(ItemCreateDto ItemDto);
        Task<ItemDto> UpdateItemAsync(ItemUpdateDto ItemDto);
        Task<bool> DeleteItemAsync(int itemId);
    }
    
}
