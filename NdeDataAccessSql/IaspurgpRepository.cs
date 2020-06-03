using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using NdeDataClasses;
using NdeInterfases;

namespace NdeDataAccessSql
{
  public class IaspurgpRepository : IiaspurgpRepository //: IAsoupRepository
  {
    private readonly string _connectionString;
    /*
    private const string Command1 = "SELECT RecId, MessageTime, RawMessageRecId, StationCode,"
      + " TrainNumber, Index1, Index2, Index3, Index4,"
      + " LocoCrewStartTimeHour,LocoCrewStartTimeMinute,MachinistName,"
      + " ConvWagonCount,NetWeight,GrossWeight,WagonCounts,LastUpdateTime,"
      + " LocoSeries,LocoNumber,WagonCounts"
      + " FROM TrainRecords"
      + " WHERE TrainNumber = @trainNumber AND MessageTime > @sttTime AND MessageTime < @stopTime"
      + " ORDER BY MessageTime DESC";
    */
    private const string Command1 = "SELECT"
      + " [RecId]"
      + ",[TrainId]"
      + ",[TrainNumber]"
      + ",[StationCode]"
      + ",[OperationCode]"
      + ",[OperationTime]"
      + ",[Track]"
      + ",[LocoSeries]"
      + ",[LocoNumber]"
      + ",[RailwayCode]"
      + ",[DepotCode]"
      + ",[Flags]"
      + ",[CrewRailway]"
      + ",[CrewDepot]"
      + ",[MachinistId]"
      + ",[MachinistName]"
      + ",[StartTime]"
      + ",[FlagsC]"
      + ",[TimeToTO]"
      + ",[LengthConv]"
      + ",[WagLaden]"
      + ",[WagEmpty]"
      + ",[WagNoWork]"
      + ",[WeightGross]"
      + ",[WeightNet]"
      + ",[VidSled]"
      + ",[WagFull]"
      + ",[DirectionFromStation]"
      + ",[DirectionToStation]"
      + ",[RollingUnits]"
      + ",[Index1]"
      + ",[Index2]"
      + ",[Index3]"
      + ",[ReceivingTime]"
      + " FROM [Iaspurgp].[dbo].[Messages5676]"
      + " WHERE TrainNumber = @trainNumber AND OperationTime > @sttTime AND OperationTime < @stopTime"
      + " ORDER BY [OperationTime] DESC";
    /*
    private const string Command2 = "SELECT RecId, MessageTime, RawMessageRecId, StationCode,"
      + " TrainNumber, Index1, Index2, Index3, Index4,"
      + " LocoCrewStartTimeHour,LocoCrewStartTimeMinute,MachinistName,"
      + " ConvWagonCount,NetWeight,GrossWeight,WagonCounts,LastUpdateTime,"
      + " LocoSeries,LocoNumber,WagonCounts"
      + " FROM TrainRecords"
      + " WHERE LastUpdateTime > @sttTime AND LastUpdateTime < @stopTime"
      + " ORDER BY MessageTime";
    */
    private const string Command2 = "SELECT"
      + " [RecId]"
      + ",[TrainId]"
      + ",[TrainNumber]"
      + ",[StationCode]"
      + ",[OperationCode]"
      + ",[OperationTime]"
      + ",[Track]"
      + ",[LocoSeries]"
      + ",[LocoNumber]"
      + ",[RailwayCode]"
      + ",[DepotCode]"
      + ",[Flags]"
      + ",[CrewRailway]"
      + ",[CrewDepot]"
      + ",[MachinistId]"
      + ",[MachinistName]"
      + ",[StartTime]"
      + ",[FlagsC]"
      + ",[TimeToTO]"
      + ",[LengthConv]"
      + ",[WagLaden]"
      + ",[WagEmpty]"
      + ",[WagNoWork]"
      + ",[WeightGross]"
      + ",[WeightNet]"
      + ",[VidSled]"
      + ",[WagFull]"
      + ",[DirectionFromStation]"
      + ",[DirectionToStation]"
      + ",[RollingUnits]"
      + ",[Index1]"
      + ",[Index2]"
      + ",[Index3]"
      + ",[ReceivingTime]"
      + " FROM [Iaspurgp].[dbo].[Messages5676]"
      + " WHERE ReceivingTime > @sttTime AND ReceivingTime < @stopTime"
      + " ORDER BY [OperationTime]";
    //
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
  + " FROM [Iaspurgp].[dbo].[Messages5676]"
  + " WHERE TrainNumber = @trainNumber"
  + " ORDER BY [OperationTime] DESC";


