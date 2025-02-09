using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.AuthDTO.Login
{
    public record LoginResponse(bool Flag, string message = null!, string Token = null!);
}
