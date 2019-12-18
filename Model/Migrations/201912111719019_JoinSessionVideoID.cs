namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class JoinSessionVideoID : DbMigration
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.JoinSessions", "SessionId", "dbo.Sessions");
            DropIndex("dbo.JoinSessions", new[] { "SessionId" });
            DropTable("dbo.JoinSessions");
        }
    }
}
