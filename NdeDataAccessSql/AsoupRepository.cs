using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using NdeDataClasses;
using NdeInterfases;

namespace NdeDataAccessSql
{
  public class AsoupRepository : IAsoupRepository
  {
    private readonly string _connectionString;
    //
    private const string Command1 = "SELECT RecId, MessageTime, RawMessageRecId, StationCode,"
      + " TrainNumber, Index1, Index2, Index3, Index4,"
      + " LocoCrewStartTimeHour,LocoCrewStartTimeMinute,MachinistName,"
      + " ConvWagonCount,NetWeight,GrossWeight,WagonCounts,LastUpdateTime,"
      + " LocoSeries,LocoNumber,WagonCounts"
      + " FROM TrainRecords"
      + " WHERE TrainNumber = @trainNumber AND MessageTime > @sttTime AND MessageTime < @stopTime"
      + " ORDER BY MessageTime DESC";
    //
    private const string Command2 = "SELECT RecId, MessageTime, RawMessageRecId, StationCode,"
      + " TrainNumber, Index1, Index2, Index3, Index4,"
      + " LocoCrewStartTimeHour,LocoCrewStartTimeMinute,MachinistName,"
      + " ConvWagonCount,NetWeight,GrossWeight,WagonCounts,LastUpdateTime,"
      + " LocoSeries,LocoNumber,WagonCounts"
      + " FROM TrainRecords"
      + " WHERE LastUpdateTime > @sttTime AND LastUpdateTime < @stopTime"
      + " ORDER BY MessageTime";
    private const string Command3 = "SELECT"
+ " [RecId]"
+ ",[LocoSeries]"
+ ",[OversizeBottom]"
+ ",[OversizeSide]"
+ ",[OversizeTop]"
+ ",[SuperOversize]"
+ ",[LengthConv]"
+ ",[HeavyAndLongMark]"
+ ",[OperationCode]"
+ ",[OperationTime]"
+ ",[StationCode]"
+ ",[VidSled]"
+ " FROM [Iaspurgp].[dbo].[Messages5676]"
+ " WHERE TrainNumber = @trainNumber"
+ " ORDER BY [OperationTime] DESC";

    //
    private readonly SqlCommand _command1;
    private readonly SqlCommand _command2;
    //
    private readonly SqlParameter _parTrainNumber1;
    private readonly SqlParameter _parSttTime1;
    private readonly SqlParameter _parStopTime1;
    private readonly SqlParameter _parSttTime2;
    private readonly SqlParameter _parStopTime2;

    //Конструктор
    public AsoupRepository(string connectionString) 
    {
      _connectionString = connectionString;
      //
      _command1 = new SqlCommand(Command1);
      _command2 = new SqlCommand(Command2);
      //
      _parTrainNumber1 = new SqlParameter("@trainNumber", SqlDbType.SmallInt);
      _parSttTime1     = new SqlParameter("@sttTime"    , SqlDbType.DateTime);
      _parStopTime1    = new SqlParameter("@stopTime"   , SqlDbType.DateTime);
      _parSttTime2     = new SqlParameter("@sttTime"    , SqlDbType.DateTime);
      _parStopTime2    = new SqlParameter("@stopTime"   , SqlDbType.DateTime);
      //
      _command1.Parameters.Add(_parTrainNumber1);
      _command1.Parameters.Add(_parSttTime1);
      _command1.Parameters.Add(_parStopTime1);
      _command2.Parameters.Add(_parSttTime2);
      _command2.Parameters.Add(_parStopTime2);
    }

