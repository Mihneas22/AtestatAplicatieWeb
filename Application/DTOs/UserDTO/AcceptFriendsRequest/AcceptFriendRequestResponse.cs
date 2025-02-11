using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.UserDTO.AcceptFriendsRequest
{
    public record AcceptFriendRequestResponse(bool Flag, string message = null!);
}
