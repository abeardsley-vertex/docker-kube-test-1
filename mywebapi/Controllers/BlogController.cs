using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using dataaccess;

namespace mywebapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BlogController
    {
        private readonly ILogger<BlogController> _logger;
        private readonly BloggingContext db;

        public BlogController(ILogger<BlogController> logger, BloggingContext db)
        {
            _logger = logger;
            this.db = db;
        }

        [HttpGet]
        public IEnumerable<Blog> Get()
        {
            return db.Blogs;
        }
    }
}