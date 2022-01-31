using AspNetCoreHero.ToastNotification.Abstractions;
using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using MvcWebUI.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcWebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MessagesController : Controller
    {
        IMessageService _messageService;
        INotyfService _notyfService;
        public MessagesController(IMessageService messageService, INotyfService notyfService)
        {
            _messageService = messageService;
            _notyfService = notyfService;
        }

        public IActionResult GetAll()
        {
            var model = new MessageViewModel
            {
                Messages = _messageService.GetAll().Data
            };
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            var message = _messageService.GetById(id).Data;
            _messageService.Delete(message);
            _notyfService.Error("Mesaj Silindi");
            return RedirectToAction("GetAll");
        }
    }
}
