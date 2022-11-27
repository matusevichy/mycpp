namespace Less3_hw.DAL.Models
{
    public class Category: BaseModel
    {
        public string Name { get; set; }
        public List<Post> Posts { get; set; }
    }
}
