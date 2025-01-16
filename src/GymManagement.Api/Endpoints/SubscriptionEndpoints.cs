namespace GymManagement.Api.Endpoints;

using System.Threading.Tasks;

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
        var command = new CreateSubscriptionCommand(request.SubscriptionType.ToString(), request.AdminId);

        var subscriptionId = await sender.Send(command);

        var response = new SubscriptionResponce(subscriptionId, request.SubscriptionType);

        return Results.Ok(response);
    }
}