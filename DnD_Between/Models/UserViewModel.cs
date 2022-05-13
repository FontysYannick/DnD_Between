using System.ComponentModel.DataAnnotations;

namespace DnD_Between.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}
