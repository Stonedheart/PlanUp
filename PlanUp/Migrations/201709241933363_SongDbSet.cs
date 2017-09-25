namespace PlanUp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SongDbSet : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SongDbSets",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        song_SongId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Songs", t => t.song_SongId)
                .Index(t => t.song_SongId);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SongDbSets", "song_SongId", "dbo.Songs");
            DropIndex("dbo.SongDbSets", new[] { "song_SongId" });
            DropTable("dbo.Songs");
            DropTable("dbo.SongDbSets");
        }
    }
}
