using ExtraHoursAPI.Models;
using ExtraHoursAPI.Models.Request;
using ExtraHoursAPI.Models.Response;
using ExtraHoursAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExtraHoursAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly HoursContext _context;
        private IUserService _userService;

        public LoginController(IUserService userService, HoursContext context)
        {
            _userService = userService;
            _context = context;
        }

    


        [HttpPost("Authentication")]
        public IActionResult Autenticate([FromBody] AuthRequest model)
        {
            Response response = new Response();
            var userResponse = _userService.Auth(model);

            if (userResponse == null)
            {
                response.Exito = 0;
                response.Message = "Usuario o Contraseñña Incorrecta";
                return BadRequest(response);
            }

            response.Exito = 1;
            response.Data = userResponse;
            return Ok(response);
        }
    }
}
