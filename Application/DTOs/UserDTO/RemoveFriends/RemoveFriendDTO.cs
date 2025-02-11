using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.UserDTO.RemoveFriends
{
    public class RemoveFriendDTO
    {
        [Required]
        public string NameWhoRequested { get; set; } = string.Empty;

        [Required]
        public string NameWhoWasRemoved{ get; set; } = string.Empty;
    }
}
