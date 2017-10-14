using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Flash.Club13.Web.Models.Home
{
    public class SignUpWoDViewModel
    {
        public SignUpWoDViewModel()
        {
            this.AllDailyWoDs = new List<HomeDailyWoDViewModel>();
        }

        public bool IsSigned { get; set; }

        public HomeDailyWoDViewModel SignedDailyWoD { get; set; }

        public Guid SelectedWoDId { get; set; }

        public ICollection<HomeDailyWoDViewModel> AllDailyWoDs { get; set; }
    }
}