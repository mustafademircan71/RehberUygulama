using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Rehber.Entities.ViewModels
{
    public class KullaniciGirisModel
    {
        [Required(ErrorMessage ="Bu Alan Boş Bırakılamaz")]
        [EmailAddress(ErrorMessage ="Email Formatında Olmalıdır")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Bu Alan Boş Bırakılamaz")]
        public string Password { get; set; }
    }
}
