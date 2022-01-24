using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using MvcWebUI.Models;
using MvcWebUI.Utilities.Constants;

namespace MvcWebUI.Controllers
{
    public class ContactController : Controller
    {
        protected IMapper Mapper { get; }
        IMessageService _messageService;
        INotyfService _notyfService;
        public ContactController(IMapper mapper, IMessageService messageService, INotyfService notyfService)
        {
            Mapper = mapper;
            _messageService = messageService;
            _notyfService = notyfService;
        }

        public IActionResult Index()
        {
            //var model = new MessageViewModel();
            return View();
        }

        [HttpPost]
        public IActionResult Message(MessageViewModel messageViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", messageViewModel);
            }
            Message message = Mapper.Map<Message>(messageViewModel);
            _messageService.Add(message);
            _notyfService.Success(NotyfMessages.MessageSended);
            return View("Index");
            //return RedirectToAction("Index");
        }
    }
}
