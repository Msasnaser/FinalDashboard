using AutoMapper;
using feliciano.DAL.Model;
using feliciano.PL.Areas.Dashboard.ViewModels.BlogsVM;
using feliciano.PL.Areas.Dashboard.ViewModels.ItemsVM;
using feliciano.PL.Areas.Dashboard.ViewModels.PortfoliosVM;
using feliciano.PL.Areas.Dashboard.ViewModels.ServicesVM;
using feliciano.PL.Areas.Dashboard.ViewModels.SlidersVM;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace feliciano.PL.Mapping
{
    public class MappingProfile :Profile
    {
        public MappingProfile() {

            //services Mapping
            CreateMap<ServiceFormVM,Service>();
            CreateMap<Service,DetailsServiceVM>();
            CreateMap<Service, IndexServiceVM>();
            CreateMap<Service, ServiceVM>().ReverseMap();

            // Blogs Mapping
            CreateMap<BlogVM, Blog>().ReverseMap();
            CreateMap<Blog, IndexBlogVM>();
            CreateMap<Blog, DetailsBlogVM>();

            //Portfolio Mapping

            CreateMap<Portfolio, PortfolioVM>().ReverseMap();

            //Item Mapping
            CreateMap<IndexItemVM, Item>().ReverseMap();
            CreateMap<ItemVM, Item>().ReverseMap();
            CreateMap<Item,ItemFormVM>().ReverseMap();

            //Slider Mapping
            CreateMap<Slider, SliderVM>().ReverseMap();
            CreateMap<Slider, SliderDetailsVM>();


        }
    }
}
