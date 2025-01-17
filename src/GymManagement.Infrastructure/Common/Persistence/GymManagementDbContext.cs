namespace GymManagement.Infrastructure.Common.Persistence;

using Microsoft.EntityFrameworkCore;

public class GymManagementDbContext : DbContext
{
    public DbSet<Subscription> Subscriptions { get; set; } = null!;

    public GymManagementDbContext(DbContextOptions options) : base(options)
    {
    }
}