using Rehber.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rehber.Entities.Concrete
{
    public class Kullanici:BaseEntity
    {
        public string AdSoyad { get; set; }
        public string TelefonNumarasi { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ICollection<TelefonRehberi> TelefonRehberleri { get; set; }
    }
}
