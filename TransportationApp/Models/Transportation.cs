using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCBlank.Models
{
    public class Transportation : ITransportation
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string TransportType { get; set; }
        [Required]
        public string TransportMode { get; set; }
        [Required]
        public string PowerSource { get; set; }
        [Required]
        public List<Capacity> Capacities { get; set; }

        public void Load(Capacity cargo)
        {
            this.Capacities.Add(cargo);
        }
        public void Transport()
        {
            Console.WriteLine("Moved from point A to point B.");
        }
        public void Unload()
        {
            this.Capacities = new List<Capacity>();
        }
    }
}