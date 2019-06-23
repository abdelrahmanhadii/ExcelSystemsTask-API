using DTOs;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Contracts
{
    public interface IUserService
    {
        string Login(LoginDTO loginDTO);
        string Token(string role, string userId);
    }
}
