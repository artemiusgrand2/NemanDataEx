using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NdeDataClasses;
using NdeDataClasses.Commands;
using WcfOverWinServiceTest.ServiceReference1;

namespace WcfOverWinServiceTest
{
  public partial class Form1 : Form
  {
    //private object command;
    public Form1(){
      InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e){
      using (var serviceClient = new NdeServiceClient()){
        var startTime = DateTime.Now;
        //IList<TrainEvent> trainEvents;
        IList<ComDefinition> defs = null;
        try{
          defs = serviceClient.GetComDefinitions();
          //trainEvents = serviceClient.GetLastTrainEvents();
        }catch (Exception error){
          string ers = error.ToString();
          MessageBox.Show(ers);
          return;
        }
        var finishTime = DateTime.Now;
        label3.Text = defs.Count().ToString();
        //label3.Text = trainEvents.Count().ToString();
        label4.Text = (finishTime - startTime).TotalMilliseconds.ToString();
        /*
        foreach (var trainEvent in trainEvents) {
          //if (trainEvent.EventStation == "140009") {
            if (trainEvent.DObjType == 5) {
              if (trainEvent.EventType == 3) {
                var evTime = trainEvent.EventTime;
                var neStat = trainEvent.NeibStation;
                if (neStat != "") {
                  //neStat = neStat;
                }
              }
            }
          //}
        }*/
      }
    }

    private void button2_Click(object sender, EventArgs e){
      using (var client = new NdeServiceClient()){
        var command = new RunTrackIoTrackCommand{
          trainIdn = int.Parse(textBox1.Text),
          trackName = textBox2.Text,
          stationCode = textBox3.Text
        };
        label34.Text = client.ExecuteBindingCommand(command);
      }
    }

    private void button3_Click(object sender, EventArgs e){
      using (var client = new NdeServiceClient()){
        var command = new TrainProcessCommand{
          Command = int.Parse(textBox4.Text),
          SubCommand = int.Parse(textBox5.Text),
          StationCdode = textBox6.Text,
          Track = textBox7.Text,
          TrainPrefix = "Pref",
          TrainNubmer = textBox8.Text,
          TrainSuffix = "Suf",
          NeibStation = "Neib",
          Remark = textBox9.Text
        };
        client.ExecuteBindingCommand(command);
      }
    }

    private void button4_Click(object sender, EventArgs e){
      using (var client = new NdeServiceClient()){
        var command = new SetTrackInCommand{
          trainIdn = int.Parse(textBox10.Text),
          trackName = textBox11.Text,
          stationCode = textBox12.Text
        };
        client.ExecuteBindingCommand(command);
      }
    }

    private void button5_Click(object sender, EventArgs e){
      using (var client = new NdeServiceClient()){
        var command = new MarkTrainCommand{
          trainIdn = int.Parse(textBox13.Text),
          strMarker = textBox14.Text
        };
        client.ExecuteBindingCommand(command);
      }
    }

    private void button6_Click(object sender, EventArgs e){
      using (var client = new NdeServiceClient()){
        var command = new WriteTrainInputCommand{
          stationCode = textBox15.Text,
          trackName = textBox16.Text,
          destName = textBox17.Text
        };
        client.ExecuteBindingCommand(command);
      }
    }

    private void button7_Click(object sender, EventArgs e){
      using (var client = new NdeServiceClient()){
        var command = new MarkMessageCommand{
          messageIdn = int.Parse(textBox18.Text),
          strMarker = textBox19.Text
        };
        client.ExecuteBindingCommand(command);
      }
    }

    private void button8_Click(object sender, EventArgs e){
      using (var serviceClient = new NdeServiceClient()){
        var startTime = DateTime.Now;
        IList<WorkMessage> trainMessages;
        try{
          trainMessages = serviceClient.GetWorkMessages();
        }catch (Exception error){
          string ers = error.ToString();
          MessageBox.Show(ers);
          return;
        }
        var finishTime = DateTime.Now;
        label26.Text = trainMessages.Count().ToString();
        label27.Text = (finishTime - startTime).TotalMilliseconds.ToString();
      }
    }

    private void button9_Click(object sender, EventArgs e){
      using (var client = new NdeServiceClient()){
        var command = new StopMessForTrainCommand{
          trainIdn = int.Parse(textBox20.Text)
        };
        client.ExecuteBindingCommand(command);
      }
    }

    private void button10_Click(object sender, EventArgs e){
      if (String.IsNullOrEmpty(textBox21.Text)){
        label32.Text = "Не указан идентификатор нитки!";
        return;
      }
      using (var client = new NdeServiceClient()){
        var command = new AssignTrainNumberCommand{
          TrainThreadId = int.Parse(textBox21.Text),
          TrainNumberPrefix = "",
          TrainNumber = textBox22.Text,
          TrainNumberSuffix = "",
          StationCode = ""
        };
        label32.Text = client.ExecuteBindingCommand(command);
      }
    }

    private void button11_Click(object sender, EventArgs e){
      using (var client = new NdeServiceClient()){
        AssignMessForTrainCommand command = null;
        try{
          command = new AssignMessForTrainCommand{
            messageIdn = int.Parse(textBox23.Text),
            trainIdn = int.Parse(textBox24.Text)
          };
        }catch (Exception){
          label38.Text = "Введите идентификаторы.";
          return;
        }
        label38.Text = client.ExecuteBindingCommand(command);
      }
    }

    private void button12_Click(object sender, EventArgs e){
      using (var client = new NdeServiceClient()){
        var command = new WriteTrainOutputCommand{
          stationCode = textBox27.Text,
          trackName = textBox26.Text,
          destName = textBox25.Text
        };
        client.ExecuteBindingCommand(command);
      }
    }

    private void button13_Click(object sender, EventArgs e){
      using (var serviceClient = new NdeServiceClient()){
        var startTime = DateTime.Now;
        IList<GIDMessage> gidMessages;
        try{
          gidMessages = serviceClient.GetGIDMessages();
        }catch (Exception error){
          string ers = error.ToString();
          MessageBox.Show(ers);
          return;
        }
        var finishTime = DateTime.Now;
        label43.Text = gidMessages.Count().ToString();
        label45.Text = (finishTime - startTime).TotalMilliseconds.ToString();
      }
    }

    private void button14_Click(object sender, EventArgs e) {
      using (var serviceClient = new NdeServiceClient()) {
        IList<GIDMessage> gidMessages = new List<GIDMessage>();
        var command = new BindPlanToTrainCommand{
          planEvents = gidMessages,
          trainIdn = 10
        };
        try{
          serviceClient.ExecuteBindingCommand(command);
        } catch (Exception error) {
          string ers = error.ToString();
          MessageBox.Show(ers);
          return;
        }
      }
    }
    //-----------------------------------------------------------------------------------------------------------
    private void label42_Click(object sender, EventArgs e)
    {
      throw new NotImplementedException();
    }

    private void label43_Click(object sender, EventArgs e)
    {
      throw new NotImplementedException();
    }

    private void label44_Click(object sender, EventArgs e)
    {
      throw new NotImplementedException();
    }

    private void label45_Click(object sender, EventArgs e)
    {
      throw new NotImplementedException();
    }

    private void tabPage1_Click(object sender, EventArgs e) {

    }
  }
}
