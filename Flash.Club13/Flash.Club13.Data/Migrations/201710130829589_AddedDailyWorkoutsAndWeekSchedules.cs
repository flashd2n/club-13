namespace Flash.Club13.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDailyWorkoutsAndWeekSchedules : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DailyWorkouts",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Day = c.String(nullable: false, maxLength: 60),
                        WorkoutInformationId = c.Guid(nullable: false),
                        CreatedOn = c.DateTime(),
                        ModifiedOn = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                        WeekSchedule_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.WorkoutInformations", t => t.WorkoutInformationId, cascadeDelete: true)
                .ForeignKey("dbo.WeekSchedules", t => t.WeekSchedule_Id)
                .Index(t => t.WorkoutInformationId)
                .Index(t => t.IsDeleted)
                .Index(t => t.WeekSchedule_Id);
            
            CreateTable(
                "dbo.WeekSchedules",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        WeekStart = c.DateTime(nullable: false),
                        WeekEnd = c.DateTime(nullable: false),
                        CreatedOn = c.DateTime(),
                        ModifiedOn = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsDeleted);
            
            AddColumn("dbo.Members", "DailyWorkout_Id", c => c.Guid());
            CreateIndex("dbo.Members", "DailyWorkout_Id");
            AddForeignKey("dbo.Members", "DailyWorkout_Id", "dbo.DailyWorkouts", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DailyWorkouts", "WeekSchedule_Id", "dbo.WeekSchedules");
            DropForeignKey("dbo.DailyWorkouts", "WorkoutInformationId", "dbo.WorkoutInformations");
            DropForeignKey("dbo.Members", "DailyWorkout_Id", "dbo.DailyWorkouts");
            DropIndex("dbo.WeekSchedules", new[] { "IsDeleted" });
            DropIndex("dbo.Members", new[] { "DailyWorkout_Id" });
            DropIndex("dbo.DailyWorkouts", new[] { "WeekSchedule_Id" });
            DropIndex("dbo.DailyWorkouts", new[] { "IsDeleted" });
            DropIndex("dbo.DailyWorkouts", new[] { "WorkoutInformationId" });
            DropColumn("dbo.Members", "DailyWorkout_Id");
            DropTable("dbo.WeekSchedules");
            DropTable("dbo.DailyWorkouts");
        }
    }
}
