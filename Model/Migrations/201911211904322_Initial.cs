namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GlobalMessages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        UserId = c.Int(nullable: false),
                        Content = c.String(),
                        PostedDate = c.DateTime(nullable: false),
                        ExpirationDate = c.DateTime(),
                        RecipientType = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Firstname = c.String(),
                        Lastname = c.String(),
                        AccessRights = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LoginInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Username = c.String(),
                        Password = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Sessions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Subject = c.String(),
                        Class = c.String(),
                        DateTime = c.DateTime(nullable: false),
                        Comments = c.String(),
                        MessageSeen = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Moods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SessionId = c.Int(nullable: false),
                        Anger = c.Double(nullable: false),
                        Joy = c.Double(nullable: false),
                        Contempt = c.Double(nullable: false),
                        Disgust = c.Double(nullable: false),
                        Engagement = c.Double(nullable: false),
                        Fear = c.Double(nullable: false),
                        Sadness = c.Double(nullable: false),
                        Suprise = c.Double(nullable: false),
                        Valence = c.Double(nullable: false),
                        Emoji = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sessions", t => t.SessionId, cascadeDelete: true)
                .Index(t => t.SessionId);
            
            CreateTable(
                "dbo.LearningMessages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        SessionId = c.Int(nullable: false),
                        Mask = c.Int(nullable: false),
                        Link = c.String(),
                        SessionTime = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sessions", "UserId", "dbo.Users");
            DropForeignKey("dbo.Moods", "SessionId", "dbo.Sessions");
            DropForeignKey("dbo.LoginInfoes", "UserId", "dbo.Users");
            DropForeignKey("dbo.GlobalMessages", "UserId", "dbo.Users");
            DropIndex("dbo.Moods", new[] { "SessionId" });
            DropIndex("dbo.Sessions", new[] { "UserId" });
            DropIndex("dbo.LoginInfoes", new[] { "UserId" });
            DropIndex("dbo.GlobalMessages", new[] { "UserId" });
            DropTable("dbo.LearningMessages");
            DropTable("dbo.Moods");
            DropTable("dbo.Sessions");
            DropTable("dbo.LoginInfoes");
            DropTable("dbo.Users");
            DropTable("dbo.GlobalMessages");
        }
    }
}
