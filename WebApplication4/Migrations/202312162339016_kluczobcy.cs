namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kluczobcy : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Grafiks", "Zmiana_Id", "dbo.Zmianas");
            DropForeignKey("dbo.Samochod_Zarejestrowany", "Obywatel_Id", "dbo.Obywatels");
            DropIndex("dbo.Grafiks", new[] { "Zmiana_Id" });
            DropIndex("dbo.Samochod_Zarejestrowany", new[] { "Obywatel_Id" });
            DropColumn("dbo.Grafiks", "Id_Zmiany");
            RenameColumn(table: "dbo.Grafiks", name: "Zmiana_Id", newName: "Id_Zmiany");
            RenameColumn(table: "dbo.Samochod_Zarejestrowany", name: "Obywatel_Id", newName: "Id_Obywatela");
            AlterColumn("dbo.Grafiks", "Id_Zmiany", c => c.Int(nullable: false));
            AlterColumn("dbo.Samochod_Zarejestrowany", "Id_Obywatela", c => c.Int(nullable: false));
            CreateIndex("dbo.Grafiks", "Id_Zmiany");
            CreateIndex("dbo.Samochod_Zarejestrowany", "Id_Obywatela");
            AddForeignKey("dbo.Grafiks", "Id_Zmiany", "dbo.Zmianas", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Samochod_Zarejestrowany", "Id_Obywatela", "dbo.Obywatels", "Id", cascadeDelete: true);
            DropColumn("dbo.Zmianas", "Id_Zmiany");
            DropColumn("dbo.Samochod_Zarejestrowany", "Pesel");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Samochod_Zarejestrowany", "Pesel", c => c.Int(nullable: false));
            AddColumn("dbo.Zmianas", "Id_Zmiany", c => c.Int(nullable: false));
            DropForeignKey("dbo.Samochod_Zarejestrowany", "Id_Obywatela", "dbo.Obywatels");
            DropForeignKey("dbo.Grafiks", "Id_Zmiany", "dbo.Zmianas");
            DropIndex("dbo.Samochod_Zarejestrowany", new[] { "Id_Obywatela" });
            DropIndex("dbo.Grafiks", new[] { "Id_Zmiany" });
            AlterColumn("dbo.Samochod_Zarejestrowany", "Id_Obywatela", c => c.Int());
            AlterColumn("dbo.Grafiks", "Id_Zmiany", c => c.Int());
            RenameColumn(table: "dbo.Samochod_Zarejestrowany", name: "Id_Obywatela", newName: "Obywatel_Id");
            RenameColumn(table: "dbo.Grafiks", name: "Id_Zmiany", newName: "Zmiana_Id");
            AddColumn("dbo.Grafiks", "Id_Zmiany", c => c.Int(nullable: false));
            CreateIndex("dbo.Samochod_Zarejestrowany", "Obywatel_Id");
            CreateIndex("dbo.Grafiks", "Zmiana_Id");
            AddForeignKey("dbo.Samochod_Zarejestrowany", "Obywatel_Id", "dbo.Obywatels", "Id");
            AddForeignKey("dbo.Grafiks", "Zmiana_Id", "dbo.Zmianas", "Id");
        }
    }
}
