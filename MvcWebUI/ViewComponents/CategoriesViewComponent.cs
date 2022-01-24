using Business.Abstract;
using Business.Concrete;
using Microsoft.AspNetCore.Mvc;
using MvcWebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcWebUI.ViewComponents
{
    public class CategoriesViewComponent : ViewComponent
    {
        ICategoryService _categoryService;
        IBlogService _blogService;
        public CategoriesViewComponent(ICategoryService categoryService, IBlogService blogService)
        {
            _categoryService = categoryService;
            _blogService = blogService;
        }

        public IViewComponentResult Invoke()
        {
            var result = _categoryService.GetAll().Data;
            int[] numbers = new int[result.Count];
            for (int i = 0; i < result.Count; i++)
            {
                numbers[i] = _blogService.GetByCategory(result[i].Id).Data.Count;
            }

            var model = new CategoryViewModel
            {
                Categories = result,
                NumberOfBlogsByCategory = numbers
            };
            return View(model);
        }
    }
}
