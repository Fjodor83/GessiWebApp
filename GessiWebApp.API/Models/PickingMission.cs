namespace GessiWebApp.API.Models
{
    public class PickingMission
    {
        public int Id { get; set; }
        public string MissionCode { get; set; }
        public string DestinationType { get; set; }
        public string Description { get; set; }
        public string Status { get; set; } // Attiva/Sospesa/Completata
        public List<Material> Materials { get; set; }
        public int UserId { get; internal set; }
    }
}