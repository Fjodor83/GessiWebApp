using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GessiWebApp.API.Models
{
    public class Movement
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Material")]
        public int MaterialId { get; set; }

        public Material Material { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [MaxLength(500)]
        public string Notes { get; set; }

        [Required]
        public MovementType Type { get; set; }
    }

    public enum MovementType
    {
        Incoming,
        Outgoing
    }
}
