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
    public class StatisticsController : Controller
    {
        IBlogService _blogService;
        ICommentService _commentService;
        ICategoryService _categoryService;
        IMessageService _messageService;
        IWriterService _writerService;
        public StatisticsController(IBlogService blogService, ICommentService commentService, 
                                    ICategoryService categoryService, IMessageService messageService, IWriterService writerService)
        {
            _blogService = blogService;
            _commentService = commentService;
            _categoryService = categoryService;
            _messageService = messageService;
            _writerService = writerService;
        }

        public IActionResult Information()
        {
            var model = new StatisticViewModel
            {
                NumberOfBlogs = _blogService.NumberOfBlogs().Data,
                NumberOfCategories = _categoryService.NumberOfCategories().Data,
                NumberOfComments = _commentService.NumberOfComments().Data,
                NumberOfMessages = _messageService.NumberOfMessages().Data,
                NumberOfWriters = _writerService.NumberOfWriters().Data
            };
            return View(model);
        }
    }
}
