namespace GymManagement.Application.Gyms.Queries.GetGym;

using ErrorOr;

using MediatR;

public record GetGymQuery(Guid SubscriptionId, Guid GymId) : IRequest<ErrorOr<Gym>>;