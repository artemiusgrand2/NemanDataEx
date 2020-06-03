using System;
using System.Collections.Generic;
using NdeInterfases;
using NdeDataClasses;

namespace BCh.Ktc.Nde.MiddleTier
{
  //Работа с поездами и справками
  public class TrainMessagesManager : ITrainMessagesManager
  {
    private readonly ICnfRepository _cnfRepository;
    private readonly IGidRepository _gidRepository;
    private readonly IAsoupRepository _asoupRepository;
    private DateTime _lastMsTime;
    private DateTime _stopMsTime;
    //Конструктор
    public TrainMessagesManager(ICnfRepository cnfRepository
                               ,IGidRepository gidRepository
                               ,IAsoupRepository asoupRepository)
    {
      _cnfRepository = cnfRepository;
      _gidRepository = gidRepository;
      _asoupRepository = asoupRepository;
      _gidRepository.ClearWMessages(DateTime.Now);
      _lastMsTime = DateTime.MinValue;
      _stopMsTime = DateTime.MaxValue;
    }
    //Определить актуальные справки для поездов
    public void UpdateActualMessages(){
      TrainEvent _trainEventS = null;
      TrainEvent _trainEventE = null;
      DateTime _timeStart, _timeEnd;
      //Профилактическая очистка
      _gidRepository.ClearTMessages();
      //Для всех актуальных ниток (с номерами и событиями)
      IList<ActualTrain> actualTrains = _gidRepository.GetActualTrains();
      foreach (var actualTrain in actualTrains){
        //привязана ли уже к поезду справка?
        TrainMessage curMessage = _gidRepository.GetActualMessage(actualTrain);
        //время начала поиска свежих справок
        DateTime sttTime = _gidRepository.GetTimeGIDStart(); //если не привязана
        if (curMessage != null){//если привязана
          sttTime = curMessage.MessageTime;
        }else{
          actualTrain.TrainNumber = actualTrain.TrainNumber;
        }
        //Получить список свежих справок по поезду, начиная с последней
        IList<TrainMessage> trainMessages =
          _asoupRepository.RetrieveTrainMessagesByTrainNumber(int.Parse(actualTrain.TrainNumber)
                                                            ,sttTime, _gidRepository.GetTimeGIDStop());
        if (trainMessages.Count == 0){continue;}
        //Пытаемся найти свежую справку для поезда
        foreach (var trainMessage in trainMessages){
          //получить все события поезда по станции, выдавшей справку
          IList<TrainEvent> trainEvents = 
            _gidRepository.GetTrainEventsForMess(trainMessage,actualTrain,_cnfRepository);
          if (trainEvents.Count == 0){continue;}
          //Определяем диапозон захвата справки
          _timeStart = DateTime.MaxValue;
          foreach (var trainEvent in trainEvents){
            if (trainEvent.EventTime < _timeStart){
              _timeStart = trainEvent.EventTime;
              _trainEventS = trainEvent;
            }
          }
          _timeEnd = DateTime.MinValue;
          foreach (var trainEvent in trainEvents){
            if (trainEvent.EventTime > _timeEnd){
              _timeEnd = trainEvent.EventTime;
              _trainEventE = trainEvent;
            }
          }
          //Первое событие
          if (_trainEventS.EventType != 3){//прибытие
            _timeStart -= new TimeSpan(0, 20, 0);
          }else{//отправление
            _timeStart -= new TimeSpan(2, 0, 0);
          }
          //Последнее событие
          if (_trainEventE.EventType == 3){//отправление
            _timeEnd += new TimeSpan(0, 20, 0);
          }
          else{//прибытие
            _timeEnd += new TimeSpan(2, 0, 0);
          }
          //Была ли дана справка в определенном диапозоне времени
          if ((trainMessage.MessageTime >= _timeStart) && (trainMessage.MessageTime <= _timeEnd)){
            if (curMessage == null){//если до этого справка не была указана
              //записываем новую
              _gidRepository.WriteNewMessForTrain(trainMessage, actualTrain);
            }
            else{//если была
              //заменяем
              _gidRepository.ChangeNewMessForTrain(trainMessage, actualTrain);
            }
            break;
          }
        }
      }
      _gidRepository.WriteAllSaipsDataToGid();
    }
    //Связать справки с поездами по данным из ГИДа
    public void AssignForeignMessages(){
      //несвязанные актуальные справки
      IList<WorkMessage> actualMessages = _gidRepository.GetActualMessages();
      int trIdn;
      string stErr;
      foreach (var actualMessage in actualMessages){
        //есть ли поезд с таким индексом в ГИДе?
        trIdn = 
          _gidRepository.GetTrainByForm(actualMessage.StForm,actualMessage.NmSost,actualMessage.StDest);
        if(trIdn == -1){continue;}
        stErr = _gidRepository.AssignMessageForTrain(actualMessage.MessIdn,trIdn);
      }
    }
    //Поддержка истории справок
    public void UpdateMessagesHistory(){
      _stopMsTime = _gidRepository.GetTimeGIDStop();
      if (_stopMsTime == DateTime.MaxValue){
        //В ГИДе нет записей
        return;
      }
      if (_lastMsTime == DateTime.MinValue){
        //Подстраиваемся под первое собатие ГИД
        _lastMsTime = _gidRepository.GetTimeGIDStart();
      }
      //Чистим лишнее (до первого события ГИД)
      _gidRepository.ClearWMessages(_gidRepository.GetTimeGIDStart());
      //Получаем свежие справки
      IList<TrainMessage> trainMessages = 
        _asoupRepository.RetrieveTrainMessages(_lastMsTime,_stopMsTime);
      //
      foreach (var trainMessage in trainMessages){
        //Записываем справку в историю
        _gidRepository.WriteWorkMessage(trainMessage);
        //Определяем время старта следующего запроса
        if (trainMessage.LastUpTime > _lastMsTime){
          _lastMsTime = trainMessage.LastUpTime;
        }
      }
      //Работаем
      _gidRepository.PrepareWorkMessages();
      //_gidRepository.SrhTrEventsForMessages();
      _gidRepository.SetStopMess();
      _gidRepository.SetMessProperties();
      _gidRepository.RunMessCommands();
    }
    //---------------------------------------------------------------------------------------------
    //
    private bool IfTrainInteres(TrainMessage trainMessage)
    {
      if (trainMessage.TrainNumber <= 999){return false;}
      if((trainMessage.TrainNumber >= 4001)&&(trainMessage.TrainNumber <= 4998)){return false;}
      if((trainMessage.TrainNumber >= 6001)&&(trainMessage.TrainNumber <= 6998)){return false;}
      if((trainMessage.TrainNumber >= 8001)&&(trainMessage.TrainNumber <= 9098)){return false;}
      return true;
    }
  }
}
