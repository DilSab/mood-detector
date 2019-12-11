namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Hash : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LoginInfoes", "Salt", c => c.String());
            AddColumn("dbo.LoginInfoes", "Hash", c => c.String());
            DropColumn("dbo.LoginInfoes", "Password");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LoginInfoes", "Password", c => c.String());
            DropColumn("dbo.LoginInfoes", "Hash");
            DropColumn("dbo.LoginInfoes", "Salt");
        }
    }
}
