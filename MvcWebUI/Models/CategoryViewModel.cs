using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcWebUI.Models
{
    public class CategoryViewModel
    {
        public List<Category> Categories { get; set; }
        public int[] NumberOfBlogsByCategory { get; set; }
    }
}
