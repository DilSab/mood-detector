namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class JoinSessionSessionVideoID : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.JoinSessions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SessionId = c.Int(nullable: false),
                        JoinName = c.String(),
                        DateTime = c.DateTime(nullable: false),
                        JoinSessionSVG = c.String(unicode: false, storeType: "text"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sessions", t => t.SessionId, cascadeDelete: true)
                .Index(t => t.SessionId);
            
            AddColumn("dbo.Sessions", "VideoId", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.JoinSessions", "SessionId", "dbo.Sessions");
            DropIndex("dbo.JoinSessions", new[] { "SessionId" });
            DropColumn("dbo.Sessions", "VideoId");
            DropTable("dbo.JoinSessions");
        }
    }
}
