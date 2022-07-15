using System;
using System.Runtime.Serialization;

namespace NdeDataClasses.Commands
{
    public class SetServiceFlagCommand : BindingCommand
    {
        [DataMember]
        public int defIdn { get; set; }
        [DataMember]
        public int serviceFlag { get; set; }
    }
}

