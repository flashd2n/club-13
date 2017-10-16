using Flash.Club13.Data.Repository;
using Flash.Club13.Data.UnitOfWork;
using Flash.Club13.Interfaces.Services;
using Flash.Club13.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Flash.Club13.Services
{
    public class PendingWorkoutService : IPendingWorkoutService
    {
        private readonly IEfRepostory<PendingWorkout> pendingWorkoutsRepo;
        private readonly IUnitOfWork unitOfWork;

        public PendingWorkoutService(IEfRepostory<PendingWorkout> pendingWorkoutsRepo, IUnitOfWork unitOfWork)
        {
            this.pendingWorkoutsRepo = pendingWorkoutsRepo ?? throw new ArgumentException("PendingWorkout repo cannot be null");
            this.unitOfWork = unitOfWork ?? throw new ArgumentException("Unit of work cannot be null");
        }

        public ICollection<PendingWorkout> GetAll()
        {
            return this.pendingWorkoutsRepo.All.ToList();
        }

        public PendingWorkout GetById(Guid id)
        {
            return this.pendingWorkoutsRepo.All.FirstOrDefault(x => x.Id == id);
        }

        public void Update(PendingWorkout pendingWorkout)
        {
            if (pendingWorkout == null)
            {
                throw new ArgumentException("PendingWorkout cannot be null");
            }

            this.pendingWorkoutsRepo.Update(pendingWorkout);
            this.unitOfWork.Commit();
        }

        public void AddPending(PendingWorkout pendingWorkout)
        {
            if (pendingWorkout == null)
            {
                throw new ArgumentException("PendingWorkout cannot be null");
            }

            this.pendingWorkoutsRepo.Add(pendingWorkout);
            this.unitOfWork.Commit();
        }

        public void MarkPendingAsCompleted(PendingWorkout pendingWorkout)
        {
            if (pendingWorkout == null)
            {
                throw new ArgumentException("PendingWorkout cannot be null");
            }

            pendingWorkout.IsCompleted = true;
            this.Update(pendingWorkout);
        }
    }
}
