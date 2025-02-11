using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string? Username {  get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }

        public List<string>? Friends {  get; set; }

        public List<string>? MealsSaved { get; set; }

        public DateTime? CreatedTime { get; set; }
    }
}
