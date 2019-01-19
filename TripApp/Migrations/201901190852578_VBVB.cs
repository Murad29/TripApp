namespace TripApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VBVB : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Trips", "Select", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Trips", "Select");
        }
    }
}
