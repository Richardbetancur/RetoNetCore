using ExtraHoursAPI.Models;
using ExtraHoursAPI.Models.Common;
using ExtraHoursAPI.Models.Request;
using ExtraHoursAPI.Models.Response;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ExtraHoursAPI.Services
{
    public class UserService : IUserService
    {
        private readonly HoursContext _context;
        private readonly AppSettings _appSettings;

        public UserService(HoursContext context, IOptions<AppSettings> appSettings)
        {
            _context = context;
            _appSettings = appSettings.Value;
        }
        public UserResponse Auth(AuthRequest model)
        {

            UserResponse userResponse = new UserResponse();
           

                var user = _context.Users.Where(u => u.Email == model.Email &&
                                             u.Password == model.Password).FirstOrDefault();
                if (user == null) return null;

                userResponse.Email = user.Email;
                userResponse.IdRol = user.IdRol;
                userResponse.Token = GetToken(user);
            
            

            return userResponse;
        }

        private string GetToken(Users user) 
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var myKey = Encoding.ASCII.GetBytes(_appSettings.MySecret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    new Claim[]
                    {

                        new Claim(ClaimTypes.NameIdentifier, user.IdUser.ToString()),
                        new Claim(ClaimTypes.Email, user.Email),
                        new Claim(ClaimTypes.Role, user.IdRol.ToString())
                        
                    }

                    ),
                Expires = DateTime.UtcNow.AddDays(15),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(myKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
