using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Lesson1.ValidationRules
{
    class regExValidationRule : ValidationRule
    {
        private Regex _Regex;

        public string Pattern
        {
            get => _Regex?.ToString();
            set => _Regex = value is null ? null : value == string.Empty ? null : new Regex(value);
        }

        public bool AllowNull { get; set; }

        public string ErrorMessage { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value is null)
                return AllowNull ? ValidationResult.ValidResult : new ValidationResult(false, "Пустая ссылка");
            if (_Regex is null) return ValidationResult.ValidResult;

            if(!(value is string str))
                str = value.ToString();
            return _Regex.IsMatch(str) ? ValidationResult.ValidResult : new ValidationResult(false, ErrorMessage ?? "Строка не удовлетворяет  регулярному выражению");
            
        }
    }
}
