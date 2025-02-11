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

namespace Application.Repository
{
    public interface IUser
    {
        Task<RegisterResponse> RegisterUserAsync(RegisterDTO registerDTO);

        Task<LoginResponse> LoginUserAsync(LoginDTO loginDTO);

        Task<AddFriendResponse> AddFriendAsync(AddFriendDTO addFriendDTO);

        Task<RemoveFriendResponse> RemoveFriendAsync(RemoveFriendDTO removeFriendDTO);

        Task<AcceptFriendRequestResponse> AcceptFriendRequestAsync(AcceptFriendRequestDTO acceptFriendRequestDTO);
    }
}
