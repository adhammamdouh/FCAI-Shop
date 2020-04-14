using System.ComponentModel.DataAnnotations.Schema;
using FCAI_Shop._Utilities;
using FCAI_Shop.Dtos;

namespace FCAI_Shop.Models
{
    [Table("Users")]
    public class User : ApplicationUser
    {
        private User()
        {

        }
        public User(UserDto user) : base(user, Roles.User)
        {
        }
        public new UserDto ToDto()
        {
            return new UserDto
            { Email = Email, Name = Name, Password = "".PadRight(Password.Length, '*'), UserName = UserName };
        }

    }
}
