using Application.DTOs.AuthDTO.Login;
using Application.DTOs.AuthDTO.Register;
using Application.DTOs.UserDTO.AcceptFriendsRequest;
using Application.DTOs.UserDTO.AddFriends;
using Application.DTOs.UserDTO.RemoveFriends;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<AcceptFriendRequestResponse> AcceptFriendRequestService(AcceptFriendRequestDTO acceptFriendRequestDTO)
        {
            var conn = await _httpClient.PostAsJsonAsync("api/user/acceptFriendRequest", acceptFriendRequestDTO);
            var result = await conn.Content.ReadFromJsonAsync<AcceptFriendRequestResponse>();
            return result!;
        }

        public async Task<AddFriendResponse> AddFriendService(AddFriendDTO addFriendDTO)
        {
            var conn = await _httpClient.PostAsJsonAsync("api/user/addFriend", addFriendDTO);
            var result = await conn.Content.ReadFromJsonAsync<AddFriendResponse>();
            return result!;
        }

        public async Task<LoginResponse> LoginUserService(LoginDTO loginDTO)
        {
            var conn = await _httpClient.PostAsJsonAsync("api/user/loginUser", loginDTO);
            var result = await conn.Content.ReadFromJsonAsync<LoginResponse>();
            return result!;
        }

        public async Task<RegisterResponse> RegisterUserService(RegisterDTO registerDTO)
        {
            var conn = await _httpClient.PostAsJsonAsync("api/user/registerUser", registerDTO);
            var result = await conn.Content.ReadFromJsonAsync<RegisterResponse>();
            return result!;
        }

        public async Task<RemoveFriendResponse> RemoveFriendService(RemoveFriendDTO removeFriendDTO)
        {
            var conn = await _httpClient.PostAsJsonAsync("api/user/removeFriend", removeFriendDTO);
            var result = await conn.Content.ReadFromJsonAsync<RemoveFriendResponse>();
            return result!;
        }
    }
}
