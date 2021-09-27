using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;
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

        public static void Start()
        {
            _logger.Info($"Запуск службы.");
        }

        public static void Stop()
        {
            _logger.Info($"Остановка службы.");
        }

        //........................................................
        //Последние события по поездам
        public IList<TrainEvent> GetLastTrainEvents()
        {
            IList<TrainEvent> trains = new List<TrainEvent>();
            _logger.Info($"Запрос получения последних исполненных событий. Начало !!! IP - {_ipUserFull}. {GetDiagnosticInfo()}");
            try
            {
                trains = _gidRepo.GetLastTrainEvents();
                AnalisPlan(trains);
            }
            catch (Exception error)
            {
                _logger.Error(error);
            }
            _logger.Info($"Запрос получения последних исполненных событий. Окончание !!! IP - {_ipUserFull}. {GetDiagnosticInfo()}");
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
            _logger.Info($"Запрос получения сообщений Начало !!! IP - {_ipUserFull}. {GetDiagnosticInfo()}");
            var messages = _gidRepo.GetWorkMessages();
            _logger.Info($"Запрос получения сообщений. Окончание !!! IP - {_ipUserFull}. {GetDiagnosticInfo()}");
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

        public IList<int> GetIdComDefinitionsInWork(IList<int> idsCom)
        {
            _logger.Info($"Запрос получения id комманд которые в работе. Начало !!! IP - {_ipUserFull}.");
            var ids = _gidRepo.GetIdComDefinitionsInWork(idsCom);
            _logger.Info($"Запрос получения id комманд которые в работе. Окончание !!! IP - {_ipUserFull}.");
            //
            return ids;
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

        private string GetDiagnosticInfo()
        {
           // var firebirdPro = System.Diagnostics.Process.GetProcesses().Where(x => x.ProcessName.IndexOf("fb_inet_server.exe") != -1).FirstOrDefault();
           // return $"{System.Diagnostics.Process.GetCurrentProcess().PrivateMemorySize64 / 1000000}MB {((firebirdPro != null)? (firebirdPro.PrivateMemorySize64/1000):0)}MB";
            return $"{System.Diagnostics.Process.GetCurrentProcess().PrivateMemorySize64 / 1000000}MB";
        }

        //Распознаем внешнюю команду..............................
        public string ExecuteBindingCommand(BindingCommand command)
        {
            string retString = "";

            if (!(string.IsNullOrEmpty(_ipCommandReceiving) || (_ipCommandReceiving == _ipUser)))
                return $"Для пользователя с IP - {_ipUser} нет доступа выполнения комманды.";

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
                var answer = _gidRepo.BindPlanToTrain(
                  bindPlanToTrainCommand.planEvents,
                  bindPlanToTrainCommand.trainIdn
                 );
                //
                _logger.Info($"IP - {_ipUserFull}. " + answer.LogMessage);
                return SerializerToStr(typeof(BindPlanToTrainAnswer), answer); // answer.LogMessage;
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
                var answer = _gidRepo.SetDefSendFlag(
               setDefSendFlagCommand.defIdn,
               setDefSendFlagCommand.sendFlag,
               setDefSendFlagCommand.tmDefC
               );
                //
                _logger.Info($"IP - {_ipUserFull}. " + answer.LogMessage);
                //
                return (answer as SetDefSendFlagAnswer).IsWrite.ToString();
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
                var answer = _gidRepo.CleanPlan();
                _logger.Info($"IP - {_ipUserFull}. " + answer.LogMessage);
                //
                return (answer as CleanPlanAnswer).IsClean.ToString();
            }
            //записать  подтверждение события в прогнозный график
            var writeEnterExecutedPlanCommand = command as WriteEnterExecutedPlanCommand;
            if (writeEnterExecutedPlanCommand != null)
            {
                retString = _gidRepo.WriteEnterExecutedPlan(writeEnterExecutedPlanCommand.TrainNumber, writeEnterExecutedPlanCommand.PlanEvId, writeEnterExecutedPlanCommand.Station, writeEnterExecutedPlanCommand.Axis, writeEnterExecutedPlanCommand.NDO);
                _logger.Info($"IP - {_ipUserFull}. " + retString);
                return retString;
            }
            //не понял!!
            throw new NotImplementedException();
        }

        public string SerializerToStr(Type type, object o)
        {
            var result = string.Empty;
            using (var stream = new MemoryStream())
            {
                var serializer = new XmlSerializer(type);
                serializer.Serialize(stream, o);
                stream.Position = 0;
                var reader = new StreamReader(stream);
                result = reader.ReadToEnd();
            }
            //
            return result;
        }

        private void AnalisPlan(IList<TrainEvent> trains)
        {
            try
            {
                foreach (var train in trains)
                {
                    if (train.PlanEvents != null)
                    {
                        var index = 0;
                        foreach (var planEvent in train.PlanEvents)
                        {
                            if (index > 0 && planEvent.EventStation != train.PlanEvents[index - 1].EventStation && planEvent.AckEventFlag != 2 && train.PlanEvents[index - 1].AckEventFlag == 2)
                            {
                                var deltaPl = (planEvent.EventTimeP - train.PlanEvents[index - 1].EventTimeP).TotalMinutes;
                                var deltaProg = (planEvent.EventTime - train.PlanEvents[index - 1].EventTime).TotalMinutes;
                                //
                                var delta = Math.Round(Math.Abs(deltaProg - deltaPl), 1);
                                if (delta > 1)
                                {
                                    _logger.Info($"IP - {_ipUserFull}. " + $"У поезда {train.TrainNumber} нитки - {train.NormIdn} расхождение перегонного времени хода на {delta} мин., на пергоне - {train.PlanEvents[index - 1].EventStation} - {planEvent.EventStation}. " + 
                                                 $"В плане {train.PlanEvents[index - 1].EventTimeP.ToString()} - {planEvent.EventTimeP.ToString()} в прогнозе - {train.PlanEvents[index - 1].EventTime.ToString()} - {planEvent.EventTime.ToString()}");
                                }
                            }
                            index++;
                        }
                    }
                }
            }
            catch { }
        }

    }
}
