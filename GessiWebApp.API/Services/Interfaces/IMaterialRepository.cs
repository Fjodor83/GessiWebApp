using GessiWebApp.API.Models;

namespace GessiWebApp.API.Services.Interfaces
{
    public interface IMaterialRepository
    {
        Task<Material> GetByIdAsync(int id);
        Task<Material> GetByCodeAsync(string code);
        Task<IEnumerable<Material>> GetAllAsync();
        Task AddAsync(Material material);
        Task UpdateAsync(Material material);
        Task DeleteAsync(int id);
        Task<IEnumerable<Material>> GetByClassificationAsync(string classificationCode);
    }
}
