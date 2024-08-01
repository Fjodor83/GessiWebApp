using GessiWebApp.API.Data;
using GessiWebApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace GessiWebApp.API.Services
{
    public class MovementService
    {
        private readonly ApplicationDbContext _context;

        public MovementService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Movement> GetMovements()
        {
            return _context.Movements
                .Include(m => m.Material)
                .Include(m => m.Warehouse)
                .ToList();
        }

        public Movement GetMovementById(int id)
        {
            return _context.Movements
                .Include(m => m.Material)
                .Include(m => m.Warehouse)
                .FirstOrDefault(m => m.Id == id);
        }

        public void CreateMovement(Movement movement)
        {
            _context.Movements.Add(movement);
            _context.SaveChanges();
        }

        public void UpdateMovement(Movement movement)
        {
            _context.Movements.Update(movement);
            _context.SaveChanges();
        }

        public void DeleteMovement(int id)
        {
            var movement = _context.Movements.Find(id);
            if (movement != null)
            {
                _context.Movements.Remove(movement);
                _context.SaveChanges();
            }
        }
    }
}