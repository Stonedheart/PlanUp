namespace PlanUp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddHomeEvent : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HomeEvents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HomeEventName = c.String(),
                        EventCategory = c.Int(nullable: false),
                        Duration = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
        }
        
        public override void Down()
        {
            DropTable("dbo.HomeEvents");
        }
    }
}
