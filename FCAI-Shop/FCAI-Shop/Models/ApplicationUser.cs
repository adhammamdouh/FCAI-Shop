using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FCAI_Shop.Dtos;
using Microsoft.EntityFrameworkCore;
using FCAI_Shop._Utilities;

namespace FCAI_Shop.Models
{
    public abstract class ApplicationUser
    {
        [Key, Column(Order = 0), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, UniqueKey, StringLength(Constants.DefaultStringLength), DataType(DataType.EmailAddress), EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Name { get; set; }

        [Required, UniqueKey, StringLength(Constants.DefaultStringLength)]
        public string UserName { get; set; }

        [Required, StringLength(Constants.DefaultStringLength)]
        public string Password { get; set; }

        [StringLength(Constants.DefaultStringLength)]
        public string UserRoles { get; set; }

        protected ApplicationUser(ApplicationUserDto applicationUser, string userRoles)
        {
            Name = applicationUser.Name;
            Password = applicationUser.Password;
            Email = applicationUser.Email;
            UserName = applicationUser.UserName;
            UserRoles = userRoles;
        }

        protected ApplicationUser()
        {

        }
        public ApplicationUserDto ToDto()
        {
            return new ApplicationUserDto
            { Email = Email, Name = Name, Password = "".PadRight(Password.Length, '*'), UserName = UserName };
        }
    }
}