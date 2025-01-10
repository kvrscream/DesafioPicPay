using Microsoft.EntityFrameworkCore;
using estudoRepository.Models;

namespace estudoRepository.Context
{
  public class ApplicationDbContext : DbContext
  {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    // Dbsets heere
    public DbSet<User> Users { get; set; }

    public DbSet<AccountModel> Accounts { get; set; }
  }
}