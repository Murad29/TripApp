namespace TripApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NullableBool : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Trips", "Select", c => c.Boolean());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Trips", "Select", c => c.Boolean(nullable: false));
        }
    }
}
