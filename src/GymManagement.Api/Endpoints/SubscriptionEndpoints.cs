namespace GymManagement.Api.Endpoints;

using System.Threading.Tasks;

using MediatR;

public static class SubscriptionEndpoints
{
    public static void MapSubscriptionEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("").WithOpenApi();

        group.MapPost("/Subscriptions", CretateSubscription);
        group.MapGet("/Subscriptions/{subscriptionId}", GetSubscription);
    }

    private static async Task<IResult> CretateSubscription(CreateSubsciptopnRequest request, ISender sender)
    {
        if (!DomainSubscriptionType.TryFromName(request.SubscriptionType.ToString(), out var subscriptionType))
        {
            return Results.Problem(
                statusCode: StatusCodes.Status400BadRequest,
                detail: "Invalid subscription type");
        }

        var command = new CreateSubscriptionCommand(
            subscriptionType,
            request.AdminId);

        var createSubscriptionResult = await sender.Send(command);

        return createSubscriptionResult.MatchFirst(
            subscription => Results.Ok(new SubscriptionResponce(
                subscription.Id,
                request.SubscriptionType)),
            error => Results.Problem(error.Description));
    }

    private static async Task<IResult> GetSubscription(Guid subscriptionId, ISender sender)
    {
        var query = new GetSubscriptionQuery(subscriptionId);

        var getSubscriptionResult = await sender.Send(query);

        return getSubscriptionResult.MatchFirst(
            subscription => Results.Ok(new SubscriptionResponce(
                subscription.Id,
                Enum.Parse<SubscriptionType>(subscription.SubscriptionType.Name))),
            error => Results.Problem(error.Description));
    }
}