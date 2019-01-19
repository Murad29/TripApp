namespace TripApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inital : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tickets", "TripName_Id", c => c.Int());
            CreateIndex("dbo.Tickets", "TripName_Id");
            AddForeignKey("dbo.Tickets", "TripName_Id", "dbo.Trips", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "TripName_Id", "dbo.Trips");
            DropIndex("dbo.Tickets", new[] { "TripName_Id" });
            DropColumn("dbo.Tickets", "TripName_Id");
        }
    }
}
