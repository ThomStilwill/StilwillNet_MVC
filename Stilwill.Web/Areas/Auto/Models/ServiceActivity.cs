using System;
using System.ComponentModel.DataAnnotations;

namespace Stilwill.Web.Areas.Auto.Models
{
    public class ServiceActivity
    {
        [Key]
        public int Id { get; set; }

        public string Description { get; set; }
        public DateTime DateOfService { get; set; }
        public int OdometerMiles { get; set; }

        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }

        public int ServiceId { get; set; }
        public Service Service { get; set; }
    }
}