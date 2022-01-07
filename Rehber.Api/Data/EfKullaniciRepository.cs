using Microsoft.EntityFrameworkCore;
using Rehber.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rehber.Api.Data
{
    public class EfKullaniciRepository:EfRepositoryEntityFramework<Kullanici,RehberContext>
    {
        public Kullanici Giris(string email,string password)
        {
            return Getir(x => x.Email == email && x.Password == password);
        }
    }
}
