namespace GymManagement.Application.Subscriptions.Commands.CreateSubscription;

using ErrorOr;

using MediatR;

public record CreateSubscriptionCommand(SubscriptionType SubscriptionType, Guid AdminId) : IRequest<ErrorOr<Subscription>>;