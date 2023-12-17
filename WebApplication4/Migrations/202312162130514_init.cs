namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Charakter_zdarzenia",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Id_Rodzaju = c.Int(nullable: false),
                        Nazwa = c.String(),
                        Charakter_Zdarzenia_PK_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Charakter_zdarzenia", t => t.Charakter_Zdarzenia_PK_id)
                .Index(t => t.Charakter_Zdarzenia_PK_id);
            
            CreateTable(
                "dbo.Funkcjonariuszs",
                c => new
                    {
                        id_Funkcjonariusza = c.Int(nullable: false, identity: true),
                        telefon = c.Int(nullable: false),
                        Pesel = c.Int(nullable: false),
                        id_Stopnia = c.Int(nullable: false),
                        adres_Email = c.String(),
                        Wyksztalcenie = c.String(),
                        Obywatel_Id = c.Int(),
                    })
                .PrimaryKey(t => t.id_Funkcjonariusza)
                .ForeignKey("dbo.Obywatels", t => t.Obywatel_Id)
                .ForeignKey("dbo.Stopiens", t => t.id_Stopnia, cascadeDelete: true)
                .Index(t => t.id_Stopnia)
                .Index(t => t.Obywatel_Id);
            
            CreateTable(
                "dbo.Grafiks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Data = c.DateTime(nullable: false),
                        Id_Funkcjonariusza = c.Int(nullable: false),
                        Godzina_Przyjscia = c.String(),
                        Godzina_Wyjscia = c.String(),
                        Id_Zmiany = c.Int(nullable: false),
                        Zmiana_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Funkcjonariuszs", t => t.Id_Funkcjonariusza, cascadeDelete: true)
                .ForeignKey("dbo.Zmianas", t => t.Zmiana_Id)
                .Index(t => t.Id_Funkcjonariusza)
                .Index(t => t.Zmiana_Id);
            
            CreateTable(
                "dbo.Zmianas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Id_Zmiany = c.Int(nullable: false),
                        Godzina_Rozpoczecia = c.String(),
                        Godzina_Zakonczenia = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Obywatels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Pesel = c.Int(nullable: false),
                        Imie = c.String(),
                        Nazwisko = c.String(),
                        DataUrodzenia = c.DateTime(nullable: false),
                        Ulica = c.String(),
                        Nr_Budynku = c.String(),
                        Miasto = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Samochod_Zarejestrowany",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nr_Rejestracyjny = c.String(),
                        Przebieg = c.Int(nullable: false),
                        Pesel = c.Int(nullable: false),
                        Id_Samochodu = c.Int(nullable: false),
                        Rocznik = c.Int(nullable: false),
                        Ubezpieczenie = c.DateTime(nullable: false),
                        Obywatel_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Obywatels", t => t.Obywatel_Id)
                .ForeignKey("dbo.Samochods", t => t.Id_Samochodu, cascadeDelete: true)
                .Index(t => t.Id_Samochodu)
                .Index(t => t.Obywatel_Id);
            
            CreateTable(
                "dbo.Samochods",
                c => new
                    {
                        Id_Samochodu = c.Int(nullable: false, identity: true),
                        Marka = c.String(),
                        Model = c.String(),
                        Samochody_PK = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id_Samochodu);
            
            CreateTable(
                "dbo.Radiowoz_policyjny",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nr_Rejestracyjny = c.String(),
                        Rocznik = c.Int(nullable: false),
                        id_Samochodu = c.Int(nullable: false),
                        Ubezpieczenie = c.DateTime(nullable: false),
                        Przebieg = c.Int(nullable: false),
                        Przeglad = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Samochods", t => t.id_Samochodu, cascadeDelete: true)
                .Index(t => t.id_Samochodu);
            
            CreateTable(
                "dbo.Zdarzenies",
                c => new
                    {
                        Id_Zdarzenia = c.Int(nullable: false, identity: true),
                        Obywatel_Pesel = c.Int(nullable: false),
                        Data = c.DateTime(nullable: false),
                        Patrole_Id_Patrolu = c.Int(nullable: false),
                        Charakter_Zdarzenia_Id_Rodzaju = c.Int(nullable: false),
                        Charakter_Zdarzenia_id = c.Int(),
                        Obywatel_Id = c.Int(),
                        Patrol_Id_Patrolu = c.Int(),
                        Samochod_zarejestrowany_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id_Zdarzenia)
                .ForeignKey("dbo.Charakter_zdarzenia", t => t.Charakter_Zdarzenia_id)
                .ForeignKey("dbo.Obywatels", t => t.Obywatel_Id)
                .ForeignKey("dbo.Patrols", t => t.Patrol_Id_Patrolu)
                .ForeignKey("dbo.Samochod_Zarejestrowany", t => t.Samochod_zarejestrowany_Id)
                .Index(t => t.Charakter_Zdarzenia_id)
                .Index(t => t.Obywatel_Id)
                .Index(t => t.Patrol_Id_Patrolu)
                .Index(t => t.Samochod_zarejestrowany_Id);
            
            CreateTable(
                "dbo.Patrols",
                c => new
                    {
                        Id_Patrolu = c.Int(nullable: false, identity: true),
                        Data = c.DateTime(nullable: false),
                        Radiowozy_Policyjne_Nr_Rejestracyjny = c.String(),
                        radiowoz_policyjny_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id_Patrolu)
                .ForeignKey("dbo.Radiowoz_policyjny", t => t.radiowoz_policyjny_Id)
                .Index(t => t.radiowoz_policyjny_Id);
            
            CreateTable(
                "dbo.Funkcjonariusz_w_patrolu",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        id_Patrolu = c.Int(nullable: false),
                        id_Funkcjonariusza = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Funkcjonariuszs", t => t.id_Funkcjonariusza, cascadeDelete: true)
                .ForeignKey("dbo.Patrols", t => t.id_Patrolu, cascadeDelete: true)
                .Index(t => t.id_Patrolu)
                .Index(t => t.id_Funkcjonariusza);
            
            CreateTable(
                "dbo.Stopiens",
                c => new
                    {
                        Id_Stopnia = c.Int(nullable: false, identity: true),
                        Nazwa = c.String(),
                        Zarobki = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id_Stopnia);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Funkcjonariuszs", "id_Stopnia", "dbo.Stopiens");
            DropForeignKey("dbo.Funkcjonariuszs", "Obywatel_Id", "dbo.Obywatels");
            DropForeignKey("dbo.Zdarzenies", "Samochod_zarejestrowany_Id", "dbo.Samochod_Zarejestrowany");
            DropForeignKey("dbo.Zdarzenies", "Patrol_Id_Patrolu", "dbo.Patrols");
            DropForeignKey("dbo.Patrols", "radiowoz_policyjny_Id", "dbo.Radiowoz_policyjny");
            DropForeignKey("dbo.Funkcjonariusz_w_patrolu", "id_Patrolu", "dbo.Patrols");
            DropForeignKey("dbo.Funkcjonariusz_w_patrolu", "id_Funkcjonariusza", "dbo.Funkcjonariuszs");
            DropForeignKey("dbo.Zdarzenies", "Obywatel_Id", "dbo.Obywatels");
            DropForeignKey("dbo.Zdarzenies", "Charakter_Zdarzenia_id", "dbo.Charakter_zdarzenia");
            DropForeignKey("dbo.Samochod_Zarejestrowany", "Id_Samochodu", "dbo.Samochods");
            DropForeignKey("dbo.Radiowoz_policyjny", "id_Samochodu", "dbo.Samochods");
            DropForeignKey("dbo.Samochod_Zarejestrowany", "Obywatel_Id", "dbo.Obywatels");
            DropForeignKey("dbo.Grafiks", "Zmiana_Id", "dbo.Zmianas");
            DropForeignKey("dbo.Grafiks", "Id_Funkcjonariusza", "dbo.Funkcjonariuszs");
            DropForeignKey("dbo.Charakter_zdarzenia", "Charakter_Zdarzenia_PK_id", "dbo.Charakter_zdarzenia");
            DropIndex("dbo.Funkcjonariusz_w_patrolu", new[] { "id_Funkcjonariusza" });
            DropIndex("dbo.Funkcjonariusz_w_patrolu", new[] { "id_Patrolu" });
            DropIndex("dbo.Patrols", new[] { "radiowoz_policyjny_Id" });
            DropIndex("dbo.Zdarzenies", new[] { "Samochod_zarejestrowany_Id" });
            DropIndex("dbo.Zdarzenies", new[] { "Patrol_Id_Patrolu" });
            DropIndex("dbo.Zdarzenies", new[] { "Obywatel_Id" });
            DropIndex("dbo.Zdarzenies", new[] { "Charakter_Zdarzenia_id" });
            DropIndex("dbo.Radiowoz_policyjny", new[] { "id_Samochodu" });
            DropIndex("dbo.Samochod_Zarejestrowany", new[] { "Obywatel_Id" });
            DropIndex("dbo.Samochod_Zarejestrowany", new[] { "Id_Samochodu" });
            DropIndex("dbo.Grafiks", new[] { "Zmiana_Id" });
            DropIndex("dbo.Grafiks", new[] { "Id_Funkcjonariusza" });
            DropIndex("dbo.Funkcjonariuszs", new[] { "Obywatel_Id" });
            DropIndex("dbo.Funkcjonariuszs", new[] { "id_Stopnia" });
            DropIndex("dbo.Charakter_zdarzenia", new[] { "Charakter_Zdarzenia_PK_id" });
            DropTable("dbo.Stopiens");
            DropTable("dbo.Funkcjonariusz_w_patrolu");
            DropTable("dbo.Patrols");
            DropTable("dbo.Zdarzenies");
            DropTable("dbo.Radiowoz_policyjny");
            DropTable("dbo.Samochods");
            DropTable("dbo.Samochod_Zarejestrowany");
            DropTable("dbo.Obywatels");
            DropTable("dbo.Zmianas");
            DropTable("dbo.Grafiks");
            DropTable("dbo.Funkcjonariuszs");
            DropTable("dbo.Charakter_zdarzenia");
        }
    }
}
