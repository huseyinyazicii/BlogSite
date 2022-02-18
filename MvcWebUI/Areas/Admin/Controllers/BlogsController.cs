using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MvcWebUI.Areas.Admin.Models;
using MvcWebUI.Areas.Admin.Models.DataModels;
using MvcWebUI.Utilities.Image;
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
        public IActionResult Add(BlogData blogData, IFormFile image)
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
            if(image != null)
            {
                blog.Image = ImageFile.Add(image, "wwwroot/Images/Blogs/");
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

        public IActionResult Update(int id)
        {
            var blog = _blogService.GetById(id).Data;
            BlogData blogData = new BlogData
            {
                Id = blog.Id,
                CategoryId = blog.CategoryId,
                Content = blog.Content,
                Title = blog.Title
            };
            var model = new BlogViewModel
            {
                BlogData = blogData,
                Categories = _categoryService.GetAll().Data
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Update(BlogData blogData, IFormFile image)
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

            var blog = _blogService.GetById(blogData.Id).Data;

            if (blogData.Image != null)
            {
                blog.Image = ImageFile.Add(image, "wwwroot/Images/Blogs/");
            }

            blog.CategoryId = blogData.CategoryId;
            blog.Title = blogData.Title;
            blog.Content = blogData.Content;
            _blogService.Update(blog);
            _notyfService.Warning("Blog Güncellendi");
            return RedirectToAction("Blogs");
        }

        public IActionResult Delete(int id)
        {
            var blog = _blogService.GetById(id).Data;
            blog.Status = false;
            _blogService.Update(blog);
            _notyfService.Error("Blog Silindi");
            return RedirectToAction("Blogs");
        }
    }
}