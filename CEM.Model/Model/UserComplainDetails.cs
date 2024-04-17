using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEM.Model.Model
{
    public class UserComplainDetails
    {
        public UserComplainDetails() {
            Name = string.Empty;
            Surname = string.Empty;
            PhoneNo = string.Empty;
            Subject = string.Empty;
            Location = string.Empty;
            SubjectDescription = string.Empty;
        }
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ComplainId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNo { get; set; }
        public string Subject { get; set; }
        public string SubjectDescription { get; set; }
        public string Location { get; set; }
        public DateTime DateCreated { get; set; }
        public Boolean Satisfied { get; set; }
        public Boolean Closed { get; set; }

    }
}
