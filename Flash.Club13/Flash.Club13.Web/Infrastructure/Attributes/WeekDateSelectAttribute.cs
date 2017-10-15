using Flash.Club13.Web.Areas.Administration.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Flash.Club13.Web.Infrastructure.Attributes
{
    public class WeekDateSelectAttribute : ValidationAttribute
    {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var schedule = (CreateWeekScheduleViewModel)validationContext.ObjectInstance;

            if (schedule.WeekEnd > schedule.WeekStart)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("Week cannot begin before the end");
        }

    }
}