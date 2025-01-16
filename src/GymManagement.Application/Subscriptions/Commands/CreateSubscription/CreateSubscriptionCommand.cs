namespace GymManagement.Application.Subscriptions.Commands.CreateSubscription;

using MediatR;

public record CreateSubscriptionCommand(string SubscriptionType, Guid AdminId) : IRequest<Guid>;