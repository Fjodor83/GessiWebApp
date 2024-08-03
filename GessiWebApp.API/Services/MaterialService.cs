using GessiWebApp.API.Data;
using GessiWebApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace GessiWebApp.API.Services
{
    public class MaterialService : IMaterialService
    {
        private readonly ApplicationDbContext _context;

        public MaterialService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Material> GetMaterials()
        {
            return _context.Materials
                .Include(m => m.Classifications)
                .Include(m => m.Images)
                .ToList();
        }

        public Material GetMaterialById(int id)
        {
            return _context.Materials
                .Include(m => m.Classifications)
                .Include(m => m.Images)
                .FirstOrDefault(m => m.Id == id);
        }

        public void CreateMaterial(Material material)
        {
            _context.Materials.Add(material);
            _context.SaveChanges();
        }

        public void UpdateMaterial(Material material)
        {
            _context.Materials.Update(material);
            _context.SaveChanges();
        }

        public void DeleteMaterial(int id)
        {
            var material = _context.Materials.Find(id);
            if (material != null)
            {
                _context.Materials.Remove(material);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Material> GetAllMaterials()
        {
            throw new NotImplementedException();
        }

        public void AddMaterial(Material material)
        {
            throw new NotImplementedException();
        }
    }
}