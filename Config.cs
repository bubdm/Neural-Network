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

        public enum Param
        {
            ScreenWidth,
            ScreenHeight,
            ScreenLeft,
            ScreenTop,
            OnTop,
            PointsCount,
            PointSize,
            PointsArrangeSnap,
            LayersSize,
            DataPanelWidth,
            AxisOffset
        }

        public static string GetString(Param name, string defaultValue = null)
        {
            return GetValue(name, defaultValue);
        }

        public static double GetDouble(Param name, double defaultValue = 0)
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

        public static int GetInt(Param name, int defaultValue = 0)
        {
            return (int)GetDouble(name, defaultValue);
        }

        public static bool GetBool(Param name, bool defaultValue = false)
        {
            return 1 == GetInt(name, defaultValue ? 1 : 0);
        }

        public static int[] GetArray(Param name, string defaultValue = null)
        {
            string value = GetValue(name, defaultValue);
            return value.Split(new[] { ',' }).Select(s => int.Parse(s.Trim())).ToArray();
        }

        public static void AddValue(Param name, string value)
        {
            var values = GetValues();
            values[name.ToString("G")] = value;
            SaveValues(values);
        }

        public static void AddValue(Param name, double value)
        {
            AddValue(name, value.ToString("G"));
        }

        public static void AddValue(Param name, int value)
        {
            AddValue(name, value.ToString());
        }

        public static void AddValue(Param name, bool value)
        {
            AddValue(name, value ? 1 : 0);
        }

        private static string GetValue(Param name, string defaultValue = null)
        {
            var values = GetValues();

            if (values.TryGetValue(name.ToString("G"), out string value))
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
