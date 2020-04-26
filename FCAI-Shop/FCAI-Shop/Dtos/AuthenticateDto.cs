using System.ComponentModel.DataAnnotations;

namespace FCAI_Shop.Dtos
{
    public class AuthenticateDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
