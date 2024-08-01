using GessiWebApp.API.Models;

namespace GessiWebApp.API.DTOs
{
    public class PickingMissionDto
    {
        public int Id { get; set; }
        public string MissionCode { get; set; }
        public string DestinationType { get; set; }
        public string Description { get; set; }
        public string Status { get; set; } // Attiva/Sospesa/Completata
        public List<Material> Materials { get; set; }
    }
}