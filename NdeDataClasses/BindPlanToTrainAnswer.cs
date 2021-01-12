using System;

namespace NdeDataClasses
{
    public class BindPlanToTrainAnswer : BaseCommandAnswer
    {
        public int PlanIdn { get; set; }
        public int TrainIdn { get; set; }
    }
}
