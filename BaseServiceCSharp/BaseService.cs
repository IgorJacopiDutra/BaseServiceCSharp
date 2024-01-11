using BaseServiceCSharp.Model;
using BaseServiceCSharp.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace BaseServiceCSharp
{
    public partial class BaseService : ServiceBase
    {
        private TimersList timers;
        public BaseService()
        {
            FileT.SaveLog(nameof(BaseService));
            InitializeComponent();
            CriarTimers();
        }

        protected override void OnStart(string[] args)
        {
            FileT.SaveLog(nameof(OnStart));
            IniciarTimers();
        }
        private void IniciarTimers()
        {
            FileT.SaveLog("IniciarTimers");
            System.Collections.IList list = timers.Timers;
            for (int i = 0; i < list.Count; i++)
            {
                TimerModel goTimer = (TimerModel)list[i];
                FileT.SaveLog("Iniciando o timer " + goTimer.Key);
                goTimer.Timer.Start();
            }
        }

        private void CriarTimers()
        {
            timers = new TimersList();
            timers.AddTimer("EnvioCobranca", 10000, OnTimerEnvioCobranca);
            timers.AddTimer("RetornoCobranca", 10000, OnTimerRetornoCobranca);
        }

        private async void OnTimerEnvioCobranca(object sender, ElapsedEventArgs e)
        {
            (sender as Timer).Enabled = false;
            FileT.SaveLog(nameof(OnTimerEnvioCobranca));
            await Task.Delay(200000); // Aguarda assincronamente por 200 segundos
            (sender as Timer).Enabled = true;
        }

        private async void OnTimerRetornoCobranca(object sender, ElapsedEventArgs e)
        {
            (sender as Timer).Enabled = false;
            FileT.SaveLog(nameof(OnTimerRetornoCobranca));
            await Task.Delay(200000); // Aguarda assincronamente por 200 segundos

            (sender as Timer).Enabled = true;
        }

        protected override void OnStop()
        {
            StopTimers();
        }

        private void StopTimers()
        {
            FileT.SaveLog(nameof(StopTimers));
            System.Collections.IList list = timers.Timers;
            for (int i = 0; i < list.Count; i++)
            {
                TimerModel goTimer = (TimerModel)list[i];
                FileT.SaveLog("Estopando o timer " + goTimer.Key);
                goTimer.Timer.Stop();
            }
        }


    }
}
