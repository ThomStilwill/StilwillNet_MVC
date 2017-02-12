using System.ComponentModel.DataAnnotations;

namespace Stilwill.Web.Areas.Auto.Models
{
    public class Service
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int IntervalMiles { get; set; }
        public int IntervalMonths { get; set; }
//
//        public int VehicleId { get; set; }
//        public Vehicle Vehicle { get; set; }
    }
}