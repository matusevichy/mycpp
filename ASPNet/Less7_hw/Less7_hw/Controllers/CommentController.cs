using Less7_hw.Models;
using Less7_hw.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Less7_hw.Controllers
{
    public class CommentController : Controller
    {
        private readonly ApplicationDbContext context;

        public CommentController(ApplicationDbContext context)
        {
            this.context = context;
        }
        [HttpPost]
        [Authorize(Roles ="User")]
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