      //
      public IList<TrainMessage> RetrieveTrainMessagesByTrainNumber(int trainNumber
                                                                 , DateTime sttTime, DateTime stpTime) {
      IList<TrainMessage> trainMessages = new List<TrainMessage>();
      using (var connection = new SqlConnection(_connectionString)){
        connection.Open();
        using (var transaction = connection.BeginTransaction())
        {
          AssignConnectionAndTransactionToCommand(_command1, connection, transaction);
          _parTrainNumber1.Value = trainNumber;
          _parSttTime1.Value     = sttTime;
          _parStopTime1.Value    = stpTime;
          using (var dataReader = _command1.ExecuteReader())
          {
            while (dataReader.Read())
            {
              TrainMessage trainMessage = RetrieveTrainMessageFromReader(dataReader);
              trainMessages.Add(trainMessage);
            }
          }
        }
      }
      return trainMessages;
    }
    //
    public IList<TrainMessage> RetrieveTrainMessages(DateTime sttTime,DateTime stopTime) {
      IList<TrainMessage> trainMessages = new List<TrainMessage>();
      using (var connection = new SqlConnection(_connectionString)) {
        connection.Open();
        using (var transaction = connection.BeginTransaction()) {
          AssignConnectionAndTransactionToCommand(_command2, connection, transaction);
          _parSttTime2.Value  = sttTime;
          _parStopTime2.Value = stopTime;
          using (var dataReader = _command2.ExecuteReader()) {
            while (dataReader.Read())
            {
              TrainMessage trainMessage = RetrieveTrainMessageFromReader(dataReader);
              trainMessages.Add(trainMessage);
            }
          }
        }
      }
      return trainMessages;
    }
    //
    private TrainMessage RetrieveTrainMessageFromReader(IDataReader dataReader){
      var trainMessage = new TrainMessage {
        RecId           = dataReader.GetInt32(0),
        MessageTime     = dataReader.GetDateTime(1),
        RawMessageRecId = dataReader.GetInt32Safely(2),
        StationCode     = dataReader.GetStringSafely(3),
        TrainNumber     = dataReader.GetInt16(4),
        TrainIndex = new TrainIndex {
          Index1 = dataReader.GetStringSafely(5),
          Index2 = dataReader.GetStringSafely(6),
          Index3 = dataReader.GetStringSafely(7),
          Index4 = dataReader.GetStringSafely(8)
        },
        CrewStTimeH = dataReader.GetByteSafely(9),
        CrewStTimeM = dataReader.GetByteSafely(10),
        Machinist   = dataReader.GetStringSafely(11),
        CWagCount   = dataReader.GetByteSafely(12),
        NtWeight    = dataReader.GetInt16Safely(13),
        GrWeight    = dataReader.GetInt16Safely(14),
                                           //15 !!!
        LastUpTime  = dataReader.GetDateTime(16),
        LocoSeries  = dataReader.GetStringSafely(17),
        LocoNumber  = dataReader.GetStringSafely(18),
        //WagCounts   = null
        WagCounts = new byte[3],
        Operation = "",
        Flags = ""
      };
      trainMessage.StationCode = PrepStCod(trainMessage.StationCode);
      if (!dataReader.IsDBNull(19)){
        //byte[] _wagCounts = new byte[3];
        //dataReader.GetBytes(19, 0, _wagCounts, 0, 3);
        dataReader.GetBytes(19, 0, trainMessage.WagCounts, 0, 3);
        //trainMessage.WagCounts = _wagCounts;
      }
      return trainMessage;
    }
    //
    private string PrepStCod(string stCod)
    {
      string nCod = stCod.Trim();
      int ch1, ch2, ch3, ch4, ch5, sum, ost;
      switch(nCod.Length){
        case  4 : nCod += "0";
                  break;
        case  5 : //break;
                  nCod = nCod.Substring(0, 4) + "0";// + nCod.Substring(4, 1);
                  break;
        case  6 : return nCod;
        default : return "";
      }
      Int32.TryParse(nCod.Substring(0, 1), out ch1);
      Int32.TryParse(nCod.Substring(1, 1), out ch2);
      Int32.TryParse(nCod.Substring(2, 1), out ch3);
      Int32.TryParse(nCod.Substring(3, 1), out ch4);
      Int32.TryParse(nCod.Substring(4, 1), out ch5);
      sum = (ch1 * 1) + (ch2 * 2) + (ch3 * 3) + (ch4 * 4) + (ch5 * 5);
      ost = sum%11;
      if(ost == 10){
        sum = (ch1 * 3) + (ch2 * 4) + (ch3 * 5) + (ch4 * 6) + (ch5 * 7);
        ost = sum%11;
        if(ost == 10){ost = 0;}
      }
      nCod += ost.ToString(CultureInfo.InvariantCulture);
      return nCod;
    }
    //
    private static void AssignConnectionAndTransactionToCommand(SqlCommand command,
      SqlConnection connection,
      SqlTransaction transaction) {
      command.Connection = connection;
      command.Transaction = transaction;
    }
  }
}
