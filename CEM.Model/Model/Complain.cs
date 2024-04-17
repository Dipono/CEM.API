using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEM.Model.Model
{
    public class Complain
    {
        public Complain()
        {
            ComplainDescription = string.Empty;
            Subject = string.Empty;
            Location = string.Empty;
        }
        [Key]
        public int Id { get; set; }
        public string Subject { get; set; }
        public string ComplainDescription { get; set; }
        public string Location { get; set; }    
        public Boolean Satisfied { get; set; }
        public Boolean Closed { get; set; }
        public DateTime Date { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
    }
}
