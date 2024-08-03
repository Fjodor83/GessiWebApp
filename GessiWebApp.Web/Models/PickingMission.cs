using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GessiWebApp.API.Models
{
    public class PickingMission
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string MissionCode { get; set; }

        [Required]
        [ForeignKey("Warehouse")]
        public int WarehouseId { get; set; }

        public Warehouse Warehouse { get; set; }

        [Required]
        [ForeignKey("Material")]
        public int MaterialId { get; set; }

        public Material Material { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public DateTime PlannedDate { get; set; }

        public DateTime? ActualDate { get; set; }

        [MaxLength(500)]
        public string Notes { get; set; }
    }
}
