using LinqToDB;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;
using Rehber.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Rehber.Api.Data
{
    public class RehberContext:DbContext
    {
        public RehberContext()
        {

        }
        public RehberContext(DbContextOptions<RehberContext> options)
            :base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfigurationRoot config = builder.Build();
            optionsBuilder.UseSqlServer(config.GetConnectionString("DatabaseConnection"));
        }

        public DbSet<TelefonRehberi> TelefonRehberleri { get; set; }
        public DbSet<Kullanici> Kullanicilar { get; set; }
    }
}
