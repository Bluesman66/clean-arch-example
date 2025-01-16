namespace GymManagement.Application.Services;

public interface ISubsrciptionService
{
    Guid CretateSubscsrciption(string subscriptionType, Guid adminId);
}
