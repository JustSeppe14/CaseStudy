using bike_site.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Contentful.Core;
using Contentful.Core.Search;

namespace bike_site.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IContentfulClient _client;

        public HomeController(ILogger<HomeController> logger, IContentfulClient client)
        {
            _client = client;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var qb = QueryBuilder<Bikes>.New.ContentTypeIs("bikeSite");

            var bike = await _client.GetEntries(qb);
            return View(bike);
        }

        public async Task<IActionResult> Details(string id)
        {
            var qb = QueryBuilder<Bikes>.New.ContentTypeIs("bikeSite").FieldEquals(f => f.Slug, id.ToLower());

            var entry = (await _client.GetEntries(qb)).FirstOrDefault();

            return View(entry);
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
