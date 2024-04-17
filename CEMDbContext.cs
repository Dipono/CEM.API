using System;

public class CEMDbContext : DbContext
{
	public CEMDbContext(DbContextOptions<CEMDbContext> options): base(options)
	{
	}

	public DbSet<User> Users { get; set; }
	public DbSet<Complain> Complains { get; set; }
	public DbSet<User_Complain> User_Complains { get; set; }
}
