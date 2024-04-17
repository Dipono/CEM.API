using System.ComponentModel.DataAnnotations;

namespace CEM.Model.Model
{
    public class User
    {
        public User()
        {
            Name = string.Empty;
            Surname = string.Empty;
            Email = string.Empty;
            PhoneNo = string.Empty;
            Password = string.Empty;
            Role = string.Empty;
        }
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}