using MailSender.Data;
using MailSender.Data.Stores.InDB;
using MailSender.Data.Stores.InMemory;
using MailSender.lib.Interfaces;
using MailSender.lib.Models;
using MailSender.lib.Service;
using MailSender.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MailSender
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static IHost _Hosting;
        public static IHost Hosting => _Hosting
            ??= Host.CreateDefaultBuilder(
                Environment.GetCommandLineArgs())
            .ConfigureAppConfiguration(cfg=>cfg
            //.AddXmlFile("appsettings.xml",true,true))
            .AddJsonFile("appconfig.json", true, true))
        .ConfigureLogging(log=>log
        .AddConsole()
        .AddDebug())
            .ConfigureServices(ConfigureServices)
            .Build();

        public static IServiceProvider Services => Hosting.Services;

        private static void ConfigureServices(HostBuilderContext host, IServiceCollection services)
        {
            services.AddSingleton<MainWindowViewModel>();

#if DEBUG
            services.AddTransient<IMailService, DebugMailService>();
#else
            services.AddTransient<IMailService, SmtpMailService>();

#endif
            services.AddSingleton<IEncryptorService, Rfc2898Encryptor>();
            services.AddDbContext<MailSenderDB>(opt => opt.UseSqlServer(host.Configuration
                .GetConnectionString("Default")));
            services.AddTransient<MailSenderDbInitializer>();

            services.AddSingleton<IStore<Recipient>, RecipientsStoreInDB>();
            services.AddSingleton<IStore<Sender>, SendersStoreInDB>();
            services.AddSingleton<IStore<Message>, MessagesStoreInDB>();
            services.AddSingleton<IStore<Server>, ServersStoreInDB>();
            services.AddSingleton<IStore<SchedulerTask>, SchedulerTasksStoreInDB>();
            //services.AddSingleton<IStore<Recipient>, RecipientsStoreInMemory>();

            services.AddSingleton<IMailSchedulerService, TaskMailSchedulerService>();

            //services.AddScoped<>();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            Services.GetRequiredService<MailSenderDbInitializer>().Initialize();
            base.OnStartup(e);

            //using (var db = Services.GetRequiredService<MailSenderDB>())
            //{
            //    var to_remove = db.SchedulerTasks.Where(task => task.Time < DateTime.Now);
            //    if (to_remove.Any())
            //    {
            //        db.SchedulerTasks.RemoveRange(to_remove);
            //        db.SaveChanges();
            //    }
            //}
        }
    }
}
