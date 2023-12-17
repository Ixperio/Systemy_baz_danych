namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class zmiana : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Funkcjonariuszs", "Obywatel_Id", "dbo.Obywatels");
            DropIndex("dbo.Funkcjonariuszs", new[] { "Obywatel_Id" });
            DropColumn("dbo.Funkcjonariuszs", "id_Obywatela");
            RenameColumn(table: "dbo.Funkcjonariuszs", name: "Obywatel_Id", newName: "id_Obywatela");
            AlterColumn("dbo.Funkcjonariuszs", "id_Obywatela", c => c.Int(nullable: false));
            CreateIndex("dbo.Funkcjonariuszs", "id_Obywatela");
            AddForeignKey("dbo.Funkcjonariuszs", "id_Obywatela", "dbo.Obywatels", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Funkcjonariuszs", "id_Obywatela", "dbo.Obywatels");
            DropIndex("dbo.Funkcjonariuszs", new[] { "id_Obywatela" });
            AlterColumn("dbo.Funkcjonariuszs", "id_Obywatela", c => c.Int());
            RenameColumn(table: "dbo.Funkcjonariuszs", name: "id_Obywatela", newName: "Obywatel_Id");
            AddColumn("dbo.Funkcjonariuszs", "id_Obywatela", c => c.Int(nullable: false));
            CreateIndex("dbo.Funkcjonariuszs", "Obywatel_Id");
            AddForeignKey("dbo.Funkcjonariuszs", "Obywatel_Id", "dbo.Obywatels", "Id");
        }
    }
}
