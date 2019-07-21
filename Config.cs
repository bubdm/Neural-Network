using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dots
{
    public class Config
    {
        public static Config Main = new Config("config.txt");

        string Name;
        string Extender;

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
            AxisOffset,

            NetworkName,
            InputMinimum,
            InputMaximum,
            InputCount,
            Randomizer,
            LayersCount,
            NeuronsCount
        }

        public Config(string name)
        {
            Name = name;
        }

        public Config Extend(string name)
        {
            Extender += name;
            return this;
        }

        public string GetString(Param name, string defaultValue = null)
        {
            return GetValue(name, defaultValue);
        }

        public double GetDouble(Param name, double defaultValue = 0)
        {
            if (double.TryParse(GetValue(name, defaultValue.ToString("G")), out double value))
            {
                return value;
            }
            else
            {
                Set(name, defaultValue);
                return defaultValue;
            }
        }

        public int GetInt(Param name, int defaultValue = 0)
        {
            return (int)GetDouble(name, defaultValue);
        }

        public bool GetBool(Param name, bool defaultValue = false)
        {
            return 1 == GetInt(name, defaultValue ? 1 : 0);
        }

        public int[] GetArray(Param name, string defaultValue = null)
        {
            string value = GetValue(name, defaultValue);
            return value.Split(new[] { ',' }).Select(s => int.Parse(s.Trim())).ToArray();
        }

        public void Set(Param name, string value)
        {
            var values = GetValues();
            values[name.ToString("G") + Extender] = value;
            SaveValues(values);
            Extender = null;
        }

        public void Set(Param name, double value)
        {
            Set(name, value.ToString("G"));
        }

        public void Set(Param name, int value)
        {
            Set(name, value.ToString());
        }

        public void Set(Param name, bool value)
        {
            Set(name, value ? 1 : 0);
        }

        private string GetValue(Param name, string defaultValue = null)
        {
            var values = GetValues();

            if (values.TryGetValue(name.ToString("G") + Extender, out string value))
            {
                Extender = null;
                return value;
            }
            else
            {
                Set(name, defaultValue);
                return defaultValue;
            }
        }

        private void SaveValues(Dictionary<string, string> values)
        {
            var lines = new List<string>();
            foreach (var pair in values)
            {
                lines.Add(pair.Key + ":" + pair.Value);
            }

            File.WriteAllLines(Name, lines);
        }

        private Dictionary<string, string> GetValues()
        {
            var result = new Dictionary<string, string>();

            if (!File.Exists(Name))
            {
                var f = File.CreateText(Name);
                f.Close();
            }

            var lines = File.ReadAllLines(Name);

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

        public void Clear()
        {
            File.WriteAllLines(Name, new string[] { });
        }
    }
}
