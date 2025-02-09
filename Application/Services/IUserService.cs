using Application.DTOs.AuthDTO.Login;
using Application.DTOs.AuthDTO.Register;
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
    }
}
