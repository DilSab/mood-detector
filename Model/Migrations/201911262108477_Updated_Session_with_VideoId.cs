namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Updated_Session_with_VideoId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sessions", "VideoId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sessions", "VideoId");
        }
    }
}
