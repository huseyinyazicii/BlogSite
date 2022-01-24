using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcWebUI.Models
{
    public class BlogViewModel
    {
        public List<BlogDetailDto> Blogs { get; set; }
        public BlogDetailDto Blog { get; set; }
    }
}
