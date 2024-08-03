using GessiWebApp.API.Models;

namespace GessiWebApp.API.Services.Interfaces
{
    public interface IPickingMissionRepository
    {
        Task<PickingMission> GetByIdAsync(int id);
        Task<IEnumerable<PickingMission>> GetByUserIdAsync(int userId);
        Task<IEnumerable<PickingMission>> GetActiveAsync();
        Task AddAsync(PickingMission mission);
        Task UpdateAsync(PickingMission mission);
        Task DeleteAsync(int id);
        Task<PickingMission> GetActiveByUserIdAsync(int userId);
    }
}
