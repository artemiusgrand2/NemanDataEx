using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NdeDataClasses;
using NdeDataClasses.Commands;
using NdeInterfases;
using log4net;

namespace BCh.Ktc.Nde.MiddleTier
{
    public class NdeServiceManager : INdeServiceManager
    {
        private static readonly ILog _logger = LogManager.GetLogger(typeof(NdeServiceManager));
        //Команды только по ГИДу (репозиторий ГИДа)
        private readonly IGidRepository _gidRepo;
        private readonly IiaspurgpRepository _iasRepo;
        private readonly string _ipUser;
        private readonly string _ipUserFull;
        private readonly string _ipCommandReceiving = string.Empty;
        //
        public NdeServiceManager(IGidRepository gidRepository, IiaspurgpRepository iasRepo, string ipUser, string ipUserFull, string ipCommandReceiving)
        {
            _gidRepo = gidRepository;
            _iasRepo = iasRepo;
            _ipUser = ipUser;
            _ipUserFull = ipUserFull;
            _ipCommandReceiving = ipCommandReceiving;
        }
        //........................................................
        //Последние события по поездам
        public IList<TrainEvent> GetLastTrainEvents()
        {
            _logger.Info($"Запрос получения последних исполненных событий. Начало !!! IP - {_ipUserFull}.");
            var trains = _gidRepo.GetLastTrainEvents();
            _logger.Info($"Запрос получения последних исполненных событий. Окончание !!! IP - {_ipUserFull}.");
            //
            return trains;
        }
        //Перечень id   плановых ниток, которые в работе
        public IList<int> GetPlanTrainIdns()
        {
            _logger.Info($"Запрос получения Id плановых ниток. Начало !!! IP - {_ipUserFull}.");
            var plans = _gidRepo.GetPlanTrainIdns();
            _logger.Info($"Запрос получения Id плановых ниток. Окончание !!! IP - {_ipUserFull}.");
            return plans;
        }
        //Дуйствующие вектора обработки
        public IList<TrainWorking> GetWorkVectors()
        {
            _logger.Info($"Запрос получения векторов. Начало !!! IP - {_ipUserFull}.");
            var vectors = _gidRepo.GetWorkVectors();
            _logger.Info($"Запрос получения векторов Окончание !!! IP - {_ipUserFull}.");
            //
            return vectors;
        }
        //История справок
        public IList<WorkMessage> GetWorkMessages()
        {
            _logger.Info($"Запрос получения сообщений Начало !!! IP - {_ipUserFull}.");
            var messages = _gidRepo.GetWorkMessages();
            _logger.Info($"Запрос получения сообщений. Окончание !!! IP - {_ipUserFull}.");
            //
            return messages;
        }
        //Сообщения ГИД
        public IList<GIDMessage> GetGIDMessages()
        {
            _logger.Info($"Запрос получения gid сообщений Начало !!! IP - {_ipUserFull}.");
            var messages = _gidRepo.GetGIDMessages();
            _logger.Info($"Запрос получения gid сообщений. Окончание !!! IP - {_ipUserFull}.");
            //
            return messages;
        }
        //Задания на исполнение команд
        public IList<ComDefinition> GetComDefinitions()
        {
            _logger.Info($"Запрос получения комманд. Начало !!! IP - {_ipUserFull}.");
            IList<ComDefinition> commands = new List<ComDefinition>();
            if (string.IsNullOrEmpty(_ipCommandReceiving) || (_ipCommandReceiving == _ipUser))
                commands = _gidRepo.GetComDefinitions();
            else
                _logger.Info($"Нет доступа на получение получение комманд. Для IP - {_ipUser}.");
            _logger.Info($"Запрос получения комманд. Окончание !!! IP - {_ipUserFull}.");
            //_iasRepo.AssignAppendexes(commands);
            return commands;
        }
        //Необработанные задания на исполнение команд
        public IList<ComDefinition> GetComDefinitionsNoRun()
        {
            return _gidRepo.GetComDefinitionsNoRun();
        }
        //
        public IList<string> GetRequests()
        {
            return _gidRepo.GetRequests();
        }
        //Распознаем внешнюю команду..............................
        public string ExecuteBindingCommand(BindingCommand command)
        {
            string retString = "";
            //TODO: rewrite this!!!
            var bindTrainTheadsCommand = command as BindTrainThreadsCommnand;
            if (bindTrainTheadsCommand != null)
            {
                //Связать нитки (поездов) БЕЗУСЛОВНО
                retString = _gidRepo.BindTrainThreads(
                  bindTrainTheadsCommand.SourceId,
                  bindTrainTheadsCommand.TargetId
                  );
                _logger.Info($"IP - {_ipUserFull}. " + retString);
                return retString;
            }
            var assignTrainNumberCommand = command as AssignTrainNumberCommand;
            if (assignTrainNumberCommand != null)
            {
                //Присвоить нитке номер поезда (полный)
                retString = _gidRepo.AssignTrainNumber(
                  assignTrainNumberCommand.TrainThreadId,
                  assignTrainNumberCommand.TrainNumberPrefix,
                  assignTrainNumberCommand.TrainNumber,
                  assignTrainNumberCommand.TrainNumberSuffix,
                  assignTrainNumberCommand.StationCode
                  );
                _logger.Info($"IP - {_ipUserFull}. " + retString);
                return retString;
            }
            var assignMessForTrainCommand = command as AssignMessForTrainCommand;
            if (assignMessForTrainCommand != null)
            {
                //Связать справку с поездом
                retString = _gidRepo.AssignMessageForTrain(
                  assignMessForTrainCommand.messageIdn,
                  assignMessForTrainCommand.trainIdn
                  );
                _logger.Info($"IP - {_ipUserFull}. " + retString);
                return retString;
            }
            var runTrackIoTrackCommand = command as RunTrackIoTrackCommand;
            if (runTrackIoTrackCommand != null)
            {
                //Сообщить о переезде с пути на путь
                retString = _gidRepo.RunTrackIoTrack(
                  runTrackIoTrackCommand.trainIdn,
                  runTrackIoTrackCommand.trackName,
                  runTrackIoTrackCommand.stationCode
                  );
                _logger.Info($"IP - {_ipUserFull}. " + retString);
                return retString;
            }
            var trainProcessCommand = command as TrainProcessCommand;
            if (trainProcessCommand != null)
            {
                //Управление векторами обработки поездов
                retString = _gidRepo.TrainProcess(trainProcessCommand);
                return retString;
            }
            var buh2DataCommand = command as Buh2DataCommand;
            if (buh2DataCommand != null)
            {
                //Записать данные Буг-2 в базу Буг - 3
                retString = _gidRepo.WriteBuh2Data(buh2DataCommand);
                return retString;
            }
            var setTrackInCommand = command as SetTrackInCommand;
            if (setTrackInCommand != null)
            {
                //Определить путь прибытия
                retString = _gidRepo.SetTrackIn(
                  setTrackInCommand.trainIdn,
                  setTrackInCommand.trackName,
                  setTrackInCommand.stationCode
                 );
                return retString;
            }
            var markTrainCommand = command as MarkTrainCommand;
            if (markTrainCommand != null)
            {
                //Маркировать поезд
                retString = _gidRepo.MarkTrain(
                  markTrainCommand.trainIdn,
                  markTrainCommand.strMarker
                 );
                return retString;
            }
            var writeTrainInputCommand = command as WriteTrainInputCommand;
            if (writeTrainInputCommand != null)
            {
                //Записать прибытие поезда
                retString = _gidRepo.WriteTrainInput(
                  writeTrainInputCommand.stationCode,
                  writeTrainInputCommand.trackName,
                  writeTrainInputCommand.destName
                 );
                return retString;
            }
            var writeTrainOutputCommand = command as WriteTrainOutputCommand;
            if (writeTrainOutputCommand != null)
            {
                //Записать отправление поезда
                retString = _gidRepo.WriteTrainOutput(
                  writeTrainOutputCommand.stationCode,
                  writeTrainOutputCommand.trackName,
                  writeTrainOutputCommand.destName
                 );
                return retString;
            }
            var markMessageCommand = command as MarkMessageCommand;
            if (markMessageCommand != null)
            {
                //Маркировать справку
                retString = _gidRepo.MarkMessage(
                  markMessageCommand.messageIdn,
                  markMessageCommand.strMarker
                 );
                return retString;
            }
            var stopMessForTrainCommand = command as StopMessForTrainCommand;
            if (stopMessForTrainCommand != null)
            {
                //Удалить связанную справку
                retString = _gidRepo.StopMessForTrain(
                  stopMessForTrainCommand.trainIdn
                 );
                return retString;
            }
            var trackPointMessagesCommand = command as TrackPointMessagesCommand;
            if (trackPointMessagesCommand != null)
            {
                //События контрольных точек перегона
                retString = _gidRepo.TrackPointMessages(trackPointMessagesCommand.trackPointMessages);
                return retString;
            }
            var bindPlanToTrainCommand = command as BindPlanToTrainCommand;
            if (bindPlanToTrainCommand != null)
            {
                //
                retString = _gidRepo.BindPlanToTrain(
                  bindPlanToTrainCommand.planEvents,
                  bindPlanToTrainCommand.trainIdn
                 );
                _logger.Info($"IP - {_ipUserFull}. " + retString);
                return retString;
            }
            var delPlanWireCommand = command as DelPlanWireCommand;
            if (delPlanWireCommand != null)
            {
                //Удалить плановую нитку
                retString = _gidRepo.DelPlanWire(
                  delPlanWireCommand.trainIdn
                 );
                _logger.Info($"IP - {_ipUserFull}. " + retString);
                return retString;
            }
            //установить флаг команды
            var setDefSendFlagCommand = command as SetDefSendFlagCommand;
            if (setDefSendFlagCommand != null)
            {
                if (string.IsNullOrEmpty(_ipCommandReceiving) || (_ipCommandReceiving == _ipUser))
                {
                    retString = _gidRepo.SetDefSendFlag(
               setDefSendFlagCommand.defIdn,
               setDefSendFlagCommand.sendFlag,
               setDefSendFlagCommand.tmDefC
               );
                }
                else
                {
                    retString = $"Нет доступа на установку флага для комманды. Для IP - {_ipUser}.";
                    _logger.Info($"IP - {_ipUserFull}. " + retString);
                }
                //
                return retString;
            }
            //
            var setReplysCommand = command as SetReplysCommand;
            if (setReplysCommand != null)
            {
                //
                retString = _gidRepo.SetReplys(
                  setReplysCommand.Replys
                 );
                return retString;
            }
            //удаляем плановый график
            var cleanPlanCommand = command as CleanPlanCommand;
            if (cleanPlanCommand != null)
            {
                if (string.IsNullOrEmpty(_ipCommandReceiving) || (_ipCommandReceiving == _ipUser))
                    retString = _gidRepo.CleanPlan();
                else
                    retString = $"Нет доступа на очистку планового графика. Для IP - {_ipUser}.";
                _logger.Info($"IP - {_ipUserFull}. " + retString);
                //
                return retString;
            }
            //записать  подтверждение события в прогнозный график
            var writeEnterExecutedPlanCommand = command as WriteEnterExecutedPlanCommand;
            if (writeEnterExecutedPlanCommand != null)
            {
                if (string.IsNullOrEmpty(_ipCommandReceiving) || (_ipCommandReceiving == _ipUser))
                    retString = _gidRepo.WriteEnterExecutedPlan(writeEnterExecutedPlanCommand.TrainNumber, writeEnterExecutedPlanCommand.PlanEvId, writeEnterExecutedPlanCommand.Station, writeEnterExecutedPlanCommand.Axis, writeEnterExecutedPlanCommand.NDO);
                else
                    retString = $"Нет доступа на запись подтверждение события в плановый график. Для IP - {_ipUser}.";
                _logger.Info($"IP - {_ipUserFull}. " + retString);
                return retString;
            }
            //не понял!!
            throw new NotImplementedException();
        }
    }
}
