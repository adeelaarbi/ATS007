using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ATS007.Controllers
{
    public class AtsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("calendar")]
        public IActionResult Calendar()
        {
            return View();
        }
    }
}
