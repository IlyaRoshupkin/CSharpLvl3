﻿using MailSender.Data;
using MailSender.Infrastructure.Commands;
using MailSender.lib.Interfaces;
using MailSender.lib.Models;
using MailSender.ViewModels.Base;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace MailSender.ViewModels
{
    class MainWindowViewModel : ViewModel
    {
        private readonly IMailService _MailService;
        private readonly IStore<Recipient> _RecipientsStore;
        private readonly IStore<Sender> _SendersStore;
        private readonly IStore<Message> _MessagesStore;
        private readonly IStore<Server> _ServersStore;
        private readonly IStore<SchedulerTask> _SchedulerTasksStore;
        private readonly IMailSchedulerService _MailSchedulerService;

        public StatisticViewModel Statistic { get; } = new StatisticViewModel();

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
            if (!ServerEditDialog.Create(
                    out var address,
                    out var port,
                    out var ssl,
                    out var login,
                    out var password,
                    out var description))
                return;
            var server = new Server
            {
                Address = address,
                Port = port,
                UseSSL = ssl,
                Login = login,
                Password = password,
                Description = description
            };
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
            if (!(p is Server server)) return;
            var address = server.Address;
            var port = server.Port;
            var ssl = server.UseSSL;
            var login = server.Login;
            var password = server.Password;
            var description = server.Description;
            if (!ServerEditDialog.ShowDialog("Edit server",
            ref address, ref port, ref ssl,
            ref login, ref password,
            ref description))
                return;
            server.Address = address;
            server.Port = port;
            server.UseSSL = ssl;
            server.Login = login;
            server.Password = password;
            server.Description = description;
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
        }
        #endregion

        #region SendMailCommand
        private ICommand _SendMailCommand;
        public ICommand SendMailCommand =>
            _SendMailCommand ??= 
            new LambdaCommand(OnSendMailCommandExecuted, CanSendMailCommandExecute);

        private bool CanSendMailCommandExecute(object p)
        {
            if (SelectedServer is null) return false;
            if(SelectedSender is null) return false;
            if(SelectedRecipient is null) return false; 
            if(SelectedMessage is null) return false;
            return true;
        }

        private void OnSendMailCommandExecuted(object p)
        {
            var server = SelectedServer;
            var sender = SelectedSender;
            var recipient = SelectedRecipient;
            var message = SelectedMessage;

            var mail_sender = _MailService.GetSender(server.Address, server.Port,
                server.UseSSL, server.Login, server.Password);
            mail_sender.Send(sender.Address, recipient.Address, message.Subject, message.Body);

            Statistic.MessageSended();
            // Major action
        }
        #endregion
        #endregion

        private ICommand _LoadDataCommand;

        public ICommand LoadDataCommand => _LoadDataCommand
            ?? new LambdaCommand(OnLoadDataCommandExecuted, CanLoadDataCommandExecuted);

        private bool CanLoadDataCommandExecuted(object p) => true;

        private void OnLoadDataCommandExecuted(object p)
        {
            Servers = new ObservableCollection<Server>(_ServersStore.GetAll());
            Senders = new ObservableCollection<Sender>(_SendersStore.GetAll());
            Recipients = new ObservableCollection<Recipient>(_RecipientsStore.GetAll());
            Messages = new ObservableCollection<Message>(_MessagesStore.GetAll());
        }

        public MainWindowViewModel(IMailService MailService,
            IStore<Recipient> RecipientsStore,
            IStore<Sender> SendersStore,
            IStore<Message> MessagesStore,
            IStore<Server> ServersStore,
            IStore<SchedulerTask> SchedulerTasksStore,
            IMailSchedulerService MailSchedulerService)
        {
            _MailService = MailService;
            _RecipientsStore = RecipientsStore;
            _SendersStore = SendersStore;
            _MessagesStore = MessagesStore;
            _ServersStore = ServersStore;
            _SchedulerTasksStore = SchedulerTasksStore;
            _MailSchedulerService = MailSchedulerService;
        }
    }
}
