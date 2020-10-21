using MailSender.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace MailSender.ViewModels
{
    class StatisticViewModel:ViewModel
    {
        private int _SendMessageCount;

        public int SendMessageCount 
        { 
            get => _SendMessageCount;
            private set => Set(ref _SendMessageCount, value);
        }

        public void MessageSended() => SendMessageCount++;
    }
}
