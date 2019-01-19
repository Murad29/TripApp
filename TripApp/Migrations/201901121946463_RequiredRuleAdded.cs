namespace TripApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RequiredRuleAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Trips", "TicketId", c => c.Int());
            AlterColumn("dbo.Trips", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Trips", "Name", c => c.String());
            DropColumn("dbo.Trips", "TicketId");
        }
    }
}
