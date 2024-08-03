using GessiWebApp.API.Data;
using GessiWebApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace GessiWebApp.API.Services
{
    public class PickingMissionService : IPickingMissionService
    {
        private readonly ApplicationDbContext _context;

        public PickingMissionService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<PickingMission> GetPickingMissions()
        {
            return _context.PickingMissions
                .Include(pm => pm.Materials)
                .ToList();
        }

        public PickingMission GetPickingMissionById(int id)
        {
            return _context.PickingMissions
                .Include(pm => pm.Materials)
                .FirstOrDefault(pm => pm.Id == id);
        }

        public void CreatePickingMission(PickingMission pickingMission)
        {
            _context.PickingMissions.Add(pickingMission);
            _context.SaveChanges();
        }

        public void UpdatePickingMission(PickingMission pickingMission)
        {
            _context.PickingMissions.Update(pickingMission);
            _context.SaveChanges();
        }

        public void DeletePickingMission(int id)
        {
            var pickingMission = _context.PickingMissions.Find(id);
            if (pickingMission != null)
            {
                _context.PickingMissions.Remove(pickingMission);
                _context.SaveChanges();
            }
        }

        public IEnumerable<PickingMission> GetAllPickingMissions()
        {
            throw new NotImplementedException();
        }

        public void AddPickingMission(PickingMission pickingMission)
        {
            throw new NotImplementedException();
        }
    }
}