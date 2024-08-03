using GessiWebApp.API.Models;

namespace GessiWebApp.API.Services
{
    public interface IMaterialService
    {
        IEnumerable<Material> GetAllMaterials();
        Material GetMaterialById(int id);
        void AddMaterial(Material material);
        void UpdateMaterial(Material material);
        void DeleteMaterial(int id);
    }
}

