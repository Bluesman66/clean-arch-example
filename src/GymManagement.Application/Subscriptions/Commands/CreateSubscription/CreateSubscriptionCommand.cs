namespace GymManagement.Application.Subscriptions.Commands.CreateSubscription;

using ErrorOr;

using MediatR;

public record CreateSubscriptionCommand(string SubscriptionType, Guid AdminId) : IRequest<ErrorOr<Guid>>;