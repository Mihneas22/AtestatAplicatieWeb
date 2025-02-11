using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.UserDTO.AddFriends
{
    public class AddFriendDTO
    {
        [Required]
        public string NameWhoRequested { get; set; } = string.Empty;

        [Required]
        public string NameWhoRecieved{ get; set; } = string.Empty;
    }
}
