using System;
using System.Collections.Generic;

namespace Hozor.DataLayer.Models
{
    public partial class TcCargoTransportTraffics
    {
        public int Id { get; set; }
        public int CargoTransportId { get; set; }
        public int TrafficCarId { get; set; }
        public int WorkFlowId { get; set; }
        public DateTime? ArrivalDate { get; set; }
        public TimeSpan? ArrivalTime { get; set; }
        public DateTime? ExitDate { get; set; }
        public TimeSpan? ExitTime { get; set; }
        public string ArrivalDoor { get; set; }
        public string ExitDoor { get; set; }
        public string ArrivalUserName { get; set; }
        public string ExitUserName { get; set; }
        public string CargoName { get; set; }
        public string Company { get; set; }
        public string Description { get; set; }

        public TcCargoTransports CargoTransport { get; set; }
        public TcTrafficCars TrafficCar { get; set; }
        public CWorkFlows WorkFlow { get; set; }
    }
}
