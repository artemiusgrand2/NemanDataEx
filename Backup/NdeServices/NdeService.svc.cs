﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web.Configuration;
using BCh.Ktc.Nde.MiddleTier;
using NdeDataAccessFb;
using NdeDataClasses;
using NdeDataClasses.Commands;
using NdeDataClasses.Configuration;
using NdeInterfases;

namespace NdeServices
{
  // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "NdeService" in code, svc and config file together.
  public class NdeService : INdeService
  {
    private readonly INdeServiceManager _serviceManager;

    public NdeService()
    {
      var conString    = WebConfigurationManager.ConnectionStrings["gidDb"].ConnectionString;
      var conStringBuh = WebConfigurationManager.ConnectionStrings["buhDb"].ConnectionString;

      int deltaTimeStart = int.Parse(WebConfigurationManager.AppSettings["deltaTimeStart"]);
      int deltaTimeStop  = int.Parse(WebConfigurationManager.AppSettings["deltaTimeStop"]);

      BuhSection[] buhSections = NdeConfigurationHelper.RetrieveBuhSectionsFromConfiguration("engine");

      //Репозиторий для работы с данными ГИД
      var repository = new GidRepository(conString, deltaTimeStart, deltaTimeStop, conStringBuh, buhSections);
      //
      _serviceManager = new NdeServiceManager(repository);
    }
    //Дублируем функции (но делаем их контрактными).......................................................
    public IList<TrainEvent> GetLastTrainEvents(){
      return _serviceManager.GetLastTrainEvents();
    }
    public IList<TrainWorking> GetWorkVectors(){
      return _serviceManager.GetWorkVectors();
    }
    public IList<WorkMessage> GetWorkMessages(){
      return _serviceManager.GetWorkMessages();
    }
    public IList<GIDMessage> GetGIDMessages() {
      return _serviceManager.GetGIDMessages();
    }
    public IList<ComDefinition> GetComDefinitions(){
      return _serviceManager.GetComDefinitions();
    }
    public IList<string> GetRequests(){
      return _serviceManager.GetRequests();
    }

    public string ExecuteBindingCommand(BindingCommand command){
      return _serviceManager.ExecuteBindingCommand(command);
    }
  }
}
