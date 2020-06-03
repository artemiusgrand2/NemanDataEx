using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NdeInterfases;

namespace LocalNdeTest
{
  class FakeTrainMessagesManager:ITrainMessagesManager
  {
    public void UpdateActualMessages()
    {
      Console.WriteLine("Актуальные справки - Тест");
    }
    public  void AssignForeignMessages(){}

    public void UpdateMessagesHistory()
    {
      Console.WriteLine("История справок - Тест");
    }
  }
}
