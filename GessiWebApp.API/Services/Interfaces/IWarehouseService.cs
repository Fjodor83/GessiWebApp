using GessiWebApp.API.Models;
namespace GessiWebApp.API.Services
{
    public interface IWarehouseService
    {
        IEnumerable<Warehouse> GetAllWarehouses();
        Warehouse GetWarehouseById(int id);
        void AddWarehouse(Warehouse warehouse);
        void UpdateWarehouse(Warehouse warehouse);
        void DeleteWarehouse(int id);
    }
}
