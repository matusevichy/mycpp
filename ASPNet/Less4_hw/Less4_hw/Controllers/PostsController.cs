using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Less4_hw.DB;
using Less4_hw.Models;

namespace Less4_hw.Controllers
{
    public class PostsController : Controller
    {
        private readonly BlogContext _context;

        public PostsController(BlogContext context)
        {
            _context = context;
        }

        // GET: Posts
        public async Task<IActionResult> Index(int? categoryId)
        {
            List<SelectListItem> categoryList = _context.Categories.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name }).ToList();
            ViewBag.categoryId = categoryList;
            var tmpList = await _context.Posts.Include(p => p.Categories).OrderByDescending(p => p.Published).ToListAsync();
            if (categoryId != null)
            {
                var cat = _context.Categories.FirstOrDefault(c => c.Id == categoryId);
                if (cat != null)
                {
                    return View(tmpList.Where(p => p.Categories.Contains(cat)));
                }
                return View(tmpList);
            }
            return View(tmpList);
        }

        // GET: Posts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Posts == null)
            {
                return NotFound();
            }

            var post = await _context.Posts.Include(p=>p.Categories).Include(p => p.Comments).FirstOrDefaultAsync(m => m.Id == id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // GET: Posts/Create
        public IActionResult Create()
        {
            ExtPostModel model = new ExtPostModel();
            model.Categories = _context.Categories.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name }).ToList();
            return View(model);
        }

        // POST: Posts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Image, Published,Content,Id")] Post post, [Bind("SelectedIds")] int[] SelectedIds)
        {
            if (post != null)
            {
                var postCategories = _context.Categories.Where(c => SelectedIds.Contains(c.Id)).ToList();
                post.Categories = postCategories;
                _context.Add(post);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(post);
        }

        // GET: Posts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Posts == null)
            {
                return NotFound();
            }

            var post = await _context.Posts.Include(p=>p.Categories).FirstOrDefaultAsync(p=>p.Id==id);
            if (post == null)
            {
                return NotFound();
            }
            ExtPostModel model = new ExtPostModel();
            model.Categories = _context.Categories.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name }).ToList();
            model.Post = post;
            model.SelectedIds = post.Categories.Select(i => i.Id).ToArray();
            return View(model);
        }

        // POST: Posts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Title,Published,Content,Id")] Post post, [Bind("SelectedIds")] int[] SelectedIds)
        {
            if (id != post.Id)
            {
                return NotFound();
            }

            if (post!=null)
            {
                try
                {
                    var postCategories = _context.Categories.Where(c => SelectedIds.Contains(c.Id)).ToList();
                    var oldPost = _context.Posts.Include(p=>p.Categories).FirstOrDefault(p=>p.Id == post.Id);
                    _context.Remove(oldPost);
                    await _context.SaveChangesAsync();
                    post.Categories = postCategories;
                    post.Id = 0;
                    _context.Add(post);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostExists(post.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(ViewBag.model);
        }

        // GET: Posts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Posts == null)
            {
                return NotFound();
            }

            var post = await _context.Posts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Posts == null)
            {
                return Problem("Entity set 'BlogContext.Posts'  is null.");
            }
            var post = await _context.Posts.FindAsync(id);
            if (post != null)
            {
                _context.Posts.Remove(post);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public async Task<IActionResult> Search(string searchText)
        {
            if (searchText != null)
            {
                var tmpList = await _context.Posts.Include(p => p.Categories).ToListAsync();
                return View("Index", tmpList.Where(p => p.Content.Contains(searchText.Trim(), StringComparison.OrdinalIgnoreCase)).OrderByDescending(p => p.Published));
            }
            return RedirectToAction(nameof(Index));
        }
        private bool PostExists(int id)
        {
          return _context.Posts.Any(e => e.Id == id);
        }
    }
}
