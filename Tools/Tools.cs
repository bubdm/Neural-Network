using NN.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Globalization;
using System.Windows.Forms;

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

    public static class Initializer
    {
        public static void FillComboBox(Type helper, ComboBox cb, Config config, Const.Param param, string defaultValue)
        {
            cb.Items.Clear();
            var items = (string[])helper.GetMethod("GetItems").Invoke(null, null);
            foreach (var i in items)
            {
                cb.Items.Add(i);
            }
            var item = config.GetString(param, !String.IsNullOrEmpty(defaultValue) ? defaultValue : items.Any() ? items[0] : null);
            if (items.Any())
            {
                if (!items.Any(r => r == item))
                {
                    item = items[0];
                }
            }
            else
            {
                item = null;
            }

            if (!String.IsNullOrEmpty(item))
            {
                cb.SelectedItem = item;
            }
        }
    }

    public static class Converter
    {
        public static double? TextToDouble(string text, double? defaultValue = null)
        {
            return String.IsNullOrEmpty(text) ? defaultValue : double.TryParse(text, NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign, Culture.Current, out double a) ? a : defaultValue;
        }

        public static double TextToDouble(string text, double defaultValue)
        {
            return String.IsNullOrEmpty(text) ? defaultValue : double.TryParse(text, NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign, Culture.Current, out double a) ? a : defaultValue;
        }

        public static bool TryTextToDouble(string text, out double? result, double? defaultValue = null)
        {
            if (String.IsNullOrEmpty(text))
            {
                result = defaultValue;
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

        public static string DoubleToText(double? d, string format = "F99")
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