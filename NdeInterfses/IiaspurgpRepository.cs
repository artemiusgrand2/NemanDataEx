using System.Collections.Generic;
using NdeDataClasses;

namespace NdeInterfases {
  public interface IiaspurgpRepository {
    void AssignAppendexes(IList<ComDefinition> commands);
  }
}
