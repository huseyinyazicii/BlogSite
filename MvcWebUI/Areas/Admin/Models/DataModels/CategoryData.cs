using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MvcWebUI.Areas.Admin.Models.DataModels
{
    public class CategoryData
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "İsim girilmesi zorunludur")]
        [MinLength(3, ErrorMessage = "En az 3 harf içermelidir")]
        public string Name { get; set; }
    }
}