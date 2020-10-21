using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using MailSender.Infrastructure.Commands.Base;

namespace MailSender.Infrastructure.Commands
{
    class CloseWindowCommand : Command
    {
        protected override void Execute(object p)
        {
            if (!(p is Window window))
                window = Application.Current.Windows.
                    Cast<Window>().FirstOrDefault(w => w.IsFocused);
            if (window is null)
                window = Application.Current.Windows.
                    Cast<Window>().FirstOrDefault(w => w.IsActive);
            window?.Close();
        }
    }
}
