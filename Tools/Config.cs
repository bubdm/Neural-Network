﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools
{
    public class Config
    {
        public static Config Main = new Config("config.txt");
        readonly string Name;
        string Extender;

        public Config(string name)
        {
            Name = name;
        }
        
        public Config Extend(long extender)
        {
            var config = new Config(Name)
            {
                Extender = extender.ToString()
            };
            return config;
        }
        
        public string GetString(Const.Param name, string defaultValue = null)
        {
            return GetValue(name, defaultValue);
        }

        public double GetDouble(Const.Param name, double defaultValue = 0)
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

        public int GetInt(Const.Param name, int defaultValue = 0)
        {
            return (int)GetDouble(name, defaultValue);
        }

        public bool GetBool(Const.Param name, bool defaultValue = false)
        {
            return 1 == GetInt(name, defaultValue ? 1 : 0);
        }

        public long[] GetArray(Const.Param name, string defaultValue = null)
        {
            if (defaultValue == null)
            {
                defaultValue = "";
            }

            string value = GetValue(name, defaultValue);
            return String.IsNullOrEmpty(value) ? new long[0] : value.Split(new[] { ',' }).Select(s => long.Parse(s.Trim())).ToArray();
        }

        public void Remove(Const.Param name)
        {
            var values = GetValues();
            if (values.TryGetValue(name.ToString("G") + Extender, out string value))
            {
                values.Remove(name.ToString("G") + Extender);
            }
            SaveValues(values);
        }

        public void Set(Const.Param name, string value)
        {
            var values = GetValues();
            values[name.ToString("G") + Extender] = value;
            SaveValues(values);
        }

        public void Set(Const.Param name, double value)
        {
            Set(name, value.ToString("G"));
        }

        public void Set(Const.Param name, int value)
        {
            Set(name, value.ToString());
        }

        public void Set(Const.Param name, bool value)
        {
            Set(name, value ? 1 : 0);
        }

        public void Set<T>(Const.Param name, IEnumerable<T> list)
        {
            Set(name, String.Join(",", list.Select(l => l.ToString())));
        }

        private string GetValue(Const.Param name, string defaultValue = null)
        {
            var values = GetValues();

            if (values.TryGetValue(name.ToString("G") + Extender, out string value))
            {
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
                        result[parts[0]] = string.Join(":", parts.Except(parts.Take(1)));
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
