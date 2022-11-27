﻿using Less7_hw.Areas.Identity.Pages.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Less7_hw.Controllers
{
    [Authorize(Roles = "Admin,User")]
    public class UploadController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private const string imagesDir = "images";
        private readonly string imagesPath;

        public UploadController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
            imagesPath = Path.Combine(_webHostEnvironment.WebRootPath, imagesDir);
        }

        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile uploadImage)
        {
            if (uploadImage != null)
            {
                var imagePath = Path.Combine(imagesPath, uploadImage.FileName);
                using var file = new FileStream(imagePath, FileMode.Create, FileAccess.Write);
                await uploadImage.CopyToAsync(file);
                var newPath = imagePath.Replace(_webHostEnvironment.WebRootPath, "");
                return Json(newPath);
            }
            ;
            return Json("");
        }
    }
}
