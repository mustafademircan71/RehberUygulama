using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.JsonWebTokens;
using Rehber.Api.Data;
using Rehber.Api.Extensions;
using Rehber.Api.Utilities.Common;
using Rehber.Entities.Concrete;
using Rehber.Entities.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace Rehber.Api.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class KullaniciController : Controller
    {
        [HttpPost("Giris")]
        public IActionResult Giris([FromBody] KullaniciGirisModel m)
        {
            Kullanici kullanici = new EfKullaniciRepository().Giris(m.Email, m.Password);
            if (kullanici != null)
            {
                HttpContext.Session.SetObjcet("ActiveKullanici", kullanici);
                return Json(new { Result = true, kullanici.Id });
            }

            return Json(new { Result = false });
        }

        [HttpGet("{id}")]
        public IActionResult Liste(int id)
        {
            List<TelefonRehberi> telefonRehberi = new EfTelefonRehberiRepository().Listele(x => x.KullaniciId == id);

            return Json(telefonRehberi);
        }
        [HttpPost("Liste")]
        public IActionResult Listele(int id)
        {
            List<TelefonRehberi> telefonRehberleri = new EfTelefonRehberiRepository().Listele(x => x.KullaniciId == id);

            return Json(telefonRehberleri);
        }
        [HttpPost("Resim")]
        public IActionResult ResimEkle()
        {
            IFormFileCollection dosya = Request.Form.Files;

            if (dosya.Count > 0)
            {
                if (!dosya[0].ContentType.StartsWith("image/"))
                {
                    return Json(new { Result = false, Message = "Lütfen Sadece Resim Dosyası Seçiniz" });
                }
                if (dosya[0].Length > (100 * 1024))
                {
                    return Json(new { Result = true, Message = "Lütfen 100 Kbden Küçük Dosya Seçiniz" });
                }
                var originDosyaAdı = dosya[0].FileName;
                var dosyAdi = RastgeleDeger.DoysaAdiOlustur(originDosyaAdı);

                var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "C:\\Users\\Mustafa\\Desktop\\RehberUygulama\\RehberUygulama\\Rehber.UI\\wwwroot\\resim\\rehberResim\\", dosyAdi);

                using (var fileStream = new FileStream(uploadPath, FileMode.Create))
                {
                    dosya[0].CopyTo(fileStream);
                }
                return Json(new { Result = true, PhotoPath = "/resim/rehberResim/" + dosyAdi });
            }
            else
            {
                return Json(new { Result = false, Message = "Lütfen Dosya Seçiniz" });
            }
        }
        [HttpPost("Ekle")]
        public IActionResult Ekle(RehberEkleModel m)
        {
           
            TelefonRehberi telefonRehberi = new TelefonRehberi();

            telefonRehberi.AdSoyad = m.AdSoyad;
            telefonRehberi.TelefonNumarasi = m.TelefonNumarasi;
            telefonRehberi.KullaniciId = m.KullaniciId;
            telefonRehberi.ResimDosyasi = m.ResimDosyasi;

            new EfTelefonRehberiRepository().Kaydet(telefonRehberi);

            return Json(new { Result = true, Messages = "Kayıt Başarılı" });
        }
        [HttpPost("Kullanici_Ekle")]
        public IActionResult Kullanici_Ekle([FromBody]KullaniciEkleModel m)
        {
            Kullanici kullanici = new Kullanici();

            kullanici.Email = m.Email;
            kullanici.Password = m.Password;
            kullanici.TelefonNumarasi = m.TelefonNumarasi;
            kullanici.AdSoyad = m.AdSoyad;
            if (m!=null)
            {
                new EfKullaniciRepository().Kaydet(kullanici);

                return Json(new { Result = true });
            }
            else
            {
                return Json(new { Result = false });
            }
           
        }
        [HttpPost("Sil")]
        public IActionResult Sil(int id)
        {
            TelefonRehberi telefonRehberi = new EfTelefonRehberiRepository().IdGetir(id);

            new EfTelefonRehberiRepository().Sil(telefonRehberi);

            return Json(new { Result = true });
        }
        [HttpPost("Detay")]
        public IActionResult Detay(int id)
        {
            TelefonRehberi telefonRehberi = new EfTelefonRehberiRepository().IdGetir(id);

            RehberModelDetay m = new RehberModelDetay();
            m.AdSoyad = telefonRehberi.AdSoyad;
            m.Id = telefonRehberi.Id;
            m.TelefonNumarasi = telefonRehberi.TelefonNumarasi;
            m.ResimDosyasi = telefonRehberi.ResimDosyasi;
            return Json(new { RehberInfo = m});
        }
        [HttpPost("Duzenle")]
        public IActionResult Duzenle(RehberDuzenleModel m)
        {
            TelefonRehberi telefonRehberi = new EfTelefonRehberiRepository().IdGetir(m.Id);

            telefonRehberi.AdSoyad = m.AdSoyad;
            telefonRehberi.TelefonNumarasi = m.TelefonNumarasi;
            telefonRehberi.Id = m.Id;
            telefonRehberi.ResimDosyasi = m.ResimDosyasi;

            new EfTelefonRehberiRepository().Güncelle(telefonRehberi);

            return Json(new { Resut = true });

        }

   
    }
}
