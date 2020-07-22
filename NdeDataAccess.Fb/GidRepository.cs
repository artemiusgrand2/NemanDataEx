using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using FirebirdSql.Data.FirebirdClient;
using NdeDataClasses.Commands;
using NdeDataClasses.Configuration;
using NdeInterfases;
using NdeDataClasses;

namespace NdeDataAccessFb
{
    //Реализация функций, определяемых интерфейсом IGidRepository
    public class GidRepository : IGidRepository
    {
        //Переменные-----------------------------------------------------------------------------------
        private readonly string _connectionString;
        private readonly bool _flPlay;
        private readonly string _connectionStringBuh;
        private readonly int _deltaTimeStart;
        private readonly int _deltaTimeStop;
        private readonly BuhSection[] _buhSections;
        //Команды
        private FbCommand _command1;
        private FbCommand _command2;
        private FbCommand _command3;
        private readonly FbCommand _command4;
        private readonly FbCommand _command5;
        private FbCommand _command6;
        private readonly FbCommand _command7;
        private FbCommand _command8;
        private FbCommand _command9;
        private FbCommand _command10;
        private FbCommand _command11;
        private readonly FbCommand _command12;
        private readonly FbCommand _command13;
        private readonly FbCommand _command14;
        private readonly FbCommand _command15;
        private readonly FbCommand _command16;
        private readonly FbCommand _command17;
        private readonly FbCommand _command18;
        private readonly FbCommand _command19;
        private readonly FbCommand _command20;
        private readonly FbCommand _command21;
        private readonly FbCommand _command22;
        private readonly FbCommand _command23;
        private FbCommand _command24;
        private FbCommand _command25;
        private readonly FbCommand _command26;
        private readonly FbCommand _command27;
        private readonly FbCommand _command28;
        private readonly FbCommand _command29;
        private readonly FbCommand _command30;
        private FbCommand _command31;
        private FbCommand _command32;
        private readonly FbCommand _command33;
        private readonly FbCommand _command34;
        private readonly FbCommand _command35;
        private FbCommand _command36;
        private FbCommand _command37;
        private FbCommand _command38;
        private FbCommand _command39;
        private FbCommand _command40;
        private FbCommand _command41;
        private readonly FbCommand _command42;
        private FbCommand _command43;
        private FbCommand _command44;
        private FbCommand _command45;
        private FbCommand _command46;
        private FbCommand _command47;
        private FbCommand _command48;
        private FbCommand _command49;
        private FbCommand _command50;
        private readonly FbCommand _command51;
        private FbCommand _command52;
        private readonly FbCommand _command53;
        private readonly FbCommand _command54;
        private readonly FbCommand _command55;
        private readonly FbCommand _command56;
        private readonly FbCommand _command57;
        private readonly FbCommand _command58;
        private readonly FbCommand _command59;
        private readonly FbCommand _command60;
        private readonly FbCommand _command61;
        private FbCommand _command62;
        private FbCommand _command63;
        private FbCommand _command64;
        private FbCommand _command65;
        private FbCommand _command66;
        private FbCommand _command67;
        private FbCommand _command68;
        private readonly FbCommand _command69;
        private FbCommand _command70;
        private readonly FbCommand _command71;
        private readonly FbCommand _command72;
        private readonly FbCommand _command73;
        private readonly FbCommand _command74;
        private readonly SqlCommand _command75;
        private readonly SqlCommand _command76;
        private SqlCommand _command77;
        private readonly SqlCommand _command78;
        private readonly SqlCommand _command79;
        private SqlCommand _command80;
        private SqlCommand _command81;
        private SqlCommand _command82;
        private FbCommand _command83;
        private FbCommand _command84;
        private FbCommand _command85;
        private FbCommand _command86;
        private FbCommand _command87;
        private FbCommand _command88;
        private FbCommand _command89;
        private FbCommand _command90;
        //Параметры
        private readonly FbParameter _parEvTime1;
        private readonly FbParameter _parTrainId2;
        private readonly FbParameter _parEventTime2;
        private readonly FbParameter _parMessTime5;
        private readonly FbParameter _parTrnIdn6;
        private readonly FbParameter _parTrnIdn7;
        private readonly FbParameter _parEvStat7;
        private readonly FbParameter _parTrainIdn8;
        private readonly FbParameter _parMsIdn8;
        private readonly FbParameter _parMsTime8;
        private readonly FbParameter _parMsStation8;
        private readonly FbParameter _parOperation8;
        private readonly FbParameter _parFlags8;
        private readonly FbParameter _parTrainNum8;
        private readonly FbParameter _parStForm8;
        private readonly FbParameter _parNmSost8;
        private readonly FbParameter _parStDest8;
        private readonly FbParameter _parTrainAttr8;
        private readonly FbParameter _parLocoSerie8;
        private readonly FbParameter _parLocoNum8;
        private readonly FbParameter _parSttTimeH8;
        private readonly FbParameter _parSttTimeM8;
        private readonly FbParameter _parMachinist8;
        private readonly FbParameter _parWagCoun8;
        private readonly FbParameter _parWagLoaded8;
        private readonly FbParameter _parWagEmpty8;
        private readonly FbParameter _parWagNoWork8;
        private readonly FbParameter _parNtWeight8;
        private readonly FbParameter _parGrWeight8;
        private readonly FbParameter _parTrainIdn9;
        private readonly FbParameter _parMsIdn9;
        private readonly FbParameter _parMsTime9;
        private readonly FbParameter _parMsStation9;
        private readonly FbParameter _parOperation9;
        private readonly FbParameter _parFlags9;
        private readonly FbParameter _parTrainNum9;
        private readonly FbParameter _parStForm9;
        private readonly FbParameter _parNmSost9;
        private readonly FbParameter _parStDest9;
        private readonly FbParameter _parTrainAttr9;
        private readonly FbParameter _parLocoSerie9;
        private readonly FbParameter _parLocoNum9;
        private readonly FbParameter _parSttTimeH9;
        private readonly FbParameter _parSttTimeM9;
        private readonly FbParameter _parMachinist9;
        private readonly FbParameter _parWagCoun9;
        private readonly FbParameter _parWagLoaded9;
        private readonly FbParameter _parWagEmpty9;
        private readonly FbParameter _parWagNoWork9;
        private readonly FbParameter _parNtWeight9;
        private readonly FbParameter _parGrWeight9;
        private readonly FbParameter _parStation10;
        private readonly FbParameter _parTrack10;
        private readonly FbParameter _parTime10;
        private readonly FbParameter _parMessTime12;
        private readonly FbParameter _parMsIdn13;
        private readonly FbParameter _parMsTime13;
        private readonly FbParameter _parMsStation13;
        private readonly FbParameter _parOperation13;
        private readonly FbParameter _parFlags13;
        private readonly FbParameter _parTrainNum13;
        private readonly FbParameter _parStForm13;
        private readonly FbParameter _parNmSost13;
        private readonly FbParameter _parStDest13;
        private readonly FbParameter _parTrainAttr13;
        private readonly FbParameter _parLocoSerie13;
        private readonly FbParameter _parLocoNum13;
        private readonly FbParameter _parSttTimeH13;
        private readonly FbParameter _parSttTimeM13;
        private readonly FbParameter _parMachinist13;
        private readonly FbParameter _parWagCoun13;
        private readonly FbParameter _parWagLoaded13;
        private readonly FbParameter _parWagEmpty13;
        private readonly FbParameter _parWagNoWork13;
        private readonly FbParameter _parNtWeight13;
        private readonly FbParameter _parGrWeight13;
        private readonly FbParameter _parBadCode13;
        private readonly FbParameter _parMsIdn15;
        private readonly FbParameter _parMsIdn16;
        private readonly FbParameter _parMessTime16;
        private readonly FbParameter _parMessTime17;
        private readonly FbParameter _parTrainIdn17;
        private readonly FbParameter _parMsIdn17;
        private readonly FbParameter _parTrainNum19;
        private readonly FbParameter _parTrainIdn20;
        private readonly FbParameter _parStation20;
        private readonly FbParameter _parTimeSp21;
        private readonly FbParameter _parMessIdn21;
        private readonly FbParameter _parStopTime23;
        private readonly FbParameter _parMessTime23;
        private readonly FbParameter _parStation23;
        private readonly FbParameter _parNmSost23;
        private readonly FbParameter _parMsIdn23;
        private readonly FbParameter _parTrainIdnS24;
        private readonly FbParameter _parTrainIdnT24;
        private readonly FbParameter _parCommand25;
        private readonly FbParameter _parCOM_TIME25;
        private readonly FbParameter _parTrain_IdnH125;
        private readonly FbParameter _parNORM_IDNH125;
        private readonly FbParameter _parTrain_NumH125;
        private readonly FbParameter _parI_ST_FORMH125;
        private readonly FbParameter _parI_ST_DESTH125;
        private readonly FbParameter _parI_SOST_NUMH125;
        private readonly FbParameter _parDOP_PROPH125;
        private readonly FbParameter _parREZERVH125;
        private readonly FbParameter _parST_IN_ZONEH125;
        private readonly FbParameter _parST_OUT_ZONEH125;
        private readonly FbParameter _parTrain_IdnH225;
        private readonly FbParameter _parNORM_IDNH225;
        private readonly FbParameter _parTrain_NumH225;
        private readonly FbParameter _parI_ST_FORMH225;
        private readonly FbParameter _parI_ST_DESTH225;
        private readonly FbParameter _parI_SOST_NUMH225;
        private readonly FbParameter _parDOP_PROPH225;
        private readonly FbParameter _parREZERVH225;
        private readonly FbParameter _parST_IN_ZONEH225;
        private readonly FbParameter _parST_OUT_ZONEH225;
        private readonly FbParameter _parTRAIN_IDNE125;
        private readonly FbParameter _parEV_TYPEE125;
        private readonly FbParameter _parEV_TIMEE125;
        private readonly FbParameter _parEv_StationE125;
        private readonly FbParameter _parEV_AXISE125;
        private readonly FbParameter _parEv_NDOE125;
        private readonly FbParameter _parEV_NE_STATIONE125;
        private readonly FbParameter _parEV_REC_IDNE125;
        private readonly FbParameter _parEV_FLAGE125;
        private readonly FbParameter _parTRAIN_IDNE225;
        private readonly FbParameter _parEV_TYPEE225;
        private readonly FbParameter _parEV_TIMEE225;
        private readonly FbParameter _parEv_StationE225;
        private readonly FbParameter _parEV_AXISE225;
        private readonly FbParameter _parEv_NDOE225;
        private readonly FbParameter _parEV_NE_STATIONE225;
        private readonly FbParameter _parEV_REC_IDNE225;
        private readonly FbParameter _parEV_FLAGE225;
        private readonly FbParameter _parMessIdn28;
        private readonly FbParameter _parMsIdnPrev28;
        private readonly FbParameter _parMessProp28;
        private readonly FbParameter _parWirIdnPrev28;
        private readonly FbParameter _parComCngNum28;
        private readonly FbParameter _parComCngWir28;
        private readonly FbParameter _parMessIdn30;
        private readonly FbParameter _parMessProp30;
        private readonly FbParameter _parTrainIdnS31;
        private readonly FbParameter _parTrainIdnT31;
        private readonly FbParameter _parTrainIdnS32;
        private readonly FbParameter _parTrainIdnT32;
        private readonly FbParameter _parComCngWir34;
        private readonly FbParameter _parComCngNum35;
        private readonly FbParameter _parTrainIdn36;
        private readonly FbParameter _parTrainIdn37;
        private readonly FbParameter _parTrainIdn38;
        private readonly FbParameter _parStation39;
        private readonly FbParameter _parTrack39;
        private readonly FbParameter _parTime39;
        private readonly FbParameter _parStation40;
        private readonly FbParameter _parTrack40;
        private readonly FbParameter _parTime40;
        private readonly FbParameter _parSMStation41;
        private readonly FbParameter _parMsType41;
        private readonly FbParameter _parEvTime41;
        private readonly FbParameter _parMsTime41;
        private readonly FbParameter _parBOType41;
        private readonly FbParameter _parBOName41;
        private readonly FbParameter _parDOType41;
        private readonly FbParameter _parDOName41;
        private readonly FbParameter _parDopIdn41;
        private readonly FbParameter _parEvIdn43;
        private readonly FbParameter _parTrack43;
        private readonly FbParameter _parTime43;
        private readonly FbParameter _parTrainIdn44;
        private readonly FbParameter _parMarker44;
        private readonly FbParameter _parMessIdn45;
        private readonly FbParameter _parMarker45;
        private readonly FbParameter _parTrainIdn46;
        private readonly FbParameter _parTrainIdn47;
        private readonly FbParameter _parMessIdn48;
        private readonly FbParameter _parTrainIdn49;
        private readonly FbParameter _parStation50;
        private readonly FbParameter _parTrack50;
        private readonly FbParameter _parTime50;
        private readonly FbParameter _parStForm54;
        private readonly FbParameter _parSstNum54;
        private readonly FbParameter _parStDest54;
        private readonly FbParameter _parMessTime55;
        private readonly FbParameter _parTrainIdn58;
        private readonly FbParameter _parEvTime58;
        private readonly FbParameter _parMsIdn59;
        private readonly FbParameter _parMsType59;
        private readonly FbParameter _parMsTime59;
        private readonly FbParameter _parMsStat59;
        private readonly FbParameter _parTrainNum59;
        private readonly FbParameter _parMsAxis59;
        private readonly FbParameter _parNeStat59;
        private readonly FbParameter _parMsFlags59;
        private readonly FbParameter _parMsIdn60;
        private readonly FbParameter _parMsIdn61;
        private readonly FbParameter _parMsFlags61;
        private readonly FbParameter _parTrainIdn62;
        private readonly FbParameter _parTrainIdn63;
        private readonly FbParameter _parNormIdn63;
        private readonly FbParameter _parRecIdn64;
        private readonly FbParameter _parNormIdn64;
        private readonly FbParameter _parTrainNum64;
        private readonly FbParameter _parStForm64;
        private readonly FbParameter _parStDest64;
        private readonly FbParameter _parSostNum64;
        private readonly FbParameter _parDopProp64;
        private readonly FbParameter _parRezerv64;
        private readonly FbParameter _parInZone64;
        private readonly FbParameter _parOutZone64;
        private readonly FbParameter _parWrNext64;
        private readonly FbParameter _parWrPrior64;
        private readonly FbParameter _parFlNoDel64;
        private readonly FbParameter _parTrainIdn65;
        private readonly FbParameter _parFlSost65;
        private readonly FbParameter _parTrainIdn66;
        private readonly FbParameter _parEvType66;
        private readonly FbParameter _parEvTime66;
        private readonly FbParameter _parEvTimeP66;
        private readonly FbParameter _parEvStation66;
        private readonly FbParameter _parEvAxis66;
        private readonly FbParameter _parEvNDO66;
        private readonly FbParameter _parCollSt66;
        private readonly FbParameter _parNeStation66;
        private readonly FbParameter _parDefIdn67;
        private readonly FbParameter _parSndFlag67;
        private readonly FbParameter _parTmDefC67;
        private readonly FbParameter _parStdForm68;
        private readonly FbParameter _parSndFlag68;
        private readonly FbParameter _parDefIdn69;
        private readonly FbParameter _parPlnEvIdn70;
        private readonly FbParameter _parPlnEvIdn71;
        private readonly FbParameter _parPlnEvIdn72;
        private readonly FbParameter _parPlnIdn73;
        private readonly FbParameter _parTrainIdn74;

