using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace MailSender.ViewModels
{
    class ViewModelLocator
    {
        public MainWindowViewModel MainWindowViewModel =>
            App.Services.GetRequiredService<MainWindowViewModel>();
    }
}
