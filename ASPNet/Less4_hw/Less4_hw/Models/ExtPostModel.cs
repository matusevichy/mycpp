using Microsoft.AspNetCore.Mvc.Rendering;

namespace Less4_hw.Models
{
    public class ExtPostModel
    {
        public Post Post { get; set; }
        public int[] SelectedIds { get; set; }
        public List<SelectListItem> Categories { get; set; }
    }
}
