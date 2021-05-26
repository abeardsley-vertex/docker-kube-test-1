using System;
using System.Collections.Generic;
using System.Collections;
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
            var delete = db.Blogs
                .OrderByDescending(b => b.BlogId)
                .Skip(10);
            db.Blogs.RemoveRange(delete);
            db.SaveChanges();

            db.Blogs.Add(new Blog{
                Url = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString() + DateTime.Now.Millisecond
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
