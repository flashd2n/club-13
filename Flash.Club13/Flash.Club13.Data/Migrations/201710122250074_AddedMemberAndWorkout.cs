namespace Flash.Club13.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedMemberAndWorkout : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 60),
                        LastName = c.String(nullable: false, maxLength: 60),
                        Gender = c.Int(nullable: false),
                        UserId = c.String(nullable: false, maxLength: 128),
                        CreatedOn = c.DateTime(),
                        ModifiedOn = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.IsDeleted);
            
            CreateTable(
                "dbo.Workouts",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        MemberId = c.Guid(nullable: false),
                        WorkoutInformationId = c.Guid(nullable: false),
                        Time = c.Time(nullable: false, precision: 7),
                        CreatedOn = c.DateTime(),
                        ModifiedOn = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Members", t => t.MemberId, cascadeDelete: true)
                .ForeignKey("dbo.WorkoutInformations", t => t.WorkoutInformationId, cascadeDelete: true)
                .Index(t => t.MemberId)
                .Index(t => t.WorkoutInformationId)
                .Index(t => t.IsDeleted);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Workouts", "WorkoutInformationId", "dbo.WorkoutInformations");
            DropForeignKey("dbo.Workouts", "MemberId", "dbo.Members");
            DropForeignKey("dbo.Members", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Workouts", new[] { "IsDeleted" });
            DropIndex("dbo.Workouts", new[] { "WorkoutInformationId" });
            DropIndex("dbo.Workouts", new[] { "MemberId" });
            DropIndex("dbo.Members", new[] { "IsDeleted" });
            DropIndex("dbo.Members", new[] { "UserId" });
            DropTable("dbo.Workouts");
            DropTable("dbo.Members");
        }
    }
}
