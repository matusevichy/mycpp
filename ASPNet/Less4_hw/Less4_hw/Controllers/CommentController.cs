using Less4_hw.DB;
using Less4_hw.Models;
using Microsoft.AspNetCore.Mvc;

namespace Less4_hw.Controllers
{
    public class CommentController : Controller
    {
        private readonly BlogContext context;

        public CommentController(BlogContext context)
        {
            this.context = context;
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("UserName, Message")] Comment comment, [Bind("PostId")] int postId)
        {
            if (comment.UserName != null && comment.Message != null)
            {
                var post = context.Posts.FirstOrDefault(p => p.Id == postId);
                if (post != null)
                {
                    comment.Post = post;
                    context.Add(comment);
                    await context.SaveChangesAsync();
                }
            }
            return RedirectToAction("Details","Posts",new { id = postId });
        }
    }
}
