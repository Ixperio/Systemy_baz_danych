namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kluczeobce2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Zdarzenies", "Id_Obywatela", c => c.Int(nullable: false));
            AddColumn("dbo.Zdarzenies", "Id_Samochodu", c => c.Int(nullable: false));
            AddColumn("dbo.Zdarzenies", "Id_Rodzaju", c => c.Int(nullable: false));
            DropColumn("dbo.Zdarzenies", "Obywatel_Pesel");
            DropColumn("dbo.Zdarzenies", "Patrole_Id_Patrolu");
            DropColumn("dbo.Zdarzenies", "Charakter_Zdarzenia_Id_Rodzaju");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Zdarzenies", "Charakter_Zdarzenia_Id_Rodzaju", c => c.Int(nullable: false));
            AddColumn("dbo.Zdarzenies", "Patrole_Id_Patrolu", c => c.Int(nullable: false));
            AddColumn("dbo.Zdarzenies", "Obywatel_Pesel", c => c.Int(nullable: false));
            DropColumn("dbo.Zdarzenies", "Id_Rodzaju");
            DropColumn("dbo.Zdarzenies", "Id_Samochodu");
            DropColumn("dbo.Zdarzenies", "Id_Obywatela");
        }
    }
}