        private readonly SqlParameter _parFlags75;
        private readonly SqlParameter _parFlagsO76;
        private readonly SqlParameter _parFlagsN76;
        private readonly SqlParameter _parReplyText77;
        private readonly SqlParameter _parFlags78;
        private readonly SqlParameter _parFlagsO79;
        private readonly SqlParameter _parFlagsN79;
        private readonly SqlParameter _parMessTimeStt80;
        private readonly SqlParameter _parMessTimeStp80;
        private readonly SqlParameter _parStation80;
        private readonly SqlParameter _parNsuNumber80;
        private readonly SqlParameter _parMessIdn81;
        private readonly SqlParameter _parStation81;
        private readonly SqlParameter _parNsuNumber81;
        private readonly SqlParameter _parMessTime81;
        private readonly SqlParameter _parDestination81;
        private readonly SqlParameter _parLocoSeries81;
        private readonly SqlParameter _parLocoNumber81;
        private readonly SqlParameter _parMessIdn82;
        private readonly SqlParameter _parTrainIndex82;
        private readonly SqlParameter _parTrainNumber82;
        private readonly SqlParameter _parFlags82;
        private readonly FbParameter _parTrainIdn84;
        private readonly FbParameter _parTrainNum85;
        private readonly FbParameter _parTrainIdn86;
        private readonly FbParameter _parTrainIdn90;
        //Тексты запросов для команд
        //Времена последних событий для всех ниток (поездов)
        private const string CommandText1 = "SELECT TG.Train_Idn, MAX(TG.Ev_Time)"
      + " FROM TGraphicID TG"
      + " INNER JOIN TTrainHeaders TH"
      + " ON TG.Train_Idn = TH.Train_Idn"
      + " WHERE TG.Ev_Time > @EvTime"
      + " GROUP BY TG.Train_Idn"
      + " ORDER BY TG.Train_Idn";
        //Последние ссобытия ниток (поездов)
        private const string CommandText2 =
          "SELECT g.Ev_Station, g.Ev_Type, g.Ev_Axis, g.Ev_Dop, g.Ev_NDO, g.Ev_NE_Station"
          + ", h.Train_Num"
          + ", n.Train_Num_P, n.Train_Num_S"
          + ", m.Ms_Idn,m.St_Dest,m.Stt_TimeH,m.Stt_TimeM,m.Machinist,m.Wag_Coun,m.Nt_Weight,m.Gr_Weight"
          + ", h.St_Out_Zone,w.Bad_Code,h.Id_Wr_Prior,h.Id_Wr_Next,h.Norm_Idn,g.RO_Time,g.BZ_Time, m.Train_Attr"
          + " FROM TGraphicID g"
          + " LEFT OUTER JOIN TTrainHeaders h"
          + " ON g.Train_Idn = h.Train_Idn"
          + " LEFT OUTER JOIN TTrainNumbers n"
          + " ON h.Train_Idn = n.Train_Idn AND h.Train_Num = n.Train_Num"
          + " LEFT OUTER JOIN TTrainMessages m"
          + " ON g.Train_Idn = m.Train_Idn"
          + " LEFT OUTER JOIN TWorkMessages w"
          + " ON w.Ms_Idn = m.Ms_Idn"
          + " WHERE g.Train_Idn = @TrainId"
          + " AND g.Ev_Time = @EventTime";
        //Вектора обработки поездов
        private const string CommandText3 = "SELECT Ms_Type,Station,BO_Name,Train_Num_P,Train_Num,Train_Num_S"
          + ",Ne_Station,Remark,Ev_Time_S,Ev_Time_E"
          + " FROM TFormCont";
        //Актуальные поезда (с номерами)
        private const string CommandText4 = "SELECT DISTINCT  TTrainHeaders.Train_Idn, TTrainHeaders.Train_Num"
          + " FROM TTrainHeaders"
          + " INNER JOIN TGraphicID ON (TTrainHeaders.Train_Idn = TGraphicID.Train_Idn)"
          + " WHERE TTrainHeaders.Train_Num <>''"
          + " ORDER by TTrainHeaders.Train_Num";
        //Очистка таблицы актуальных справок до указанного времени
        private const string CommandText5 = "DELETE from TTrainMessages"
          + " WHERE Ms_Time < @msTime";
        //Актуальная справка для нитки поезда
        private const string CommandText6 = "SELECT Train_Idn, Ms_Idn, Ms_Time, Ms_Station, Train_Num, St_Form, Nm_Sost, St_Dest"
          + " FROM TTrainMessages"
          + " WHERE Train_Idn = @trnIdn";
        //События нитки поезда по станции
        private const string CommandText7 = "SELECT Ev_Type, Ev_Time, Ev_Axis"
          + " FROM TGraphicID"
          + " WHERE Train_Idn = @trnIdn AND Ev_Station = @evStat";
        //Запись новой актуальной справки
        private const string CommandText8 = "Insert Into TTrainMessages"
          + " (Train_Idn,Ms_Idn,Ms_Time,Ms_Station,Train_Num,St_Form,Nm_Sost,St_Dest"
          + ",Train_Attr,Loco_Series,Loco_Num"
          + ",Wag_Loaded,Wag_Empty,Wag_NoWork"
          + ",Operation,Flags"
          + ",Stt_TimeH,Stt_TimeM,Machinist,Wag_Coun,Nt_Weight,Gr_Weight)"
          + " Values(@TrainIdn,@MsIdn,@MsTime,@MsStation,@TrainNum,@StForm,@NmSost,@StDest"
          + ",@TrainAttr,@LocoSerie,@LocoNum"
          + ",@WagLoaded,@WagEmpty,@WagNoWork"
          + ",@Operation,@Flags"
          + ",@SttTimeH,@SttTimeM,@Machinist,@WagCoun,@NtWeight,@GrWeight)";
        //Корректировка актуальной справки нитки поезда
        private const string CommandText9 = "UPDATE TTrainMessages"
          + " SET Ms_Idn = @MsIdn,Ms_Time = @MsTime,Ms_Station = @MsStation"
          + ",Train_Num = @TrainNum,St_Form = @StForm,Nm_Sost = @NmSost,St_Dest = @StDest"
          + ",Train_Attr = @TrainAttr,Loco_Series = @LocoSerie,Loco_Num = @LocoNum"
          + ",Wag_Loaded = @WagLoaded,Wag_Empty = @WagEmpty,Wag_NoWork = @WagNoWork"
          + ",Operation = @Operation,Flags = @Flags"
          + ",Stt_TimeH = @SttTimeH,Stt_TimeM = @SttTimeM,Machinist = @Machinist,Wag_Coun = @WagCoun"
          + ",Nt_Weight = @NtWeight,Gr_Weight = @GrWeight"
          + " WHERE Train_Idn = @TrainIdn";
        //Состояния пути станции после указанного времени
        private const string CommandText10 = "SELECT Ms_Type"
          + " FROM TTrackCont"
          + " WHERE Station = @Stat AND BO_Name = @Track AND Ev_Time > @Time AND (Ms_Type = 5 OR Ms_Type = 6)";
        //История справок (за последние 12 часов)
        private const string CommandText11 = "SELECT Ms_Idn,Ms_Time,Ms_Station,Train_Idn,Train_Num"
          + ",Wr_Stt_Time,Wr_Stp_Time,St_Form,Nm_Sost,St_Dest,Ms_Prop"
          + ",Stt_TimeH,Stt_TimeM,Machinist,Wag_Coun,Nt_Weight,Gr_Weight,Ms_Marker,Bad_Code"
          + ",Loco_Series,Loco_Num,Train_Attr"
          + ",Wag_Loaded,Wag_Empty,Wag_NoWork"
          + ",Operation,Flags"
          + " FROM TWorkMessages"
          + " ORDER by Ms_Idn DESC";
        //Очистка таблицы истории справок до указанного времени
        private const string CommandText12 = "DELETE from TWorkMessages"
          + " WHERE Ms_Time <= @msTime";
        //Записать новую справку в историю
        private const string CommandText13 = "Insert Into TWorkMessages"
          + " (Ms_Idn,Ms_Time,Ms_Station,Train_Num,St_Form,Nm_Sost,St_Dest"
          + ",Train_Attr,Loco_Series,Loco_Num"
          + ",Wag_Loaded,Wag_Empty,Wag_NoWork"
          + ",Operation,Flags"
          + ",Stt_TimeH,Stt_TimeM,Machinist,Wag_Coun,Nt_Weight,Gr_Weight,Bad_Code)"
          + " Values(@MsIdn,@MsTime,@MsStation,@TrainNum,@StForm,@NmSost,@StDest"
          + ",@TrainAttr,@LocoSerie,@LocoNum"
          + ",@WagLoaded,@WagEmpty,@WagNoWork"
          + ",@Operation,@Flags"
          + ",@SttTimeH,@SttTimeM,@Machinist,@WagCoun,@NtWeight,@GrWeight,@BadCode)";
        //Справки из истории для обработки
        private const string CommandText14 = "SELECT Ms_Idn,Ms_Time,Ms_Station,Train_Idn,Train_Num"
          + ",Wr_Stt_Time,Wr_Stp_Time,St_Form,Nm_Sost,St_Dest"
          + " FROM TWorkMessages"
          + " WHERE Wr_Stt_Time IS NULL OR Wr_Stp_Time IS NULL"
          + " ORDER by Ms_Time,Ms_Idn";
        //Актуальная справка по идентификатору
        private const string CommandText15 = "SELECT Train_Idn, Ms_Idn, Ms_Time, Ms_Station, Train_Num, St_Form, Nm_Sost, St_Dest"
          + " FROM TTrainMessages"
          + " WHERE Ms_Idn = @MsIdn";
        //
        private const string CommandText16 = "UPDATE TWorkMessages"
          + " SET Wr_Stp_Time = @MsTime"
          + " WHERE Ms_Idn = @MsIdn";
        //
        private const string CommandText17 = "UPDATE TWorkMessages"
          + " SET Wr_Stt_Time = @MsTime,Train_Idn = @TrainIdn"
          + " WHERE Ms_Idn = @MsIdn";
        //
        private const string CommandText18 = "SELECT Ms_Idn,Ms_Time,Train_Num,Ms_Station"
          + " FROM TWorkMessages"
          + " WHERE Tm_Lst_Ev IS NULL"
          + " ORDER by Ms_Time,Ms_Idn";
        //
        private const string CommandText19 = "SELECT Train_Idn"
          + " FROM TTrainNumbers"
          + " WHERE Train_Num = @TrainNum"
          + " ORDER by Ev_Time DESC";
        //Дать время событий поезда по станции, начиная с последнего
        private const string CommandText20 = "SELECT Ev_Time"
          + " FROM TGraphicID"
          + " WHERE Train_Idn = @TrainIdn AND Ev_Station = @Station"
          + " ORDER by Ev_Time DESC";
        //Указать время ближайшего события для справки
        private const string CommandText21 = "UPDATE TWorkMessages"
          + " SET Tm_Lst_Ev = @TimeSp"
          + " WHERE Ms_Idn = @MsIdn";
        //Дать связанные неостановленные справки
        private const string CommandText22 = "SELECT Ms_Time,St_Form,Nm_Sost,Ms_Idn"
          + " FROM TWorkMessages"
          + " WHERE Wr_Stt_Time IS NOT NULL AND Wr_Stp_Time IS NULL"
          + " ORDER by Ms_Time,Ms_Idn";
        //Установить флаг остановки действия для справок до указанного времени
        private const string CommandText23 = "UPDATE TWorkMessages"
          + " SET Wr_Stp_Time = @StopTime"
          + " WHERE Wr_Stp_Time IS NULL AND Ms_Time <= @MsTime AND St_Form = @Station AND Nm_Sost = @NmSost AND Ms_Idn < @MsIdn";
        //Связать две нитки
        private const string CommandText24 = "UPDATE TGraphicID"
          + " SET Train_Idn = @TrIdnT,Ev_Flag = 0"
          + " WHERE Train_Idn = @TrIdnS";
        //Записать команду для ГИДа
        private const string CommandText25 = "EXECUTE PROCEDURE ADD_NEW_Command"
          + " @Command,@COM_TIME"
          + ",@Train_IdnH1,@NORM_IDNH1,@Train_NumH1,@I_ST_FORMH1,@I_ST_DESTH1,@I_SOST_NUMH1"
          + ",@DOP_PROPH1,@REZERVH1,@ST_IN_ZONEH1,@ST_OUT_ZONEH1"
          + ",@Train_IdnH2,@NORM_IDNH2,@Train_NumH2,@I_ST_FORMH2,@I_ST_DESTH2,@I_SOST_NUMH2"
          + ",@DOP_PROPH2,@REZERVH2,@ST_IN_ZONEH2,@ST_OUT_ZONEH2"
          + ",@TRAIN_IDNE1,@EV_TYPEE1,@EV_TIMEE1,@Ev_StationE1,@EV_AXISE1,@Ev_NDOE1,@EV_NE_STATIONE1,@EV_REC_IDNE1,@EV_FLAGE1"
          + ",@TRAIN_IDNE2,@EV_TYPEE2,@EV_TIMEE2,@Ev_StationE2,@EV_AXISE2,@Ev_NDOE2,@EV_NE_STATIONE2,@EV_REC_IDNE2,@EV_FLAGE2";
        //Справки из истории
        private const string CommandText26 = "SELECT Ms_Idn,Ms_Time,Ms_Station,Train_Idn,Train_Num"
          + ",Wr_Stt_Time,Wr_Stp_Time,St_Form,Nm_Sost,St_Dest,Ms_Idn_Prev,Ms_Prop,Com_Cng_Num,Com_Cng_Wir,Wir_Idn_Prev"
          + " FROM TWorkMessages"
          + " ORDER by St_Form,Nm_Sost,Ms_Time,Ms_Idn";
        //
        private const string CommandText27 = "UPDATE TWorkMessages"
          + " SET Ms_Prop = 0";
        //
        private const string CommandText28 = "UPDATE TWorkMessages"
          + " SET Ms_Idn_Prev = @MsIdnP,Ms_Prop = @MsProp,Wir_Idn_Prev = @WrIdnP,Com_Cng_Num = @CmCngN,Com_Cng_Wir = @CmCngW"
          + " WHERE Ms_Idn = @MsIdn";
        //
        private const string CommandText29 = "SELECT Ms_Idn,Train_Idn,Wir_Idn_Prev"
        + " FROM TWorkMessages"
        + " WHERE Com_Cng_Wir = 1";
        //
        private const string CommandText30 = "UPDATE TWorkMessages"
          + " SET Ms_Prop = @MsProp"
          + " WHERE Ms_Idn = @MsIdn";
        //
        private const string CommandText31 = "UPDATE TTrainNumbers"
          + " SET Train_Idn = @TrIdnT,Fl_Arch = 0"
          + " WHERE Train_Idn = @TrIdnS";
        //
        private const string CommandText32 = "UPDATE TWorkMessages"
          + " SET Train_Idn = @TrIdnT"
          + " WHERE Train_Idn = @TrIdnS";
        //
        private const string CommandText33 = "SELECT Ms_Idn,Train_Idn,Wir_Idn_Prev,Train_Num,Ms_Station"
        + " FROM TWorkMessages"
        + " WHERE Com_Cng_Num = 1"
        + " ORDER by Ms_Time";
        //
        private const string CommandText34 = "UPDATE TWorkMessages"
          + " SET Com_Cng_Wir = @CmCngW"
          + " WHERE Com_Cng_Wir = 1";
        //
        private const string CommandText35 = "UPDATE TWorkMessages"
          + " SET Com_Cng_Num = @CmCngN"
          + " WHERE Com_Cng_Num = 1";
        //Дать время последнего события по поезду
        private const string CommandText36 = "SELECT TG.Train_Idn, MAX(TG.Ev_Time)"
        + " FROM TGraphicID TG"
        + " WHERE TG.Train_Idn = @TrainIdn"
        + " GROUP BY TG.Train_Idn";
        //Дать время первого события по поезду
        private const string CommandText37 = "SELECT TG.Train_Idn, MIN(TG.Ev_Time)"
        + " FROM TGraphicID TG"
        + " WHERE TG.Train_Idn = @TrainIdn"
        + " GROUP BY TG.Train_Idn";
        //События нитки поезда, начиная с последнего
        private const string CommandText38 = "SELECT Ev_Type, Ev_Time, Ev_Station, Ev_Axis,Ev_Rec_Idn"
          + " FROM TGraphicID"
          + " WHERE Train_Idn = @TrainIdn"
          + " ORDER BY Ev_Time DESC";
        //Дать все состояния пути станции после указанного времени
        private const string CommandText39 = "SELECT Ev_Time,Ms_Type,BO_Name"
          + " FROM TTrackCont"
          + " WHERE Station = @Station AND BO_Name Like @Track AND Ev_Time > @Time"
          + " AND (Ms_Type = 4 OR Ms_Type = 5 OR Ms_Type = 6)"
          + " ORDER BY Ev_Time";
        //Дать все состояния пути станции до указанного времени
        private const string CommandText40 = "SELECT Ev_Time,Ms_Type,BO_Name"
          + " FROM TTrackCont"
          + " WHERE Station = @Station AND BO_Name Like @Track AND Ev_Time < @Time"
          + " AND (Ms_Type = 4 OR Ms_Type = 5 OR Ms_Type = 6)"
          + " ORDER BY Ev_Time DESC";
        //Добавить сообщение в ГИД
        private const string CommandText41 = "EXECUTE PROCEDURE ADD_NEW_Message"
          + " @SM_Station,@Ms_Type,@Ev_Time,@Ms_Time,@BO_Type,@BO_Name,@DO_Type,@DO_Name,@Dop_Idn";
        //Удалить актуальные справки на поезда, у которых нет событий в ГИДе
        private const string CommandText42 = "DELETE FROM TTrainMessages"
          + " WHERE TTrainMessages.Train_Idn NOT IN"
          + " ("
          + "SELECT Distinct TTrainMessages.Train_Idn FROM TTrainMessages"
          + " INNER JOIN TGraphicid"
          + " ON (TTrainMessages.Train_Idn = TGraphicID.Train_Idn)"
          + ")";
        //Определить ось события
        private const string CommandText43 = "UPDATE TGraphicID"
          + " SET Ev_Axis = @Track,Ev_Time = @Time,Ev_Flag = 0"
          + " WHERE Ev_Rec_Idn = @EvIdn";
        //Записать маркер для нитки
        private const string CommandText44 = "UPDATE TTrainHeaders"
          + " SET St_Out_Zone = @Marker"
          + " WHERE Train_Idn = @TrainIdn";
        //Записать маркер для справки
        private const string CommandText45 = "UPDATE TWorkMessages"
          + " SET Ms_Marker = @Marker"
          + " WHERE Ms_Idn = @MessIdn";
        //Удалить актуальную справку для поезда
        private const string CommandText46 = "DELETE FROM TTrainMessages"
          + " WHERE TTrainMessages.Train_Idn = @TrainIdn";
        //Сбросить флаги справок для поезда (отвязать)
        private const string CommandText47 = "UPDATE TWorkMessages"
          + " SET Wr_Stt_Time = NULL,Wr_Stp_Time = NULL,Train_Idn = NULL"
          + " WHERE Train_Idn = @TrainIdn";
        //Дать справку по идентификатору
        private const string CommandText48 = "SELECT Ms_Idn,Ms_Time,Ms_Station,Train_Idn,Train_Num"
          + ",Wr_Stt_Time,Wr_Stp_Time,St_Form,Nm_Sost,St_Dest,Ms_Prop"
          + ",Stt_TimeH,Stt_TimeM,Machinist,Wag_Coun,Nt_Weight,Gr_Weight,Ms_Marker"
          + ",Train_Attr,Loco_Series,Loco_Num"
          + ",Wag_Loaded,Wag_Empty,Wag_NoWork"
          + ",Operation,Flags"
          + " FROM TWorkMessages"
          + " WHERE Ms_Idn = @MessIdn";
        //Дать заголовок нитки поезда
        private const string CommandText49 = "SELECT Train_Num,Norm_Idn"
          + " FROM TTrainHeaders"
          + " WHERE Train_Idn = @TrainIdn";
        //Дать состояния блок-участка до указанного времени
        private const string CommandText50 = "SELECT Ev_Time,Ms_Type,BO_Name"
          + " FROM TTrackCont"
          + " WHERE Station = @Station AND BO_Name = @Track AND Ev_Time < @Time"
          + " AND (Ms_Type = 13 OR Ms_Type = 14 OR Ms_Type = 15)"
          + " ORDER BY Ev_Time DESC";
        //Дать время первого события ГИДа
        private const string CommandText51 = "SELECT MIN(TG.Ev_Time)"
          + " FROM TGraphicID TG";
        //Дать время последнего события ГИДа
        private const string CommandText52 = "SELECT MAX(TG.Ev_Time)"
          //  + " FROM TTrackCont TG";
          + " FROM TGraphicID TG";
        //Дать ниразу несвязанные актуальные сообщения
        private const string CommandText53 = "SELECT Ms_Idn,St_Form,Nm_Sost,St_Dest"
          + " FROM TWorkMessages"
          + " WHERE Train_Idn IS NULL AND Ms_Prop = 1"
          + " ORDER by Ms_Time";
        //Вернуть нитку из заголовка с указанным индексом
        private const string CommandText54 = "SELECT Train_Idn"
          + " FROM TTrainHeaders"
          + " WHERE I_St_Form = @StForm AND I_Sost_Num = @SstNum AND I_St_Dest = @StDest";
        //Очистка таблицы сообщений ГИДа
        private const string CommandText55 = "DELETE from TGIDMessages"
          + " WHERE Ms_Time <= @msTime";
        //Вернуть все сообщения ГИД
        private const string CommandText56 = "SELECT Ms_Idn,Ms_Type,Ms_Time,Ms_Station"
          + ",Train_Num,Ms_Axis,NE_Station,Ms_Flags"
          + " FROM TGIDMessages"
          + " ORDER by Ms_Time";
        //Вернуть (фактически последнее) сообщение ГИД
        private const string CommandText57 = "SELECT Ms_Idn,Ms_Time"
          + " FROM TGIDMessages"
          + " ORDER by Ms_Time DESC";
        //Вернуть внешние прибытия и отпраления для нитки по станции после указанного времени
        private const string CommandText58 = "SELECT Ev_Type,Ev_Time,Ev_Station,ev_Axis,Ev_Ne_Station"
          + " ,Ev_Rec_Idn"
          + " FROM TGraphicID"
          + " WHERE Train_Idn = @TrainIdn AND Ev_Time > @EvTime AND Ev_Station <> Ev_Ne_Station"
          + " ORDER by Ev_Time";
        //Запись сообщения ГИД
        private const string CommandText59 = "Insert Into TGIDMessages"
          + " (Ms_Idn,Ms_Type,Ms_Time,Ms_Station,Train_Num,Ms_Axis,Ne_Station,Ms_Flags)"
          + " Values(@MsIdn,@MsType,@MsTime,@MsStat,@TrainNum,@MsAxis,@NeStat,@MsFlags)";
        //Вернуть параметры сообщения (флаги)
        private const string CommandText60 = "SELECT Ms_Flags"
          + " FROM TGIDMessages"
          + " WHERE Ms_Idn = @MsIdn";
        //Установка флагов сообщения
        private const string CommandText61 = "UPDATE TGIDMessages"
          + " SET Ms_Flags = @MsFlags"
          + " WHERE Ms_Idn = @MsIdn";
        //Удалить события плановой нитки
        private const string CommandText62 = "DELETE FROM TGraphicPl"
          + " WHERE Train_Idn = @TrainIdn";
        //Установить (сбросить) ссылку на плановую нитку
        private const string CommandText63 = "UPDATE TTrainHeaders"
          + " SET Norm_Idn = @NormIdn"
          + " WHERE Train_Idn = @TrainIdn";
        //Создать заголовок нитки (поезда)
        private const string CommandText64 = "EXECUTE PROCEDURE ADD_NEW_TrainHeader"
          + " @Norm_Idn,@Train_Num,@I_St_Form,@I_St_Dest,@I_Sost_Num"
          + ",@Dop_Prop,@Rezerv,@St_In_Zone,@St_Out_Zone,@Id_Wr_Next,@Id_Wr_Prior,@Fl_NoDel";
        //Установить флаг состояния нитки (плановой)
        private const string CommandText65 = "UPDATE TTrainHeaders"
          + " SET Fl_Sost = @FlSost"
          + " WHERE Train_Idn = @TrainIdn";
        //Запись события плановой нитки
        private const string CommandText66 = "Insert Into TGraphicPl"
          + " (Train_Idn,Ev_Type,Ev_Time,Ev_Time_P,Ev_Station,Ev_Axis,Ev_NDO,Coll_St,Ev_NE_Station)"
          + " Values(@TrainIdn,@EvType,@EvTime,@EvTimeP,@EvStation,@EvAxis,@EvNDO,@Coll_St,@NEStation)";
        //Записать флаг передачи задания на исполнение
        private const string CommandText67 = "UPDATE TComDefinitions"
          + " SET Fl_Snd = @FlSnd,Tm_Def_Creat = @TmDefC"
          + " WHERE Def_Idn = @DefIdn";
        //Получить задания на команды с указанными флагами
        private const string CommandText68 = "SELECT Def_Idn,St_Code,Tr_Num"
          + ",Ob_Stt_Type,Ob_Stt_Name,Ob_End_Type,Ob_End_Name"
          + ",Lnk_Def_Idn_N,Lnk_Def_Idn_E,Tm_Def_Start,Stay_Fnd,Ev_Idn_Pln"
          + " FROM TComDefinitions"
          + " WHERE Std_Form = @StdForm AND Fl_Snd = @FlSnd";
        //Получить задание по идентификатору
        private const string CommandText69 = "SELECT Std_Form,Ev_Idn_Pln,Tm_Def_Start,Fl_Snd"
          + " FROM TComDefinitions"
          + " WHERE Def_Idn = @DefIdn";
        //Получить плановое событие по идентификатору
        private const string CommandText70 = "SELECT Ev_Cnfm,Ev_Time,Coll_St,Coll_Sp,Train_Idn"
          + " FROM TGraphicPl"
          + " WHERE Ev_Rec_Idn = @PlEvIdn";
        //Получить плановые события до указанного (немного перебор)
        private const string CommandText71 = "SELECT p1.Ev_Type,p1.Ev_Station,p1.Ev_NDO"
          + ",p1.Ev_Rec_Idn"
          + " FROM TGraphicPl p1"
          + " WHERE p1.Train_Idn ="
          + " (SELECT p2.Train_Idn FROM TGraphicPl p2 WHERE p2.Ev_Rec_Idn = @PlEvIdn)"
          + " AND p1.Ev_Time_P <"
          + " (SELECT p3.Ev_Time_P FROM TGraphicPl p3 WHERE p3.Ev_Rec_Idn = @PlEvIdn)"
          + " ORDER BY p1.Ev_Rec_Idn DESC";
        //Получить плановые события после указанного
        private const string CommandText72 = "SELECT p1.Ev_Type,p1.Ev_Station,p1.Ev_NDO"
          + ",p1.Ev_Rec_Idn"
          + " FROM TGraphicPl p1"
          + " WHERE p1.Train_Idn ="
          + " (SELECT p2.Train_Idn FROM TGraphicPl p2 WHERE p2.Ev_Rec_Idn = @PlEvIdn)"
          + " AND p1.Ev_Time_P >"
          + " (SELECT p3.Ev_Time_P FROM TGraphicPl p3 WHERE p3.Ev_Rec_Idn = @PlEvIdn)"
          + " ORDER BY p1.Ev_Rec_Idn";
        //Получить задание на указанное плановое событие
        private const string CommandText73 = "SELECT Std_Form,Ev_Idn_Pln,Tm_Def_Start,Fl_Snd"
          + " FROM TComDefinitions"
          + " WHERE Ev_Idn_Pln = @PlnIdn";
        //Получить время первой коллизии по поезду (в принципе всех коллизий)
        private const string CommandText74 = "SELECT Ev_Time"
          + " FROM TGraphicPl"
          + " WHERE Train_Idn = @TrainIdn AND (Coll_St > 0 OR Coll_Sp > 0)"
          + " ORDER by Ev_Time";
        //
        private const string CommandText75 = "SELECT QueryXml"
          + " FROM Wagons266"
          + " WHERE Flags = @Flags";
        //
        private const string CommandText76 = "UPDATE Wagons266"
          + " SET Flags = @FlagsN"
          + " WHERE Flags = @FlagsO";
        //
        private const string CommandText77 = "INSERT INTO Replys"
          + " (ReplyText)"
          + " VALUES (@ReplyText)";
        //
        private const string CommandText78 = "SELECT QueryXml"
          + " FROM Capters266"
          + " WHERE Flags = @Flags";
        //
        private const string CommandText79 = "UPDATE Capters266"
          + " SET Flags = @FlagsN"
          + " WHERE Flags = @FlagsO";
        //
        private const string CommandText80 = "SELECT MessIdn,MessTime,Destination"
          + ",TrainIndex,TrainNumber"
          + ",LocoSeries,LocoNumber,Category"
          + " FROM Capters266"
          + " WHERE TrainNumber IS NOT NULL"// AND Category IS NOT NULL"
          + " AND MessTime > @MessTmStt AND MessTime < @MessTmStp"
          + " AND Station = @Station AND NsuNumber = @NsuNumber"
          + " ORDER BY MessTime";
        //
        private const string CommandText81 = "INSERT INTO Capters266"
          + " (MessIdn,Station,NsuNumber,MessTime,Destination,LocoSeries,LocoNumber)"
          + " VALUES (@MessIdn,@Station,@NsuNumber,@MessTime,@Destination,@LocoSeries,@LocoNumber)";
        //
        private const string CommandText82 = "INSERT INTO Wagons266"
          + " (MessIdn,TrainIndex,TrainNumber,Flags,OrdNumber,InvNumber)"
          + " VALUES (@MessIdn,@TrainIndex,@TrainNumber,@Flags,'-1','1234')";
        //Получить задания на команды с указанными флагами
        private const string CommandText83 = "SELECT Def_Idn,St_Code,Tr_Num"
          + ",Ob_Stt_Type,Ob_Stt_Name,Ob_End_Type,Ob_End_Name"
          + ",Lnk_Def_Idn_N,Lnk_Def_Idn_E,Tm_Def_Start,Stay_Fnd,Ev_Idn_Pln"
          + " FROM TComDefinitions"
          + " WHERE Fl_Snd <> 4";
        //
        //Получить расписание плановой нитки
        private const string CommandText84 = "SELECT  Ev_Type, Ev_Time_P, Ev_Station, Ev_Rec_Idn, EV_CNFM"
          + " FROM TGraphicPl"
          + " WHERE Train_Idn = @TrainIdn"
          + " ORDER by Ev_Rec_Idn";
        //Получить события по плановым ниткам
        private const string CommandText85 = "SELECT TTrainHeaders.Fl_Sost, TGraphicPl.Train_Idn, TGraphicPl.Ev_Station, TGraphicPl.Ev_Time From TGraphicPl, TTrainHeaders,"
            + " (SELECT  Pl.Train_Idn, MIN(Ev_Rec_Idn) as Ev_Rec_Idn From TGraphicPl Pl,"
            + " (SELECT Train_Idn, Fl_Sost FROM TTrainHeaders WHERE Train_Num = @TrainNumber AND Norm_Idn IS NULL AND Fl_Sost IS NOT NULL) TH"
            + " WHERE TH.Train_Idn = Pl.Train_Idn AND Pl.Ev_Station in (@Stations) GROUP BY Pl.Train_Idn) bufferTable"
            + " WHERE  TGraphicPl.Ev_Rec_Idn = bufferTable.Ev_Rec_Idn And TTrainHeaders.Train_Idn = bufferTable.Train_Idn";
        //Получить id исполненной нитки по id плановой нитки
        private const string CommandText86 = "SELECT Train_Idn"
        + " FROM TTrainHeaders"
        + " WHERE Norm_Idn = @TrainIdn";
        //Удалить не переданные команды
        private const string CommandText87 = "DELETE FROM TCOMDEFINITIONS WHERE Fl_Snd != 4";
        //Cбросить ссылки на все плановые нитки
        private const string CommandText88 = "UPDATE TTrainHeaders"
          + " SET Norm_Idn = 0"
          + " WHERE Norm_Idn in (SELECT Train_Idn From TGraphicPl GROUP BY Train_Idn)";
        //Удалить плановые нитки
        private const string CommandText89 = "DELETE FROM TGraphicPl";
        //Сбросить ссылку на плановую нитку
        private const string CommandText90 = "UPDATE TTrainHeaders"
          + " SET Norm_Idn = 0"
          + " WHERE Norm_Idn = @TrainIdn";
        //Конструктор----------------------------------------------------------------------------------
        public GidRepository(string connectionString, bool flPlay
                        , int deltaTimeStart, int deltaTimeStop
                        , string connectionStringBuh
                        , BuhSection[] buhSections)
        {
            _connectionString = connectionString;
            _flPlay = flPlay;
            _deltaTimeStart = deltaTimeStart;
            _deltaTimeStop = deltaTimeStop;
            _connectionStringBuh = connectionStringBuh;
            _buhSections = buhSections;
            //Создаем команды (с текстами)
            //_command1  = new FbCommand(CommandText1);
            //_command2  = new FbCommand(CommandText2);
            //_command3  = new FbCommand(CommandText3);
            _command4 = new FbCommand(CommandText4);
            _command5 = new FbCommand(CommandText5);
            //_command6  = new FbCommand(CommandText6);
            _command7 = new FbCommand(CommandText7);
            //_command8  = new FbCommand(CommandText8);
            //_command9  = new FbCommand(CommandText9);
            //_command10 = new FbCommand(CommandText10);
            //_command11 = new FbCommand(CommandText11);
            _command12 = new FbCommand(CommandText12);
            _command13 = new FbCommand(CommandText13);
            _command14 = new FbCommand(CommandText14);
            _command15 = new FbCommand(CommandText15);
            _command16 = new FbCommand(CommandText16);
            _command17 = new FbCommand(CommandText17);
            _command18 = new FbCommand(CommandText18);
            _command19 = new FbCommand(CommandText19);
            _command20 = new FbCommand(CommandText20);
            _command21 = new FbCommand(CommandText21);
            _command22 = new FbCommand(CommandText22);
            _command23 = new FbCommand(CommandText23);
            //_command24 = new FbCommand(CommandText24);
            //_command25 = new FbCommand(CommandText25);
            _command26 = new FbCommand(CommandText26);
            _command27 = new FbCommand(CommandText27);
            _command28 = new FbCommand(CommandText28);
            _command29 = new FbCommand(CommandText29);
            _command30 = new FbCommand(CommandText30);
            //_command31 = new FbCommand(CommandText31);
            //   _command32 = new FbCommand(CommandText32);
            _command33 = new FbCommand(CommandText33);
            _command34 = new FbCommand(CommandText34);
            _command35 = new FbCommand(CommandText35);
            //_command36 = new FbCommand(CommandText36);
            //_command37 = new FbCommand(CommandText37);
            //_command38 = new FbCommand(CommandText38);
            //_command39 = new FbCommand(CommandText39);
            //_command40 = new FbCommand(CommandText40);
            //_command41 = new FbCommand(CommandText41);
            _command42 = new FbCommand(CommandText42);
            //_command43 = new FbCommand(CommandText43);
            //_command44 = new FbCommand(CommandText44);
            //_command45 = new FbCommand(CommandText45);
            //_command46 = new FbCommand(CommandText46);
            //_command47 = new FbCommand(CommandText47);
            //_command48 = new FbCommand(CommandText48);
            // _command49 = new FbCommand(CommandText49);
            //_command50 = new FbCommand(CommandText50);
            _command51 = new FbCommand(CommandText51);
            //_command52 = new FbCommand(CommandText52);
            _command53 = new FbCommand(CommandText53);
            _command54 = new FbCommand(CommandText54);
            _command55 = new FbCommand(CommandText55);
            _command56 = new FbCommand(CommandText56);
            _command57 = new FbCommand(CommandText57);
            _command58 = new FbCommand(CommandText58);
            _command59 = new FbCommand(CommandText59);
            _command60 = new FbCommand(CommandText60);
            _command61 = new FbCommand(CommandText61);
            //_command62 = new FbCommand(CommandText62);
            //_command63 = new FbCommand(CommandText63);
            //_command64 = new FbCommand(CommandText64);
            //_command65 = new FbCommand(CommandText65);
            //_command66 = new FbCommand(CommandText66);
            //_command67 = new FbCommand(CommandText67);
            // _command68 = new FbCommand(CommandText68);
            _command69 = new FbCommand(CommandText69);
            //_command70 = new FbCommand(CommandText70);
            _command71 = new FbCommand(CommandText71);
            _command72 = new FbCommand(CommandText72);
            _command73 = new FbCommand(CommandText73);
            _command74 = new FbCommand(CommandText74);
            _command75 = new SqlCommand(CommandText75);
            _command76 = new SqlCommand(CommandText76);
            //_command77 = new SqlCommand(CommandText77);
            _command78 = new SqlCommand(CommandText78);
            _command79 = new SqlCommand(CommandText79);
            //_command80 = new SqlCommand(CommandText80);
            //_command81 = new SqlCommand(CommandText81);
            //_command82 = new SqlCommand(CommandText82);
            //_command83 = new FbCommand(CommandText83);
            //Создаем параметры
            _parEvTime1 = new FbParameter("@EvTime", FbDbType.TimeStamp);
            _parTrainId2 = new FbParameter("@TrainId", FbDbType.Integer);
            _parEventTime2 = new FbParameter("@EventTime", FbDbType.TimeStamp);
            _parMessTime5 = new FbParameter("@msTime", FbDbType.TimeStamp);
            _parTrnIdn6 = new FbParameter("@trnIdn", FbDbType.Integer);
            _parTrnIdn7 = new FbParameter("@trnIdn", FbDbType.Integer);
            _parEvStat7 = new FbParameter("@evStat", FbDbType.VarChar);
            _parTrainIdn8 = new FbParameter("@TrainIdn", FbDbType.Integer);
            _parMsIdn8 = new FbParameter("@MsIdn", FbDbType.BigInt);// .Integer);
            _parMsTime8 = new FbParameter("@MsTime", FbDbType.TimeStamp);
            _parMsStation8 = new FbParameter("@MsStation", FbDbType.VarChar);
            _parOperation8 = new FbParameter("@Operation", FbDbType.VarChar);
            _parFlags8 = new FbParameter("@Flags", FbDbType.VarChar);
            _parTrainNum8 = new FbParameter("@TrainNum", FbDbType.VarChar);
            _parStForm8 = new FbParameter("@StForm", FbDbType.VarChar);
            _parNmSost8 = new FbParameter("@NmSost", FbDbType.VarChar);
            _parStDest8 = new FbParameter("@StDest", FbDbType.VarChar);
            _parTrainAttr8 = new FbParameter("@TrainAttr", FbDbType.VarChar);
            _parLocoSerie8 = new FbParameter("@LocoSerie", FbDbType.VarChar);
            _parLocoNum8 = new FbParameter("@LocoNum", FbDbType.VarChar);
            _parSttTimeH8 = new FbParameter("@SttTimeH", FbDbType.Integer);
            _parSttTimeM8 = new FbParameter("@SttTimeM", FbDbType.Integer);
            _parMachinist8 = new FbParameter("@Machinist", FbDbType.VarChar);
            _parWagCoun8 = new FbParameter("@WagCoun", FbDbType.Integer);
            _parWagLoaded8 = new FbParameter("@WagLoaded", FbDbType.SmallInt);
            _parWagEmpty8 = new FbParameter("@WagEmpty", FbDbType.SmallInt);
            _parWagNoWork8 = new FbParameter("@WagNoWork", FbDbType.SmallInt);
            _parNtWeight8 = new FbParameter("@NtWeight", FbDbType.Integer);
            _parGrWeight8 = new FbParameter("@GrWeight", FbDbType.Integer);
            _parTrainIdn9 = new FbParameter("@TrainIdn", FbDbType.Integer);
            _parMsIdn9 = new FbParameter("@MsIdn", FbDbType.Integer);
            _parMsTime9 = new FbParameter("@MsTime", FbDbType.TimeStamp);
            _parMsStation9 = new FbParameter("@MsStation", FbDbType.VarChar);
            _parOperation9 = new FbParameter("@Operation", FbDbType.VarChar);
            _parFlags9 = new FbParameter("@Flags", FbDbType.VarChar);
            _parTrainNum9 = new FbParameter("@TrainNum", FbDbType.VarChar);
            _parStForm9 = new FbParameter("@StForm", FbDbType.VarChar);
            _parNmSost9 = new FbParameter("@NmSost", FbDbType.VarChar);
            _parStDest9 = new FbParameter("@StDest", FbDbType.VarChar);
            _parTrainAttr9 = new FbParameter("@TrainAttr", FbDbType.VarChar);
            _parLocoSerie9 = new FbParameter("@LocoSerie", FbDbType.VarChar);
            _parLocoNum9 = new FbParameter("@LocoNum", FbDbType.VarChar);
            _parSttTimeH9 = new FbParameter("@SttTimeH", FbDbType.Integer);
            _parSttTimeM9 = new FbParameter("@SttTimeM", FbDbType.Integer);
            _parMachinist9 = new FbParameter("@Machinist", FbDbType.VarChar);
            _parWagCoun9 = new FbParameter("@WagCoun", FbDbType.Integer);
            _parWagLoaded9 = new FbParameter("@WagLoaded", FbDbType.SmallInt);
            _parWagEmpty9 = new FbParameter("@WagEmpty", FbDbType.SmallInt);
            _parWagNoWork9 = new FbParameter("@WagNoWork", FbDbType.SmallInt);
            _parNtWeight9 = new FbParameter("@NtWeight", FbDbType.Integer);
            _parGrWeight9 = new FbParameter("@GrWeight", FbDbType.Integer);
            _parStation10 = new FbParameter("@Stat", FbDbType.VarChar);
            _parTrack10 = new FbParameter("@Track", FbDbType.VarChar);
            _parTime10 = new FbParameter("@Time", FbDbType.TimeStamp);
            _parMessTime12 = new FbParameter("@msTime", FbDbType.TimeStamp);
            _parMsIdn13 = new FbParameter("@MsIdn", FbDbType.Integer);
            _parMsTime13 = new FbParameter("@MsTime", FbDbType.TimeStamp);
            _parMsStation13 = new FbParameter("@MsStation", FbDbType.VarChar);
            _parOperation13 = new FbParameter("@Operation", FbDbType.VarChar);
            _parFlags13 = new FbParameter("@Flags", FbDbType.VarChar);
            _parTrainNum13 = new FbParameter("@TrainNum", FbDbType.VarChar);
            _parStForm13 = new FbParameter("@StForm", FbDbType.VarChar);
            _parNmSost13 = new FbParameter("@NmSost", FbDbType.VarChar);
            _parStDest13 = new FbParameter("@StDest", FbDbType.VarChar);
            _parTrainAttr13 = new FbParameter("@TrainAttr", FbDbType.VarChar);
            _parLocoSerie13 = new FbParameter("@LocoSerie", FbDbType.VarChar);
            _parLocoNum13 = new FbParameter("@LocoNum", FbDbType.VarChar);
            _parSttTimeH13 = new FbParameter("@SttTimeH", FbDbType.Integer);
            _parSttTimeM13 = new FbParameter("@SttTimeM", FbDbType.Integer);
            _parMachinist13 = new FbParameter("@Machinist", FbDbType.VarChar);
            _parWagCoun13 = new FbParameter("@WagCoun", FbDbType.Integer);
            _parWagLoaded13 = new FbParameter("@WagLoaded", FbDbType.SmallInt);
            _parWagEmpty13 = new FbParameter("@WagEmpty", FbDbType.SmallInt);
            _parWagNoWork13 = new FbParameter("@WagNoWork", FbDbType.SmallInt);
            _parNtWeight13 = new FbParameter("@NtWeight", FbDbType.Integer);
            _parGrWeight13 = new FbParameter("@GrWeight", FbDbType.Integer);
            _parBadCode13 = new FbParameter("@BadCode", FbDbType.VarChar);
            _parMsIdn15 = new FbParameter("@MsIdn", FbDbType.Integer);
            _parMsIdn16 = new FbParameter("@MsIdn", FbDbType.Integer);
            _parMessTime16 = new FbParameter("@MsTime", FbDbType.TimeStamp);
            _parMessTime17 = new FbParameter("@MsTime", FbDbType.TimeStamp);
            _parTrainIdn17 = new FbParameter("@TrainIdn", FbDbType.Integer);
            _parMsIdn17 = new FbParameter("@MsIdn", FbDbType.Integer);
            _parTrainNum19 = new FbParameter("@TrainNum", FbDbType.VarChar);
            _parTrainIdn20 = new FbParameter("@TrainIdn", FbDbType.Integer);
            _parStation20 = new FbParameter("@Station", FbDbType.VarChar);
            _parTimeSp21 = new FbParameter("@TimeSp", FbDbType.Integer);
            _parMessIdn21 = new FbParameter("@MsIdn", FbDbType.Integer);
            _parStopTime23 = new FbParameter("@StopTime", FbDbType.TimeStamp);
            _parMessTime23 = new FbParameter("@MsTime", FbDbType.TimeStamp);
            _parStation23 = new FbParameter("@Station", FbDbType.VarChar);
            _parNmSost23 = new FbParameter("@NmSost", FbDbType.VarChar);
            _parMsIdn23 = new FbParameter("@MsIdn", FbDbType.Integer);
            _parTrainIdnS24 = new FbParameter("@TrIdnS", FbDbType.Integer);
            _parTrainIdnT24 = new FbParameter("@TrIdnT", FbDbType.Integer);
            _parCommand25 = new FbParameter("@Command", FbDbType.Integer);
            _parCOM_TIME25 = new FbParameter("@COM_TIME", FbDbType.TimeStamp);
            _parTrain_IdnH125 = new FbParameter("@Train_IdnH1", FbDbType.Integer);
            _parNORM_IDNH125 = new FbParameter("@NORM_IDNH1", FbDbType.Integer);
            _parTrain_NumH125 = new FbParameter("@Train_NumH1", FbDbType.VarChar);
            _parI_ST_FORMH125 = new FbParameter("@I_ST_FORMH1", FbDbType.VarChar);
            _parI_ST_DESTH125 = new FbParameter("@I_ST_DESTH1", FbDbType.VarChar);
            _parI_SOST_NUMH125 = new FbParameter("@I_SOST_NUMH1", FbDbType.Integer);
            _parDOP_PROPH125 = new FbParameter("@DOP_PROPH1", FbDbType.VarChar);
            _parREZERVH125 = new FbParameter("@REZERVH1", FbDbType.Integer);
            _parST_IN_ZONEH125 = new FbParameter("@ST_IN_ZONEH1", FbDbType.VarChar);
            _parST_OUT_ZONEH125 = new FbParameter("@ST_OUT_ZONEH1", FbDbType.VarChar);
            _parTrain_IdnH225 = new FbParameter("@Train_IdnH2", FbDbType.Integer);
            _parNORM_IDNH225 = new FbParameter("@NORM_IDNH2", FbDbType.Integer);
            _parTrain_NumH225 = new FbParameter("@Train_NumH2", FbDbType.VarChar);
            _parI_ST_FORMH225 = new FbParameter("@I_ST_FORMH2", FbDbType.VarChar);
            _parI_ST_DESTH225 = new FbParameter("@I_ST_DESTH2", FbDbType.VarChar);
            _parI_SOST_NUMH225 = new FbParameter("@I_SOST_NUMH2", FbDbType.Integer);
            _parDOP_PROPH225 = new FbParameter("@DOP_PROPH2", FbDbType.VarChar);
            _parREZERVH225 = new FbParameter("@REZERVH2", FbDbType.Integer);
            _parST_IN_ZONEH225 = new FbParameter("@ST_IN_ZONEH2", FbDbType.VarChar);
            _parST_OUT_ZONEH225 = new FbParameter("@ST_OUT_ZONEH2", FbDbType.VarChar);
            _parTRAIN_IDNE125 = new FbParameter("@TRAIN_IDNE1", FbDbType.Integer);
            _parEV_TYPEE125 = new FbParameter("@EV_TYPEE1", FbDbType.Integer);
            _parEV_TIMEE125 = new FbParameter("@EV_TIMEE1", FbDbType.TimeStamp);
            _parEv_StationE125 = new FbParameter("@Ev_StationE1", FbDbType.VarChar);
            _parEV_AXISE125 = new FbParameter("@EV_AXISE1", FbDbType.VarChar);
            _parEv_NDOE125 = new FbParameter("@Ev_NDOE1", FbDbType.VarChar);
            _parEV_NE_STATIONE125 = new FbParameter("@EV_NE_STATIONE1", FbDbType.VarChar);
            _parEV_REC_IDNE125 = new FbParameter("@EV_REC_IDNE1", FbDbType.Integer);
            _parEV_FLAGE125 = new FbParameter("@EV_FLAGE1", FbDbType.Integer);
            _parTRAIN_IDNE225 = new FbParameter("@TRAIN_IDNE2", FbDbType.Integer);
            _parEV_TYPEE225 = new FbParameter("@EV_TYPEE2", FbDbType.Integer);
            _parEV_TIMEE225 = new FbParameter("@EV_TIMEE2", FbDbType.TimeStamp);
            _parEv_StationE225 = new FbParameter("@Ev_StationE2", FbDbType.VarChar);
            _parEV_AXISE225 = new FbParameter("@EV_AXISE2", FbDbType.VarChar);
            _parEv_NDOE225 = new FbParameter("@Ev_NDOE2", FbDbType.VarChar);
            _parEV_NE_STATIONE225 = new FbParameter("@EV_NE_STATIONE2", FbDbType.VarChar);
            _parEV_REC_IDNE225 = new FbParameter("@EV_REC_IDNE2", FbDbType.Integer);
            _parEV_FLAGE225 = new FbParameter("@EV_FLAGE2", FbDbType.Integer);
            _parMessIdn28 = new FbParameter("@MsIdn", FbDbType.Integer);
            _parMsIdnPrev28 = new FbParameter("@MsIdnP", FbDbType.Integer);
            _parMessProp28 = new FbParameter("@MsProp", FbDbType.Integer);
            _parWirIdnPrev28 = new FbParameter("@WrIdnP", FbDbType.Integer);
            _parComCngNum28 = new FbParameter("@CmCngN", FbDbType.Integer);
            _parComCngWir28 = new FbParameter("@CmCngW", FbDbType.Integer);
            _parMessIdn30 = new FbParameter("@MsIdn", FbDbType.Integer);
            _parMessProp30 = new FbParameter("@MsProp", FbDbType.Integer);
            _parTrainIdnS31 = new FbParameter("@TrIdnS", FbDbType.Integer);
            _parTrainIdnT31 = new FbParameter("@TrIdnT", FbDbType.Integer);
            _parTrainIdnS32 = new FbParameter("@TrIdnS", FbDbType.Integer);
            _parTrainIdnT32 = new FbParameter("@TrIdnT", FbDbType.Integer);
            _parComCngWir34 = new FbParameter("@CmCngW", FbDbType.Integer);
            _parComCngNum35 = new FbParameter("@CmCngN", FbDbType.Integer);
            _parTrainIdn36 = new FbParameter("@TrainIdn", FbDbType.Integer);
            _parTrainIdn37 = new FbParameter("@TrainIdn", FbDbType.Integer);
            _parTrainIdn38 = new FbParameter("@TrainIdn", FbDbType.Integer);
            _parStation39 = new FbParameter("@Station", FbDbType.VarChar);
            _parTrack39 = new FbParameter("@Track", FbDbType.VarChar);
            _parTime39 = new FbParameter("@Time", FbDbType.TimeStamp);
            _parStation40 = new FbParameter("@Station", FbDbType.VarChar);
            _parTrack40 = new FbParameter("@Track", FbDbType.VarChar);
            _parTime40 = new FbParameter("@Time", FbDbType.TimeStamp);
            _parSMStation41 = new FbParameter("@SM_Station", FbDbType.VarChar);
            _parMsType41 = new FbParameter("@Ms_Type", FbDbType.Integer);
            _parEvTime41 = new FbParameter("@Ev_Time", FbDbType.TimeStamp);
            _parMsTime41 = new FbParameter("@Ms_Time", FbDbType.TimeStamp);
            _parBOType41 = new FbParameter("@BO_Type", FbDbType.Integer);
            _parBOName41 = new FbParameter("@BO_Name", FbDbType.VarChar);
            _parDOType41 = new FbParameter("@DO_Type", FbDbType.Integer);
            _parDOName41 = new FbParameter("@DO_Name", FbDbType.VarChar);
            _parDopIdn41 = new FbParameter("@Dop_Idn", FbDbType.Integer);
            _parEvIdn43 = new FbParameter("@EvIdn", FbDbType.Integer);
            _parTrack43 = new FbParameter("@Track", FbDbType.VarChar);
            _parTime43 = new FbParameter("@Time", FbDbType.TimeStamp);
            _parTrainIdn44 = new FbParameter("@TrainIdn", FbDbType.Integer);
            _parMarker44 = new FbParameter("@Marker", FbDbType.VarChar);
            _parMessIdn45 = new FbParameter("@MessIdn", FbDbType.Integer);
            _parMarker45 = new FbParameter("@Marker", FbDbType.VarChar);
            _parTrainIdn46 = new FbParameter("@TrainIdn", FbDbType.Integer);
            _parTrainIdn47 = new FbParameter("@TrainIdn", FbDbType.Integer);
            _parMessIdn48 = new FbParameter("@MessIdn", FbDbType.Integer);
            _parTrainIdn49 = new FbParameter("@TrainIdn", FbDbType.Integer);
            _parStation50 = new FbParameter("@Station", FbDbType.VarChar);
            _parTrack50 = new FbParameter("@Track", FbDbType.VarChar);
            _parTime50 = new FbParameter("@Time", FbDbType.TimeStamp);
            _parStForm54 = new FbParameter("@StForm", FbDbType.VarChar);
            _parSstNum54 = new FbParameter("@SstNum", FbDbType.VarChar);
            _parStDest54 = new FbParameter("@StDest", FbDbType.VarChar);
            _parMessTime55 = new FbParameter("@msTime", FbDbType.TimeStamp);
            _parTrainIdn58 = new FbParameter("@TrainIdn", FbDbType.Integer);
            _parEvTime58 = new FbParameter("@EvTime", FbDbType.TimeStamp);
            _parMsIdn59 = new FbParameter("@MsIdn", FbDbType.Integer);
            _parMsType59 = new FbParameter("@MsType", FbDbType.Integer);
            _parMsTime59 = new FbParameter("@MsTime", FbDbType.TimeStamp);
            _parMsStat59 = new FbParameter("@MsStat", FbDbType.VarChar);
            _parTrainNum59 = new FbParameter("@TrainNum", FbDbType.VarChar);
            _parMsAxis59 = new FbParameter("@MsAxis", FbDbType.VarChar);
            _parNeStat59 = new FbParameter("@NeStat", FbDbType.VarChar);
            _parMsFlags59 = new FbParameter("@MsFlags", FbDbType.VarChar);
            _parMsIdn60 = new FbParameter("@MsIdn", FbDbType.Integer);
            _parMsIdn61 = new FbParameter("@MsIdn", FbDbType.Integer);
            _parMsFlags61 = new FbParameter("@MsFlags", FbDbType.VarChar);
            _parTrainIdn62 = new FbParameter("@TrainIdn", FbDbType.Integer);
            _parTrainIdn63 = new FbParameter("@TrainIdn", FbDbType.Integer);
            _parNormIdn63 = new FbParameter("@NormIdn", FbDbType.Integer);
            _parRecIdn64 = new FbParameter("@RecIdn", FbDbType.Integer);
            _parNormIdn64 = new FbParameter("@Norm_Idn", FbDbType.Integer);
            _parTrainNum64 = new FbParameter("@Train_Num", FbDbType.VarChar);
            _parStForm64 = new FbParameter("@I_St_Form", FbDbType.VarChar);
            _parStDest64 = new FbParameter("@I_St_Dest", FbDbType.VarChar);
            _parSostNum64 = new FbParameter("@I_Sost_Num", FbDbType.Integer);
            _parDopProp64 = new FbParameter("@Dop_Prop", FbDbType.VarChar);
            _parRezerv64 = new FbParameter("@Rezerv", FbDbType.Integer);
            _parInZone64 = new FbParameter("@St_In_Zone", FbDbType.VarChar);
            _parOutZone64 = new FbParameter("@St_Out_Zone", FbDbType.VarChar);
            _parWrNext64 = new FbParameter("@Id_Wr_Next", FbDbType.Integer);
            _parWrPrior64 = new FbParameter("@Id_Wr_Prior", FbDbType.Integer);
            _parFlNoDel64 = new FbParameter("@Fl_NoDel", FbDbType.Integer);
            _parTrainIdn65 = new FbParameter("@TrainIdn", FbDbType.Integer);
            _parFlSost65 = new FbParameter("@FlSost", FbDbType.Integer);
            _parTrainIdn66 = new FbParameter("@TrainIdn", FbDbType.Integer);
            _parEvType66 = new FbParameter("@EvType", FbDbType.Integer);
            _parEvTime66 = new FbParameter("@EvTime", FbDbType.TimeStamp);
            _parEvTimeP66 = new FbParameter("@EvTimeP", FbDbType.TimeStamp);
            _parEvStation66 = new FbParameter("@EvStation", FbDbType.VarChar);
            _parEvAxis66 = new FbParameter("@EvAxis", FbDbType.VarChar);
            _parEvNDO66 = new FbParameter("@EvNDO", FbDbType.VarChar);
            _parCollSt66 = new FbParameter("@Coll_St", FbDbType.Integer);
            _parNeStation66 = new FbParameter("@NEStation", FbDbType.VarChar);
            _parDefIdn67 = new FbParameter("@DefIdn", FbDbType.Integer);
            _parSndFlag67 = new FbParameter("@FlSnd", FbDbType.Integer);
            _parTmDefC67 = new FbParameter("@TmDefC", FbDbType.TimeStamp);
            _parStdForm68 = new FbParameter("@StdForm", FbDbType.Integer);
            _parSndFlag68 = new FbParameter("@FlSnd", FbDbType.Integer);
            _parDefIdn69 = new FbParameter("@DefIdn", FbDbType.Integer);
            _parPlnEvIdn70 = new FbParameter("@PlEvIdn", FbDbType.Integer);
            _parPlnEvIdn71 = new FbParameter("@PlEvIdn", FbDbType.Integer);
            _parPlnEvIdn72 = new FbParameter("@PlEvIdn", FbDbType.Integer);
            _parPlnIdn73 = new FbParameter("@PlnIdn", FbDbType.Integer);
            _parTrainIdn74 = new FbParameter("@TrainIdn", FbDbType.Integer);
            _parFlags75 = new SqlParameter("@Flags", SqlDbType.VarChar);
            _parFlagsO76 = new SqlParameter("@FlagsO", SqlDbType.VarChar);
            _parFlagsN76 = new SqlParameter("@FlagsN", SqlDbType.VarChar);
            _parReplyText77 = new SqlParameter("@ReplyText", SqlDbType.VarChar);
            _parFlags78 = new SqlParameter("@Flags", SqlDbType.VarChar);
            _parFlagsO79 = new SqlParameter("@FlagsO", SqlDbType.VarChar);
            _parFlagsN79 = new SqlParameter("@FlagsN", SqlDbType.VarChar);
            _parStation80 = new SqlParameter("@Station", SqlDbType.VarChar);
            _parNsuNumber80 = new SqlParameter("@NsuNumber", SqlDbType.SmallInt);
            _parMessTimeStt80 = new SqlParameter("@MessTmStt", SqlDbType.DateTime);
            _parMessTimeStp80 = new SqlParameter("@MessTmStp", SqlDbType.DateTime);
            _parMessIdn81 = new SqlParameter("@MessIdn", SqlDbType.Int);
            _parStation81 = new SqlParameter("@Station", SqlDbType.VarChar);
            _parNsuNumber81 = new SqlParameter("@NsuNumber", SqlDbType.SmallInt);
            _parMessTime81 = new SqlParameter("@MessTime", SqlDbType.DateTime);
            _parDestination81 = new SqlParameter("@Destination", SqlDbType.SmallInt);
            _parLocoSeries81 = new SqlParameter("@LocoSeries", SqlDbType.VarChar);
            _parLocoNumber81 = new SqlParameter("@LocoNumber", SqlDbType.VarChar);
            _parMessIdn82 = new SqlParameter("@MessIdn", SqlDbType.Int);
            _parTrainIndex82 = new SqlParameter("@TrainIndex", SqlDbType.VarChar);
            _parTrainNumber82 = new SqlParameter("@TrainNumber", SqlDbType.VarChar);
            _parFlags82 = new SqlParameter("@Flags", SqlDbType.VarChar);
            _parTrainIdn84 = new FbParameter("@TrainIdn", FbDbType.Integer);
            _parTrainNum85 = new FbParameter("@TrainNumber", FbDbType.Integer);
            _parTrainIdn86 = new FbParameter("@TrainIdn", FbDbType.Integer);
            _parTrainIdn90 = new FbParameter("@TrainIdn", FbDbType.Integer);
            //
            _parRecIdn64.Direction = ParameterDirection.Output;
            //Добавляем параметры в команду(ы)
            // _command1.Parameters.Add(_parEvTime1);
            //_command2.Parameters.Add(_parTrainId2);
            //_command2.Parameters.Add(_parEventTime2);
            _command5.Parameters.Add(_parMessTime5);
            //_command6.Parameters.Add(_parTrnIdn6);
            _command7.Parameters.Add(_parTrnIdn7);
            _command7.Parameters.Add(_parEvStat7);
            //_command8.Parameters.Add(_parTrainIdn8);
            //_command8.Parameters.Add(_parMsIdn8);
            //_command8.Parameters.Add(_parMsTime8);
            //_command8.Parameters.Add(_parMsStation8);
            //_command8.Parameters.Add(_parOperation8);
            //_command8.Parameters.Add(_parFlags8);
            //_command8.Parameters.Add(_parTrainNum8);
            //_command8.Parameters.Add(_parStForm8);
            //_command8.Parameters.Add(_parNmSost8);
            //_command8.Parameters.Add(_parStDest8);
            //_command8.Parameters.Add(_parTrainAttr8);
            //_command8.Parameters.Add(_parLocoSerie8);
            //_command8.Parameters.Add(_parLocoNum8);
            //_command8.Parameters.Add(_parSttTimeH8);
            //_command8.Parameters.Add(_parSttTimeM8);
            //_command8.Parameters.Add(_parMachinist8);
            //_command8.Parameters.Add(_parWagCoun8);
            //_command8.Parameters.Add(_parWagLoaded8);
            //_command8.Parameters.Add(_parWagEmpty8);
            //_command8.Parameters.Add(_parWagNoWork8);
            //_command8.Parameters.Add(_parNtWeight8);
            //_command8.Parameters.Add(_parGrWeight8);
            //_command9.Parameters.Add(_parTrainIdn9);
            //_command9.Parameters.Add(_parMsIdn9);
            //_command9.Parameters.Add(_parMsTime9);
            //_command9.Parameters.Add(_parMsStation9);
            //_command9.Parameters.Add(_parOperation9);
            //_command9.Parameters.Add(_parFlags9);
            //_command9.Parameters.Add(_parTrainNum9);
            //_command9.Parameters.Add(_parStForm9);
            //_command9.Parameters.Add(_parNmSost9);
            //_command9.Parameters.Add(_parStDest9);
            //_command9.Parameters.Add(_parTrainAttr9);
            //_command9.Parameters.Add(_parLocoSerie9);
            //_command9.Parameters.Add(_parLocoNum9);
            //_command9.Parameters.Add(_parSttTimeH9);
            //_command9.Parameters.Add(_parSttTimeM9);
            //_command9.Parameters.Add(_parMachinist9);
            //_command9.Parameters.Add(_parWagCoun9);
            //_command9.Parameters.Add(_parWagLoaded9);
            //_command9.Parameters.Add(_parWagEmpty9);
            //_command9.Parameters.Add(_parWagNoWork9);
            //_command9.Parameters.Add(_parNtWeight9);
            //_command9.Parameters.Add(_parGrWeight9);
            //_command10.Parameters.Add(_parStation10);
            //_command10.Parameters.Add(_parTrack10);
            //_command10.Parameters.Add(_parTime10);
            _command12.Parameters.Add(_parMessTime12);
            _command13.Parameters.Add(_parMsIdn13);
            _command13.Parameters.Add(_parMsTime13);
            _command13.Parameters.Add(_parMsStation13);
            _command13.Parameters.Add(_parOperation13);
            _command13.Parameters.Add(_parFlags13);
            _command13.Parameters.Add(_parTrainNum13);
            _command13.Parameters.Add(_parStForm13);
            _command13.Parameters.Add(_parNmSost13);
            _command13.Parameters.Add(_parStDest13);
            _command13.Parameters.Add(_parTrainAttr13);
            _command13.Parameters.Add(_parLocoSerie13);
            _command13.Parameters.Add(_parLocoNum13);
            _command13.Parameters.Add(_parSttTimeH13);
            _command13.Parameters.Add(_parSttTimeM13);
            _command13.Parameters.Add(_parMachinist13);
            _command13.Parameters.Add(_parWagCoun13);
            _command13.Parameters.Add(_parWagLoaded13);
            _command13.Parameters.Add(_parWagEmpty13);
            _command13.Parameters.Add(_parWagNoWork13);
            _command13.Parameters.Add(_parNtWeight13);
            _command13.Parameters.Add(_parGrWeight13);
            _command13.Parameters.Add(_parBadCode13);
            _command15.Parameters.Add(_parMsIdn15);
            _command16.Parameters.Add(_parMsIdn16);
            _command16.Parameters.Add(_parMessTime16);
            _command17.Parameters.Add(_parMessTime17);
            _command17.Parameters.Add(_parTrainIdn17);
            _command17.Parameters.Add(_parMsIdn17);
            _command19.Parameters.Add(_parTrainNum19);
            _command20.Parameters.Add(_parTrainIdn20);
            _command20.Parameters.Add(_parStation20);
            _command21.Parameters.Add(_parTimeSp21);
            _command21.Parameters.Add(_parMessIdn21);
            _command23.Parameters.Add(_parStopTime23);
            _command23.Parameters.Add(_parMessTime23);
            _command23.Parameters.Add(_parStation23);
            _command23.Parameters.Add(_parNmSost23);
            _command23.Parameters.Add(_parMsIdn23);
            //_command24.Parameters.Add(_parTrainIdnS24);
            //_command24.Parameters.Add(_parTrainIdnT24);
            //_command25.Parameters.Add(_parCommand25);
            //_command25.Parameters.Add(_parCOM_TIME25);
            //_command25.Parameters.Add(_parTrain_IdnH125);
            //_command25.Parameters.Add(_parNORM_IDNH125);
            //_command25.Parameters.Add(_parTrain_NumH125);
            //_command25.Parameters.Add(_parI_ST_FORMH125);
            //_command25.Parameters.Add(_parI_ST_DESTH125);
            //_command25.Parameters.Add(_parI_SOST_NUMH125);
            //_command25.Parameters.Add(_parDOP_PROPH125);
            //_command25.Parameters.Add(_parREZERVH125);
            //_command25.Parameters.Add(_parST_IN_ZONEH125);
            //_command25.Parameters.Add(_parST_OUT_ZONEH125);
            //_command25.Parameters.Add(_parTrain_IdnH225);
            //_command25.Parameters.Add(_parNORM_IDNH225);
            //_command25.Parameters.Add(_parTrain_NumH225);
            //_command25.Parameters.Add(_parI_ST_FORMH225);
            //_command25.Parameters.Add(_parI_ST_DESTH225);
            //_command25.Parameters.Add(_parI_SOST_NUMH225);
            //_command25.Parameters.Add(_parDOP_PROPH225);
            //_command25.Parameters.Add(_parREZERVH225);
            //_command25.Parameters.Add(_parST_IN_ZONEH225);
            //_command25.Parameters.Add(_parST_OUT_ZONEH225);
            //_command25.Parameters.Add(_parTRAIN_IDNE125);
            //_command25.Parameters.Add(_parEV_TYPEE125);
            //_command25.Parameters.Add(_parEV_TIMEE125);
            //_command25.Parameters.Add(_parEv_StationE125);
            //_command25.Parameters.Add(_parEV_AXISE125);
            //_command25.Parameters.Add(_parEv_NDOE125);
            //_command25.Parameters.Add(_parEV_NE_STATIONE125);
            //_command25.Parameters.Add(_parEV_REC_IDNE125);
            //_command25.Parameters.Add(_parEV_FLAGE125);
            //_command25.Parameters.Add(_parTRAIN_IDNE225);
            //_command25.Parameters.Add(_parEV_TYPEE225);
            //_command25.Parameters.Add(_parEV_TIMEE225);
            //_command25.Parameters.Add(_parEv_StationE225);
            //_command25.Parameters.Add( _parEV_AXISE225);
            //_command25.Parameters.Add(_parEv_NDOE225);
            //_command25.Parameters.Add(_parEV_NE_STATIONE225);
            //_command25.Parameters.Add(_parEV_REC_IDNE225);
            //_command25.Parameters.Add(_parEV_FLAGE225);
            _command28.Parameters.Add(_parMessIdn28);
            _command28.Parameters.Add(_parMsIdnPrev28);
            _command28.Parameters.Add(_parMessProp28);
            _command28.Parameters.Add(_parWirIdnPrev28);
            _command28.Parameters.Add(_parComCngNum28);
            _command28.Parameters.Add(_parComCngWir28);
            _command30.Parameters.Add(_parMessIdn30);
            _command30.Parameters.Add(_parMessProp30);
            //_command31.Parameters.Add(_parTrainIdnS31);
            //_command31.Parameters.Add(_parTrainIdnT31);
            //_command32.Parameters.Add(_parTrainIdnS32);
            //_command32.Parameters.Add(_parTrainIdnT32);
            _command34.Parameters.Add(_parComCngWir34);
            _command35.Parameters.Add(_parComCngNum35);
            //_command36.Parameters.Add(_parTrainIdn36);
            //_command37.Parameters.Add(_parTrainIdn37);
            //_command38.Parameters.Add(_parTrainIdn38);
            //_command39.Parameters.Add(_parStation39);
            //_command39.Parameters.Add(_parTrack39);
            //_command39.Parameters.Add(_parTime39);
            //_command40.Parameters.Add(_parStation40);
            //_command40.Parameters.Add(_parTrack40);
            //_command40.Parameters.Add(_parTime40);
            //_command41.Parameters.Add(_parSMStation41);
            //_command41.Parameters.Add(_parMsType41);
            //_command41.Parameters.Add(_parEvTime41);
            //_command41.Parameters.Add(_parMsTime41);
            //_command41.Parameters.Add(_parBOType41);
            //_command41.Parameters.Add(_parBOName41);
            //_command41.Parameters.Add(_parDOType41);
            //_command41.Parameters.Add(_parDOName41);
            //_command41.Parameters.Add(_parDopIdn41);
            //_command43.Parameters.Add(_parEvIdn43);
            //_command43.Parameters.Add(_parTrack43);
            //_command43.Parameters.Add(_parTime43);
            //_command44.Parameters.Add(_parTrainIdn44);
            //_command44.Parameters.Add(_parMarker44);
            //_command45.Parameters.Add(_parMessIdn45);
            //_command45.Parameters.Add(_parMarker45);
            //_command46.Parameters.Add(_parTrainIdn46);
            //_command47.Parameters.Add(_parTrainIdn47);
            //_command48.Parameters.Add(_parMessIdn48);
            //_command49.Parameters.Add(_parTrainIdn49);
            //_command50.Parameters.Add(_parStation50);
            //_command50.Parameters.Add(_parTrack50);
            //_command50.Parameters.Add(_parTime50);
            _command54.Parameters.Add(_parStForm54);
            _command54.Parameters.Add(_parSstNum54);
            _command54.Parameters.Add(_parStDest54);
            _command55.Parameters.Add(_parMessTime55);
            _command58.Parameters.Add(_parTrainIdn58);
            _command58.Parameters.Add(_parEvTime58);
            _command59.Parameters.Add(_parMsIdn59);
            _command59.Parameters.Add(_parMsType59);
            _command59.Parameters.Add(_parMsTime59);
            _command59.Parameters.Add(_parMsStat59);
            _command59.Parameters.Add(_parTrainNum59);
            _command59.Parameters.Add(_parMsAxis59);
            _command59.Parameters.Add(_parNeStat59);
            _command59.Parameters.Add(_parMsFlags59);
            _command60.Parameters.Add(_parMsIdn60);
            _command61.Parameters.Add(_parMsIdn61);
            _command61.Parameters.Add(_parMsFlags61);
            //_command62.Parameters.Add(_parTrainIdn62);
            //_command63.Parameters.Add(_parTrainIdn63);
            //_command63.Parameters.Add(_parNormIdn63);
            //_command64.Parameters.Add(_parRecIdn64);
            //_command64.Parameters.Add(_parNormIdn64);
            //_command64.Parameters.Add(_parTrainNum64);
            //_command64.Parameters.Add(_parStForm64);
            //_command64.Parameters.Add(_parStDest64);
            //_command64.Parameters.Add(_parSostNum64);
            //_command64.Parameters.Add(_parDopProp64);
            //_command64.Parameters.Add(_parRezerv64);
            //_command64.Parameters.Add(_parInZone64);
            //_command64.Parameters.Add(_parOutZone64);
            //_command64.Parameters.Add(_parWrNext64);
            //_command64.Parameters.Add(_parWrPrior64);
            //_command64.Parameters.Add(_parFlNoDel64);
            //_command65.Parameters.Add(_parTrainIdn65);
            //_command65.Parameters.Add(_parFlSost65);
            //_command66.Parameters.Add(_parTrainIdn66);
            //_command66.Parameters.Add(_parEvType66);
            //_command66.Parameters.Add(_parEvTime66);
            //_command66.Parameters.Add(_parEvTimeP66);
            //_command66.Parameters.Add(_parEvStation66);
            //_command66.Parameters.Add(_parEvAxis66);
            //_command66.Parameters.Add(_parEvNDO66);
            // _command66.Parameters.Add(_parCollSt66);
            //_command66.Parameters.Add(_parNeStation66);
            //_command67.Parameters.Add(_parDefIdn67);
            //_command67.Parameters.Add(_parSndFlag67);
            //_command67.Parameters.Add(_parTmDefC67);
            //_command68.Parameters.Add(_parStdForm68);
            //_command68.Parameters.Add(_parSndFlag68);
            _command69.Parameters.Add(_parDefIdn69);
            //_command70.Parameters.Add(_parPlnEvIdn70);
            _command71.Parameters.Add(_parPlnEvIdn71);
            _command72.Parameters.Add(_parPlnEvIdn72);
            _command73.Parameters.Add(_parPlnIdn73);
            _command74.Parameters.Add(_parTrainIdn74);
            _command75.Parameters.Add(_parFlags75);
            _command76.Parameters.Add(_parFlagsO76);
            _command76.Parameters.Add(_parFlagsN76);
            //_command77.Parameters.Add(_parReplyText77);
            _command78.Parameters.Add(_parFlags78);
            _command79.Parameters.Add(_parFlagsO79);
            _command79.Parameters.Add(_parFlagsN79);
            //_command80.Parameters.Add(_parMessTimeStt80);
            //_command80.Parameters.Add(_parMessTimeStp80);
            //_command80.Parameters.Add(_parStation80);
            //_command80.Parameters.Add(_parNsuNumber80);
            //_command81.Parameters.Add(_parMessIdn81);
            //_command81.Parameters.Add(_parStation81);
            //_command81.Parameters.Add(_parNsuNumber81);
            //_command81.Parameters.Add(_parMessTime81);
            //_command81.Parameters.Add(_parDestination81);
            //_command81.Parameters.Add(_parLocoSeries81);
            //_command81.Parameters.Add(_parLocoNumber81);
            //_command82.Parameters.Add(_parMessIdn82);
            //_command82.Parameters.Add(_parTrainIndex82);
            //_command82.Parameters.Add(_parTrainNumber82);
            //_command82.Parameters.Add(_parFlags82);
        }


