namespace PlanUp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SongDbSet1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SongDbSets", "song_SongId", "dbo.Songs");
            DropIndex("dbo.SongDbSets", new[] { "song_SongId" });
            AddColumn("dbo.SongDbSets", "SongId", c => c.Int(nullable: false));
            DropColumn("dbo.SongDbSets", "song_SongId");
            DropTable("dbo.Songs");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Songs",
                c => new
                    {
                        SongId = c.String(nullable: false, maxLength: 128),
                        Title = c.String(),
                        Etag = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.SongId);
            
            AddColumn("dbo.SongDbSets", "song_SongId", c => c.String(maxLength: 128));
            DropColumn("dbo.SongDbSets", "SongId");
            CreateIndex("dbo.SongDbSets", "song_SongId");
            AddForeignKey("dbo.SongDbSets", "song_SongId", "dbo.Songs", "SongId");
        }
    }
}
