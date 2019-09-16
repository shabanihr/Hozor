using System;
using System.Collections.Generic;

namespace Hozor.DataLayer.Models
{
    public partial class TcComrades
    {
        public int Id { get; set; }
        public int TrafficCarId { get; set; }
        public int EmployeeId { get; set; }
        public string ComradeName { get; set; }
        public string ComradeFamily { get; set; }
        public string ComradeSection { get; set; }

        public TcTrafficCars TrafficCar { get; set; }
    }
}
