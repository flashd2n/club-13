namespace Flash.Club13.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixedManyToManyDailyWorkoutsToMembersRelation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Members", "DailyWorkout_Id", "dbo.DailyWorkouts");
            DropIndex("dbo.Members", new[] { "DailyWorkout_Id" });
            CreateTable(
                "dbo.MemberDailyWorkouts",
                c => new
                    {
                        Member_Id = c.Guid(nullable: false),
                        DailyWorkout_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Member_Id, t.DailyWorkout_Id })
                .ForeignKey("dbo.Members", t => t.Member_Id, cascadeDelete: true)
                .ForeignKey("dbo.DailyWorkouts", t => t.DailyWorkout_Id, cascadeDelete: true)
                .Index(t => t.Member_Id)
                .Index(t => t.DailyWorkout_Id);
            
            DropColumn("dbo.Members", "DailyWorkout_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Members", "DailyWorkout_Id", c => c.Guid());
            DropForeignKey("dbo.MemberDailyWorkouts", "DailyWorkout_Id", "dbo.DailyWorkouts");
            DropForeignKey("dbo.MemberDailyWorkouts", "Member_Id", "dbo.Members");
            DropIndex("dbo.MemberDailyWorkouts", new[] { "DailyWorkout_Id" });
            DropIndex("dbo.MemberDailyWorkouts", new[] { "Member_Id" });
            DropTable("dbo.MemberDailyWorkouts");
            CreateIndex("dbo.Members", "DailyWorkout_Id");
            AddForeignKey("dbo.Members", "DailyWorkout_Id", "dbo.DailyWorkouts", "Id");
        }
    }
}
