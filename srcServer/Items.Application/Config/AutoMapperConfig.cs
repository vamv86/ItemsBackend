using AutoMapper;
using Items.Domain;
using Items.Domain.Dtos;

namespace Items.Application.Config
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig() 
        {
            CreateMap<ItemDto, Item>().ReverseMap();
            CreateMap<ItemCreateDto, Item>().ReverseMap();
            CreateMap<ItemUpdateDto, Item>().ReverseMap();            
        }
    }
}
