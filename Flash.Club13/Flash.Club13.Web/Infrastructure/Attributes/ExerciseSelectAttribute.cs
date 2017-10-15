using Flash.Club13.Web.Areas.Administration.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Flash.Club13.Web.Infrastructure.Attributes
{
    public class ExerciseSelectAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var workout = (CreateWorkoutViewModel)validationContext.ObjectInstance;

            if (workout.AllExercises.Any(x => x.IsSelected == true))
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("Pleaase select atleast on exercise");
        }
    }
}