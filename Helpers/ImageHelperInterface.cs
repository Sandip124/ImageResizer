using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ImageResizer.Helpers
{
    public interface ImageHelperInterface
    {
        /// <summary>
        /// Resize image for the given file path
        /// </summary>
        /// <param name="filePath">Path of a file that is being resized</param>
        /// <returns>Returns the resized image file</returns>
        string ResizeImage(string filePath);

        /// <summary>
        /// Upload image and resize file
        /// </summary>
        /// <param name="formFile"> IFormFile that is being  resized.</param>
        /// <returns>Returns the resized image file.</returns>
        Task<string> UploadImageAndResize(IFormFile formFile,string tempDirectory);
    }
}