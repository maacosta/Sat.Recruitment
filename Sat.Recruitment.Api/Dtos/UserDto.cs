using Sat.Recruitment.Api.Controllers;
using Sat.Recruitment.Api.Enums;
using System.ComponentModel.DataAnnotations;

namespace Sat.Recruitment.Api.Dtos
{
    public class UserDto
    {
        [Required(ErrorMessage = "The name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The email is required")]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "The address is required")]
        public string Address { get; set; }
        
        [Required(ErrorMessage = "The phone is required")]
        [Phone]
        public string Phone { get; set; }

        [EnumDataType(typeof(UserTypeEnum))]
        public string UserType { get; set; }

        public decimal Money { get; set; }
    }
}
