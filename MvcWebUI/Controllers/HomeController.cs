using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using MvcWebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcWebUI.Controllers
{
    public class HomeController : Controller
    {
        IBlogService _blogService;
        public HomeController(IBlogService blogService)
        {
            _blogService = blogService;
        }
        public IActionResult Index()
        {
            var model = new BlogViewModel
            {
                Blogs = _blogService.GetAllWithDetail(3).Data
            };
            return View(model);
        }
    }
}
