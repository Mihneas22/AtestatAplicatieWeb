using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.UserDTO.GetUserByName
{
    public class GetUserByNameDTO
    {
        [Required]
        public string Username { get; set; } = string.Empty;
    }
}
