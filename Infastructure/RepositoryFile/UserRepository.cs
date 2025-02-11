using Application.DTOs.AuthDTO.Login;
using Application.DTOs.AuthDTO.Register;
using Application.Repository;
using BCrypt.Net;
using Domain.Models;
using Infastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Infastructure.RepositoryFile
{
    public class UserRepository : IUser
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IConfiguration _configuration;

        public UserRepository(ApplicationDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }
        private string GenerateJWTToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var userClaims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username!),
                new Claim(ClaimTypes.Email, user.Email!),
            };

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: userClaims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<LoginResponse> LoginUserAsync(LoginDTO loginDTO)
        {
            if (loginDTO == null)
                return new LoginResponse(false, "Invalid");

            var user = await _dbContext.UsersEntity.FirstOrDefaultAsync(u=> u.Email == loginDTO.Email);
            if (user == null)
                return new LoginResponse(false, "User not found");

            bool checkPass = BCrypt.Net.BCrypt.Verify(loginDTO.Password, user.Password);
            if (checkPass)
            {
                string token = GenerateJWTToken(user);
                return new LoginResponse(true, "Logare cu succes!", token);
            }
            else
                return new LoginResponse(false, "Date invalide");
        }

        public async Task<RegisterResponse> RegisterUserAsync(RegisterDTO registerDTO)
        {
            if (registerDTO == null)
                return new RegisterResponse(false, "Invalid");

            var user = await _dbContext.UsersEntity.FirstOrDefaultAsync(u => u.Email == registerDTO.Email);
            if (user != null)
                return new RegisterResponse(false, "User cu acelasi email deja exista.");

            _dbContext.UsersEntity.Add(new User
            {
                Username = registerDTO.Username,
                Email = registerDTO.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(registerDTO.Password),
                MealsSaved = new List<string>(),
                Friends = new List<string>(),
                CreatedTime = DateTime.Now,
            });

            await _dbContext.SaveChangesAsync();

            return new RegisterResponse(true, "Succes, va puteti loga acum!");
        }
    }
}
