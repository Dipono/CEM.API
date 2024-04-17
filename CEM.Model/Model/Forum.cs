using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEM.Model.Model
{
    public class Forum
    {
        Forum() { 
            Topic = string.Empty;
            TopicDescription = string.Empty;
        }
        [Key]
        public int Id { get; set; }
        public string Topic { get; set; }
        public string TopicDescription { get; set; }
        public DateTime DateCreated { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
    }
}
