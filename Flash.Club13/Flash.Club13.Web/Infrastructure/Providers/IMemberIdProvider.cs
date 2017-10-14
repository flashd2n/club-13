using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flash.Club13.Web.Infrastructure.Providers
{
    public interface IMemberIdProvider
    {
        string GetLoggeedUserId();
    }
}
