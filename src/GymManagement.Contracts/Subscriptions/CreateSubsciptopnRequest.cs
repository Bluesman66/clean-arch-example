namespace GymManagement.Contracts.Subscription;

public record CreateSubsciptopnRequest(
    SubscriptionType SubscriptionType,
    Guid AdminId);

