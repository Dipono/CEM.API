using CEM.Model.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEM.Model
{
    public class CEMDbContext: DbContext
    {
        public CEMDbContext(DbContextOptions<CEMDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Complain> Complains { get; set; }
        public DbSet<User_Complain> User_Complains { get; set; }
        public DbSet<Forum> Forums { get; set; }
        public DbSet<User_Forum> User_Forums { get; set; }

    }
}
