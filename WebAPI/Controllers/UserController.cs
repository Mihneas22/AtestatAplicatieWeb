using Application.DTOs.AuthDTO.Login;
using Application.DTOs.AuthDTO.Register;
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
        public async Task<ActionResult<LoginResponse>> LoginResponseAsync(LoginDTO loginDTO)
        {
            var result = await userRepo.LoginUserAsync(loginDTO);
            return Ok(result);
        }
    }
}
