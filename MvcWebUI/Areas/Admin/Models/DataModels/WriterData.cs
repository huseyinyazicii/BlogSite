using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MvcWebUI.Areas.Admin.Models.DataModels
{
    public class WriterData
    {
        [Required(ErrorMessage = "İsim zorunludur")]
        [MaxLength(50,ErrorMessage = "En fazla 50 karakter olabilir")]
        [MinLength(2,ErrorMessage = "En az 2 karakter olmalıdır")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Soyisim zorunludur")]
        [MaxLength(50, ErrorMessage = "En fazla 50 karakter olabilir")]
        [MinLength(2, ErrorMessage = "En az 2 karakter olmalıdır")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email zorunludur")]
        [MaxLength(50, ErrorMessage = "En fazla 50 karakter olabilir")]
        [MinLength(2, ErrorMessage = "En az 2 karakter olmalıdır")]
        [EmailAddress(ErrorMessage = "Email türünde olmalıdır")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifre zorunludur")]
        [MaxLength(50, ErrorMessage = "En fazla 50 karakter olabilir")]
        [MinLength(6, ErrorMessage = "En az 6 karakter olmalıdır")]
        public string Password { get; set; }
    }
}
