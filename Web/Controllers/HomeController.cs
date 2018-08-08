using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Dal;
using Microsoft.AspNetCore.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ToolDbContext _context;

        public HomeController(ToolDbContext context)
        {
            _context = context;
        }
         
        public OkObjectResult Index()
        {
            return Ok(_context.tuser.ToList());
        }

        public IActionResult About()
        {
            ViewData["Message"] = _context.tuser.FirstOrDefault().username;

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
