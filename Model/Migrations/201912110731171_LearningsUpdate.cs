namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LearningsUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LearningMessages", "EmotionName", c => c.String());
            AlterColumn("dbo.LearningMessages", "SessionTime", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.LearningMessages", "SessionTime", c => c.Long(nullable: false));
            DropColumn("dbo.LearningMessages", "EmotionName");
        }
    }
}
