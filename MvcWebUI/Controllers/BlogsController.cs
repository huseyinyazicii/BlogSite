using AspNetCoreHero.ToastNotification.Abstractions;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using MvcWebUI.Models;
using MvcWebUI.Utilities.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcWebUI.Controllers
{
    public class BlogsController : Controller
    {
        IBlogService _blogService;
        ICommentService _commentService;
        INotyfService _notyfService;
        public BlogsController(IBlogService blogService, ICommentService commentService, INotyfService notyfService)
        {
            _blogService = blogService;
            _commentService = commentService;
            _notyfService = notyfService;
        }

        public IActionResult Blogs(int id = 0) // category id
        {
             
            var model = new BlogViewModel
            {
                Blogs = id == 0 ? _blogService.GetAllWithDetail().Data : _blogService.GetByCategory(id).Data
            };
            return View(model);
        }

        public IActionResult BlogDetails(int id)  //blog id
        {
            var model = new BlogViewModel
            {
                Blog = _blogService.GetBlogDetailsById(id).Data
            };
            return View(model);
        }
    }
}