    private readonly SqlCommand _command1;
    private readonly SqlCommand _command2;
    private readonly SqlCommand _command3;
    //
    private readonly SqlParameter _parTrainNumber1;
    private readonly SqlParameter _parSttTime1;
    private readonly SqlParameter _parStopTime1;
    private readonly SqlParameter _parSttTime2;
    private readonly SqlParameter _parStopTime2;
    private readonly SqlParameter _parTrainNumber3;
    //
    public IaspurgpRepository(string connectionString) {
      _connectionString = connectionString;
      //
      _command1 = new SqlCommand(Command1);
      _command2 = new SqlCommand(Command2);
      _command3 = new SqlCommand(Command3);
      //
      _parTrainNumber1 = new SqlParameter("@trainNumber", SqlDbType.Char);
      _parSttTime1 = new SqlParameter("@sttTime", SqlDbType.DateTime);
      _parStopTime1 = new SqlParameter("@stopTime", SqlDbType.DateTime);
      _parSttTime2 = new SqlParameter("@sttTime", SqlDbType.DateTime);
      _parStopTime2 = new SqlParameter("@stopTime", SqlDbType.DateTime);
      _parTrainNumber3 = new SqlParameter("@trainNumber", SqlDbType.Char);
      //
      _command1.Parameters.Add(_parTrainNumber1);
      _command1.Parameters.Add(_parSttTime1);
      _command1.Parameters.Add(_parStopTime1);
      _command2.Parameters.Add(_parSttTime2);
      _command2.Parameters.Add(_parStopTime2);
      _command3.Parameters.Add(_parTrainNumber3);
    }


    public void AssignAppendexes(IList<ComDefinition> commands) {
      using (var con = new SqlConnection(_connectionString)) {
        con.Open();
        _command3.Connection = con;

        foreach (var command in commands) {
          _parTrainNumber3.Value = command.TrainNum;

          using (var dataReader = _command1.ExecuteReader()) {
            if (dataReader.Read()) {
              command.Appendix = new ComDefAppendix {
                LocoSeries = dataReader.GetStringSafely(1),
                OversizeBottom = dataReader.GetStringSafely(2),
                OversizeSide = dataReader.GetStringSafely(3),
                OversizeTop = dataReader.GetStringSafely(4),
                SuperOversize = dataReader.GetStringSafely(5),
                LengthConv = dataReader.GetInt32Safely(6),
                HeavyAndLongMark = dataReader.GetStringSafely(7),
                OperationCode = dataReader.GetStringSafely(8),
                OperationTime = dataReader.GetDateTime(9),
                StationCode = dataReader.GetStringSafely(10),
                VidSled = dataReader.GetStringSafely(11)
              };
            }
          }
        }
      }
    }



