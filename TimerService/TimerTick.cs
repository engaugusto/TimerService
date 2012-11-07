using System.Timers;
using System.Diagnostics;
using System;

namespace TimerService
{
    public class TimerTick
    {
        private EventLog _eventLog;
        private Timer _timer;
        private bool _log;

        public delegate void TimerTicked();

        public TimerTicked Ticked { get; set; }

        public TimerTick(bool log = false)
        {
            _log = log;
            _timer = new Timer();
            _eventLog = new EventLog();
        }
        
        public void StartTimer()
        {
            //1: Adicionando o evento Elapsed ao objeto Timer
            _timer.Elapsed += new ElapsedEventHandler(OnElapsedTime);

            //2: Marcando o como intervalo 1 minuto (= 60,000 milliseconds)
            _timer.Interval = 1000;

            //3: Habilitando o objeto timer para execução.
            _timer.Enabled = true;
            
            if(_log)
                //Escreve no Visualizador de Evento do Windows
                _eventLog.WriteEntry("Serviço Inicializado.", EventLogEntryType.Information);
        }

        public void OnElapsedTime(object source, ElapsedEventArgs e)
        {
            if (_log)
                _eventLog.WriteEntry("Executando serviço: " +
                    DateTime.Now.ToShortTimeString(), EventLogEntryType.Information);
            Ticked();
        }

        public void OnStop()
        {
            _timer.Enabled = false;
            if (_log)
                _eventLog.WriteEntry("Serviço Parado.", EventLogEntryType.Information);
        }

    }
}
