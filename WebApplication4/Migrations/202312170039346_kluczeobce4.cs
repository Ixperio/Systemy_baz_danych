namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kluczeobce4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Samochod_Zarejestrowany", "Rocznik", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Samochod_Zarejestrowany", "Rocznik", c => c.Int(nullable: false));
        }
    }
}
