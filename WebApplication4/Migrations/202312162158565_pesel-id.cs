namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class peselid : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Funkcjonariuszs", "id_Obywatela", c => c.Int(nullable: false));
            DropColumn("dbo.Funkcjonariuszs", "Pesel");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Funkcjonariuszs", "Pesel", c => c.Int(nullable: false));
            DropColumn("dbo.Funkcjonariuszs", "id_Obywatela");
        }
    }
}
