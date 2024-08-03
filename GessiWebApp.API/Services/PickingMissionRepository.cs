using GessiWebApp.API.Data;
using GessiWebApp.API.Models;
using GessiWebApp.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GessiWebApp.API.Services
{
    public class PickingMissionRepository : IPickingMissionRepository
    {
        private readonly ApplicationDbContext _context;

        public PickingMissionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PickingMission> GetByIdAsync(int id)
        {
            return await _context.PickingMissions.FindAsync(id);
        }

        public async Task<IEnumerable<PickingMission>> GetByUserIdAsync(int userId)
        {
            return await _context.PickingMissions.Where(pm => pm.UserId == userId).ToListAsync();
        }

        public async Task<IEnumerable<PickingMission>> GetActiveAsync()
        {
            return await _context.PickingMissions.Where(pm => pm.Status != "Closed").ToListAsync();
        }

        public async Task AddAsync(PickingMission mission)
        {
            await _context.PickingMissions.AddAsync(mission);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(PickingMission mission)
        {
            _context.PickingMissions.Update(mission);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var mission = await GetByIdAsync(id);
            if (mission != null)
            {
                _context.PickingMissions.Remove(mission);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<PickingMission> GetActiveByUserIdAsync(int userId)
        {
            return await _context.PickingMissions
                .FirstOrDefaultAsync(pm => pm.UserId == userId && pm.Status == "Active");
        }
    }
}
