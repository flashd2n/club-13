using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;

namespace Flash.Club13.Web.Infrastructure.Providers
{
    public class MemberIdProvider : IMemberIdProvider
    {
        public string GetLoggeedUserId()
        {
            var id = HttpContext.Current.User.Identity.GetUserId();
            return id;
        }
    }
}