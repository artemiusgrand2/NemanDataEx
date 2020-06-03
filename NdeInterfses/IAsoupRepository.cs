using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NdeDataClasses;

namespace NdeInterfases
{
  public interface IAsoupRepository
  {
    IList<TrainMessage> RetrieveTrainMessagesByTrainNumber(int trainNumber,DateTime sttTime,DateTime stpTime);
    IList<TrainMessage> RetrieveTrainMessages(DateTime sttTime,DateTime stopTime);
  }
}
