namespace feliciano.PL.Areas.Dashboard.ViewModels.BlogsVM
{
    public class BlogVM
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public DateTime CreateAt { get; set; }
        public bool IsDeleted { get; set; }
        public IFormFile Image { get; set; }
        public string? ImageName { get; set; }  
    }
}
