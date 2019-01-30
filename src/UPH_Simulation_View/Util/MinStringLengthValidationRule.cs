using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace UPH_Simulation_View.Util
{
    public class MinStringLengthValidationRule : ValidationRule
    {
        public double Min { get; set; }

        public override ValidationResult Validate(
          object value, System.Globalization.CultureInfo cultureInfo)
        {
            string stringValue = (string) value;

            string text = String.Format("Length must be minimum", Min);

            if (stringValue.Length < Min)
            {
                return new ValidationResult(false, "To small. " + text);
            }
            return ValidationResult.ValidResult;
        }
    }
}
