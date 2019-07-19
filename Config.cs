using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dots
{
    public static class Config
    {
        const string CONFIG_NAME = "config.txt";

        public const string SCREEN_WIDTH = "screen_width";

        public const string POINTS_COUNT = "points_count";
        public const string POINT_SIZE = "point_size";
        public const string POINT_ARRANGE_SNAP = "point_arrange_snap";
        public const string LAYERS_SIZE = "layers_size";
        public const string DATA_PANEL_WIDTH = "data_panel_width";
        public const string AXIS_OFFSET = "axis_offset";

        public static string GetString(string name, string defaultValue = null)
        {
            return GetValue(name, defaultValue);
        }

        public static double GetNumber(string name, double defaultValue = 0)
        {
            if (double.TryParse(GetValue(name, defaultValue.ToString("G")), out double value))
            {
                return value;
            }
            else
            {
                AddValue(name, defaultValue);
                return defaultValue;
            }
        }

        public static int[] GetArray(string name, string defaultValue = null)
        {
            string value = GetValue(name, defaultValue);
            return value.Split(new[] { ',' }).Select(s => int.Parse(s)).ToArray();
        }

        public static void AddValue(string name, string value)
        {
            var values = GetValues();
            values[name] = value;
            SaveValues(values);
        }

        public static void AddValue(string name, double value)
        {
            AddValue(name, value.ToString("G"));
        }

        private static string GetValue(string name, string defaultValue = null)
        {
            var values = GetValues();

            if (values.TryGetValue(name, out string value))
            {
                return value;
            }
            else
            {
                AddValue(name, defaultValue);
                return defaultValue;
            }
        }

        private static void SaveValues(Dictionary<string, string> values)
        {
            var lines = new List<string>();
            foreach (var pair in values)
            {
                lines.Add(pair.Key + ":" + pair.Value);
            }

            File.WriteAllLines(CONFIG_NAME, lines);
        }

        private static Dictionary<string, string> GetValues()
        {
            var result = new Dictionary<string, string>();

            if (!File.Exists(CONFIG_NAME))
            {
                var f = File.CreateText(CONFIG_NAME);
                f.Close();
            }

            var lines = File.ReadAllLines(CONFIG_NAME);

            foreach (var line in lines)
            {
                if (line.Contains(":"))
                {
                    var parts = line.Split(new[] { ':' });
                    if (parts.Count() > 1)
                    {
                        result[parts[0]] = string.Concat(parts.Except(parts.Take(1)));
                    }
                }
            }

            return result;
        }

        public static void Clear()
        {
            File.WriteAllLines(CONFIG_NAME, new string[] { });
        }
    }
}
