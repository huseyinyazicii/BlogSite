using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcWebUI.Models
{
    public class CommentViewModel
    {
        public List<Comment> Comments { get; set; }
        public Comment Comment { get; set; }
        public int BlogId { get; set; }
    }
}