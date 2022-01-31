using AspNetCoreHero.ToastNotification.Abstractions;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using MvcWebUI.Models;
using MvcWebUI.Utilities.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcWebUI.Controllers
{
    public class CommentsController : Controller
    {
        ICommentService _commentService;
        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public void AddComment(Comment comment)
        {
            comment.Status = true;
            comment.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            _commentService.Add(comment);
        }
    }
}
