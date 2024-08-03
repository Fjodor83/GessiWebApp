using GessiWebApp.API.Data;
using GessiWebApp.API.Models;
using GessiWebApp.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GessiWebApp.API.Services
{
    public class MaterialRepository : IMaterialRepository
    {
        private readonly ApplicationDbContext _context;

        public MaterialRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Material> GetByIdAsync(int id)
        {
            return await _context.Materials.FindAsync(id);
        }

        public async Task<Material> GetByCodeAsync(string code)
        {
            return await _context.Materials.FirstOrDefaultAsync(m => m.MaterialCode == code);
        }

        public async Task<IEnumerable<Material>> GetAllAsync()
        {
            return await _context.Materials.ToListAsync();
        }

        public async Task AddAsync(Material material)
        {
            await _context.Materials.AddAsync(material);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Material material)
        {
            _context.Materials.Update(material);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var material = await GetByIdAsync(id);
            if (material != null)
            {
                _context.Materials.Remove(material);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Material>> GetByClassificationAsync(string classificationCode)
        {
            return await _context.Materials
                .Where(m => m.Classifications.Any(c => c.ClassificationCode == classificationCode))
                .ToListAsync();
        }
    }

}
