namespace TripApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewChange : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tickets", "TicketId", c => c.Int());
            DropColumn("dbo.Trips", "TicketId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Trips", "TicketId", c => c.Int());
            DropColumn("dbo.Tickets", "TicketId");
        }
    }
}
