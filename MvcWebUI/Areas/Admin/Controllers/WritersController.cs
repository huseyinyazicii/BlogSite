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
    public class WritersController : Controller
    {
        IWriterService _writerService;
        INotyfService _notyfService;
        public WritersController(IWriterService writerService, INotyfService notyfService)
        {
            _writerService = writerService;
            _notyfService = notyfService;
        }

        public IActionResult GetAll()
        {
            var model = new WriterViewModel
            {
                Writers = _writerService.GetAll().Data
            };
            return View(model);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(WriterData writerData)
        {
            if(!ModelState.IsValid)
            {
                return View(writerData);
            }
            var writer = new Writer
            {
                FirstName = writerData.FirstName,
                LastName = writerData.LastName,
                Email = writerData.Email,
                Password = writerData.Password,
                Status = true
            };
            _writerService.Add(writer);
            _notyfService.Success("Yazar Eklendi");
            return RedirectToAction("GetAll");
        }

        public IActionResult Delete(int id)
        {
            var writer = _writerService.GetById(id).Data;
            writer.Status = false;
            _writerService.Update(writer);
            _notyfService.Error("Yazar Silindi");
            return RedirectToAction("GetAll");
        }
    }
}
