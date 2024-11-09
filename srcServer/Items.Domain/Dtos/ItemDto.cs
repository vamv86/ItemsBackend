
namespace Items.Domain.Dtos
{
    public class ItemDto
    {
        public int ItemId { get; set; }
        public string Name { get; set; }
        public DateTime DateCreate { get; set; }
    }
    public class ItemCreateDto
    {
        public string Name { get; set; }
    }

    public class ItemUpdateDto
    {
        public int ItemId { get; set; }
        public string Name { get; set; }
    }

}
