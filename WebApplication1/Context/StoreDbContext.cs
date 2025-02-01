using Microsoft.EntityFrameworkCore;
using WebApplication1.Entities;

namespace WebApplication1.Context
{
	public class StoreDbContext : DbContext
	{
		public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options) { 
			
		}
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
