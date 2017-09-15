namespace PlanUp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newm : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.HomeEvents", "EventCategory_Id", "dbo.EventCategories");
            DropIndex("dbo.HomeEvents", new[] { "EventCategory_Id" });
            AddColumn("dbo.HomeEvents", "EventCategory", c => c.Int(nullable: false));
            DropColumn("dbo.HomeEvents", "EventCategory_Id");
            DropTable("dbo.EventCategories");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.EventCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.HomeEvents", "EventCategory_Id", c => c.Int());
            DropColumn("dbo.HomeEvents", "EventCategory");
            CreateIndex("dbo.HomeEvents", "EventCategory_Id");
            AddForeignKey("dbo.HomeEvents", "EventCategory_Id", "dbo.EventCategories", "Id");
        }
    }
}
