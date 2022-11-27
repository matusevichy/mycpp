using Microsoft.AspNetCore.Mvc.Rendering;

namespace Less7_hw.Models
{
    public class ExtPostModel
    {
        public Post Post { get; set; }
        public int[] SelectedIds { get; set; }
        public List<SelectListItem> Categories { get; set; }
    }
}
