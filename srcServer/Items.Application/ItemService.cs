using AutoMapper;
using AutoMapper.QueryableExtensions;
using Items.Domain;
using Items.Domain.Dtos;
using Items.Domain.Interfaz;
using Items.Infraestructure;
using Microsoft.EntityFrameworkCore;

namespace Items.Application
{ 
    public class ItemService : IItemService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public ItemService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Author: Victor Moreno Vela
        /// Create Date: 19/10/2024
        /// Description: Obtiene un Item por su identificador.
        /// </summary>
        /// <param name="ItemId">El identificador de la Item.</param>
        /// <returns>Una tarea que representa la operación asincrónica. El resultado de la tarea será un DTO de la Item si se encuentra, de lo contrario, null.</returns>
        public async Task<ItemDto> GetItemByIdAsync(int ItemId)
        {
            var Item = await _context.Items.FindAsync(ItemId);
            return _mapper.Map<ItemDto>(Item);
        }

        /// <summary>
        /// Author: Victor Moreno Vela
        /// Create Date: 19/10/2024
        /// Description: Obtiene todas las Items.
        /// </summary>
        /// <returns>Una tarea que representa la operación asincrónica. El resultado de la tarea será una colección de DTO de Items.</returns>
        public async Task<List<ItemDto>> GetAllItemsAsync()
        {
            var Items = await _context.Items
                .ProjectTo<ItemDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return Items;
        }

        /// <summary>
        /// Author: Victor Moreno Vela
        /// Create Date: 19/10/2024
        /// Description: Crea un nueva Item.
        /// </summary>
        /// <param name="ItemDto">El DTO de la Item a crear.</param>
        /// <returns>Una tarea que representa la operación asincrónica. El resultado de la tarea será el DTO de la Item creada.</returns>
        public async Task<ItemDto> CreateItemAsync(ItemCreateDto ItemDto)
        {

            Item item = _mapper.Map<Item>(ItemDto);
  
            await _context.Items.AddAsync(item);
            await _context.SaveChangesAsync();

            return _mapper.Map<ItemDto>(item);
        }

        /// <summary>
        /// Author: Victor Moreno Vela
        /// Create Date: 19/10/2024
        /// Description: Actualiza un Item existente.
        /// </summary>
        /// <param name="ItemId">El identificador de la Item a actualizar.</param>
        /// <param name="ItemDto">El DTO de la Item con los nuevos valores.</param>
        /// <returns>Una tarea que representa la operación asincrónica. El resultado de la tarea será el DTO de la Item actualizada si se encuentra, de lo contrario, null.</returns>
        public async Task<ItemDto> UpdateItemAsync(ItemUpdateDto ItemDto)
        {
            var Item = await _context.Items.FindAsync(ItemDto.ItemId);
            if (Item == null) return null;

            _mapper.Map(ItemDto, Item);
            await _context.SaveChangesAsync();

            return _mapper.Map<ItemDto>(Item);
        }

        /// <summary>
        /// Author: Victor Moreno Vela
        /// Create Date: 19/10/2024
        /// Description: Elimina un Item existente.
        /// </summary>
        /// <param name="ItemId">El identificador de la Item a eliminar.</param>
        /// <returns>Una tarea que representa la operación asincrónica. El resultado de la tarea será true si la Item se elimina correctamente, de lo contrario, false.</returns>
        public async Task<bool> DeleteItemAsync(int ItemId)
        {
            var Item = await _context.Items.FindAsync(ItemId);
            if (Item == null) return false;

            _context.Items.Remove(Item);
            await _context.SaveChangesAsync();
            return true;
        }

  
    }
}
