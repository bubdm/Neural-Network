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

        public static string DoubleToText(double? d)
        {
            if (!d.HasValue)
            {
                return null;
            }
            else
            {
                return d.Value.ToString("G", Culture.Current);
            }
        }
    }
}   