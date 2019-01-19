namespace TripApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedStringToDateTime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Trips", "DepartureDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Trips", "ArrivalDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Trips", "ArrivalDate", c => c.String());
            AlterColumn("dbo.Trips", "DepartureDate", c => c.String());
        }
    }
}
