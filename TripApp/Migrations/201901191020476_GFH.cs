namespace TripApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GFH : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tickets", "TicketName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tickets", "TicketName");
        }
    }
}
