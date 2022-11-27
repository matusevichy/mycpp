namespace Less7_hw.Models
{
    public class Category: BaseModel
    {
        public string Name { get; set; }
        public List<Post> Posts { get; set; }
    }
}
