using MailSender.Data;
using MailSender.Infrastructure.Commands;
using MailSender.Models;
using MailSender.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace MailSender.ViewModels
{
    class MainWindowViewModel : ViewModel
    {
        private string _Title = "Test Window";
        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        }

        #region Properties

        private ObservableCollection<Server> _Servers;
        public ObservableCollection<Server> Servers
        {
            get => _Servers;
            set => Set(ref _Servers, value);
        }

        private ObservableCollection<Sender> _Senders;
        public ObservableCollection<Sender> Senders
        {
            get => _Senders;
            set => Set(ref _Senders, value);
        }

        private ObservableCollection<Recipient> _Recipients;
        public ObservableCollection<Recipient> Recipients
        {
            get => _Recipients;
            set => Set(ref _Recipients, value);
        }

        private ObservableCollection<Message> _Messages;
        public ObservableCollection<Message> Messages
        {
            get => _Messages;
            set => Set(ref _Messages, value);
        }

        private Server _SelectedServer;
        public Server SelectedServer
        {
            get => _SelectedServer;
            set => Set(ref _SelectedServer, value);
        }

        private Sender _SelectedSender;
        public Sender SelectedSender
        {
            get => _SelectedSender;
            set => Set(ref _SelectedSender, value);
        }

        private Recipient _SelectedRecipient;
        public Recipient SelectedRecipient
        {
            get => _SelectedRecipient;
            set => Set(ref _SelectedRecipient, value);
        }

        private Message _SelectedMessage;
        public Message SelectedMessage
        {
            get => _SelectedMessage;
            set => Set(ref _SelectedMessage, value);
        }
        #endregion

        #region Commands
        #region CreateNewServerCommand
        private ICommand _CreateNewServerCommand;
        public ICommand CreateNewServerCommand =>
            _CreateNewServerCommand ??= new LambdaCommand(OnCreateNewServerCommandExecuted,CanCreateNewServerCommandExecute);

        private bool CanCreateNewServerCommandExecute(object p) => true;

        private void OnCreateNewServerCommandExecuted(object p)
        {
            // Major action
        }
        #endregion
        #region EditNewServerCommand
        private ICommand _EditNewServerCommand;
        public ICommand EditNewServerCommand =>
            _EditNewServerCommand ??= new LambdaCommand(OnEditNewServerCommandExecuted, CanEditNewServerCommandExecute);

        private bool CanEditNewServerCommandExecute(object p) => 
            p is Server||SelectedServer!=null;

        private void OnEditNewServerCommandExecuted(object p)
        {
            var server = p as Server ?? SelectedServer;
            if (server is null) return;
            // Major action(look for in the methodbook)
        }
        #endregion
        #region DeleteNewServerCommand
        private ICommand _DeleteNewServerCommand;
        public ICommand DeleteNewServerCommand =>
            _DeleteNewServerCommand ??= new LambdaCommand(OnDeleteNewServerCommandExecuted, CanDeleteNewServerCommandExecute);

        private bool CanDeleteNewServerCommandExecute(object p) => true;

        private void OnDeleteNewServerCommandExecuted(object p)
        {
            var server = p as Server ?? SelectedServer;
            if (server is null) return;
            Servers.Remove(server);
            SelectedServer = Servers.FirstOrDefault();
            // Major action
        }
        #endregion
        #endregion

        public MainWindowViewModel()
        {
            Servers = new ObservableCollection<Server>(TestData.Servers);
            Senders = new ObservableCollection<Sender>(TestData.Senders);
            Recipients = new ObservableCollection<Recipient>(TestData.Recipients);
            Messages = new ObservableCollection<Message>(TestData.Messages);
        }
    }
}
