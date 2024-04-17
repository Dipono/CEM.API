using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEM.Model.Model
{
    public class User_Complain
    {
        public User_Complain()
        {
            Respond = string.Empty;
        }
        [Key]
        public int Id { get; set; }
        public string Respond { get; set; }
        public DateTime DateCreated { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        [ForeignKey("Complain")]
        public int ComplainId { get; set; }
    }
}
