using Entities.Concrete;
using MvcWebUI.Areas.Admin.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcWebUI.Areas.Admin.Models
{
    public class BlogViewModel
    {
        public List<Blog> Blogs { get; set; }
        public List<Category> Categories { get; set; }
        public BlogData BlogData { get; set; }
    }
}
