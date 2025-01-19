namespace GymManagement.Application.Gyms.Queries.ListGyms;

using ErrorOr;

using MediatR;

public record ListGymsQuery(Guid SubscriptionId) : IRequest<ErrorOr<List<Gym>>>;