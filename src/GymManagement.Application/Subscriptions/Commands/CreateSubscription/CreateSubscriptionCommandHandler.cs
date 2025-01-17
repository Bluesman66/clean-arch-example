namespace GymManagement.Application.Subscriptions.Commands.CreateSubscription;

using ErrorOr;

using MediatR;

public class CreateSubscriptionCommandHandler : IRequestHandler<CreateSubscriptionCommand, ErrorOr<Subscription>>
{
    private readonly ISubscriptionsRepository _subscriptionsRepository;
    // private readonly IUnitOfWork _unitOfWork;

    public CreateSubscriptionCommandHandler(ISubscriptionsRepository subscriptionsRepository
    // , IUnitOfWork unitOfWork
    )
    {
        _subscriptionsRepository = subscriptionsRepository;
        // _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<Subscription>> Handle(CreateSubscriptionCommand request, CancellationToken cancellationToken)
    {
        // Create a subscription
        var subscription = new Subscription
        {
            Id = Guid.NewGuid(),
            SubscriptionType = request.SubscriptionType
        };

        // Add it to the database
        await _subscriptionsRepository.AddSubscriptionAsync(subscription);
        // await _unitOfWork.CommitChangesAsync();

        // Return subscription
        return subscription;
    }
}