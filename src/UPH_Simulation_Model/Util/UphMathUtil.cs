using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPH_Simulation_Model
{
    public static class UphMathUtil
    {
        private static readonly double ACCURACY = 0.0001;

        public static bool IsBetween(int number, int start, int end)
        {
            return number > start && number < end;
        }

        public static bool IsBetweenOrEqualToRight(double number, double left, double right)
        {
            bool IsGreaterThanLeft = IsGreaterThan(number, left);
            bool IsLessThanRight = IsLessThanOrEqualTo(number, right);
            return IsGreaterThanLeft && IsLessThanRight;
        }

        public static bool IsEqualTo(double left, double right)
        {
            return Math.Abs(left - right) < ACCURACY;
         }

        public static bool IsGreaterThanOrEqualTo(double left, double right)
        {
            bool areEqual = Math.Abs(left - right) < ACCURACY;
            bool greaterThan = left > right;
            return areEqual || greaterThan;
        }

        public static bool IsGreaterThan(double left, double right)
        {
            if (IsEqualTo(left, right)) 
            {
                return false;
            }
            return left > right;
        }

        public static bool IsLessThanOrEqualTo(double left, double right)
        {
            if (IsEqualTo(left, right))
            {
                return true;
            }
            return left < right;
        }

        public static bool IsNumeric(object Expression)
        {
            if (Expression == null || Expression is DateTime)
                return false;

            if (Expression is Int16 || Expression is Int32 || Expression is Int64 || Expression is Decimal || Expression is Single || Expression is Double || Expression is Boolean)
                return true;

            try
            {
                if (Expression is string)
                    Double.Parse(Expression as string);
                else
                    Double.Parse(Expression.ToString());
                return true;
            }
            catch { } // just dismiss errors but return false
            return false;
        }
    }
}
