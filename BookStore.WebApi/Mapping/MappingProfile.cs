using AutoMapper;
using BookStore.EntityLayer.Concrete;
using BookStore.WebApi.Dtos.Category;
using BookStore.WebApi.Dtos.Product;
using BookStore.WebApi.Dtos.Quote;

namespace BookStore.WebApi.Mapping
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryResultDto>().ReverseMap();
            CreateMap<Category, CategoryCreateDto>().ReverseMap();
            CreateMap<Category, CategoryGetByIdDto>().ReverseMap();
            CreateMap<Category, CategoryUpdateDto>().ReverseMap();


            CreateMap<Product,ProductCreateDto>().ReverseMap();
            CreateMap<Product,ProductResultDto>().ReverseMap();
            CreateMap<Product,ProductUpdateDto>().ReverseMap();
            CreateMap<Product,ProductGetByIdDto>().ReverseMap();
           
            
            
            CreateMap<Quote,QuoteResultDto>().ReverseMap();
            CreateMap<Quote,QuoteUpdateDto>().ReverseMap();
            CreateMap<Quote,QuoteCreateDto>().ReverseMap();
            CreateMap<Quote,QuoteGetByIdDto>().ReverseMap();

        }

        
    }
}
