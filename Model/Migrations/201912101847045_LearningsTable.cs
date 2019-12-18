namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LearningsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Learnings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Mask = c.Int(nullable: false),
                        EmotionName = c.String(),
                        Text = c.String(),
                        Link = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Learnings");
        }
    }
}
