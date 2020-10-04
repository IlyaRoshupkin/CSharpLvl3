using MailSender.lib.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MailSender.lib.Models
{
    public class Recipient : Person//,IDataErrorInfo
    {
        //string IDataErrorInfo.this[string PropertyName]
        //{
        //    get
        //    {
        //        switch (PropertyName)
        //        {
        //            default: return null;
        //            case nameof(Name):
        //                var name = Name;
        //                if (name is null) return
        //                         "Name can`t be an empty line.";
        //                if (name.Length <= 2) return
        //                         "Name can`t be shorter than two signs.";
        //                if (name.Length > 20) return
        //                         "Name can`t be longer than twenty signs.";
        //                return null;
        //            case nameof(Address):
        //                return null;
        //        }
        //    }
        //}

        //public override string Name
        //{
        //    get => base.Name;
        //    set
        //    {
        //        if (String.IsNullOrWhiteSpace(value))
        //            throw new ArgumentNullException(nameof(value));
        //        if (!Char.IsLetter(value[0]))
        //            throw new ArgumentException("Name has to begin only with letter.",
        //                nameof(value));

        //        base.Name = value;
        //    }
        //}

        //    string IDataErrorInfo.Error { get; }="";
        //}
    }
}
