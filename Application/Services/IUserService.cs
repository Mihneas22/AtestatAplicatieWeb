using Application.DTOs.AuthDTO.Login;
using Application.DTOs.AuthDTO.Register;
using Application.DTOs.UserDTO.AcceptFriendsRequest;
using Application.DTOs.UserDTO.AddFriends;
using Application.DTOs.UserDTO.RemoveFriends;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IUserService
    {
        Task<RegisterResponse> RegisterUserService(RegisterDTO registerDTO);

        Task<LoginResponse> LoginUserService(LoginDTO loginDTO);

        Task<AddFriendResponse> AddFriendService(AddFriendDTO addFriendDTO);

        Task<RemoveFriendResponse> RemoveFriendService(RemoveFriendDTO removeFriendDTO);

        Task<AcceptFriendRequestResponse> AcceptFriendRequestService(AcceptFriendRequestDTO acceptFriendRequestDTO);
    }
}
