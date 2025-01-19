namespace GymManagement.Application.Subscriptions.Commands.DeleteSubscription;

using ErrorOr;

using MediatR;

public record DeleteSubscriptionCommand(Guid SubscriptionId) : IRequest<ErrorOr<Deleted>>;