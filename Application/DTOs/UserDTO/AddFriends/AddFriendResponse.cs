﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.UserDTO.AddFriends
{
    public record AddFriendResponse(bool Flag, string message = null!);
}
