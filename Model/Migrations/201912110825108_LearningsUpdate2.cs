namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LearningsUpdate2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LearningMessages", "session_Id", c => c.Int());
            CreateIndex("dbo.LearningMessages", "session_Id");
            AddForeignKey("dbo.LearningMessages", "session_Id", "dbo.Sessions", "Id");
            DropColumn("dbo.LearningMessages", "SessionId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LearningMessages", "SessionId", c => c.Int(nullable: false));
            DropForeignKey("dbo.LearningMessages", "session_Id", "dbo.Sessions");
            DropIndex("dbo.LearningMessages", new[] { "session_Id" });
            DropColumn("dbo.LearningMessages", "session_Id");
        }
    }
}
