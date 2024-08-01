using static System.Net.Mime.MediaTypeNames;

namespace GessiWebApp.API.Models
{
    public class Material
    {
        public int Id { get; set; }
        public string MaterialCode { get; set; }
        public string Description { get; set; }
        public string Notes { get; set; }
        public List<Classification> Classifications { get; set; }
        public List<Image> Images { get; set; }
        public DateTime CreationDate { get; set; }
    }
}