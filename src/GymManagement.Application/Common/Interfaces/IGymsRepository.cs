namespace GymManagement.Application.Common.Interfaces;

using GymManagement.Domain.Gyms;

public interface IGymsRepository
{
    Task AddGymAsync(Gym gym);
    Task<Gym?> GetByIdAsync(Guid id);
    Task<bool> ExistsAsync(Guid id);
    Task<List<Gym>> ListBySubscriptionIdAsync(Guid subscriptionId);
    Task UpdateGymAsync(Gym gym);
    Task RemoveGymAsync(Gym gym);
    Task RemoveRangeAsync(List<Gym> gyms);
}