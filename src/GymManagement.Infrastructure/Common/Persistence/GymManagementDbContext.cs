namespace GymManagement.Infrastructure.Common.Persistence;

using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

public class GymManagementDbContext : DbContext, IUnitOfWork
{
    public GymManagementDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Subscription> Subscriptions { get; set; } = null!;

    public async Task CommitChangesAsync()
    {
        await base.SaveChangesAsync();
    }
}