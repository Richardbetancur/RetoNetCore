using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExtraHoursAPI.Models.Response
{
    public class UserResponse
    {
        public string Email { get; set; }
        public int IdRol { get; set; }
        public string Token { get; set; }
    }
}
