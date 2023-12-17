namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class zmodyfikowana : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Samochods", "Samochody_PK");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Samochods", "Samochody_PK", c => c.Int(nullable: false));
        }
    }
}
