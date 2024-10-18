using feliciano.PL.Areas.Dashboard.ViewModels.PortfoliosVM;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace feliciano.PL.Areas.Dashboard.ViewModels.ItemsVM
{
    public class ItemFormVM
    {
        public int Id { get; set; }
        public string? ImageName { get; set; }
        public IFormFile Image { get; set; }
        public int? PortfolioId { get; set; }
        public SelectList? protfolios { get; set; }
        // public IEnumerable<PortfolioVM> protfolios { get; set; }
        public DateTime CreatedTime { get; set; }

    }
}
