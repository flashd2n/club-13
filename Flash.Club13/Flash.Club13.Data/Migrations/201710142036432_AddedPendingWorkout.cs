namespace Flash.Club13.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPendingWorkout : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PendingWorkouts",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        IsCompleted = c.Boolean(nullable: false),
                        CreatedOn = c.DateTime(),
                        ModifiedOn = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                        DailyWorkout_Id = c.Guid(),
                        Member_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DailyWorkouts", t => t.DailyWorkout_Id)
                .ForeignKey("dbo.Members", t => t.Member_Id)
                .Index(t => t.IsDeleted)
                .Index(t => t.DailyWorkout_Id)
                .Index(t => t.Member_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PendingWorkouts", "Member_Id", "dbo.Members");
            DropForeignKey("dbo.PendingWorkouts", "DailyWorkout_Id", "dbo.DailyWorkouts");
            DropIndex("dbo.PendingWorkouts", new[] { "Member_Id" });
            DropIndex("dbo.PendingWorkouts", new[] { "DailyWorkout_Id" });
            DropIndex("dbo.PendingWorkouts", new[] { "IsDeleted" });
            DropTable("dbo.PendingWorkouts");
        }
    }
}
