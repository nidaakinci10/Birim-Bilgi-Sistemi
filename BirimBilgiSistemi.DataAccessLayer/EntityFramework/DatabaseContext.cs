using BirimBilgiSistemi.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace BirimBilgiSistemi.DataAccessLayer.EntityFramework
{
    //veritabanı tablolarını burada oluşturuyoruz
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("MyDBContext")
        {
        }
        //dbsetler
        public DbSet<personel> Personel { get; set; }
        public DbSet<egitimBilgileri> EgitimBilgileri { get; set; }
        public DbSet<baskanlik> Baskanlik { get; set; }
        public DbSet<dosya> Dosya { get; set; }
        public DbSet<gorev> Gorev { get; set; }
        public DbSet<mudurluk> Mudurluk { get; set; }
        public DbSet<seflik> Seflik { get; set; }
        public DbSet<sertifikaBilgi> SertifikaBilgi { get; set; }
        public DbSet<takvim> Takvim { get; set; }
        public DbSet<talep> Talep { get; set; }
        public DbSet<edasBilgileri> EdasBilgileri { get; set; }
        public DbSet<webErisim> WebErisim { get; set; }
        public DbSet<wfsErisim> WfsErisim { get; set; }
        public DbSet<bolgeErisim> BolgeErisim { get; set; }
        public DbSet<edasIrtıbatBilgileri> EdasIrtıbatBilgileri { get; set; }
        public DbSet<edasIletisimBilgileri> EdasIletisimBilgileri { get; set; }
        public DbSet<kategoriTipi> kategoriTipi{ get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}