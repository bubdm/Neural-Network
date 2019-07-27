using NN.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Globalization;

namespace Tools
{
    public static class Culture
    {
        static CultureInfo CurrentCulture;
        public static CultureInfo Current
        {
            get
            {
                if (CurrentCulture == null)
                {
                    CurrentCulture = (CultureInfo)CultureInfo.InvariantCulture.Clone();
                    CurrentCulture.NumberFormat.NumberDecimalSeparator = ".";
                }

                return CurrentCulture;
            }
        }
    }

    public static class Converter
    {
        public static double? TextToDouble(string text)
        {
            return String.IsNullOrEmpty(text) ? (double?)null : double.TryParse(text, NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign, Culture.Current, out double a) ? a : (double?)null;
        }

        public static bool TryTextToDouble(string text, out double? result)
        {
            if (String.IsNullOrEmpty(text))
            {
                result = null;
                return true;
            }

            if (double.TryParse(text, NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign, Culture.Current, out double d))
            {
                result = d;
                return true;
            }

            result = null;
            return false;
        }

        static char[] _0 = new[] { '0' };
        static char[] _S = new[] { Culture.Current.NumberFormat.NumberDecimalSeparator[0] };

        public static string DoubleToText(double? d, string format = "G")
        {
            if (!d.HasValue)
            {
                return null;
            }
            else
            {
                var result = d.Value.ToString(format, Culture.Current);
                if (result.Contains(Culture.Current.NumberFormat.NumberDecimalSeparator))
                {
                    result = result.TrimEnd(_0).TrimEnd(_S);
                }
                return result;
            }
        }
    }
}   