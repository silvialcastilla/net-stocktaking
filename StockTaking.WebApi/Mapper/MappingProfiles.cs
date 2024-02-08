using AutoMapper;
using StockTaking.Entities;
using StockTaking.DTOs.Category;
using StockTaking.DTOs.StockTakingMovement;
using StockTaking.DTOs.StockTakingStock;
using StockTaking.DTOs.MovementType;
using StockTaking.DTOs.Product;
using StockTaking.DTOs.Supplier;

namespace StockTaking.WebApi.Mapper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            //Category
            CreateMap<CategoryToCreateDto, Category>();
            CreateMap<CategoryToEditDto, Category>();
            //we want to create de dto when we get the info from db
            CreateMap<Category, CategoryToListDto>();

            //StockTakingMovement
            CreateMap<StockTakingMovementToCreateDto, StockTakingMovement>();
            CreateMap<StockTakingMovementToEditDto, StockTakingMovement>();
            CreateMap<StockTakingMovement, StockTakingMovementToListDto>()
                .ForMember(dest => dest.MovementTypeName, opt => opt.MapFrom(src => src.MovementType.Name))
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name));

            //StockTakingStock
            CreateMap<StockTakingStockToCreateDto, StockTakingStock>();
            CreateMap<StockTakingStockToEditDto, StockTakingStock>();
            CreateMap<StockTakingStock, StockTakingStockToListDto>() 
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name));

            //MovementType
            CreateMap<MovementTypeToCreateDto, MovementType>();
            CreateMap<MovementTypeToEditDto, MovementType>();
            CreateMap<MovementType, MovementTypeToListDto>();

            
            //MovementType
            CreateMap<ProductToCreateDto, Product>();
            CreateMap<ProductToEditDto, Product>();
            CreateMap<Product, ProductToListDto>()
                 .ForMember(dest => dest.SupplierName, opt => opt.MapFrom(src => src.Supplier.Name))
                 .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));

            //MovementType
            CreateMap<SupplierToCreateDto, Supplier>();
            CreateMap<SupplierToEditDto, Supplier>();
            CreateMap<Supplier, SupplierToListDto>();
        }
    }
}