        private void AddParametrsToCommand8()
        {
            _command8.Parameters.Add(_parTrainIdn8);
            _command8.Parameters.Add(_parMsIdn8);
            _command8.Parameters.Add(_parMsTime8);
            _command8.Parameters.Add(_parMsStation8);
            _command8.Parameters.Add(_parOperation8);
            _command8.Parameters.Add(_parFlags8);
            _command8.Parameters.Add(_parTrainNum8);
            _command8.Parameters.Add(_parStForm8);
            _command8.Parameters.Add(_parNmSost8);
            _command8.Parameters.Add(_parStDest8);
            _command8.Parameters.Add(_parTrainAttr8);
            _command8.Parameters.Add(_parLocoSerie8);
            _command8.Parameters.Add(_parLocoNum8);
            _command8.Parameters.Add(_parSttTimeH8);
            _command8.Parameters.Add(_parSttTimeM8);
            _command8.Parameters.Add(_parMachinist8);
            _command8.Parameters.Add(_parWagCoun8);
            _command8.Parameters.Add(_parWagLoaded8);
            _command8.Parameters.Add(_parWagEmpty8);
            _command8.Parameters.Add(_parWagNoWork8);
            _command8.Parameters.Add(_parNtWeight8);
            _command8.Parameters.Add(_parGrWeight8);
        }

