using Api.ViewModels.Products;
using AutoMapper;
using CleanArch.Query.Models.Products;

namespace Api
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<ProductReadModel , ProductVm>().ReverseMap();
        }
    }
}
