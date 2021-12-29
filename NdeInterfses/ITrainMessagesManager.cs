using System;

namespace NdeInterfases
{
  public interface ITrainMessagesManager
  {
    void UpdateActualMessages();
    void AssignForeignMessages();
    void UpdateMessagesHistory();
  }
}