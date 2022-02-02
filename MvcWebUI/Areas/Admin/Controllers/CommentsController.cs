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
    public class CommentsController : Controller
    {
        ICommentService _commentService;
        IBlogService _blogService;
        INotyfService _notyfService;

        public CommentsController(ICommentService commentService, IBlogService blogService, INotyfService notyfService)
        {
            _commentService = commentService;
            _blogService = blogService;
            _notyfService = notyfService;
        }

        public IActionResult GetByBlogId(int id)
        {
            var blog = _blogService.GetById(id).Data;
            var comments = _commentService.GetByBlog(blog.Id).Data;
            var model = new CommentViewModel
            {
                Comments = comments
            };
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            var comment = _commentService.GetById(id).Data;
            _commentService.Delete(comment);
            _notyfService.Error("Yorum Silindi");
            return Redirect("/Admin/Comments/GetByBlogId/" + comment.BlogId);
        }
    }
}
