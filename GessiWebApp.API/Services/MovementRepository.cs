using GessiWebApp.API.Data;
using GessiWebApp.API.Models;
using GessiWebApp.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GessiWebApp.API.Services
{
    public class MovementRepository : IMovementRepository
    {
        private readonly ApplicationDbContext _context;

        public MovementRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Movement> GetByIdAsync(int id)
        {
            return await _context.Movements.FindAsync(id);
        }

        public async Task<IEnumerable<Movement>> GetByMaterialIdAsync(int materialId)
        {
            return await _context.Movements.Where(m => m.MaterialId == materialId).ToListAsync();
        }

        public async Task<IEnumerable<Movement>> GetByWarehouseIdAsync(int warehouseId)
        {
            return await _context.Movements.Where(m => m.WarehouseId == warehouseId).ToListAsync();
        }

        public async Task<IEnumerable<Movement>> GetByDateRangeAsync(DateTime start, DateTime end)
        {
            return await _context.Movements.Where(m => m.Date >= start && m.Date <= end).ToListAsync();
        }

        public async Task AddAsync(Movement movement)
        {
            await _context.Movements.AddAsync(movement);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Movement movement)
        {
            _context.Movements.Update(movement);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var movement = await GetByIdAsync(id);
            if (movement != null)
            {
                _context.Movements.Remove(movement);
                await _context.SaveChangesAsync();
            }
        }
    }
}
