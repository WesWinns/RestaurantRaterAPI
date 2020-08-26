namespace RestaurantRaterAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetupForeignKeys : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ratings", "RestaurantId", c => c.Int(nullable: false));
            CreateIndex("dbo.Ratings", "RestaurantId");
            AddForeignKey("dbo.Ratings", "RestaurantId", "dbo.Restaurants", "Id", cascadeDelete: true);
            DropColumn("dbo.Restaurants", "Rating");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Restaurants", "Rating", c => c.Double(nullable: false));
            DropForeignKey("dbo.Ratings", "RestaurantId", "dbo.Restaurants");
            DropIndex("dbo.Ratings", new[] { "RestaurantId" });
            DropColumn("dbo.Ratings", "RestaurantId");
        }
    }
}
