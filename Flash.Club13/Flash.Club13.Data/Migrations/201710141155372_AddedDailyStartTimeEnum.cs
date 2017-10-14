namespace Flash.Club13.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDailyStartTimeEnum : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DailyWorkouts", "StartTime", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DailyWorkouts", "StartTime");
        }
    }
}
