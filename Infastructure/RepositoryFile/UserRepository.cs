using Application.DTOs.AuthDTO.Login;
using Application.DTOs.AuthDTO.Register;
using Application.DTOs.UserDTO.AcceptFriendsRequest;
using Application.DTOs.UserDTO.AddFriends;
using Application.DTOs.UserDTO.GetUserByName;
using Application.DTOs.UserDTO.RemoveFriends;
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
                FriendsPending = new List<string>(),
                Friends = new List<string>(),
                Inbox = new List<string>(),
                CreatedTime = DateTime.Now,
            });

            await _dbContext.SaveChangesAsync();

            return new RegisterResponse(true, "Succes, va puteti loga acum!");
        }

        public async Task<AddFriendResponse> AddFriendAsync(AddFriendDTO addFriendDTO)
        {
            if (addFriendDTO == null)
                return new AddFriendResponse(false, "Date invalide...");

            var user2 = await _dbContext.UsersEntity.FirstOrDefaultAsync(u => u.Username == addFriendDTO.NameWhoRecieved);

            if(user2 == null)
                return new AddFriendResponse(false, "User nu a fost gasit...");

            if(user2.Friends != null)
            {
                var listOfFriends = user2.Friends.ToList();
                foreach (var friend in listOfFriends)
                    if (friend == addFriendDTO.NameWhoRequested)
                        return new AddFriendResponse(false, "Deja sunteti prieten cu acest utilizator");
            }

            user2.Inbox!.Add($"You have a friend request from: {addFriendDTO.NameWhoRequested}");
            user2.FriendsPending!.Add(addFriendDTO.NameWhoRequested);
            await _dbContext.SaveChangesAsync();

            return new AddFriendResponse(true, "Succes!");
        }

        public async Task<RemoveFriendResponse> RemoveFriendAsync(RemoveFriendDTO removeFriendDTO)
        {
            if (removeFriendDTO == null)
                return new RemoveFriendResponse(false, "Date invalide...");

            var user2 = await _dbContext.UsersEntity.FirstOrDefaultAsync(u => u.Username == removeFriendDTO.NameWhoWasRemoved);

            if (user2 == null)
                return new RemoveFriendResponse(false, "User nu a fost gasit...");

            user2.Friends!.Remove(user2.Username!);
            await _dbContext.SaveChangesAsync();

            return new RemoveFriendResponse(true, "Succes!");
        }

        public async Task<AcceptFriendRequestResponse> AcceptFriendRequestAsync(AcceptFriendRequestDTO acceptFriendRequestDTO)
        {
            if (acceptFriendRequestDTO == null)
                return new AcceptFriendRequestResponse(false, "Date invalide...");

            var userWhoRecievedRequest = await _dbContext.UsersEntity.FirstOrDefaultAsync(u => u.Username == acceptFriendRequestDTO.NameWhoRecieved);
            var userWhoSendedRequest = await _dbContext.UsersEntity.FirstOrDefaultAsync(u => u.Username == acceptFriendRequestDTO.NameWhoRequested);

            if(userWhoRecievedRequest == null || userWhoSendedRequest == null)
                return new AcceptFriendRequestResponse(false, "Unul dintre useri este invalid.");

            if (acceptFriendRequestDTO.Status == true)
            {
                userWhoRecievedRequest.Friends!.Add(userWhoSendedRequest.Username!);
                userWhoSendedRequest.Friends!.Add(userWhoRecievedRequest.Username!);

                userWhoRecievedRequest.FriendsPending!.Remove(userWhoSendedRequest.Username!);
                await _dbContext.SaveChangesAsync();
            }
            return new AcceptFriendRequestResponse(true, "Succes!");
        }

        public async Task<GetUserByNameResponse> GetUserByNameAsync(GetUserByNameDTO getUserByNameDTO)
        {
            if (getUserByNameDTO == null)
                return new GetUserByNameResponse(false, "Date invalide...");

            var user = await _dbContext.UsersEntity.FirstOrDefaultAsync(u => u.Username == getUserByNameDTO.Username);

            if (user == null)
                return new GetUserByNameResponse(false, "User invalid...");

            return new GetUserByNameResponse(true, "User gasit!", user);
        }
    }
}
