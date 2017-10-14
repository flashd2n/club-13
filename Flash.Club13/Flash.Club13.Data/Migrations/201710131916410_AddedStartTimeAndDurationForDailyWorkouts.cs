namespace Flash.Club13.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedStartTimeAndDurationForDailyWorkouts : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DailyWorkouts", "StartTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.DailyWorkouts", "DurationInMinutes", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DailyWorkouts", "DurationInMinutes");
            DropColumn("dbo.DailyWorkouts", "StartTime");
        }
    }
}
