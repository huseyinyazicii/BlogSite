using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using MvcWebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcWebUI.ViewComponents
{
    public class LastBlogsViewComponent : ViewComponent
    {
        IBlogService _blogService;
        public LastBlogsViewComponent(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public IViewComponentResult Invoke()
        {
            var model = new BlogViewModel
            {
                Blogs = _blogService.GetAllWithDetail(5).Data
            };
            return View(model);
        }
    }
}
