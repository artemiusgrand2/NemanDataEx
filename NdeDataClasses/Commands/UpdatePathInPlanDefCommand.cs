using System;
using System.Runtime.Serialization;

namespace NdeDataClasses.Commands
{
    [DataContract]
    public class UpdatePathInPlanDefCommand : BindingCommand
    {
        [DataMember]
        public int DefIdn { get; set; }

        [DataMember]
        public string TrainNumber { get; set; }
        [DataMember]
        public int PlanEvId { get; set; }
        [DataMember]
        public string Station { get; set; }
        [DataMember]
        public string Axis { get; set; }
        [DataMember]
        public string NDO { get; set; }

    }
}