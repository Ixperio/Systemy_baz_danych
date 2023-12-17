namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kluczeobce3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Zdarzenies", "Obywatel_Id", "dbo.Obywatels");
            DropForeignKey("dbo.Zdarzenies", "Samochod_zarejestrowany_Id", "dbo.Samochod_Zarejestrowany");
            DropForeignKey("dbo.Zdarzenies", "Charakter_Zdarzenia_id", "dbo.Charakter_zdarzenia");
            DropForeignKey("dbo.Zdarzenies", "Patrol_Id_Patrolu", "dbo.Patrols");
            DropIndex("dbo.Zdarzenies", new[] { "Charakter_Zdarzenia_id" });
            DropIndex("dbo.Zdarzenies", new[] { "Obywatel_Id" });
            DropIndex("dbo.Zdarzenies", new[] { "Patrol_Id_Patrolu" });
            DropIndex("dbo.Zdarzenies", new[] { "Samochod_zarejestrowany_Id" });
            DropColumn("dbo.Zdarzenies", "Id_Obywatela");
            DropColumn("dbo.Zdarzenies", "Id_Rodzaju");
            RenameColumn(table: "dbo.Zdarzenies", name: "Obywatel_Id", newName: "Id_Obywatela");
            RenameColumn(table: "dbo.Zdarzenies", name: "Samochod_zarejestrowany_Id", newName: "Samochod_Id");
            RenameColumn(table: "dbo.Zdarzenies", name: "Charakter_Zdarzenia_id", newName: "Id_Rodzaju");
            RenameColumn(table: "dbo.Zdarzenies", name: "Patrol_Id_Patrolu", newName: "Id_Patrolu");
            AlterColumn("dbo.Zdarzenies", "Id_Rodzaju", c => c.Int(nullable: false));
            AlterColumn("dbo.Zdarzenies", "Id_Obywatela", c => c.Int(nullable: false));
            AlterColumn("dbo.Zdarzenies", "Id_Patrolu", c => c.Int(nullable: false));
            AlterColumn("dbo.Zdarzenies", "Samochod_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Zdarzenies", "Id_Obywatela");
            CreateIndex("dbo.Zdarzenies", "Samochod_Id");
            CreateIndex("dbo.Zdarzenies", "Id_Patrolu");
            CreateIndex("dbo.Zdarzenies", "Id_Rodzaju");
            AddForeignKey("dbo.Zdarzenies", "Id_Obywatela", "dbo.Obywatels", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Zdarzenies", "Samochod_Id", "dbo.Samochod_Zarejestrowany", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Zdarzenies", "Id_Rodzaju", "dbo.Charakter_zdarzenia", "id", cascadeDelete: true);
            AddForeignKey("dbo.Zdarzenies", "Id_Patrolu", "dbo.Patrols", "Id_Patrolu", cascadeDelete: true);
            DropColumn("dbo.Zdarzenies", "Id_Samochodu");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Zdarzenies", "Id_Samochodu", c => c.Int(nullable: false));
            DropForeignKey("dbo.Zdarzenies", "Id_Patrolu", "dbo.Patrols");
            DropForeignKey("dbo.Zdarzenies", "Id_Rodzaju", "dbo.Charakter_zdarzenia");
            DropForeignKey("dbo.Zdarzenies", "Samochod_Id", "dbo.Samochod_Zarejestrowany");
            DropForeignKey("dbo.Zdarzenies", "Id_Obywatela", "dbo.Obywatels");
            DropIndex("dbo.Zdarzenies", new[] { "Id_Rodzaju" });
            DropIndex("dbo.Zdarzenies", new[] { "Id_Patrolu" });
            DropIndex("dbo.Zdarzenies", new[] { "Samochod_Id" });
            DropIndex("dbo.Zdarzenies", new[] { "Id_Obywatela" });
            AlterColumn("dbo.Zdarzenies", "Samochod_Id", c => c.Int());
            AlterColumn("dbo.Zdarzenies", "Id_Patrolu", c => c.Int());
            AlterColumn("dbo.Zdarzenies", "Id_Obywatela", c => c.Int());
            AlterColumn("dbo.Zdarzenies", "Id_Rodzaju", c => c.Int());
            RenameColumn(table: "dbo.Zdarzenies", name: "Id_Patrolu", newName: "Patrol_Id_Patrolu");
            RenameColumn(table: "dbo.Zdarzenies", name: "Id_Rodzaju", newName: "Charakter_Zdarzenia_id");
            RenameColumn(table: "dbo.Zdarzenies", name: "Samochod_Id", newName: "Samochod_zarejestrowany_Id");
            RenameColumn(table: "dbo.Zdarzenies", name: "Id_Obywatela", newName: "Obywatel_Id");
            AddColumn("dbo.Zdarzenies", "Id_Rodzaju", c => c.Int(nullable: false));
            AddColumn("dbo.Zdarzenies", "Id_Obywatela", c => c.Int(nullable: false));
            CreateIndex("dbo.Zdarzenies", "Samochod_zarejestrowany_Id");
            CreateIndex("dbo.Zdarzenies", "Patrol_Id_Patrolu");
            CreateIndex("dbo.Zdarzenies", "Obywatel_Id");
            CreateIndex("dbo.Zdarzenies", "Charakter_Zdarzenia_id");
            AddForeignKey("dbo.Zdarzenies", "Patrol_Id_Patrolu", "dbo.Patrols", "Id_Patrolu");
            AddForeignKey("dbo.Zdarzenies", "Charakter_Zdarzenia_id", "dbo.Charakter_zdarzenia", "id");
            AddForeignKey("dbo.Zdarzenies", "Samochod_zarejestrowany_Id", "dbo.Samochod_Zarejestrowany", "Id");
            AddForeignKey("dbo.Zdarzenies", "Obywatel_Id", "dbo.Obywatels", "Id");
        }
    }
}
