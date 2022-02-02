using AutoMapper;
using Entities.Concrete;
using MvcWebUI.Areas.Admin.Models.DataModels;
namespace MvcWebUI.AutoMapper
{
    public class BlogProfile : Profile
    {
        public BlogProfile()
        {
            CreateMap<Blog, BlogData >();
            CreateMap<BlogData, Blog>();
        }
    }
}
