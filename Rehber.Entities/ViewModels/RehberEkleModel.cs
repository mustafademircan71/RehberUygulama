using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Rehber.Entities.ViewModels
{
    public class RehberEkleModel
    {
        [Required(ErrorMessage ="Bu Alan Boş Bırakılamaz")]
        [Phone(ErrorMessage ="Telefon Numarası Girilmelidir")]
        public string TelefonNumarasi { get; set; }

        [Required(ErrorMessage ="Bu Alan Boş Bırakılamaz")]
        [MinLength(2,ErrorMessage ="En Az 2 Karakter Olmalıdır")]
        public string AdSoyad { get; set; }

        public string ResimDosyasi { get; set; }

        public int KullaniciId { get; set; }
    }
}
