using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExtraHoursAPI.Models.Response;
using ExtraHoursAPI.Models.Request;

namespace ExtraHoursAPI.Services
{
    public interface IUserService
    {
        UserResponse Auth(AuthRequest model);
    }
}
