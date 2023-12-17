namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class zmiana1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Charakter_zdarzenia", "Charakter_Zdarzenia_PK_id", "dbo.Charakter_zdarzenia");
            DropIndex("dbo.Charakter_zdarzenia", new[] { "Charakter_Zdarzenia_PK_id" });
            DropColumn("dbo.Charakter_zdarzenia", "Charakter_Zdarzenia_PK_id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Charakter_zdarzenia", "Charakter_Zdarzenia_PK_id", c => c.Int());
            CreateIndex("dbo.Charakter_zdarzenia", "Charakter_Zdarzenia_PK_id");
            AddForeignKey("dbo.Charakter_zdarzenia", "Charakter_Zdarzenia_PK_id", "dbo.Charakter_zdarzenia", "id");
        }
    }
}
