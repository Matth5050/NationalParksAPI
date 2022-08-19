using System;
using System.ComponentModel.DataAnnotations;

namespace NationalPark.Models
{
    public class Park
    {
        public int ParkId { get; set; }
        public int RegionId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string State { get; set; }
    }
}