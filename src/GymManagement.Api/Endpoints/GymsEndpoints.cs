namespace GymManagement.Api.Endpoints;

using MediatR;

public static class GymsEndpoints
{
    public static void MapGymsEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/subscriptions/{subscriptionId}/gyms").WithOpenApi();

        group.MapPost("", CreateGym).WithName(nameof(GetGym));
        group.MapGet("", ListGyms);
        group.MapGet("/{gymId}", GetGym);
        group.MapDelete("/{gymId}", DeleteGym);
        group.MapPost("/{gymId}/trainers", AddTrainer);
    }

    public static async Task<IResult> CreateGym(CreateGymRequest request, Guid subscriptionId, ISender mediator)
    {
        var command = new CreateGymCommand(request.Name, subscriptionId);

        var createGymResult = await mediator.Send(command);

        return createGymResult.Match(
            gym => Results.Ok(new GymResponse(gym.Id, gym.Name)),
            _ => Results.Problem());
    }

    public static async Task<IResult> ListGyms(Guid subscriptionId, ISender mediator)
    {
        var command = new ListGymsQuery(subscriptionId);

        var listGymsResult = await mediator.Send(command);

        return listGymsResult.Match(
            gyms => Results.Ok(gyms.ConvertAll(gym => new GymResponse(gym.Id, gym.Name))),
            _ => Results.Problem());
    }

    public static async Task<IResult> GetGym(Guid subscriptionId, Guid gymId, ISender mediator)
    {
        var command = new GetGymQuery(subscriptionId, gymId);

        var getGymResult = await mediator.Send(command);

        return getGymResult.Match(
            gym => Results.Ok(new GymResponse(gym.Id, gym.Name)),
            _ => Results.Problem());
    }

    public static async Task<IResult> DeleteGym(Guid subscriptionId, Guid gymId, ISender mediator)
    {
        var command = new DeleteGymCommand(subscriptionId, gymId);

        var deleteGymResult = await mediator.Send(command);

        return deleteGymResult.Match(
            _ => Results.NoContent(),
            _ => Results.Problem());
    }

    public static async Task<IResult> AddTrainer(AddTrainerRequest request, Guid subscriptionId, Guid gymId, ISender mediator)
    {
        var command = new AddTrainerCommand(subscriptionId, gymId, request.TrainerId);

        var addTrainerResult = await mediator.Send(command);

        return addTrainerResult.Match(
            _ => Results.Ok(),
            _ => Results.Problem());
    }
}