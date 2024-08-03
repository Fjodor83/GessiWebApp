using GessiWebApp.API.Models;

namespace GessiWebApp.API.Services.Interfaces
{
    public interface IMovementRepository
    {
        Task<Movement> GetByIdAsync(int id);
        Task<IEnumerable<Movement>> GetByMaterialIdAsync(int materialId);
        Task<IEnumerable<Movement>> GetByWarehouseIdAsync(int warehouseId);
        Task<IEnumerable<Movement>> GetByDateRangeAsync(DateTime start, DateTime end);
        Task AddAsync(Movement movement);
        Task UpdateAsync(Movement movement);
        Task DeleteAsync(int id);
    }
}
