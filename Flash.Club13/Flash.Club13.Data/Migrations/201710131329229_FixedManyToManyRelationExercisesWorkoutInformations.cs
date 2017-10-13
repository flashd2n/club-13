namespace Flash.Club13.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixedManyToManyRelationExercisesWorkoutInformations : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Exercises", "WorkoutInformation_Id", "dbo.WorkoutInformations");
            DropIndex("dbo.Exercises", new[] { "WorkoutInformation_Id" });
            CreateTable(
                "dbo.ExerciseWorkoutInformations",
                c => new
                    {
                        Exercise_Id = c.Guid(nullable: false),
                        WorkoutInformation_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Exercise_Id, t.WorkoutInformation_Id })
                .ForeignKey("dbo.Exercises", t => t.Exercise_Id, cascadeDelete: true)
                .ForeignKey("dbo.WorkoutInformations", t => t.WorkoutInformation_Id, cascadeDelete: true)
                .Index(t => t.Exercise_Id)
                .Index(t => t.WorkoutInformation_Id);
            
            DropColumn("dbo.Exercises", "WorkoutInformation_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Exercises", "WorkoutInformation_Id", c => c.Guid());
            DropForeignKey("dbo.ExerciseWorkoutInformations", "WorkoutInformation_Id", "dbo.WorkoutInformations");
            DropForeignKey("dbo.ExerciseWorkoutInformations", "Exercise_Id", "dbo.Exercises");
            DropIndex("dbo.ExerciseWorkoutInformations", new[] { "WorkoutInformation_Id" });
            DropIndex("dbo.ExerciseWorkoutInformations", new[] { "Exercise_Id" });
            DropTable("dbo.ExerciseWorkoutInformations");
            CreateIndex("dbo.Exercises", "WorkoutInformation_Id");
            AddForeignKey("dbo.Exercises", "WorkoutInformation_Id", "dbo.WorkoutInformations", "Id");
        }
    }
}
