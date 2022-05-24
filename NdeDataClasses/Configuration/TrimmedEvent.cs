using NdeDataClasses.Enums;

namespace NdeDataClasses.Configuration
{
    public class TrimmedEvent
    {
        public string StationCode { get; private set; }
        public TypeEvent TypeEvent { get; private set; }
        public string Ndo { get; private set; }

        public TrimmedEvent(string stationCode, TypeEvent typeEvent, string ndo)
        {
            StationCode = (stationCode.IndexOf("TE") != -1) ? stationCode : $"TE{stationCode}";
            TypeEvent = typeEvent;
            Ndo = ndo;
        }
    }
}
