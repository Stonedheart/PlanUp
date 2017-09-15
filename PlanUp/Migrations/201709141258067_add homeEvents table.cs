namespace PlanUp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addhomeEventstable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HomeEvents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HomeEventName = c.String(),
                        Duration = c.Int(nullable: false),
                        EventCategory_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EventCategories", t => t.EventCategory_Id)
                .Index(t => t.EventCategory_Id);
            
            CreateTable(
                "dbo.EventCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HomeEvents", "EventCategory_Id", "dbo.EventCategories");
            DropIndex("dbo.HomeEvents", new[] { "EventCategory_Id" });
            DropTable("dbo.EventCategories");
            DropTable("dbo.HomeEvents");
        }
    }
}
