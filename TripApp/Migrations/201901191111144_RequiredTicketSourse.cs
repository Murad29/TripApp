namespace TripApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RequiredTicketSourse : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tickets", "TicketName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Tickets", "TicketSource", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tickets", "TicketSource", c => c.String());
            AlterColumn("dbo.Tickets", "TicketName", c => c.String(nullable: false));
        }
    }
}
