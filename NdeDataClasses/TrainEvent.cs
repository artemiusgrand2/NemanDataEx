using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace NdeDataClasses
{
    [DataContract]
    //Событие поезда
    public class TrainEvent
    {
        [DataMember]
        public int TrainIdn { get; set; }
        [DataMember]
        public string TrainNumber { get; set; }
        [DataMember]
        public string TrainNumberPrefix { get; set; }
        [DataMember]
        public string TrainNumberSuffix { get; set; }
        [DataMember]
        public string TrainAttr { get; set; }
        [DataMember]
        public string EventStation { get; set; }
        [DataMember]
        public int EventType { get; set; }
        [DataMember]
        public string EventAxis { get; set; }
        [DataMember]
        public int DObjType { get; set; }
        [DataMember]
        public string DObjName { get; set; }
        [DataMember]
        public string NeibStation { get; set; }
        [DataMember]
        public int MessIdn { get; set; }
        [DataMember]
        public int DestType { get; set; }
        [DataMember]
        public DateTime EventTime { get; set; }
        [DataMember]
        public DateTime RoTime { get; set; }
        [DataMember]
        public DateTime BzTime { get; set; }
        [DataMember]
        public string DestStation { get; set; }
        [DataMember]
        public int CrewStTimeH { get; set; }
        [DataMember]
        public int CrewStTimeM { get; set; }
        [DataMember]
        public string Machinist { get; set; }
        [DataMember]
        public int CWagCount { get; set; }
        [DataMember]
        public int NtWeight { get; set; }
        [DataMember]
        public int GrWeight { get; set; }
        [DataMember]
        public string Marker { get; set; }
        [DataMember]
        public string BadCode { get; set; }
        [DataMember]
        public int IdWrPrior { get; set; }
        [DataMember]
        public int IdWrNext { get; set; }
        [DataMember]
        public int NormIdn { get; set; }
        [DataMember]
        public IList<PlanEvent> PlanEvents { get; set; } = new List<PlanEvent>();
    }
}
