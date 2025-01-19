namespace GymManagement.Application.Gyms.Commands.DeleteGym;

using ErrorOr;

using MediatR;

public record DeleteGymCommand(Guid SubscriptionId, Guid GymId) : IRequest<ErrorOr<Deleted>>;