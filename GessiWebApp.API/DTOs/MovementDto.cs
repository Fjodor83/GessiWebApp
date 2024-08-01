using GessiWebApp.API.Models;

namespace GessiWebApp.API.DTOs
{
    public class MovementDto
    {
        public int Id { get; set; }
        public int MaterialId { get; set; }
        public Material Material { get; set; }
        public int WarehouseId { get; set; }
        public Warehouse Warehouse { get; set; }
        public string MovementType { get; set; } // Ingresso/Uscita
        public int Quantity { get; set; }
        public DateTime Date { get; set; }
        public string Notes { get; set; }
    }
}