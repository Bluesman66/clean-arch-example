namespace GymManagement.Api.Endpoints;

using System.Threading.Tasks;

using MediatR;

public static class RoomsEndpoints
{
    public static void MapRoomsEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/gyms/{gymId}/rooms").WithOpenApi();

        group.MapPost("", CreateRoom);
        group.MapDelete("/{roomId}", DeleteRoom);
    }

    private static async Task<IResult> CreateRoom(CreateRoomRequest request, Guid gymId, ISender mediator)
    {
        var command = new CreateRoomCommand(
            gymId,
            request.Name);

        var createRoomResult = await mediator.Send(command);

        return createRoomResult.Match(
            room => Results.Ok(new RoomResponse(room.Id, room.Name)),
            _ => Results.Problem());
    }

    private static async Task<IResult> DeleteRoom(Guid gymId, Guid roomId, ISender mediator)
    {
        var command = new DeleteRoomCommand(gymId, roomId);

        var deleteRoomResult = await mediator.Send(command);

        return deleteRoomResult.Match(
            _ => Results.NoContent(),
            _ => Results.Problem());
    }
}