namespace GymManagement.Application.Gyms.Commands.CreateGym;

using ErrorOr;

using MediatR;

public record CreateGymCommand(string Name, Guid SubscriptionId) : IRequest<ErrorOr<Gym>>;