using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using NdeDataAccessFb;
using NdeDataAccessSql;
using NdeDataClasses;
using BCh.Ktc.Nde.MiddleTier;
using NdeDataClasses.Configuration;

namespace LocalNdeTest
{
  class Program
  {
    private static void Main(string[] args)
    {
      //DateTime startTime,stopTime;
      //TimeSpan wrTime;
      string _connectionStringCnf;
      string _connectionStringGid;
      string _connectionStringMes;
      string _connectionStringBuh;

      BuhSection[] _buhSections;

      bool flPlay;
      try {
        flPlay = bool.Parse(ConfigurationManager.AppSettings["GidPlay"]);
      } catch (Exception e) {
        var err = e.ToString();
        flPlay = false;
      }

      int deltaTimeStart = int.Parse(ConfigurationManager.AppSettings["deltaTimeStart"]);
      int deltaTimeStop  = int.Parse(ConfigurationManager.AppSettings["deltaTimeStop"]);

      _connectionStringCnf = ConfigurationManager.ConnectionStrings["cnfDb"].ConnectionString;
      _connectionStringGid = ConfigurationManager.ConnectionStrings["gidDb"].ConnectionString;
      _connectionStringMes = ConfigurationManager.ConnectionStrings["mesDb"].ConnectionString;
      _connectionStringBuh = ConfigurationManager.ConnectionStrings["buhDb"].ConnectionString;

      _buhSections = NdeConfigurationHelper.RetrieveBuhSectionsFromConfiguration("engine");

      var ndeDataCnf = new CnfRepository(_connectionStringCnf);
      var ndeDataGid = new GidRepository(_connectionStringGid,flPlay
                                        , deltaTimeStart, deltaTimeStop
                                        , _connectionStringBuh
                                        , _buhSections, null);
      var ndeDataMes = new AsoupRepository(_connectionStringMes);
      //var ndeDataMes = new IaspurgpRepository(_connectionStringMes);
      
      //Console.WriteLine("Последние события по поездам");
      //startTime = DateTime.Now;
      //IList<TrainEvent> trainEvents = ndeDataGid.GetLastTrainEvents();
      //var ias = ndeDataGid.GetRequests();
      var trainMessagesManager = new TrainMessagesManager(ndeDataCnf, ndeDataGid, ndeDataMes);
      //trainMessagesManager.UpdateActualMessages();
      trainMessagesManager.UpdateMessagesHistory();
      /*
      stopTime = DateTime.Now;
      wrTime = stopTime - startTime;
      Console.WriteLine("всего: {0}", trainEvents.Count);
      Console.WriteLine("получены за: {0} мсек.", wrTime.TotalMilliseconds);
      Console.ReadLine();

      Console.WriteLine("");
      startTime = DateTime.Now;
      //IList<GIDMessage> trainMessages = ndeDataGid.GetGIDMessages();
      ndeDataGid.RunMessCommands();
      stopTime = DateTime.Now;
      wrTime = stopTime - startTime;
      //Console.WriteLine("всего: {0}", trainMessages.Count);
      Console.WriteLine("получены за: {0} мсек.", wrTime.TotalMilliseconds);
      Console.ReadLine();
      /
      Console.WriteLine("");
      Console.WriteLine("Текущие вектора обработки поездов");
      startTime = DateTime.Now;
      IList<TrainWorking> trainWorkVectors = ndeDataGid.GetWorkVectors();
      stopTime = DateTime.Now;
      wrTime = stopTime - startTime;
      Console.WriteLine("всего: {0}", trainWorkVectors.Count);
      Console.WriteLine("получены за: {0} мсек.", wrTime.TotalMilliseconds);

      Console.WriteLine("");
      Console.WriteLine("Актуальные поезда");
      startTime = DateTime.Now;
      IList<ActualTrain> actualTrains = ndeDataGid.GetActualTrains();
      stopTime = DateTime.Now;
      wrTime = stopTime - startTime;
      Console.WriteLine("всего: {0}", actualTrains.Count);
      Console.WriteLine("получены за: {0} мсек.", wrTime.TotalMilliseconds);
      
      Console.WriteLine("");
      Console.WriteLine("Рабочие справки");
      startTime = DateTime.Now;
      IList<WorkMessage> workMessages = ndeDataGid.GetWorkMessages();
      stopTime = DateTime.Now;
      wrTime = stopTime - startTime;
      Console.WriteLine("всего: {0}", workMessages.Count);
      Console.WriteLine("получены за: {0} мсек.", wrTime.TotalMilliseconds);
      * /
      Console.WriteLine("");
      Console.WriteLine("Актуальные справки");
      startTime = DateTime.Now;
      var trainsAndMes = new TrainMessagesManager(ndeDataCnf,ndeDataGid, ndeDataMes);
      trainsAndMes.UpdateActualMessages();
      stopTime = DateTime.Now;
      wrTime = stopTime - startTime;
      Console.WriteLine("получены за: {0} мсек.", wrTime.TotalMilliseconds);
      Console.ReadLine();
      */
      /*
      Console.WriteLine("");
      var fakeManader = new TrainMessagesManager(ndeDataCnf, ndeDataGid, ndeDataMes);
      var updater = new UpdaterEngine(fakeManader, 10000);
      startTime = DateTime.Now;
      updater.Start();
      //Thread.Sleep(10000);
      Console.ReadLine();
      updater.Stop();
      stopTime = DateTime.Now;
      wrTime = stopTime - startTime;
      Console.WriteLine("выполнено за: {0} мсек.", wrTime.TotalMilliseconds);
      Console.ReadLine();
      */
      IList<ComDefinition> comDefinitions;
      string tmpS = "";
      while (true){
        comDefinitions = ndeDataGid.GetComDefinitionsNoRun();
        foreach (var comDefinition in comDefinitions){
          //ndeDataGid.SetDefSendFlag(comDefinition.DefIdn, 4, DateTime.Now);
          tmpS   = "Приб на";
          if (comDefinition.ObStpType == 5){
            tmpS = "Отпр  с";
          }
          Console.WriteLine("{0} - {1} {2} {3} в {4} т.время {5} колл. {6}"
            ,comDefinition.DefIdn
            ,tmpS
            ,comDefinition.StatCode
            ,comDefinition.TrainNum
            ,comDefinition.ComStartTime.ToString(@"HH:mm:ss")
            ,ndeDataGid.GetTimeGIDStop().ToString(@"HH:mm:ss")
            ,comDefinition.CollStartTime.ToString(@"HH:mm:ss"));
        }
        Console.ReadLine();
      }
    }
  }
}
