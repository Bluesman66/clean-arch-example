namespace GymManagement.Api.Endpoints;

using System.Threading.Tasks;
using ErrorOr;
using MediatR;

public static class SubscriptionEndpoints
{
    public static void MapSubscriptionEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("").WithOpenApi();

        group.MapPost("/Subscriptions", CretateSubscription);
    }

    private static async Task<IResult> CretateSubscription(CreateSubsciptopnRequest request, ISender sender)
    {
        var command = new CreateSubscriptionCommand(
            request.SubscriptionType.ToString(),
            request.AdminId);

        var createSubscriptionResult = await sender.Send(command);

        return createSubscriptionResult.MatchFirst(
            guid => Results.Ok(new SubscriptionResponce(guid, request.SubscriptionType)),
            error => Results.Problem()
        );
    }
}