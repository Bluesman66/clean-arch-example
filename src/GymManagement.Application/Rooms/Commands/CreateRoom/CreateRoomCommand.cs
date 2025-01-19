namespace GymManagement.Application.Rooms.Commands.CreateRoom;

using ErrorOr;

using MediatR;

public record CreateRoomCommand(
    Guid GymId,
    string RoomName) : IRequest<ErrorOr<Room>>;