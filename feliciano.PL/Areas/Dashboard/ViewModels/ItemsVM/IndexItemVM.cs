using feliciano.DAL.Model;
using feliciano.PL.Areas.Dashboard.ViewModels.PortfoliosVM;

namespace feliciano.PL.Areas.Dashboard.ViewModels.ItemsVM
{
    public class IndexItemVM
    {
        public int Id { get; set; }
        public string ImageName { get; set; }
        public string PortfolioName { get; set; }  // Add this to display the name of the portfolio
        public DateTime CreatedTime { get; set; }



    }
}
