namespace GymManagement.Api.Endpoints;

using System.Threading.Tasks;

using MediatR;

public static class SubscriptionsEndpoints
{
    public static void MapSubscriptionsEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("").WithOpenApi();

        group.MapPost("/subscriptions", CretateSubscription).WithName(nameof(GetSubscription));
        group.MapGet("/subscriptions/{subscriptionId}", GetSubscription);
        group.MapDelete("/subscriptions/{subscriptionId}", DeleteSubscription);
    }

    private static async Task<IResult> CretateSubscription(CreateSubsciptopnRequest request, ISender mediator)
    {
        if (!DomainSubscriptionType.TryFromName(
            request.SubscriptionType.ToString(),
            out var subscriptionType))
        {
            return Results.Problem(
                statusCode: StatusCodes.Status400BadRequest,
                detail: "Invalid subscription type");
        }

        var command = new CreateSubscriptionCommand(
            subscriptionType,
            request.AdminId);

        var createSubscriptionResult = await mediator.Send(command);

        return createSubscriptionResult.Match(
            subscription => Results.Ok(
                new SubscriptionResponce(
                    subscription.Id,
                    ToDto(subscription.SubscriptionType))),
            _ => Results.Problem());
    }

    private static async Task<IResult> GetSubscription(Guid subscriptionId, ISender mediator)
    {
        var query = new GetSubscriptionQuery(subscriptionId);

        var getSubscriptionResult = await mediator.Send(query);

        return getSubscriptionResult.MatchFirst(
            subscription => Results.Ok(new SubscriptionResponce(
                subscription.Id,
                ToDto(subscription.SubscriptionType))),
            _ => Results.Problem());
    }

    public static async Task<IResult> DeleteSubscription(Guid subscriptionId, ISender mediator)
    {
        var command = new DeleteSubscriptionCommand(subscriptionId);

        var deleteSubscriptionResult = await mediator.Send(command);

        return deleteSubscriptionResult.Match(
            _ => Results.NoContent(),
            _ => Results.Problem());
    }

    private static SubscriptionType ToDto(DomainSubscriptionType subscriptionType)
    {
        return subscriptionType.Name switch
        {
            nameof(DomainSubscriptionType.Free) => SubscriptionType.Free,
            nameof(DomainSubscriptionType.Starter) => SubscriptionType.Starter,
            nameof(DomainSubscriptionType.Pro) => SubscriptionType.Pro,
            _ => throw new InvalidOperationException(),
        };
    }
}