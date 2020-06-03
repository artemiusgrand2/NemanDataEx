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
using ServiceNdeTest.ServiceReference1;
//using TrainEvent = ServiceNdeTest.ServiceReference1.TrainEvent;
//using WorkMessage = ServiceNdeTest.ServiceReference1.WorkMessage;

namespace ServiceNdeTest
{
  public partial class Form1 : Form
  {
    public Form1() {
      InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e) {
      using (var client = new NdeServiceClient())
      {
        IList<TrainEvent> trainEvents;
        //IList<WorkMessage> workMessages;
        //IList<GIDMessage> gidMessages;
        IList<ComDefinition> comDefinitions;

        trainEvents = client.GetLastTrainEvents();
        //workMessages = client.GetWorkMessages();
        //gidMessages = client.GetGIDMessages();
        client.ExecuteBindingCommand(
          new SetDefSendFlagCommand {
            defIdn = 1,
            sendFlag = 2
          }
        );
        try {
          comDefinitions = client.GetComDefinitions();
        }
        catch (Exception error)
        {
          string err = error.ToString();
        }
      }
    }

    private void button2_Click(object sender, EventArgs e) {
      using (var client = new NdeServiceClient())
      {
        var sourceThreadId = int.Parse(txtSourceThreadId.Text);
        var targetThreadId = int.Parse(txtTargetThreadId.Text);
        client.ExecuteBindingCommand(
          new BindTrainThreadsCommnand{
            SourceId = sourceThreadId, 
            TargetId = targetThreadId
          }
        );
      }
    }
  }
}
