namespace TripApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Trips", "DepartureDate");
            DropColumn("dbo.Trips", "ArrivalDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Trips", "ArrivalDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Trips", "DepartureDate", c => c.DateTime(nullable: false));
        }
    }
}
