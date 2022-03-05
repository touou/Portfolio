using Microsoft.EntityFrameworkCore;
using Portfolio.Entitys;

namespace Portfolio.DataContext;

public class ApplicationContext : DbContext
{
    public DbSet<Request> Requests { get; set; }

    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
        
    }
}