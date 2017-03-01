using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CNCDataManager.Controllers.Internals
{
    internal enum AuthorizationLevel
    {
        Tourist,
        Member,
        AdvancedMember,
        ResourceOwner,
        Administrator,
        Root
    }
}
