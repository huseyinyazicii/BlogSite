using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using MvcWebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcWebUI.ViewComponents
{
    public class CommentsViewComponent : ViewComponent
    {
        ICommentService _commentService;
        public CommentsViewComponent(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public IViewComponentResult Invoke(int id)
        {
            var model = new CommentViewModel
            {
                Comments = _commentService.GetByBlog(id).Data,
                BlogId = id
            };
            return View(model);
        }
    }
}