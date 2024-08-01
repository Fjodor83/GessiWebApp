namespace GessiWebApp.API.DTOs
{
    public class MaterialDto
    {
        public int Id { get; set; }
        public string MaterialCode { get; set; }
        public string Description { get; set; }
        public string Notes { get; set; }
        public List<string> Classifications { get; set; }
        public List<string> Images { get; set; }
        public DateTime CreationDate { get; set; }
    }
}