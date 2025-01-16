namespace GymManagement.Api.Endpoints;

public static class SubscriptionEndpoints
{
    public static void MapSubscriptionEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("").WithOpenApi();

        group.MapPost("/Subscriptions", CretateSubscription);
    }

    private static IResult CretateSubscription(CreateSubsciptopnRequest request, ISubsrciptionService service)
    {
        var subscriptionId = service.CretateSubscsrciption(request.SubscriptionType.ToString(), request.AdminId);

        var response = new SubscriptionResponce(subscriptionId, request.SubscriptionType);

        return Results.Ok(response);
    }
}