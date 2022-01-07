using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Rehber.Api.Extensions;
using Rehber.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rehber.Api.Aspects
{
    public class SessionAspect:ActionFilterAttribute,IActionFilter
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Kullanici activeKullanıcı = context.HttpContext.Session.GetObject<Kullanici>("ActiveKullanici");
            if (activeKullanıcı==null)
            {
                context.Result = new RedirectToActionResult("Giris", "Kullanici", null);
            }
        }
    }
}
