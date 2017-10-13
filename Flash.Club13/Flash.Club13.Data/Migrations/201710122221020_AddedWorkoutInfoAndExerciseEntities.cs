namespace Flash.Club13.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedWorkoutInfoAndExerciseEntities : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Exercises",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 60),
                        CreatedOn = c.DateTime(),
                        ModifiedOn = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                        WorkoutInformation_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.WorkoutInformations", t => t.WorkoutInformation_Id)
                .Index(t => t.IsDeleted)
                .Index(t => t.WorkoutInformation_Id);
            
            CreateTable(
                "dbo.WorkoutInformations",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 60),
                        Description = c.String(nullable: false),
                        VideoLink = c.String(maxLength: 100),
                        BestTime = c.Time(precision: 7),
                        CreatedOn = c.DateTime(),
                        ModifiedOn = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsDeleted);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Exercises", "WorkoutInformation_Id", "dbo.WorkoutInformations");
            DropIndex("dbo.WorkoutInformations", new[] { "IsDeleted" });
            DropIndex("dbo.Exercises", new[] { "WorkoutInformation_Id" });
            DropIndex("dbo.Exercises", new[] { "IsDeleted" });
            DropTable("dbo.WorkoutInformations");
            DropTable("dbo.Exercises");
        }
    }
}
