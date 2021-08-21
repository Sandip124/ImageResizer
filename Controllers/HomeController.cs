using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ImageResizer.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ImageResizer.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace ImageResizer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ImageHelperInterface _imageHelper;
        private readonly IWebHostEnvironment _env;

        public HomeController(ILogger<HomeController> logger, ImageHelperInterface imageHelper,IWebHostEnvironment env)
        {
            _logger = logger;
            _imageHelper = imageHelper;
            _env = env;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ImageResize(IFormFile file)
        {
            
            var image  = _imageHelper.UploadImageAndResize(file,_env.WebRootPath);

            ViewBag.resizeImage = image;

            return RedirectToAction(nameof(Index));
        }
        
    }
}