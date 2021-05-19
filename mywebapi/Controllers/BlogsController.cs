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
    public class BlogsController
    {
        private readonly ILogger<BlogsController> _logger;
        private readonly BloggingContext db;

        public BlogsController(ILogger<BlogsController> logger, BloggingContext db)
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