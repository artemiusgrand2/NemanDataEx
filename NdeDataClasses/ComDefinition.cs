using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace NdeDataClasses
{
    [DataContract]
    public class ComDefinition
    {
        [DataMember]
        public int ComType { get; set; }
        [DataMember]
        public int DefIdn { get; set; }
        [DataMember]
        public string StatCode { get; set; }
        [DataMember]
        public string TrainNum { get; set; }
        [DataMember]
        public int ObSttType { get; set; }
        [DataMember]
        public string ObSttName { get; set; }
        [DataMember]
        public int ObStpType { get; set; }
        [DataMember]
        public string ObStpName { get; set; }
        [DataMember]
        public DateTime ComStartTime { get; set; }
        [DataMember]
        public DateTime CollStartTime { get; set; }
        //Id Плановой нитки
        [DataMember]
        public int PlnIdn { get; set; }
        //Продолжите
        [DataMember]
        public int Stop { get; set; }
        [DataMember]
        /// <summary>
        /// Id события в плановой нитке
        /// </summary>
        public int PlnEvIdn { get; set; }
        public int StdForm { get; set; }
        [DataMember]
        public int FlSnd { get; set; }

        public ComDefAppendix Appendix { get; set; }
    }
}
