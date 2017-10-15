using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Flash.Club13.Web.Models.Home
{
    public class TotalMembersViewModel
    {
        public TotalMembersViewModel()
        {

        }

        public TotalMembersViewModel(int count)
        {
            this.Count = count;
        }

        public int Count { get; set; }
    }
}