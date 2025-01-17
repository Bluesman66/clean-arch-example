namespace GymManagement.Application.Subscriptions.Queries.GetSubscription;

using ErrorOr;

using MediatR;

public class GetSubscriptionQueryHandler : IRequestHandler<GetSubscriptionQuery, ErrorOr<Subscription>>
{
    private readonly ISubscriptionsRepository _subscriptionsRepository;

    public GetSubscriptionQueryHandler(ISubscriptionsRepository subscriptionsRepository)
    {
        _subscriptionsRepository = subscriptionsRepository;
    }

    public async Task<ErrorOr<Subscription>> Handle(GetSubscriptionQuery request, CancellationToken cancellationToken)
    {
        var subscription = await _subscriptionsRepository.GetByIdAsync(request.SubscriptionId);

        return subscription is null
            ? Error.NotFound("Subscription not found")
            : subscription;
    }
}