using System;
using System.ServiceProcess;
using System.Timers;
using System.Diagnostics;

namespace TimerService
{
    public class ServiceTimer : ServiceBase
    {
        private TimerTick ticTac;

        public ServiceTimer()
        {
            InitializeComponent();
            ticTac = new TimerTick();
        }

        protected override void OnStart(string[] args)
        {
            ticTac.StartTimer();
        }

        protected override void OnStop()
        {
            ticTac.OnStop();
        }

        private void InitializeComponent()
        {
            // 
            // ServiceTimer
            // 
            this.ServiceName = "ServiceTimer";
        }
    }
}
