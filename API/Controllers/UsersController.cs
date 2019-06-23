using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BL.Contracts;
using DTOs;
using Logger.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IUserService UserService;
        ILoggerService Logger;
        public UsersController(IUserService userService, ILoggerService logger)
        {
            UserService = userService;
            Logger = logger;
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDTO)
        {
            try
            {
                var Token = UserService.Login(loginDTO);
                if (Token.Length > 0)
                {
                    return await Task.FromResult(Ok(new { token = Token}));
                }
                else
                {
                    return await Task.FromResult(BadRequest("Wrong Password!"));
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.ToString());
                return await Task.FromResult(BadRequest("Error"));
            }
        }
    }
}