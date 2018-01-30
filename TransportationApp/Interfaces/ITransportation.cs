using System.Collections.Generic;

namespace MVCBlank.Models
{
    public interface ITransportation
    {
        List<Capacity> Capacities { get; set; }
        string Name { get; set; }
        string PowerSource { get; set; }
        string TransportMode { get; set; }
        string TransportType { get; set; }

        void Load(Capacity cargo);
        void Transport();
        void Unload();
    }
}