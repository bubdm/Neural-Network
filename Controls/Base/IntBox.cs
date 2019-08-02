﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tools;

namespace NN.Controls
{
    public class IntBox : TextBox, IConfigValue
    {
        public event Action Changed = delegate { };

        public Const.Param ConfigParameter
        {
            get;
            set;
        }

        public int? DefaultValue
        {
            get;
            set;
        }

        public int MinimumValue
        {
            get;
            set;
        }

        public int MaximumValue
        {
            get;
            set;
        }

        public bool IsNullAllowed
        {
            get;
            set;
        }

        public IntBox()
        {
            TextChanged += IntBox_TextChanged;
        }

        private void IntBox_TextChanged(object sender, EventArgs e)
        {
            if (IsValid())
            {
                BackColor = Color.White;
                Changed();
            }
            else
            {
                BackColor = Color.Tomato;
            }
        }

        public bool IsValid()
        {
            if (IsNull() && IsNullAllowed)
            {
                return true;
            }

            return Converter.TryTextToInt(Text, out int? value) && value >= MinimumValue && value <= MaximumValue;
        }

        public bool IsNull()
        {
            return String.IsNullOrEmpty(Text);
        }

        public int Value => IsValid() ? (IsNull() ? throw new InvalidValueException(ConfigParameter, "null") : Converter.TextToInt(Text).Value) : throw new InvalidValueException(ConfigParameter, Text);
        public int? ValueOrNull => IsNull() && IsNullAllowed ? (int?)null : IsValid() ? Converter.TextToInt(Text) : throw new InvalidValueException(ConfigParameter, Text);

        public void Load(Config config)
        {
            Text = Converter.IntToText(config.GetInt(ConfigParameter, DefaultValue));
        }

        public void Save(Config config)
        {
            config.Set(ConfigParameter, IsNullAllowed ? ValueOrNull : Value);
        }

        public void Vanish(Config config)
        {
            config.Remove(ConfigParameter);
        }

        public void SetChangeEvent(Action action)
        {
            Changed -= action;
            Changed += action;
        }
    }
}
