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
//using RealNdeServiceTest.ServiceReference1;

namespace RealNdeServiceTest
{
  public partial class Form1 : Form
  {
    public Form1() {
      InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e) {
      System.Net.WebProxy wp = new System.Net.WebProxy("10.4.253.70", 3128);
      wp.Credentials = new System.Net.NetworkCredential("zenuk", "12345");
      // moved to app.config
      System.Net.ServicePointManager.Expect100Continue = false;
      //
      System.Net.WebRequest.DefaultWebProxy = wp; 
      //using (var clint = new NdeServiceClient())
      //{
      //  DateTime startTime, stopTime;
      //  TimeSpan wrTime;

      //  IList<TrainEvent> trainEvents;
      //  IList<WorkMessage> workMessages;
      //  //
      //  startTime = DateTime.Now;
      //  try
      //  {
      //    trainEvents = clint.GetLastTrainEvents();
      //  }
      //  catch (Exception error)
      //  {
      //    string ers = error.ToString();
      //    MessageBox.Show(ers);
      //    return;
      //    //throw;
      //  }
        //stopTime = DateTime.Now;
        //wrTime = stopTime - startTime;
        //label1.Text = "всего поездов";
        //label2.Text = trainEvents.Count.ToString();
        //label3.Text = "получено за ";
        //label4.Text = wrTime.TotalMilliseconds.ToString();
        //workMessages = clint.GetWorkMessages();
      //}
    }

    private void button2_Click(object sender, EventArgs e) {
      //using (var client = new NdeServiceClient()) {
      //  var sourceThreadId = int.Parse(txtSourceThreadId.Text);
      //  var targetThreadId = int.Parse(txtTargetThreadId.Text);
      //  var command = new BindTrainThreadsCommnand
      //    {
      //      SourceId = sourceThreadId, 
      //      TargetId = targetThreadId
      //    };
      //  client.ExecuteBindingCommand(command);
      //}
    }

    private void button3_Click(object sender, EventArgs e) {
      //using (var client = new NdeServiceClient()) {
      //  var targetThreadId = int.Parse(textBox1.Text);
      //  var command = new AssignTrainNumberCommand {
      //    TrainThreadId = targetThreadId, 
      //    TrainNumber = textBox2.Text,
      //    StationCode = textBox3.Text,
      //    TrainNumberPrefix = textBox4.Text,
      //    TrainNumberSuffix = textBox5.Text
      //  };
      //  client.ExecuteBindingCommand(command);
      //}
    }

    private void button4_Click(object sender, EventArgs e) {
      //using (var client = new NdeServiceClient()) {
      //  var command = new RunTrackIoTrackCommand {
      //    trainIdn = int.Parse(textBox6.Text),
      //    trackName = textBox7.Text,
      //    stationCode = textBox8.Text
      //  };
      //  client.ExecuteBindingCommand(command);
      //}
    }
  }
}
