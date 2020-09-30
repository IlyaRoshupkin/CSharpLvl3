using MailSender.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace MailSender.ViewModels
{
    class MainWindowViewModel :ViewModel
    {
        private string _Title = "Text Window";
        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        }
    }
}
