﻿using MailSender.lib.Interfaces;
using MailSender.lib.Service;
using MailSender.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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
            .ConfigureServices(ConfigureServices)
            .Build();

        public static IServiceProvider Services => Hosting.Services;

        private static void ConfigureServices(HostBuilderContext host, IServiceCollection services)
        {
            services.AddSingleton<MainWindowViewModel>();
            services.AddTransient<IMailService, SmtpMailService>();
            //services.AddScoped<>();

            
        }
    }
}
