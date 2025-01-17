
namespace GymManagement.Infrastructure.Subscriptions.Persistence;

public class SubscriptionRepository : ISubscriptionsRepository
{
    private readonly static List<Subscription> _subscriptions = new();

    public Task AddSubscriptionAsync(Subscription subscription)
    {
        _subscriptions.Add(subscription);

        return Task.CompletedTask;
    }

    public Task<Subscription?> GetByIdAsync(Guid subscriptionId)
    {
        var subscription = _subscriptions.FirstOrDefault(s => s.Id == subscriptionId);

        return Task.FromResult(subscription);
    }
}