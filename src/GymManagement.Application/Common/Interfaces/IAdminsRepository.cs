namespace GymManagement.Application.Common.Interfaces;

using GymManagement.Domain.Admins;

public interface IAdminsRepository
{
    Task<Admin?> GetByIdAsync(Guid adminId);
    Task UpdateAsync(Admin admin);
}