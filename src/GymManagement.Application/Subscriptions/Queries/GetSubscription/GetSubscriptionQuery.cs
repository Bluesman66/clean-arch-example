namespace GymManagement.Application.Subscriptions.Queries.GetSubscription;

using ErrorOr;

using MediatR;

public record GetSubscriptionQuery(Guid SubscriptionId) : IRequest<ErrorOr<Subscription>>;
