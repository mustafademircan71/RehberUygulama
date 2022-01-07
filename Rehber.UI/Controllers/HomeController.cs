using Microsoft.AspNetCore.Mvc;
using Rehber.Api.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rehber.UI.Controllers
{
    [SessionAspect]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