        private void AddParametrsToCommand9()
        {
            _command9.Parameters.Add(_parTrainIdn9);
            _command9.Parameters.Add(_parMsIdn9);
            _command9.Parameters.Add(_parMsTime9);
            _command9.Parameters.Add(_parMsStation9);
            _command9.Parameters.Add(_parOperation9);
            _command9.Parameters.Add(_parFlags9);
            _command9.Parameters.Add(_parTrainNum9);
            _command9.Parameters.Add(_parStForm9);
            _command9.Parameters.Add(_parNmSost9);
            _command9.Parameters.Add(_parStDest9);
            _command9.Parameters.Add(_parTrainAttr9);
            _command9.Parameters.Add(_parLocoSerie9);
            _command9.Parameters.Add(_parLocoNum9);
            _command9.Parameters.Add(_parSttTimeH9);
            _command9.Parameters.Add(_parSttTimeM9);
            _command9.Parameters.Add(_parMachinist9);
            _command9.Parameters.Add(_parWagCoun9);
            _command9.Parameters.Add(_parWagLoaded9);
            _command9.Parameters.Add(_parWagEmpty9);
            _command9.Parameters.Add(_parWagNoWork9);
            _command9.Parameters.Add(_parNtWeight9);
            _command9.Parameters.Add(_parGrWeight9);
        }

        private void AddParametrsToCommand25()
        {
            _command25.Parameters.Add(_parCommand25);
            _command25.Parameters.Add(_parCOM_TIME25);
            _command25.Parameters.Add(_parTrain_IdnH125);
            _command25.Parameters.Add(_parNORM_IDNH125);
            _command25.Parameters.Add(_parTrain_NumH125);
            _command25.Parameters.Add(_parI_ST_FORMH125);
            _command25.Parameters.Add(_parI_ST_DESTH125);
            _command25.Parameters.Add(_parI_SOST_NUMH125);
            _command25.Parameters.Add(_parDOP_PROPH125);
            _command25.Parameters.Add(_parREZERVH125);
            _command25.Parameters.Add(_parST_IN_ZONEH125);
            _command25.Parameters.Add(_parST_OUT_ZONEH125);
            _command25.Parameters.Add(_parTrain_IdnH225);
            _command25.Parameters.Add(_parNORM_IDNH225);
            _command25.Parameters.Add(_parTrain_NumH225);
            _command25.Parameters.Add(_parI_ST_FORMH225);
            _command25.Parameters.Add(_parI_ST_DESTH225);
            _command25.Parameters.Add(_parI_SOST_NUMH225);
            _command25.Parameters.Add(_parDOP_PROPH225);
            _command25.Parameters.Add(_parREZERVH225);
            _command25.Parameters.Add(_parST_IN_ZONEH225);
            _command25.Parameters.Add(_parST_OUT_ZONEH225);
            _command25.Parameters.Add(_parTRAIN_IDNE125);
            _command25.Parameters.Add(_parEV_TYPEE125);
            _command25.Parameters.Add(_parEV_TIMEE125);
            _command25.Parameters.Add(_parEv_StationE125);
            _command25.Parameters.Add(_parEV_AXISE125);
            _command25.Parameters.Add(_parEv_NDOE125);
            _command25.Parameters.Add(_parEV_NE_STATIONE125);
            _command25.Parameters.Add(_parEV_REC_IDNE125);
            _command25.Parameters.Add(_parEV_FLAGE125);
            _command25.Parameters.Add(_parTRAIN_IDNE225);
            _command25.Parameters.Add(_parEV_TYPEE225);
            _command25.Parameters.Add(_parEV_TIMEE225);
            _command25.Parameters.Add(_parEv_StationE225);
            _command25.Parameters.Add(_parEV_AXISE225);
            _command25.Parameters.Add(_parEv_NDOE225);
            _command25.Parameters.Add(_parEV_NE_STATIONE225);
            _command25.Parameters.Add(_parEV_REC_IDNE225);
            _command25.Parameters.Add(_parEV_FLAGE225);
        }

        private void AddParametrsToCommand39()
        {
            _command39.Parameters.Add(_parStation39);
            _command39.Parameters.Add(_parTrack39);
            _command39.Parameters.Add(_parTime39);
        }

        private void AddParametrsToCommand40()
        {
            _command40.Parameters.Add(_parStation40);
            _command40.Parameters.Add(_parTrack40);
            _command40.Parameters.Add(_parTime40);
        }

        private void AddParametrsToCommand41()
        {
            _command41.Parameters.Add(_parSMStation41);
            _command41.Parameters.Add(_parMsType41);
            _command41.Parameters.Add(_parEvTime41);
            _command41.Parameters.Add(_parMsTime41);
            _command41.Parameters.Add(_parBOType41);
            _command41.Parameters.Add(_parBOName41);
            _command41.Parameters.Add(_parDOType41);
            _command41.Parameters.Add(_parDOName41);
            _command41.Parameters.Add(_parDopIdn41);
        }

        private void AddParametrsToCommand43()
        {
            _command43.Parameters.Add(_parEvIdn43);
            _command43.Parameters.Add(_parTrack43);
            _command43.Parameters.Add(_parTime43);
        }

        private void AddParametrsToCommand50()
        {
            _command50.Parameters.Add(_parStation50);
            _command50.Parameters.Add(_parTrack50);
            _command50.Parameters.Add(_parTime50);
        }

        private void AddParametrsToCommand64()
        {
            _command64.Parameters.Add(_parRecIdn64);
            _command64.Parameters.Add(_parNormIdn64);
            _command64.Parameters.Add(_parTrainNum64);
            _command64.Parameters.Add(_parStForm64);
            _command64.Parameters.Add(_parStDest64);
            _command64.Parameters.Add(_parSostNum64);
            _command64.Parameters.Add(_parDopProp64);
            _command64.Parameters.Add(_parRezerv64);
            _command64.Parameters.Add(_parInZone64);
            _command64.Parameters.Add(_parOutZone64);
            _command64.Parameters.Add(_parWrNext64);
            _command64.Parameters.Add(_parWrPrior64);
            _command64.Parameters.Add(_parFlNoDel64);
        }

        private void AddParametrsToCommand65()
        {
            _command65.Parameters.Add(_parTrainIdn65);
            _command65.Parameters.Add(_parFlSost65);
        }

        private void AddParametrsToCommand66()
        {
            _command66.Parameters.Add(_parTrainIdn66);
            _command66.Parameters.Add(_parEvType66);
            _command66.Parameters.Add(_parEvTime66);
            _command66.Parameters.Add(_parEvTimeP66);
            _command66.Parameters.Add(_parEvStation66);
            _command66.Parameters.Add(_parEvAxis66);
            _command66.Parameters.Add(_parEvNDO66);
            _command66.Parameters.Add(_parCollSt66);
            _command66.Parameters.Add(_parNeStation66);
        }

        private void AddParametrsToCommand80()
        {
            _command80.Parameters.Add(_parMessTimeStt80);
            _command80.Parameters.Add(_parMessTimeStp80);
            _command80.Parameters.Add(_parStation80);
            _command80.Parameters.Add(_parNsuNumber80);
        }

        private void AddParametrsToCommand81()
        {
            _command81.Parameters.Add(_parMessIdn81);
            _command81.Parameters.Add(_parStation81);
            _command81.Parameters.Add(_parNsuNumber81);
            _command81.Parameters.Add(_parMessTime81);
            _command81.Parameters.Add(_parDestination81);
            _command81.Parameters.Add(_parLocoSeries81);
            _command81.Parameters.Add(_parLocoNumber81);
        }

        private void AddParametrsToCommand82()
        {
            _command82.Parameters.Add(_parMessIdn82);
            _command82.Parameters.Add(_parTrainIndex82);
            _command82.Parameters.Add(_parTrainNumber82);
            _command82.Parameters.Add(_parFlags82);
        }

        private void AddParametrsToCommand85(IEnumerable<string> values)
        {
            _command85.Parameters.Add(_parTrainNum85);
            _command85.AddArrayParameters("Stations", values);
        }

        //Пользовательские запросы---------------------------------------------------------------------
        //Дать список последних событий по поездам
        public IList<TrainEvent> GetLastTrainEvents()
        {
            //Создаем новый (выходной) список событий
            IList<TrainEvent> returnedList = new List<TrainEvent>();
            //Создаем новое соединение
            using (var connection = new FbConnection(_connectionString))
            {
                connection.Open();
                _command1 = new FbCommand(CommandText1);
                _command1.Parameters.Add(_parEvTime1);
                //
                _command2 = new FbCommand(CommandText2);
                _command2.Parameters.Add(_parTrainId2);
                _command2.Parameters.Add(_parEventTime2);
                //
                _command10 = new FbCommand(CommandText10);
                _command10.Parameters.Add(_parStation10);
                _command10.Parameters.Add(_parTrack10);
                _command10.Parameters.Add(_parTime10);
                //
                _command84 = new FbCommand(CommandText84);
                _command84.Parameters.Add(_parTrainIdn84);
                using (var transaction = connection.BeginTransaction())
                {

                    AssignConnectionAndTransactionToCommand(_command1, connection, transaction);
                    AssignConnectionAndTransactionToCommand(_command2, connection, transaction);
                    AssignConnectionAndTransactionToCommand(_command10, connection, transaction);
                    AssignConnectionAndTransactionToCommand(_command84, connection, transaction);
                    //_parEvTime1.Value = DateTime.Now.AddHours(-3);//!!!
                    _parEvTime1.Value = GetTimeGIDStop().AddHours(-3);//!!!
                    using (var dbReader1 = _command1.ExecuteReader())
                    {
                        while (dbReader1.Read())
                        {
                            //идентификатор поезда
                            _parTrainId2.Value = dbReader1[0];
                            //время последнего события
                            var eventTime = dbReader1.GetDateTime(1);
                            _parEventTime2.Value = eventTime;
                            using (var dbReader2 = _command2.ExecuteReader())
                            {
                                //оно должно быть одно !!!
                                while (dbReader2.Read())
                                {
                                    var trainEvent = new TrainEvent
                                    {
                                        TrainIdn = dbReader1.GetInt32(0),
                                        EventStation = dbReader2.GetString(0).Remove(0, 2),
                                        EventType = dbReader2.GetInt16(1),
                                        EventAxis = dbReader2.GetString(2),
                                        //DObjType          = dbReader2.GetInt16(3),
                                        DObjName = dbReader2.GetString(4),
                                        NeibStation = dbReader2.GetString(5),
                                        TrainNumber = dbReader2.GetString(6),
                                        TrainNumberPrefix = dbReader2.GetString(7),
                                        TrainNumberSuffix = dbReader2.GetString(8),
                                        DestStation = dbReader2.GetString(10),
                                        //CrewStTimeH       = dbReader2.GetByte(11),
                                        //CrewStTimeM       = dbReader2.GetInt32(12),
                                        Machinist = dbReader2.GetString(13),
                                        //CWagCount         = dbReader2.GetInt32(14),
                                        //NtWeight          = dbReader2.GetInt32(15),
                                        //GrWeight          = dbReader2.GetInt32(16),
                                        Marker = dbReader2.GetString(17),
                                        BadCode = dbReader2.GetString(18),
                                        //IdWrPrior         = dbReader2.GetInt32(19),
                                        //IdWrNext          = dbReader2.GetInt32(20),
                                        //NormIdn           = dbReader2.GetInt32(21),
                                        //RoTime            = dbReader2.GetDateTime(22),
                                        //BzTime            = dbReader2.GetDateTime(23),
                                        TrainAttr = dbReader2.GetString(24),
                                        EventTime = eventTime
                                    };
                                    trainEvent.RoTime = new DateTime(1899, 12, 30);
                                    trainEvent.BzTime = new DateTime(1899, 12, 30);
                                    if (!String.IsNullOrEmpty(dbReader2.GetString(22)))
                                    {
                                        trainEvent.RoTime = dbReader2.GetDateTime(22);
                                    }
                                    if (!String.IsNullOrEmpty(dbReader2.GetString(23)))
                                    {
                                        trainEvent.BzTime = dbReader2.GetDateTime(23);
                                    }
                                    int tmI;
                                    if (!Int32.TryParse(dbReader2.GetString(3), out tmI)) { tmI = -1; }
                                    trainEvent.DObjType = tmI;
                                    if (!Int32.TryParse(dbReader2.GetString(9), out tmI)) { tmI = -1; }
                                    trainEvent.MessIdn = tmI;
                                    if (!Int32.TryParse(dbReader2.GetString(11), out tmI)) { tmI = 0; }
                                    trainEvent.CrewStTimeH = tmI;
                                    if (!Int32.TryParse(dbReader2.GetString(12), out tmI)) { tmI = 0; }
                                    trainEvent.CrewStTimeM = tmI;
                                    if (!Int32.TryParse(dbReader2.GetString(14), out tmI)) { tmI = 0; }
                                    trainEvent.CWagCount = tmI;
                                    if (!Int32.TryParse(dbReader2.GetString(15), out tmI)) { tmI = 0; }
                                    trainEvent.NtWeight = tmI;
                                    if (!Int32.TryParse(dbReader2.GetString(16), out tmI)) { tmI = 0; }
                                    trainEvent.GrWeight = tmI;
                                    if (!Int32.TryParse(dbReader2.GetString(21), out tmI)) { tmI = 0; }
                                    trainEvent.NormIdn = tmI;
                                    //
                                    if (trainEvent.Marker != "")
                                    {
                                        trainEvent.Marker = trainEvent.Marker;
                                    }
                                    //
                                    // trainEvent.EventStation = trainEvent.EventStation.Remove(0, 2);
                                    if (trainEvent.NeibStation != null)
                                    {
                                        if (trainEvent.NeibStation.Length >= 2)
                                        {
                                            trainEvent.NeibStation = trainEvent.NeibStation.Remove(0, 2);
                                        }
                                    }
                                    if (trainEvent.EventType != 3)
                                    {
                                        _parStation10.Value = "TE" + trainEvent.EventStation;
                                        _parTrack10.Value = trainEvent.EventAxis;
                                        _parTime10.Value = trainEvent.EventTime + new TimeSpan(0, 0, 1);
                                        using (var dbReader3 = _command10.ExecuteReader())
                                        {
                                            if (!dbReader3.Read()) { trainEvent.DestType = 0; }
                                            else { trainEvent.DestType = 1; }
                                        }
                                    }
                                    else
                                    {
                                        if (trainEvent.NeibStation != "") { trainEvent.DestType = 2; }
                                        else { trainEvent.DestType = 3; }
                                    }
                                    //
                                    if (trainEvent.NormIdn != 0)
                                    {
                                        //ищем расписание плановой нитки
                                        _parTrainIdn84.Value = trainEvent.NormIdn;
                                        using (var dbReader4 = _command84.ExecuteReader())
                                        {
                                            while (dbReader4.Read())
                                            {
                                                var planEvent = new PlanEvent();
                                                planEvent.EventType = dbReader4.GetInt16(0);
                                                planEvent.EventTimeP = dbReader4.GetDateTime(1);
                                                planEvent.EventStation = dbReader4.GetString(2).Remove(0, 2);
                                                planEvent.EvIdn = dbReader4.GetInt32(3);
                                                trainEvent.PlanEvents.Add(planEvent);
                                            }
                                        }
                                    }
                                    //Помещаем событие в возвращаемый список
                                    returnedList.Add(trainEvent);
                                    break;
                                }
                            }
                        }
                    }
                }
                _command1.Dispose();
                _command2.Dispose();
                _command10.Dispose();
                _command84.Dispose();
                //Закрываем соединение
                connection.Close();
            }
            //Возвращаем список событий
            return returnedList;
        }


