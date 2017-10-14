using Flash.Club13.Interfaces.Data.Models.Base;
using Flash.Club13.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace Flash.Club13.Data
{
    public class MainDbContext : IdentityDbContext<User>
    {
        public MainDbContext()
            : base("MainDb", throwIfV1Schema: false)
        {
        }

        public static MainDbContext Create()
        {
            return new MainDbContext();
        }

        public IDbSet<Test> Tests { get; set; }

        public IDbSet<Exercise> Exercises { get; set; }

        public IDbSet<WorkoutInformation> WorkoutInformations { get; set; }

        public IDbSet<Workout> Workouts { get; set; }

        public IDbSet<Member> Members { get; set; }

        public IDbSet<DailyWorkout> DailyWorkouts { get; set; }

        public IDbSet<WeekSchedule> WeekSchedules { get; set; }

        public IDbSet<PendingWorkout> PendingWorkouts { get; set; }

        public override int SaveChanges()
        {
            this.ApplyAuditInfo();
            return base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            this.OnExerciseBuilding(modelBuilder);

            this.OnWorkoutInformationBuilding(modelBuilder);

            this.OnWorkoutBuilding(modelBuilder);

            this.OnMemberBuilding(modelBuilder);

            this.OnDailyWorkoutBuilding(modelBuilder);

            this.OnWeekScheduleBuilding(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private void OnWeekScheduleBuilding(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WeekSchedule>()
                .Property(weekSchedule => weekSchedule.WeekStart)
                .IsRequired();

            modelBuilder.Entity<WeekSchedule>()
                .Property(weekSchedule => weekSchedule.WeekEnd)
                .IsRequired();
        }

        private void OnDailyWorkoutBuilding(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DailyWorkout>()
                .Property(dailyWorkout => dailyWorkout.Day)
                .IsRequired()
                .HasMaxLength(60);

            //modelBuilder.Entity<DailyWorkout>()
            //    .Property(dailyWorkout => dailyWorkout.StartTime)
            //    .IsRequired();

            modelBuilder.Entity<DailyWorkout>()
                .Property(dailyWorkout => dailyWorkout.DurationInMinutes)
                .IsRequired();

            modelBuilder.Entity<DailyWorkout>()
                .HasRequired(dailyWorkout => dailyWorkout.WorkoutInformation);
        }

        private void OnMemberBuilding(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Member>()
                .HasRequired(member => member.User);

            modelBuilder.Entity<Member>()
                .Property(member => member.FirstName)
                .IsRequired()
                .HasMaxLength(60);

            modelBuilder.Entity<Member>()
                .Property(member => member.LastName)
                .IsRequired()
                .HasMaxLength(60);

            modelBuilder.Entity<Member>()
                .Property(member => member.Gender)
                .IsRequired();
        }

        private void OnWorkoutBuilding(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Workout>()
                .HasRequired(workout => workout.Member);

            modelBuilder.Entity<Workout>()
                .HasRequired(workout => workout.WorkoutInformation);

            modelBuilder.Entity<Workout>()
                .Property(workout => workout.Time)
                .IsRequired();
        }

        private void OnWorkoutInformationBuilding(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WorkoutInformation>()
                .Property(wI => wI.Name)
                .IsRequired()
                .HasMaxLength(60);

            modelBuilder.Entity<WorkoutInformation>()
                .Property(wI => wI.Description)
                .IsRequired()
                .IsMaxLength();

            modelBuilder.Entity<WorkoutInformation>()
                .Property(wI => wI.VideoLink)
                .IsOptional()
                .HasMaxLength(100);

            modelBuilder.Entity<WorkoutInformation>()
                .Property(wI => wI.BestTime)
                .IsOptional();
        }

        private void OnExerciseBuilding(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Exercise>()
                .Property(exercise => exercise.Name)
                .IsRequired()
                .HasMaxLength(60);
        }

        private void ApplyAuditInfo()
        {
            Func<DbEntityEntry, bool> filterEntityRule = x => x.Entity is IAuditable && (x.State == EntityState.Added || x.State == EntityState.Modified);

            foreach (var entry in this.ChangeTracker.Entries().Where(filterEntityRule))
            {
                var entity = (IAuditable)entry.Entity;

                if (entry.State == EntityState.Added && entity.CreatedOn == default(DateTime?))
                {
                    entity.CreatedOn = DateTime.Now;
                }
                else
                {
                    entity.ModifiedOn = DateTime.Now;
                }
            }
        }
    }
}
