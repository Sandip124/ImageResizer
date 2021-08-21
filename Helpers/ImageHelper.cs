using System;
using System.IO;
using System.Threading.Tasks;
using ImageMagick;
using Microsoft.AspNetCore.Http;

namespace ImageResizer.Helpers
{
    public class ImageHelper : ImageHelperInterface
    {
        public string ResizeImage(string filePath)
        {
            throw new System.NotImplementedException();
        }

        public async Task<string> UploadImageAndResize(IFormFile formFile,string tempDirectory)
        {
            var fileName = string.Empty;
            if (formFile.Length > 0)
            {
                
                var filePath = Path.Combine(tempDirectory, formFile.FileName);
                await using var stream = File.Create(filePath);
                await formFile.CopyToAsync(stream).ConfigureAwait(true);
                
                using var image = new MagickImage(filePath);
                image.Format = image.Format; // Get or Set the format of the image.
                image.Resize(40, 40); // fit the image into the requested width and height. 
                image.Quality = 10; // This is the Compression level.
                await image.WriteAsync(fileName);
            }
            return fileName;
        }
    }
}