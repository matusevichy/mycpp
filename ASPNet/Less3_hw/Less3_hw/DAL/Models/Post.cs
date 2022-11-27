namespace Less3_hw.DAL.Models
{
    public class Post: BaseModel
    {
        public string Title { get; set; }
        public DateTime Published { get; set; }
        public string Content { get; set; }
        public List<Category> Categories { get; set; }
    }
}
