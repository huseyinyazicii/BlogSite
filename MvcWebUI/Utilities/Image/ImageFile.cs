using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MvcWebUI.Utilities.Image
{
    public static class ImageFile
    {
        public static string Add(IFormFile image, string path)
        {
            var extension = Path.GetExtension(image.FileName);
            var newImageName = Guid.NewGuid() + extension;
            var location = Path.Combine(Directory.GetCurrentDirectory(), path, newImageName);
            var stream = new FileStream(location, FileMode.Create);
            image.CopyTo(stream);
            return newImageName;
        }
    }
}