using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;
using System.Windows;
using System.Windows.Input;
using MailSender.Infrastructure.Commands;

namespace MailSender.ViewModels.Base
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

        private ICommand _ShowDialogCommand;
        public ICommand ShowDialogCommand => _ShowDialogCommand
            ??= new LambdaCommand(OnShowDialogCommandExecuted);

        private void OnShowDialogCommandExecuted(object p)
        {
            MessageBox.Show("Hello World");
        }

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
