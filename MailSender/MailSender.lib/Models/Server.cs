using MailSender.lib.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace MailSender.lib.Models
{
    public class Server:Entity
    {
        private string _Address;
        private int _Port;
        private string _Login;
        private bool _UseSSL;
        private string _Password;
        private string _Description;

        public string Address
        {
            get => _Address;
            set { _Address = value; }
        }

        public int Port
        {
            get => _Port;
            set
            {
                if (value < 0 || value >= 65535)
                    throw new ArgumentOutOfRangeException(
                        nameof(value),value,"Port number has to be in the range " +
                        "from 0 to 65535.");
                _Port = value;
            }
        }
        public string Login 
        {
            get => _Login;
            set { _Login = value; }
        }
        public bool UseSSL
        {
            get => _UseSSL;
            set { _UseSSL = value; }
        }
        public string Password
        {
            get => _Password;
            set { _Password = value; }
        }
        public string Description
        {
            get => _Description;
            set { _Description = value; }
        }
    }
}
