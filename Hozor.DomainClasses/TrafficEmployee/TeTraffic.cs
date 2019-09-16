using System;
using System.Collections.Generic;

namespace Hozor.DataLayer.Models
{
    public partial class TeTraffic
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string Date { get; set; }
        public int WorkFlowId { get; set; }
        public int CarId { get; set; }
        public string ArrivalTime1 { get; set; }
        public string ExitTime1 { get; set; }
        public string ArrivalTime2 { get; set; }
        public string ExitTime2 { get; set; }
        public string ArrivalTime3 { get; set; }
        public string ExitTime3 { get; set; }
        public string ArrivalTime4 { get; set; }
        public string ExitTime4 { get; set; }
        public string ArrivalDoor1 { get; set; }
        public string ArrivalDoor2 { get; set; }
        public string ArrivalDoor3 { get; set; }
        public string ArrivalDoor4 { get; set; }
        public string ExitDoor1 { get; set; }
        public string ExitDoor2 { get; set; }
        public string ExitDoor3 { get; set; }
        public string ExitDoor4 { get; set; }
        public string ArrivalUser1 { get; set; }
        public string ArrivalUser2 { get; set; }
        public string ArrivalUser3 { get; set; }
        public string ArrivalUser4 { get; set; }
        public string ExitUser1 { get; set; }
        public string ExitUser2 { get; set; }
        public string ExitUser3 { get; set; }
        public string ExitUser4 { get; set; }
        public string ArrivalFinal { get; set; }
        public string ExitFinal { get; set; }
        public bool? Presence { get; set; }
        public string ExitReoprt1 { get; set; }
        public string ExitReoprt2 { get; set; }
        public string ExitReoprt3 { get; set; }
        public string ArrivalTraffic1 { get; set; }
        public string ArrivalTraffic2 { get; set; }
        public string ArrivalTraffic3 { get; set; }
        public string ArrivalTraffic4 { get; set; }
        public string ExitTraffic1 { get; set; }
        public string ExitTraffic2 { get; set; }
        public string ExitTraffic3 { get; set; }
        public string ExitTraffic4 { get; set; }
        public string ArrivalTrafficFinal { get; set; }
        public string ExitTrafficFinal { get; set; }

        public TeCar Car { get; set; }
        public TeDate DateNavigation { get; set; }
        public CEmployees Employee { get; set; }
    }
}
