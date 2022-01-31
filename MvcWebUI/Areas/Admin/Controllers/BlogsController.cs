using AspNetCoreHero.ToastNotification.Abstractions;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using MvcWebUI.Areas.Admin.Models;
using MvcWebUI.Areas.Admin.Models.DataModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MvcWebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogsController : Controller
    {
        IBlogService _blogService;
        INotyfService _notyfService;
        ICategoryService _categoryService;
        public BlogsController(IBlogService blogService, INotyfService notyfService, ICategoryService categoryService)
        {
            _blogService = blogService;
            _notyfService = notyfService;
            _categoryService = categoryService;
        }

        public IActionResult Blogs()
        {
            var model = new BlogViewModel
            {
                Blogs = _blogService.GetAll().Data
            };
            return View(model);
        }

        public IActionResult Add()
        {
            var model = new BlogViewModel
            {
                BlogData = new BlogData(),
                Categories = _categoryService.GetAll().Data
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(BlogData blogData)
        {
            if (!ModelState.IsValid)
            {
                var model = new BlogViewModel
                {
                    BlogData = blogData,
                    Categories = _categoryService.GetAll().Data
                };
                return View(model);
            }
            var blog = new Blog();
            if(blogData.Image != null)
            {
                var extension = Path.GetExtension(blogData.Image.FileName);
                var newImageName = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/Blogs/", newImageName);
                var stream = new FileStream(location, FileMode.Create);
                blogData.Image.CopyTo(stream);
                blog.Image = newImageName;
            }
            else
            {
                blog.Image = "defaultBlog.jpg";
            }
            blog.CategoryId = blogData.CategoryId;
            blog.WriterId = 2;
            blog.Title = blogData.Title;
            blog.Content = blogData.Content;
            blog.NumberOfComments = 0;
            blog.NumberOfLikes = 0;
            blog.Status = true;
            blog.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            _blogService.Add(blog);
            _notyfService.Success("Blog Eklendi");
            return RedirectToAction("Blogs");
        }
    }
}
