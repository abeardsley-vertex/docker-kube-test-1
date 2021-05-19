using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mvc_web_app.Models;

using dataaccess;

namespace mvc_web_app.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BloggingContext db;

        public HomeController(ILogger<HomeController> logger, BloggingContext db)
        {
            _logger = logger;
            this.db = db;
        }

        public IActionResult Index()
        {
            db.Blogs.Add(new Blog{
                Url = "https://" + Guid.NewGuid().ToString().Replace("-", "")
            });
            db.SaveChanges();

            var urls = db.Blogs
                .Select(b => b.Url)
                .ToList();

            var model = new Models.Home.HomeModel{
                Urls = urls
            };

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
