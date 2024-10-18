using feliciano.DAL.Model;

namespace feliciano.PL.Areas.Dashboard.ViewModels.ItemsVM
{
    public class ItemVM
    {
        public int Id { get; set; }
        public string ImageName { get; set; }
        public DateTime CreatedTime { get; set; }
        public Portfolio portfolio { get; set; }


    }
}
