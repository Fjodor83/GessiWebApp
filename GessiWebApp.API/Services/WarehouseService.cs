using GessiWebApp.API.Data;
using GessiWebApp.API.Models;

namespace GessiWebApp.API.Services
{
    public class WarehouseService
    {
        private readonly ApplicationDbContext _context;

        public WarehouseService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Warehouse> GetWarehouses()
        {
            return _context.Warehouses.ToList();
        }

        public Warehouse GetWarehouseById(int id)
        {
            return _context.Warehouses.Find(id);
        }

        public void CreateWarehouse(Warehouse warehouse)
        {
            _context.Warehouses.Add(warehouse);
            _context.SaveChanges();
        }

        public void UpdateWarehouse(Warehouse warehouse)
        {
            _context.Warehouses.Update(warehouse);
            _context.SaveChanges();
        }

        public void DeleteWarehouse(int id)
        {
            var warehouse = _context.Warehouses.Find(id);
            if (warehouse != null)
            {
                _context.Warehouses.Remove(warehouse);
                _context.SaveChanges();
            }
        }
    }
}