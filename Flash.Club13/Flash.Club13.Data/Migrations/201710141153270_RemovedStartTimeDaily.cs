namespace Flash.Club13.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedStartTimeDaily : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.DailyWorkouts", "StartTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DailyWorkouts", "StartTime", c => c.DateTime(nullable: false));
        }
    }
}
