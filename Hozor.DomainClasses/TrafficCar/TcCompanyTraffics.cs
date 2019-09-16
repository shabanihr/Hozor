using System;
using System.Collections.Generic;

namespace Hozor.DataLayer.Models
{
    public partial class TcCompanyTraffics
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int EmployeeId { get; set; }
        public int TrafficCarId { get; set; }
        public int WorkFlowId { get; set; }
        public DateTime? ExitDate { get; set; }
        public TimeSpan? ArrivalTime { get; set; }
        public DateTime? ArrivalDate { get; set; }
        public TimeSpan? ExitTime { get; set; }
        public string ArrivalDoor { get; set; }
        public string ExitDoor { get; set; }
        public string ArrivalUserName { get; set; }
        public string ExitUserName { get; set; }
        public int? ArrivalKilometer { get; set; }
        public int? ExitKilometer { get; set; }
        public double? FunctionKilometer { get; set; }
        public string Destination { get; set; }
        public string Description { get; set; }

        public TcCompanys Company { get; set; }
        public CEmployees Employee { get; set; }
        public TcTrafficCars TrafficCar { get; set; }
        public CWorkFlows WorkFlow { get; set; }
    }
}
