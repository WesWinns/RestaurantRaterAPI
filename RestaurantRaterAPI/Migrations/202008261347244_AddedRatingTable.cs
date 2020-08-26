namespace RestaurantRaterAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedRatingTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ratings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FoodScore = c.Double(nullable: false),
                        EnvironmentScore = c.Double(nullable: false),
                        CleanlinessScore = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Ratings");
        }
    }
}
