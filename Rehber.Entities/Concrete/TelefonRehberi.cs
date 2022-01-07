using Rehber.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rehber.Entities.Concrete
{
    public class TelefonRehberi:BaseEntity
    {
        public string TelefonNumarasi { get; set; }
        public string AdSoyad { get; set; }
        public string ResimDosyasi { get; set; }
        public int KullaniciId { get; set; }
        public Kullanici Kullanici { get; set; }
    }
}
