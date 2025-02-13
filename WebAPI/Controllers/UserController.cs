using Application.DTOs.AuthDTO.Login;
using Application.DTOs.AuthDTO.Register;
using Application.DTOs.UserDTO.AcceptFriendsRequest;
using Application.DTOs.UserDTO.AddFriends;
using Application.DTOs.UserDTO.GetUserByName;
using Application.DTOs.UserDTO.GetUserFriends;
using Application.DTOs.UserDTO.RemoveFriends;
using Application.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser userRepo;

        public UserController(IUser userRepo)
        {
            this.userRepo = userRepo;
        }

        [HttpPost("registerUser")]
        public async Task<ActionResult<RegisterResponse>> RegisterUserAsync(RegisterDTO registerDTO)
        {
            var result = await userRepo.RegisterUserAsync(registerDTO);
            return Ok(result);
        }

        [HttpPost("loginUser")]
        public async Task<ActionResult<LoginResponse>> LoginUserAsync(LoginDTO loginDTO)
        {
            var result = await userRepo.LoginUserAsync(loginDTO);
            return Ok(result);
        }

        [HttpPost("addFriend")]
        public async Task<ActionResult<AddFriendResponse>> AddFriendAsync(AddFriendDTO addFriendDTO)
        {
            var result = await userRepo.AddFriendAsync(addFriendDTO);
            return Ok(result);
        }

        [HttpPost("removeFriend")]
        public async Task<ActionResult<RemoveFriendResponse>> RemoveFriendAsync(RemoveFriendDTO removeFriendDTO)
        {
            var result = await userRepo.RemoveFriendAsync(removeFriendDTO);
            return Ok(result);
        }

        [HttpPost("acceptFriendRequest")]
        public async Task<ActionResult<AcceptFriendRequestResponse>> AcceptFriendRequestAsync(AcceptFriendRequestDTO acceptFriendRequestDTO)
        {
            var result = await userRepo.AcceptFriendRequestAsync(acceptFriendRequestDTO);
            return Ok(result);
        }

        [HttpGet("getUserByName/{username}")]
        public async Task<ActionResult<GetUserByNameResponse>> GetUserByNameAsync(string username)
        {
            var result = await userRepo.GetUserByNameAsync(new GetUserByNameDTO { Username = username });
            return Ok(result);
        }

        [HttpGet("getUserFriends/{username}")]
        public async Task<ActionResult<GetFriendsUserResponse>> GetUserFriendsAsync(string username)
        {
            var result = await userRepo.GetUserFriendsAsync(new GetUserFriendsDTO { Username = username });
            return Ok(result);
        }
    }
}
