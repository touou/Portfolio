using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Portfolio.Entitys;

namespace Portfolio.DataContext;

public class ApplicationContext : IdentityDbContext<User>
{
    public DbSet<Request> Requests { get; set; }

    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
        
    }
}