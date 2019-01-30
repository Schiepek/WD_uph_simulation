using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace UPH_Simulation_View.Util
{
    public class StringCharacterValidationRule : ValidationRule
    {
        private readonly string regexString = UPH_Simulation_View.Properties.Settings.Default.StringRegex;

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string stringValue = (string)value;

            Regex regex = new Regex(regexString);
            Match match = regex.Match(stringValue);

            if (match.Success)
            {
                return ValidationResult.ValidResult;
            }
            return new ValidationResult(false, "String does not match expression: " + regexString);
        }
    }
}
