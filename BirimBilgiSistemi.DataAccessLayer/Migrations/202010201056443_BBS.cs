namespace BirimBilgiSistemi.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BBS : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Baskanlik",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        isim = c.String(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        ModifiedUsername = c.String(maxLength: 30),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Mudurluk",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        isim = c.String(nullable: false),
                        baskanlikId = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        ModifiedUsername = c.String(maxLength: 30),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Baskanlik", t => t.baskanlikId, cascadeDelete: true)
                .Index(t => t.baskanlikId);
            
            CreateTable(
                "dbo.Personel",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        sicilNo = c.String(nullable: false),
                        tcKimlik = c.String(nullable: false),
                        ad = c.String(nullable: false),
                        soyad = c.String(nullable: false),
                        telefon = c.String(nullable: false),
                        dahili = c.String(nullable: false),
                        eposta = c.String(nullable: false),
                        meslegi = c.String(nullable: false),
                        unvani = c.String(nullable: false),
                        IsAdmin = c.Boolean(nullable: false),
                        adres = c.String(nullable: false),
                        baskanlikId = c.Int(),
                        mudurlukId = c.Int(),
                        seflikId = c.Int(),
                        kanGrubu = c.String(),
                        yakininAdSoyadi = c.String(),
                        yakininTelefon = c.String(),
                        kullanici_adi = c.String(),
                        sifre = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        ModifiedUsername = c.String(maxLength: 30),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Mudurluk", t => t.mudurlukId)
                .ForeignKey("dbo.Seflik", t => t.seflikId)
                .ForeignKey("dbo.Baskanlik", t => t.baskanlikId)
                .Index(t => t.baskanlikId)
                .Index(t => t.mudurlukId)
                .Index(t => t.seflikId);
            
            CreateTable(
                "dbo.Takvim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        personel_id = c.Int(nullable: false),
                        etkinlikAd = c.String(nullable: false, maxLength: 25),
                        etkinlikAciklama = c.String(nullable: false),
                        etkinlikKonum = c.String(nullable: false),
                        etkinlikKategori = c.Int(nullable: false),
                        baslangicTarihi = c.DateTime(nullable: false),
                        bitisTarihi = c.DateTime(nullable: false),
                        katilimci = c.String(nullable: false),
                        NameSurname = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        ModifiedUsername = c.String(maxLength: 30),
                        kategoriTipi_Id = c.Int(),
                        Personel_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.kategoriTipi", t => t.kategoriTipi_Id)
                .ForeignKey("dbo.Personel", t => t.Personel_Id)
                .Index(t => t.kategoriTipi_Id)
                .Index(t => t.Personel_Id);
            
            CreateTable(
                "dbo.kategoriTipi",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        KategoriTipi = c.String(maxLength: 50),
                        RenkKodu = c.String(maxLength: 50),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        ModifiedUsername = c.String(maxLength: 30),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Seflik",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        isim = c.String(nullable: false),
                        BaskanlikId = c.Int(),
                        MudurlukId = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        ModifiedUsername = c.String(maxLength: 30),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Baskanlik", t => t.BaskanlikId)
                .ForeignKey("dbo.Mudurluk", t => t.MudurlukId)
                .Index(t => t.BaskanlikId)
                .Index(t => t.MudurlukId);
            
            CreateTable(
                "dbo.BolgeErisim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        bolgeMudurlugu = c.String(),
                        isimSoyisim = c.String(),
                        gorev = c.String(),
                        eposta = c.String(),
                        telefon = c.String(),
                        cepTelefon = c.String(),
                        erisimDurumu = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        ModifiedUsername = c.String(maxLength: 30),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Dosya",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        personel_id = c.Int(nullable: false),
                        dosyaAdi = c.String(),
                        dosyaAciklama = c.String(),
                        dosyaPath = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        ModifiedUsername = c.String(maxLength: 30),
                        Personel_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Personel", t => t.Personel_Id)
                .Index(t => t.Personel_Id);
            
            CreateTable(
                "dbo.EdasBilgileri",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        dagitimSirketi = c.String(nullable: false),
                        sorumluIl = c.String(nullable: false),
                        baglantiDurumu = c.String(),
                        adres = c.String(),
                        kepAdresi = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        ModifiedUsername = c.String(maxLength: 30),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EdasIletisimBilgileri",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        dagitimSirketi_id = c.Int(),
                        irtibatPersonel_id = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        ModifiedUsername = c.String(maxLength: 30),
                        EdasBilgileri_Id = c.Int(),
                        EdasIrtıbatBilgileri_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EdasBilgileri", t => t.EdasBilgileri_Id)
                .ForeignKey("dbo.EdasIrtibatPersonel", t => t.EdasIrtıbatBilgileri_Id)
                .Index(t => t.EdasBilgileri_Id)
                .Index(t => t.EdasIrtıbatBilgileri_Id);
            
            CreateTable(
                "dbo.EdasIrtibatPersonel",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        isimSoyisim = c.String(),
                        gorev = c.String(),
                        unvani = c.String(),
                        eposta = c.String(),
                        telefon = c.String(),
                        cepTelefon = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        ModifiedUsername = c.String(maxLength: 30),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EgitimBilgileri",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        personelId = c.Int(nullable: false),
                        egitimTuru = c.String(nullable: false),
                        okulAdi = c.String(nullable: false),
                        okulBolum = c.String(nullable: false),
                        mezuniyetYili = c.String(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        ModifiedUsername = c.String(maxLength: 30),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Gorev",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        isim = c.String(),
                        ekleme = c.Boolean(nullable: false),
                        silme = c.Boolean(nullable: false),
                        duzenleme = c.Boolean(nullable: false),
                        goruntuleme = c.Boolean(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        ModifiedUsername = c.String(maxLength: 30),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SertifikaBigi",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        personelId = c.Int(nullable: false),
                        sertifikaAdi = c.String(nullable: false),
                        sertifikaTarihi = c.DateTime(nullable: false),
                        sertifikaKurum = c.String(nullable: false),
                        sertifikaAciklama = c.String(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        ModifiedUsername = c.String(maxLength: 30),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Talep",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        personel_id = c.Int(nullable: false),
                        talepTuru = c.String(nullable: false),
                        eposta = c.String(nullable: false),
                        talepAciklama = c.String(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        ModifiedUsername = c.String(maxLength: 30),
                        Personel_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Personel", t => t.Personel_Id)
                .Index(t => t.Personel_Id);
            
            CreateTable(
                "dbo.WebErisim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        dagitimSirketi_id = c.Int(nullable: false),
                        sorumluIl_id = c.Int(nullable: false),
                        vpn_kullaniciAdi = c.String(),
                        vpn_sifre = c.String(),
                        vpn_baglantiAdresi = c.String(),
                        vpn_uygulamaAdi = c.String(),
                        IP = c.String(),
                        web_kullaniciAdi = c.String(),
                        web_sifre = c.String(),
                        web_baglantiAdresi = c.String(),
                        erisimDurumuGM = c.String(),
                        erisimDurumuBM = c.String(),
                        aciklama = c.String(),
                        ustyazi = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        ModifiedUsername = c.String(maxLength: 30),
                        EdasBilgileri_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EdasBilgileri", t => t.EdasBilgileri_Id)
                .Index(t => t.EdasBilgileri_Id);
            
            CreateTable(
                "dbo.WfsErisim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        dagitimSirketi_id = c.Int(nullable: false),
                        vpn_kullaniciAdi = c.String(),
                        vpn_sifre = c.String(),
                        vpn_baglantiAdresi = c.String(),
                        vpn_uygulamaAdi = c.String(),
                        vpn_IP = c.String(),
                        wfs_kullaniciAdi = c.String(),
                        wfs_sifre = c.String(),
                        wfs_baglantiAdresi = c.String(),
                        erisimDurumu = c.String(),
                        aciklama = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        ModifiedUsername = c.String(maxLength: 30),
                        EdasBilgileri_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EdasBilgileri", t => t.EdasBilgileri_Id)
                .Index(t => t.EdasBilgileri_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WfsErisim", "EdasBilgileri_Id", "dbo.EdasBilgileri");
            DropForeignKey("dbo.WebErisim", "EdasBilgileri_Id", "dbo.EdasBilgileri");
            DropForeignKey("dbo.Talep", "Personel_Id", "dbo.Personel");
            DropForeignKey("dbo.EdasIletisimBilgileri", "EdasIrtıbatBilgileri_Id", "dbo.EdasIrtibatPersonel");
            DropForeignKey("dbo.EdasIletisimBilgileri", "EdasBilgileri_Id", "dbo.EdasBilgileri");
            DropForeignKey("dbo.Dosya", "Personel_Id", "dbo.Personel");
            DropForeignKey("dbo.Personel", "baskanlikId", "dbo.Baskanlik");
            DropForeignKey("dbo.Personel", "seflikId", "dbo.Seflik");
            DropForeignKey("dbo.Seflik", "MudurlukId", "dbo.Mudurluk");
            DropForeignKey("dbo.Seflik", "BaskanlikId", "dbo.Baskanlik");
            DropForeignKey("dbo.Personel", "mudurlukId", "dbo.Mudurluk");
            DropForeignKey("dbo.Takvim", "Personel_Id", "dbo.Personel");
            DropForeignKey("dbo.Takvim", "kategoriTipi_Id", "dbo.kategoriTipi");
            DropForeignKey("dbo.Mudurluk", "baskanlikId", "dbo.Baskanlik");
            DropIndex("dbo.WfsErisim", new[] { "EdasBilgileri_Id" });
            DropIndex("dbo.WebErisim", new[] { "EdasBilgileri_Id" });
            DropIndex("dbo.Talep", new[] { "Personel_Id" });
            DropIndex("dbo.EdasIletisimBilgileri", new[] { "EdasIrtıbatBilgileri_Id" });
            DropIndex("dbo.EdasIletisimBilgileri", new[] { "EdasBilgileri_Id" });
            DropIndex("dbo.Dosya", new[] { "Personel_Id" });
            DropIndex("dbo.Seflik", new[] { "MudurlukId" });
            DropIndex("dbo.Seflik", new[] { "BaskanlikId" });
            DropIndex("dbo.Takvim", new[] { "Personel_Id" });
            DropIndex("dbo.Takvim", new[] { "kategoriTipi_Id" });
            DropIndex("dbo.Personel", new[] { "seflikId" });
            DropIndex("dbo.Personel", new[] { "mudurlukId" });
            DropIndex("dbo.Personel", new[] { "baskanlikId" });
            DropIndex("dbo.Mudurluk", new[] { "baskanlikId" });
            DropTable("dbo.WfsErisim");
            DropTable("dbo.WebErisim");
            DropTable("dbo.Talep");
            DropTable("dbo.SertifikaBigi");
            DropTable("dbo.Gorev");
            DropTable("dbo.EgitimBilgileri");
            DropTable("dbo.EdasIrtibatPersonel");
            DropTable("dbo.EdasIletisimBilgileri");
            DropTable("dbo.EdasBilgileri");
            DropTable("dbo.Dosya");
            DropTable("dbo.BolgeErisim");
            DropTable("dbo.Seflik");
            DropTable("dbo.kategoriTipi");
            DropTable("dbo.Takvim");
            DropTable("dbo.Personel");
            DropTable("dbo.Mudurluk");
            DropTable("dbo.Baskanlik");
        }
    }
}
