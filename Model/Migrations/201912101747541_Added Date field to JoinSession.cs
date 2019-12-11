namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDatefieldtoJoinSession : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.JoinSessions", "DateTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.JoinSessions", "JoinSessionSVG", c => c.String(unicode: false, storeType: "text"));
            DropColumn("dbo.JoinSessions", "SessionSVG");
        }
        
        public override void Down()
        {
            AddColumn("dbo.JoinSessions", "SessionSVG", c => c.String(unicode: false, storeType: "text"));
            DropColumn("dbo.JoinSessions", "JoinSessionSVG");
            DropColumn("dbo.JoinSessions", "DateTime");
        }
    }
}
