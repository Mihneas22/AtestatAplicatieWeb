using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.UserDTO.GetUserByName
{
    public record GetUserByNameResponse(bool Flag, string message = null!,User user = null!);
}
