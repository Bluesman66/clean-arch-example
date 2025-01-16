
namespace GymManagement.Application.Services;

public class SubsrciptionService : ISubsrciptionService
{
    public Guid CretateSubscsrciption(string subscriptionType, Guid adminId)
    {
        return Guid.NewGuid();
    }
}
