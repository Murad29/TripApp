namespace TripApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestDontWork : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Trips", "DepartureDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Trips", "ArrivalDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Trips", "ArrivalDate");
            DropColumn("dbo.Trips", "DepartureDate");
        }
    }
}
