using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace TestMailSender.ViewModels.Base
{
    class MainWindowViewModel : ViewModel
    {
        private string _Title = "Text Window";
        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        }
        public DateTime CurrentTime => DateTime.Now;

        private bool _TimerEnabled = true;

        public bool TimerEnabled
        {
            get => _TimerEnabled;
            set
            {
                if (!Set(ref _TimerEnabled, value)) return;
                _Timer.Enabled = value;
            }
        }

        private readonly Timer _Timer;
        public MainWindowViewModel()
        {
            _Timer = new Timer(100);
            _Timer.Elapsed += OnTimerElapsed;
            _Timer.AutoReset = true;
            _Timer.Enabled = true;
        }

        private void OnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            OnProprtyChanged(nameof(CurrentTime));
        }
    }
}
