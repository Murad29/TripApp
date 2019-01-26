namespace TripApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CityDeleted : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Cities");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CityName = c.String(),
                        CountryName = c.String(),
                        Currency = c.String(),
                        Language = c.String(),
                        CurrentWeather = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}