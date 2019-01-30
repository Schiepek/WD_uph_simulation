using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace UPH_Simulation_View.Util
{
    public class DoubleRangeValidationRule : ValidationRule
    {
        public double Min { get; set; }
        public double Max { get; set; }

        public override ValidationResult Validate(
          object value, System.Globalization.CultureInfo cultureInfo)
        {
            double doubleValue;

            string text = String.Format("Must be between {0} and {1}",
                           Min, Max);
            if (!Double.TryParse(value.ToString(), out doubleValue))
                return new ValidationResult(false, "Not a number");
            if (doubleValue < Min)
                return new ValidationResult(false, "To small. " + text);
            if (doubleValue > Max)
                return new ValidationResult(false, "To large. " + text);
            return ValidationResult.ValidResult;
        }
    }
}
