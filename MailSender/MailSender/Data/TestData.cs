using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using MailSender.Models;
using MailSender.lib.Service;

namespace MailSender.Data
{
    static class TestData
    {
        public static List<Sender> Senders { get; } = Enumerable.Range(1, 10)
            .Select(i => new Sender
            {
                Name = $"Sender {i}",
                Address = $"sender_{i}@server.ru"
            })
            .ToList();

        public static List<Recipient> Recipients { get; } = Enumerable.Range(1, 10)
           .Select(i => new Recipient
           {
               Name = $"Recipient {i}",
               Address = $"recipient{i}@server.ru"
           })
           .ToList();

        public static List<Server> Servers { get; } = Enumerable.Range(1, 10)
           .Select(i => new Server
           {
               Address = $"smtp.server{i}.com",
               Port = 25,
               Login = $"Login-{i}",
               Password = TextEncoder.Encode($"Password-{i}"),
               UseSSL = i%2==0
           })
           .ToList();

        public static List<Message> Messages { get; } = Enumerable.Range(1, 20)
            .Select(i => new Message
            {
                Subject = $"Message {i}",
                Body = $"A message`s text"
            })
            .ToList();
    }
}
