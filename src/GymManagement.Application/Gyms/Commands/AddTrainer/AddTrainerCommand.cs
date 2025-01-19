namespace GymManagement.Application.Gyms.Commands.AddTrainer;

using ErrorOr;

using MediatR;

public record AddTrainerCommand(Guid SubscriptionId, Guid GymId, Guid TrainerId) : IRequest<ErrorOr<Success>>;