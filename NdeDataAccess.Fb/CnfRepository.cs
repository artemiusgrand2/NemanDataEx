using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FirebirdSql.Data.FirebirdClient;
using NdeInterfases;

namespace NdeDataAccessFb
{
  public class CnfRepository : ICnfRepository
  {
    //
    private readonly string _connectionString;

    private readonly FbCommand _command1;

    private readonly FbParameter _parStationCode1;
    //
    private const string CommandText1 = "SELECT TNEIBSTATIONS.STATION"
    + " FROM TNEIBSTATIONS"
    + " WHERE  TNEIBSTATIONS.GRPNUM"
    + " IN (SELECT TNEIBSTATIONS.GRPNUM FROM TNEIBSTATIONS where TNEIBSTATIONS.STATION = @StCode)";
    //
    public CnfRepository(string connectionString){
      _connectionString = connectionString;
      //
      _command1 = new FbCommand(CommandText1);
      //
      _parStationCode1 = new FbParameter("@StCode", FbDbType.VarChar);
      //Добавляем параметры в команду(ы)
      _command1.Parameters.Add(_parStationCode1);
    }
    //
    public IList<string> GetStationGroup(string stationCode){
      IList<string> returnedList = new List<string>();
      using (var connection = new FbConnection(_connectionString)){
        connection.Open();
        using (var transaction = connection.BeginTransaction()){
          AssignConnectionAndTransactionToCommand(_command1,connection,transaction);
          _parStationCode1.Value = stationCode;
          using (var dbReader1 = _command1.ExecuteReader()){
            while (dbReader1.Read()){
              string stCode = dbReader1.GetString(0);
              returnedList.Add(stCode);
            }
            if(returnedList.Count == 0){
              returnedList.Add(stationCode);
            }
          }
        }
        connection.Close();
      }
      return returnedList;
    }
    //
    private static void AssignConnectionAndTransactionToCommand(FbCommand command
                                                               ,FbConnection connection,FbTransaction transaction){
      command.Connection = connection;
      command.Transaction = transaction;
    }
  }
}
