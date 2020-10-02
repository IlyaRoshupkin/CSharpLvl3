using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MailSender
{
    /// <summary>
    /// Interaction logic for ServerEditDialog.xaml
    /// </summary>
    public partial class ServerEditDialog : Window
    {
        private ServerEditDialog() => InitializeComponent();
        private void OnPortTextInput(object Sender, TextCompositionEventArgs E)
        {
            
            if (!(Sender is TextBox text_box) || text_box.Text == "") return;
            E.Handled = !int.TryParse(text_box.Text, out _);
        }
        private void OnButtonClick(object Sender, RoutedEventArgs E)
        {
            DialogResult = !((Button)E.OriginalSource).IsCancel;
            Close();
        }
        
        public static bool ShowDialog(
        string Title, 
        ref string Address, ref int Port, ref bool UseSSL,
        ref string Login, ref string Password)
        {
            // Создаём окно и инициализируем его свойства
            var window = new ServerEditDialog
            {
                Title = Title,
                ServerAddress = { Text = Address },
                ServerPort = { Text = Port.ToString() },
                ServerSSL = { IsChecked = UseSSL },
                Login = { Text = Login },
                Password = { Password = Password },
            
                Owner = Application .Current.Windows.
                Cast<Window>().FirstOrDefault(window => window.IsActive)
            };

            if (window.ShowDialog() != true) return false;
            Address = window.ServerAddress.Text;
            Port = int.Parse(window.ServerPort.Text);
            Login = window.Login.Text;
            Password = window.Password.Password;
            return true;
        }
        public static bool Create(
        out string Address,
        out int Port,
        out bool UseSSL,
        out string Login,
        out string Password)
        {
     
            //Name = null;
            Address = null;
            Port = 25;
            UseSSL = false;
            //Description = null;
            Login = null;
            Password = null;
            return ShowDialog("Создать сервер",
            //ref Name,
            ref Address,
            ref Port,
            ref UseSSL,
            //ref Description,
            ref Login,
 ref Password);
        }
    }

}
