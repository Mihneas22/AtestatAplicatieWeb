using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.AuthDTO.Register
{
    public record RegisterResponse(bool Flag, string message = null!);
}