        //Дать список открытых векторов обработки поездов
        public IList<TrainWorking> GetWorkVectors()
        {
            IList<TrainWorking> returnedList = new List<TrainWorking>();
            using (var connection = new FbConnection(_connectionString))
            {
                connection.Open();
                _command3 = new FbCommand(CommandText3);
                using (var transaction = connection.BeginTransaction())
                {
                    AssignConnectionAndTransactionToCommand(_command3, connection, transaction);
                    using (var dbReader1 = _command3.ExecuteReader())
                    {
                        while (dbReader1.Read())
                        {
                            var trainWrkVector = new TrainWorking
                            {
                                MsType = dbReader1.GetInt16(0),
                                Station = dbReader1.GetString(1),
                                Track = dbReader1.GetString(2),
                                TrainPrefix = dbReader1.GetString(3),
                                TrainNumber = dbReader1.GetString(4),
                                TrainSuffix = dbReader1.GetString(5),
                                NeStation = dbReader1.GetString(6),
                                Remark = dbReader1.GetString(7),
                                StartTime = dbReader1.GetDateTime(8),
                                StopTime = dbReader1.GetDateTime(9)
                            };
                            if (trainWrkVector.StopTime != new DateTime(1899, 12, 30)) { continue; }
                            //Если вектор открыт
                            //помещаем его в возвращаемый список
                            returnedList.Add(trainWrkVector);
                        }
                    }
                }
                _command3.Dispose();
                connection.Close();
            }
            return returnedList;
        }
        //Дать историю справок 
        /*
        0  Ms_Idn
        1  Ms_Time
        2  Ms_Station
        3  Train_Idn
        4  Train_Num
        5  Wr_Stt_Time
        6  Wr_Stp_Time
        7  St_Form
        8  Nm_Sost
        9  St_Dest
        10 Ms_Prop
        11 Stt_TimeH
        12 Stt_TimeM
        13 Machinist
        14 Wag_Coun
        15 Nt_Weight
        16 Gr_Weight
        17 Ms_Marker
        18 Bad_Code
        19 Loco_Series
        20 Loco_Num
        21 Train_Attr
        22 Wag_Loaded
        23 Wag_Empty
        24 Wag_NoWork
        25 Operation
        26 Flags
        */
        public IList<WorkMessage> GetWorkMessages()
        {
            IList<WorkMessage> returnedList = new List<WorkMessage>();
            using (var connection = new FbConnection(_connectionString))
            {
                connection.Open();
                _command11 = new FbCommand(CommandText11);
                using (var transaction = connection.BeginTransaction())
                {
                    AssignConnectionAndTransactionToCommand(_command11, connection, transaction);
                    using (var dbReader1 = _command11.ExecuteReader())
                    {
                        while (dbReader1.Read())
                        {
                            try
                            {
                                var trainWrkMess = new WorkMessage
                                {
                                    MessIdn = dbReader1.GetInt32(0),
                                    MessTime = dbReader1.GetDateTime(1),
                                    MessStation = dbReader1.GetString(2),
                                    TrainNum = dbReader1.GetString(4),
                                    StForm = dbReader1.GetString(7),
                                    NmSost = dbReader1.GetString(8),
                                    StDest = dbReader1.GetString(9),
                                    MessProp = dbReader1.GetInt32(10),
                                    CrewStTimeH = dbReader1.GetInt32(11),
                                    CrewStTimeM = dbReader1.GetInt32(12),
                                    Machinist = dbReader1.GetString(13),
                                    CWagCount = dbReader1.GetInt32(14),
                                    NtWeight = dbReader1.GetInt32(15),
                                    GrWeight = dbReader1.GetInt32(16),
                                    Marker = dbReader1.GetString(17),
                                    BadCode = dbReader1.GetString(18),
                                    LocoSeries = dbReader1.GetString(19),
                                    LocoNum = dbReader1.GetString(20),
                                    TrainAttr = dbReader1.GetString(21),
                                    WagLoaded = (byte)dbReader1.GetInt16(22),
                                    WagEmpty = (byte)dbReader1.GetInt16(23),
                                    WagNoWork = (byte)dbReader1.GetInt16(24),
                                    Operation = dbReader1.GetString(25),
                                    Flags = dbReader1.GetString(26),
                                    MessType = 0
                                };
                                int ti; if (!Int32.TryParse(dbReader1.GetString(3), out ti)) { ti = -1; }
                                trainWrkMess.TrainIdn = ti;
                                if (!String.IsNullOrEmpty(dbReader1.GetString(5))) { trainWrkMess.MessType += 1; }
                                if (!String.IsNullOrEmpty(dbReader1.GetString(6))) { trainWrkMess.MessType += 2; }
                                //
                                if (trainWrkMess.Marker != "")
                                {
                                    trainWrkMess.Marker = trainWrkMess.Marker;
                                }
                                //
                                returnedList.Add(trainWrkMess);
                            }
                            catch (Exception exception)
                            {
                                string Error = exception.ToString();
                            }
                        }
                    }
                }
                _command11.Dispose();
                connection.Close();
            }
            return returnedList;
        }
        //Дать список свежих сообщений ГИД
        public IList<GIDMessage> GetGIDMessages()
        {
            DateTime startTime = GetTimeGIDStop() - new TimeSpan(0, _deltaTimeStop + _deltaTimeStart, 0);
            IList<GIDMessage> returnedList = new List<GIDMessage>();
            ClearGidMessages(GetTimeGIDStart());
            WriteGIDMessages();
            using (var connection = new FbConnection(_connectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    AssignConnectionAndTransactionToCommand(_command56, connection, transaction);
                    using (var dbReader1 = _command56.ExecuteReader())
                    {
                        while (dbReader1.Read())
                        {
                            var gidMessage = new GIDMessage
                            {
                                MsIdn = dbReader1.GetInt32(0),
                                MsType = dbReader1.GetInt16(1),
                                MsTime = dbReader1.GetDateTime(2),
                                MsStation = dbReader1.GetString(3),
                                TrainNum = dbReader1.GetString(4),
                                MsAxis = dbReader1.GetString(5),
                                NeStation = dbReader1.GetString(6),
                                MsFlags = dbReader1.GetString(7)
                            };
                            if (!String.IsNullOrEmpty(gidMessage.MsFlags)) { continue; }
                            if (gidMessage.MsTime < startTime) { continue; }
                            //помещаем его в возвращаемый список
                            returnedList.Add(gidMessage);
                            SetMessFlag(gidMessage.MsIdn, "T");
                        }
                    }
                }
                connection.Close();
            }
            return returnedList;
        }
        //Дать список подготовленных ! но не воспринятых ! заданий на исполнение команд
        public IList<ComDefinition> GetComDefinitionsNoRun()
        {
            IList<ComDefinition> returnedList = new List<ComDefinition>();
            using (var connection = new FbConnection(_connectionString))
            {
                connection.Open();
                _command83 = new FbCommand(CommandText83);
                using (var transaction = connection.BeginTransaction())
                {
                    AssignConnectionAndTransactionToCommand(_command83, connection, transaction);
                    //_parStdForm68.Value = 2;
                    //_parSndFlag68.Value = 0;
                    using (var dbReader1 = _command83.ExecuteReader())
                    {
                        while (dbReader1.Read())
                        {
                            var comDefinition = new ComDefinition
                            {
                                ComType = 0,
                                DefIdn = dbReader1.GetInt32(0),
                                StatCode = dbReader1.GetInt32(1).ToString().Trim(),
                                TrainNum = dbReader1.GetString(2).Trim(),
                                ObSttType = dbReader1.GetInt16(3),
                                ObSttName = dbReader1.GetString(4).Trim(),
                                ObStpType = dbReader1.GetInt16(5),
                                ObStpName = dbReader1.GetString(6).Trim(),
                                ComStartTime = dbReader1.GetDateTime(9),
                                CollStartTime = DateTime.MinValue
                            };
                            returnedList.Add(comDefinition);
                        }
                    }
                }
                _command83.Dispose();
                connection.Close();
            }
            return returnedList;
        }
        //Дать список подготовленных заданий на исполнение команд
        public IList<ComDefinition> GetComDefinitions()
        {
            IList<ComDefinition> returnedList = new List<ComDefinition>();
            // IList<TrainEvent> trainEvents = GetLastTrainEvents();
            using (var connection = new FbConnection(_connectionString))
            {
                connection.Open();
                _command68 = new FbCommand(CommandText68);
                _command68.Parameters.Add(_parStdForm68);
                _command68.Parameters.Add(_parSndFlag68);
                //
                _command70 = new FbCommand(CommandText70);
                _command70.Parameters.Add(_parPlnEvIdn70);
                using (var transaction = connection.BeginTransaction())
                {
                    AssignConnectionAndTransactionToCommand(_command68, connection, transaction);
                    AssignConnectionAndTransactionToCommand(_command70, connection, transaction);
                    _parStdForm68.Value = 2;
                    _parSndFlag68.Value = 0;
                    using (var dbReader1 = _command68.ExecuteReader())
                    {
                        if (dbReader1.HasRows)
                        {
                            while (dbReader1.Read())
                            {
                                var comDefinition = new ComDefinition
                                {
                                    ComType = 0,
                                    DefIdn = dbReader1.GetInt32(0),
                                    StatCode = dbReader1.GetInt32(1).ToString().Trim(),
                                    TrainNum = dbReader1.GetString(2).Trim(),
                                    ObSttType = dbReader1.GetInt16(3),
                                    ObSttName = dbReader1.GetString(4).Trim(),
                                    ObStpType = dbReader1.GetInt16(5),
                                    ObStpName = dbReader1.GetString(6).Trim(),
                                    //Lnk_Def_Idn_N (7)
                                    //Lnk_Def_Idn_E (8)
                                    ComStartTime = dbReader1.GetDateTime(9),
                                    CollStartTime = DateTime.MinValue,
                                    PlnEvIdn = dbReader1.GetInt32(11)
                                };
                                //ищем Id плановой нитки
                                _parPlnEvIdn70.Value = comDefinition.PlnEvIdn;
                                using (var dbReader2 = _command70.ExecuteReader())
                                {
                                    if (dbReader2.HasRows)
                                    {
                                        if (dbReader2.Read())
                                        {
                                            comDefinition.PlnIdn = dbReader2.GetInt32(4);
                                        }
                                    }
                                }
                                /*
                                GIDMessage planEvent = null;
                                int lnkDefIdn = 0;
                                ComDefinition lnkDefinition = null;
                                planEvent = GetPlanEventByIdn(dbReader1.GetInt32(11));
                                if (planEvent == null){
                                  continue;
                                }
                                //Проверяем на наличие конфликтов----------------------------------------------
                                if((planEvent.FlColSt > 0) || (planEvent.FlColSp > 0)){
                                  //comDefinition.ComType = 1;???
                                  //continue;
                                }
                                if(FindSpanConflict(trainEvents,comDefinition,dbReader1.GetInt32(11))){
                                  //continue;
                                }
                                //Пусть Артем Разбирается
                                comDefinition.CollStartTime = GetTmStartCollByTrain(planEvent.TrainIdn);
                                //Проверяем работу исключающей команды-----------------------------------------
                                lnkDefIdn = (!String.IsNullOrEmpty(dbReader1.GetString(8)))
                                                       ? Int32.Parse(dbReader1.GetString(8))
                                                       : 0;
                                lnkDefinition = GetDefByDefIdn(lnkDefIdn);
                                if(lnkDefinition != null){
                                  //Исключающая команда существует
                                  if(lnkDefinition.StdForm != 5){
                                    //не связана(с исполненным событием)
                                    //а может оно САМО уже подтвердилось?
                                    planEvent = GetPlanEventByIdn(lnkDefinition.PlnIdn);
                                    //само связанное событие плановой нитки
                                    if(planEvent != null){
                                      if(planEvent.FlCnfm != 2){
                                        //не подтверждено
                                        continue;
                                      }
                                      //Событие подтверждено
                                      //Можно установить флаг связанности для команды
                                    }
                                  }
                                }
                                //Проверяем работу команды на прибытие для отправления-------------------------
                                lnkDefIdn = (!String.IsNullOrEmpty(dbReader1.GetString(7)))
                                                       ? Int32.Parse(dbReader1.GetString(7))
                                                       : 0;
                                lnkDefinition = GetDefByDefIdn(lnkDefIdn);
                                if(lnkDefinition != null){
                                  //предыдущая (на прибытие) существует
                                  if(lnkDefinition.FlSnd < 4){//!!!
                                    //но она даже не начинала выполняться
                                    continue;
                                  }
                                  //предыдущая команда (на прибытие) выполняется или уже выполнена
                                  int flStay = dbReader1.GetInt16(10);
                                  if(flStay > 0){
                                    //если планируется стоянка
                                    planEvent = GetPlanEventByIdn(lnkDefinition.PlnIdn);
                                    //событие плановой нитки (прибытие)
                                    if(planEvent != null){
                                      if(planEvent.FlCnfm != 2){
                                        //прибытие пока не подтверждено
                                        continue;
                                      }
                                      //выдерживаем стоянку
                                      if((GetTimeGIDStop() - planEvent.MsTime) <
                                        (comDefinition.ComStartTime - lnkDefinition.ComStartTime)){
                                        //открывать выходной еще пора
                                        continue;
                                      }
                                    }
                                  }
                                }
                                */
                                //Установить время исполнения (щажжа)???.
                                //comDefinition.ComStartTime = GetTimeGIDStop() + new TimeSpan(0, 1, 0);
                                returnedList.Add(comDefinition);
                                // SetDefSendFlag(comDefinition.DefIdn, 1, comDefinition.ComStartTime);
                            }
                        }
                    }
                }
                _command68.Dispose();
                _command70.Dispose();
                connection.Close();
            }
            return returnedList;
        }
        //Дать запросы для ИАС
        public IList<string> GetRequests()
        {
            var requests = new List<string>();
            using (var connection = new SqlConnection(_connectionStringBuh))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    AssignConnectionAndTransactionToCommandSql(_command75, connection, transaction);
                    AssignConnectionAndTransactionToCommandSql(_command76, connection, transaction);
                    AssignConnectionAndTransactionToCommandSql(_command78, connection, transaction);
                    AssignConnectionAndTransactionToCommandSql(_command79, connection, transaction);
                    //
                    _parFlags75.Value = "1";
                    using (var dbReader1 = _command75.ExecuteReader())
                    {
                        while (dbReader1.Read())
                        {
                            requests.Add(dbReader1.GetString(0));
                        }
                    }
                    _parFlagsO76.Value = "1"; _parFlagsN76.Value = "2";
                    _command76.ExecuteNonQuery();
                    //
                    _parFlags78.Value = "1";
                    using (var dbReader1 = _command78.ExecuteReader())
                    {
                        while (dbReader1.Read())
                        {
                            requests.Add(dbReader1.GetString(0));
                        }
                    }
                    _parFlagsO79.Value = "1"; _parFlagsN79.Value = "2";
                    _command79.ExecuteNonQuery();
                    //
                    _parFlags78.Value = "4";
                    using (var dbReader1 = _command78.ExecuteReader())
                    {
                        while (dbReader1.Read())
                        {
                            requests.Add(dbReader1.GetString(0));
                        }
                    }
                    _parFlagsO79.Value = "4"; _parFlagsN79.Value = "5";
                    _command79.ExecuteNonQuery();
                    transaction.Commit();
                }
                connection.Close();
            }
            return requests;
        }
        //Пользовательские команды---------------------------------------------------------------
        //Удалить плановую нитку
        public string DelPlanWire(int trainIdn)
        {
            string retString = "";
            using (var connection = new FbConnection(_connectionString))
            {
                connection.Open();
                _command62 = new FbCommand(CommandText62);
                _command62.Parameters.Add(_parTrainIdn62);
                //
                _command90 = new FbCommand(CommandText90);
                _command90.Parameters.Add(_parTrainIdn90);
                using (var transaction = connection.BeginTransaction())
                {
                    AssignConnectionAndTransactionToCommand(_command62, connection, transaction);
                    AssignConnectionAndTransactionToCommand(_command90, connection, transaction);
                    _parTrainIdn62.Value = trainIdn;
                    _parTrainIdn90.Value = trainIdn;
                    _command62.ExecuteNonQuery();
                    _command90.ExecuteNonQuery();
                    transaction.Commit();
                    retString = "Плановая нитка удалена.";
                }
                _command62.Dispose();
                _command90.Dispose();
                connection.Close();
            }
            return retString;
        }
        //Соединить нитки (безусловно)
        public string BindTrainThreads(int sourceThreadId, int targetThreadId)
        {
            string retString = "";
            using (var connection = new FbConnection(_connectionString))
            {
                connection.Open();
                _command24 = new FbCommand(CommandText24);
                _command24.Parameters.Add(_parTrainIdnS24);
                _command24.Parameters.Add(_parTrainIdnT24);
                //
                _command31 = new FbCommand(CommandText31);
                _command31.Parameters.Add(_parTrainIdnS31);
                _command31.Parameters.Add(_parTrainIdnT31);
                //
                _command32 = new FbCommand(CommandText32);
                _command32.Parameters.Add(_parTrainIdnS32);
                _command32.Parameters.Add(_parTrainIdnT32);
                // 
                _command36 = new FbCommand(CommandText36);
                _command36.Parameters.Add(_parTrainIdn36);
                //
                _command37 = new FbCommand(CommandText37);
                _command37.Parameters.Add(_parTrainIdn37);
                using (var transaction = connection.BeginTransaction())
                {
                    AssignConnectionAndTransactionToCommand(_command24, connection, transaction);
                    AssignConnectionAndTransactionToCommand(_command31, connection, transaction);
                    AssignConnectionAndTransactionToCommand(_command32, connection, transaction);
                    AssignConnectionAndTransactionToCommand(_command36, connection, transaction);
                    AssignConnectionAndTransactionToCommand(_command37, connection, transaction);
                    DateTime _timeSttS = DateTime.MinValue;
                    DateTime _timeEndS = DateTime.MinValue;
                    DateTime _timeSttT = DateTime.MinValue;
                    DateTime _timeEndT = DateTime.MinValue;
                    _parTrainIdn36.Value = sourceThreadId;
                    using (var dbReader1 = _command36.ExecuteReader())
                    {
                        if (dbReader1.Read())
                        {
                            _timeEndS = dbReader1.GetDateTime(1);
                        }
                    }
                    _parTrainIdn36.Value = targetThreadId;
                    using (var dbReader1 = _command36.ExecuteReader())
                    {
                        if (dbReader1.Read())
                        {
                            _timeEndT = dbReader1.GetDateTime(1);
                        }
                    }
                    _parTrainIdn37.Value = sourceThreadId;
                    using (var dbReader1 = _command37.ExecuteReader())
                    {
                        if (dbReader1.Read())
                        {
                            _timeSttS = dbReader1.GetDateTime(1);
                        }
                    }
                    _parTrainIdn37.Value = targetThreadId;
                    using (var dbReader1 = _command37.ExecuteReader())
                    {
                        if (dbReader1.Read())
                        {
                            _timeSttT = dbReader1.GetDateTime(1);
                        }
                    }
                    if ((_timeSttS != DateTime.MinValue) && (_timeEndS != DateTime.MinValue)
                     && (_timeSttT != DateTime.MinValue) && (_timeEndT != DateTime.MinValue))
                    {
                        if ((_timeSttT >= _timeEndS) || (_timeSttS >= _timeEndT))
                        {
                            _parTrainIdnS24.Value = sourceThreadId;
                            _parTrainIdnT24.Value = targetThreadId;
                            _command24.ExecuteNonQuery();
                            _parTrainIdnS31.Value = sourceThreadId;
                            _parTrainIdnT31.Value = targetThreadId;
                            _command31.ExecuteNonQuery();
                            _parTrainIdnS32.Value = sourceThreadId;
                            _parTrainIdnT32.Value = targetThreadId;
                            _command32.ExecuteNonQuery();
                            transaction.Commit();
                            retString = "Нитки связаны.";
                        }
                        else
                        {
                            retString = "Эти нитки не могут быть связаны.";
                        }
                    }
                    else
                    {
                        retString = "Не все параметры определены.";
                    }
                }
                _command24.Dispose();
                _command31.Dispose();
                _command32.Dispose();
                _command36.Dispose();
                _command37.Dispose();
                connection.Close();
            }
            return retString;
        }

        //Дать номер поезду
        public string AssignTrainNumber(int threadId
                                       , string trainNumberPrefix, string trainNumber, string trainNumberSuffix
                                       , string StationCode)
        {
            StopMessForTrain(threadId);
            using (var connection = new FbConnection(_connectionString))
            {
                connection.Open();
                _command25 = new FbCommand(CommandText25);
                AddParametrsToCommand25();
                using (var transaction = connection.BeginTransaction())
                {
                    AssignConnectionAndTransactionToCommand(_command25, connection, transaction);
                    _parCommand25.Value = 11;
                    _parTrain_IdnH125.Value = threadId;
                    _parEv_NDOE125.Value = trainNumberPrefix;
                    _parTrain_NumH125.Value = trainNumber;
                    _parEv_NDOE225.Value = trainNumberSuffix;
                    _parEv_StationE125.Value = "TE" + StationCode;
                    _command25.ExecuteNonQuery();
                    transaction.Commit();
                }
                _command25.Dispose();
                connection.Close();
            }
            return "Команда передана в ГИД.";
        }
        //Связать справку с поездом
        /*
        0  Ms_Idn
        1  Ms_Time
        2  Ms_Station
        3  Train_Idn
        4  Train_Num
        5  Wr_Stt_Time
        6  Wr_Stp_Time
        7  St_Form
        8  Nm_Sost
        9  St_Dest
        10 Ms_Prop
        11 Stt_TimeH
        12 Stt_TimeM
        13 Machinist
        14 Wag_Coun
        15 Nt_Weight
        16 Gr_Weight
        17 Ms_Marker
        18 Train_Attr
        19 Loco_Series
        20 Loco_Num
        21 Wag_Loaded
        22 Wag_Empty
        23 Wag_NoWork
        24 Operation
        25 Flags
        */
        public string AssignMessageForTrain(int messageIdn, int trainIdn)
        {
            var retString = "";
            TrainMessage trainMessage = null;
            TrainIndex trainIndex = null;
            var actualTrain = new ActualTrain();
            using (var connection = new FbConnection(_connectionString))
            {
                connection.Open();
                _command48 = new FbCommand(CommandText48);
                _command48.Parameters.Add(_parMessIdn48);
                using (var transaction = connection.BeginTransaction())
                {
                    AssignConnectionAndTransactionToCommand(_command48, connection, transaction);
                    _parMessIdn48.Value = messageIdn;
                    using (var dbReader1 = _command48.ExecuteReader())
                    {
                        if (dbReader1.Read())
                        {
                            trainMessage = new TrainMessage();
                            trainIndex = new TrainIndex();
                            trainMessage.TrainIndex = trainIndex;
                            trainMessage.RawMessageRecId = dbReader1.GetInt32(0);
                            trainMessage.MessageTime = dbReader1.GetDateTime(1);
                            trainMessage.StationCode = dbReader1.GetString(2);
                            trainMessage.TrainNumber = int.Parse(dbReader1.GetString(4));
                            trainMessage.TrainIndex.Index1 = dbReader1.GetString(7);
                            trainMessage.TrainIndex.Index2 = dbReader1.GetString(8);
                            trainMessage.TrainIndex.Index3 = dbReader1.GetString(9);
                            trainMessage.TrainIndex.Index4 = dbReader1.GetString(18);
                            trainMessage.LocoSeries = dbReader1.GetString(19);
                            trainMessage.LocoNumber = dbReader1.GetString(20);
                            trainMessage.CrewStTimeH = dbReader1.GetInt32(11);
                            trainMessage.CrewStTimeM = dbReader1.GetInt32(12);
                            trainMessage.Machinist = dbReader1.GetString(13);
                            trainMessage.CWagCount = dbReader1.GetInt32(14);
                            trainMessage.NtWeight = dbReader1.GetInt32(15);
                            trainMessage.GrWeight = dbReader1.GetInt32(16);
                            trainMessage.WagCounts = new byte[3];
                            trainMessage.WagCounts[0] = (byte)dbReader1.GetInt16(21);
                            trainMessage.WagCounts[1] = (byte)dbReader1.GetInt16(22);
                            trainMessage.WagCounts[2] = (byte)dbReader1.GetInt16(23);
                            trainMessage.Operation = dbReader1.GetString(24);
                            trainMessage.Flags = dbReader1.GetString(25);
                        }
                    }
                }
                _command48.Dispose();
                connection.Close();
            }
            if (trainMessage != null)
            {
                actualTrain.TrainIdn = trainIdn;
                TrainMessage curMessage = GetActualMessage(actualTrain);
                if (curMessage == null)
                {//если до этого справка не была указана
                 //записываем новую
                    WriteNewMessForTrain(trainMessage, actualTrain);
                    retString = "Записана новая связанная справка.";
                }
                else
                {//если была
                 //заменяем
                    ChangeNewMessForTrain(trainMessage, actualTrain);
                    retString = "Связанная справка заменена.";
                }
                //Если у поезда отсутствует номер, присвоить
                using (var connection = new FbConnection(_connectionString))
                {
                    connection.Open();
                    _command49 = new FbCommand(CommandText49);
                    _command49.Parameters.Add(_parTrainIdn49);
                    using (var transaction = connection.BeginTransaction())
                    {
                        AssignConnectionAndTransactionToCommand(_command49, connection, transaction);
                        _parTrainIdn49.Value = trainIdn;
                        using (var dbReader1 = _command49.ExecuteReader())
                        {
                            if (dbReader1.Read())
                            {
                                if (String.IsNullOrEmpty(dbReader1.GetString(0)))
                                {
                                    AssignTrainNumber(trainIdn, "", trainMessage.TrainNumber.ToString(), "", "");
                                }
                            }
                        }
                        transaction.Commit();
                    }
                    _command49.Dispose();
                    connection.Close();
                }
            }
            else
            {
                retString = "Справка не найдена.";
            }
            return retString;
        }
        //Сообщить о переезде с пути на путь в ГИД
        public string RunTrackIoTrack(int trainIdn, string trackName, string stationCode)
        {
            string retString = "";
            using (var connection = new FbConnection(_connectionString))
            {
                connection.Open();
                _command38 = new FbCommand(CommandText38);
                _command39 = new FbCommand(CommandText39);
                _command40 = new FbCommand(CommandText40);
                _command41 = new FbCommand(CommandText41);
                //
                _command38.Parameters.Add(_parTrainIdn38);
                AddParametrsToCommand39();
                AddParametrsToCommand40();
                AddParametrsToCommand41();
                using (var transaction = connection.BeginTransaction())
                {
                    AssignConnectionAndTransactionToCommand(_command38, connection, transaction);
                    AssignConnectionAndTransactionToCommand(_command39, connection, transaction);
                    AssignConnectionAndTransactionToCommand(_command40, connection, transaction);
                    AssignConnectionAndTransactionToCommand(_command41, connection, transaction);
                    _parTrainIdn38.Value = trainIdn;
                    using (var dbReader1 = _command38.ExecuteReader())
                    {
                        if (dbReader1.Read())
                        {
                            int trackSost;
                            DateTime timeOutFree = DateTime.MaxValue;
                            DateTime timeInBuzy = DateTime.MinValue;
                            int _evType = dbReader1.GetInt32(0);
                            DateTime evTime = dbReader1.GetDateTime(1);
                            string evStat = dbReader1.GetString(2);
                            string evTrack = dbReader1.GetString(3);
                            string tmpTrc;
                            DateTime TimeOut = DateTime.Now - new TimeSpan(0, 0, 30);
                            DateTime TimeIn = DateTime.Now;
                            if ((_evType != 3) && (evStat == "TE" + stationCode) && (evTrack != ""))
                            {
                                _parStation39.Value = evStat;
                                _parTrack39.Value = evTrack + "%";
                                _parTime39.Value = evTime + new TimeSpan(0, 1, 0);//???
                                using (var dbReader2 = _command39.ExecuteReader())
                                {
                                    while (dbReader2.Read())
                                    {
                                        tmpTrc = GetTrack(evTrack, dbReader2.GetString(2));
                                        if (tmpTrc == "") { continue; }
                                        evTrack = tmpTrc;
                                        trackSost = dbReader2.GetInt32(1);
                                        if (trackSost == 5)
                                        {
                                            timeOutFree = dbReader2.GetDateTime(0);
                                        }
                                        break;
                                    }
                                }
                                _parStation39.Value = evStat;
                                _parTrack39.Value = trackName + "%";
                                _parTime39.Value = evTime;
                                using (var dbReader2 = _command39.ExecuteReader())
                                {
                                    while (dbReader2.Read())
                                    {
                                        tmpTrc = GetTrack(trackName, dbReader2.GetString(2));
                                        if (tmpTrc == "") { continue; }
                                        trackSost = dbReader2.GetInt32(1);
                                        if (trackSost == 4)
                                        {
                                            trackName = tmpTrc;
                                            timeInBuzy = dbReader2.GetDateTime(0);
                                        }
                                        break;
                                    }
                                }
                                if (timeInBuzy == DateTime.MinValue)
                                {
                                    _parStation40.Value = evStat;
                                    _parTrack40.Value = trackName + "%";
                                    _parTime40.Value = evTime + new TimeSpan(0, 0, 1);
                                    using (var dbReader2 = _command40.ExecuteReader())
                                    {
                                        while (dbReader2.Read())
                                        {
                                            tmpTrc = GetTrack(trackName, dbReader2.GetString(2));
                                            if (tmpTrc == "") { continue; }
                                            trackName = tmpTrc;
                                            trackSost = dbReader2.GetInt32(1);
                                            if (trackSost == 4)
                                            {
                                                timeInBuzy = dbReader2.GetDateTime(0);
                                            }
                                            break;
                                        }
                                    }
                                }
                                if (timeInBuzy != DateTime.MinValue)
                                {
                                    //путь прибытия занялся
                                    if (timeInBuzy < evTime)
                                    {
                                        //до события прибытия
                                        if (timeOutFree < DateTime.MaxValue)
                                        {
                                            //путь отправления освободился, тогда ...
                                            TimeOut = timeOutFree;
                                            TimeIn = TimeOut + new TimeSpan(0, 0, 30);
                                        }
                                    }
                                    else
                                    {
                                        //после события прибытия
                                        TimeIn = timeInBuzy;
                                        if (timeInBuzy < timeOutFree)
                                        {
                                            //но раньше освобождения пути отправления
                                            TimeOut = TimeIn - new TimeSpan(0, 0, 30);
                                        }
                                        else
                                        {
                                            //если позже освобожденния пути отправления
                                            TimeOut = timeOutFree;
                                        }
                                    }
                                    //Дать сообщения о переезде с пути на путь
                                    _parSMStation41.Value = evStat;
                                    _parMsType41.Value = 14;
                                    _parEvTime41.Value = TimeOut;
                                    _parMsTime41.Value = TimeOut;
                                    _parBOType41.Value = 3;
                                    _parBOName41.Value = evTrack;
                                    _parDOType41.Value = 3;
                                    _parDOName41.Value = trackName;
                                    _parDopIdn41.Value = -1;
                                    _command41.ExecuteNonQuery();
                                    _parSMStation41.Value = evStat;
                                    _parMsType41.Value = 12;
                                    _parEvTime41.Value = TimeIn;
                                    _parMsTime41.Value = TimeIn;
                                    _parBOType41.Value = 3;
                                    _parBOName41.Value = trackName;
                                    _parDOType41.Value = 3;
                                    _parDOName41.Value = evTrack;
                                    _parDopIdn41.Value = -1;
                                    _command41.ExecuteNonQuery();
                                    retString = "Сообщения о переезде с пути на путь отосланы в ГИД.";
                                }
                                else
                                {
                                    retString = "Не определено время занятия пути переезда.";
                                }
                            }
                            else
                            {
                                retString = "Последнее событие поезда не является прибытием на путь указанной станции.";
                            }
                        }
                        else
                        {
                            retString = "Не найдено последнее событие поезда.";
                        }
                    }
                    transaction.Commit();
                }
                _command38.Dispose();
                _command39.Dispose();
                _command40.Dispose();
                _command41.Dispose();
                connection.Close();
            }
            return retString;
        }
        //Управление векторами обработки поездов
        public string TrainProcess(TrainProcessCommand trainProcessCommand)
        {
            string retString = "";
            using (var connection = new FbConnection(_connectionString))
            {
                connection.Open();
                _command25 = new FbCommand(CommandText25);
                AddParametrsToCommand25();
                using (var transaction = connection.BeginTransaction())
                {
                    AssignConnectionAndTransactionToCommand(_command25, connection, transaction);
                    //Приспособа под TrainsGrZ
                    switch (trainProcessCommand.Command)
                    {
                        case 0:
                            _parCommand25.Value = 13;
                            break;
                        case 1:
                            _parCommand25.Value = 14;
                            break;
                        case 2:
                            _parCommand25.Value = 16;
                            break;
                        default:
                            _parCommand25.Value = -1;
                            break;
                    }
                    //
                    _parEv_StationE125.Value = "TE" + trainProcessCommand.StationCdode;
                    _parEV_AXISE125.Value = trainProcessCommand.Track;
                    _parEV_TIMEE125.Value = DateTime.Now;
                    _parI_ST_FORMH125.Value = trainProcessCommand.TrainPrefix;
                    _parTrain_NumH125.Value = trainProcessCommand.TrainNubmer;
                    _parI_ST_DESTH125.Value = trainProcessCommand.TrainSuffix;
                    _parEv_NDOE125.Value = trainProcessCommand.Remark;
                    _parEv_NDOE225.Value = trainProcessCommand.NeibStation;
                    _parREZERVH125.Value = trainProcessCommand.SubCommand;
                    //Это АНАХРЕНИЗМ, лучше подкорректировать (роспуск) в TrainsGrZ !!!
                    if (trainProcessCommand.Command == 1)
                    {
                        switch (trainProcessCommand.SubCommand)
                        {
                            case 1:
                                _parREZERVH125.Value = 3;
                                break;
                            case 2:
                                _parREZERVH125.Value = 1;
                                break;
                            case 3:
                                _parREZERVH125.Value = 2;
                                break;
                        }
                    }
                    //
                    _command25.ExecuteNonQuery();
                    transaction.Commit();
                    retString = "Команда управления обработкой отослана в ГИД.";
                }
                _command25.Dispose();
                connection.Close();
            }
            return retString;
        }

        //Определить путь прибытия
        public string SetTrackIn(int trainIdn, string trackName, string stationCode)
        {
            string retString = "";
            using (var connection = new FbConnection(_connectionString))
            {
                connection.Open();
                _command38 = new FbCommand(CommandText38);
                _command39 = new FbCommand(CommandText39);
                _command40 = new FbCommand(CommandText40);
                _command43 = new FbCommand(CommandText43);
                //
                _command38.Parameters.Add(_parTrainIdn38);
                AddParametrsToCommand39();
                AddParametrsToCommand40();
                AddParametrsToCommand43();
                using (var transaction = connection.BeginTransaction())
                {
                    AssignConnectionAndTransactionToCommand(_command38, connection, transaction);
                    AssignConnectionAndTransactionToCommand(_command39, connection, transaction);
                    AssignConnectionAndTransactionToCommand(_command40, connection, transaction);
                    AssignConnectionAndTransactionToCommand(_command43, connection, transaction);
                    _parTrainIdn38.Value = trainIdn;
                    using (var dbReader1 = _command38.ExecuteReader())
                    {
                        if (dbReader1.Read())
                        {
                            int trackSost;
                            DateTime timeInBuzy = DateTime.MaxValue;
                            int evType = dbReader1.GetInt32(0);
                            DateTime evTime = dbReader1.GetDateTime(1);
                            string evStat = dbReader1.GetString(2);
                            int evIdn = dbReader1.GetInt32(4);
                            string tmpTrc;
                            DateTime TimeIn = DateTime.MaxValue;
                            if ((evType != 3) && (evStat == "TE" + stationCode))
                            {
                                _parStation39.Value = evStat;
                                _parTrack39.Value = trackName + "%";
                                _parTime39.Value = evTime - new TimeSpan(0, 0, 1);
                                using (var dbReader2 = _command39.ExecuteReader())
                                {
                                    while (dbReader2.Read())
                                    {
                                        tmpTrc = GetTrack(trackName, dbReader2.GetString(2));
                                        if (tmpTrc == "") { continue; }
                                        trackSost = dbReader2.GetInt32(1);
                                        DateTime tmpT = dbReader2.GetDateTime(0);
                                        if (trackSost == 4)
                                        {
                                            timeInBuzy = dbReader2.GetDateTime(0);
                                            if ((timeInBuzy - evTime) < new TimeSpan(0, 20, 0))
                                            {
                                                TimeIn = timeInBuzy;
                                            }
                                            break;
                                        }
                                    }
                                }
                                if (TimeIn == DateTime.MaxValue)
                                {
                                    _parStation40.Value = evStat;
                                    _parTrack40.Value = trackName + "%";
                                    _parTime40.Value = evTime;
                                    using (var dbReader2 = _command40.ExecuteReader())
                                    {
                                        while (dbReader2.Read())
                                        {
                                            tmpTrc = GetTrack(trackName, dbReader2.GetString(2));
                                            if (tmpTrc == "") { continue; }
                                            trackSost = dbReader2.GetInt32(1);
                                            if (trackSost == 4)
                                            {
                                                timeInBuzy = dbReader2.GetDateTime(0);
                                                if ((evTime - timeInBuzy) < new TimeSpan(0, 5, 0))
                                                {
                                                    TimeIn = timeInBuzy;
                                                }
                                            }
                                            break;
                                        }
                                    }
                                }
                                if (TimeIn == DateTime.MaxValue)
                                {
                                    TimeIn = evTime;
                                }
                                _parEvIdn43.Value = evIdn;
                                _parTrack43.Value = trackName;
                                _parTime43.Value = TimeIn;
                                _command43.ExecuteNonQuery();
                                retString = "Путь прибытия определен.";
                            }
                            else
                            {
                                retString = "Последнее событие поезда не является прибытием на указанную станцию.";
                            }
                        }
                        else
                        {
                            retString = "Не найдено последнее событие поезда.";
                        }
                    }
                    transaction.Commit();
                }
                _command38.Dispose();
                _command39.Dispose();
                _command40.Dispose();
                _command43.Dispose();
                connection.Close();
            }
            return retString;
        }
        //Маркировать поезд
        public string MarkTrain(int trainIdn, string strMarker)
        {
            string retString = "";
            using (var connection = new FbConnection(_connectionString))
            {
                connection.Open();
                _command44 = new FbCommand(CommandText44);
                //
                _command44.Parameters.Add(_parTrainIdn44);
                _command44.Parameters.Add(_parMarker44);
                using (var transaction = connection.BeginTransaction())
                {
                    AssignConnectionAndTransactionToCommand(_command44, connection, transaction);
                    _parTrainIdn44.Value = trainIdn;
                    string tmpS = "";
                    if (strMarker.Length > 8)
                    {
                        tmpS = strMarker.Substring(0, 8);
                    }
                    else if (strMarker.Length > 0)
                    {
                        tmpS = strMarker;
                    }
                    else
                    {
                        //tmpS = "Блок.";
                    }
                    _parMarker44.Value = tmpS;
                    _command44.ExecuteNonQuery();
                    transaction.Commit();
                    retString = "Поезд отмаркирован.";
                }
                _command44.Dispose();
                connection.Close();
            }
            return retString;
        }
        //Маркировать справку
        public string MarkMessage(int messageIdn, string strMarker)
        {
            string retString = "";
            using (var connection = new FbConnection(_connectionString))
            {
                connection.Open();
                _command45 = new FbCommand(CommandText45);
                //
                _command45.Parameters.Add(_parMessIdn45);
                _command45.Parameters.Add(_parMarker45);
                using (var transaction = connection.BeginTransaction())
                {
                    AssignConnectionAndTransactionToCommand(_command45, connection, transaction);
                    _parMessIdn45.Value = messageIdn;
                    string tmpS = "";
                    if (strMarker.Length > 8)
                    {
                        tmpS = strMarker.Substring(0, 8);
                    }
                    else if (strMarker.Length > 0)
                    {
                        tmpS = strMarker;
                    }
                    else
                    {
                        //tmpS = "Блок.";
                    }
                    _parMarker45.Value = tmpS;
                    _command45.ExecuteNonQuery();
                    transaction.Commit();
                    retString = "Справка отмаркирована.";
                }
                _command45.Dispose();
                connection.Close();
            }
            return retString;
        }
        //Отвязать справку от поезда
        public string StopMessForTrain(int trainIdn)
        {
            string retString = "";
            /*
            using (var connection = new FbConnection(_connectionString)) {
              connection.Open();
              using (var transaction = connection.BeginTransaction()) {
                AssignConnectionAndTransactionToCommand(_command46, connection, transaction);
                AssignConnectionAndTransactionToCommand(_command47, connection, transaction);
                _parTrainIdn46.Value = trainIdn;
                _command46.ExecuteNonQuery();
                _parTrainIdn47.Value = trainIdn;
                _command47.ExecuteNonQuery();
                transaction.Commit();
                retString = "Справка отвязана от поезда.";
              }
              connection.Close();
            }
            */
            using (var connection = new FbConnection(_connectionString))
            {
                connection.Open();
                _command46 = new FbCommand(CommandText46);
                _command46.Parameters.Add(_parTrainIdn46);
                using (var transaction = connection.BeginTransaction())
                {
                    AssignConnectionAndTransactionToCommand(_command46, connection, transaction);
                    _parTrainIdn46.Value = trainIdn;
                    _command46.ExecuteNonQuery();
                    transaction.Commit();
                }
                _command46.Dispose();
                connection.Close();
            }
            //using (var connection = new FbConnection(_connectionString))
            //{
            //    connection.Open();
            //    _command47 = new FbCommand(CommandText47);
            //    _command47.Parameters.Add(_parTrainIdn47);
            //    using (var transaction = connection.BeginTransaction())
            //    {
            //        AssignConnectionAndTransactionToCommand(_command47, connection, transaction);
            //        _parTrainIdn47.Value = trainIdn;
            //        //_command47.ExecuteNonQuery(); - ???
            //        transaction.Commit();
            //    }
            //    _command47.Dispose();
            //    connection.Close();
            //}
            return retString;
        }
        //Записать прибытие поезда
        public string WriteTrainInput(string stationCode, string trackName, string destName)
        {
            string retString = "";
            using (var connection = new FbConnection(_connectionString))
            {
                connection.Open();
                _command40 = new FbCommand(CommandText40);
                _command41 = new FbCommand(CommandText41);
                //
                AddParametrsToCommand40();
                AddParametrsToCommand41();
                using (var transaction = connection.BeginTransaction())
                {
                    AssignConnectionAndTransactionToCommand(_command40, connection, transaction);
                    AssignConnectionAndTransactionToCommand(_command41, connection, transaction);
                    string tmpTrc;
                    int trackSost;
                    DateTime timeInBuzy = DateTime.MaxValue;
                    DateTime timeInFree = DateTime.MaxValue;
                    //Ищем занятие пути назад от текущего времени
                    _parStation40.Value = "TE" + stationCode;
                    _parTrack40.Value = trackName + "%";
                    _parTime40.Value = DateTime.Now;
                    using (var dbReader1 = _command40.ExecuteReader())
                    {
                        while (dbReader1.Read())
                        {
                            tmpTrc = GetTrack(trackName, dbReader1.GetString(2));
                            if (tmpTrc == "") { continue; }
                            trackSost = dbReader1.GetInt32(1);
                            if (trackSost == 4)
                            {
                                timeInBuzy = dbReader1.GetDateTime(0);
                                trackName = tmpTrc;
                                break;
                            }
                            else if (trackSost == 5)
                            {
                                timeInFree = dbReader1.GetDateTime(0);
                                if ((DateTime.Now - timeInFree) > new TimeSpan(0, 5, 0))
                                {
                                    break;
                                }
                                continue;
                            }
                            else { break; }
                        }
                    }
                    if (timeInBuzy < DateTime.MaxValue)
                    {
                        //Записать прибытие
                        _parSMStation41.Value = "TE" + stationCode;
                        _parMsType41.Value = 16;
                        _parEvTime41.Value = timeInBuzy;
                        _parMsTime41.Value = timeInBuzy;
                        _parBOType41.Value = 3;
                        _parBOName41.Value = trackName;
                        _parDOType41.Value = 5;
                        _parDOName41.Value = destName;
                        _parDopIdn41.Value = -1;
                        _command41.ExecuteNonQuery();
                        retString = "Прибытие записано.";
                    }
                    else
                    {
                        retString = "Не определено время занятия пути прибытия.";
                    }
                    transaction.Commit();
                }
                _command40.Dispose();
                _command41.Dispose();
                connection.Close();
            }
            return retString;
        }
        //Записать отправление поезда
        public string WriteTrainOutput(string stationCode, string trackName, string destName)
        {
            string retString = "";
            using (var connection = new FbConnection(_connectionString))
            {
                connection.Open();
                _command41 = new FbCommand(CommandText41);
                _command50 = new FbCommand(CommandText50);
                AddParametrsToCommand41();
                AddParametrsToCommand50();
                using (var transaction = connection.BeginTransaction())
                {
                    AssignConnectionAndTransactionToCommand(_command41, connection, transaction);
                    AssignConnectionAndTransactionToCommand(_command50, connection, transaction);
                    DateTime timeOutBuzy = DateTime.MaxValue;
                    //Просматриваем состояния блок-участка назад от текущего времени
                    _parStation50.Value = "TE" + stationCode;
                    _parTrack50.Value = destName;
                    _parTime50.Value = DateTime.Now;
                    using (var dbReader1 = _command50.ExecuteReader())
                    {
                        while (dbReader1.Read())
                        {
                            int blokSost = dbReader1.GetInt32(1);
                            if (blokSost == 13)
                            {
                                timeOutBuzy = dbReader1.GetDateTime(0);
                                break;
                            }
                            if (blokSost == 14)
                            {
                                continue;
                            }
                            if (blokSost == 15)
                            {
                                break;
                            }
                        }
                    }
                    //if ((timeOutBuzy != DateTime.MaxValue) && ((DateTime.Now - timeOutBuzy) > new TimeSpan(0, 0, 30))) {
                    if (timeOutBuzy != DateTime.MaxValue)
                    {
                        //Записать отправление
                        _parSMStation41.Value = "TE" + stationCode;
                        _parMsType41.Value = 14;
                        _parEvTime41.Value = timeOutBuzy - new TimeSpan(0, 1, 0);
                        _parMsTime41.Value = DateTime.Now;
                        _parBOType41.Value = 3;
                        _parBOName41.Value = trackName;
                        _parDOType41.Value = 5;
                        _parDOName41.Value = destName;
                        _parDopIdn41.Value = -1;
                        _command41.ExecuteNonQuery();
                        retString = "Отправление записано.";
                    }
                    transaction.Commit();
                }
                _command41.Dispose();
                _command50.Dispose();
                connection.Close();
            }
            return retString;
        }
        //События контрольных точек перегона (записываем)
        public string TrackPointMessages(IList<TrackPointMessage> trackPointMessages)
        {
            string retString = "";
            using (var connection = new FbConnection(_connectionString))
            {
                connection.Open();
                _command41 = new FbCommand(CommandText41);
                AddParametrsToCommand41();
                using (var transaction = connection.BeginTransaction())
                {
                    AssignConnectionAndTransactionToCommand(_command41, connection, transaction);
                    try
                    {
                        foreach (var trackPointMessage in trackPointMessages)
                        {
                            _parMsType41.Value = trackPointMessage.MsType;
                            _parEvTime41.Value = DateTime.Now;
                            _parBOType41.Value = trackPointMessage.StCodeStart;
                            _parDOType41.Value = trackPointMessage.StCodeStop;
                            _parBOName41.Value = trackPointMessage.SpanTrack;
                            _parDOName41.Value = trackPointMessage.PointName;
                            _parSMStation41.Value = trackPointMessage.TrPointStart.ToString()
                                            + " " + trackPointMessage.Direction;
                            _parDopIdn41.Value = trackPointMessage.TrPointStop;
                            _command41.ExecuteNonQuery();
                        }
                        retString = "События контрольных точек записаны.";
                    }
                    catch (Exception exception)
                    {
                        retString = exception.ToString();
                    }
                    _command41.Dispose();
                    transaction.Commit();
                }
                connection.Close();
            }
            return retString;
        }
        //Записать плановую нитку и связать ее с исполненной
        public string BindPlanToTrain(IList<GIDMessage> planEvents, int trainIdn)
        {
            string retString = "";
            var trainIdnBuffer = DeleteRepeatPlanToTrain(planEvents);
            if (trainIdn == 0)
            //    DelLinkedPlWire(trainIdn);
            //else
                trainIdn = trainIdnBuffer;
            //
            int planIdn = WritePlanWire(planEvents);
            using (var connection = new FbConnection(_connectionString))
            {
                connection.Open();
                _command25 = new FbCommand(CommandText25);
                AddParametrsToCommand25();
                using (var transaction = connection.BeginTransaction())
                {
                    AssignConnectionAndTransactionToCommand(_command25, connection, transaction);
                    _parCommand25.Value = 35;
                    _parTrain_IdnH125.Value = planIdn;
                    _parTrain_IdnH225.Value = trainIdn;
                    _command25.ExecuteNonQuery();
                    //_parCommand25.Value = 38;
                    //_command25.ExecuteNonQuery();//!!!
                    transaction.Commit();
                    retString = planIdn.ToString();
                }
                _command25.Dispose();
                connection.Close();
            }
            return retString;
        }

        //Поиск и удаление повторных плановых ниток схожих с искомой 
        public int DeleteRepeatPlanToTrain(IList<GIDMessage> planEvents)
        {
            int executedTrainId = 0;
            if(planEvents != null && planEvents.Count > 0)
            {
                using (var connection = new FbConnection(_connectionString))
                {
                    connection.Open();
                    //
                    _command62 = new FbCommand(CommandText62);
                    _command62.Parameters.Add(_parTrainIdn62);
                    //
                    _command85 = new FbCommand(CommandText85);
                    AddParametrsToCommand85(planEvents.Select(x => x.MsStation));
                    _parTrainNum85.Value = planEvents.First().TrainNum;
                    //
                    _command86 = new FbCommand(CommandText86);
                    _command86.Parameters.Add(_parTrainIdn86);
                    //
                    _command63 = new FbCommand(CommandText63);
                    _command63.Parameters.Add(_parTrainIdn63);
                    _command63.Parameters.Add(_parNormIdn63);
                    using (var transaction = connection.BeginTransaction())
                    {
                        AssignConnectionAndTransactionToCommand(_command62, connection, transaction);
                        AssignConnectionAndTransactionToCommand(_command63, connection, transaction);
                        AssignConnectionAndTransactionToCommand(_command85, connection, transaction);
                        AssignConnectionAndTransactionToCommand(_command86, connection, transaction);
                        using (var dbReader1 = _command85.ExecuteReader())
                        {
                            while (dbReader1.Read())
                            {
                                var eventTime = dbReader1.GetDateTime(3);
                                var eventStation = dbReader1.GetString(2);
                                var fl_sost = dbReader1.GetInt16SafelyOr0(0);
                                var train_Idn = dbReader1.GetInt32(1);
                                var eventTimePlan = planEvents.Where(x => x.MsStation == eventStation).FirstOrDefault().MsTime;
                                if((eventTime >= eventTimePlan && (eventTime - eventTimePlan).TotalHours <=1) || (eventTimePlan >= eventTime && (eventTimePlan - eventTime).TotalHours <= 1))
                                {
                                    //удаляем плановую нитку
                                    _parTrainIdn62.Value = train_Idn;
                                    _command62.ExecuteNonQuery();
                                    //если нитка связана с исполненной находим ее Id
                                    if (fl_sost == 2)
                                    {
                                        _parTrainIdn86.Value = train_Idn;
                                       var trainIdExecuted =  _command86.ExecuteScalar();
                                        if(trainIdExecuted != null)
                                        {
                                            executedTrainId = Convert.ToInt32(trainIdExecuted);
                                            //
                                            _parTrainIdn63.Value = executedTrainId;
                                            _parNormIdn63.Value = 0;
                                            _command63.ExecuteNonQuery();
                                        }
                                    }
                                }
                            }
                        }
                        transaction.Commit();
                    }
                    //
                    _command62.Dispose();
                    _command63.Dispose();
                    _command85.Dispose();
                    _command86.Dispose();
                    connection.Close();
                }
            }
            //
            return executedTrainId;
        }
        //Установить флаг исполнения задания
        public string SetDefSendFlag(int defIdn, int sendFlag, DateTime tmDefC)
        {
            string retString = "";
            using (var connection = new FbConnection(_connectionString))
            {
                connection.Open();
                _command67 = new FbCommand(CommandText67);
                _command67.Parameters.Add(_parDefIdn67);
                _command67.Parameters.Add(_parSndFlag67);
                _command67.Parameters.Add(_parTmDefC67);
                using (var transaction = connection.BeginTransaction())
                {
                    AssignConnectionAndTransactionToCommand(_command67, connection, transaction);
                    _parDefIdn67.Value = defIdn;
                    _parSndFlag67.Value = sendFlag;
                    _parTmDefC67.Value = tmDefC;
                    _command67.ExecuteNonQuery();
                    transaction.Commit();
                }
                _command67.Dispose();
                connection.Close();
            }
            return retString;
        }
        /// <summary>
        /// очищаем плановый график и команды
        /// </summary>
        /// <returns></returns>
        public string CleanPlan()
        {
            string retString = "";
            using (var connection = new FbConnection(_connectionString))
            {
                connection.Open();
                _command87 = new FbCommand(CommandText87);
                _command88 = new FbCommand(CommandText88);
                _command89 = new FbCommand(CommandText89);
                using (var transaction = connection.BeginTransaction())
                {
                    AssignConnectionAndTransactionToCommand(_command87, connection, transaction);
                    AssignConnectionAndTransactionToCommand(_command88, connection, transaction);
                    AssignConnectionAndTransactionToCommand(_command89, connection, transaction);
                    _command87.ExecuteNonQuery();
                    _command88.ExecuteNonQuery();
                    _command89.ExecuteNonQuery();
                    retString = "Удален плановый график";
                    transaction.Commit();
                }
                _command87.Dispose();
                _command88.Dispose();
                _command89.Dispose();
                connection.Close();
            }
            return retString;
        }

        //Записать ответы от ИАС
        public string SetReplys(IList<string> replys)
        {
            string retString;
            try
            {
                using (var connection = new SqlConnection(_connectionStringBuh))
                {
                    connection.Open();
                    _command77 = new SqlCommand(CommandText77);
                    _command77.Parameters.Add(_parReplyText77);
                    using (var transaction = connection.BeginTransaction())
                    {
                        AssignConnectionAndTransactionToCommandSql(_command77, connection, transaction);
                        foreach (var reply in replys)
                        {
                            _parReplyText77.Value = reply;
                            _command77.ExecuteNonQuery();
                        }
                        transaction.Commit();
                    }
                    _command77.Dispose();
                    connection.Close();
                    retString = "Сообщения приняты.";
                }
            }
            catch (Exception e)
            {
                string err = e.ToString();
                retString = string.Empty;
            }
            return retString;
        }
        //Записать сообщение 20х (Буг-2) в базу Буг-3
        public string WriteBuh2Data(Buh2DataCommand buh2DataCommand)
        {
            string retString = "";
            using (var connection = new SqlConnection(_connectionStringBuh))
            {
                connection.Open();
                _command81 = new SqlCommand(CommandText81);
                _command82 = new SqlCommand(CommandText82);
                //
                AddParametrsToCommand81();
                AddParametrsToCommand82();
                using (var transaction = connection.BeginTransaction())
                {
                    AssignConnectionAndTransactionToCommandSql(_command81, connection, transaction);
                    AssignConnectionAndTransactionToCommandSql(_command82, connection, transaction);
                    _parMessIdn81.Value = buh2DataCommand.MessageIdn;
                    _parStation81.Value = buh2DataCommand.Station;
                    _parNsuNumber81.Value = buh2DataCommand.NsuNumber;
                    _parMessTime81.Value = buh2DataCommand.MessageTime;
                    _parDestination81.Value = buh2DataCommand.Direction;
                    _parLocoSeries81.Value = buh2DataCommand.LocoSeries;
                    _parLocoNumber81.Value = buh2DataCommand.LocoNumber;
                    _command81.ExecuteNonQuery();
                    _parMessIdn82.Value = buh2DataCommand.MessageIdn;
                    _parTrainIndex82.Value = buh2DataCommand.TrainIndex;
                    _parTrainNumber82.Value = buh2DataCommand.TrainNumber;
                    _parFlags82.Value = "3";
                    _command82.ExecuteNonQuery();
                    transaction.Commit();
                    retString = "Сообщение Буг-2 записано.";
                }
                _command81.Dispose();
                _command82.Dispose();
                connection.Close();
            }
            return retString;
        }
        //Внутренние функции---------------------------------------------------------------------------
        //
        public void WriteAllSaipsDataToGid()
        {
            int i = 0;
            foreach (var section in _buhSections)
            {
                _buhSections[i].CurStartTime = WriteSaipsDataToGid(section.RewriteStation
                                                                  , section.NsuNumber, section.CurStartTime);
                i++;
            }
        }
        //
        public DateTime WriteSaipsDataToGid(string stationCode, int nsuNum, DateTime startTime)
        {
            DateTime stopTime = GetTimeGIDStop();
            if (stopTime == DateTime.MaxValue)
            {
                return startTime;
            }
            using (var connection = new SqlConnection(_connectionStringBuh))
            using (var connection1 = new FbConnection(_connectionString))
            {
                connection.Open(); connection1.Open();
                _command41 = new FbCommand(CommandText41);
                _command80 = new SqlCommand(CommandText80);
                AddParametrsToCommand41();
                AddParametrsToCommand80();
                //
                using (var transaction = connection.BeginTransaction())
                using (var transaction1 = connection1.BeginTransaction())
                {
                    AssignConnectionAndTransactionToCommandSql(_command80, connection, transaction);
                    AssignConnectionAndTransactionToCommand(_command41, connection1, transaction1);
                    _parStation80.Value = stationCode;
                    _parNsuNumber80.Value = nsuNum;
                    _parMessTimeStt80.Value = startTime;
                    _parMessTimeStp80.Value = stopTime - new TimeSpan(0, 10, 0);
                    using (var dbReader1 = _command80.ExecuteReader())
                    {
                        while (dbReader1.Read())
                        {
                            int messIdn = dbReader1.GetInt32(0);
                            startTime = dbReader1.GetDateTime(1);
                            int destination = dbReader1.GetInt16(2);
                            var trainIndex = dbReader1.GetString(3);
                            var trainNumber = dbReader1.GetString(4);
                            var locoSeries = "";
                            var locoNumber = "";
                            if (!dbReader1.IsDBNull(5))
                            {
                                locoSeries = dbReader1.GetString(5);
                                locoNumber = dbReader1.GetString(6);
                            }
                            var category = "";
                            if (!dbReader1.IsDBNull(7))
                            {
                                category = dbReader1.GetString(7);
                            }
                            _parSMStation41.Value = stationCode + " " + trainIndex;
                            _parMsType41.Value = 202; if (category == "3") { _parMsType41.Value = 206; }
                            _parEvTime41.Value = startTime;
                            _parMsTime41.Value = stopTime;
                            _parBOType41.Value = destination;
                            _parBOName41.Value = trainNumber;
                            _parDOType41.Value = nsuNum;
                            //_parDOName41.Value    = locoSeries + " " + locoNumber;
                            string ss = locoNumber;
                            if (ss.Length == 5) { ss = ss.Remove(4, 1); }
                            if (ss.Length > 0)
                            {
                                while (ss.Substring(0, 1) == "0") { ss = ss.Remove(0, 1); }
                            }
                            _parDOName41.Value = locoSeries + " " + ss;
                            _parDopIdn41.Value = messIdn;
                            _command41.ExecuteNonQuery();
                        }
                    }
                    transaction1.Commit();
                }
                _command41.Dispose();
                _command80.Dispose();
                connection.Close(); connection1.Close();
            }
            return startTime;
        }
        //Получить время первой коллизии поезда
        public DateTime GetTmStartCollByTrain(int trainIdn)
        {
            DateTime retTime = DateTime.MinValue;
            using (var connection = new FbConnection(_connectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    AssignConnectionAndTransactionToCommand(_command74, connection, transaction);
                    _parTrainIdn74.Value = trainIdn;
                    using (var dbReader1 = _command74.ExecuteReader())
                    {
                        if (dbReader1.Read())
                        {
                            retTime = dbReader1.GetDateTime(0);
                        }
                    }
                }
                connection.Close();
            }
            return retTime;
        }
        //Есть ли конфликты на перегоне?
        public bool FindSpanConflict(IList<TrainEvent> trainEvents
                                    , ComDefinition comDefinition, int plnEventId)
        {
            GIDMessage planEvent = null;
            DateTime ownTimeOut = DateTime.MinValue;
            ComDefinition comDefinitionNear = null;
            if (comDefinition.ObSttType == 5)
            {
                //Если готовится команда на прибытие
                planEvent = GetNearPlnEvent(plnEventId, 0);
                //предыдущее плановое событие (отправление) нашего поезда
                if (planEvent == null) { return true; }
                //вышел ли уже наш поезд на перегон прибытия?
                if (planEvent.MsStation.Contains("TE"))
                {
                    planEvent.MsStation = planEvent.MsStation.Remove(0, 2);
                }
                foreach (var trainEvent in trainEvents)
                {
                    if ((trainEvent.EventType == 3)
                      && (trainEvent.EventStation == planEvent.MsStation)
                      && (trainEvent.DObjName == planEvent.MsAxis))
                    {
                        if (trainEvent.TrainNumber == comDefinition.TrainNum)
                        {
                            //вышел
                            //время отправления нашего поезда
                            ownTimeOut = trainEvent.EventTime;
                            break;
                        }
                    }
                }
                if (ownTimeOut == DateTime.MinValue)
                {
                    //не вышел, а существует ли задание для отправления?
                    comDefinitionNear = GetDefByPlnIdn(planEvent.MsIdn);
                    if (comDefinitionNear == null)
                    {
                        return false;// true;???
                    }
                    //существует
                    if (comDefinitionNear.FlSnd < 4)
                    {//!!!
                     //но оно пока не выполняется
                        return true;
                    }
                    //наш поезд (как минимум) пытаются отправить на перегон
                }
                //кто на перегоне?
                foreach (var trainEvent in trainEvents)
                {
                    if ((trainEvent.EventType == 3)
                      && (trainEvent.EventStation == planEvent.MsStation)
                      && (trainEvent.DObjName == planEvent.MsAxis))
                    {
                        if (ownTimeOut == DateTime.MinValue)
                        {
                            //перегон кем-то занят, а нашего поезда там нет
                            return true;
                        }
                        if (trainEvent.TrainNumber != comDefinition.TrainNum)
                        {
                            if (trainEvent.EventTime < ownTimeOut)
                            {
                                //кто-то движется перед нашим поездом (ждем)
                                return true;
                            }
                        }
                    }
                }
            }
            if (comDefinition.ObStpType == 5)
            {
                planEvent = GetNearPlnEvent(plnEventId, 1);
                if (planEvent == null)
                {
                    //бред, такой нитки быть не может!
                    return true;
                }
                if (planEvent.MsStation.Contains("TE"))
                {
                    planEvent.MsStation = planEvent.MsStation.Remove(0, 2);
                }
                //кто-нибудь отправился на этот перегон с соседней станции?
                foreach (var trainEvent in trainEvents)
                {
                    if ((trainEvent.EventType == 3)
                      && (trainEvent.EventStation == planEvent.MsStation)
                      && (trainEvent.DObjName == planEvent.MsAxis))
                    {
                        //перегон занят встречным.
                        return true;
                    }
                }
            }
            return false;
        }
        //Получить плановое событие по идентификатору
        public GIDMessage GetPlanEventByIdn(int plnEventId)
        {
            GIDMessage gidMessage = null;
            using (var connection = new FbConnection(_connectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    AssignConnectionAndTransactionToCommand(_command70, connection, transaction);
                    _parPlnEvIdn70.Value = plnEventId;
                    using (var dbReader1 = _command70.ExecuteReader())
                    {
                        if (dbReader1.Read())
                        {
                            //Пока используем этот класс
                            gidMessage = new GIDMessage();
                            //идентификатор плановой нитки
                            gidMessage.TrainIdn = dbReader1.GetInt32(4);
                            //флаг подтверждения события
                            gidMessage.FlCnfm = (!String.IsNullOrEmpty(dbReader1.GetString(0)))
                                                   ? Int32.Parse(dbReader1.GetString(0))
                                                   : 0;
                            //время
                            gidMessage.MsTime = dbReader1.GetDateTime(1);
                            //коллизии по станции
                            gidMessage.FlColSt = (!String.IsNullOrEmpty(dbReader1.GetString(2)))
                                                   ? Int32.Parse(dbReader1.GetString(2))
                                                   : 0;
                            //коллизии по перегону
                            gidMessage.FlColSp = (!String.IsNullOrEmpty(dbReader1.GetString(3)))
                                                   ? Int32.Parse(dbReader1.GetString(3))
                                                   : 0;
                        }
                    }
                }
                connection.Close();
            }
            return gidMessage;
        }
        //Получить предыдущее/последующее плановое событие относительно указанного
        public GIDMessage GetNearPlnEvent(int plnEventId, int dst)
        {
            GIDMessage planEvent = null;
            using (var connection = new FbConnection(_connectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    AssignConnectionAndTransactionToCommand(_command71, connection, transaction);
                    AssignConnectionAndTransactionToCommand(_command72, connection, transaction);
                    _parPlnEvIdn71.Value = plnEventId;
                    _parPlnEvIdn72.Value = plnEventId;
                    FbDataReader dbReader1 = null;
                    try
                    {
                        if (dst == 0)
                        {
                            dbReader1 = _command71.ExecuteReader();
                        }
                        else
                        {
                            dbReader1 = _command72.ExecuteReader();
                        }
                        if (dbReader1.Read())
                        {
                            //int evType = dbReader1.GetInt32(0);
                            planEvent = new GIDMessage();
                            planEvent.MsStation = dbReader1.GetString(1);
                            //пока используем это поле
                            planEvent.MsAxis = dbReader1.GetString(2);
                            planEvent.MsIdn = dbReader1.GetInt32(3);
                        }
                    }
                    finally
                    {
                        if (dbReader1 != null)
                        {
                            dbReader1.Close();//dbReader1 = null;
                        }
                    }
                }
                connection.Close();
            }
            return planEvent;
        }
        //Получить задание для планового события
        public ComDefinition GetDefByPlnIdn(int plnIdn)
        {
            ComDefinition comDefinition = null;
            using (var connection = new FbConnection(_connectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    AssignConnectionAndTransactionToCommand(_command73, connection, transaction);
                    _parPlnIdn73.Value = plnIdn;
                    using (var dbReader1 = _command73.ExecuteReader())
                    {
                        if (dbReader1.Read())
                        {
                            comDefinition = new ComDefinition
                            {
                                StdForm = dbReader1.GetInt16(0),
                                PlnEvIdn = dbReader1.GetInt32(1),
                                ComStartTime = dbReader1.GetDateTime(2),
                                FlSnd = dbReader1.GetInt16(3)
                            };
                        }
                    }
                }
                connection.Close();
            }
            return comDefinition;
        }
        //Получить задание по идентификатору
        public ComDefinition GetDefByDefIdn(int defIdn)
        {
            ComDefinition comDefinition = null;
            using (var connection = new FbConnection(_connectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    AssignConnectionAndTransactionToCommand(_command69, connection, transaction);
                    _parDefIdn69.Value = defIdn;
                    using (var dbReader1 = _command69.ExecuteReader())
                    {
                        if (dbReader1.Read())
                        {
                            comDefinition = new ComDefinition
                            {
                                StdForm = dbReader1.GetInt16(0),
                                PlnEvIdn = dbReader1.GetInt32(1),
                                ComStartTime = dbReader1.GetDateTime(2),
                                FlSnd = dbReader1.GetInt16(3)
                            };
                        }
                    }
                }
                connection.Close();
            }
            return comDefinition;
        }
        //Записать плановую нитку
        public int WritePlanWire(IList<GIDMessage> planEvents)
        {
            int planIdn = 0;
            string planNum = "";
            if (planEvents.Count == 0) { return planIdn; }
            GIDMessage planEventT = planEvents[0]; planNum = planEventT.TrainNum;
            using (var connection = new FbConnection(_connectionString))
            {
                connection.Open();
                _command64 = new FbCommand(CommandText64);
                AddParametrsToCommand64();
                _command65 = new FbCommand(CommandText65);
                AddParametrsToCommand65();
                _command66 = new FbCommand(CommandText66);
                AddParametrsToCommand66();
                using (var transaction = connection.BeginTransaction())
                {
                    AssignConnectionAndTransactionToCommand(_command64, connection, transaction);
                    AssignConnectionAndTransactionToCommand(_command65, connection, transaction);
                    AssignConnectionAndTransactionToCommand(_command66, connection, transaction);
                    _parTrainNum64.Value = planNum;
                    _parFlNoDel64.Value = 1;
                    _command64.ExecuteNonQuery();
                    planIdn = (int)_parRecIdn64.Value;
                    _parTrainIdn65.Value = planIdn;
                    _parFlSost65.Value = 1;
                    _command65.ExecuteNonQuery();
                    foreach (var planEvent in planEvents)
                    {
                        _parTrainIdn66.Value = planIdn;
                        _parEvType66.Value = planEvent.MsType;
                        _parEvTime66.Value = planEvent.MsTime;
                        _parEvTimeP66.Value = planEvent.MsTime;
                        _parEvStation66.Value = planEvent.MsStation;
                        _parEvAxis66.Value = planEvent.MsAxis;
                        _parEvNDO66.Value = planEvent.MsFlags;
                        _parCollSt66.Value = planEvent.FlColSt;
                        _parNeStation66.Value = planEvent.NeStation;
                        _command66.ExecuteNonQuery();
                    }
                    transaction.Commit();
                }
                _command64.Dispose();
                _command65.Dispose();
                _command66.Dispose();
            }
            return planIdn;
        }
        //Удалить плановую нитку, ранее связанную с указанной исполненной
        public void DelLinkedPlWire(int trainIdn)
        {
            using (var connection = new FbConnection(_connectionString))
            {
                connection.Open();
                _command49 = new FbCommand(CommandText49);
                _command49.Parameters.Add(_parTrainIdn49);
                //
                _command62 = new FbCommand(CommandText62);
                _command62.Parameters.Add(_parTrainIdn62);
                //
                _command63 = new FbCommand(CommandText63);
                _command63.Parameters.Add(_parTrainIdn63);
                _command63.Parameters.Add(_parNormIdn63);
                using (var transaction = connection.BeginTransaction())
                {
                    AssignConnectionAndTransactionToCommand(_command49, connection, transaction);
                    AssignConnectionAndTransactionToCommand(_command62, connection, transaction);
                    AssignConnectionAndTransactionToCommand(_command63, connection, transaction);
                    _parTrainIdn49.Value = trainIdn;
                    using (var dbReader1 = _command49.ExecuteReader())
                    {
                        if (dbReader1.Read())
                        {
                            var normIdn = dbReader1.GetInt32(1);
                            _parTrainIdn62.Value = normIdn;
                            _command62.ExecuteNonQuery();
                            _parTrainIdn63.Value = trainIdn;
                            _parNormIdn63.Value = 0;
                            _command63.ExecuteNonQuery();
                        }
                    }
                    transaction.Commit();
                }
                _command49.Dispose();
                _command62.Dispose();
                _command63.Dispose();
                connection.Close();
            }
        }


        //Установить флаг для сообщения ГИД
        public void SetMessFlag(int messIdn, string flag)
        {
            using (var connection = new FbConnection(_connectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    AssignConnectionAndTransactionToCommand(_command60, connection, transaction);
                    AssignConnectionAndTransactionToCommand(_command61, connection, transaction);
                    _parMsIdn60.Value = messIdn;
                    _parMsIdn61.Value = messIdn;
                    using (var dbReader1 = _command60.ExecuteReader())
                    {
                        try
                        {
                            if (dbReader1.Read())
                            {
                                string tmpS = dbReader1.GetString(0); tmpS += flag;
                                _parMsFlags61.Value = tmpS;
                                _command61.ExecuteNonQuery();
                            }
                        }
                        catch (Exception e)
                        {
                            string Err = e.ToString();
                        }
                    }
                    transaction.Commit();
                }
                connection.Close();
            }
        }
        //Дать последнее сообщение ГИД
        public GIDMessage GetLastGIDMess()
        {
            GIDMessage lastMess = new GIDMessage();
            using (var connection = new FbConnection(_connectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    AssignConnectionAndTransactionToCommand(_command57, connection, transaction);
                    using (var dbReader1 = _command57.ExecuteReader())
                    {
                        try
                        {
                            if (dbReader1.Read())
                            {
                                lastMess.MsIdn = dbReader1.GetInt32(0);
                                lastMess.MsTime = dbReader1.GetDateTime(1);
                            }
                        }
                        catch (Exception e)
                        {
                            string Err = e.ToString();
                            lastMess.MsTime = DateTime.MinValue;
                        }
                    }
                }
                connection.Close();
            }
            return lastMess;
        }
        //Записать новые сообщения ГИД
        public void WriteGIDMessages()
        {
            GIDMessage lastMess = GetLastGIDMess();
            DateTime stopTime = GetTimeGIDStop() - new TimeSpan(0, _deltaTimeStop, 0);
            IList<ActualTrain> actualTrains = GetActualTrains();
            using (var connection = new FbConnection(_connectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    AssignConnectionAndTransactionToCommand(_command58, connection, transaction);
                    AssignConnectionAndTransactionToCommand(_command59, connection, transaction);
                    _parEvTime58.Value = lastMess.MsTime;
                    foreach (var actualTrain in actualTrains)
                    {
                        _parTrainIdn58.Value = actualTrain.TrainIdn;
                        using (var dbReader1 = _command58.ExecuteReader())
                        {
                            while (dbReader1.Read())
                            {
                                _parMsIdn59.Value = dbReader1.GetInt32(5);
                                _parMsType59.Value = dbReader1.GetInt32(0);
                                _parMsTime59.Value = dbReader1.GetDateTime(1);
                                string tmpS = dbReader1.GetString(2); tmpS = tmpS.Remove(0, 2);
                                _parMsStat59.Value = tmpS;
                                _parTrainNum59.Value = actualTrain.TrainNumber;
                                _parMsAxis59.Value = dbReader1.GetString(3);
                                tmpS = dbReader1.GetString(4);
                                if (!String.IsNullOrEmpty(tmpS)) { tmpS = tmpS.Remove(0, 2); }
                                _parNeStat59.Value = tmpS;
                                _parMsFlags59.Value = null;
                                if ((DateTime)_parMsTime59.Value > stopTime) { break; }
                                _command59.ExecuteNonQuery();
                            }
                        }
                    }
                    transaction.Commit();
                }
                connection.Close();
            }
        }
        //Дать список актуальных поездов
        public IList<ActualTrain> GetActualTrains()
        {
            IList<ActualTrain> returnedList = new List<ActualTrain>();
            using (var connection = new FbConnection(_connectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    AssignConnectionAndTransactionToCommand(_command4, connection, transaction);
                    using (var dbReader1 = _command4.ExecuteReader())
                    {
                        while (dbReader1.Read())
                        {
                            var trainActual = new ActualTrain
                            {
                                TrainIdn = dbReader1.GetInt32(0),
                                TrainNumber = dbReader1.GetString(1),
                            };
                            returnedList.Add(trainActual);
                        }
                    }
                }
                connection.Close();
            }
            return returnedList;
        }
        //Удалить лишние актуальные справки
        public void ClearTMessages()
        {
            using (var connection = new FbConnection(_connectionString))
            using (var connection1 = new FbConnection(_connectionString))
            {
                connection.Open();
                connection1.Open();
                using (var transaction = connection.BeginTransaction())
                using (var transaction1 = connection1.BeginTransaction())
                {
                    AssignConnectionAndTransactionToCommand(_command5, connection, transaction);
                    AssignConnectionAndTransactionToCommand(_command42, connection1, transaction1);
                    //Удалить справки с временем, раньше пепрого события ГИД
                    _parMessTime5.Value = GetTimeGIDStart();
                    _command5.ExecuteNonQuery();
                    transaction.Commit();
                    //Удалить справки, по которым нет событий по станци, их выдавшей
                    _command42.ExecuteNonQuery();
                    transaction1.Commit();
                }
                connection.Close();
                connection1.Close();
            }
        }
        //Удалить лишние справки из истории до указанного времени
        public void ClearWMessages(DateTime stpTime)
        {
            using (var connection = new FbConnection(_connectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    AssignConnectionAndTransactionToCommand(_command12, connection, transaction);
                    //Удалить справки с временем, раньше указанного
                    _parMessTime12.Value = stpTime;
                    int cn = _command12.ExecuteNonQuery();
                    transaction.Commit();
                }
                connection.Close();
            }
        }
        //Удалить лишние сообщения ГИДа
        public void ClearGidMessages(DateTime stpTime)
        {
            using (var connection = new FbConnection(_connectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    AssignConnectionAndTransactionToCommand(_command55, connection, transaction);
                    //Удалить сообщения с временем, раньше указанного
                    _parMessTime55.Value = stpTime;
                    int cn = _command55.ExecuteNonQuery();
                    transaction.Commit();
                }
                connection.Close();
            }
        }
        //Существует ли на указанный поезд связанная справка?
        public TrainMessage GetActualMessage(ActualTrain actualTrain)
        {
            TrainMessage actualMess = null;
            using (var connection = new FbConnection(_connectionString))
            {
                connection.Open();
                _command6 = new FbCommand(CommandText6);
                _command6.Parameters.Add(_parTrnIdn6);
                using (var transaction = connection.BeginTransaction())
                {
                    AssignConnectionAndTransactionToCommand(_command6, connection, transaction);
                    _parTrnIdn6.Value = actualTrain.TrainIdn;
                    using (var dbReader1 = _command6.ExecuteReader())
                    {
                        //она вообще-то может быть только одна
                        while (dbReader1.Read())
                        {
                            actualMess = new TrainMessage
                            {
                                RawMessageRecId = dbReader1.GetInt32(1),
                                MessageTime = dbReader1.GetDateTime(2),
                            };
                            break;
                        }
                    }
                }
                _command6.Dispose();
                connection.Close();
            }
            return actualMess;
        }

        //Дать несвязанные актуальные сообщения
        public IList<WorkMessage> GetActualMessages()
        {
            IList<WorkMessage> returnedList = new List<WorkMessage>();
            using (var connection = new FbConnection(_connectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    AssignConnectionAndTransactionToCommand(_command53, connection, transaction);
                    using (var dbReader1 = _command53.ExecuteReader())
                    {
                        while (dbReader1.Read())
                        {
                            try
                            {
                                var trainWrkMess = new WorkMessage
                                {
                                    MessIdn = dbReader1.GetInt32(0),
                                    StForm = dbReader1.GetString(1),
                                    NmSost = dbReader1.GetString(2),
                                    StDest = dbReader1.GetString(3),
                                };
                                returnedList.Add(trainWrkMess);
                            }
                            catch (Exception exception)
                            {
                                string Error = exception.ToString();
                            }
                        }
                    }
                }
                connection.Close();
            }
            return returnedList;
        }
        //Получить поезд с указанным индексом из заголовка ГИДа
        public int GetTrainByForm(string stForm, string nmSost, string stDest)
        {
            int trIdn = -1;
            using (var connection = new FbConnection(_connectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    AssignConnectionAndTransactionToCommand(_command54, connection, transaction);
                    _parStForm54.Value = stForm;
                    _parSstNum54.Value = nmSost;
                    _parStDest54.Value = stDest;
                    using (var dbReader1 = _command54.ExecuteReader())
                    {
                        if (dbReader1.Read())
                        {
                            try
                            {
                                trIdn = dbReader1.GetInt32(0);
                            }
                            catch (Exception exception)
                            {
                                string Error = exception.ToString();
                            }
                        }
                    }
                }
                connection.Close();
            }
            return trIdn;
        }
        //Дать события поезда по станции, приславшей справку
        public IList<TrainEvent> GetTrainEventsForMess(TrainMessage trainMessage
                                                      , ActualTrain actualTrain
                                                      , ICnfRepository cnfRepository)
        {
            IList<TrainEvent> returnedList = new List<TrainEvent>();
            using (var connection = new FbConnection(_connectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    AssignConnectionAndTransactionToCommand(_command7, connection, transaction);
                    _parTrnIdn7.Value = actualTrain.TrainIdn;
                    var stationsList = cnfRepository.GetStationGroup(trainMessage.StationCode);
                    foreach (var statCode in stationsList)
                    {
                        _parEvStat7.Value = "TE" + statCode;
                        using (var dbReader1 = _command7.ExecuteReader())
                        {
                            while (dbReader1.Read())
                            {
                                var trainEvent = new TrainEvent
                                {
                                    EventType = dbReader1.GetInt16(0),
                                    EventTime = dbReader1.GetDateTime(1),
                                    EventAxis = dbReader1.GetString(2),
                                };
                                returnedList.Add(trainEvent);
                            }
                        }
                    }
                }
                connection.Close();
            }
            return returnedList;
        }
        //Записать новую связанную справку
        public void WriteNewMessForTrain(TrainMessage trainMessage, ActualTrain actualTrain)
        {
            using (var connection = new FbConnection(_connectionString))
            {
                connection.Open();
                _command8 = new FbCommand(CommandText8);
                AddParametrsToCommand8();
                using (var transaction = connection.BeginTransaction())
                {
                    AssignConnectionAndTransactionToCommand(_command8, connection, transaction);
                    //
                    _parTrainIdn8.Value = actualTrain.TrainIdn;
                    _parMsIdn8.Value = trainMessage.RawMessageRecId;
                    _parMsTime8.Value = trainMessage.MessageTime;
                    _parMsStation8.Value = trainMessage.StationCode;
                    _parTrainNum8.Value = trainMessage.TrainNumber;
                    _parStForm8.Value = trainMessage.TrainIndex.Index1;
                    _parNmSost8.Value = trainMessage.TrainIndex.Index2;
                    _parStDest8.Value = trainMessage.TrainIndex.Index3;
                    _parTrainAttr8.Value = trainMessage.TrainIndex.Index4;
                    _parLocoSerie8.Value = trainMessage.LocoSeries;
                    _parLocoNum8.Value = trainMessage.LocoNumber;
                    _parSttTimeH8.Value = trainMessage.CrewStTimeH;
                    _parSttTimeM8.Value = trainMessage.CrewStTimeM;
                    _parMachinist8.Value = trainMessage.Machinist;
                    _parWagCoun8.Value = trainMessage.CWagCount;
                    _parNtWeight8.Value = trainMessage.NtWeight;
                    _parGrWeight8.Value = trainMessage.GrWeight;
                    _parWagLoaded8.Value = trainMessage.WagCounts[0];
                    _parWagEmpty8.Value = trainMessage.WagCounts[1];
                    _parWagNoWork8.Value = trainMessage.WagCounts[2];
                    _parOperation8.Value = trainMessage.Operation;
                    _parFlags8.Value = trainMessage.Flags;
                    _command8.ExecuteNonQuery();
                    transaction.Commit();
                }
                _command8.Dispose();
                connection.Close();
            }
        }
        //Заменить связанную справку
        public void ChangeNewMessForTrain(TrainMessage trainMessage, ActualTrain actualTrain)
        {
            using (var connection = new FbConnection(_connectionString))
            {
                connection.Open();
                _command9 = new FbCommand(CommandText9);
                AddParametrsToCommand9();
                using (var transaction = connection.BeginTransaction())
                {
                    AssignConnectionAndTransactionToCommand(_command9, connection, transaction);
                    //
                    _parTrainIdn9.Value = actualTrain.TrainIdn;
                    _parMsIdn9.Value = trainMessage.RawMessageRecId;
                    _parMsTime9.Value = trainMessage.MessageTime;
                    _parMsStation9.Value = trainMessage.StationCode;
                    _parTrainNum9.Value = trainMessage.TrainNumber;
                    _parStForm9.Value = trainMessage.TrainIndex.Index1;
                    _parNmSost9.Value = trainMessage.TrainIndex.Index2;
                    _parStDest9.Value = trainMessage.TrainIndex.Index3;
                    _parTrainAttr9.Value = trainMessage.TrainIndex.Index4;
                    _parLocoSerie9.Value = trainMessage.LocoSeries;
                    _parLocoNum9.Value = trainMessage.LocoNumber;
                    _parSttTimeH9.Value = trainMessage.CrewStTimeH;
                    _parSttTimeM9.Value = trainMessage.CrewStTimeM;
                    _parMachinist9.Value = trainMessage.Machinist;
                    _parWagCoun9.Value = trainMessage.CWagCount;
                    _parNtWeight9.Value = trainMessage.NtWeight;
                    _parGrWeight9.Value = trainMessage.GrWeight;
                    _parWagLoaded9.Value = trainMessage.WagCounts[0];
                    _parWagEmpty9.Value = trainMessage.WagCounts[1];
                    _parWagNoWork9.Value = trainMessage.WagCounts[2];
                    _parOperation9.Value = trainMessage.Operation;
                    _parFlags9.Value = trainMessage.Flags;
                    _command9.ExecuteNonQuery();
                    transaction.Commit();
                }
                _command9.Dispose();
                connection.Close();
            }
        }
        //Записать новую справку в историю
        public void WriteWorkMessage(TrainMessage trainMessage)
        {
            using (var connection = new FbConnection(_connectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    AssignConnectionAndTransactionToCommand(_command13, connection, transaction);
                    _parMsIdn13.Value = trainMessage.RawMessageRecId;
                    _parMsTime13.Value = trainMessage.MessageTime;
                    _parMsStation13.Value = trainMessage.StationCode;
                    _parTrainNum13.Value = trainMessage.TrainNumber;
                    _parStForm13.Value = trainMessage.TrainIndex.Index1;
                    _parNmSost13.Value = trainMessage.TrainIndex.Index2;
                    _parStDest13.Value = trainMessage.TrainIndex.Index3;
                    _parTrainAttr13.Value = trainMessage.TrainIndex.Index4;
                    _parLocoSerie13.Value = trainMessage.LocoSeries;
                    _parLocoNum13.Value = trainMessage.LocoNumber;
                    _parSttTimeH13.Value = trainMessage.CrewStTimeH;
                    _parSttTimeM13.Value = trainMessage.CrewStTimeM;
                    _parMachinist13.Value = trainMessage.Machinist;
                    _parWagCoun13.Value = trainMessage.CWagCount;
                    _parNtWeight13.Value = trainMessage.NtWeight;
                    _parGrWeight13.Value = trainMessage.GrWeight;
                    _parBadCode13.Value = "";
                    /*
                    if ((trainMessage.TrainIndex.Index1.Contains("0000"))
                     || (trainMessage.TrainIndex.Index1.Contains("0001"))){
                       _parStForm13.Value  = trainMessage.TrainIndex.Index3;//?

                       string ss = trainMessage.TrainIndex.Index3;
                       while (ss.Substring(0,1) == "0"){
                         ss = ss.Remove(0, 1);
                       }
                       if(ss == trainMessage.TrainNumber.ToString()){
                         _parBadCode13.Value = trainMessage.TrainIndex.Index1;
                       }else{
                         try{
                           if(((trainMessage.TrainNumber - int.Parse(ss)) == 1)
                            ||((trainMessage.TrainNumber - int.Parse(ss)) == -1)){
                             _parBadCode13.Value = trainMessage.TrainIndex.Index1;
                           }
                         }catch (Exception){
                           _parBadCode13.Value = trainMessage.TrainIndex.Index1;
                         }
                       }
                     }
                    */
                    _parWagLoaded13.Value = trainMessage.WagCounts[0];
                    _parWagEmpty13.Value = trainMessage.WagCounts[1];
                    _parWagNoWork13.Value = trainMessage.WagCounts[2];
                    _parOperation13.Value = trainMessage.Operation;
                    _parFlags13.Value = trainMessage.Flags;
                    _command13.ExecuteNonQuery();
                    transaction.Commit();
                }
                connection.Close();
            }
        }
        //Откорректировать в истории факт связанности справок с поездами
        public void PrepareWorkMessages()
        {
            using (var connection = new FbConnection(_connectionString))
            using (var connection1 = new FbConnection(_connectionString))
            using (var connection2 = new FbConnection(_connectionString))
            using (var connection3 = new FbConnection(_connectionString))
            {
                connection.Open();
                connection1.Open();
                connection2.Open();
                connection3.Open();
                using (var transaction = connection.BeginTransaction())
                using (var transaction1 = connection1.BeginTransaction())
                using (var transaction2 = connection2.BeginTransaction())
                using (var transaction3 = connection3.BeginTransaction())
                {
                    AssignConnectionAndTransactionToCommand(_command14, connection, transaction);
                    AssignConnectionAndTransactionToCommand(_command15, connection1, transaction1);
                    AssignConnectionAndTransactionToCommand(_command16, connection2, transaction2);
                    AssignConnectionAndTransactionToCommand(_command17, connection3, transaction3);
                    //Для всех "не связанных" или "не остановленных" справок
                    using (var dbReader1 = _command14.ExecuteReader())
                    {
                        while (dbReader1.Read())
                        {
                            Int32 messIdn = dbReader1.GetInt32(0);
                            DateTime sttTime = DateTime.MinValue;
                            //Была ли справка связана с поездом ранее?
                            if (!DateTime.TryParse(dbReader1.GetString(5), out sttTime)) { }
                            _parMsIdn15.Value = messIdn;
                            //Связана ли данная справка с поездом?
                            using (var dbReader2 = _command15.ExecuteReader())
                            {
                                if (!dbReader2.Read())
                                {
                                    //сейчас не связана...
                                    if (sttTime != DateTime.MinValue)
                                    {
                                        //но была связана ранее
                                        _parMsIdn16.Value = messIdn;
                                        _parMessTime16.Value = DateTime.Now;
                                        //фиксируем остановку факта связывания
                                        _command16.ExecuteNonQuery();
                                    }
                                }
                                else
                                {
                                    //справка сейчас связана
                                    if (sttTime == DateTime.MinValue)
                                    {
                                        //но ранее она не была связана
                                        _parMsIdn17.Value = messIdn;
                                        _parMessTime17.Value = DateTime.Now;
                                        _parTrainIdn17.Value = dbReader2.GetInt32(0);
                                        //фиксируем факт связывания
                                        _command17.ExecuteNonQuery();
                                    }
                                }
                            }
                        }
                    }
                    transaction2.Commit();
                    transaction3.Commit();
                }
                connection.Close();
                connection1.Close();
                connection2.Close();
                connection3.Close();
            }
        }
        //Определить интервал времени между справками и соответствующими событиями поездов по станциям
        public void SrhTrEventsForMessages()
        {
            using (var connection = new FbConnection(_connectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    AssignConnectionAndTransactionToCommand(_command18, connection, transaction);
                    AssignConnectionAndTransactionToCommand(_command19, connection, transaction);
                    AssignConnectionAndTransactionToCommand(_command20, connection, transaction);
                    AssignConnectionAndTransactionToCommand(_command21, connection, transaction);
                    using (var dbReader1 = _command18.ExecuteReader())
                    {
                        //для всех пустых записей из таблицы справок
                        while (dbReader1.Read())
                        {
                            //для поезда с номером из таблицы номеров
                            _parTrainNum19.Value = dbReader1.GetString(2);
                            using (var dbReader2 = _command19.ExecuteReader())
                            {
                                //
                                while (dbReader2.Read())
                                {
                                    //для нитки с идентификатором по станции из графика
                                    _parTrainIdn20.Value = dbReader2.GetInt32(0);
                                    _parStation20.Value = "TE" + dbReader1.GetString(3);
                                    using (var dbReader3 = _command20.ExecuteReader())
                                    {
                                        //последнее событие
                                        if (dbReader3.Read())
                                        {
                                            //записываем интервал между справкой и последним событием
                                            TimeSpan ts = dbReader1.GetDateTime(1) - dbReader3.GetDateTime(0);
                                            _parTimeSp21.Value = (Int32)ts.TotalSeconds;
                                            _parMessIdn21.Value = dbReader1.GetInt32(0);
                                            _command21.ExecuteNonQuery();
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    transaction.Commit();
                }
                connection.Close();
            }
        }
        //Остановить предыдущие справки
        public void SetStopMess()
        {
            using (var connection = new FbConnection(_connectionString))
            using (var connection1 = new FbConnection(_connectionString))
            {
                connection.Open();
                connection1.Open();
                using (var transaction = connection.BeginTransaction())
                using (var transaction1 = connection1.BeginTransaction())
                {
                    AssignConnectionAndTransactionToCommand(_command22, connection, transaction);
                    AssignConnectionAndTransactionToCommand(_command23, connection1, transaction1);
                    using (var dbReader1 = _command22.ExecuteReader())
                    {
                        //Для всех связанных в данный момент справок
                        while (dbReader1.Read())
                        {
                            _parMessTime23.Value = dbReader1.GetDateTime(0);
                            _parStation23.Value = dbReader1.GetString(1);
                            _parNmSost23.Value = dbReader1.GetString(2);
                            _parStopTime23.Value = DateTime.Now;
                            _parMsIdn23.Value = dbReader1.GetInt32(3);
                            //все предыдущие справки по данному (грузовому - ст.формирования, нм.состава) поезду считать остановленными
                            _command23.ExecuteNonQuery();
                        }
                    }
                    transaction1.Commit();
                }
                connection.Close();
                connection1.Close();
            }
        }
        //Переустановить свойства справок в истории
        public void SetMessProperties()
        {
            using (var connection = new FbConnection(_connectionString))
            using (var connection1 = new FbConnection(_connectionString))
            using (var connection2 = new FbConnection(_connectionString))
            using (var connection3 = new FbConnection(_connectionString))
            {
                connection.Open();
                connection1.Open();
                connection2.Open();
                connection3.Open();
                using (var transaction = connection.BeginTransaction())
                using (var transaction1 = connection1.BeginTransaction())
                using (var transaction2 = connection2.BeginTransaction())
                using (var transaction3 = connection3.BeginTransaction())
                {
                    AssignConnectionAndTransactionToCommand(_command26, connection, transaction);
                    AssignConnectionAndTransactionToCommand(_command27, connection1, transaction1);
                    AssignConnectionAndTransactionToCommand(_command28, connection2, transaction2);
                    AssignConnectionAndTransactionToCommand(_command30, connection3, transaction3);
                    //Сбросить признак актуальности справок
                    _command27.ExecuteNonQuery();
                    transaction1.Commit();
                    using (var dbReader1 = _command26.ExecuteReader())
                    {
                        //Для всех справок из истории, отсортированных по ст.формирования,нм.состава и времени
                        //Предыдущая справка
                        var wrkMessPrv = new WorkMessage();
                        //Текущая справка
                        var wrkMessCur = new WorkMessage();
                        //
                        string _tmpS;
                        int _counMess = 0;
                        int _trainIdn = -1;
                        wrkMessCur.StForm = null;
                        wrkMessCur.NmSost = null;
                        wrkMessCur.StDest = null;
                        //
                        while (dbReader1.Read())
                        {
                            //копируем текущую справку в предыдущую
                            wrkMessPrv.MessIdn = wrkMessCur.MessIdn;
                            wrkMessPrv.MessTime = wrkMessCur.MessTime;//
                            wrkMessPrv.MessStation = wrkMessCur.MessStation;
                            wrkMessPrv.Operation = wrkMessCur.Operation;
                            wrkMessPrv.Flags = wrkMessCur.Flags;
                            wrkMessPrv.TrainIdn = wrkMessCur.TrainIdn;
                            wrkMessPrv.TrainNum = wrkMessCur.TrainNum;
                            wrkMessPrv.StForm = wrkMessCur.StForm;
                            wrkMessPrv.NmSost = wrkMessCur.NmSost;
                            wrkMessPrv.StDest = wrkMessCur.StDest;
                            wrkMessPrv.MessIdnPrev = wrkMessCur.MessIdnPrev;//
                            wrkMessPrv.MessProp = wrkMessCur.MessProp;//
                            wrkMessPrv.ComCngNum = wrkMessCur.ComCngNum;//
                            wrkMessPrv.ComCngWir = wrkMessCur.ComCngWir;//
                            wrkMessPrv.WirIdnPrev = wrkMessCur.WirIdnPrev;
                            //Читаем текущую справку
                            wrkMessCur.MessIdn = dbReader1.GetInt32(0);
                            wrkMessCur.MessTime = dbReader1.GetDateTime(1);//
                            wrkMessCur.MessStation = dbReader1.GetString(2);
                            _tmpS = dbReader1.GetString(3);
                            if (String.IsNullOrEmpty(_tmpS)) { wrkMessCur.TrainIdn = -1; }
                            else { wrkMessCur.TrainIdn = Int32.Parse(_tmpS); }
                            wrkMessCur.TrainNum = dbReader1.GetString(4);
                            wrkMessCur.StForm = dbReader1.GetString(7);
                            wrkMessCur.NmSost = dbReader1.GetString(8);
                            wrkMessCur.StDest = dbReader1.GetString(9);
                            _tmpS = dbReader1.GetString(10);
                            if (String.IsNullOrEmpty(_tmpS)) { wrkMessCur.MessIdnPrev = -1; }
                            else { wrkMessCur.MessIdnPrev = Int32.Parse(_tmpS); }
                            _tmpS = dbReader1.GetString(11);
                            if (String.IsNullOrEmpty(_tmpS)) { wrkMessCur.MessProp = -1; }
                            else { wrkMessCur.MessProp = Int32.Parse(_tmpS); }
                            _tmpS = dbReader1.GetString(12);
                            if (String.IsNullOrEmpty(_tmpS)) { wrkMessCur.ComCngNum = -1; }
                            else { wrkMessCur.ComCngNum = Int32.Parse(_tmpS); }
                            _tmpS = dbReader1.GetString(13);
                            if (String.IsNullOrEmpty(_tmpS)) { wrkMessCur.ComCngWir = -1; }
                            else { wrkMessCur.ComCngWir = Int32.Parse(_tmpS); }
                            _tmpS = dbReader1.GetString(14);
                            if (String.IsNullOrEmpty(_tmpS)) { wrkMessCur.WirIdnPrev = -1; }
                            else { wrkMessCur.WirIdnPrev = Int32.Parse(_tmpS); }
                            //Поезд другой?
                            if ((wrkMessCur.StForm != wrkMessPrv.StForm)
                              || (wrkMessCur.NmSost != wrkMessPrv.NmSost)
                              || (wrkMessCur.StDest != wrkMessPrv.StDest))
                            {
                                //другой
                                _counMess = 1;
                                _trainIdn = -1;
                            }
                            else
                            {
                                //тот же
                                _counMess++;
                            }
                            //Связана ли текущая справка с ниткой поезда?
                            if (wrkMessCur.TrainIdn != -1)
                            {
                                //если была ранее справка, связанная с текущим поездом,
                                //"нитки" у поезда разные,
                                //команда на их связывание не давалась
                                if ((_trainIdn != -1)
                                  && (wrkMessCur.TrainIdn != _trainIdn)
                                  && (wrkMessCur.ComCngWir == -1))
                                {
                                    //установить команду текущей нитки с предыдущей
                                    wrkMessCur.ComCngWir = 1;
                                    wrkMessCur.WirIdnPrev = _trainIdn;
                                }
                                //запомнить текущую связанную нитку
                                _trainIdn = wrkMessCur.TrainIdn;
                            }
                            //Если это первая справка по поезду
                            if (_counMess == 1)
                            {
                                //а перед ней была (последняя) справка по предыдущему поезду
                                if (wrkMessPrv.StForm != null)
                                {
                                    wrkMessPrv.MessProp = 1;
                                    _parMessIdn30.Value = wrkMessPrv.MessIdn;
                                    _parMessProp30.Value = wrkMessPrv.MessProp;
                                    //усрановить признак актуальности для последней справки предыдущего поезда
                                    _command30.ExecuteNonQuery();
                                    transaction3.CommitRetaining();
                                }
                            }
                            //Если это не первая справка по поезду
                            if (_counMess > 1)
                            {
                                //установить ссылку на предыдущую справку
                                wrkMessCur.MessIdnPrev = wrkMessPrv.MessIdn;
                                //если была ранее справка, связанная с текущим поездом,
                                //номер поезда сейчас меняется
                                //команда на изменение номера ранее не давалась
                                if ((_trainIdn != -1)
                                  && (wrkMessCur.TrainNum != wrkMessPrv.TrainNum)
                                  && (wrkMessCur.ComCngNum == -1))
                                {
                                    //присвоить новый номер со станции, выдавшей текущую справку
                                    wrkMessCur.ComCngNum = 1;
                                    wrkMessCur.WirIdnPrev = _trainIdn;
                                }
                            }
                            _parMessIdn28.Value = wrkMessCur.MessIdn;
                            _parMsIdnPrev28.Value = wrkMessCur.MessIdnPrev;
                            _parMessProp28.Value = wrkMessCur.MessProp;
                            _parWirIdnPrev28.Value = wrkMessCur.WirIdnPrev;
                            _parComCngNum28.Value = wrkMessCur.ComCngNum;
                            _parComCngWir28.Value = wrkMessCur.ComCngWir;
                            //Записать параметры текущей справки
                            _command28.ExecuteNonQuery();
                            transaction2.CommitRetaining();
                        }
                        if (_counMess > 0)
                        {
                            _parMessIdn30.Value = wrkMessCur.MessIdn;
                            _parMessProp30.Value = 1;
                            //усрановить признак актуальности для последней справки
                            _command30.ExecuteNonQuery();
                            transaction3.CommitRetaining();
                        }
                    }
                    //transaction1.Commit();
                    //transaction2.Commit();
                    //transaction3.Commit();
                }
                connection.Close();
                connection1.Close();
                connection2.Close();
                connection3.Close();
            }
        }
        //Выполнить команды из истории справок
        public void RunMessCommands()
        {
            using (var connection = new FbConnection(_connectionString))
            using (var connection1 = new FbConnection(_connectionString))
            using (var connection2 = new FbConnection(_connectionString))
            using (var connection3 = new FbConnection(_connectionString))
            {
                connection.Open();
                connection1.Open();
                connection2.Open();
                connection3.Open();
                using (var transaction = connection.BeginTransaction())
                using (var transaction1 = connection1.BeginTransaction())
                using (var transaction2 = connection2.BeginTransaction())
                using (var transaction3 = connection3.BeginTransaction())
                {
                    AssignConnectionAndTransactionToCommand(_command29, connection, transaction);
                    AssignConnectionAndTransactionToCommand(_command33, connection1, transaction1);
                    AssignConnectionAndTransactionToCommand(_command34, connection2, transaction2);
                    AssignConnectionAndTransactionToCommand(_command35, connection3, transaction3);
                    //Выполнить все команды безусловного соединения ниток поездов
                    using (var dbReader1 = _command29.ExecuteReader())
                    {
                        while (dbReader1.Read())
                        {
                            int _messIdn = dbReader1.GetInt32(0);
                            int _trainIdn;
                            string _tmpS = dbReader1.GetString(1);
                            if (String.IsNullOrEmpty(_tmpS)) { _trainIdn = -1; } else { _trainIdn = Int32.Parse(_tmpS); }
                            int _prvWirIdn = dbReader1.GetInt32(2);
                            if (_trainIdn != -1)
                            {
                                BindTrainThreads(_prvWirIdn, _trainIdn);
                            }
                        }
                    }
                    _parComCngWir34.Value = 2;
                    //считать команды соединения ниток выполненными
                    _command34.ExecuteNonQuery();
                    transaction2.Commit();
                    //Выполнить все команды изменения померов поездов
                    using (var dbReader1 = _command33.ExecuteReader())
                    {
                        while (dbReader1.Read())
                        {
                            var messIdn = dbReader1.GetInt32(0);
                            int trainIdn;
                            var tmpS = dbReader1.GetString(1);
                            if (String.IsNullOrEmpty(tmpS)) { trainIdn = -1; } else { trainIdn = Int32.Parse(tmpS); }
                            var prvWirIdn = dbReader1.GetInt32(2);
                            var trainNum = dbReader1.GetString(3);
                            var msStation = dbReader1.GetString(4);
                            if (trainIdn == -1)
                            {
                                AssignTrainNumber(prvWirIdn, "", trainNum, "", msStation);
                            }
                        }
                    }
                    _parComCngNum35.Value = 2;
                    //считать все команды изменения номеров выполненными
                    _command35.ExecuteNonQuery();
                    transaction3.Commit();
                }
                connection.Close();
                connection1.Close();
                connection2.Close();
                connection3.Close();
            }
        }
        //Время первого события ГИД
        public DateTime GetTimeGIDStart()
        {
            DateTime retTime = DateTime.MinValue;
            using (var connection = new FbConnection(_connectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    AssignConnectionAndTransactionToCommand(_command51, connection, transaction);
                    //
                    using (var dbReader1 = _command51.ExecuteReader())
                    {
                        if (dbReader1.Read())
                        {
                            try
                            {
                                retTime = dbReader1.GetDateTime(0);
                            }
                            catch (Exception e)
                            {
                                string Err = e.ToString();
                            }
                        }
                    }
                }
                connection.Close();
            }
            return retTime;
        }
        //Время последнего события ГИД
        public DateTime GetTimeGIDStop()
        {
            if (!_flPlay)
            {
                return DateTime.Now;
            }
            DateTime retTime = DateTime.MaxValue;
            using (var connection = new FbConnection(_connectionString))
            {
                connection.Open();
                _command52 = new FbCommand(CommandText52);
                using (var transaction = connection.BeginTransaction())
                {
                    AssignConnectionAndTransactionToCommand(_command52, connection, transaction);
                    //
                    using (var dbReader1 = _command52.ExecuteReader())
                    {
                        if (dbReader1.Read())
                        {
                            try
                            {
                                retTime = dbReader1.GetDateTime(0);
                            }
                            catch (Exception e)
                            {
                                string Err = e.ToString();
                            }
                        }
                    }
                }
                _command52.Dispose();
                connection.Close();
            }
            return retTime;
        }
        //Ассоциировать команду с соединением и транзакцией
        private static void AssignConnectionAndTransactionToCommand(FbCommand command
                                        , FbConnection connection, FbTransaction transaction)
        {
            command.Connection = connection;
            command.Transaction = transaction;
        }
        private static void AssignConnectionAndTransactionToCommandSql(SqlCommand command
                                        , SqlConnection connection, SqlTransaction transaction)
        {
            command.Connection = connection;
            command.Transaction = transaction;
        }
        //Входит ли название оси в название пути (зто ось этого пути)???
        private static string GetTrack(string axis, string track)
        {
            int suf = -1;
            string trc;
            if (axis.Length > track.Length) { return ""; }
            if (axis == track) { return track; }
            trc = track.Substring(axis.Length, 1);
            if (!Int32.TryParse(trc, out suf))
            {
                return track;
            }
            return "";
        }

    }
}
