using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.ServiceProcess;
using System.Text;
using NdeServices;

namespace NdeWcfOverWinService
{
  public partial class Service1 : ServiceBase
  {
    private ServiceHost _serviceHost;

    public Service1(){
      InitializeComponent();
    }

    protected override void OnStart(string[] args){
      if(_serviceHost != null){
        _serviceHost.Close();
      }
      _serviceHost = new ServiceHost(typeof(NdeService));
      _serviceHost.Open();
    }

    protected override void OnStop(){
      if(_serviceHost != null){
        _serviceHost.Close();
        _serviceHost = null;
      }
    }
  }
}
