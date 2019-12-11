namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedSessionSVGtoJoinSessionmodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.JoinSessions", "SessionSVG", c => c.String(unicode: false, storeType: "text"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.JoinSessions", "SessionSVG");
        }
    }
}
