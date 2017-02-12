using System;
using System.ComponentModel.DataAnnotations;

namespace Stilwill.Web.Areas.Auto.Models
{
    public class Vehicle
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Make { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public string Year { get; set; }
        [Required]
        public DateTime PurchaseDate { get; set; }
    }
}
