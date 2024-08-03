using GessiWebApp.API.Models;

namespace GessiWebApp.API.Services.Interfaces
{
    public interface IWarehouseRepository
    {
        Task<Warehouse> GetByIdAsync(int id);
        Task<Warehouse> GetByCodeAsync(string code);
        Task<IEnumerable<Warehouse>> GetAllAsync();
        Task AddAsync(Warehouse warehouse);
        Task UpdateAsync(Warehouse warehouse);
        Task DeleteAsync(int id);
    }
}
