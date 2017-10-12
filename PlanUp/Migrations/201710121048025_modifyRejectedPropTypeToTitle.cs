namespace PlanUp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyRejectedPropTypeToTitle : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RejectedPropositions", "Title", c => c.String());
            DropColumn("dbo.RejectedPropositions", "Type");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RejectedPropositions", "Type", c => c.String());
            DropColumn("dbo.RejectedPropositions", "Title");
        }
    }
}
