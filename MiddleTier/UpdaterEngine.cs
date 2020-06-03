using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using NdeInterfases;
using log4net;

namespace BCh.Ktc.Nde.MiddleTier
{
  //Обработка по таймеру
  public class UpdaterEngine
  {
    private static readonly ILog _logger = LogManager.GetLogger(typeof(UpdaterEngine));
    private readonly ITrainMessagesManager _trainMessagesManager;
    private readonly Timer _timer;
    private readonly int _timerPeriod;
    //Конструктор
    public UpdaterEngine(ITrainMessagesManager trainMessagesManager, int timerPeriod){
      _trainMessagesManager = trainMessagesManager;
      _timer = new Timer(OnTimerTick);
      _timerPeriod = timerPeriod;
    }
    //При старте
    public void Start(){
      _logger.Info("Updater started");
      //_timer.Change(30000, _timerPeriod);
      _timer.Change(1000, _timerPeriod);
    }
    //При останове
    public void Stop(){
      _logger.Info("Updater stopped");
      _timer.Change(Timeout.Infinite, Timeout.Infinite);
    }
    //По таймеру
    private void OnTimerTick(object obj){
      _logger.Info("Запуск по таймеру...");
      //Останавливаем таймер
      _timer.Change(Timeout.Infinite, Timeout.Infinite);
      //Обработка актуальных справок
      try {
        _trainMessagesManager.UpdateActualMessages();
      }catch (Exception exception){
        _logger.Error("An exception occurred in UpdateActualMessages", exception);
      }
      //Связываем справкм по данным из ГИДа
      try{
        _trainMessagesManager.AssignForeignMessages();
      } catch (Exception exception) {
        _logger.Error("An exception occurred in AssignForeignMessages", exception);
      }
      //Обработка истории справок
      try {
        _trainMessagesManager.UpdateMessagesHistory();
      } catch (Exception exception) {
        _logger.Error("An exception occurred in UpdateMessagesHistory", exception);
      }
      //Восстанавливаем таймер
      _timer.Change(_timerPeriod, _timerPeriod);
    }
  }
}
