using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace NdeDataClasses
{
    [DataContract]
    //Событие плановой нитки
    public class PlanEvent
    {
        //[DataMember]
        //public int TrainIdn { get; set; }
        [DataMember]
        public int EvIdn { get; set; }
        [DataMember]
        public DateTime EventTimeP { get; set; }
        [DataMember]
        public string EventStation { get; set; }
        [DataMember]
        public int EventType { get; set; }
        [DataMember]
        public string Axis { get; set; }
        [DataMember]
        public string Ndo { get; set; }
        [DataMember]
        public int AckEventFlag { get; set; }
    }
}
