using Microsoft.EntityFrameworkCore;
using TestApi.Domain;

namespace TestApi.DAL;

public class MyDbContext : DbContext
{
    public DbSet<TaskEntity> Tasks { get; set; } = null!;

    public DbSet<User> Users { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(@"Host=localhost;Port=5432;Database=TestApi;Username=postgres;Password=CjyzCjyz1");
    }
}