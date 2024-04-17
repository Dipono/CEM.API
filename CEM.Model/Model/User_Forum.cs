using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEM.Model.Model
{
    public class User_Forum
    {
        User_Forum()
        {
            Comment = string.Empty;
        }
        [Key]
        public int Id { get; set; }
        public string Comment { get; set; }
        public DateTime? CreatedAt { get; set; }
        [ForeignKey("User")]      
        public int UserId { get; set; }

        [ForeignKey("Forum")]
        public int ForumId { get; set; }
        
    }
}
