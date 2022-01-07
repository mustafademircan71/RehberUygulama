using Microsoft.AspNetCore.Mvc;
using Rehber.Api.Aspects;
using Rehber.Api.Data;
using Rehber.Api.Extensions;
using Rehber.Entities.Concrete;
using Rehber.Entities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rehber.UI.Controllers
{
    public class KullaniciController : Controller
    {
        public IActionResult Giris()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Giris([FromBody]KullaniciGirisModel m)
        {
            Kullanici kullanici = new EfKullaniciRepository().Giris(m.Email, m.Password);
            if (kullanici!=null)
            {
                HttpContext.Session.SetObjcet("ActiveKullanici", kullanici);
                return Json(new { Result = true });
            }
            return Json(new { Result = false });
            
        }
        [SessionAspect]
        public IActionResult Liste()
        {
            return View();
        }
        [SessionAspect]
        public IActionResult Ekle()
        {
           return View();
        }
        [SessionAspect]
        public IActionResult Cikis()
        {
            HttpContext.Session.Clear();

            return View("Giris");
        }
        
        public IActionResult KayıtOl()
        {
            return View();
        }
        [SessionAspect]
        [HttpPost]
        public IActionResult Test(List<int> list)
        {
            return View();
        }
    
    }
}
