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
            this.pendingWorkoutsRepo = pendingWorkoutsRepo;
            this.unitOfWork = unitOfWork;
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
            this.pendingWorkoutsRepo.Update(pendingWorkout);
            this.unitOfWork.Commit();
        }

        public void AddPending(PendingWorkout pendingWorkout)
        {
            this.pendingWorkoutsRepo.Add(pendingWorkout);
            this.unitOfWork.Commit();
        }

        public void MarkPendingAsCompleted(PendingWorkout pendingWorkout)
        {
            pendingWorkout.IsCompleted = true;
            this.Update(pendingWorkout);
        }
    }
}
