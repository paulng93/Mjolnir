using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Hudl.Mjolnir.Attributes;
using ThorsHammerPoCConsole.Models;

namespace ThorsHammerPoCConsole
{
    [Command("core-client","core-user", 15000)]
    public interface IUserServices
    {
        Task<UserDto> GetInfo(int count, CancellationToken? token = null);
    }
}
