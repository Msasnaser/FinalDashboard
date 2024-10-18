namespace feliciano.PL.Areas.Dashboard.ViewModels.SlidersVM
{
    public class SliderVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? ImageName { get; set; }
        public DateTime CreatedTime { get; set; }

        public IFormFile Image { get; set; }
    }
}
