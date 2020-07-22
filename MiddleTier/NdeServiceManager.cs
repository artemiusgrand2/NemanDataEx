using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NdeDataClasses;
using NdeDataClasses.Commands;
using NdeInterfases;

namespace BCh.Ktc.Nde.MiddleTier
{
    public class NdeServiceManager : INdeServiceManager
    {
        //Команды только по ГИДу (репозиторий ГИДа)
        private readonly IGidRepository _gidRepo;
        private readonly IiaspurgpRepository _iasRepo;
        //
        public NdeServiceManager(IGidRepository gidRepository, IiaspurgpRepository iasRepo)
        {
            _gidRepo = gidRepository;
            _iasRepo = iasRepo;
        }
        //........................................................
        //Последние события по поездам
        public IList<TrainEvent> GetLastTrainEvents()
        {
            return _gidRepo.GetLastTrainEvents();
        }
        //Дуйствующие вектора обработки
        public IList<TrainWorking> GetWorkVectors()
        {
            return _gidRepo.GetWorkVectors();
        }
        //История справок
        public IList<WorkMessage> GetWorkMessages()
        {
            return _gidRepo.GetWorkMessages();
        }
        //Сообщения ГИД
        public IList<GIDMessage> GetGIDMessages()
        {
            return _gidRepo.GetGIDMessages();
        }
        //Задания на исполнение команд
        public IList<ComDefinition> GetComDefinitions()
        {
            var commands = _gidRepo.GetComDefinitions();
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
                return retString;
            }
            var delPlanWireCommand = command as DelPlanWireCommand;
            if (delPlanWireCommand != null)
            {
                //Удалить плановую нитку
                retString = _gidRepo.DelPlanWire(
                  delPlanWireCommand.trainIdn
                 );
                return retString;
            }
            //установить флаг команды
            var setDefSendFlagCommand = command as SetDefSendFlagCommand;
            if (setDefSendFlagCommand != null)
            {
                //
                retString = _gidRepo.SetDefSendFlag(
                  setDefSendFlagCommand.defIdn,
                  setDefSendFlagCommand.sendFlag,
                  setDefSendFlagCommand.tmDefC
                 );
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
                //
                retString = _gidRepo.CleanPlan();
                return retString;
            }
            //не понял!!
            throw new NotImplementedException();
        }
    }
}
