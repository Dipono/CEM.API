using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEM.Model.Model
{
    public class UsersForum
    {
        public UsersForum() { 
            Name = string.Empty;
            Surname = string.Empty;
            Topic = string.Empty;
            TopicDescription = string.Empty;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int UserId { get; set; }
        public int ForumId { get; set; }
        public string Topic { get; set; }
        public string TopicDescription { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
