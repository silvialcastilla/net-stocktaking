using AutoMapper;
using StockTaking.Entities;
using StockTaking.DTOs.Category;

namespace StockTaking.WebApi.Mapper
{
    public class MappingProfiles: Profile
    {
        public MappingProfiles(){
            CreateMap<CategoryToCreateDto, Category>();
            CreateMap<CategoryToEditDto, Category>();
            //we want to create de dto when we get the info from db
            CreateMap<Category, CategoryToListDto>();
        }
    }
}