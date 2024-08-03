using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GessiWebApp.API.Models
{
    public class Warehouse
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(200)]
        public string Location { get; set; }

        public ICollection<Material> Materials { get; set; }
    }
}
