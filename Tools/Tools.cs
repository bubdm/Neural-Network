using Dots.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Tools
{
    public static class Converter
    {
        public static double? TextToDouble(string text)
        {
            return String.IsNullOrEmpty(text) ? (double?)null : double.TryParse(text, out double a) ? a : (double?)null;
        }
}
}   