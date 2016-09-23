using System;

namespace FamilyHelper.API.Models.DTO
{
    public class UserRegisterDTO
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirthday { get; set; }
    }
}
