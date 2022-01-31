using AspNetCoreHero.ToastNotification.Abstractions;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using MvcWebUI.Areas.Admin.Models;
using MvcWebUI.Areas.Admin.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcWebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriesController : Controller
    {
        ICategoryService _categoryService;
        INotyfService _notyfService;
        public CategoriesController(ICategoryService categoryService, INotyfService notyfService)
        {
            _categoryService = categoryService;
            _notyfService = notyfService;
        }

        public IActionResult GetAll()
        {
            var model = new CategoryViewModel
            {
                Categories = _categoryService.GetAll().Data
            };
            return View(model);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(CategoryData categoryData)
        {
            if (!ModelState.IsValid)
            {
                return View(categoryData);
            }
            var category = new Category
            {
                Name = categoryData.Name,
                Status = true
            };
            _categoryService.Add(category);
            _notyfService.Success("Kategori Eklendi");
            return RedirectToAction("GetAll");
        }

        public IActionResult Delete(int id)
        {
            var category = _categoryService.GetById(id).Data;
            category.Status = false;
            _categoryService.Update(category);
            _notyfService.Error("Kategori Silindi");
            return RedirectToAction("GetAll");
        }

        public IActionResult Update(int id)
        {
            var category = _categoryService.GetById(id).Data;
            var model = new CategoryData
            {
                Id = id,
                Name = category.Name
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Update(CategoryData categoryData)
        {
            if (!ModelState.IsValid)
            {
                return View(categoryData);
            }
            var category = _categoryService.GetById(categoryData.Id).Data;
            category.Name = categoryData.Name;
            _categoryService.Update(category);
            _notyfService.Information("Kategori Güncellendi");
            return RedirectToAction("GetAll");
        }
    }
}
