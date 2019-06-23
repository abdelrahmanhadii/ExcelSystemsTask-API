using BL.Contracts;
using DAL;
using DTOs;
using Microsoft.IdentityModel.Tokens;
using Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BL.Services
{
    public class UserService:IUserService
    {
        private IRepositoryWrapper RepoWrap;
        public UserService(IRepositoryWrapper repoWrap)
        {
            RepoWrap = repoWrap;
        }
        public string Login(LoginDTO loginDTO)
        {
            var User = RepoWrap.UserRepo.ReadBy(a => a.UserName == loginDTO.UserName && a.Password == loginDTO.Password && a.IsActive == true);
            string Token = "";
            if (User.ID>0)
            {
                Token = this.Token(User.RoleID.ToString(), User.ID.ToString());
            }
            return Token;
        }
        public string Token(string role, string userId)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var tokeOptions = new JwtSecurityToken(
                    issuer: "http://localhost:61086",
                    audience: "http://localhost:61086",
                    claims: new List<Claim>()
                    {
                        new Claim(ClaimTypes.Sid, userId),
                        new Claim(ClaimTypes.Role, role),
                        new Claim("RoleName", role)
                    },
                    expires: DateTime.Now.AddMinutes(50),
                    signingCredentials: signinCredentials
                );
            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
            return tokenString;
        }
    }
}
