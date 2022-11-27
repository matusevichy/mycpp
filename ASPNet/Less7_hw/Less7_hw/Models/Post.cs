namespace Less7_hw.Models
{
    public class Post: BaseModel
    {
        public string Title { get; set; }
        public DateTime Published { get; set; }
        public string Content { get; set; }
        public string? Image { get; set; }
        public List<Category> Categories { get; set; }
        public List<Comment>? Comments { get; set; }
    }
}
