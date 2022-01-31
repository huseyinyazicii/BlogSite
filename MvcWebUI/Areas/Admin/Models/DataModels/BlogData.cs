using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MvcWebUI.Areas.Admin.Models.DataModels
{
    public class BlogData
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Kategori zorunlu")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Başlık boş olamaz")]
        [MinLength(2, ErrorMessage = "En az 2 karakter içermelidir")]
        [MaxLength(100, ErrorMessage = "En fazla 100 karakter içermelidir")]
        public string Title { get; set; }

        [Required(ErrorMessage = "İçerik boş olamaz")]
        [MinLength(100, ErrorMessage = "En az 100 karakter içermelidir")]
        public string Content { get; set; }

        public IFormFile Image { get; set; }
    }
}
