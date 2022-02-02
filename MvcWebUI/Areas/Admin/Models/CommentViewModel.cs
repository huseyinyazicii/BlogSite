using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcWebUI.Areas.Admin.Models
{
    public class CommentViewModel
    {
        public List<Comment> Comments { get; set; }
    }
}
