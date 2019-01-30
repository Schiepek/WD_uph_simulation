using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace UPH_Simulation_View.Util
{
    public class IntRangeValidationRule : ValidationRule
    {
        public int Min { get; set; }
        public int Max { get; set; }

        public override ValidationResult Validate(
          object value, System.Globalization.CultureInfo cultureInfo)
        {
            int intValue;

            string text = String.Format("Must be between {0} and {1}",
                           Min, Max);
            if (!Int32.TryParse(value.ToString(), out intValue))
                return new ValidationResult(false, "Not a number");
            if (intValue < Min)
                return new ValidationResult(false, "To small. " + text);
            if (intValue > Max)
                return new ValidationResult(false, "To large. " + text);
            return ValidationResult.ValidResult;
        }
    }
}
