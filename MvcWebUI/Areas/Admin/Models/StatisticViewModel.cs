using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcWebUI.Areas.Admin.Models
{
    public class StatisticViewModel
    {
        public int NumberOfBlogs { get; set; }
        public int NumberOfCategories { get; set; }
        public int NumberOfComments { get; set; }
        public int NumberOfMessages { get; set; }
        public int NumberOfWriters { get; set; }
    }
}
