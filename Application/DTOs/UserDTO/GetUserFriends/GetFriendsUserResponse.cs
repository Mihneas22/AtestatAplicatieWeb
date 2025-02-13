using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.UserDTO.GetUserFriends
{
    public record GetFriendsUserResponse(bool Flag, string message = null!, List<string> FriendsUsername = null!);
}