    //
    public IList<TrainMessage> RetrieveTrainMessagesByTrainNumber(int trainNumber, DateTime sttTime, DateTime stpTime) {
      IList<TrainMessage> trainMessages = new List<TrainMessage>();
      using (var connection = new SqlConnection(_connectionString)) {
        connection.Open();
        using (var transaction = connection.BeginTransaction()) {
          AssignConnectionAndTransactionToCommand(_command1, connection, transaction);
          _parTrainNumber1.Value = trainNumber.ToString();
          _parSttTime1.Value = sttTime;
          _parStopTime1.Value = stpTime;
          using (var dataReader = _command1.ExecuteReader()) {
            while (dataReader.Read()) {
              TrainMessage trainMessage = RetrieveTrainMessageFromReader(dataReader);
              trainMessages.Add(trainMessage);
            }
          }
        }
      }
      return trainMessages;
    }
    //
    public IList<TrainMessage> RetrieveTrainMessages(DateTime sttTime, DateTime stopTime) {
      //throw new NotImplementedException();
      IList<TrainMessage> trainMessages = new List<TrainMessage>();
      using (var connection = new SqlConnection(_connectionString)) {
        connection.Open();
        using (var transaction = connection.BeginTransaction()) {
          AssignConnectionAndTransactionToCommand(_command2, connection, transaction);
          _parSttTime2.Value = sttTime;
          _parStopTime2.Value = stopTime;
          using (var dataReader = _command2.ExecuteReader()) {
            while (dataReader.Read()) {
              TrainMessage trainMessage = RetrieveTrainMessageFromReader(dataReader);
              trainMessages.Add(trainMessage);
            }
          }
        }
      }
      return trainMessages;
    }
    /*
      0 [RecId]"
      1 [TrainId]"
      2 [TrainNumber]"
      3 [StationCode]"
      4 [OperationCode]"
      5 [OperationTime]"
      6 [Track]"
      7 [LocoSeries]"
      8 [LocoNumber]"
      9 [RailwayCode]"
      10[DepotCode]"
      11[Flags]"
      12[CrewRailway]"
      13[CrewDepot]"
      14[MachinistId]"
      15[MachinistName]"
      16[StartTime]"
      17[FlagsC]"
      18[TimeToTO]"
      19[LengthConv]"
      20[WagLaden]"
      21[WagEmpty]"
      22[WagNoWork]"
      23[WeightGross]"
      24[WeightNet]"
      25[VidSled]"
      26[WagFull]"
      27[DirectionFromStation]"
      28[DirectionToStation]"
      29[RollingUnits]"
      30[Index1]"
      31[Index2]"
      32[Index3]"
      33 ReceivingTime
     */
    //


    private static TrainMessage RetrieveTrainMessageFromReader(IDataReader dataReader) {
      var trainMessage = new TrainMessage {
        RecId = dataReader.GetInt32(0),
        MessageTime = dataReader.GetDateTime(5),
        RawMessageRecId = dataReader.GetInt32(0),//???
        StationCode = dataReader.GetStringSafely(3),
        TrainNumber = int.Parse(dataReader.GetString(2)),
        TrainIndex = new TrainIndex {
          Index1 = dataReader.GetStringSafely(30),
          Index2 = dataReader.GetStringSafely(31),
          Index3 = dataReader.GetStringSafely(32),
          Index4 = ""
        },
        CrewStTimeH = 0,
        CrewStTimeM = 0,
        Machinist = dataReader.GetStringSafely(15),
        CWagCount = dataReader.GetInt32Safely(19),
        NtWeight = dataReader.GetInt32Safely(24),
        GrWeight = dataReader.GetInt32Safely(23),
        LastUpTime = dataReader.GetDateTime(33),//???
        LocoSeries = dataReader.GetStringSafely(7),
        LocoNumber = dataReader.GetStringSafely(8),
        WagCounts = new byte[3],
        Operation = dataReader.GetStringSafely(4),
        Flags = dataReader.GetStringSafely(11)
      };
      /*
      trainMessage.RecId = dataReader.GetInt32(0);
      trainMessage.MessageTime = dataReader.GetDateTime(5);
      trainMessage.RawMessageRecId = -1;
      trainMessage.StationCode = dataReader.GetStringSafely(3);
      trainMessage.TrainNumber = int.Parse(dataReader.GetString(2));
      trainMessage.TrainIndex = new TrainIndex {};
      trainMessage.TrainIndex.Index1 = dataReader.GetStringSafely(30);
      trainMessage.TrainIndex.Index2 = dataReader.GetStringSafely(31);
      trainMessage.TrainIndex.Index3 = dataReader.GetStringSafely(32);
      trainMessage.TrainIndex.Index4 = "";
      trainMessage.CrewStTimeH = 0;
      trainMessage.CrewStTimeM = 0;
      trainMessage.Machinist = dataReader.GetStringSafely(15);
      trainMessage.CWagCount = dataReader.GetInt32Safely(19);
      trainMessage.NtWeight = dataReader.GetInt32Safely(24);
      trainMessage.GrWeight = dataReader.GetInt32Safely(23);
      trainMessage.LastUpTime = DateTime.MinValue;!!!
      trainMessage.LocoSeries = dataReader.GetStringSafely(7);
      trainMessage.LocoNumber = dataReader.GetStringSafely(8);
      trainMessage.WagCounts = new byte[3];
      */
      return trainMessage;
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
