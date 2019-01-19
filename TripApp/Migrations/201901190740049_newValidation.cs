namespace TripApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newValidation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Trips", "Name", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Trips", "Name", c => c.String(nullable: false));
        }
    }
}
