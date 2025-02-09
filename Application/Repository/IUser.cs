using Application.DTOs.AuthDTO.Login;
using Application.DTOs.AuthDTO.Register;
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
    }
}
