namespace PlanUp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyRejectedProposition : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RejectedPropositions", "Tag", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.RejectedPropositions", "Tag");
        }
    }
}
