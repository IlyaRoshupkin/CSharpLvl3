using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace MailSender.Infrastructure.ValidationRules
{
    public class RegExValidation : ValidationRule
    {
        private Regex _Regex;
        public string Pattern
        {
            get => _Regex?.ToString();
            set => _Regex = string.IsNullOrEmpty(value) 
                ? null : new Regex(value);
        }

        public bool AllowNull { get; set; }

        public string ErrorMessage { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            //return new ValidationResult(false, "Information about a current error.");
            if (value is null)
                return AllowNull
                    ? ValidationResult.ValidResult
                    : new ValidationResult(false, ErrorMessage
                    ?? "There is no reference to the string");
            if (_Regex is null) return ValidationResult.ValidResult;
            if (!(value is string str))
                str = value.ToString();
            return _Regex.IsMatch(str)
                ?ValidationResult.ValidResult
                :new ValidationResult(false,ErrorMessage 
                ?? $"The line doesn`t meet the requirements of the expression {Pattern})");
        }
    }
}
